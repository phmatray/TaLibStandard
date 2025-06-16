// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Aroon indicator calculation.
/// </summary>
/// <remarks>
/// The Aroon indicator is a technical analysis tool used to identify trend changes and 
/// the strength of a trend. It consists of two lines: Aroon Up and Aroon Down, both 
/// ranging from 0 to 100. Aroon Up measures the time since the highest high within the 
/// lookback period, while Aroon Down measures the time since the lowest low. High values 
/// (70-100) indicate a strong trend, while low values (0-30) suggest a weak trend or 
/// consolidation. Crossovers between the lines can signal potential trend reversals.
/// </remarks>
public record AroonResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AroonResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="aroonDown">The array containing the calculated Aroon Down values.</param>
    /// <param name="aroonUp">The array containing the calculated Aroon Up values.</param>
    public AroonResult(RetCode retCode, int begIdx, int nbElement, double[] aroonDown, double[] aroonUp)
        : base(retCode, begIdx, nbElement)
    {
        AroonDown = aroonDown;
        AroonUp = aroonUp;
    }

    /// <summary>
    /// Gets the array of Aroon Down values.
    /// </summary>
    /// <value>
    /// An array of doubles representing the Aroon Down line, ranging from 0 to 100. 
    /// High values (70-100) indicate that a low was recently reached and a downtrend 
    /// may be in place. Low values (0-30) indicate that it has been a long time since 
    /// a low was reached.
    /// </value>
    public double[] AroonDown { get; }

    /// <summary>
    /// Gets the array of Aroon Up values.
    /// </summary>
    /// <value>
    /// An array of doubles representing the Aroon Up line, ranging from 0 to 100. 
    /// High values (70-100) indicate that a high was recently reached and an uptrend 
    /// may be in place. Low values (0-30) indicate that it has been a long time since 
    /// a high was reached.
    /// </value>
    public double[] AroonUp { get; }
}
