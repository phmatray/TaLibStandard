// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Fluent volume indicators.
/// </summary>
/// <remarks>
/// The class name is TA-Lib's own function group and never appears at a call site: these are
/// extension methods on <see cref="PriceSeries"/>.
/// </remarks>
public static class VolumeIndicators
{
    /// <summary>
    /// Computes on-balance volume: the running total of volume, signed by the direction of the
    /// close.
    /// </summary>
    /// <param name="prices">
    /// The price series. It must carry volumes, which only <see cref="PriceSeries.FromOhlcv"/>
    /// supplies; substituting a constant volume would turn this into a signed bar counter.
    /// </param>
    /// <returns>
    /// A bar-aligned series that is warm from bar <c>0</c>, because the running total needs no
    /// lookback. The absolute level carries no meaning — it depends on where the series happens to
    /// start — so only its direction and its divergence from price are read.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// The price series carries no volumes.
    /// </exception>
    public static IndicatorSeries Obv(this PriceSeries prices)
    {
        HighLevelGuard.RequireVolume(prices, nameof(Obv));

        if (prices.IsEmpty)
        {
            return IndicatorSeries.Empty(0);
        }

        ObvResult result = TAMath.Obv(0, prices.BarCount - 1, prices.CloseArray, prices.VolumeArray);
        HighLevelGuard.Succeeded(result.RetCode, nameof(Obv));

        return prices.AlignOwning(result, static r => r.Real);
    }
}
