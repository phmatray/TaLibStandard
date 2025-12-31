// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Parabolic SAR (Stop And Reverse) indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="acceleration">The acceleration factor (default: 0.02).</param>
    /// <param name="maximum">The maximum acceleration factor (default: 0.2).</param>
    /// <returns>A SarResult object containing the calculated values.</returns>
    /// <remarks>
    /// The Parabolic SAR is a trend-following indicator that provides entry and exit points.
    /// It appears as a series of dots placed either above or below the price bars.
    /// A dot below the price indicates a bullish signal, while a dot above indicates a bearish signal.
    /// The acceleration factor determines how quickly the SAR converges towards the price.
    /// The indicator is particularly effective in trending markets but can produce whipsaws in ranging markets.
    /// </remarks>
    public static SarResult Sar(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double acceleration,
        double maximum)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Sar(
            startIdx,
            endIdx,
            high,
            low,
            acceleration,
            maximum,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new SarResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Parabolic SAR (Stop And Reverse) indicator using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <returns>A SarResult object containing the calculated values.</returns>
    /// <remarks>Uses the default acceleration factor of 0.02 and maximum acceleration of 0.2.</remarks>
    public static SarResult Sar(int startIdx, int endIdx, double[] high, double[] low)
        => Sar(startIdx, endIdx, high, low, 0.02, 0.2);

    /// <summary>
    /// Calculates the Parabolic SAR (Stop And Reverse) indicator using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="acceleration">The acceleration factor.</param>
    /// <param name="maximum">The maximum acceleration factor.</param>
    /// <returns>A SarResult object containing the calculated values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before processing.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static SarResult Sar(int startIdx, int endIdx, float[] high, float[] low, double acceleration, double maximum)
        => Sar(startIdx, endIdx, high.ToDouble(), low.ToDouble(), acceleration, maximum);
        
    /// <summary>
    /// Calculates the Parabolic SAR (Stop And Reverse) indicator using float arrays and default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <returns>A SarResult object containing the calculated values.</returns>
    /// <remarks>
    /// Uses the default acceleration factor of 0.02 and maximum acceleration of 0.2.
    /// This overload accepts float arrays and converts them to double arrays.
    /// </remarks>
    public static SarResult Sar(int startIdx, int endIdx, float[] high, float[] low)
        => Sar(startIdx, endIdx, high, low, 0.02, 0.2);
}
