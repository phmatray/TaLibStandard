// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the 1-day Rate-Of-Change (TRIX) indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods for the exponential moving average (default: 30).</param>
    /// <returns>A TrixResult object containing the calculated values.</returns>
    /// <remarks>
    /// TRIX is a momentum oscillator that displays the percent rate of change of a triple exponentially smoothed moving average.
    /// It filters out insignificant price movements and is designed to keep you in trends equal to or shorter than the number of periods specified.
    /// TRIX oscillates around a zero line and can be used to identify oversold and overbought markets, and as a momentum indicator.
    /// Positive values indicate an uptrend, while negative values indicate a downtrend.
    /// </remarks>
    public static TrixResult Trix(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Trix(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new TrixResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the 1-day Rate-Of-Change (TRIX) indicator using the default time period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <returns>A TrixResult object containing the calculated values.</returns>
    /// <remarks>Uses the default time period of 30.</remarks>
    public static TrixResult Trix(int startIdx, int endIdx, double[] real)
        => Trix(startIdx, endIdx, real, 30);

    /// <summary>
    /// Calculates the 1-day Rate-Of-Change (TRIX) indicator using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods for the exponential moving average.</param>
    /// <returns>A TrixResult object containing the calculated values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before processing.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static TrixResult Trix(int startIdx, int endIdx, float[] real, int timePeriod)
        => Trix(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the 1-day Rate-Of-Change (TRIX) indicator using float arrays and the default time period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <returns>A TrixResult object containing the calculated values.</returns>
    /// <remarks>
    /// Uses the default time period of 30. This overload accepts float arrays and converts them to double arrays.
    /// </remarks>
    public static TrixResult Trix(int startIdx, int endIdx, float[] real)
        => Trix(startIdx, endIdx, real, 30);
}
