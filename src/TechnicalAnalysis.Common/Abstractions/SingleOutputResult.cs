// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

/// <summary>
/// Base class for indicator results that produce a single output array.
/// </summary>
/// <remarks>
/// This abstract class provides common functionality for technical indicators
/// that calculate a single output series. It encapsulates the result array
/// and inherits the metadata properties (RetCode, BegIdx, NbElement) from IndicatorResult.
/// </remarks>
public abstract record SingleOutputResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SingleOutputResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of calculated indicator values.</param>
    protected SingleOutputResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of calculated indicator values.
    /// </summary>
    /// <value>
    /// An array of double values representing the indicator's output series.
    /// </value>
    public double[] Real { get; }
}
