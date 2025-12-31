// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the TRIX indicator.
/// </summary>
/// <remarks>
/// TRIX is a momentum oscillator that displays the rate of change of a triple exponentially smoothed moving average.
/// It filters out insignificant price movements and helps identify oversold and overbought markets.
/// The indicator oscillates around a zero line and is excellent for identifying divergences.
/// </remarks>
public record TrixResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TrixResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of TRIX values representing the rate of change of the triple EMA.</param>
    public TrixResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
