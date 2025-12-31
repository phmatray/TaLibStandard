// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Fast Stochastic (STOCHF) which provides a more responsive version of the stochastic oscillator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="fastKPeriod">The number of periods for Fast %K calculation (default: 5).</param>
    /// <param name="fastDPeriod">The smoothing period for Fast %K to get Fast %D (default: 3).</param>
    /// <param name="fastDMAType">The type of moving average for Fast %D calculation (default: Simple MA).</param>
    /// <returns>A StochFResult containing the Fast %K and Fast %D values.</returns>
    /// <remarks>
    /// The Fast Stochastic is more responsive to price changes than the slow stochastic.
    /// It uses unsmoothed %K line and a smoothed %D line:
    /// - Fast %K: Raw stochastic calculation
    /// - Fast %D: Moving average of Fast %K
    /// This indicator is useful for short-term trading but can be more prone to false signals.
    /// </remarks>
    public static StochFResult StochF(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double[] close,
        int fastKPeriod,
        int fastDPeriod,
        MAType fastDMAType)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outFastK = new double[endIdx - startIdx + 1];
        double[] outFastD = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.StochF(
            startIdx,
            endIdx,
            high,
            low,
            close,
            fastKPeriod,
            fastDPeriod,
            fastDMAType,
            ref outBegIdx,
            ref outNBElement,
            ref outFastK,
            ref outFastD);
            
        return new StochFResult(retCode, outBegIdx, outNBElement, outFastK, outFastD);
    }

    /// <summary>
    /// Calculates the Fast Stochastic using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A StochFResult containing the Fast %K and Fast %D values.</returns>
    /// <remarks>
    /// Uses default values: fastKPeriod=5, fastDPeriod=3, fastDMAType=Simple Moving Average.
    /// </remarks>
    public static StochFResult StochF(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => StochF(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma);

    /// <summary>
    /// Calculates the Fast Stochastic (STOCHF) which provides a more responsive version of the stochastic oscillator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="fastKPeriod">The number of periods for Fast %K calculation.</param>
    /// <param name="fastDPeriod">The smoothing period for Fast %K to get Fast %D.</param>
    /// <param name="fastDMAType">The type of moving average for Fast %D calculation.</param>
    /// <returns>A StochFResult containing the Fast %K and Fast %D values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// </remarks>
    public static StochFResult StochF(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        float[] close,
        int fastKPeriod,
        int fastDPeriod,
        MAType fastDMAType)
        => StochF(
            startIdx,
            endIdx,
            high.ToDouble(),
            low.ToDouble(),
            close.ToDouble(),
            fastKPeriod,
            fastDPeriod,
            fastDMAType);
        
    /// <summary>
    /// Calculates the Fast Stochastic using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A StochFResult containing the Fast %K and Fast %D values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// Uses default values: fastKPeriod=5, fastDPeriod=3, fastDMAType=Simple Moving Average.
    /// </remarks>
    public static StochFResult StochF(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => StochF(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma);
}
