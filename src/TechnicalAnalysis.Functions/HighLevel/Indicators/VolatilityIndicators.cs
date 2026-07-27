// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Fluent volatility indicators.
/// </summary>
/// <remarks>
/// The class name is TA-Lib's own function group and never appears at a call site: these are
/// extension methods on <see cref="PriceSeries"/>.
/// </remarks>
public static class VolatilityIndicators
{
    /// <summary>
    /// Computes the average true range.
    /// </summary>
    /// <param name="prices">
    /// The price series. It must carry high and low prices: a true range is a property of a bar's
    /// range, and the absolute change in close is not a substitute for it.
    /// </param>
    /// <param name="timePeriod">The smoothing period. Defaults to 14, as in the raw layer.</param>
    /// <returns>
    /// A bar-aligned series whose first bar is <paramref name="timePeriod"/>. If the series holds
    /// fewer bars than the period needs, the result is empty and reports success.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="timePeriod"/> is outside 2 to 100000. This is deliberately stricter than the
    /// raw entry point, which accepts 1, in exchange for one period rule that holds everywhere.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// The price series carries no high and low prices.
    /// </exception>
    public static IndicatorSeries Atr(this PriceSeries prices, int timePeriod = 14)
    {
        HighLevelGuard.Period(timePeriod, nameof(timePeriod));
        HighLevelGuard.RequireHighLow(prices, nameof(Atr));

        if (prices.IsEmpty)
        {
            return IndicatorSeries.Empty(0);
        }

        AtrResult result = TAMath.Atr(
            0,
            prices.BarCount - 1,
            prices.HighArray,
            prices.LowArray,
            prices.CloseArray,
            timePeriod);

        HighLevelGuard.Succeeded(result.RetCode, nameof(Atr));

        return prices.AlignOwning(result, static r => r.Real);
    }
}
