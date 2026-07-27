// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// A single-instrument, bar-by-bar backtester with an explicitly causal execution model.
/// </summary>
/// <remarks>
/// <para>
/// <b>The execution timeline.</b> For every bar <c>i</c>, in this exact order:
/// </para>
/// <list type="number">
/// <item>
/// <description>
/// the cursor moves to bar <c>i</c>, so bars <c>0..i</c> become readable and <c>i+1..</c> do not;
/// </description>
/// </item>
/// <item>
/// <description>
/// the signal produced at the close of bar <c>i-1</c> is filled at <c>Open(i)</c>, with slippage and
/// commission;
/// </description>
/// </item>
/// <item>
/// <description>
/// on the final bar, any position still open is liquidated at <c>Close(i)</c> when
/// <see cref="BacktestOptions.CloseOpenPositionAtEnd"/> is set;
/// </description>
/// </item>
/// <item>
/// <description>
/// the account is marked to market at <c>Close(i)</c> and one <see cref="EquityPoint"/> is appended;
/// </description>
/// </item>
/// <item>
/// <description>
/// the strategy is asked for a signal, seeing bars <c>0..i</c> only. That signal is queued for bar
/// <c>i+1</c>.
/// </description>
/// </item>
/// </list>
/// <para>
/// <b>Why there is no look-ahead bias.</b> The rule "a decision taken from bars <c>0..i</c> executes at
/// <c>Open(i+1)</c>" is enforced by construction, not by discipline:
/// </para>
/// <list type="bullet">
/// <item>
/// <description>
/// the strategy is handed an <see cref="IBarWindow"/> whose <see cref="IBarWindow.Count"/> is <c>i+1</c> and
/// which throws <see cref="LookAheadException"/> for any index above <c>i</c>;
/// </description>
/// </item>
/// <item>
/// <description>
/// indicators are pre-computed over the whole series (which is safe, because every TA-Lib function is
/// causal) and then re-indexed through <see cref="IndicatorSeries"/>, which is bound to the same cursor and
/// throws on a future index;
/// </description>
/// </item>
/// <item>
/// <description>
/// the length of the full series never leaks either: <see cref="IndicatorSeries.Count"/>,
/// <see cref="IndicatorSeries.BegIdx"/> and <see cref="IndicatorSeries.NBElement"/> are window-relative too,
/// so a strategy cannot read the total bar count out of an indicator it obtained in
/// <see cref="IStrategy.Initialize"/>;
/// </description>
/// </item>
/// <item>
/// <description>
/// nothing in <see cref="IBarWindow"/>, <see cref="IIndicatorSource"/> or <see cref="IndicatorSeries"/>
/// returns the backing arrays, so the future cannot be reached indirectly;
/// </description>
/// </item>
/// <item>
/// <description>
/// the returned signal is stored, not executed, and the fill price is read from the <em>next</em> bar's
/// open.
/// </description>
/// </item>
/// </list>
/// <para>
/// A strategy that tries to cheat therefore fails loudly with <see cref="LookAheadException"/> rather than
/// quietly reporting an impossible Sharpe ratio. The engine never swallows that exception.
/// </para>
/// <para>
/// <b>Cost model.</b> A buy fills at <c>price * (1 + slippage)</c>, a sell at <c>price * (1 - slippage)</c>,
/// and each fill is charged <c>notional * commission</c> where the notional uses the filled price. Position
/// size is chosen so that the cash needed — notional plus commission — never exceeds the allocated budget,
/// which keeps cash non-negative for any <see cref="BacktestOptions.PositionFraction"/> up to <c>1</c>.
/// </para>
/// </remarks>
public sealed class BacktestEngine
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BacktestEngine"/> class with the default option set.
    /// </summary>
    public BacktestEngine()
        : this(new BacktestOptions())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BacktestEngine"/> class.
    /// </summary>
    /// <param name="options">The simulated market and account settings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="options"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="options"/> contains an out-of-range value.</exception>
    public BacktestEngine(BacktestOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        options.Validate();
        Options = options;
    }

    /// <summary>
    /// Gets the options this engine simulates with.
    /// </summary>
    public BacktestOptions Options { get; }

    /// <summary>
    /// Runs a strategy over a bar series.
    /// </summary>
    /// <param name="strategy">The strategy to simulate.</param>
    /// <param name="bars">
    /// The bar series, ordered ascending by timestamp. An empty series is valid and yields an empty result.
    /// </param>
    /// <returns>The equity curve, the completed trades and the performance metrics of the run.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="strategy"/> or <paramref name="bars"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="LookAheadException">The strategy attempted to read data from the future.</exception>
    public BacktestResult Run(IStrategy strategy, IReadOnlyList<Bar> bars)
    {
        ArgumentNullException.ThrowIfNull(strategy);
        ArgumentNullException.ThrowIfNull(bars);

        BarWindow window = new(bars);
        IndicatorSet indicators = new(bars, window);
        strategy.Initialize(indicators);

        RunState state = new(Options.InitialCapital);
        Signal pending = Signal.Hold;
        int lastIndex = bars.Count - 1;

        for (int i = 0; i <= lastIndex; i++)
        {
            // (1) Advance the causal cursor. Bars 0..i are now readable; i+1.. still throw.
            window.MoveTo(i);
            Bar bar = bars[i];

            // (2) Fill the order decided at the close of bar i-1, at the open of bar i.
            if (pending != Signal.Hold)
            {
                Apply(pending, state, i, bar.Timestamp, bar.Open);
            }

            // (3) Liquidate on the last bar so the trade list and the final equity are fully realised.
            if (i == lastIndex && state.Position is not null && Options.CloseOpenPositionAtEnd)
            {
                ClosePosition(state, i, bar.Timestamp, bar.Close);
            }

            // (4) Mark to market at the close of bar i.
            double signedQuantity = state.Position?.SignedQuantity ?? 0.0;
            double equity = state.Cash + (signedQuantity * bar.Close);
            state.EquityCurve.Add(new EquityPoint(i, bar.Timestamp, bar.Close, state.Cash, signedQuantity, equity));

            // (5) Ask for the next target exposure. The strategy sees bars 0..i and nothing else.
            //     On the last bar the answer can no longer be executed, so it is discarded.
            Signal next = strategy.Evaluate(window, state.Position);
            pending = i < lastIndex ? next : Signal.Hold;
        }

        PerformanceMetrics metrics = PerformanceMetrics.Compute(
            state.EquityCurve,
            state.Trades,
            Options.InitialCapital,
            Options.BarsPerYear,
            Options.RiskFreeRate);

        return new BacktestResult(strategy.Name, Options, state.EquityCurve, state.Trades, metrics);
    }

    private void Apply(Signal signal, RunState state, int index, DateTime timestamp, double price)
    {
        // Shorting disabled: a reversal signal degrades to "go flat" rather than being silently ignored,
        // so a long/short strategy still behaves sensibly in a long-only account.
        if (signal == Signal.EnterShort && !Options.AllowShort)
        {
            signal = Signal.Exit;
        }

        switch (signal)
        {
            case Signal.Exit:
                ClosePosition(state, index, timestamp, price);
                break;

            case Signal.EnterLong:
                if (state.Position?.IsLong == true)
                {
                    return;
                }

                ClosePosition(state, index, timestamp, price);
                OpenPosition(state, OrderSide.Buy, index, timestamp, price);
                break;

            case Signal.EnterShort:
                if (state.Position?.IsShort == true)
                {
                    return;
                }

                ClosePosition(state, index, timestamp, price);
                OpenPosition(state, OrderSide.Sell, index, timestamp, price);
                break;

            case Signal.Hold:
            default:
                break;
        }
    }

    private void OpenPosition(RunState state, OrderSide side, int index, DateTime timestamp, double price)
    {
        double fillPrice = FillPrice(price, side);
        if (!double.IsFinite(fillPrice) || fillPrice <= 0.0)
        {
            return;
        }

        // Any previous position has already been liquidated by the caller, so cash is the whole of equity.
        double equity = state.Cash + (state.Position?.MarketValue(price) ?? 0.0);
        double budget = Options.Sizing == PositionSizing.FixedFraction
            ? equity * Options.PositionFraction
            : Math.Min(Options.PositionCash, equity);

        if (!double.IsFinite(budget) || budget <= 0.0)
        {
            return;
        }

        // Solve  qty * fillPrice * (1 + commissionRate) = budget  so that the cash leg, commission included,
        // exactly consumes the budget and never overdraws the account.
        double quantity = budget / (fillPrice * (1.0 + Options.CommissionRate));
        if (!double.IsFinite(quantity) || quantity <= 0.0)
        {
            return;
        }

        double commission = quantity * fillPrice * Options.CommissionRate;
        state.Cash += side == OrderSide.Buy
            ? -((quantity * fillPrice) + commission)
            : (quantity * fillPrice) - commission;

        state.Position = new Position(side, quantity, fillPrice, index, timestamp, commission);
    }

    private void ClosePosition(RunState state, int index, DateTime timestamp, double price)
    {
        if (state.Position is not { } position)
        {
            return;
        }

        OrderSide closingSide = position.IsLong ? OrderSide.Sell : OrderSide.Buy;
        double fillPrice = FillPrice(price, closingSide);
        double commission = position.Quantity * fillPrice * Options.CommissionRate;

        state.Cash += position.IsLong
            ? (position.Quantity * fillPrice) - commission
            : -((position.Quantity * fillPrice) + commission);

        state.Trades.Add(new Trade(
            position.Side,
            position.Quantity,
            position.EntryIndex,
            position.EntryTime,
            position.EntryPrice,
            index,
            timestamp,
            fillPrice,
            position.EntryCommission + commission));

        state.Position = null;
    }

    private double FillPrice(double price, OrderSide side)
    {
        return side == OrderSide.Buy
            ? price * (1.0 + Options.SlippageRate)
            : price * (1.0 - Options.SlippageRate);
    }

    private sealed class RunState(double initialCash)
    {
        public double Cash { get; set; } = initialCash;

        public Position? Position { get; set; }

        public List<Trade> Trades { get; } = [];

        public List<EquityPoint> EquityCurve { get; } = [];
    }
}
