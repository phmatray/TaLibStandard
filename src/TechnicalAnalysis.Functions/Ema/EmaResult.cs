// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Exponential Moving Average (EMA) indicator.
/// </summary>
/// <remarks>
/// The EMA is a type of moving average that gives more weight to recent prices,
/// making it more responsive to new information compared to the Simple Moving Average (SMA).
/// It is commonly used to identify trends and generate trading signals.
/// </remarks>
public record EmaResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmaResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of exponential moving average values.</param>
    public EmaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of exponential moving average values.
    /// </summary>
    /// <value>
    /// An array of double values representing the Exponential Moving Average at each data point.
    /// Each value is calculated using an exponential weighting factor that gives more importance
    /// to recent price data.
    /// </value>
    public double[] Real { get; }
}
