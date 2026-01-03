// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Performs vector subtraction of two input arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inReal0">First input array (minuend).</param>
    /// <param name="inReal1">Second input array (subtrahend).</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the difference of corresponding elements (inReal0 - inReal1).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// This function performs element-wise subtraction:
    /// outReal[i] = inReal0[i] - inReal1[i]
    /// 
    /// Common uses:
    /// - Calculating price differences or spreads between instruments
    /// - Computing indicator divergences
    /// - Removing trend components from price series
    /// - Creating oscillators by subtracting moving averages
    /// - Calculating profit/loss series
    /// </remarks>
    public static RetCode Sub(
        int startIdx,
        int endIdx,
        in double[] inReal0,
        in double[] inReal1,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        var inReal0Local = inReal0;
        var inReal1Local = inReal1;
        var outRealLocal = outReal;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inReal0Local, inReal1Local, outRealLocal)
        );
        if (validation != Success)
        {
            return validation;
        }

        int i = startIdx;
        int outIdx = 0;
        while (i <= endIdx)
        {
            outReal[outIdx] = inReal0[i] - inReal1[i];
            i++;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Sub calculation.
    /// </summary>
    /// <returns>Always returns 0 as subtraction requires no historical data.</returns>
    public static int SubLookback()
    {
        return 0;
    }
}
