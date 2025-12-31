// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates a moving average with variable period lengths (MAVP).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="periods">Array specifying the period to use for each corresponding value in the real array.</param>
    /// <param name="minPeriod">The minimum allowed period value.</param>
    /// <param name="maxPeriod">The maximum allowed period value.</param>
    /// <param name="maType">The type of moving average to calculate.</param>
    /// <returns>A MovingAverageVariablePeriodResult containing the calculated values.</returns>
    /// <remarks>
    /// The MAVP indicator allows for dynamic period lengths at each data point, enabling adaptive smoothing
    /// based on market conditions or other criteria. The period array determines the lookback period for
    /// each corresponding element in the real array.
    /// </remarks>
    public static MovingAverageVariablePeriodResult MovingAverageVariablePeriod(
        int startIdx,
        int endIdx,
        double[] real,
        double[] periods,
        int minPeriod,
        int maxPeriod,
        MAType maType)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MovingAverageVariablePeriod(
            startIdx,
            endIdx,
            real,
            periods,
            minPeriod,
            maxPeriod,
            maType,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new MovingAverageVariablePeriodResult(retCode, outBegIdx, outNBElement, outReal);
    }
        
    /// <summary>
    /// Calculates a moving average with variable period lengths (MAVP) using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="periods">Array specifying the period to use for each corresponding value in the real array.</param>
    /// <returns>A MovingAverageVariablePeriodResult containing the calculated values.</returns>
    /// <remarks>
    /// This overload uses default values: minPeriod=2, maxPeriod=30, and MAType=SMA.
    /// </remarks>
    public static MovingAverageVariablePeriodResult MovingAverageVariablePeriod(
        int startIdx,
        int endIdx,
        double[] real,
        double[] periods)
        => MovingAverageVariablePeriod(startIdx, endIdx, real, periods, 2, 30, MAType.Sma);

    /// <summary>
    /// Calculates a moving average with variable period lengths (MAVP) using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="periods">Array specifying the period to use for each corresponding value in the real array.</param>
    /// <param name="minPeriod">The minimum allowed period value.</param>
    /// <param name="maxPeriod">The maximum allowed period value.</param>
    /// <param name="maType">The type of moving average to calculate.</param>
    /// <returns>A MovingAverageVariablePeriodResult containing the calculated values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before processing.
    /// The conversion may result in minor precision differences.
    /// </remarks>
    public static MovingAverageVariablePeriodResult MovingAverageVariablePeriod(
        int startIdx,
        int endIdx,
        float[] real,
        float[] periods,
        int minPeriod,
        int maxPeriod,
        MAType maType)
        => MovingAverageVariablePeriod(
            startIdx,
            endIdx,
            real.ToDouble(),
            periods.ToDouble(),
            minPeriod,
            maxPeriod,
            maType);
        
    /// <summary>
    /// Calculates a moving average with variable period lengths (MAVP) using float arrays and default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Input array of real values.</param>
    /// <param name="periods">Array specifying the period to use for each corresponding value in the real array.</param>
    /// <returns>A MovingAverageVariablePeriodResult containing the calculated values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before processing.
    /// Uses default values: minPeriod=2, maxPeriod=30, and MAType=SMA.
    /// </remarks>
    public static MovingAverageVariablePeriodResult MovingAverageVariablePeriod(
        int startIdx,
        int endIdx,
        float[] real,
        float[] periods)
        => MovingAverageVariablePeriod(startIdx, endIdx, real, periods, 2, 30, MAType.Sma);
}
