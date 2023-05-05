// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode Sar(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        double optInAcceleration,
        in double optInMaximum,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double sar;
        double ep;
        int tempInt = 0;
        double[] epTemp = new double[1];
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
            optInAcceleration < 0.0 ||
            optInMaximum < 0.0 ||
            outReal == null!)
        {
            return BadParam;
        }

        if (startIdx < 1)
        {
            startIdx = 1;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        double af = optInAcceleration;
        if (af > optInMaximum)
        {
            optInAcceleration = optInMaximum;
            af = optInAcceleration;
        }

        RetCode retCode = MinusDM(startIdx, startIdx, inHigh, inLow, 1, ref tempInt, ref tempInt, ref epTemp);
        int isLong = epTemp[0] > 0.0 ? 0 : 1;

        if (retCode != Success)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        outBegIdx = startIdx;
        int outIdx = 0;
        int todayIdx = startIdx;
        double newHigh = inHigh[todayIdx - 1];
        double newLow = inLow[todayIdx - 1];
        if (isLong == 1)
        {
            ep = inHigh[todayIdx];
            sar = newLow;
        }
        else
        {
            ep = inLow[todayIdx];
            sar = newHigh;
        }

        newLow = inLow[todayIdx];
        newHigh = inHigh[todayIdx];
        while (todayIdx <= endIdx)
        {
            double prevLow = newLow;
            double prevHigh = newHigh;
            newLow = inLow[todayIdx];
            newHigh = inHigh[todayIdx];
            todayIdx++;
            if (isLong == 1)
            {
                if (newLow <= sar)
                {
                    isLong = 0;
                    sar = ep;
                    if (sar < prevHigh)
                    {
                        sar = prevHigh;
                    }

                    if (sar < newHigh)
                    {
                        sar = newHigh;
                    }

                    outReal[outIdx] = sar;
                    outIdx++;
                    af = optInAcceleration;
                    ep = newLow;
                    sar += af * (ep - sar);
                    if (sar < prevHigh)
                    {
                        sar = prevHigh;
                    }

                    if (sar < newHigh)
                    {
                        sar = newHigh;
                    }
                }
                else
                {
                    outReal[outIdx] = sar;
                    outIdx++;
                    if (newHigh > ep)
                    {
                        ep = newHigh;
                        af += optInAcceleration;
                        if (af > optInMaximum)
                        {
                            af = optInMaximum;
                        }
                    }

                    sar += af * (ep - sar);
                    if (sar > prevLow)
                    {
                        sar = prevLow;
                    }

                    if (sar > newLow)
                    {
                        sar = newLow;
                    }
                }
            }
            else if (newHigh >= sar)
            {
                isLong = 1;
                sar = ep;
                if (sar > prevLow)
                {
                    sar = prevLow;
                }

                if (sar > newLow)
                {
                    sar = newLow;
                }

                outReal[outIdx] = sar;
                outIdx++;
                af = optInAcceleration;
                ep = newHigh;
                sar += af * (ep - sar);
                if (sar > prevLow)
                {
                    sar = prevLow;
                }

                if (sar > newLow)
                {
                    sar = newLow;
                }
            }
            else
            {
                outReal[outIdx] = sar;
                outIdx++;
                if (newLow < ep)
                {
                    ep = newLow;
                    af += optInAcceleration;
                    if (af > optInMaximum)
                    {
                        af = optInMaximum;
                    }
                }

                sar += af * (ep - sar);
                if (sar < prevHigh)
                {
                    sar = prevHigh;
                }

                if (sar < newHigh)
                {
                    sar = newHigh;
                }
            }
        }

        outNBElement = outIdx;
        return Success;
    }

    public static int SarLookback(double optInAcceleration, double optInMaximum)
    {
        return optInAcceleration < 0.0 ||
            optInMaximum < 0.0
            ? -1
            : 1;
    }
}
