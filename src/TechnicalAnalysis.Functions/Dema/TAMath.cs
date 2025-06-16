// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Double Exponential Moving Average (DEMA) for the specified range of data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <param name="timePeriod">The number of periods to use in the DEMA calculation. Default is 30.</param>
    /// <returns>A DemaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The Double Exponential Moving Average (DEMA) is a technical indicator developed by Patrick Mulloy.
    /// It uses two exponential moving averages to eliminate lag. The formula is: DEMA = 2 * EMA - EMA(EMA).
    /// This makes DEMA more responsive to price changes than a traditional EMA or SMA.
    /// </remarks>
    public static DemaResult Dema(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Dema(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new DemaResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Double Exponential Moving Average (DEMA) using a default period of 30.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <returns>A DemaResult object containing the calculated values and metadata.</returns>
    public static DemaResult Dema(int startIdx, int endIdx, double[] real)
        => Dema(startIdx, endIdx, real, 30);

    /// <summary>
    /// Calculates the Double Exponential Moving Average (DEMA) for float input data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <param name="timePeriod">The number of periods to use in the DEMA calculation.</param>
    /// <returns>A DemaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static DemaResult Dema(int startIdx, int endIdx, float[] real, int timePeriod)
        => Dema(startIdx, endIdx, real.ToDouble(), timePeriod);

    /// <summary>
    /// Calculates the Double Exponential Moving Average (DEMA) for float input data using a default period of 30.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <returns>A DemaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static DemaResult Dema(int startIdx, int endIdx, float[] real)
        => Dema(startIdx, endIdx, real, 30);
}
