// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Chaikin Accumulation/Distribution Oscillator (ADOSC).
    /// </summary>
    /// <remarks>
    /// The Chaikin Oscillator is created by subtracting a 10-period exponential moving average 
    /// of the Accumulation/Distribution line from a 3-period exponential moving average of the A/D line.
    /// This oscillator measures the momentum of the Accumulation/Distribution line by plotting the difference 
    /// between the fast and slow exponential moving averages. It is used to identify bullish and bearish 
    /// divergences that can signal potential trend reversals.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of trading volumes.</param>
    /// <param name="fastPeriod">The period for the fast exponential moving average (default: 3).</param>
    /// <param name="slowPeriod">The period for the slow exponential moving average (default: 10).</param>
    /// <returns>An AdOscResult object containing the calculated oscillator values.</returns>
    public static AdOscResult AdOsc(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double[] close,
        double[] volume,
        int fastPeriod,
        int slowPeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.AdOsc(
            startIdx,
            endIdx,
            high,
            low,
            close,
            volume,
            fastPeriod,
            slowPeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new AdOscResult(retCode, outBegIdx, outNBElement, outReal);
    }
        
    /// <summary>
    /// Calculates the Chaikin Accumulation/Distribution Oscillator (ADOSC) with default periods.
    /// </summary>
    /// <remarks>
    /// This overload uses default values of 3 for the fast period and 10 for the slow period.
    /// See the main overload for a detailed description of the ADOSC indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of trading volumes.</param>
    /// <returns>An AdOscResult object containing the calculated oscillator values.</returns>
    public static AdOscResult AdOsc(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double[] close,
        double[] volume)
        => AdOsc(startIdx, endIdx, high, low, close, volume, 3, 10);

    /// <summary>
    /// Calculates the Chaikin Accumulation/Distribution Oscillator (ADOSC) using float arrays.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// See the double array overload for a detailed description of the ADOSC indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of trading volumes.</param>
    /// <param name="fastPeriod">The period for the fast exponential moving average.</param>
    /// <param name="slowPeriod">The period for the slow exponential moving average.</param>
    /// <returns>An AdOscResult object containing the calculated oscillator values.</returns>
    public static AdOscResult AdOsc(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        float[] close,
        float[] volume,
        int fastPeriod,
        int slowPeriod)
        => AdOsc(
            startIdx,
            endIdx,
            high.ToDouble(),
            low.ToDouble(),
            close.ToDouble(),
            volume.ToDouble(),
            fastPeriod,
            slowPeriod);
        
    /// <summary>
    /// Calculates the Chaikin Accumulation/Distribution Oscillator (ADOSC) using float arrays with default periods.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// Uses default values of 3 for the fast period and 10 for the slow period.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of trading volumes.</param>
    /// <returns>An AdOscResult object containing the calculated oscillator values.</returns>
    public static AdOscResult AdOsc(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume)
        => AdOsc(startIdx, endIdx, high, low, close, volume, 3, 10);
}
