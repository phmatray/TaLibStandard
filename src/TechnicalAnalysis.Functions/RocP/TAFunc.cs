// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Rate of Change Percentage (ROCP) - a momentum indicator showing price change as a ratio.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods to look back. Typical values: 9, 12, 25.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the ROCP values (as decimal ratios).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// ROCP is calculated as:
    /// ROCP = (Price(today) - Price(N periods ago)) / Price(N periods ago)
    /// 
    /// This is similar to ROC but expressed as a decimal ratio rather than percentage:
    /// - ROCP of 0.1 means 10% increase
    /// - ROCP of -0.05 means 5% decrease
    /// - ROCP of 0 means no change
    /// 
    /// To convert to percentage: ROCP × 100 = ROC
    /// 
    /// ROCP is useful when you need the raw ratio for calculations
    /// or when integrating with other indicators that expect decimal values.
    /// </remarks>
    public static RetCode RocP(
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
                outReal[outIdx] = (inReal[inIdx] - tempReal) / tempReal;
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
    /// Returns the lookback period required for ROCP calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods to look back. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid ROCP value can be calculated, or -1 if parameters are invalid.</returns>
    public static int RocPLookback(int optInTimePeriod)
    {
        return ValidationHelper.ValidateLookback(optInTimePeriod, minPeriod: 1);
    }
}
