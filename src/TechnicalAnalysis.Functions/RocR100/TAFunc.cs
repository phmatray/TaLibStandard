// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Rate of Change Ratio as a percentage (RocR100) for a given period.
    /// </summary>
    /// <remarks>
    /// The Rate of Change Ratio 100 (RocR100) is a momentum oscillator that measures the
    /// percentage ratio between the current price and the price n periods ago. It is calculated as:
    /// RocR100 = (Current Price / Price n periods ago) * 100
    /// 
    /// A RocR100 value of 100 indicates no change, values above 100 indicate a percentage increase,
    /// and values below 100 indicate a percentage decrease. For example, a RocR100 of 110 represents
    /// a 10% increase, while a RocR100 of 90 represents a 10% decrease.
    /// 
    /// This is essentially the same as RocR but multiplied by 100 to express the result as a
    /// percentage, making it easier to interpret. Many traders prefer this format as it directly
    /// shows the percentage change.
    /// 
    /// Common uses include:
    /// - Identifying overbought/oversold conditions
    /// - Detecting divergences between price and momentum
    /// - Confirming trend strength
    /// - Generating trading signals when crossing key levels (e.g., 100)
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">The number of periods to look back for comparison (valid range: 1-100000).</param>
    /// <param name="outBegIdx">Output parameter that will contain the index of the first valid output value.</param>
    /// <param name="outNBElement">Output parameter that will contain the number of elements in the output array.</param>
    /// <param name="outReal">Output array that will contain the calculated RocR100 percentage values.</param>
    /// <returns>
    /// A <see cref="RetCode"/> indicating the success or failure of the calculation.
    /// Returns <see cref="RetCode.Success"/> on successful calculation.
    /// Returns <see cref="RetCode.OutOfRangeStartIndex"/> if startIdx is less than 0.
    /// Returns <see cref="RetCode.OutOfRangeEndIndex"/> if endIdx is less than 0 or less than startIdx.
    /// Returns <see cref="RetCode.BadParam"/> if any input parameters are invalid.
    /// </returns>
    public static RetCode RocR100(
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
                outReal[outIdx] = inReal[inIdx] / tempReal * 100.0;
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
    /// Calculates the lookback period required for the RocR100 calculation.
    /// </summary>
    /// <remarks>
    /// The lookback period represents the number of data points that must be available
    /// before the first RocR100 value can be calculated. For RocR100, this is equal to the
    /// specified time period, as we need at least that many historical values to compare
    /// against the current value.
    /// </remarks>
    /// <param name="optInTimePeriod">The number of periods used in the RocR100 calculation (valid range: 1-100000).</param>
    /// <returns>
    /// The number of data points required before the first valid RocR100 value can be calculated.
    /// Returns -1 if the time period is outside the valid range.
    /// </returns>
    public static int RocR100Lookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 1 or > 100000 ? -1 : optInTimePeriod;
    }
}
