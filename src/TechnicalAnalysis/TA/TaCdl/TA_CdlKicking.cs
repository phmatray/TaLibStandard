namespace TechnicalAnalysis
{
    using System;

    internal static partial class TACore
    {
        public static RetCode CdlKicking(
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
            int num68;
            double[] shadowVeryShortPeriodTotal = new double[2];
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

            int lookbackTotal = CdlKickingLookback();
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

            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - Globals.candleSettings[7].avgPeriod;
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - Globals.candleSettings[0].avgPeriod;
            int i = shadowVeryShortTrailingIdx;
            while (true)
            {
                double num83;
                double num88;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num88 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num87;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num87 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num84;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num85;
                            double num86;
                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num86 = inClose[i - 1];
                            }
                            else
                            {
                                num86 = inOpen[i - 1];
                            }

                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num85 = inOpen[i - 1];
                            }
                            else
                            {
                                num85 = inClose[i - 1];
                            }

                            num84 = inHigh[i - 1] - num86 + (num85 - inLow[i - 1]);
                        }
                        else
                        {
                            num84 = 0.0;
                        }

                        num87 = num84;
                    }

                    num88 = num87;
                }

                shadowVeryShortPeriodTotal[1] += num88;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num83 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num82;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num82 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num79;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num80;
                            double num81;
                            if (inClose[i] >= inOpen[i])
                            {
                                num81 = inClose[i];
                            }
                            else
                            {
                                num81 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num80 = inOpen[i];
                            }
                            else
                            {
                                num80 = inClose[i];
                            }

                            num79 = inHigh[i] - num81 + (num80 - inLow[i]);
                        }
                        else
                        {
                            num79 = 0.0;
                        }

                        num82 = num79;
                    }

                    num83 = num82;
                }

                shadowVeryShortPeriodTotal[0] += num83;
                i++;
            }

            i = bodyLongTrailingIdx;
            while (true)
            {
                double num73;
                double num78;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num78 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num77;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num77 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num74;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num75;
                            double num76;
                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num76 = inClose[i - 1];
                            }
                            else
                            {
                                num76 = inOpen[i - 1];
                            }

                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num75 = inOpen[i - 1];
                            }
                            else
                            {
                                num75 = inClose[i - 1];
                            }

                            num74 = inHigh[i - 1] - num76 + (num75 - inLow[i - 1]);
                        }
                        else
                        {
                            num74 = 0.0;
                        }

                        num77 = num74;
                    }

                    num78 = num77;
                }

                bodyLongPeriodTotal[1] += num78;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num73 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num72;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num72 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num69;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num70;
                            double num71;
                            if (inClose[i] >= inOpen[i])
                            {
                                num71 = inClose[i];
                            }
                            else
                            {
                                num71 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num70 = inOpen[i];
                            }
                            else
                            {
                                num70 = inClose[i];
                            }

                            num69 = inHigh[i] - num71 + (num70 - inLow[i]);
                        }
                        else
                        {
                            num69 = 0.0;
                        }

                        num72 = num69;
                    }

                    num73 = num72;
                }

                bodyLongPeriodTotal[0] += num73;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_0413:
            if (inClose[i] >= inOpen[i])
            {
                num68 = 1;
            }
            else
            {
                num68 = -1;
            }

            if ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -num68)
            {
                double num61;
                double num67;
                if (Globals.candleSettings[0].avgPeriod != 0.0)
                {
                    num67 = bodyLongPeriodTotal[1] / Globals.candleSettings[0].avgPeriod;
                }
                else
                {
                    double num66;
                    if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                    {
                        num66 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num65;
                        if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                        {
                            num65 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num62;
                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                double num63;
                                double num64;
                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num64 = inClose[i - 1];
                                }
                                else
                                {
                                    num64 = inOpen[i - 1];
                                }

                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num63 = inOpen[i - 1];
                                }
                                else
                                {
                                    num63 = inClose[i - 1];
                                }

                                num62 = inHigh[i - 1] - num64 + (num63 - inLow[i - 1]);
                            }
                            else
                            {
                                num62 = 0.0;
                            }

                            num65 = num62;
                        }

                        num66 = num65;
                    }

                    num67 = num66;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                {
                    num61 = 2.0;
                }
                else
                {
                    num61 = 1.0;
                }

                if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    > Globals.candleSettings[0].factor * num67 / num61)
                {
                    double num53;
                    double num59;
                    double num60;
                    if (inClose[i - 1] >= inOpen[i - 1])
                    {
                        num60 = inClose[i - 1];
                    }
                    else
                    {
                        num60 = inOpen[i - 1];
                    }

                    if (Globals.candleSettings[7].avgPeriod != 0.0)
                    {
                        num59 = shadowVeryShortPeriodTotal[1] / Globals.candleSettings[7].avgPeriod;
                    }
                    else
                    {
                        double num58;
                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                        {
                            num58 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num57;
                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                            {
                                num57 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num54;
                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    double num55;
                                    double num56;
                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num56 = inClose[i - 1];
                                    }
                                    else
                                    {
                                        num56 = inOpen[i - 1];
                                    }

                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num55 = inOpen[i - 1];
                                    }
                                    else
                                    {
                                        num55 = inClose[i - 1];
                                    }

                                    num54 = inHigh[i - 1] - num56 + (num55 - inLow[i - 1]);
                                }
                                else
                                {
                                    num54 = 0.0;
                                }

                                num57 = num54;
                            }

                            num58 = num57;
                        }

                        num59 = num58;
                    }

                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                    {
                        num53 = 2.0;
                    }
                    else
                    {
                        num53 = 1.0;
                    }

                    if (inHigh[i - 1] - num60 < Globals.candleSettings[7].factor * num59 / num53)
                    {
                        double num45;
                        double num51;
                        double num52;
                        if (inClose[i - 1] >= inOpen[i - 1])
                        {
                            num52 = inOpen[i - 1];
                        }
                        else
                        {
                            num52 = inClose[i - 1];
                        }

                        if (Globals.candleSettings[7].avgPeriod != 0.0)
                        {
                            num51 = shadowVeryShortPeriodTotal[1] / Globals.candleSettings[7].avgPeriod;
                        }
                        else
                        {
                            double num50;
                            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                            {
                                num50 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                            }
                            else
                            {
                                double num49;
                                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                {
                                    num49 = inHigh[i - 1] - inLow[i - 1];
                                }
                                else
                                {
                                    double num46;
                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        double num47;
                                        double num48;
                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num48 = inClose[i - 1];
                                        }
                                        else
                                        {
                                            num48 = inOpen[i - 1];
                                        }

                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num47 = inOpen[i - 1];
                                        }
                                        else
                                        {
                                            num47 = inClose[i - 1];
                                        }

                                        num46 = inHigh[i - 1] - num48 + (num47 - inLow[i - 1]);
                                    }
                                    else
                                    {
                                        num46 = 0.0;
                                    }

                                    num49 = num46;
                                }

                                num50 = num49;
                            }

                            num51 = num50;
                        }

                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            num45 = 2.0;
                        }
                        else
                        {
                            num45 = 1.0;
                        }

                        if (num52 - inLow[i - 1] < Globals.candleSettings[7].factor * num51 / num45)
                        {
                            double num38;
                            double num44;
                            if (Globals.candleSettings[0].avgPeriod != 0.0)
                            {
                                num44 = bodyLongPeriodTotal[0] / Globals.candleSettings[0].avgPeriod;
                            }
                            else
                            {
                                double num43;
                                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                                {
                                    num43 = Math.Abs(inClose[i] - inOpen[i]);
                                }
                                else
                                {
                                    double num42;
                                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                                    {
                                        num42 = inHigh[i] - inLow[i];
                                    }
                                    else
                                    {
                                        double num39;
                                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                                        {
                                            double num40;
                                            double num41;
                                            if (inClose[i] >= inOpen[i])
                                            {
                                                num41 = inClose[i];
                                            }
                                            else
                                            {
                                                num41 = inOpen[i];
                                            }

                                            if (inClose[i] >= inOpen[i])
                                            {
                                                num40 = inOpen[i];
                                            }
                                            else
                                            {
                                                num40 = inClose[i];
                                            }

                                            num39 = inHigh[i] - num41 + (num40 - inLow[i]);
                                        }
                                        else
                                        {
                                            num39 = 0.0;
                                        }

                                        num42 = num39;
                                    }

                                    num43 = num42;
                                }

                                num44 = num43;
                            }

                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                num38 = 2.0;
                            }
                            else
                            {
                                num38 = 1.0;
                            }

                            if (Math.Abs(inClose[i] - inOpen[i])
                                > Globals.candleSettings[0].factor * num44 / num38)
                            {
                                double num30;
                                double num36;
                                double num37;
                                if (inClose[i] >= inOpen[i])
                                {
                                    num37 = inClose[i];
                                }
                                else
                                {
                                    num37 = inOpen[i];
                                }

                                if (Globals.candleSettings[7].avgPeriod != 0.0)
                                {
                                    num36 = shadowVeryShortPeriodTotal[0]
                                            / Globals.candleSettings[7].avgPeriod;
                                }
                                else
                                {
                                    double num35;
                                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                                    {
                                        num35 = Math.Abs(inClose[i] - inOpen[i]);
                                    }
                                    else
                                    {
                                        double num34;
                                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                        {
                                            num34 = inHigh[i] - inLow[i];
                                        }
                                        else
                                        {
                                            double num31;
                                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                            {
                                                double num32;
                                                double num33;
                                                if (inClose[i] >= inOpen[i])
                                                {
                                                    num33 = inClose[i];
                                                }
                                                else
                                                {
                                                    num33 = inOpen[i];
                                                }

                                                if (inClose[i] >= inOpen[i])
                                                {
                                                    num32 = inOpen[i];
                                                }
                                                else
                                                {
                                                    num32 = inClose[i];
                                                }

                                                num31 = inHigh[i] - num33 + (num32 - inLow[i]);
                                            }
                                            else
                                            {
                                                num31 = 0.0;
                                            }

                                            num34 = num31;
                                        }

                                        num35 = num34;
                                    }

                                    num36 = num35;
                                }

                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    num30 = 2.0;
                                }
                                else
                                {
                                    num30 = 1.0;
                                }

                                if (inHigh[i] - num37 < Globals.candleSettings[7].factor * num36 / num30)
                                {
                                    double num22;
                                    double num28;
                                    double num29;
                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num29 = inOpen[i];
                                    }
                                    else
                                    {
                                        num29 = inClose[i];
                                    }

                                    if (Globals.candleSettings[7].avgPeriod != 0.0)
                                    {
                                        num28 = shadowVeryShortPeriodTotal[0]
                                                / Globals.candleSettings[7].avgPeriod;
                                    }
                                    else
                                    {
                                        double num27;
                                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                                        {
                                            num27 = Math.Abs(inClose[i] - inOpen[i]);
                                        }
                                        else
                                        {
                                            double num26;
                                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                            {
                                                num26 = inHigh[i] - inLow[i];
                                            }
                                            else
                                            {
                                                double num23;
                                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                                {
                                                    double num24;
                                                    double num25;
                                                    if (inClose[i] >= inOpen[i])
                                                    {
                                                        num25 = inClose[i];
                                                    }
                                                    else
                                                    {
                                                        num25 = inOpen[i];
                                                    }

                                                    if (inClose[i] >= inOpen[i])
                                                    {
                                                        num24 = inOpen[i];
                                                    }
                                                    else
                                                    {
                                                        num24 = inClose[i];
                                                    }

                                                    num23 = inHigh[i] - num25 + (num24 - inLow[i]);
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

                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        num22 = 2.0;
                                    }
                                    else
                                    {
                                        num22 = 1.0;
                                    }

                                    if (num29 - inLow[i] < Globals.candleSettings[7].factor * num28 / num22
                                        && ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1
                                            && inLow[i] > inHigh[i - 1]
                                            || inClose[i - 1] >= inOpen[i - 1] && inHigh[i] < inLow[i - 1]))
                                    {
                                        int num21;
                                        if (inClose[i] >= inOpen[i])
                                        {
                                            num21 = 1;
                                        }
                                        else
                                        {
                                            num21 = -1;
                                        }

                                        outInteger[outIdx] = num21 * 100;
                                        outIdx++;
                                        goto Label_0CDA;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0CDA:
            totIdx = 1;
            while (totIdx >= 0)
            {
                double num5;
                double num10;
                double num15;
                double num20;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num20 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num19;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num19 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num16;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num17;
                            double num18;
                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num18 = inClose[i - totIdx];
                            }
                            else
                            {
                                num18 = inOpen[i - totIdx];
                            }

                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num17 = inOpen[i - totIdx];
                            }
                            else
                            {
                                num17 = inClose[i - totIdx];
                            }

                            num16 = inHigh[i - totIdx] - num18 + (num17 - inLow[i - totIdx]);
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
                    num15 = Math.Abs(
                        inClose[bodyLongTrailingIdx - totIdx] - inOpen[bodyLongTrailingIdx - totIdx]);
                }
                else
                {
                    double num14;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num14 = inHigh[bodyLongTrailingIdx - totIdx] - inLow[bodyLongTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num11;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num12;
                            double num13;
                            if (inClose[bodyLongTrailingIdx - totIdx] >= inOpen[bodyLongTrailingIdx - totIdx])
                            {
                                num13 = inClose[bodyLongTrailingIdx - totIdx];
                            }
                            else
                            {
                                num13 = inOpen[bodyLongTrailingIdx - totIdx];
                            }

                            if (inClose[bodyLongTrailingIdx - totIdx] >= inOpen[bodyLongTrailingIdx - totIdx])
                            {
                                num12 = inOpen[bodyLongTrailingIdx - totIdx];
                            }
                            else
                            {
                                num12 = inClose[bodyLongTrailingIdx - totIdx];
                            }

                            num11 = inHigh[bodyLongTrailingIdx - totIdx] - num13
                                    + (num12 - inLow[bodyLongTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num11 = 0.0;
                        }

                        num14 = num11;
                    }

                    num15 = num14;
                }

                bodyLongPeriodTotal[totIdx] += num20 - num15;
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
                            double num2;
                            double num3;
                            if (inClose[shadowVeryShortTrailingIdx - totIdx]
                                >= inOpen[shadowVeryShortTrailingIdx - totIdx])
                            {
                                num3 = inClose[shadowVeryShortTrailingIdx - totIdx];
                            }
                            else
                            {
                                num3 = inOpen[shadowVeryShortTrailingIdx - totIdx];
                            }

                            if (inClose[shadowVeryShortTrailingIdx - totIdx]
                                >= inOpen[shadowVeryShortTrailingIdx - totIdx])
                            {
                                num2 = inOpen[shadowVeryShortTrailingIdx - totIdx];
                            }
                            else
                            {
                                num2 = inClose[shadowVeryShortTrailingIdx - totIdx];
                            }

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
            bodyLongTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0413;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlKickingLookback()
        {
            return (Globals.candleSettings[7].avgPeriod <= Globals.candleSettings[0].avgPeriod
                         ? Globals.candleSettings[0].avgPeriod
                         : Globals.candleSettings[7].avgPeriod) + 1;
        }
    }
}
