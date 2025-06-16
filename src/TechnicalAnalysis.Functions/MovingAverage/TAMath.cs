// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates a Moving Average of the specified type for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 30).</param>
    /// <param name="maType">The type of moving average to calculate (default: SMA).</param>
    /// <returns>A MovingAverageResult containing the calculated moving average values.</returns>
    /// <remarks>
    /// This function supports multiple moving average types including:
    /// - Simple Moving Average (SMA)
    /// - Exponential Moving Average (EMA)
    /// - Weighted Moving Average (WMA)
    /// - Double Exponential Moving Average (DEMA)
    /// - Triple Exponential Moving Average (TEMA)
    /// - Triangular Moving Average (TRIMA)
    /// - Kaufman Adaptive Moving Average (KAMA)
    /// - MESA Adaptive Moving Average (MAMA)
    /// - T3 Moving Average
    /// </remarks>
    public static MovingAverageResult MovingAverage(
        int startIdx,
        int endIdx,
        double[] real,
        int timePeriod,
        MAType maType)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MovingAverage(
            startIdx,
            endIdx,
            real,
            timePeriod,
            maType,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);

        return new MovingAverageResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates a Simple Moving Average using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>A MovingAverageResult containing the calculated moving average values.</returns>
    public static MovingAverageResult MovingAverage(int startIdx, int endIdx, double[] real)
        => MovingAverage(startIdx, endIdx, real, 30, MAType.Sma);

    /// <summary>
    /// Calculates a Moving Average of the specified type for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <param name="maType">The type of moving average to calculate.</param>
    /// <returns>A MovingAverageResult containing the calculated moving average values.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static MovingAverageResult MovingAverage(int startIdx, int endIdx, float[] real, int timePeriod, MAType maType)
        => MovingAverage(startIdx, endIdx, real.ToDouble(), timePeriod, maType);

    /// <summary>
    /// Calculates a Simple Moving Average using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>A MovingAverageResult containing the calculated moving average values.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static MovingAverageResult MovingAverage(int startIdx, int endIdx, float[] real)
        => MovingAverage(startIdx, endIdx, real, 30, MAType.Sma);
}
