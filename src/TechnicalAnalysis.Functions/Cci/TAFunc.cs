// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Commodity Channel Index (CCI) - a momentum oscillator used to identify cyclical trends.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="optInTimePeriod">Number of periods for the CCI calculation. Typical value: 20.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the CCI values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// CCI measures the difference between a security's price change and its average price change.
    /// 
    /// Calculation:
    /// CCI = (Typical Price - SMA of Typical Price) / (0.015 * Mean Deviation)
    /// Where Typical Price = (High + Low + Close) / 3
    /// 
    /// Interpretation:
    /// - Values typically range between -200 and +200
    /// - Above +100: Potentially overbought
    /// - Below -100: Potentially oversold
    /// - Zero line crossovers can signal trend changes
    /// - Divergences with price indicate potential reversals
    /// 
    /// Originally developed for commodities but now used across all markets.
    /// </remarks>
    public static RetCode Cci(
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

        int circBufferIdx = 0;
        int maxIdxCircBuffer = 29;

        int lookbackTotal = optInTimePeriod - 1;
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        double[] circBuffer = new double[optInTimePeriod];

        maxIdxCircBuffer = optInTimePeriod - 1;
        int i = startIdx - lookbackTotal;
        while (i < startIdx)
        {
            circBuffer[circBufferIdx] = (inHigh[i] + inLow[i] + inClose[i]) / 3.0;
            i++;
            circBufferIdx++;
            if (circBufferIdx > maxIdxCircBuffer)
            {
                circBufferIdx = 0;
            }
        }

        int outIdx = 0;
        do
        {
            double lastValue = (inHigh[i] + inLow[i] + inClose[i]) / 3.0;
            circBuffer[circBufferIdx] = lastValue;
            double theAverage = 0.0;
            int j = 0;
            while (j < optInTimePeriod)
            {
                theAverage += circBuffer[j];
                j++;
            }

            theAverage /= optInTimePeriod;
            double tempReal2 = 0.0;
            for (j = 0; j < optInTimePeriod; j++)
            {
                tempReal2 += Math.Abs(circBuffer[j] - theAverage);
            }

            double tempReal = lastValue - theAverage;
            if (tempReal != 0.0 && tempReal2 != 0.0)
            {
                outReal[outIdx] = tempReal / (0.015 * (tempReal2 / optInTimePeriod));
                outIdx++;
            }
            else
            {
                outReal[outIdx] = 0.0;
                outIdx++;
            }

            circBufferIdx++;
            if (circBufferIdx > maxIdxCircBuffer)
            {
                circBufferIdx = 0;
            }

            i++;
        }
        while (i <= endIdx);

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for CCI calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the CCI calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid CCI value can be calculated, or -1 if parameters are invalid.</returns>
    public static int CciLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
