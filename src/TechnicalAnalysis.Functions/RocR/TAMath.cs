// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Rate of Change Ratio (ROCR) which measures price momentum as a ratio.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">Array of input values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 10).</param>
    /// <returns>A RocRResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The Rate of Change Ratio (ROCR) is a momentum oscillator that measures the ratio of the current
    /// price to the price n periods ago. It is calculated as: (Current Price / Price n periods ago).
    /// Values above 1.0 indicate upward momentum, while values below 1.0 indicate downward momentum.
    /// This differs from ROC which expresses the change as a percentage.
    /// </remarks>
    public static RocRResult RocR(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.RocR(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new RocRResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Rate of Change Ratio (ROCR) using a default time period of 10.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">Array of input values (typically closing prices).</param>
    /// <returns>A RocRResult object containing the calculated values and metadata.</returns>
    public static RocRResult RocR(int startIdx, int endIdx, double[] real)
        => RocR(startIdx, endIdx, real, 10);

    /// <summary>
    /// Calculates the Rate of Change Ratio (ROCR) for float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">Array of input values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 10).</param>
    /// <returns>A RocRResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// This ensures compatibility with data sources that provide float precision while maintaining accuracy
    /// in the calculations.
    /// </remarks>
    public static RocRResult RocR(int startIdx, int endIdx, float[] real, int timePeriod)
        => RocR(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Rate of Change Ratio (ROCR) for float arrays using a default time period of 10.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">Array of input values (typically closing prices).</param>
    /// <returns>A RocRResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before performing the calculation.
    /// </remarks>
    public static RocRResult RocR(int startIdx, int endIdx, float[] real)
        => RocR(startIdx, endIdx, real, 10);
}
