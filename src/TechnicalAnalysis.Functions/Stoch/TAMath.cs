// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Stochastic Oscillator (STOCH) which measures momentum by comparing closing price to price range.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="fastKPeriod">The number of periods for %K calculation (default: 5).</param>
    /// <param name="slowKPeriod">The smoothing period for %K to get Slow %K (default: 3).</param>
    /// <param name="slowKMAType">The type of moving average for Slow %K smoothing (default: Simple MA).</param>
    /// <param name="slowDPeriod">The smoothing period for Slow %K to get Slow %D (default: 3).</param>
    /// <param name="slowDMAType">The type of moving average for Slow %D smoothing (default: Simple MA).</param>
    /// <returns>A StochResult containing the Slow %K and Slow %D values.</returns>
    /// <remarks>
    /// The Stochastic Oscillator is a momentum indicator comparing the closing price to the range of prices
    /// over a certain period. It consists of two lines:
    /// - %K: The main line showing the current close relative to the high-low range
    /// - %D: A moving average of %K, acting as a signal line
    /// Values range from 0 to 100, with readings above 80 indicating overbought and below 20 indicating oversold.
    /// </remarks>
    public static StochResult Stoch(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double[] close,
        int fastKPeriod,
        int slowKPeriod,
        MAType slowKMAType,
        int slowDPeriod,
        MAType slowDMAType)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outSlowK = new double[endIdx - startIdx + 1];
        double[] outSlowD = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Stoch(
            startIdx,
            endIdx,
            high,
            low,
            close,
            fastKPeriod,
            slowKPeriod,
            slowKMAType,
            slowDPeriod,
            slowDMAType,
            ref outBegIdx,
            ref outNBElement,
            ref outSlowK,
            ref outSlowD);
            
        return new StochResult(retCode, outBegIdx, outNBElement, outSlowK, outSlowD);
    }

    /// <summary>
    /// Calculates the Stochastic Oscillator using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A StochResult containing the Slow %K and Slow %D values.</returns>
    /// <remarks>
    /// Uses default values: fastKPeriod=5, slowKPeriod=3, slowDPeriod=3, both using Simple Moving Average.
    /// </remarks>
    public static StochResult Stoch(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => Stoch(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma, 3, MAType.Sma);

    /// <summary>
    /// Calculates the Stochastic Oscillator (STOCH) which measures momentum by comparing closing price to price range.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="fastKPeriod">The number of periods for %K calculation.</param>
    /// <param name="slowKPeriod">The smoothing period for %K to get Slow %K.</param>
    /// <param name="slowKMAType">The type of moving average for Slow %K smoothing.</param>
    /// <param name="slowDPeriod">The smoothing period for Slow %K to get Slow %D.</param>
    /// <param name="slowDMAType">The type of moving average for Slow %D smoothing.</param>
    /// <returns>A StochResult containing the Slow %K and Slow %D values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// </remarks>
    public static StochResult Stoch(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        float[] close,
        int fastKPeriod,
        int slowKPeriod,
        MAType slowKMAType,
        int slowDPeriod,
        MAType slowDMAType)
        => Stoch(
            startIdx,
            endIdx,
            high.ToDouble(),
            low.ToDouble(),
            close.ToDouble(),
            fastKPeriod,
            slowKPeriod,
            slowKMAType,
            slowDPeriod,
            slowDMAType);
        
    /// <summary>
    /// Calculates the Stochastic Oscillator using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A StochResult containing the Slow %K and Slow %D values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// Uses default values: fastKPeriod=5, slowKPeriod=3, slowDPeriod=3, both using Simple Moving Average.
    /// </remarks>
    public static StochResult Stoch(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => Stoch(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma, 3, MAType.Sma);
}
