using System;
using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    internal static partial class TACore
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
            double[] ep_temp = new double[1];
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inHigh == null || inLow == null)
            {
                return RetCode.BadParam;
            }

            if (optInOffsetOnReverse < 0.0)
            {
                return RetCode.BadParam;
            }

            if (optInAccelerationInitLong < 0.0)
            {
                return RetCode.BadParam;
            }

            if (optInAccelerationLong < 0.0)
            {
                return RetCode.BadParam;
            }

            if (optInAccelerationMaxLong < 0.0)
            {
                return RetCode.BadParam;
            }

            if (optInAccelerationInitShort < 0.0)
            {
                return RetCode.BadParam;
            }

            if (optInAccelerationShort < 0.0)
            {
                return RetCode.BadParam;
            }

            if (optInAccelerationMaxShort < 0.0)
            {
                return RetCode.BadParam;
            }

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            if (startIdx < 1)
            {
                startIdx = 1;
            }

            if (startIdx > endIdx)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
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
                RetCode retCode = MinusDM(startIdx, startIdx, inHigh, inLow, 1, ref tempInt, ref tempInt, ref ep_temp);
                if (ep_temp[0] > 0.0)
                {
                    isLong = 0;
                }
                else
                {
                    isLong = 1;
                }

                if (retCode != RetCode.Success)
                {
                    outBegIdx = 0;
                    outNBElement = 0;
                    return retCode;
                }
            }
            else if (optInStartValue > 0.0)
            {
                isLong = 1;
            }
            else
            {
                isLong = 0;
            }

            outBegIdx = startIdx;
            int outIdx = 0;
            int todayIdx = startIdx;
            double newHigh = inHigh[todayIdx - 1];
            double newLow = inLow[todayIdx - 1];
            if (optInStartValue == 0.0)
            {
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
            }
            else if (optInStartValue > 0.0)
            {
                ep = inHigh[todayIdx];
                sar = optInStartValue;
            }
            else
            {
                ep = inLow[todayIdx];
                sar = Math.Abs(optInStartValue);
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
            return RetCode.Success;
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
            if (optInOffsetOnReverse < 0.0)
            {
                return -1;
            }

            if (optInAccelerationInitLong < 0.0)
            {
                return -1;
            }

            if (optInAccelerationLong < 0.0)
            {
                return -1;
            }

            if (optInAccelerationMaxLong < 0.0)
            {
                return -1;
            }

            if (optInAccelerationInitShort < 0.0)
            {
                return -1;
            }

            if (optInAccelerationShort < 0.0)
            {
                return -1;
            }

            if (optInAccelerationMaxShort < 0.0)
            {
                return -1;
            }

            return 1;
        }
    }
}
