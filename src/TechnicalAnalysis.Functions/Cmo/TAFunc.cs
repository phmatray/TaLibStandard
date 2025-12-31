// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Chande Momentum Oscillator (CMO) - a momentum oscillator that measures the difference between gains and losses.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of prices (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the CMO calculation. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the CMO values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// CMO is a variation of RSI that provides a more responsive momentum reading.
    /// 
    /// Calculation:
    /// CMO = 100 * (Sum of Gains - Sum of Losses) / (Sum of Gains + Sum of Losses)
    /// 
    /// Values range from -100 to +100:
    /// - Values above +50: Strong upward momentum
    /// - Values below -50: Strong downward momentum
    /// - Values near 0: No clear momentum
    /// 
    /// Interpretation:
    /// - Overbought: CMO above +50
    /// - Oversold: CMO below -50
    /// - Trend confirmation: CMO moving in direction of price
    /// - Divergence: CMO moving opposite to price (potential reversal)
    /// 
    /// Advantages over RSI:
    /// - Symmetric scale (-100 to +100) vs RSI (0 to 100)
    /// - More responsive to price changes
    /// - Clearer identification of momentum extremes
    /// </remarks>
    public static RetCode Cmo(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode validationResult = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal, optInTimePeriod);
        if (validationResult != Success)
        {
            return validationResult;
        }

        outBegIdx = 0;
        outNBElement = 0;
        int lookbackTotal = CmoLookback(optInTimePeriod);
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx <= endIdx)
        {
            double prevLoss;
            double prevGain;
            double tempValue1;
            double tempValue2;
            int i;
            int outIdx = 0;
            if (optInTimePeriod == 1)
            {
                outBegIdx = startIdx;
                i = endIdx - startIdx + 1;
                outNBElement = i;
                Array.Copy(inReal, startIdx, outReal, 0, i);
                return Success;
            }

            int today = startIdx - lookbackTotal;
            double prevValue = inReal[today];
            if (TACore.Globals.UnstablePeriod[FuncUnstId.Cmo] == 0 && TACore.Globals.Compatibility == Compatibility.Metastock)
            {
                double savePrevValue = prevValue;
                prevGain = 0.0;
                prevLoss = 0.0;
                for (i = optInTimePeriod; i > 0; i--)
                {
                    tempValue1 = inReal[today];
                    today++;
                    tempValue2 = tempValue1 - prevValue;
                    prevValue = tempValue1;
                    if (tempValue2 < 0.0)
                    {
                        prevLoss -= tempValue2;
                    }
                    else
                    {
                        prevGain += tempValue2;
                    }
                }

                tempValue1 = prevLoss / optInTimePeriod;
                tempValue2 = prevGain / optInTimePeriod;
                double tempValue3 = tempValue2 - tempValue1;
                double tempValue4 = tempValue1 + tempValue2;
                outReal[outIdx] = 100.0 * (tempValue3 / tempValue4);
                outIdx++;

                if (today > endIdx)
                {
                    outBegIdx = startIdx;
                    outNBElement = outIdx;
                    return Success;
                }

                today -= optInTimePeriod;
                prevValue = savePrevValue;
            }

            prevGain = 0.0;
            prevLoss = 0.0;
            today++;
            for (i = optInTimePeriod; i > 0; i--)
            {
                tempValue1 = inReal[today];
                today++;
                tempValue2 = tempValue1 - prevValue;
                prevValue = tempValue1;
                if (tempValue2 < 0.0)
                {
                    prevLoss -= tempValue2;
                }
                else
                {
                    prevGain += tempValue2;
                }
            }

            prevLoss /= optInTimePeriod;
            prevGain /= optInTimePeriod;
            if (today > startIdx)
            {
                tempValue1 = prevGain + prevLoss;
                outReal[outIdx] = 100.0 * ((prevGain - prevLoss) / tempValue1);
                outIdx++;
            }
            else
            {
                while (today < startIdx)
                {
                    tempValue1 = inReal[today];
                    tempValue2 = tempValue1 - prevValue;
                    prevValue = tempValue1;
                    prevLoss *= optInTimePeriod - 1;
                    prevGain *= optInTimePeriod - 1;
                    if (tempValue2 < 0.0)
                    {
                        prevLoss -= tempValue2;
                    }
                    else
                    {
                        prevGain += tempValue2;
                    }

                    prevLoss /= optInTimePeriod;
                    prevGain /= optInTimePeriod;
                    today++;
                }
            }

            while (today <= endIdx)
            {
                tempValue1 = inReal[today];
                today++;
                tempValue2 = tempValue1 - prevValue;
                prevValue = tempValue1;
                prevLoss *= optInTimePeriod - 1;
                prevGain *= optInTimePeriod - 1;
                if (tempValue2 < 0.0)
                {
                    prevLoss -= tempValue2;
                }
                else
                {
                    prevGain += tempValue2;
                }

                prevLoss /= optInTimePeriod;
                prevGain /= optInTimePeriod;
                tempValue1 = prevGain + prevLoss;
                outReal[outIdx] = 100.0 * ((prevGain - prevLoss) / tempValue1);
                outIdx++;
            }

            outBegIdx = startIdx;
            outNBElement = outIdx;
        }

        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for CMO calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the CMO calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid CMO value can be calculated, or -1 if parameters are invalid.</returns>
    public static int CmoLookback(int optInTimePeriod)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            return -1;
        }

        int retValue = optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Cmo];
        if (TACore.Globals.Compatibility == Compatibility.Metastock)
        {
            retValue--;
        }

        return retValue;
    }
}
