// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    private static RetCode TA_INT_EMA(int startIdx, int endIdx, double[] inReal0, int optInTimePeriod0, double optInK1, ref int outBegIdx, ref int outNbElement, double[] outReal0)
    {
        int today;
        double prevMA;
        int lookbackTotal = EmaLookback(optInTimePeriod0);
            
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }
            
        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return Success;
        }
            
        outBegIdx = startIdx;
            
        if (TACore.Globals.Compatibility != Compatibility.Default)
        {
            prevMA = inReal0[0];
            today = 1;
        }
        else
        {
            today = startIdx - lookbackTotal;
            int i = optInTimePeriod0;
            double tempReal = 0.0;
            while (true)
            {
                i--;
                    
                if (i <= 0)
                {
                    break;
                }
                    
                tempReal += inReal0[today];
                today++;
            }
            prevMA = tempReal / optInTimePeriod0;
        }
            
        while (today <= startIdx)
        {
            prevMA = (inReal0[today] - prevMA) * optInK1 + prevMA;
            today++;
        }
            
        outReal0[0] = prevMA;
        int outIdx = 1;
            
        while (true)
        {
            if (today > endIdx)
            {
                break;
            }
                
            prevMA = (inReal0[today] - prevMA) * optInK1 + prevMA;
            today++;
            outReal0[outIdx] = prevMA;
            outIdx++;
        }
            
        outNbElement = outIdx;
        return Success;
    }
        
    private static RetCode TA_INT_MACD(int startIdx, int endIdx, double[] inReal0, int optInFastPeriod0, int optInSlowPeriod1, int optInSignalPeriod2, ref int outBegIdx, ref int outNbElement, double[] outMACD0, double[] outMACDSignal1, double[] outMACDHist2)
    {
        int i;
        int outNbElement1 = 0;
        int outNbElement2 = 0;
        double k2;
        double k1;
        int outBegIdx2 = 0;
        int outBegIdx1 = 0;

        int tempInteger;
        if (optInSlowPeriod1 < optInFastPeriod0)
        {
            tempInteger = optInSlowPeriod1;
            optInSlowPeriod1 = optInFastPeriod0;
            optInFastPeriod0 = tempInteger;
        }

        if (optInSlowPeriod1 != 0)
        {
            k1 = 2.0 / (optInSlowPeriod1 + 1);
        }
        else
        {
            optInSlowPeriod1 = 26;
            k1 = 0.075;
        }
            
        if (optInFastPeriod0 != 0)
        {
            k2 = 2.0 / (optInFastPeriod0 + 1);
        }
        else
        {
            optInFastPeriod0 = 12;
            k2 = 0.15;
        }
            
        int lookbackSignal = EmaLookback(optInSignalPeriod2);
        int lookbackTotal = lookbackSignal;
        lookbackTotal += EmaLookback(optInSlowPeriod1);
            
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }
            
        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return Success;
        }
            
        tempInteger = endIdx - startIdx + 1 + lookbackSignal;
            
        double[] fastEMABuffer = new double[tempInteger];
        double[] slowEMABuffer = new double[tempInteger];
            
        tempInteger = startIdx - lookbackSignal;
        RetCode retCode = TA_INT_EMA(tempInteger, endIdx, inReal0, optInSlowPeriod1, k1, ref outBegIdx1, ref outNbElement1, slowEMABuffer);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return retCode;
        }
            
        retCode = TA_INT_EMA(tempInteger, endIdx, inReal0, optInFastPeriod0, k2, ref outBegIdx2, ref outNbElement2, fastEMABuffer);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return retCode;
        }
            
        if (outBegIdx1 != tempInteger || outBegIdx2 != tempInteger || outNbElement1 != outNbElement2 || outNbElement1 != endIdx - startIdx + 1 + lookbackSignal)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return InternalError;
        }
            
        for (i = 0; i < outNbElement1; i++)
        {
            fastEMABuffer[i] -= slowEMABuffer[i];
        }
            
        Array.Copy(fastEMABuffer, lookbackSignal, outMACD0, 0, endIdx - startIdx + 1);
        retCode = TA_INT_EMA(0, outNbElement1 - 1, fastEMABuffer, optInSignalPeriod2, 2.0 / (optInSignalPeriod2 + 1), ref outBegIdx2, ref outNbElement2, outMACDSignal1);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return retCode;
        }
            
        for (i = 0; i < outNbElement2; i++)
        {
            outMACDHist2[i] = outMACD0[i] - outMACDSignal1[i];
        }
            
        outBegIdx = startIdx;
        outNbElement = outNbElement2;
        return Success;
    }
        
    private static RetCode TA_INT_PO(int startIdx, int endIdx, double[] inReal0, int optInFastPeriod0, int optInSlowPeriod1, MAType optInMethod2, ref int outBegIdx, ref int outNbElement, double[] outReal0, double[] tempBuffer, int doPercentageOutput)
    {
        int tempInteger = 0;
        int outBegIdx2 = 0;
        int outNbElement2 = 0;
            
        if (optInSlowPeriod1 < optInFastPeriod0)
        {
            tempInteger = optInSlowPeriod1;
            optInSlowPeriod1 = optInFastPeriod0;
            optInFastPeriod0 = tempInteger;
        }
            
        RetCode retCode = MovingAverage(startIdx, endIdx, inReal0, optInFastPeriod0, optInMethod2, ref outBegIdx2, ref outNbElement2, ref tempBuffer);
            
        if (retCode == Success)
        {
            int outNbElement1 = 0;
            int outBegIdx1 = 0;
            retCode = MovingAverage(startIdx, endIdx, inReal0, optInSlowPeriod1, optInMethod2, ref outBegIdx1, ref outNbElement1, ref outReal0);
                
            if (retCode == Success)
            {
                int i;
                int j;
                tempInteger = outBegIdx1 - outBegIdx2;
                    
                if (doPercentageOutput == 0)
                {
                    i = 0;
                    j = tempInteger;
                    while (i < outNbElement1)
                    {
                        outReal0[i] = tempBuffer[j] - outReal0[i];
                        i++;
                        j++;
                    }
                }
                else
                {
                    i = 0;
                    for (j = tempInteger; i < outNbElement1; j++)
                    {
                        double tempReal = outReal0[i];
                        outReal0[i] = (tempBuffer[j] - tempReal) / tempReal * 100.0;
                        i++;
                    }
                }
                outBegIdx = outBegIdx1;
                outNbElement = outNbElement1;
            }
        }
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNbElement = 0;
        }
            
        return retCode;
    }
        
    private static RetCode TA_INT_SMA(int startIdx, int endIdx, double[] inReal0, int optInTimePeriod0, ref int outBegIdx, ref int outNbElement, double[] outReal0)
    {
        int lookbackTotal = optInTimePeriod0 - 1;
            
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }
            
        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return Success;
        }
            
        double periodTotal = 0.0;
        int trailingIdx = startIdx - lookbackTotal;
        int i = trailingIdx;
            
        if (optInTimePeriod0 > 1)
        {
            while (i < startIdx)
            {
                periodTotal += inReal0[i];
                i++;
            }
        }
            
        int outIdx = 0;
            
        do
        {
            periodTotal += inReal0[i];
            i++;
            double tempReal = periodTotal;
            periodTotal -= inReal0[trailingIdx];
            trailingIdx++;
            outReal0[outIdx] = tempReal / optInTimePeriod0;
            outIdx++;
        }
        while (i <= endIdx);
            
        outNbElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }
        
    private static void TA_INT_stddev_using_precalc_ma(double[] inReal, double[] inMovAvg, int inMovAvgBegIdx, int inMovAvgNbElement, int timePeriod, double[] output)
    {
        double tempReal;
        int outIdx;
        int startSum = inMovAvgBegIdx + 1 - timePeriod;
        int endSum = inMovAvgBegIdx;
        double periodTotal2 = 0.0;
            
        for (outIdx = startSum; outIdx < endSum; outIdx++)
        {
            tempReal = inReal[outIdx];
            tempReal *= tempReal;
            periodTotal2 += tempReal;
        }
            
        outIdx = 0;
            
        while (outIdx < inMovAvgNbElement)
        {
            tempReal = inReal[endSum];
            tempReal *= tempReal;
            periodTotal2 += tempReal;
            double meanValue2 = periodTotal2 / timePeriod;
            tempReal = inReal[startSum];
            tempReal *= tempReal;
            periodTotal2 -= tempReal;
            tempReal = inMovAvg[outIdx];
            tempReal *= tempReal;
            meanValue2 -= tempReal;
            output[outIdx] = meanValue2 >= 1E-08 ? Math.Sqrt(meanValue2) : 0.0;
            outIdx++;
            startSum++;
            endSum++;
        }
    }
        
    private static RetCode TA_INT_VAR(int startIdx, int endIdx, double[] inReal0, int optInTimePeriod0, ref int outBegIdx, ref int outNbElement, double[] outReal0)
    {
        double tempReal;
        int nbInitialElementNeeded = optInTimePeriod0 - 1;
            
        if (startIdx < nbInitialElementNeeded)
        {
            startIdx = nbInitialElementNeeded;
        }
            
        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return Success;
        }
            
        double periodTotal1 = 0.0;
        double periodTotal2 = 0.0;
        int trailingIdx = startIdx - nbInitialElementNeeded;
        int i = trailingIdx;
            
        if (optInTimePeriod0 > 1)
        {
            while (i < startIdx)
            {
                tempReal = inReal0[i];
                i++;
                periodTotal1 += tempReal;
                tempReal *= tempReal;
                periodTotal2 += tempReal;
            }
        }
            
        int outIdx = 0;
            
        do
        {
            tempReal = inReal0[i];
            i++;
            periodTotal1 += tempReal;
            tempReal *= tempReal;
            periodTotal2 += tempReal;
            double meanValue1 = periodTotal1 / optInTimePeriod0;
            double meanValue2 = periodTotal2 / optInTimePeriod0;
            tempReal = inReal0[trailingIdx];
            trailingIdx++;
            periodTotal1 -= tempReal;
            tempReal *= tempReal;
            periodTotal2 -= tempReal;
            outReal0[outIdx] = meanValue2 - meanValue1 * meanValue1;
            outIdx++;
        }
        while (i <= endIdx);
            
        outNbElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }
}
