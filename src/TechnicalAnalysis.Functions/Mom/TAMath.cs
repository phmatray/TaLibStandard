// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Functions.Internal;

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Momentum indicator for the specified range of data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <param name="timePeriod">The number of periods to use in the momentum calculation. Default is 10.</param>
    /// <returns>A MomResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The Momentum indicator measures the rate of change in price over a specified period.
    /// It is calculated as the difference between the current price and the price n periods ago.
    /// Positive values indicate upward momentum, while negative values indicate downward momentum.
    /// The indicator is useful for identifying the strength and direction of price trends.
    /// </remarks>
    public static MomResult Mom(int startIdx, int endIdx, double[] real, int timePeriod = 10)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Mom(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);

        return new MomResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Momentum indicator for float input data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <param name="timePeriod">The number of periods to use in the momentum calculation. Default is 10.</param>
    /// <returns>A MomResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static MomResult Mom(int startIdx, int endIdx, float[] real, int timePeriod = 10)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => Mom(s, e, r, timePeriod));
}
