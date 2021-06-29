using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlHangingMan(
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
            double num25;
            double num30;
            double num35;
            double num40;
            double num65;
            double num71;
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

            int lookbackTotal = CdlHangingManLookback();
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

            double bodyPeriodTotal = 0.0;
            int bodyTrailingIdx = startIdx - Globals.candleSettings[2].avgPeriod;
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - Globals.candleSettings[4].avgPeriod;
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - Globals.candleSettings[7].avgPeriod;
            double nearPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - 1 - Globals.candleSettings[8].avgPeriod;
            int i = bodyTrailingIdx;
            while (true)
            {
                double num91;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                {
                    num91 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num90;
                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                    {
                        num90 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num87;
                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                        {
                            double num89 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num88 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num87 = inHigh[i] - num89 + (num88 - inLow[i]);
                        }
                        else
                        {
                            num87 = 0.0;
                        }

                        num90 = num87;
                    }

                    num91 = num90;
                }

                bodyPeriodTotal += num91;
                i++;
            }

            i = shadowLongTrailingIdx;
            while (true)
            {
                double num86;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                {
                    num86 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num85;
                    if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                    {
                        num85 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num82;
                        if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                        {
                            double num83;
                            double num84;
                            if (inClose[i] >= inOpen[i])
                            {
                                num84 = inClose[i];
                            }
                            else
                            {
                                num84 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num83 = inOpen[i];
                            }
                            else
                            {
                                num83 = inClose[i];
                            }

                            num82 = inHigh[i] - num84 + (num83 - inLow[i]);
                        }
                        else
                        {
                            num82 = 0.0;
                        }

                        num85 = num82;
                    }

                    num86 = num85;
                }

                shadowLongPeriodTotal += num86;
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (true)
            {
                double num81;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num81 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num80;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num80 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num77;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num79 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num78 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num77 = inHigh[i] - num79 + (num78 - inLow[i]);
                        }
                        else
                        {
                            num77 = 0.0;
                        }

                        num80 = num77;
                    }

                    num81 = num80;
                }

                shadowVeryShortPeriodTotal += num81;
                i++;
            }

            i = nearTrailingIdx;
            while (true)
            {
                double num76;
                if (i >= startIdx - 1)
                {
                    break;
                }

                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num76 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num75;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num75 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num72;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num73;
                            double num74;
                            if (inClose[i] >= inOpen[i])
                            {
                                num74 = inClose[i];
                            }
                            else
                            {
                                num74 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num73 = inOpen[i];
                            }
                            else
                            {
                                num73 = inClose[i];
                            }

                            num72 = inHigh[i] - num74 + (num73 - inLow[i]);
                        }
                        else
                        {
                            num72 = 0.0;
                        }

                        num75 = num72;
                    }

                    num76 = num75;
                }

                nearPeriodTotal += num76;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_03FF:
            if (Globals.candleSettings[2].avgPeriod != 0.0)
            {
                num71 = bodyPeriodTotal / Globals.candleSettings[2].avgPeriod;
            }
            else
            {
                double num70;
                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                {
                    num70 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num69;
                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                    {
                        num69 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num66;
                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                        {
                            double num67;
                            double num68;
                            if (inClose[i] >= inOpen[i])
                            {
                                num68 = inClose[i];
                            }
                            else
                            {
                                num68 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num67 = inOpen[i];
                            }
                            else
                            {
                                num67 = inClose[i];
                            }

                            num66 = inHigh[i] - num68 + (num67 - inLow[i]);
                        }
                        else
                        {
                            num66 = 0.0;
                        }

                        num69 = num66;
                    }

                    num70 = num69;
                }

                num71 = num70;
            }

            if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
            {
                num65 = 2.0;
            }
            else
            {
                num65 = 1.0;
            }

            if (Math.Abs(inClose[i] - inOpen[i]) < Globals.candleSettings[2].factor * num71 / num65)
            {
                double num57;
                double num63;
                double num64;
                if (inClose[i] >= inOpen[i])
                {
                    num64 = inOpen[i];
                }
                else
                {
                    num64 = inClose[i];
                }

                if (Globals.candleSettings[4].avgPeriod != 0.0)
                {
                    num63 = shadowLongPeriodTotal / Globals.candleSettings[4].avgPeriod;
                }
                else
                {
                    double num62;
                    if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                    {
                        num62 = Math.Abs(inClose[i] - inOpen[i]);
                    }
                    else
                    {
                        double num61;
                        if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                        {
                            num61 = inHigh[i] - inLow[i];
                        }
                        else
                        {
                            double num58;
                            if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                            {
                                double num59;
                                double num60;
                                if (inClose[i] >= inOpen[i])
                                {
                                    num60 = inClose[i];
                                }
                                else
                                {
                                    num60 = inOpen[i];
                                }

                                if (inClose[i] >= inOpen[i])
                                {
                                    num59 = inOpen[i];
                                }
                                else
                                {
                                    num59 = inClose[i];
                                }

                                num58 = inHigh[i] - num60 + (num59 - inLow[i]);
                            }
                            else
                            {
                                num58 = 0.0;
                            }

                            num61 = num58;
                        }

                        num62 = num61;
                    }

                    num63 = num62;
                }

                if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                {
                    num57 = 2.0;
                }
                else
                {
                    num57 = 1.0;
                }

                if (num64 - inLow[i] > Globals.candleSettings[4].factor * num63 / num57)
                {
                    double num49;
                    double num55;
                    double num56;
                    if (inClose[i] >= inOpen[i])
                    {
                        num56 = inClose[i];
                    }
                    else
                    {
                        num56 = inOpen[i];
                    }

                    if (Globals.candleSettings[7].avgPeriod != 0.0)
                    {
                        num55 = shadowVeryShortPeriodTotal / Globals.candleSettings[7].avgPeriod;
                    }
                    else
                    {
                        double num54;
                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                        {
                            num54 = Math.Abs(inClose[i] - inOpen[i]);
                        }
                        else
                        {
                            double num53;
                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                            {
                                num53 = inHigh[i] - inLow[i];
                            }
                            else
                            {
                                double num50;
                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    double num51;
                                    double num52;
                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num52 = inClose[i];
                                    }
                                    else
                                    {
                                        num52 = inOpen[i];
                                    }

                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num51 = inOpen[i];
                                    }
                                    else
                                    {
                                        num51 = inClose[i];
                                    }

                                    num50 = inHigh[i] - num52 + (num51 - inLow[i]);
                                }
                                else
                                {
                                    num50 = 0.0;
                                }

                                num53 = num50;
                            }

                            num54 = num53;
                        }

                        num55 = num54;
                    }

                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                    {
                        num49 = 2.0;
                    }
                    else
                    {
                        num49 = 1.0;
                    }

                    if (inHigh[i] - num56 < Globals.candleSettings[7].factor * num55 / num49)
                    {
                        double num41;
                        double num47;
                        double num48;
                        if (inClose[i] < inOpen[i])
                        {
                            num48 = inClose[i];
                        }
                        else
                        {
                            num48 = inOpen[i];
                        }

                        if (Globals.candleSettings[8].avgPeriod != 0.0)
                        {
                            num47 = nearPeriodTotal / Globals.candleSettings[8].avgPeriod;
                        }
                        else
                        {
                            double num46;
                            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                            {
                                num46 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                            }
                            else
                            {
                                double num45;
                                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                {
                                    num45 = inHigh[i - 1] - inLow[i - 1];
                                }
                                else
                                {
                                    double num42;
                                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                    {
                                        double num43;
                                        double num44;
                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num44 = inClose[i - 1];
                                        }
                                        else
                                        {
                                            num44 = inOpen[i - 1];
                                        }

                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num43 = inOpen[i - 1];
                                        }
                                        else
                                        {
                                            num43 = inClose[i - 1];
                                        }

                                        num42 = inHigh[i - 1] - num44 + (num43 - inLow[i - 1]);
                                    }
                                    else
                                    {
                                        num42 = 0.0;
                                    }

                                    num45 = num42;
                                }

                                num46 = num45;
                            }

                            num47 = num46;
                        }

                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            num41 = 2.0;
                        }
                        else
                        {
                            num41 = 1.0;
                        }

                        if (num48 >= inHigh[i - 1] - Globals.candleSettings[8].factor * num47 / num41)
                        {
                            outInteger[outIdx] = -100;
                            outIdx++;
                            goto Label_095E;
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_095E:
            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num40 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num39;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num39 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num36;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        double num37;
                        double num38;
                        if (inClose[i] >= inOpen[i])
                        {
                            num38 = inClose[i];
                        }
                        else
                        {
                            num38 = inOpen[i];
                        }

                        if (inClose[i] >= inOpen[i])
                        {
                            num37 = inOpen[i];
                        }
                        else
                        {
                            num37 = inClose[i];
                        }

                        num36 = inHigh[i] - num38 + (num37 - inLow[i]);
                    }
                    else
                    {
                        num36 = 0.0;
                    }

                    num39 = num36;
                }

                num40 = num39;
            }

            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num35 = Math.Abs(inClose[bodyTrailingIdx] - inOpen[bodyTrailingIdx]);
            }
            else
            {
                double num34;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num34 = inHigh[bodyTrailingIdx] - inLow[bodyTrailingIdx];
                }
                else
                {
                    double num31;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        double num32;
                        double num33;
                        if (inClose[bodyTrailingIdx] >= inOpen[bodyTrailingIdx])
                        {
                            num33 = inClose[bodyTrailingIdx];
                        }
                        else
                        {
                            num33 = inOpen[bodyTrailingIdx];
                        }

                        if (inClose[bodyTrailingIdx] >= inOpen[bodyTrailingIdx])
                        {
                            num32 = inOpen[bodyTrailingIdx];
                        }
                        else
                        {
                            num32 = inClose[bodyTrailingIdx];
                        }

                        num31 = inHigh[bodyTrailingIdx] - num33 + (num32 - inLow[bodyTrailingIdx]);
                    }
                    else
                    {
                        num31 = 0.0;
                    }

                    num34 = num31;
                }

                num35 = num34;
            }

            bodyPeriodTotal += num40 - num35;
            if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
            {
                num30 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num29;
                if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                {
                    num29 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num26;
                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                    {
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

                        if (inClose[i] >= inOpen[i])
                        {
                            num27 = inOpen[i];
                        }
                        else
                        {
                            num27 = inClose[i];
                        }

                        num26 = inHigh[i] - num28 + (num27 - inLow[i]);
                    }
                    else
                    {
                        num26 = 0.0;
                    }

                    num29 = num26;
                }

                num30 = num29;
            }

            if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
            {
                num25 = Math.Abs(inClose[shadowLongTrailingIdx] - inOpen[shadowLongTrailingIdx]);
            }
            else
            {
                double num24;
                if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                {
                    num24 = inHigh[shadowLongTrailingIdx] - inLow[shadowLongTrailingIdx];
                }
                else
                {
                    double num21;
                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                    {
                        double num22;
                        double num23;
                        if (inClose[shadowLongTrailingIdx] >= inOpen[shadowLongTrailingIdx])
                        {
                            num23 = inClose[shadowLongTrailingIdx];
                        }
                        else
                        {
                            num23 = inOpen[shadowLongTrailingIdx];
                        }

                        if (inClose[shadowLongTrailingIdx] >= inOpen[shadowLongTrailingIdx])
                        {
                            num22 = inOpen[shadowLongTrailingIdx];
                        }
                        else
                        {
                            num22 = inClose[shadowLongTrailingIdx];
                        }

                        num21 = inHigh[shadowLongTrailingIdx] - num23 + (num22 - inLow[shadowLongTrailingIdx]);
                    }
                    else
                    {
                        num21 = 0.0;
                    }

                    num24 = num21;
                }

                num25 = num24;
            }

            shadowLongPeriodTotal += num30 - num25;
            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
            {
                num15 = Math.Abs(inClose[shadowVeryShortTrailingIdx] - inOpen[shadowVeryShortTrailingIdx]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[shadowVeryShortTrailingIdx] - inLow[shadowVeryShortTrailingIdx];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                    {
                        double num12;
                        double num13;
                        if (inClose[shadowVeryShortTrailingIdx] >= inOpen[shadowVeryShortTrailingIdx])
                        {
                            num13 = inClose[shadowVeryShortTrailingIdx];
                        }
                        else
                        {
                            num13 = inOpen[shadowVeryShortTrailingIdx];
                        }

                        if (inClose[shadowVeryShortTrailingIdx] >= inOpen[shadowVeryShortTrailingIdx])
                        {
                            num12 = inOpen[shadowVeryShortTrailingIdx];
                        }
                        else
                        {
                            num12 = inClose[shadowVeryShortTrailingIdx];
                        }

                        num11 = inHigh[shadowVeryShortTrailingIdx] - num13
                                + (num12 - inLow[shadowVeryShortTrailingIdx]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            shadowVeryShortPeriodTotal += num20 - num15;
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
                num5 = Math.Abs(inClose[nearTrailingIdx] - inOpen[nearTrailingIdx]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[nearTrailingIdx] - inLow[nearTrailingIdx];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[nearTrailingIdx] >= inOpen[nearTrailingIdx])
                        {
                            num3 = inClose[nearTrailingIdx];
                        }
                        else
                        {
                            num3 = inOpen[nearTrailingIdx];
                        }

                        if (inClose[nearTrailingIdx] >= inOpen[nearTrailingIdx])
                        {
                            num2 = inOpen[nearTrailingIdx];
                        }
                        else
                        {
                            num2 = inClose[nearTrailingIdx];
                        }

                        num = inHigh[nearTrailingIdx] - num3 + (num2 - inLow[nearTrailingIdx]);
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
            bodyTrailingIdx++;
            shadowLongTrailingIdx++;
            shadowVeryShortTrailingIdx++;
            nearTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_03FF;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlHangingManLookback()
        {
            int num;
            int avgPeriod;
            if ((Globals.candleSettings[2].avgPeriod <= Globals.candleSettings[4].avgPeriod
                     ? Globals.candleSettings[4].avgPeriod
                     : Globals.candleSettings[2].avgPeriod) > Globals.candleSettings[7].avgPeriod)
            {
                avgPeriod = Globals.candleSettings[2].avgPeriod <= Globals.candleSettings[4].avgPeriod
                                ? Globals.candleSettings[4].avgPeriod
                                : Globals.candleSettings[2].avgPeriod;
            }
            else
            {
                avgPeriod = Globals.candleSettings[7].avgPeriod;
            }

            if (avgPeriod > Globals.candleSettings[8].avgPeriod)
            {
                int num2;
                if ((Globals.candleSettings[2].avgPeriod <= Globals.candleSettings[4].avgPeriod
                         ? Globals.candleSettings[4].avgPeriod
                         : Globals.candleSettings[2].avgPeriod) > Globals.candleSettings[7].avgPeriod)
                {
                    num2 = Globals.candleSettings[2].avgPeriod <= Globals.candleSettings[4].avgPeriod
                               ? Globals.candleSettings[4].avgPeriod
                               : Globals.candleSettings[2].avgPeriod;
                }
                else
                {
                    num2 = Globals.candleSettings[7].avgPeriod;
                }

                num = num2;
            }
            else
            {
                num = Globals.candleSettings[8].avgPeriod;
            }

            return num + 1;
        }
    }
}
