namespace TechnicalAnalysis
{
    using System;

    internal partial class TACore
    {
        public static RetCode Cdl3Inside(
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

            int lookbackTotal = Cdl3InsideLookback();
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
            double bodyShortPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 2 - Globals.candleSettings[0].avgPeriod;
            int bodyShortTrailingIdx = startIdx - 1 - Globals.candleSettings[2].avgPeriod;
            int i = bodyLongTrailingIdx;
            while (true)
            {
                double num49;
                if (i >= startIdx - 2)
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
                            double num47 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num46 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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

            i = bodyShortTrailingIdx;
            while (true)
            {
                double num44;
                if (i >= startIdx - 1)
                {
                    break;
                }

                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                {
                    num44 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num43;
                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                    {
                        num43 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num40;
                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                        {
                            double num42 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num41 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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

                bodyShortPeriodTotal += num44;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_0238:
            if (Globals.candleSettings[0].avgPeriod != 0.0)
            {
                num39 = bodyLongPeriodTotal / Globals.candleSettings[0].avgPeriod;
            }
            else
            {
                double num38;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num38 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num37;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num37 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num34;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num36 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num35 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num34 = inHigh[i - 2] - num36 + (num35 - inLow[i - 2]);
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

            double num33 = Globals.candleSettings[0].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                > Globals.candleSettings[0].factor * num39 / num33)
            {
                double num32;
                if (Globals.candleSettings[2].avgPeriod != 0.0)
                {
                    num32 = bodyShortPeriodTotal / Globals.candleSettings[2].avgPeriod;
                }
                else
                {
                    double num31;
                    if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                    {
                        num31 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num30;
                        if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                        {
                            num30 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num27;
                            if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                            {
                                double num29 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                double num28 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                num27 = inHigh[i - 1] - num29 + (num28 - inLow[i - 1]);
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

                double num26 = Globals.candleSettings[2].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    <= Globals.candleSettings[2].factor * num32 / num26)
                {
                    double num25 = inClose[i - 1] > inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                    double num24 = inClose[i - 2] > inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];

                    if (num25 < num24)
                    {
                        double num23 = inClose[i - 1] < inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                        double num22 = inClose[i - 2] < inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];

                        if (num23 > num22
                            && (inClose[i - 2] >= inOpen[i - 2] && (inClose[i] < inOpen[i] ? -1 : 1) == -1
                                                                && inClose[i] < inOpen[i - 2]
                                || (inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == -1 && inClose[i] >= inOpen[i]
                                && inClose[i] > inOpen[i - 2]))
                        {
                            int num21;
                            if (inClose[i - 2] >= inOpen[i - 2])
                            {
                                num21 = 1;
                            }
                            else
                            {
                                num21 = -1;
                            }

                            outInteger[outIdx] = -num21 * 100;
                            outIdx++;
                            goto Label_0610;
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0610:
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num18 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                        double num17 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                        num16 = inHigh[i - 2] - num18 + (num17 - inLow[i - 2]);
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
                        double num13 = inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx] ? inClose[bodyLongTrailingIdx] : inOpen[bodyLongTrailingIdx];
                        double num12 = inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx] ? inOpen[bodyLongTrailingIdx] : inClose[bodyLongTrailingIdx];
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
            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        double num8 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                        double num7 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
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

            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[bodyShortTrailingIdx] - inOpen[bodyShortTrailingIdx]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[bodyShortTrailingIdx] - inLow[bodyShortTrailingIdx];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        double num3 = inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx] ? inClose[bodyShortTrailingIdx] : inOpen[bodyShortTrailingIdx];
                        double num2 = inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx] ? inOpen[bodyShortTrailingIdx] : inClose[bodyShortTrailingIdx];
                        num = inHigh[bodyShortTrailingIdx] - num3 + (num2 - inLow[bodyShortTrailingIdx]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            bodyShortPeriodTotal += num10 - num5;
            i++;
            bodyLongTrailingIdx++;
            bodyShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0238;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static RetCode Cdl3Inside(
            int startIdx,
            int endIdx,
            float[] inOpen,
            float[] inHigh,
            float[] inLow,
            float[] inClose,
            ref int outBegIdx,
            ref int outNBElement,
            int[] outInteger)
        {
            float num5;
            float num10;
            float num15;
            float num20;
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

            int lookbackTotal = Cdl3InsideLookback();
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
            double bodyShortPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 2 - Globals.candleSettings[0].avgPeriod;
            int bodyShortTrailingIdx = startIdx - 1 - Globals.candleSettings[2].avgPeriod;
            int i = bodyLongTrailingIdx;
            while (true)
            {
                float num49;
                if (i >= startIdx - 2)
                {
                    break;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num49 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    float num48;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num48 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        float num45;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            float num47 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            float num46 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num45 = inHigh[i] - num47 + (num46 - inLow[i]);
                        }
                        else
                        {
                            num45 = 0.0f;
                        }

                        num48 = num45;
                    }

                    num49 = num48;
                }

                bodyLongPeriodTotal += num49;
                i++;
            }

            i = bodyShortTrailingIdx;
            while (true)
            {
                float num44;
                if (i >= startIdx - 1)
                {
                    break;
                }

                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                {
                    num44 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    float num43;
                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                    {
                        num43 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        float num40;
                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                        {
                            float num42 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            float num41 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num40 = inHigh[i] - num42 + (num41 - inLow[i]);
                        }
                        else
                        {
                            num40 = 0.0f;
                        }

                        num43 = num40;
                    }

                    num44 = num43;
                }

                bodyShortPeriodTotal += num44;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_0254:
            if (Globals.candleSettings[0].avgPeriod != 0.0)
            {
                num39 = bodyLongPeriodTotal / Globals.candleSettings[0].avgPeriod;
            }
            else
            {
                float num38;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num38 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    float num37;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num37 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        float num34;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            float num36 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            float num35 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num34 = inHigh[i - 2] - num36 + (num35 - inLow[i - 2]);
                        }
                        else
                        {
                            num34 = 0.0f;
                        }

                        num37 = num34;
                    }

                    num38 = num37;
                }

                num39 = num38;
            }

            double num33 = Globals.candleSettings[0].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                > Globals.candleSettings[0].factor * num39 / num33)
            {
                double num32;
                if (Globals.candleSettings[2].avgPeriod != 0.0)
                {
                    num32 = bodyShortPeriodTotal / Globals.candleSettings[2].avgPeriod;
                }
                else
                {
                    float num31;
                    if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                    {
                        num31 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        float num30;
                        if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                        {
                            num30 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            float num27;
                            if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                            {
                                float num29 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                float num28 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                num27 = inHigh[i - 1] - num29 + (num28 - inLow[i - 1]);
                            }
                            else
                            {
                                num27 = 0.0f;
                            }

                            num30 = num27;
                        }

                        num31 = num30;
                    }

                    num32 = num31;
                }

                double num26 = Globals.candleSettings[2].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    <= Globals.candleSettings[2].factor * num32 / num26)
                {
                    float num25 = inClose[i - 1] > inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                    float num24 = inClose[i - 2] > inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];

                    if (num25 < num24)
                    {
                        float num23 = inClose[i - 1] < inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                        float num22 = inClose[i - 2] < inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];

                        if (num23 > num22
                            && (inClose[i - 2] >= inOpen[i - 2] && (inClose[i] < inOpen[i] ? -1 : 1) == -1
                                                                && inClose[i] < inOpen[i - 2]
                                || (inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == -1 && inClose[i] >= inOpen[i]
                                && inClose[i] > inOpen[i - 2]))
                        {
                            int num21;
                            if (inClose[i - 2] >= inOpen[i - 2])
                            {
                                num21 = 1;
                            }
                            else
                            {
                                num21 = -1;
                            }

                            outInteger[outIdx] = -num21 * 100;
                            outIdx++;
                            goto Label_0672;
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0672:
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                float num19;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    float num16;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        float num18 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                        float num17 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                        num16 = inHigh[i - 2] - num18 + (num17 - inLow[i - 2]);
                    }
                    else
                    {
                        num16 = 0.0f;
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
                float num14;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[bodyLongTrailingIdx] - inLow[bodyLongTrailingIdx];
                }
                else
                {
                    float num11;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        float num13 = inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx] ? inClose[bodyLongTrailingIdx] : inOpen[bodyLongTrailingIdx];
                        float num12 = inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx] ? inOpen[bodyLongTrailingIdx] : inClose[bodyLongTrailingIdx];
                        num11 = inHigh[bodyLongTrailingIdx] - num13 + (num12 - inLow[bodyLongTrailingIdx]);
                    }
                    else
                    {
                        num11 = 0.0f;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            bodyLongPeriodTotal += num20 - num15;
            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                float num9;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    float num6;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        float num8 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                        float num7 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                        num6 = inHigh[i - 1] - num8 + (num7 - inLow[i - 1]);
                    }
                    else
                    {
                        num6 = 0.0f;
                    }

                    num9 = num6;
                }

                num10 = num9;
            }

            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[bodyShortTrailingIdx] - inOpen[bodyShortTrailingIdx]);
            }
            else
            {
                float num4;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[bodyShortTrailingIdx] - inLow[bodyShortTrailingIdx];
                }
                else
                {
                    float num;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        float num3 = inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx] ? inClose[bodyShortTrailingIdx] : inOpen[bodyShortTrailingIdx];
                        float num2 = inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx] ? inOpen[bodyShortTrailingIdx] : inClose[bodyShortTrailingIdx];
                        num = inHigh[bodyShortTrailingIdx] - num3 + (num2 - inLow[bodyShortTrailingIdx]);
                    }
                    else
                    {
                        num = 0.0f;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            bodyShortPeriodTotal += num10 - num5;
            i++;
            bodyLongTrailingIdx++;
            bodyShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0254;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int Cdl3InsideLookback()
        {
            return (Globals.candleSettings[2].avgPeriod <= Globals.candleSettings[0].avgPeriod
                ? Globals.candleSettings[0].avgPeriod
                : Globals.candleSettings[2].avgPeriod) + 2;
        }
    }
}
