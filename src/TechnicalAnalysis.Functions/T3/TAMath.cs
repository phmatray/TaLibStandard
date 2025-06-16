// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the T3 Triple Exponential Moving Average for the specified range of data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <param name="timePeriod">The number of periods to use in the T3 calculation. Default is 5.</param>
    /// <param name="vFactor">The volume factor (0-1) that controls the smoothing. Default is 0.7.</param>
    /// <returns>A T3Result object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The T3 Triple Exponential Moving Average is a type of moving average developed by Tim Tillson.
    /// It incorporates multiple exponential moving averages and includes a volume factor to provide
    /// better smoothing with reduced lag. The vFactor parameter controls the amount of smoothing,
    /// where higher values (closer to 1) provide more smoothing but may introduce more lag.
    /// </remarks>
    public static T3Result T3(int startIdx, int endIdx, double[] real, int timePeriod, double vFactor)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.T3(
            startIdx,
            endIdx,
            real,
            timePeriod,
            vFactor,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new T3Result(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the T3 Triple Exponential Moving Average using default parameters (period=5, vFactor=0.7).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <returns>A T3Result object containing the calculated values and metadata.</returns>
    public static T3Result T3(int startIdx, int endIdx, double[] real)
        => T3(startIdx, endIdx, real, 5, 0.7);

    /// <summary>
    /// Calculates the T3 Triple Exponential Moving Average for float input data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <param name="timePeriod">The number of periods to use in the T3 calculation.</param>
    /// <param name="vFactor">The volume factor (0-1) that controls the smoothing.</param>
    /// <returns>A T3Result object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static T3Result T3(int startIdx, int endIdx, float[] real, int timePeriod, double vFactor)
        => T3(startIdx, endIdx, real.ToDouble(), timePeriod, vFactor);
        
    /// <summary>
    /// Calculates the T3 Triple Exponential Moving Average for float input data using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <returns>A T3Result object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// Uses default parameters: period=5, vFactor=0.7.
    /// </remarks>
    public static T3Result T3(int startIdx, int endIdx, float[] real)
        => T3(startIdx, endIdx, real, 5, 0.7);
}
