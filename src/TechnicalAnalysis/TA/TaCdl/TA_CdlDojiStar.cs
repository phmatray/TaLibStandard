using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlDojiStar(
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
            double num15;
            double num20;
            int num21;
            double num22;
            double num23;
            double num26;
            double num32;
            double num33;
            double num39;
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

            int lookbackTotal = CdlDojiStarLookback();
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
            double bodyDojiPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 1 - Globals.candleSettings[0].avgPeriod;
            int bodyDojiTrailingIdx = startIdx - Globals.candleSettings[3].avgPeriod;
            int i = bodyLongTrailingIdx;
            while (true)
            {
                double num49;
                if (i >= startIdx - 1)
                {
                    break;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num49 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num48;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num48 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num45;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num46;
                            double num47;
                            if (inClose[i] >= inOpen[i])
                            {
                                num47 = inClose[i];
                            }
                            else
                            {
                                num47 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num46 = inOpen[i];
                            }
                            else
                            {
                                num46 = inClose[i];
                            }

                            num45 = inHigh[i] - num47 + (num46 - inLow[i]);
                        }
                        else
                        {
                            num45 = 0.0;
                        }

                        num48 = num45;
                    }

                    num49 = num48;
                }

                bodyLongPeriodTotal += num49;
                i++;
            }

            i = bodyDojiTrailingIdx;
            while (true)
            {
                double num44;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
                {
                    num44 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num43;
                    if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                    {
                        num43 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num40;
                        if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                        {
                            double num41;
                            double num42;
                            if (inClose[i] >= inOpen[i])
                            {
                                num42 = inClose[i];
                            }
                            else
                            {
                                num42 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num41 = inOpen[i];
                            }
                            else
                            {
                                num41 = inClose[i];
                            }

                            num40 = inHigh[i] - num42 + (num41 - inLow[i]);
                        }
                        else
                        {
                            num40 = 0.0;
                        }

                        num43 = num40;
                    }

                    num44 = num43;
                }

                bodyDojiPeriodTotal += num44;
                i++;
            }

            int outIdx = 0;
            Label_0232:
            if (Globals.candleSettings[0].avgPeriod != 0.0)
            {
                num39 = bodyLongPeriodTotal / Globals.candleSettings[0].avgPeriod;
            }
            else
            {
                double num38;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num38 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num37;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num37 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num34;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num35;
                            double num36;
                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num36 = inClose[i - 1];
                            }
                            else
                            {
                                num36 = inOpen[i - 1];
                            }

                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num35 = inOpen[i - 1];
                            }
                            else
                            {
                                num35 = inClose[i - 1];
                            }

                            num34 = inHigh[i - 1] - num36 + (num35 - inLow[i - 1]);
                        }
                        else
                        {
                            num34 = 0.0;
                        }

                        num37 = num34;
                    }

                    num38 = num37;
                }

                num39 = num38;
            }

            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
            {
                num33 = 2.0;
            }
            else
            {
                num33 = 1.0;
            }

            if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                <= Globals.candleSettings[0].factor * num39 / num33)
            {
                goto Label_0592;
            }

            if (Globals.candleSettings[3].avgPeriod != 0.0)
            {
                num32 = bodyDojiPeriodTotal / Globals.candleSettings[3].avgPeriod;
            }
            else
            {
                double num31;
                if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
                {
                    num31 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num30;
                    if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                    {
                        num30 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num27;
                        if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                        {
                            double num28;
                            double num29;
                            if (inClose[i] >= inOpen[i])
                            {
                                num29 = inClose[i];
                            }
                            else
                            {
                                num29 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num28 = inOpen[i];
                            }
                            else
                            {
                                num28 = inClose[i];
                            }

                            num27 = inHigh[i] - num29 + (num28 - inLow[i]);
                        }
                        else
                        {
                            num27 = 0.0;
                        }

                        num30 = num27;
                    }

                    num31 = num30;
                }

                num32 = num31;
            }

            if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
            {
                num26 = 2.0;
            }
            else
            {
                num26 = 1.0;
            }

            if (Math.Abs(inClose[i] - inOpen[i]) > Globals.candleSettings[3].factor * num32 / num26)
            {
                goto Label_0592;
            }

            if (inClose[i - 1] >= inOpen[i - 1])
            {
                double num24;
                double num25;
                if (inOpen[i] < inClose[i])
                {
                    num25 = inOpen[i];
                }
                else
                {
                    num25 = inClose[i];
                }

                if (inOpen[i - 1] > inClose[i - 1])
                {
                    num24 = inOpen[i - 1];
                }
                else
                {
                    num24 = inClose[i - 1];
                }

                if (num25 > num24)
                {
                    goto Label_056D;
                }
            }

            if ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) != -1)
            {
                goto Label_0592;
            }

            if (inOpen[i] > inClose[i])
            {
                num23 = inOpen[i];
            }
            else
            {
                num23 = inClose[i];
            }

            if (inOpen[i - 1] < inClose[i - 1])
            {
                num22 = inOpen[i - 1];
            }
            else
            {
                num22 = inClose[i - 1];
            }

            if (num23 >= num22)
            {
                goto Label_0592;
            }

            Label_056D:
            if (inClose[i - 1] >= inOpen[i - 1])
            {
                num21 = 1;
            }
            else
            {
                num21 = -1;
            }

            outInteger[outIdx] = -num21 * 100;
            outIdx++;
            goto Label_059B;
            Label_0592:
            outInteger[outIdx] = 0;
            outIdx++;
            Label_059B:
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num17;
                        double num18;
                        if (inClose[i - 1] >= inOpen[i - 1])
                        {
                            num18 = inClose[i - 1];
                        }
                        else
                        {
                            num18 = inOpen[i - 1];
                        }

                        if (inClose[i - 1] >= inOpen[i - 1])
                        {
                            num17 = inOpen[i - 1];
                        }
                        else
                        {
                            num17 = inClose[i - 1];
                        }

                        num16 = inHigh[i - 1] - num18 + (num17 - inLow[i - 1]);
                    }
                    else
                    {
                        num16 = 0.0;
                    }

                    num19 = num16;
                }

                num20 = num19;
            }

            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num15 = Math.Abs(inClose[bodyLongTrailingIdx] - inOpen[bodyLongTrailingIdx]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[bodyLongTrailingIdx] - inLow[bodyLongTrailingIdx];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num12;
                        double num13;
                        if (inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx])
                        {
                            num13 = inClose[bodyLongTrailingIdx];
                        }
                        else
                        {
                            num13 = inOpen[bodyLongTrailingIdx];
                        }

                        if (inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx])
                        {
                            num12 = inOpen[bodyLongTrailingIdx];
                        }
                        else
                        {
                            num12 = inClose[bodyLongTrailingIdx];
                        }

                        num11 = inHigh[bodyLongTrailingIdx] - num13 + (num12 - inLow[bodyLongTrailingIdx]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            bodyLongPeriodTotal += num20 - num15;
            if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                    {
                        double num7;
                        double num8;
                        if (inClose[i] >= inOpen[i])
                        {
                            num8 = inClose[i];
                        }
                        else
                        {
                            num8 = inOpen[i];
                        }

                        if (inClose[i] >= inOpen[i])
                        {
                            num7 = inOpen[i];
                        }
                        else
                        {
                            num7 = inClose[i];
                        }

                        num6 = inHigh[i] - num8 + (num7 - inLow[i]);
                    }
                    else
                    {
                        num6 = 0.0;
                    }

                    num9 = num6;
                }

                num10 = num9;
            }

            if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[bodyDojiTrailingIdx] - inOpen[bodyDojiTrailingIdx]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[bodyDojiTrailingIdx] - inLow[bodyDojiTrailingIdx];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[bodyDojiTrailingIdx] >= inOpen[bodyDojiTrailingIdx])
                        {
                            num3 = inClose[bodyDojiTrailingIdx];
                        }
                        else
                        {
                            num3 = inOpen[bodyDojiTrailingIdx];
                        }

                        if (inClose[bodyDojiTrailingIdx] >= inOpen[bodyDojiTrailingIdx])
                        {
                            num2 = inOpen[bodyDojiTrailingIdx];
                        }
                        else
                        {
                            num2 = inClose[bodyDojiTrailingIdx];
                        }

                        num = inHigh[bodyDojiTrailingIdx] - num3 + (num2 - inLow[bodyDojiTrailingIdx]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            bodyDojiPeriodTotal += num10 - num5;
            i++;
            bodyLongTrailingIdx++;
            bodyDojiTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0232;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlDojiStarLookback()
        {
            return (Globals.candleSettings[3].avgPeriod <= Globals.candleSettings[0].avgPeriod
                         ? Globals.candleSettings[0].avgPeriod
                         : Globals.candleSettings[3].avgPeriod) + 1;
        }
    }
}
