// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Kaufman Adaptive Moving Average (KAMA) for the specified range of data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <param name="timePeriod">The number of periods to use in the KAMA calculation. Default is 30.</param>
    /// <returns>A KamaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The Kaufman Adaptive Moving Average (KAMA) was developed by Perry Kaufman. It is designed to
    /// account for market noise or volatility. KAMA will closely follow prices when the price swings
    /// are relatively small and the noise is low. KAMA will adjust when the price swings widen and
    /// follow prices from a greater distance. This trend-following indicator can be used to identify
    /// the overall trend, time turning points and filter price movements.
    /// </remarks>
    public static KamaResult Kama(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Kama(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new KamaResult(retCode, outBegIdx, outNBElement, outReal);
    }
        
    /// <summary>
    /// Calculates the Kaufman Adaptive Moving Average (KAMA) using a default period of 30.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <returns>A KamaResult object containing the calculated values and metadata.</returns>
    public static KamaResult Kama(int startIdx, int endIdx, double[] real)
        => Kama(startIdx, endIdx, real, 30);

    /// <summary>
    /// Calculates the Kaufman Adaptive Moving Average (KAMA) for float input data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <param name="timePeriod">The number of periods to use in the KAMA calculation.</param>
    /// <returns>A KamaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static KamaResult Kama(int startIdx, int endIdx, float[] real, int timePeriod)
        => Kama(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Kaufman Adaptive Moving Average (KAMA) for float input data using a default period of 30.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <returns>A KamaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static KamaResult Kama(int startIdx, int endIdx, float[] real)
        => Kama(startIdx, endIdx, real, 30);
}
