using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlHikkakeMod(
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
            int outIdx;
            double num5;
            double num10;
            double num18;
            double num30;
            double num35;
            double num42;
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

            int lookbackTotal = CdlHikkakeModLookback();
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
            int nearTrailingIdx = startIdx - 3 - Globals.candleSettings[8].avgPeriod;
            int i = nearTrailingIdx;
            while (true)
            {
                double num54;
                if (i >= startIdx - 3)
                {
                    break;
                }

                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num54 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num53;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num53 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num50;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num52 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num51 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num50 = inHigh[i - 2] - num52 + (num51 - inLow[i - 2]);
                        }
                        else
                        {
                            num50 = 0.0;
                        }

                        num53 = num50;
                    }

                    num54 = num53;
                }

                nearPeriodTotal += num54;
                i++;
            }

            int patternIdx = 0;
            int pattern = 0;
            i = startIdx - 3;
            Label_0174:
            if (i >= startIdx)
            {
                i = startIdx;
                outIdx = 0;
                goto Label_069A;
            }

            if (inHigh[i - 2] >= inHigh[i - 3] || inLow[i - 2] <= inLow[i - 3] || inHigh[i - 1] >= inHigh[i - 2] || inLow[i - 1] <= inLow[i - 2])
            {
                goto Label_04C0;
            }

            if (inHigh[i] < inHigh[i - 1] && inLow[i] < inLow[i - 1])
            {
                double num49;
                if (Globals.candleSettings[8].avgPeriod != 0.0)
                {
                    num49 = nearPeriodTotal / Globals.candleSettings[8].avgPeriod;
                }
                else
                {
                    double num48;
                    if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                    {
                        num48 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num47;
                        if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                        {
                            num47 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num44;
                            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                            {
                                double num46 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                double num45 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                num44 = inHigh[i - 2] - num46 + (num45 - inLow[i - 2]);
                            }
                            else
                            {
                                num44 = 0.0;
                            }

                            num47 = num44;
                        }

                        num48 = num47;
                    }

                    num49 = num48;
                }

                double num43 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (inClose[i - 2] <= inLow[i - 2] + Globals.candleSettings[8].factor * num49 / num43)
                {
                    goto Label_04A9;
                }
            }

            if (inHigh[i] <= inHigh[i - 1] || inLow[i] <= inLow[i - 1])
            {
                goto Label_04C0;
            }

            if (Globals.candleSettings[8].avgPeriod != 0.0)
            {
                num42 = nearPeriodTotal / Globals.candleSettings[8].avgPeriod;
            }
            else
            {
                double num41;
                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num41 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num40;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num40 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num37;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num39 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num38 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num37 = inHigh[i - 2] - num39 + (num38 - inLow[i - 2]);
                        }
                        else
                        {
                            num37 = 0.0;
                        }

                        num40 = num37;
                    }

                    num41 = num40;
                }

                num42 = num41;
            }

            double num36 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (inClose[i - 2] < inHigh[i - 2] - Globals.candleSettings[8].factor * num42 / num36)
            {
                goto Label_04C0;
            }

            Label_04A9:
            pattern = (inHigh[i] >= inHigh[i - 1] ? -1 : 1) * 100;
            patternIdx = i;
            goto Label_04E9;
            Label_04C0:
            if (i <= patternIdx + 3 && (pattern > 0 && inClose[i] > inHigh[patternIdx - 1]
                                        || pattern < 0 && inClose[i] < inLow[patternIdx - 1]))
            {
                patternIdx = 0;
            }

            Label_04E9:
            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num35 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num34;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num34 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num31;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        double num33 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                        double num32 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                        num31 = inHigh[i - 2] - num33 + (num32 - inLow[i - 2]);
                    }
                    else
                    {
                        num31 = 0.0;
                    }

                    num34 = num31;
                }

                num35 = num34;
            }

            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num30 = Math.Abs(inClose[nearTrailingIdx - 2] - inOpen[nearTrailingIdx - 2]);
            }
            else
            {
                double num29;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num29 = inHigh[nearTrailingIdx - 2] - inLow[nearTrailingIdx - 2];
                }
                else
                {
                    double num26;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        double num28 = inClose[nearTrailingIdx - 2] >= inOpen[nearTrailingIdx - 2] ? inClose[nearTrailingIdx - 2] : inOpen[nearTrailingIdx - 2];
                        double num27 = inClose[nearTrailingIdx - 2] >= inOpen[nearTrailingIdx - 2] ? inOpen[nearTrailingIdx - 2] : inClose[nearTrailingIdx - 2];
                        num26 = inHigh[nearTrailingIdx - 2] - num28 + (num27 - inLow[nearTrailingIdx - 2]);
                    }
                    else
                    {
                        num26 = 0.0;
                    }

                    num29 = num26;
                }

                num30 = num29;
            }

            nearPeriodTotal += num35 - num30;
            nearTrailingIdx++;
            i++;
            goto Label_0174;
            Label_069A:
            if (inHigh[i - 2] >= inHigh[i - 3] || inLow[i - 2] <= inLow[i - 3] || inHigh[i - 1] >= inHigh[i - 2] || inLow[i - 1] <= inLow[i - 2])
            {
                goto Label_09E9;
            }

            if (inHigh[i] < inHigh[i - 1] && inLow[i] < inLow[i - 1])
            {
                double num25;
                if (Globals.candleSettings[8].avgPeriod != 0.0)
                {
                    num25 = nearPeriodTotal / Globals.candleSettings[8].avgPeriod;
                }
                else
                {
                    double num24;
                    if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                    {
                        num24 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num23;
                        if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                        {
                            num23 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num20;
                            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                            {
                                double num22 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                double num21 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                num20 = inHigh[i - 2] - num22 + (num21 - inLow[i - 2]);
                            }
                            else
                            {
                                num20 = 0.0;
                            }

                            num23 = num20;
                        }

                        num24 = num23;
                    }

                    num25 = num24;
                }

                double num19 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (inClose[i - 2] <= inLow[i - 2] + Globals.candleSettings[8].factor * num25 / num19)
                {
                    goto Label_09C8;
                }
            }

            if (inHigh[i] <= inHigh[i - 1] || inLow[i] <= inLow[i - 1])
            {
                goto Label_09E9;
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
                    num17 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num16 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num13;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num15 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num14 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num13 = inHigh[i - 2] - num15 + (num14 - inLow[i - 2]);
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

            double num12 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (inClose[i - 2] < inHigh[i - 2] - Globals.candleSettings[8].factor * num18 / num12)
            {
                goto Label_09E9;
            }

            Label_09C8:
            pattern = (inHigh[i] >= inHigh[i - 1] ? -1 : 1) * 100;
            patternIdx = i;
            outInteger[outIdx] = pattern;
            outIdx++;
            goto Label_0A3A;
            Label_09E9:
            if (i <= patternIdx + 3 && (pattern > 0 && inClose[i] > inHigh[patternIdx - 1]
                                        || pattern < 0 && inClose[i] < inLow[patternIdx - 1]))
            {
                int num11;
                if (pattern > 0)
                {
                    num11 = 1;
                }
                else
                {
                    num11 = -1;
                }

                outInteger[outIdx] = pattern + num11 * 100;
                outIdx++;
                patternIdx = 0;
            }
            else
            {
                outInteger[outIdx] = 0;
                outIdx++;
            }

            Label_0A3A:
            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[nearTrailingIdx - 2] - inOpen[nearTrailingIdx - 2]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[nearTrailingIdx - 2] - inLow[nearTrailingIdx - 2];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        double num3 = inClose[nearTrailingIdx - 2] >= inOpen[nearTrailingIdx - 2] ? inClose[nearTrailingIdx - 2] : inOpen[nearTrailingIdx - 2];
                        double num2 = inClose[nearTrailingIdx - 2] >= inOpen[nearTrailingIdx - 2] ? inOpen[nearTrailingIdx - 2] : inClose[nearTrailingIdx - 2];
                        num = inHigh[nearTrailingIdx - 2] - num3 + (num2 - inLow[nearTrailingIdx - 2]);
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
            nearTrailingIdx++;
            i++;
            if (i <= endIdx)
            {
                goto Label_069A;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlHikkakeModLookback()
        {
            return (1 <= Globals.candleSettings[8].avgPeriod ? Globals.candleSettings[8].avgPeriod : 1) + 5;
        }
    }
}
