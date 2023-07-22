// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Mfi(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        in double[] inVolume,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int moneyFlowIdx = 0;
        int maxIdxMoneyFlow = 49;
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
            inVolume == null! ||
            optInTimePeriod is < 2 or > 100000 ||
            outReal == null!)
        {
            return BadParam;
        }

        MoneyFlow[] moneyFlow = new MoneyFlow[optInTimePeriod];
        for (int moneyFlowIndex = 0; moneyFlowIndex < moneyFlow.Length; moneyFlowIndex++)
        {
            moneyFlow[moneyFlowIndex] = new MoneyFlow();
        }

        maxIdxMoneyFlow = optInTimePeriod - 1;
        outBegIdx = 0;
        outNBElement = 0;
        int lookbackTotal = optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Mfi];
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx <= endIdx)
        {
            double tempValue1;
            double tempValue2;
            int outIdx = 0;
            int today = startIdx - lookbackTotal;
            double prevValue = (inHigh[today] + inLow[today] + inClose[today]) / 3.0;
            double posSumMF = 0.0;
            double negSumMF = 0.0;
            today++;
            for (int i = optInTimePeriod; i > 0; i--)
            {
                tempValue1 = (inHigh[today] + inLow[today] + inClose[today]) / 3.0;
                tempValue2 = tempValue1 - prevValue;
                prevValue = tempValue1;
                tempValue1 *= inVolume[today];
                today++;
                if (tempValue2 < 0.0)
                {
                    moneyFlow[moneyFlowIdx].Negative = tempValue1;
                    negSumMF += tempValue1;
                    moneyFlow[moneyFlowIdx].Positive = 0.0;
                }
                else if (tempValue2 > 0.0)
                {
                    moneyFlow[moneyFlowIdx].Positive = tempValue1;
                    posSumMF += tempValue1;
                    moneyFlow[moneyFlowIdx].Negative = 0.0;
                }
                else
                {
                    moneyFlow[moneyFlowIdx].Positive = 0.0;
                    moneyFlow[moneyFlowIdx].Negative = 0.0;
                }

                moneyFlowIdx++;
                if (moneyFlowIdx > maxIdxMoneyFlow)
                {
                    moneyFlowIdx = 0;
                }
            }

            if (today > startIdx)
            {
                tempValue1 = posSumMF + negSumMF;
                outReal[outIdx] = tempValue1 < 1.0 ? 0.0 : 100.0 * (posSumMF / tempValue1);
                outIdx++;
            }
            else
            {
                while (today < startIdx)
                {
                    posSumMF -= moneyFlow[moneyFlowIdx].Positive;
                    negSumMF -= moneyFlow[moneyFlowIdx].Negative;
                    tempValue1 = (inHigh[today] + inLow[today] + inClose[today]) / 3.0;
                    tempValue2 = tempValue1 - prevValue;
                    prevValue = tempValue1;
                    tempValue1 *= inVolume[today];
                    today++;
                    switch (tempValue2)
                    {
                        case < 0.0:
                            moneyFlow[moneyFlowIdx].Negative = tempValue1;
                            negSumMF += tempValue1;
                            moneyFlow[moneyFlowIdx].Positive = 0.0;
                            break;
                        case > 0.0:
                            moneyFlow[moneyFlowIdx].Positive = tempValue1;
                            posSumMF += tempValue1;
                            moneyFlow[moneyFlowIdx].Negative = 0.0;
                            break;
                        default:
                            moneyFlow[moneyFlowIdx].Positive = 0.0;
                            moneyFlow[moneyFlowIdx].Negative = 0.0;
                            break;
                    }

                    moneyFlowIdx++;
                    if (moneyFlowIdx > maxIdxMoneyFlow)
                    {
                        moneyFlowIdx = 0;
                    }
                }
            }

            while (today <= endIdx)
            {
                posSumMF -= moneyFlow[moneyFlowIdx].Positive;
                negSumMF -= moneyFlow[moneyFlowIdx].Negative;
                tempValue1 = (inHigh[today] + inLow[today] + inClose[today]) / 3.0;
                tempValue2 = tempValue1 - prevValue;
                prevValue = tempValue1;
                tempValue1 *= inVolume[today];
                today++;
                if (tempValue2 < 0.0)
                {
                    moneyFlow[moneyFlowIdx].Negative = tempValue1;
                    negSumMF += tempValue1;
                    moneyFlow[moneyFlowIdx].Positive = 0.0;
                }
                else if (tempValue2 > 0.0)
                {
                    moneyFlow[moneyFlowIdx].Positive = tempValue1;
                    posSumMF += tempValue1;
                    moneyFlow[moneyFlowIdx].Negative = 0.0;
                }
                else
                {
                    moneyFlow[moneyFlowIdx].Positive = 0.0;
                    moneyFlow[moneyFlowIdx].Negative = 0.0;
                }

                tempValue1 = posSumMF + negSumMF;
                if (tempValue1 < 1.0)
                {
                    outReal[outIdx] = 0.0;
                    outIdx++;
                }
                else
                {
                    outReal[outIdx] = 100.0 * (posSumMF / tempValue1);
                    outIdx++;
                }

                moneyFlowIdx++;
                if (moneyFlowIdx > maxIdxMoneyFlow)
                {
                    moneyFlowIdx = 0;
                }
            }

            outBegIdx = startIdx;
            outNBElement = outIdx;
        }

        return Success;
    }

    public static int MfiLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Mfi];
    }
}
