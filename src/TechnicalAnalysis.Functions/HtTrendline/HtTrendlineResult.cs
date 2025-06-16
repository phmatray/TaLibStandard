// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Hilbert Transform - Instantaneous Trendline (HT_TRENDLINE) calculation.
/// This indicator creates a smooth trendline by removing the dominant cycle component from price data,
/// effectively filtering out short-term fluctuations to reveal the underlying trend.
/// </summary>
public record HtTrendlineResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HtTrendlineResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of trendline values representing the smoothed price trend with cycles removed.</param>
    public HtTrendlineResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of instantaneous trendline values.
    /// These values represent a smoothed version of the price with dominant cycles filtered out,
    /// providing a clear view of the underlying trend direction and strength.
    /// </summary>
    public double[] Real { get; }
}
