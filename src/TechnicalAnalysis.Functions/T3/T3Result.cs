// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the T3 Moving Average indicator.
/// </summary>
/// <remarks>
/// T3 is a smoothed moving average developed by Tim Tillson. It incorporates multiple
/// exponential smoothing techniques to produce a moving average that is both smooth
/// and responsive, with minimal lag compared to traditional moving averages.
/// </remarks>
public record T3Result : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="T3Result"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of T3 moving average values.</param>
    public T3Result(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
