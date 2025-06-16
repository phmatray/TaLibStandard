// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Rate of Change Percentage (ROCP) indicator for the specified range of data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <param name="timePeriod">The number of periods to use in the ROCP calculation. Default is 10.</param>
    /// <returns>A RocPResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The Rate of Change Percentage (ROCP) indicator is similar to ROC but expresses the rate of change
    /// as a decimal fraction rather than a percentage. The formula is: ROCP = (current price - price n 
    /// periods ago) / price n periods ago. For example, a 10% increase would be represented as 0.1.
    /// This momentum oscillator helps identify the velocity of price changes and potential trend reversals.
    /// </remarks>
    public static RocPResult RocP(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.RocP(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new RocPResult(retCode, outBegIdx, outNBElement, outReal);
    }
        
    /// <summary>
    /// Calculates the Rate of Change Percentage (ROCP) indicator using a default period of 10.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <returns>A RocPResult object containing the calculated values and metadata.</returns>
    public static RocPResult RocP(int startIdx, int endIdx, double[] real)
        => RocP(startIdx, endIdx, real, 10);

    /// <summary>
    /// Calculates the Rate of Change Percentage (ROCP) indicator for float input data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <param name="timePeriod">The number of periods to use in the ROCP calculation.</param>
    /// <returns>A RocPResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static RocPResult RocP(int startIdx, int endIdx, float[] real, int timePeriod)
        => RocP(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Rate of Change Percentage (ROCP) indicator for float input data using a default period of 10.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <returns>A RocPResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static RocPResult RocP(int startIdx, int endIdx, float[] real)
        => RocP(startIdx, endIdx, real, 10);
}
