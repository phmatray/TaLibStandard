using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlLongLeggedDoji(
            int startIdx,
            int endIdx,
            in double[] inOpen,
            in double[] inHigh,
            in double[] inLow,
            in double[] inClose,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            double num5;
            double num10;
            double num15;
            double num20;
            double num37;
            double num43;
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

            int lookbackTotal = CdlLongLeggedDojiLookback();
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

            double bodyDojiPeriodTotal = 0.0;
            int bodyDojiTrailingIdx = startIdx - Globals.candleSettings[3].avgPeriod;
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - Globals.candleSettings[4].avgPeriod;
            int i = bodyDojiTrailingIdx;
            while (true)
            {
                double num53;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
                {
                    num53 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num52;
                    if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                    {
                        num52 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num49;
                        if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                        {
                            double num50;
                            double num51;
                            if (inClose[i] >= inOpen[i])
                            {
                                num51 = inClose[i];
                            }
                            else
                            {
                                num51 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num50 = inOpen[i];
                            }
                            else
                            {
                                num50 = inClose[i];
                            }

                            num49 = inHigh[i] - num51 + (num50 - inLow[i]);
                        }
                        else
                        {
                            num49 = 0.0;
                        }

                        num52 = num49;
                    }

                    num53 = num52;
                }

                bodyDojiPeriodTotal += num53;
                i++;
            }

            i = shadowLongTrailingIdx;
            while (true)
            {
                double num48;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                {
                    num48 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num47;
                    if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                    {
                        num47 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num44;
                        if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                        {
                            double num45;
                            double num46;
                            if (inClose[i] >= inOpen[i])
                            {
                                num46 = inClose[i];
                            }
                            else
                            {
                                num46 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num45 = inOpen[i];
                            }
                            else
                            {
                                num45 = inClose[i];
                            }

                            num44 = inHigh[i] - num46 + (num45 - inLow[i]);
                        }
                        else
                        {
                            num44 = 0.0;
                        }

                        num47 = num44;
                    }

                    num48 = num47;
                }

                shadowLongPeriodTotal += num48;
                i++;
            }

            int outIdx = 0;
            Label_022E:
            if (Globals.candleSettings[3].avgPeriod != 0.0)
            {
                num43 = bodyDojiPeriodTotal / Globals.candleSettings[3].avgPeriod;
            }
            else
            {
                double num42;
                if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
                {
                    num42 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num41;
                    if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                    {
                        num41 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num38;
                        if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                        {
                            double num39;
                            double num40;
                            if (inClose[i] >= inOpen[i])
                            {
                                num40 = inClose[i];
                            }
                            else
                            {
                                num40 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num39 = inOpen[i];
                            }
                            else
                            {
                                num39 = inClose[i];
                            }

                            num38 = inHigh[i] - num40 + (num39 - inLow[i]);
                        }
                        else
                        {
                            num38 = 0.0;
                        }

                        num41 = num38;
                    }

                    num42 = num41;
                }

                num43 = num42;
            }

            if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
            {
                num37 = 2.0;
            }
            else
            {
                num37 = 1.0;
            }

            if (Math.Abs(inClose[i] - inOpen[i]) <= Globals.candleSettings[3].factor * num43 / num37)
            {
                double num29;
                double num35;
                double num36;
                if (inClose[i] >= inOpen[i])
                {
                    num36 = inOpen[i];
                }
                else
                {
                    num36 = inClose[i];
                }

                if (Globals.candleSettings[4].avgPeriod != 0.0)
                {
                    num35 = shadowLongPeriodTotal / Globals.candleSettings[4].avgPeriod;
                }
                else
                {
                    double num34;
                    if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                    {
                        num34 = Math.Abs(inClose[i] - inOpen[i]);
                    }
                    else
                    {
                        double num33;
                        if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                        {
                            num33 = inHigh[i] - inLow[i];
                        }
                        else
                        {
                            double num30;
                            if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                            {
                                double num31;
                                double num32;
                                if (inClose[i] >= inOpen[i])
                                {
                                    num32 = inClose[i];
                                }
                                else
                                {
                                    num32 = inOpen[i];
                                }

                                if (inClose[i] >= inOpen[i])
                                {
                                    num31 = inOpen[i];
                                }
                                else
                                {
                                    num31 = inClose[i];
                                }

                                num30 = inHigh[i] - num32 + (num31 - inLow[i]);
                            }
                            else
                            {
                                num30 = 0.0;
                            }

                            num33 = num30;
                        }

                        num34 = num33;
                    }

                    num35 = num34;
                }

                if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                {
                    num29 = 2.0;
                }
                else
                {
                    num29 = 1.0;
                }

                if (num36 - inLow[i] <= Globals.candleSettings[4].factor * num35 / num29)
                {
                    double num21;
                    double num27;
                    double num28;
                    if (inClose[i] >= inOpen[i])
                    {
                        num28 = inClose[i];
                    }
                    else
                    {
                        num28 = inOpen[i];
                    }

                    if (Globals.candleSettings[4].avgPeriod != 0.0)
                    {
                        num27 = shadowLongPeriodTotal / Globals.candleSettings[4].avgPeriod;
                    }
                    else
                    {
                        double num26;
                        if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                        {
                            num26 = Math.Abs(inClose[i] - inOpen[i]);
                        }
                        else
                        {
                            double num25;
                            if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                            {
                                num25 = inHigh[i] - inLow[i];
                            }
                            else
                            {
                                double num22;
                                if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                                {
                                    double num23;
                                    double num24;
                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num24 = inClose[i];
                                    }
                                    else
                                    {
                                        num24 = inOpen[i];
                                    }

                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num23 = inOpen[i];
                                    }
                                    else
                                    {
                                        num23 = inClose[i];
                                    }

                                    num22 = inHigh[i] - num24 + (num23 - inLow[i]);
                                }
                                else
                                {
                                    num22 = 0.0;
                                }

                                num25 = num22;
                            }

                            num26 = num25;
                        }

                        num27 = num26;
                    }

                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                    {
                        num21 = 2.0;
                    }
                    else
                    {
                        num21 = 1.0;
                    }

                    if (inHigh[i] - num28 <= Globals.candleSettings[4].factor * num27 / num21)
                    {
                        goto Label_0610;
                    }
                }

                outInteger[outIdx] = 100;
                outIdx++;
                goto Label_0619;
            }

            Label_0610:
            outInteger[outIdx] = 0;
            outIdx++;
            Label_0619:
            if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                    {
                        double num17;
                        double num18;
                        if (inClose[i] >= inOpen[i])
                        {
                            num18 = inClose[i];
                        }
                        else
                        {
                            num18 = inOpen[i];
                        }

                        if (inClose[i] >= inOpen[i])
                        {
                            num17 = inOpen[i];
                        }
                        else
                        {
                            num17 = inClose[i];
                        }

                        num16 = inHigh[i] - num18 + (num17 - inLow[i]);
                    }
                    else
                    {
                        num16 = 0.0;
                    }

                    num19 = num16;
                }

                num20 = num19;
            }

            if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
            {
                num15 = Math.Abs(inClose[bodyDojiTrailingIdx] - inOpen[bodyDojiTrailingIdx]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[bodyDojiTrailingIdx] - inLow[bodyDojiTrailingIdx];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                    {
                        double num12;
                        double num13;
                        if (inClose[bodyDojiTrailingIdx] >= inOpen[bodyDojiTrailingIdx])
                        {
                            num13 = inClose[bodyDojiTrailingIdx];
                        }
                        else
                        {
                            num13 = inOpen[bodyDojiTrailingIdx];
                        }

                        if (inClose[bodyDojiTrailingIdx] >= inOpen[bodyDojiTrailingIdx])
                        {
                            num12 = inOpen[bodyDojiTrailingIdx];
                        }
                        else
                        {
                            num12 = inClose[bodyDojiTrailingIdx];
                        }

                        num11 = inHigh[bodyDojiTrailingIdx] - num13 + (num12 - inLow[bodyDojiTrailingIdx]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            bodyDojiPeriodTotal += num20 - num15;
            if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[shadowLongTrailingIdx] - inOpen[shadowLongTrailingIdx]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[shadowLongTrailingIdx] - inLow[shadowLongTrailingIdx];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[shadowLongTrailingIdx] >= inOpen[shadowLongTrailingIdx])
                        {
                            num3 = inClose[shadowLongTrailingIdx];
                        }
                        else
                        {
                            num3 = inOpen[shadowLongTrailingIdx];
                        }

                        if (inClose[shadowLongTrailingIdx] >= inOpen[shadowLongTrailingIdx])
                        {
                            num2 = inOpen[shadowLongTrailingIdx];
                        }
                        else
                        {
                            num2 = inClose[shadowLongTrailingIdx];
                        }

                        num = inHigh[shadowLongTrailingIdx] - num3 + (num2 - inLow[shadowLongTrailingIdx]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            shadowLongPeriodTotal += num10 - num5;
            i++;
            bodyDojiTrailingIdx++;
            shadowLongTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_022E;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlLongLeggedDojiLookback()
        {
            return Globals.candleSettings[3].avgPeriod <= Globals.candleSettings[4].avgPeriod
                        ? Globals.candleSettings[4].avgPeriod
                        : Globals.candleSettings[3].avgPeriod;
        }
    }
}
