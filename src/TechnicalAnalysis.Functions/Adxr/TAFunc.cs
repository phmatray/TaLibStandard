// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Average Directional Movement Index Rating (ADXR) - a smoothed version of ADX.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="optInTimePeriod">Number of periods for the ADX calculation. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the ADXR values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// ADXR is a smoothed version of the ADX indicator, providing a more stable trend strength reading.
    /// 
    /// Calculation:
    /// ADXR = (ADX today + ADX n periods ago) / 2
    /// 
    /// Where n is the same period used for ADX calculation (typically 14).
    /// 
    /// Interpretation (same as ADX but smoother):
    /// - Values above 25: Strong trend
    /// - Values below 20: Weak trend or ranging market
    /// - Rising ADXR: Trend strengthening
    /// - Falling ADXR: Trend weakening
    /// 
    /// ADXR lags more than ADX but provides fewer false signals due to its smoothing.
    /// It's particularly useful for confirming trend strength in longer-term trading strategies.
    /// </remarks>
    public static RetCode Adxr(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode indexCheck = ValidationHelper.ValidateIndexRange(startIdx, endIdx);
        if (indexCheck != Success)
        {
            return indexCheck;
        }

        RetCode arrayCheck = ValidationHelper.ValidateArrays(inHigh, inLow, inClose, outReal);
        if (arrayCheck != Success)
        {
            return arrayCheck;
        }

        RetCode periodCheck = ValidationHelper.ValidatePeriodRange(optInTimePeriod);
        if (periodCheck != Success)
        {
            return periodCheck;
        }

        int adxrLookback = AdxrLookback(optInTimePeriod);
        if (startIdx < adxrLookback)
        {
            startIdx = adxrLookback;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        double[] adx = new double[endIdx - startIdx + (2 * optInTimePeriod)];

        RetCode retCode = Adx(
            startIdx - (optInTimePeriod - 1),
            endIdx,
            inHigh,
            inLow,
            inClose,
            optInTimePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref adx);
            
        if (retCode != Success)
        {
            return retCode;
        }

        int i = optInTimePeriod - 1;
        int j = 0;
        int outIdx = 0;
        int nbElement = endIdx - startIdx + 2;
        while (true)
        {
            nbElement--;
            if (nbElement == 0)
            {
                break;
            }

            outReal[outIdx] = (adx[i] + adx[j]) / 2.0;
            outIdx++;
            j++;
            i++;
        }

        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for ADXR calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the ADX calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid ADXR value can be calculated, or -1 if parameters are invalid.</returns>
    public static int AdxrLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000
            ? -1
            : optInTimePeriod + AdxLookback(optInTimePeriod) - 1;
    }
}
