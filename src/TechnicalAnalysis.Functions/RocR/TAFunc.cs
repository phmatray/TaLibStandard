// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Rate of Change Ratio (RocR) for a given period.
    /// </summary>
    /// <remarks>
    /// The Rate of Change Ratio (RocR) is a momentum oscillator that measures the ratio
    /// between the current price and the price n periods ago. It is calculated as:
    /// RocR = Current Price / Price n periods ago
    /// 
    /// A RocR value of 1.0 indicates no change, values above 1.0 indicate an increase,
    /// and values below 1.0 indicate a decrease. For example, a RocR of 1.1 represents
    /// a 10% increase, while a RocR of 0.9 represents a 10% decrease.
    /// 
    /// This indicator is useful for identifying momentum and potential trend changes.
    /// When RocR crosses above 1.0, it may signal upward momentum, and when it crosses
    /// below 1.0, it may signal downward momentum.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">The number of periods to look back for comparison (valid range: 1-100000).</param>
    /// <param name="outBegIdx">Output parameter that will contain the index of the first valid output value.</param>
    /// <param name="outNBElement">Output parameter that will contain the number of elements in the output array.</param>
    /// <param name="outReal">Output array that will contain the calculated RocR values.</param>
    /// <returns>
    /// A <see cref="RetCode"/> indicating the success or failure of the calculation.
    /// Returns <see cref="RetCode.Success"/> on successful calculation.
    /// Returns <see cref="RetCode.OutOfRangeStartIndex"/> if startIdx is less than 0.
    /// Returns <see cref="RetCode.OutOfRangeEndIndex"/> if endIdx is less than 0 or less than startIdx.
    /// Returns <see cref="RetCode.BadParam"/> if any input parameters are invalid.
    /// </returns>
    public static RetCode RocR(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode validationResult = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal, optInTimePeriod, 1);
        if (validationResult != Success)
        {
            return validationResult;
        }

        if (startIdx < optInTimePeriod)
        {
            startIdx = optInTimePeriod;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outIdx = 0;
        int inIdx = startIdx;
        int trailingIdx = startIdx - optInTimePeriod;
        while (true)
        {
            if (inIdx > endIdx)
            {
                break;
            }

            double tempReal = inReal[trailingIdx];
            trailingIdx++;
            if (tempReal != 0.0)
            {
                outReal[outIdx] = inReal[inIdx] / tempReal;
                outIdx++;
            }
            else
            {
                outReal[outIdx] = 0.0;
                outIdx++;
            }

            inIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Calculates the lookback period required for the RocR calculation.
    /// </summary>
    /// <remarks>
    /// The lookback period represents the number of data points that must be available
    /// before the first RocR value can be calculated. For RocR, this is equal to the
    /// specified time period, as we need at least that many historical values to compare
    /// against the current value.
    /// </remarks>
    /// <param name="optInTimePeriod">The number of periods used in the RocR calculation (valid range: 1-100000).</param>
    /// <returns>
    /// The number of data points required before the first valid RocR value can be calculated.
    /// Returns -1 if the time period is outside the valid range.
    /// </returns>
    public static int RocRLookback(int optInTimePeriod)
    {
        return ValidationHelper.ValidateLookback(optInTimePeriod, minPeriod: 1);
    }
}
