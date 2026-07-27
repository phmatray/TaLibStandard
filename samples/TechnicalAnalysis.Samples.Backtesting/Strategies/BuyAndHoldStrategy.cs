// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Strategies;

/// <summary>
/// The baseline every other strategy is measured against: buy once, hold to the end.
/// </summary>
/// <remarks>
/// <para><b>Entry.</b> A single long signal is emitted at the close of the first bar and filled at the open
/// of the second bar, exactly like any other strategy — the baseline pays the same slippage and commission
/// as its competitors, so the comparison is fair.</para>
/// <para><b>Exit.</b> None. The engine liquidates the position at the close of the last bar when
/// <see cref="BacktestOptions.CloseOpenPositionAtEnd"/> is set, which makes the run exactly one round trip.
/// Its net return is therefore the return of the underlying series from the second bar's open to the last
/// bar's close, less one round trip of costs.</para>
/// <para><b>Warm-up.</b> None; the strategy uses no indicator.</para>
/// </remarks>
public sealed class BuyAndHoldStrategy : IStrategy
{
    private bool _entered;

    /// <inheritdoc />
    public string Name => "Buy and hold";

    /// <inheritdoc />
    public string Description => "Baseline: buy at the second bar's open and hold to the final close, paying one round trip of costs.";

    /// <inheritdoc />
    public void Initialize(IIndicatorSource indicators)
    {
        ArgumentNullException.ThrowIfNull(indicators);

        _entered = false;
    }

    /// <inheritdoc />
    public Signal Evaluate(IBarWindow bars, Position? position)
    {
        ArgumentNullException.ThrowIfNull(bars);

        if (_entered)
        {
            return Signal.Hold;
        }

        _entered = true;
        return Signal.EnterLong;
    }
}
