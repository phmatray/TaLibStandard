using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlPiercing(
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
            int totIdx;
            double[] bodyLongPeriodTotal = new double[2];
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

            int lookbackTotal = CdlPiercingLookback();
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

            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - Globals.candleSettings[0].avgPeriod;
            int i = bodyLongTrailingIdx;
            while (true)
            {
                double num29;
                double num34;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num34 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num33;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num33 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num30;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num31;
                            double num32;
                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num32 = inClose[i - 1];
                            }
                            else
                            {
                                num32 = inOpen[i - 1];
                            }

                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num31 = inOpen[i - 1];
                            }
                            else
                            {
                                num31 = inClose[i - 1];
                            }

                            num30 = inHigh[i - 1] - num32 + (num31 - inLow[i - 1]);
                        }
                        else
                        {
                            num30 = 0.0;
                        }

                        num33 = num30;
                    }

                    num34 = num33;
                }

                bodyLongPeriodTotal[1] += num34;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num29 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num28;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num28 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num25;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num26;
                            double num27;
                            if (inClose[i] >= inOpen[i])
                            {
                                num27 = inClose[i];
                            }
                            else
                            {
                                num27 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num26 = inOpen[i];
                            }
                            else
                            {
                                num26 = inClose[i];
                            }

                            num25 = inHigh[i] - num27 + (num26 - inLow[i]);
                        }
                        else
                        {
                            num25 = 0.0;
                        }

                        num28 = num25;
                    }

                    num29 = num28;
                }

                bodyLongPeriodTotal[0] += num29;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_0237:
            if ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1)
            {
                double num18;
                double num24;
                if (Globals.candleSettings[0].avgPeriod != 0.0)
                {
                    num24 = bodyLongPeriodTotal[1] / Globals.candleSettings[0].avgPeriod;
                }
                else
                {
                    double num23;
                    if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                    {
                        num23 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num22;
                        if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                        {
                            num22 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num19;
                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                double num20;
                                double num21;
                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num21 = inClose[i - 1];
                                }
                                else
                                {
                                    num21 = inOpen[i - 1];
                                }

                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num20 = inOpen[i - 1];
                                }
                                else
                                {
                                    num20 = inClose[i - 1];
                                }

                                num19 = inHigh[i - 1] - num21 + (num20 - inLow[i - 1]);
                            }
                            else
                            {
                                num19 = 0.0;
                            }

                            num22 = num19;
                        }

                        num23 = num22;
                    }

                    num24 = num23;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                {
                    num18 = 2.0;
                }
                else
                {
                    num18 = 1.0;
                }

                if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    > Globals.candleSettings[0].factor * num24 / num18 && inClose[i] >= inOpen[i])
                {
                    double num11;
                    double num17;
                    if (Globals.candleSettings[0].avgPeriod != 0.0)
                    {
                        num17 = bodyLongPeriodTotal[0] / Globals.candleSettings[0].avgPeriod;
                    }
                    else
                    {
                        double num16;
                        if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                        {
                            num16 = Math.Abs(inClose[i] - inOpen[i]);
                        }
                        else
                        {
                            double num15;
                            if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                            {
                                num15 = inHigh[i] - inLow[i];
                            }
                            else
                            {
                                double num12;
                                if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                                {
                                    double num13;
                                    double num14;
                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num14 = inClose[i];
                                    }
                                    else
                                    {
                                        num14 = inOpen[i];
                                    }

                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num13 = inOpen[i];
                                    }
                                    else
                                    {
                                        num13 = inClose[i];
                                    }

                                    num12 = inHigh[i] - num14 + (num13 - inLow[i]);
                                }
                                else
                                {
                                    num12 = 0.0;
                                }

                                num15 = num12;
                            }

                            num16 = num15;
                        }

                        num17 = num16;
                    }

                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        num11 = 2.0;
                    }
                    else
                    {
                        num11 = 1.0;
                    }

                    if (Math.Abs(inClose[i] - inOpen[i])
                        > Globals.candleSettings[0].factor * num17 / num11 && inOpen[i] < inLow[i - 1] && inClose[i] < inOpen[i - 1] && inClose[i] > inClose[i - 1]
                        + Math.Abs(inClose[i - 1] - inOpen[i - 1]) * 0.5)
                    {
                        outInteger[outIdx] = 100;
                        outIdx++;
                        goto Label_0558;
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0558:
            totIdx = 1;
            while (totIdx >= 0)
            {
                double num5;
                double num10;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num10 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num9;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num9 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num6;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num7;
                            double num8;
                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num8 = inClose[i - totIdx];
                            }
                            else
                            {
                                num8 = inOpen[i - totIdx];
                            }

                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num7 = inOpen[i - totIdx];
                            }
                            else
                            {
                                num7 = inClose[i - totIdx];
                            }

                            num6 = inHigh[i - totIdx] - num8 + (num7 - inLow[i - totIdx]);
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
                    num5 = Math.Abs(
                        inClose[bodyLongTrailingIdx - totIdx] - inOpen[bodyLongTrailingIdx - totIdx]);
                }
                else
                {
                    double num4;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num4 = inHigh[bodyLongTrailingIdx - totIdx] - inLow[bodyLongTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num2;
                            double num3;
                            if (inClose[bodyLongTrailingIdx - totIdx] >= inOpen[bodyLongTrailingIdx - totIdx])
                            {
                                num3 = inClose[bodyLongTrailingIdx - totIdx];
                            }
                            else
                            {
                                num3 = inOpen[bodyLongTrailingIdx - totIdx];
                            }

                            if (inClose[bodyLongTrailingIdx - totIdx] >= inOpen[bodyLongTrailingIdx - totIdx])
                            {
                                num2 = inOpen[bodyLongTrailingIdx - totIdx];
                            }
                            else
                            {
                                num2 = inClose[bodyLongTrailingIdx - totIdx];
                            }

                            num = inHigh[bodyLongTrailingIdx - totIdx] - num3
                                  + (num2 - inLow[bodyLongTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num = 0.0;
                        }

                        num4 = num;
                    }

                    num5 = num4;
                }

                bodyLongPeriodTotal[totIdx] += num10 - num5;
                totIdx--;
            }

            i++;
            bodyLongTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0237;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlPiercingLookback()
        {
            return Globals.candleSettings[0].avgPeriod + 1;
        }
    }
}
