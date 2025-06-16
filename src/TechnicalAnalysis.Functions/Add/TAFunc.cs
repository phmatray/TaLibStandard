// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Performs vector addition of two input arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inReal0">First input array of values.</param>
    /// <param name="inReal1">Second input array of values.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array containing the sum of corresponding elements from inReal0 and inReal1.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// This function performs element-wise addition:
    /// outReal[i] = inReal0[i] + inReal1[i]
    /// 
    /// Common uses:
    /// - Combining multiple indicators or price series
    /// - Creating custom composite indicators
    /// - Adding constants to price series (when one array contains constant values)
    /// - Building spread indicators between two instruments
    /// </remarks>
    public static RetCode Add(
        int startIdx,
        int endIdx,
        in double[] inReal0,
        in double[] inReal1,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal0 == null!)
        {
            return BadParam;
        }

        if (inReal1 == null!)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        int i = startIdx;
        int outIdx = 0;
        while (i <= endIdx)
        {
            outReal[outIdx] = inReal0[i] + inReal1[i];
            i++;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Add calculation.
    /// </summary>
    /// <returns>Always returns 0 as addition requires no historical data.</returns>
    public static int AddLookback()
    {
        return 0;
    }
}
