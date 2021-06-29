namespace TechnicalAnalysis
{
    using System;

    internal partial class TACore
    {
        public static RetCode CdlTasukiGap(
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
            int num11;
            double num12;
            double num18;
            double num19;
            double num20;
            double num21;
            double num30;
            double num31;
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

            int lookbackTotal = CdlTasukiGapLookback();
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

            double nearPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - Globals.candleSettings[8].avgPeriod;
            int i = nearTrailingIdx;
            while (true)
            {
                double num36;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num36 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num35;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num35 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num32;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num33;
                            double num34;
                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num34 = inClose[i - 1];
                            }
                            else
                            {
                                num34 = inOpen[i - 1];
                            }

                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num33 = inOpen[i - 1];
                            }
                            else
                            {
                                num33 = inClose[i - 1];
                            }

                            num32 = inHigh[i - 1] - num34 + (num33 - inLow[i - 1]);
                        }
                        else
                        {
                            num32 = 0.0;
                        }

                        num35 = num32;
                    }

                    num36 = num35;
                }

                nearPeriodTotal += num36;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_0168:
            if (inOpen[i - 1] < inClose[i - 1])
            {
                num31 = inOpen[i - 1];
            }
            else
            {
                num31 = inClose[i - 1];
            }

            if (inOpen[i - 2] > inClose[i - 2])
            {
                num30 = inOpen[i - 2];
            }
            else
            {
                num30 = inClose[i - 2];
            }

            if (num31 > num30 && inClose[i - 1] >= inOpen[i - 1] && (inClose[i] < inOpen[i] ? -1 : 1) == -1 && inOpen[i] < inClose[i - 1] && inOpen[i] > inOpen[i - 1] && inClose[i] < inOpen[i - 1])
            {
                double num29;
                if (inClose[i - 2] > inOpen[i - 2])
                {
                    num29 = inClose[i - 2];
                }
                else
                {
                    num29 = inOpen[i - 2];
                }

                if (inClose[i] > num29)
                {
                    double num22;
                    double num28;
                    if (Globals.candleSettings[8].avgPeriod != 0.0)
                    {
                        num28 = nearPeriodTotal / Globals.candleSettings[8].avgPeriod;
                    }
                    else
                    {
                        double num27;
                        if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                        {
                            num27 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num26;
                            if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                            {
                                num26 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num23;
                                if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                {
                                    double num24;
                                    double num25;
                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num25 = inClose[i - 1];
                                    }
                                    else
                                    {
                                        num25 = inOpen[i - 1];
                                    }

                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num24 = inOpen[i - 1];
                                    }
                                    else
                                    {
                                        num24 = inClose[i - 1];
                                    }

                                    num23 = inHigh[i - 1] - num25 + (num24 - inLow[i - 1]);
                                }
                                else
                                {
                                    num23 = 0.0;
                                }

                                num26 = num23;
                            }

                            num27 = num26;
                        }

                        num28 = num27;
                    }

                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        num22 = 2.0;
                    }
                    else
                    {
                        num22 = 1.0;
                    }

                    if (Math.Abs(
                            Math.Abs(inClose[i - 1] - inOpen[i - 1])
                            - Math.Abs(inClose[i] - inOpen[i]))
                        < Globals.candleSettings[8].factor * num28 / num22)
                    {
                        goto Label_05CD;
                    }
                }
            }

            if (inOpen[i - 1] > inClose[i - 1])
            {
                num21 = inOpen[i - 1];
            }
            else
            {
                num21 = inClose[i - 1];
            }

            if (inOpen[i - 2] < inClose[i - 2])
            {
                num20 = inOpen[i - 2];
            }
            else
            {
                num20 = inClose[i - 2];
            }

            if (num21 >= num20 || (inClose[i - 1] < inOpen[i - 1] ? -1 : 1) != -1 || inClose[i] < inOpen[i] || inOpen[i] >= inOpen[i - 1] || inOpen[i] <= inClose[i - 1] || inClose[i] <= inOpen[i - 1])
            {
                goto Label_05F1;
            }

            if (inClose[i - 2] < inOpen[i - 2])
            {
                num19 = inClose[i - 2];
            }
            else
            {
                num19 = inOpen[i - 2];
            }

            if (inClose[i] >= num19)
            {
                goto Label_05F1;
            }

            if (Globals.candleSettings[8].avgPeriod != 0.0)
            {
                num18 = nearPeriodTotal / Globals.candleSettings[8].avgPeriod;
            }
            else
            {
                double num17;
                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num17 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num16 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num13;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num14;
                            double num15;
                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num15 = inClose[i - 1];
                            }
                            else
                            {
                                num15 = inOpen[i - 1];
                            }

                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num14 = inOpen[i - 1];
                            }
                            else
                            {
                                num14 = inClose[i - 1];
                            }

                            num13 = inHigh[i - 1] - num15 + (num14 - inLow[i - 1]);
                        }
                        else
                        {
                            num13 = 0.0;
                        }

                        num16 = num13;
                    }

                    num17 = num16;
                }

                num18 = num17;
            }

            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
            {
                num12 = 2.0;
            }
            else
            {
                num12 = 1.0;
            }

            if (Math.Abs(
                    Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    - Math.Abs(inClose[i] - inOpen[i]))
                >= Globals.candleSettings[8].factor * num18 / num12)
            {
                goto Label_05F1;
            }

            Label_05CD:
            if (inClose[i - 1] >= inOpen[i - 1])
            {
                num11 = 1;
            }
            else
            {
                num11 = -1;
            }

            outInteger[outIdx] = num11 * 100;
            outIdx++;
            goto Label_05FA;
            Label_05F1:
            outInteger[outIdx] = 0;
            outIdx++;
            Label_05FA:
            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        double num7;
                        double num8;
                        if (inClose[i - 1] >= inOpen[i - 1])
                        {
                            num8 = inClose[i - 1];
                        }
                        else
                        {
                            num8 = inOpen[i - 1];
                        }

                        if (inClose[i - 1] >= inOpen[i - 1])
                        {
                            num7 = inOpen[i - 1];
                        }
                        else
                        {
                            num7 = inClose[i - 1];
                        }

                        num6 = inHigh[i - 1] - num8 + (num7 - inLow[i - 1]);
                    }
                    else
                    {
                        num6 = 0.0;
                    }

                    num9 = num6;
                }

                num10 = num9;
            }

            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[nearTrailingIdx - 1] - inOpen[nearTrailingIdx - 1]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[nearTrailingIdx - 1] - inLow[nearTrailingIdx - 1];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[nearTrailingIdx - 1] >= inOpen[nearTrailingIdx - 1])
                        {
                            num3 = inClose[nearTrailingIdx - 1];
                        }
                        else
                        {
                            num3 = inOpen[nearTrailingIdx - 1];
                        }

                        if (inClose[nearTrailingIdx - 1] >= inOpen[nearTrailingIdx - 1])
                        {
                            num2 = inOpen[nearTrailingIdx - 1];
                        }
                        else
                        {
                            num2 = inClose[nearTrailingIdx - 1];
                        }

                        num = inHigh[nearTrailingIdx - 1] - num3 + (num2 - inLow[nearTrailingIdx - 1]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            nearPeriodTotal += num10 - num5;
            i++;
            nearTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0168;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlTasukiGapLookback()
        {
            return Globals.candleSettings[8].avgPeriod + 2;
        }
    }
}
