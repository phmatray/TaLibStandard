// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Fluent momentum indicators.
/// </summary>
/// <remarks>
/// <para>
/// The class name is TA-Lib's own function group and never appears at a call site: these are
/// extension methods on <see cref="PriceSeries"/>.
/// </para>
/// <para>
/// No indicator here returns a thresholded verdict such as "overbought". A wrong number looks
/// wrong; a wrong <see cref="bool"/> looks authoritative and has already destroyed the evidence
/// that would have shown it was wrong. The conventional levels are also conventions — 70 and 30
/// come from a 1978 book about daily bars — so they belong in your source file, under your review,
/// not in the library.
/// </para>
/// </remarks>
public static class MomentumIndicators
{
    /// <summary>
    /// Computes the relative strength index of the closing prices.
    /// </summary>
    /// <param name="prices">The price series.</param>
    /// <param name="timePeriod">The lookback period. Defaults to 14, as in the raw layer.</param>
    /// <returns>
    /// A bar-aligned series of values from 0 to 100. A strictly rising series is pinned at 100 and a
    /// flat series reads 0, matching the reference C implementation. If the series holds fewer bars
    /// than the period needs, the result is empty and reports success — and an empty result answers
    /// <c>null</c> rather than <c>0</c>, so it can never be mistaken for an oversold reading.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="timePeriod"/> is outside 2 to 100000.
    /// </exception>
    public static IndicatorSeries Rsi(this PriceSeries prices, int timePeriod = 14)
    {
        HighLevelGuard.Period(timePeriod, nameof(timePeriod));

        if (prices.IsEmpty)
        {
            return IndicatorSeries.Empty(0);
        }

        RsiResult result = TAMath.Rsi(0, prices.BarCount - 1, prices.CloseArray, timePeriod);
        HighLevelGuard.Succeeded(result.RetCode, nameof(Rsi));

        return prices.AlignOwning(result, static r => r.Real);
    }

    /// <summary>
    /// Computes the average directional index — the strength of a trend, without its direction.
    /// </summary>
    /// <param name="prices">
    /// The price series. It must carry high and low prices, because the directional movement of a
    /// bar is defined by how its range extends beyond the previous bar's.
    /// </param>
    /// <param name="timePeriod">The Wilder smoothing period. Defaults to 14, as in the raw layer.</param>
    /// <returns>
    /// A bar-aligned series of values from 0 to 100. The first bar is
    /// <c>(2 * timePeriod) + unstablePeriod - 1</c>, which is 27 for the default period — the
    /// longest warm-up of any indicator on this surface, because the index is a smoothed average of
    /// a smoothed average. A value says only how strongly price is trending; whether it is trending
    /// up or down is what <c>TAMath.PlusDI</c> and <c>TAMath.MinusDI</c> answer.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="timePeriod"/> is outside 2 to 100000.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// The price series carries no high and low prices.
    /// </exception>
    public static IndicatorSeries Adx(this PriceSeries prices, int timePeriod = 14)
    {
        HighLevelGuard.Period(timePeriod, nameof(timePeriod));
        HighLevelGuard.RequireHighLow(prices, nameof(Adx));

        if (prices.IsEmpty)
        {
            return IndicatorSeries.Empty(0);
        }

        AdxResult result = TAMath.Adx(
            0,
            prices.BarCount - 1,
            prices.HighArray,
            prices.LowArray,
            prices.CloseArray,
            timePeriod);

        HighLevelGuard.Succeeded(result.RetCode, nameof(Adx));

        return prices.AlignOwning(result, static r => r.Real);
    }

    /// <summary>
    /// Computes the moving average convergence divergence of the closing prices.
    /// </summary>
    /// <param name="prices">The price series.</param>
    /// <param name="fastPeriod">The fast exponential moving average period. Defaults to 12, as in the raw layer.</param>
    /// <param name="slowPeriod">The slow exponential moving average period. Defaults to 26, as in the raw layer.</param>
    /// <param name="signalPeriod">
    /// The period of the signal line, an exponential moving average of the MACD line. Defaults to 9,
    /// as in the raw layer.
    /// </param>
    /// <returns>
    /// The line, signal and histogram, each independently bar-aligned and sharing the same first
    /// bar. A signal crossing is <c>macd.Line.CrossedAbove(macd.Signal, bar)</c>.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="fastPeriod"/>, <paramref name="slowPeriod"/> or
    /// <paramref name="signalPeriod"/> is outside 2 to 100000. The signal period matters most: the
    /// raw layer does not reject a signal period of 1, it fails inside an internal array copy.
    /// </exception>
    public static MacdSeries Macd(
        this PriceSeries prices,
        int fastPeriod = 12,
        int slowPeriod = 26,
        int signalPeriod = 9)
    {
        HighLevelGuard.Period(fastPeriod, nameof(fastPeriod));
        HighLevelGuard.Period(slowPeriod, nameof(slowPeriod));
        HighLevelGuard.Period(signalPeriod, nameof(signalPeriod));

        if (prices.IsEmpty)
        {
            IndicatorSeries empty = IndicatorSeries.Empty(0);
            return new MacdSeries(empty, empty, empty);
        }

        MacdResult result = TAMath.Macd(
            0,
            prices.BarCount - 1,
            prices.CloseArray,
            fastPeriod,
            slowPeriod,
            signalPeriod);

        HighLevelGuard.Succeeded(result.RetCode, nameof(Macd));

        return new MacdSeries(
            prices.AlignOwning(result, static r => r.MacdValue),
            prices.AlignOwning(result, static r => r.MacdSignal),
            prices.AlignOwning(result, static r => r.MacdHist));
    }

    /// <summary>
    /// Computes the slow stochastic oscillator.
    /// </summary>
    /// <param name="prices">
    /// The price series. It must carry high and low prices, because the oscillator measures where
    /// the close sits inside the recent range.
    /// </param>
    /// <param name="fastKPeriod">The lookback of the raw %K. Defaults to 5, as in the raw layer.</param>
    /// <param name="slowKPeriod">The smoothing period applied to %K. Defaults to 3, as in the raw layer.</param>
    /// <param name="slowKMAType">The moving average used to smooth %K. Defaults to simple.</param>
    /// <param name="slowDPeriod">The period of %D. Defaults to 3, as in the raw layer.</param>
    /// <param name="slowDMAType">The moving average used for %D. Defaults to simple.</param>
    /// <returns>The %K and %D lines, each independently bar-aligned.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="fastKPeriod"/>, <paramref name="slowKPeriod"/> or
    /// <paramref name="slowDPeriod"/> is outside 2 to 100000.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// The price series carries no high and low prices.
    /// </exception>
    public static StochSeries Stoch(
        this PriceSeries prices,
        int fastKPeriod = 5,
        int slowKPeriod = 3,
        MAType slowKMAType = MAType.Sma,
        int slowDPeriod = 3,
        MAType slowDMAType = MAType.Sma)
    {
        HighLevelGuard.Period(fastKPeriod, nameof(fastKPeriod));
        HighLevelGuard.Period(slowKPeriod, nameof(slowKPeriod));
        HighLevelGuard.Period(slowDPeriod, nameof(slowDPeriod));
        HighLevelGuard.RequireHighLow(prices, nameof(Stoch));

        if (prices.IsEmpty)
        {
            IndicatorSeries empty = IndicatorSeries.Empty(0);
            return new StochSeries(empty, empty);
        }

        StochResult result = TAMath.Stoch(
            0,
            prices.BarCount - 1,
            prices.HighArray,
            prices.LowArray,
            prices.CloseArray,
            fastKPeriod,
            slowKPeriod,
            slowKMAType,
            slowDPeriod,
            slowDMAType);

        HighLevelGuard.Succeeded(result.RetCode, nameof(Stoch));

        return new StochSeries(
            prices.AlignOwning(result, static r => r.SlowK),
            prices.AlignOwning(result, static r => r.SlowD));
    }
}
