// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Rate of Change (ROC) indicator for the specified range of data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <param name="timePeriod">The number of periods to use in the ROC calculation. Default is 10.</param>
    /// <returns>A RocResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The Rate of Change (ROC) indicator measures the percentage change in price between the current
    /// price and the price n periods ago. The formula is: ROC = ((current price - price n periods ago) / 
    /// price n periods ago) * 100. This momentum oscillator is useful for identifying overbought and
    /// oversold conditions, as well as confirming price trends and spotting divergences.
    /// </remarks>
    public static RocResult Roc(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Roc(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new RocResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Rate of Change (ROC) indicator using a default period of 10.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <returns>A RocResult object containing the calculated values and metadata.</returns>
    public static RocResult Roc(int startIdx, int endIdx, double[] real)
        => Roc(startIdx, endIdx, real, 10);

    /// <summary>
    /// Calculates the Rate of Change (ROC) indicator for float input data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <param name="timePeriod">The number of periods to use in the ROC calculation.</param>
    /// <returns>A RocResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static RocResult Roc(int startIdx, int endIdx, float[] real, int timePeriod)
        => Roc(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Rate of Change (ROC) indicator for float input data using a default period of 10.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <returns>A RocResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static RocResult Roc(int startIdx, int endIdx, float[] real)
        => Roc(startIdx, endIdx, real, 10);
}
