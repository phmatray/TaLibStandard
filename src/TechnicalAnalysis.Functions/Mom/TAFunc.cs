// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Momentum indicator - the difference between current price and price N periods ago.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods to look back. Typical values: 10, 12, 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the momentum values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Momentum is calculated as:
    /// MOM = Price(today) - Price(N periods ago)
    /// 
    /// Interpretation:
    /// - Positive values indicate upward momentum
    /// - Negative values indicate downward momentum
    /// - Zero line crossovers signal potential trend changes
    /// - Divergences with price can signal potential reversals
    /// 
    /// The raw momentum value represents the absolute price change.
    /// Often normalized or used with other indicators for better signals.
    /// Higher time periods smooth the indicator but increase lag.
    /// </remarks>
    public static RetCode Mom(
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

            outReal[outIdx] = inReal[inIdx] - inReal[trailingIdx];
            outIdx++;
            trailingIdx++;
            inIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Momentum calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods to look back. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid Momentum value can be calculated, or -1 if parameters are invalid.</returns>
    public static int MomLookback(int optInTimePeriod)
    {
        return ValidationHelper.ValidateLookback(optInTimePeriod, minPeriod: 1);
    }
}
