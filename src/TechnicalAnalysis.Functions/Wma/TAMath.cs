// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Weighted Moving Average (WMA) for the specified range of data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <param name="timePeriod">The number of periods to use in the WMA calculation. Default is 30.</param>
    /// <returns>A WmaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The Weighted Moving Average assigns linearly increasing weights to more recent data points.
    /// The most recent value has a weight of n, the second most recent n-1, and so on, where n is the time period.
    /// This makes the WMA more responsive to recent price changes than the Simple Moving Average.
    /// </remarks>
    public static WmaResult Wma(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Wma(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
        return new WmaResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Weighted Moving Average (WMA) using a default period of 30.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <returns>A WmaResult object containing the calculated values and metadata.</returns>
    public static WmaResult Wma(int startIdx, int endIdx, double[] real)
        => Wma(startIdx, endIdx, real, 30);

    /// <summary>
    /// Calculates the Weighted Moving Average (WMA) for float input data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <param name="timePeriod">The number of periods to use in the WMA calculation.</param>
    /// <returns>A WmaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static WmaResult Wma(int startIdx, int endIdx, float[] real, int timePeriod)
        => Wma(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Weighted Moving Average (WMA) for float input data using a default period of 30.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <returns>A WmaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static WmaResult Wma(int startIdx, int endIdx, float[] real)
        => Wma(startIdx, endIdx, real, 30);
}
