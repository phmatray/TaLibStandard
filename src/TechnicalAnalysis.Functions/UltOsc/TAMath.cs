// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Ultimate Oscillator (ULTOSC) indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of closing prices.</param>
    /// <param name="timePeriod1">The first time period (short-term, default: 7).</param>
    /// <param name="timePeriod2">The second time period (intermediate-term, default: 14).</param>
    /// <param name="timePeriod3">The third time period (long-term, default: 28).</param>
    /// <returns>A UltOscResult object containing the calculated values.</returns>
    /// <remarks>
    /// The Ultimate Oscillator is a momentum oscillator designed to capture momentum across three different timeframes.
    /// It uses weighted sums of three oscillators, each of which uses a different time period.
    /// The indicator ranges between 0 and 100, with overbought levels typically above 70 and oversold levels below 30.
    /// This multi-timeframe approach reduces false signals and provides more reliable divergence signals.
    /// </remarks>
    public static UltOscResult UltOsc(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double[] close,
        int timePeriod1,
        int timePeriod2,
        int timePeriod3)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.UltOsc(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod1,
            timePeriod2,
            timePeriod3,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new UltOscResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Ultimate Oscillator (ULTOSC) indicator using default time periods.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of closing prices.</param>
    /// <returns>A UltOscResult object containing the calculated values.</returns>
    /// <remarks>Uses the default time periods of 7, 14, and 28.</remarks>
    public static UltOscResult UltOsc(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => UltOsc(startIdx, endIdx, high, low, close, 7, 14, 28);

    /// <summary>
    /// Calculates the Ultimate Oscillator (ULTOSC) indicator using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of closing prices.</param>
    /// <param name="timePeriod1">The first time period (short-term).</param>
    /// <param name="timePeriod2">The second time period (intermediate-term).</param>
    /// <param name="timePeriod3">The third time period (long-term).</param>
    /// <returns>A UltOscResult object containing the calculated values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before processing.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static UltOscResult UltOsc(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        float[] close,
        int timePeriod1,
        int timePeriod2,
        int timePeriod3)
        => UltOsc(
            startIdx,
            endIdx,
            high.ToDouble(),
            low.ToDouble(),
            close.ToDouble(),
            timePeriod1,
            timePeriod2,
            timePeriod3);
        
    /// <summary>
    /// Calculates the Ultimate Oscillator (ULTOSC) indicator using float arrays and default time periods.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of closing prices.</param>
    /// <returns>A UltOscResult object containing the calculated values.</returns>
    /// <remarks>
    /// Uses the default time periods of 7, 14, and 28. This overload accepts float arrays and converts them to double arrays.
    /// </remarks>
    public static UltOscResult UltOsc(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => UltOsc(startIdx, endIdx, high, low, close, 7, 14, 28);
}
