// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common.Abstractions;

/// <summary>
/// Base class for indicator results that produce three output arrays.
/// </summary>
/// <remarks>
/// This abstract class provides common functionality for technical indicators
/// that calculate three output series. It encapsulates all three result arrays
/// and inherits the metadata properties (RetCode, BegIdx, NbElement) from IndicatorResult.
/// </remarks>
public abstract record TripleOutputResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TripleOutputResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="real0">The first array of calculated indicator values.</param>
    /// <param name="real1">The second array of calculated indicator values.</param>
    /// <param name="real2">The third array of calculated indicator values.</param>
    protected TripleOutputResult(
        RetCode retCode,
        int begIdx,
        int nbElement,
        double[] real0,
        double[] real1,
        double[] real2)
        : base(retCode, begIdx, nbElement)
    {
        Real0 = real0;
        Real1 = real1;
        Real2 = real2;
    }

    /// <summary>
    /// Gets the first array of calculated indicator values.
    /// </summary>
    /// <value>
    /// An array of double values representing the first output series.
    /// </value>
    protected double[] Real0 { get; }

    /// <summary>
    /// Gets the second array of calculated indicator values.
    /// </summary>
    /// <value>
    /// An array of double values representing the second output series.
    /// </value>
    protected double[] Real1 { get; }

    /// <summary>
    /// Gets the third array of calculated indicator values.
    /// </summary>
    /// <value>
    /// An array of double values representing the third output series.
    /// </value>
    protected double[] Real2 { get; }
}
