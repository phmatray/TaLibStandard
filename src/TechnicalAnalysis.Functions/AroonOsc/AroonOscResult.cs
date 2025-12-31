// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Aroon Oscillator calculation.
/// </summary>
/// <remarks>
/// The Aroon Oscillator is derived from the Aroon indicator and is calculated as the
/// difference between Aroon Up and Aroon Down (Aroon Up - Aroon Down). It oscillates
/// between -100 and +100, with zero as the centerline. Positive values indicate an
/// upward trend (Aroon Up is greater than Aroon Down), while negative values indicate
/// a downward trend. The farther the oscillator is from the zero line, the stronger
/// the trend. Crossovers through zero can signal trend changes, making this a valuable
/// tool for trend identification and timing entry/exit points.
/// </remarks>
public record AroonOscResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AroonOscResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated Aroon Oscillator values.</param>
    public AroonOscResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
