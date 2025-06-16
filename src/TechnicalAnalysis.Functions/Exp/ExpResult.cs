// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the vector exponential operation (EXP function).
/// </summary>
/// <remarks>
/// The EXP function calculates the exponential (e^x) of each element in the input array,
/// where e is Euler's number (approximately 2.71828). The result is an array where each
/// element represents e raised to the power of the corresponding input value.
/// </remarks>
public record ExpResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the exponential values.</param>
    public ExpResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of exponential values resulting from the EXP operation.
    /// </summary>
    /// <value>
    /// An array of doubles where each element represents e raised to the power
    /// of the corresponding element from the input array.
    /// </value>
    public double[] Real { get; }
}
