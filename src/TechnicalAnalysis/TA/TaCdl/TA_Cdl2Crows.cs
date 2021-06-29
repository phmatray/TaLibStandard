namespace TechnicalAnalysis
{
    using System;

    internal static partial class TACore
    {
        public static RetCode Cdl2Crows(
            int startIdx,
            int endIdx,
            double[] inOpen,
            double[] inHigh,
            double[] inLow,
            double[] inClose,
            ref int outBegIdx,
            ref int outNBElement,
            int[] outInteger)
        {
            double num5;
            double num10;
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inOpen == null || inHigh == null || inLow == null || inClose == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            int lookbackTotal = Cdl2CrowsLookback();
            if (startIdx < lookbackTotal)
            {
                startIdx = lookbackTotal;
            }

            if (startIdx > endIdx)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
            }

            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 2 - Globals.candleSettings[0].avgPeriod;
            int i = bodyLongTrailingIdx;
            while (true)
            {
                double num24;
                if (i >= startIdx - 2)
                {
                    break;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num24 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num23;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num23 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num20;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num22 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num21 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];

                            num20 = inHigh[i] - num22 + (num21 - inLow[i]);
                        }
                        else
                        {
                            num20 = 0.0;
                        }

                        num23 = num20;
                    }

                    num24 = num23;
                }

                bodyLongPeriodTotal += num24;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_014D:
            if (inClose[i - 2] >= inOpen[i - 2])
            {
                double num19;
                if (Globals.candleSettings[0].avgPeriod != 0.0)
                {
                    num19 = bodyLongPeriodTotal / Globals.candleSettings[0].avgPeriod;
                }
                else
                {
                    double num18;
                    if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                    {
                        num18 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num17;
                        if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                        {
                            num17 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num14;
                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                double num16 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                double num15 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];

                                num14 = inHigh[i - 2] - num16 + (num15 - inLow[i - 2]);
                            }
                            else
                            {
                                num14 = 0.0;
                            }

                            num17 = num14;
                        }

                        num18 = num17;
                    }

                    num19 = num18;
                }

                double num13 = Globals.candleSettings[0].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                    > Globals.candleSettings[0].factor * num19 / num13
                    && (inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1)
                {
                    double num12 = inOpen[i - 1] < inClose[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                    double num11 = inOpen[i - 2] > inClose[i - 2] ? inOpen[i - 2] : inClose[i - 2];

                    if (num12 > num11 && (inClose[i] < inOpen[i] ? -1 : 1) == -1 && inOpen[i] < inOpen[i - 1] &&
                        inOpen[i] > inClose[i - 1] && inClose[i] > inOpen[i - 2] && inClose[i] < inClose[i - 2])
                    {
                        outInteger[outIdx] = -100;
                        outIdx++;
                        goto Label_036E;
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_036E:
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num8 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                        double num7 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];

                        num6 = inHigh[i - 2] - num8 + (num7 - inLow[i - 2]);
                    }
                    else
                    {
                        num6 = 0.0;
                    }

                    num9 = num6;
                }

                num10 = num9;
            }

            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[bodyLongTrailingIdx] - inOpen[bodyLongTrailingIdx]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[bodyLongTrailingIdx] - inLow[bodyLongTrailingIdx];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num3 = inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx]
                            ? inClose[bodyLongTrailingIdx]
                            : inOpen[bodyLongTrailingIdx];
                        double num2 = inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx]
                            ? inOpen[bodyLongTrailingIdx]
                            : inClose[bodyLongTrailingIdx];

                        num = inHigh[bodyLongTrailingIdx] - num3 + (num2 - inLow[bodyLongTrailingIdx]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            bodyLongPeriodTotal += num10 - num5;
            i++;
            bodyLongTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_014D;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int Cdl2CrowsLookback()
        {
            return Globals.candleSettings[0].avgPeriod + 2;
        }
    }
}
