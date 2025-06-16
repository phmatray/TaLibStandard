// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Average True Range (ATR) - a volatility indicator that measures the average range of price movement.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="optInTimePeriod">Number of periods for the ATR calculation. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the ATR values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// ATR measures volatility by calculating the average of the True Range over a specified period.
    /// True Range is the greatest of:
    /// - Current High - Current Low
    /// - |Current High - Previous Close|
    /// - |Current Low - Previous Close|
    /// 
    /// ATR uses:
    /// - Volatility measurement: Higher ATR indicates higher volatility
    /// - Stop-loss placement: Often placed at 2-3 ATR from entry
    /// - Position sizing: Inversely proportional to ATR for risk management
    /// - Breakout confirmation: Moves exceeding 1-2 ATR can signal breakouts
    /// 
    /// ATR is non-directional - it measures volatility regardless of price direction.
    /// </remarks>
    public static RetCode Atr(
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
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inHigh == null! ||
            inLow == null! ||
            inClose == null! ||
            optInTimePeriod is < 1 or > 100000 ||
            outReal == null!)
        {
            return BadParam;
        }

        outBegIdx = 0;
        outNBElement = 0;
        int lookbackTotal = AtrLookback(optInTimePeriod);
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
            int outIdx = (int)TACore.Globals.UnstablePeriod[FuncUnstId.Atr];
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
            outReal[0] = prevATR;
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
                outReal[outIdx] = prevATR / optInTimePeriod;
                outIdx++;
            }

            outBegIdx = startIdx;
            outNBElement = outIdx;
        }

        return retCode;
    }

    /// <summary>
    /// Returns the lookback period required for ATR calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the ATR calculation. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid ATR value can be calculated, or -1 if parameters are invalid.</returns>
    public static int AtrLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 1 or > 100000 ? -1 : optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Atr];
    }
}
