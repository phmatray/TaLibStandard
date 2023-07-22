// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode SarExt(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double optInStartValue,
        in double optInOffsetOnReverse,
        double optInAccelerationInitLong,
        double optInAccelerationLong,
        in double optInAccelerationMaxLong,
        double optInAccelerationInitShort,
        double optInAccelerationShort,
        in double optInAccelerationMaxShort,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double sar;
        double ep;
        int isLong;
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
            optInOffsetOnReverse < 0.0 ||
            optInAccelerationInitLong < 0.0 ||
            optInAccelerationLong < 0.0 ||
            optInAccelerationMaxLong < 0.0 ||
            optInAccelerationInitShort < 0.0 ||
            optInAccelerationShort < 0.0 ||
            optInAccelerationMaxShort < 0.0 ||
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

        double afLong = optInAccelerationInitLong;
        double afShort = optInAccelerationInitShort;
        if (afLong > optInAccelerationMaxLong)
        {
            optInAccelerationInitLong = optInAccelerationMaxLong;
            afLong = optInAccelerationInitLong;
        }

        if (optInAccelerationLong > optInAccelerationMaxLong)
        {
            optInAccelerationLong = optInAccelerationMaxLong;
        }

        if (afShort > optInAccelerationMaxShort)
        {
            optInAccelerationInitShort = optInAccelerationMaxShort;
            afShort = optInAccelerationInitShort;
        }

        if (optInAccelerationShort > optInAccelerationMaxShort)
        {
            optInAccelerationShort = optInAccelerationMaxShort;
        }

        if (optInStartValue == 0.0)
        {
            int tempInt = 0;
            RetCode retCode = MinusDM(startIdx, startIdx, inHigh, inLow, 1, ref tempInt, ref tempInt, ref epTemp);
            isLong = epTemp[0] > 0.0 ? 0 : 1;

            if (retCode != Success)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return retCode;
            }
        }
        else
        {
            isLong = optInStartValue > 0.0 ? 1 : 0;
        }

        outBegIdx = startIdx;
        int outIdx = 0;
        int todayIdx = startIdx;
        double newHigh = inHigh[todayIdx - 1];
        double newLow = inLow[todayIdx - 1];
        switch (optInStartValue)
        {
            case 0.0 when isLong == 1:
                ep = inHigh[todayIdx];
                sar = newLow;
                break;
            case 0.0:
                ep = inLow[todayIdx];
                sar = newHigh;
                break;
            case > 0.0:
                ep = inHigh[todayIdx];
                sar = optInStartValue;
                break;
            default:
                ep = inLow[todayIdx];
                sar = Math.Abs(optInStartValue);
                break;
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

                    if (optInOffsetOnReverse != 0.0)
                    {
                        sar += sar * optInOffsetOnReverse;
                    }

                    outReal[outIdx] = -sar;
                    outIdx++;
                    afShort = optInAccelerationInitShort;
                    ep = newLow;
                    sar += afShort * (ep - sar);
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
                        afLong += optInAccelerationLong;
                        if (afLong > optInAccelerationMaxLong)
                        {
                            afLong = optInAccelerationMaxLong;
                        }
                    }

                    sar += afLong * (ep - sar);
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

                if (optInOffsetOnReverse != 0.0)
                {
                    sar -= sar * optInOffsetOnReverse;
                }

                outReal[outIdx] = sar;
                outIdx++;
                afLong = optInAccelerationInitLong;
                ep = newHigh;
                sar += afLong * (ep - sar);
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
                outReal[outIdx] = -sar;
                outIdx++;
                if (newLow < ep)
                {
                    ep = newLow;
                    afShort += optInAccelerationShort;
                    if (afShort > optInAccelerationMaxShort)
                    {
                        afShort = optInAccelerationMaxShort;
                    }
                }

                sar += afShort * (ep - sar);
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

    public static int SarExtLookback(
        double optInStartValue,
        double optInOffsetOnReverse,
        double optInAccelerationInitLong,
        double optInAccelerationLong,
        double optInAccelerationMaxLong,
        double optInAccelerationInitShort,
        double optInAccelerationShort,
        double optInAccelerationMaxShort)
    {
        return optInStartValue < 0.0 ||
               optInOffsetOnReverse < 0.0 ||
               optInAccelerationInitLong < 0.0 ||
               optInAccelerationLong < 0.0 ||
               optInAccelerationMaxLong < 0.0 ||
               optInAccelerationInitShort < 0.0 ||
               optInAccelerationShort < 0.0 ||
               optInAccelerationMaxShort < 0.0
            ? -1
            : 1;
    }
}
