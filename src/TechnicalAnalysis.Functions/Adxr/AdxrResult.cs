// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Average Directional Movement Index Rating (ADXR).
/// The ADXR is a smoothed version of the ADX indicator, providing a more stable measure
/// of trend strength by averaging the current ADX value with a previous ADX value.
/// </summary>
public record AdxrResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AdxrResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">An array containing the calculated ADXR values. Each value represents
    /// the smoothed average directional movement index rating, typically ranging from 0 to 100,
    /// where higher values indicate stronger trend strength.</param>
    public AdxrResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of calculated ADXR values.
    /// Each value represents the Average Directional Movement Index Rating,
    /// providing a smoothed measure of trend strength.
    /// </summary>
    public double[] Real { get; }
}
