// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Normalized Average True Range (NATR) - ATR expressed as a percentage of closing price.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="optInTimePeriod">Number of periods for the NATR calculation. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the NATR values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// NATR normalizes the ATR by dividing it by the closing price, making it comparable across different price levels.
    /// 
    /// Calculation:
    /// NATR = (ATR / Close) * 100
    /// 
    /// Advantages over standard ATR:
    /// - Percentage-based: Comparable across different securities and price levels
    /// - Better for position sizing: Direct percentage risk measurement
    /// - Useful for scanning: Can compare volatility across entire market
    /// - Price-independent: A $10 stock and $1000 stock can be compared
    /// 
    /// Trading applications:
    /// - Volatility comparison across multiple securities
    /// - Position sizing based on equal volatility exposure
    /// - Stop-loss placement as percentage of price
    /// - Market regime identification (high/low volatility periods)
    /// - Options trading: Estimating potential price movement ranges
    /// 
    /// NATR values typically range from 1% to 10% for most securities,
    /// with higher values indicating more volatile instruments.
    /// </remarks>
    public static RetCode Natr(
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
        int outNbElement1 = 0;
        int outBegIdx1 = 0;
        double[] prevATRTemp = new double[1];
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHigh, inLow, inClose, outReal),
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriod, 1)
        );
        if (validation != Success)
        {
            return validation;
        }

        outBegIdx = 0;
        outNBElement = 0;
        int lookbackTotal = NatrLookback(optInTimePeriod);
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            return Success;
        }

        if (optInTimePeriod <= 1)
        {
            return TrueRange(startIdx, endIdx, inHigh, inLow, inClose, ref outBegIdx, ref outNBElement, ref outReal);
        }

        double[] tempBuffer = new double[lookbackTotal + (endIdx - startIdx) + 1];
        RetCode retCode = TrueRange(
            startIdx - lookbackTotal + 1,
            endIdx,
            inHigh,
            inLow,
            inClose,
            ref outBegIdx1,
            ref outNbElement1,
            ref tempBuffer);
            
        if (retCode == Success)
        {
            retCode = TA_INT_SMA(
                optInTimePeriod - 1,
                optInTimePeriod - 1,
                tempBuffer,
                optInTimePeriod,
                ref outBegIdx1,
                ref outNbElement1,
                prevATRTemp);
            if (retCode != Success)
            {
                return retCode;
            }

            double prevATR = prevATRTemp[0];
            int today = optInTimePeriod;
            int outIdx = (int)TACore.Globals.UnstablePeriod[FuncUnstId.Natr];
            while (true)
            {
                if (outIdx == 0)
                {
                    break;
                }

                prevATR *= optInTimePeriod - 1;
                prevATR += tempBuffer[today];
                today++;
                prevATR /= optInTimePeriod;
                outIdx--;
            }

            outIdx = 1;
            double tempValue = inClose[today];
            outReal[0] = prevATR / tempValue * 100.0;

            int nbATR = endIdx - startIdx + 1;
            while (true)
            {
                nbATR--;
                if (nbATR == 0)
                {
                    break;
                }

                prevATR *= optInTimePeriod - 1;
                prevATR += tempBuffer[today];
                today++;
                prevATR /= optInTimePeriod;
                tempValue = inClose[today];
                outReal[outIdx] = prevATR / tempValue * 100.0;

                outIdx++;
            }

            outBegIdx = startIdx;
            outNBElement = outIdx;
        }

        return retCode;
    }

    /// <summary>
    /// Returns the lookback period required for NATR calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the NATR calculation. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid NATR value can be calculated, or -1 if parameters are invalid.</returns>
    public static int NatrLookback(int optInTimePeriod)
    {
        return ValidationHelper.ValidateLookback(optInTimePeriod, minPeriod: 1, unstablePeriod: FuncUnstId.Natr);
    }
}
