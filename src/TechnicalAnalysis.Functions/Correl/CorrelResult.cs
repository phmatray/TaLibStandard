// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Pearson Correlation Coefficient calculation.
/// </summary>
/// <remarks>
/// The Correlation Coefficient measures the linear relationship between two data series, 
/// typically two securities or a security and a benchmark. Values range from -1 to +1, 
/// where +1 indicates perfect positive correlation (both move in the same direction), 
/// -1 indicates perfect negative correlation (move in opposite directions), and 0 indicates 
/// no linear relationship. This statistical measure is crucial for portfolio diversification, 
/// pairs trading strategies, and understanding market relationships.
/// </remarks>
public record CorrelResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CorrelResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated correlation coefficient values.</param>
    public CorrelResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }

    /// <summary>
    /// Gets the array of correlation coefficient values.
    /// </summary>
    /// <value>
    /// An array of doubles representing the correlation values, ranging from -1 to +1. 
    /// Values near +1 indicate strong positive correlation, values near -1 indicate 
    /// strong negative correlation, and values near 0 indicate weak or no linear relationship. 
    /// These values are essential for risk management and portfolio optimization.
    /// </value>
}
