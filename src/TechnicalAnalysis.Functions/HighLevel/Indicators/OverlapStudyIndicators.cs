// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Fluent overlap study indicators — those plotted on the price scale.
/// </summary>
/// <remarks>
/// <para>
/// The class name is TA-Lib's own function group and never appears at a call site: these are
/// extension methods on <see cref="PriceSeries"/>, so they appear directly on <c>prices.</c> in
/// IntelliSense.
/// </para>
/// <para>
/// Every default here is copied verbatim from the corresponding raw entry point. The fluent layer
/// never invents a number, so that a fluent call and a raw call with the same arguments cannot
/// disagree.
/// </para>
/// </remarks>
public static class OverlapStudyIndicators
{
    /// <summary>
    /// Computes the simple moving average of the closing prices.
    /// </summary>
    /// <param name="prices">The price series.</param>
    /// <param name="timePeriod">The number of bars to average. Defaults to 30, as in the raw layer.</param>
    /// <returns>
    /// A bar-aligned series whose first bar is <c>timePeriod - 1</c>. If the series holds fewer bars
    /// than the period needs, the result is empty and reports success — that is not an error.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="timePeriod"/> is outside 2 to 100000.
    /// </exception>
    public static IndicatorSeries Sma(this PriceSeries prices, int timePeriod = 30)
    {
        HighLevelGuard.Period(timePeriod, nameof(timePeriod));

        if (prices.IsEmpty)
        {
            return IndicatorSeries.Empty(0);
        }

        SmaResult result = TAMath.Sma(0, prices.BarCount - 1, prices.CloseArray, timePeriod);
        HighLevelGuard.Succeeded(result.RetCode, nameof(Sma));

        return prices.AlignOwning(result, static r => r.Real);
    }

    /// <summary>
    /// Computes the exponential moving average of the closing prices.
    /// </summary>
    /// <param name="prices">The price series.</param>
    /// <param name="timePeriod">The smoothing period. Defaults to 30, as in the raw layer.</param>
    /// <returns>
    /// A bar-aligned series. If the series holds fewer bars than the period needs, the result is
    /// empty and reports success.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="timePeriod"/> is outside 2 to 100000.
    /// </exception>
    public static IndicatorSeries Ema(this PriceSeries prices, int timePeriod = 30)
    {
        HighLevelGuard.Period(timePeriod, nameof(timePeriod));

        if (prices.IsEmpty)
        {
            return IndicatorSeries.Empty(0);
        }

        EmaResult result = TAMath.Ema(0, prices.BarCount - 1, prices.CloseArray, timePeriod);
        HighLevelGuard.Succeeded(result.RetCode, nameof(Ema));

        return prices.AlignOwning(result, static r => r.Real);
    }

    /// <summary>
    /// Computes Bollinger Bands over the closing prices.
    /// </summary>
    /// <param name="prices">The price series.</param>
    /// <param name="timePeriod">
    /// The period of the middle band and of the standard deviation. <b>Defaults to 5, which is
    /// TA-Lib's own default</b>, even though 20 is the conventional trading choice; pass 20
    /// explicitly if that is what you want. The fluent layer never silently redefines a default.
    /// </param>
    /// <param name="nbDevUp">
    /// The number of standard deviations for the upper band. Defaults to 2. Not validated: any
    /// finite deviation is meaningful.
    /// </param>
    /// <param name="nbDevDn">
    /// The number of standard deviations for the lower band. Defaults to 2. Not validated.
    /// </param>
    /// <param name="maType">The type of moving average used for the middle band. Defaults to simple.</param>
    /// <returns>
    /// The three bands, each independently bar-aligned and sharing the same first bar.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="timePeriod"/> is outside 2 to 100000.
    /// </exception>
    public static BollingerBandsSeries BollingerBands(
        this PriceSeries prices,
        int timePeriod = 5,
        double nbDevUp = 2.0,
        double nbDevDn = 2.0,
        MAType maType = MAType.Sma)
    {
        HighLevelGuard.Period(timePeriod, nameof(timePeriod));

        if (prices.IsEmpty)
        {
            IndicatorSeries empty = IndicatorSeries.Empty(0);
            return new BollingerBandsSeries(empty, empty, empty);
        }

        BollingerBandsResult result = TAMath.BollingerBands(
            0,
            prices.BarCount - 1,
            prices.CloseArray,
            timePeriod,
            nbDevUp,
            nbDevDn,
            maType);

        HighLevelGuard.Succeeded(result.RetCode, nameof(BollingerBands));

        return new BollingerBandsSeries(
            prices.AlignOwning(result, static r => r.RealUpperBand),
            prices.AlignOwning(result, static r => r.RealMiddleBand),
            prices.AlignOwning(result, static r => r.RealLowerBand));
    }
}
