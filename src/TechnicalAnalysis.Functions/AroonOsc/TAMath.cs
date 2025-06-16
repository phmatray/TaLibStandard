// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Aroon Oscillator (AROONOSC) which measures the strength of a trend and likelihood of continuation.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>An AroonOscResult containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The Aroon Oscillator is calculated as the difference between Aroon Up and Aroon Down.
    /// It oscillates between -100 and +100 with zero as the center line.
    /// Positive values indicate an upward trend, while negative values indicate a downward trend.
    /// </remarks>
    public static AroonOscResult AroonOsc(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.AroonOsc(
            startIdx,
            endIdx,
            high,
            low,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new AroonOscResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Aroon Oscillator (AROONOSC) using the default time period of 14.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <returns>An AroonOscResult containing the calculated values and metadata.</returns>
    public static AroonOscResult AroonOsc(int startIdx, int endIdx, double[] high, double[] low)
        => AroonOsc(startIdx, endIdx, high, low, 14);

    /// <summary>
    /// Calculates the Aroon Oscillator (AROONOSC) which measures the strength of a trend and likelihood of continuation.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>An AroonOscResult containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// </remarks>
    public static AroonOscResult AroonOsc(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
        => AroonOsc(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

    /// <summary>
    /// Calculates the Aroon Oscillator (AROONOSC) using the default time period of 14.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <returns>An AroonOscResult containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// </remarks>
    public static AroonOscResult AroonOsc(int startIdx, int endIdx, float[] high, float[] low)
        => AroonOsc(startIdx, endIdx, high, low, 14);
}
