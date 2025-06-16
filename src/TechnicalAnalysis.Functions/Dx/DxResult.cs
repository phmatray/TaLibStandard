// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Directional Movement Index (DX) indicator calculation.
/// DX measures the strength of a trend regardless of its direction, derived from comparing directional movements.
/// </summary>
public record DxResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DxResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated DX values.</param>
    public DxResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of Directional Movement Index values.
    /// Values range from 0 to 100, where higher values indicate stronger trends (either up or down).
    /// Values below 20 typically indicate weak trends, while values above 40 suggest strong trends.
    /// </summary>
    public double[] Real { get; }
}
