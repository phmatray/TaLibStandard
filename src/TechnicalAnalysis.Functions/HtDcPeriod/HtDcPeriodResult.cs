// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Hilbert Transform - Dominant Cycle Period (HT_DCPERIOD) calculation.
/// This indicator identifies the dominant cycle period of market data using Hilbert Transform techniques,
/// providing insight into the cyclical nature of price movements.
/// </summary>
public record HtDcPeriodResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HtDcPeriodResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of dominant cycle period values in bars, representing the length of the identified market cycles.</param>
    public HtDcPeriodResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }

    /// <summary>
    /// Gets the array of dominant cycle period values.
    /// Each value represents the period (in bars) of the dominant market cycle at that point in time.
    /// Values typically range from 10 to 50 bars, depending on market conditions.
    /// </summary>
}
