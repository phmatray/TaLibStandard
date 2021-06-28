namespace TechnicalAnalysis
{
    using System;

    internal partial class TACore
    {
        public static RetCode Cdl3BlackCrows(
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
            double[] shadowVeryShortPeriodTotal = new double[3];
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

            int lookbackTotal = Cdl3BlackCrowsLookback();
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

            shadowVeryShortPeriodTotal[2] = 0.0;
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - Globals.candleSettings[7].avgPeriod;
            int i = shadowVeryShortTrailingIdx;
            while (true)
            {
                double num39;
                double num44;
                double num49;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num49 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num48;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num48 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num45;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num47 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num46 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num45 = inHigh[i - 2] - num47 + (num46 - inLow[i - 2]);
                        }
                        else
                        {
                            num45 = 0.0;
                        }

                        num48 = num45;
                    }

                    num49 = num48;
                }

                shadowVeryShortPeriodTotal[2] += num49;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num44 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num43;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num43 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num40;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num42 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                            double num41 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                            num40 = inHigh[i - 1] - num42 + (num41 - inLow[i - 1]);
                        }
                        else
                        {
                            num40 = 0.0;
                        }

                        num43 = num40;
                    }

                    num44 = num43;
                }

                shadowVeryShortPeriodTotal[1] += num44;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num39 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num38;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num38 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num35;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num37 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num36 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num35 = inHigh[i] - num37 + (num36 - inLow[i]);
                        }
                        else
                        {
                            num35 = 0.0;
                        }

                        num38 = num35;
                    }

                    num39 = num38;
                }

                shadowVeryShortPeriodTotal[0] += num39;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_0317:
            if (inClose[i - 3] >= inOpen[i - 3] && (inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == -1)
            {
                double num33;
                double num34 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];

                if (Globals.candleSettings[7].avgPeriod != 0.0)
                {
                    num33 = shadowVeryShortPeriodTotal[2] / Globals.candleSettings[7].avgPeriod;
                }
                else
                {
                    double num32;
                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                    {
                        num32 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num31;
                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                        {
                            num31 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num28;
                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                            {
                                double num30 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                double num29 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                num28 = inHigh[i - 2] - num30 + (num29 - inLow[i - 2]);
                            }
                            else
                            {
                                num28 = 0.0;
                            }

                            num31 = num28;
                        }

                        num32 = num31;
                    }

                    num33 = num32;
                }

                double num27 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (num34 - inLow[i - 2] < Globals.candleSettings[7].factor * num33 / num27
                    && (inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1)
                {
                    double num25;
                    double num26 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];

                    if (Globals.candleSettings[7].avgPeriod != 0.0)
                    {
                        num25 = shadowVeryShortPeriodTotal[1] / Globals.candleSettings[7].avgPeriod;
                    }
                    else
                    {
                        double num24;
                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                        {
                            num24 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num23;
                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                            {
                                num23 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num20;
                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    double num22 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                    double num21 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                    num20 = inHigh[i - 1] - num22 + (num21 - inLow[i - 1]);
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

                    double num19 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                    if (num26 - inLow[i - 1] < Globals.candleSettings[7].factor * num25 / num19
                        && (inClose[i] < inOpen[i] ? -1 : 1) == -1)
                    {
                        double num17;
                        double num18 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];

                        if (Globals.candleSettings[7].avgPeriod != 0.0)
                        {
                            num17 = shadowVeryShortPeriodTotal[0] / Globals.candleSettings[7].avgPeriod;
                        }
                        else
                        {
                            double num16;
                            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                            {
                                num16 = Math.Abs(inClose[i] - inOpen[i]);
                            }
                            else
                            {
                                double num15;
                                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                {
                                    num15 = inHigh[i] - inLow[i];
                                }
                                else
                                {
                                    double num12;
                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        double num14 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                        double num13 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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

                        double num11 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                        if (num18 - inLow[i] < Globals.candleSettings[7].factor * num17 / num11
                            && inOpen[i - 1] < inOpen[i - 2] && inOpen[i - 1] > inClose[i - 2] &&
                            inOpen[i] < inOpen[i - 1] && inOpen[i] > inClose[i - 1] && inHigh[i - 3] > inClose[i - 2] &&
                            inClose[i - 2] > inClose[i - 1] && inClose[i - 1] > inClose[i])
                        {
                            outInteger[outIdx] = -100;
                            outIdx++;
                            goto Label_081B;
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_081B:
            int totIdx = 2;
            while (totIdx >= 0)
            {
                double num5;
                double num10;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num10 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num9;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num9 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num6;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num8 = inClose[i - totIdx] >= inOpen[i - totIdx]
                                ? inClose[i - totIdx]
                                : inOpen[i - totIdx];
                            double num7 = inClose[i - totIdx] >= inOpen[i - totIdx]
                                ? inOpen[i - totIdx]
                                : inClose[i - totIdx];
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

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num5 = Math.Abs(
                        inClose[shadowVeryShortTrailingIdx - totIdx]
                        - inOpen[shadowVeryShortTrailingIdx - totIdx]);
                }
                else
                {
                    double num4;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num4 = inHigh[shadowVeryShortTrailingIdx - totIdx] - inLow[shadowVeryShortTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num3 = inClose[shadowVeryShortTrailingIdx - totIdx] >=
                                          inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inClose[shadowVeryShortTrailingIdx - totIdx]
                                : inOpen[shadowVeryShortTrailingIdx - totIdx];

                            double num2 = inClose[shadowVeryShortTrailingIdx - totIdx] >=
                                          inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inOpen[shadowVeryShortTrailingIdx - totIdx]
                                : inClose[shadowVeryShortTrailingIdx - totIdx];

                            num = inHigh[shadowVeryShortTrailingIdx - totIdx] - num3
                                  + (num2 - inLow[shadowVeryShortTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num = 0.0;
                        }

                        num4 = num;
                    }

                    num5 = num4;
                }

                shadowVeryShortPeriodTotal[totIdx] += num10 - num5;
                totIdx--;
            }

            i++;
            shadowVeryShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0317;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static RetCode Cdl3BlackCrows(
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
            double[] shadowVeryShortPeriodTotal = new double[3];
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

            int lookbackTotal = Cdl3BlackCrowsLookback();
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

            shadowVeryShortPeriodTotal[2] = 0.0;
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - Globals.candleSettings[7].avgPeriod;
            int i = shadowVeryShortTrailingIdx;
            while (true)
            {
                float num39;
                float num44;
                float num49;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num49 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    float num48;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num48 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        float num45;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            float num47 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            float num46 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num45 = inHigh[i - 2] - num47 + (num46 - inLow[i - 2]);
                        }
                        else
                        {
                            num45 = 0.0f;
                        }

                        num48 = num45;
                    }

                    num49 = num48;
                }

                shadowVeryShortPeriodTotal[2] += num49;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num44 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    float num43;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num43 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        float num40;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            float num42 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                            float num41 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                            num40 = inHigh[i - 1] - num42 + (num41 - inLow[i - 1]);
                        }
                        else
                        {
                            num40 = 0.0f;
                        }

                        num43 = num40;
                    }

                    num44 = num43;
                }

                shadowVeryShortPeriodTotal[1] += num44;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num39 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    float num38;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num38 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        float num35;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            float num37 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            float num36 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num35 = inHigh[i] - num37 + (num36 - inLow[i]);
                        }
                        else
                        {
                            num35 = 0.0f;
                        }

                        num38 = num35;
                    }

                    num39 = num38;
                }

                shadowVeryShortPeriodTotal[0] += num39;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_0341:
            if (inClose[i - 3] >= inOpen[i - 3] && (inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == -1)
            {
                double num33;
                float num34 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];

                if (Globals.candleSettings[7].avgPeriod != 0.0)
                {
                    num33 = shadowVeryShortPeriodTotal[2] / Globals.candleSettings[7].avgPeriod;
                }
                else
                {
                    float num32;
                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                    {
                        num32 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        float num31;
                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                        {
                            num31 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            float num28;
                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                            {
                                float num30 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                float num29 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                num28 = inHigh[i - 2] - num30 + (num29 - inLow[i - 2]);
                            }
                            else
                            {
                                num28 = 0.0f;
                            }

                            num31 = num28;
                        }

                        num32 = num31;
                    }

                    num33 = num32;
                }

                double num27 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (num34 - inLow[i - 2] < Globals.candleSettings[7].factor * num33 / num27
                    && (inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1)
                {
                    double num25;
                    float num26 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];

                    if (Globals.candleSettings[7].avgPeriod != 0.0)
                    {
                        num25 = shadowVeryShortPeriodTotal[1] / Globals.candleSettings[7].avgPeriod;
                    }
                    else
                    {
                        float num24;
                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                        {
                            num24 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            float num23;
                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                            {
                                num23 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                float num20;
                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    float num22 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                    float num21 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                    num20 = inHigh[i - 1] - num22 + (num21 - inLow[i - 1]);
                                }
                                else
                                {
                                    num20 = 0.0f;
                                }

                                num23 = num20;
                            }

                            num24 = num23;
                        }

                        num25 = num24;
                    }

                    double num19 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                    if (num26 - inLow[i - 1] < Globals.candleSettings[7].factor * num25 / num19
                        && (inClose[i] < inOpen[i] ? -1 : 1) == -1)
                    {
                        double num17;
                        float num18 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];

                        if (Globals.candleSettings[7].avgPeriod != 0.0)
                        {
                            num17 = shadowVeryShortPeriodTotal[0] / Globals.candleSettings[7].avgPeriod;
                        }
                        else
                        {
                            float num16;
                            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                            {
                                num16 = Math.Abs(inClose[i] - inOpen[i]);
                            }
                            else
                            {
                                float num15;
                                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                {
                                    num15 = inHigh[i] - inLow[i];
                                }
                                else
                                {
                                    float num12;
                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        float num14 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                        float num13 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                                        num12 = inHigh[i] - num14 + (num13 - inLow[i]);
                                    }
                                    else
                                    {
                                        num12 = 0.0f;
                                    }

                                    num15 = num12;
                                }

                                num16 = num15;
                            }

                            num17 = num16;
                        }

                        double num11 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                        if (num18 - inLow[i] < Globals.candleSettings[7].factor * num17 / num11
                            && inOpen[i - 1] < inOpen[i - 2] && inOpen[i - 1] > inClose[i - 2] &&
                            inOpen[i] < inOpen[i - 1] && inOpen[i] > inClose[i - 1] && inHigh[i - 3] > inClose[i - 2] &&
                            inClose[i - 2] > inClose[i - 1] && inClose[i - 1] > inClose[i])
                        {
                            outInteger[outIdx] = -100;
                            outIdx++;
                            goto Label_0891;
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0891:
            int totIdx = 2;
            while (totIdx >= 0)
            {
                float num5;
                float num10;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num10 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    float num9;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num9 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        float num6;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            float num8 = inClose[i - totIdx] >= inOpen[i - totIdx]
                                ? inClose[i - totIdx]
                                : inOpen[i - totIdx];
                            float num7 = inClose[i - totIdx] >= inOpen[i - totIdx]
                                ? inOpen[i - totIdx]
                                : inClose[i - totIdx];
                            num6 = inHigh[i - totIdx] - num8 + (num7 - inLow[i - totIdx]);
                        }
                        else
                        {
                            num6 = 0.0f;
                        }

                        num9 = num6;
                    }

                    num10 = num9;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num5 = Math.Abs(
                        inClose[shadowVeryShortTrailingIdx - totIdx]
                        - inOpen[shadowVeryShortTrailingIdx - totIdx]);
                }
                else
                {
                    float num4;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num4 = inHigh[shadowVeryShortTrailingIdx - totIdx] - inLow[shadowVeryShortTrailingIdx - totIdx];
                    }
                    else
                    {
                        float num;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            float num3 = inClose[shadowVeryShortTrailingIdx - totIdx] >=
                                         inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inClose[shadowVeryShortTrailingIdx - totIdx]
                                : inOpen[shadowVeryShortTrailingIdx - totIdx];

                            float num2 = inClose[shadowVeryShortTrailingIdx - totIdx] >=
                                         inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inOpen[shadowVeryShortTrailingIdx - totIdx]
                                : inClose[shadowVeryShortTrailingIdx - totIdx];

                            num = inHigh[shadowVeryShortTrailingIdx - totIdx] - num3
                                  + (num2 - inLow[shadowVeryShortTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num = 0.0f;
                        }

                        num4 = num;
                    }

                    num5 = num4;
                }

                shadowVeryShortPeriodTotal[totIdx] += num10 - num5;
                totIdx--;
            }

            i++;
            shadowVeryShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0341;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int Cdl3BlackCrowsLookback()
        {
            return Globals.candleSettings[7].avgPeriod + 3;
        }
    }
}
