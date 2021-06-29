using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlKickingByLength(
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
            int num70;
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

            int lookbackTotal = CdlKickingByLengthLookback();
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
                double num85;
                double num90;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num90 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num89;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num89 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num86;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num87;
                            double num88;
                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num88 = inClose[i - 1];
                            }
                            else
                            {
                                num88 = inOpen[i - 1];
                            }

                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num87 = inOpen[i - 1];
                            }
                            else
                            {
                                num87 = inClose[i - 1];
                            }

                            num86 = inHigh[i - 1] - num88 + (num87 - inLow[i - 1]);
                        }
                        else
                        {
                            num86 = 0.0;
                        }

                        num89 = num86;
                    }

                    num90 = num89;
                }

                shadowVeryShortPeriodTotal[1] += num90;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num85 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num84;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num84 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num81;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num82;
                            double num83;
                            if (inClose[i] >= inOpen[i])
                            {
                                num83 = inClose[i];
                            }
                            else
                            {
                                num83 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num82 = inOpen[i];
                            }
                            else
                            {
                                num82 = inClose[i];
                            }

                            num81 = inHigh[i] - num83 + (num82 - inLow[i]);
                        }
                        else
                        {
                            num81 = 0.0;
                        }

                        num84 = num81;
                    }

                    num85 = num84;
                }

                shadowVeryShortPeriodTotal[0] += num85;
                i++;
            }

            i = bodyLongTrailingIdx;
            while (true)
            {
                double num75;
                double num80;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num80 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num79;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num79 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num76;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num77;
                            double num78;
                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num78 = inClose[i - 1];
                            }
                            else
                            {
                                num78 = inOpen[i - 1];
                            }

                            if (inClose[i - 1] >= inOpen[i - 1])
                            {
                                num77 = inOpen[i - 1];
                            }
                            else
                            {
                                num77 = inClose[i - 1];
                            }

                            num76 = inHigh[i - 1] - num78 + (num77 - inLow[i - 1]);
                        }
                        else
                        {
                            num76 = 0.0;
                        }

                        num79 = num76;
                    }

                    num80 = num79;
                }

                bodyLongPeriodTotal[1] += num80;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num75 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num74;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num74 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num71;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num72;
                            double num73;
                            if (inClose[i] >= inOpen[i])
                            {
                                num73 = inClose[i];
                            }
                            else
                            {
                                num73 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num72 = inOpen[i];
                            }
                            else
                            {
                                num72 = inClose[i];
                            }

                            num71 = inHigh[i] - num73 + (num72 - inLow[i]);
                        }
                        else
                        {
                            num71 = 0.0;
                        }

                        num74 = num71;
                    }

                    num75 = num74;
                }

                bodyLongPeriodTotal[0] += num75;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_0413:
            if (inClose[i] >= inOpen[i])
            {
                num70 = 1;
            }
            else
            {
                num70 = -1;
            }

            if ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -num70)
            {
                double num63;
                double num69;
                if (Globals.candleSettings[0].avgPeriod != 0.0)
                {
                    num69 = bodyLongPeriodTotal[1] / Globals.candleSettings[0].avgPeriod;
                }
                else
                {
                    double num68;
                    if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                    {
                        num68 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num67;
                        if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                        {
                            num67 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num64;
                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                double num65;
                                double num66;
                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num66 = inClose[i - 1];
                                }
                                else
                                {
                                    num66 = inOpen[i - 1];
                                }

                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num65 = inOpen[i - 1];
                                }
                                else
                                {
                                    num65 = inClose[i - 1];
                                }

                                num64 = inHigh[i - 1] - num66 + (num65 - inLow[i - 1]);
                            }
                            else
                            {
                                num64 = 0.0;
                            }

                            num67 = num64;
                        }

                        num68 = num67;
                    }

                    num69 = num68;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                {
                    num63 = 2.0;
                }
                else
                {
                    num63 = 1.0;
                }

                if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    > Globals.candleSettings[0].factor * num69 / num63)
                {
                    double num55;
                    double num61;
                    double num62;
                    if (inClose[i - 1] >= inOpen[i - 1])
                    {
                        num62 = inClose[i - 1];
                    }
                    else
                    {
                        num62 = inOpen[i - 1];
                    }

                    if (Globals.candleSettings[7].avgPeriod != 0.0)
                    {
                        num61 = shadowVeryShortPeriodTotal[1] / Globals.candleSettings[7].avgPeriod;
                    }
                    else
                    {
                        double num60;
                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                        {
                            num60 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num59;
                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                            {
                                num59 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num56;
                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    double num57;
                                    double num58;
                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num58 = inClose[i - 1];
                                    }
                                    else
                                    {
                                        num58 = inOpen[i - 1];
                                    }

                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num57 = inOpen[i - 1];
                                    }
                                    else
                                    {
                                        num57 = inClose[i - 1];
                                    }

                                    num56 = inHigh[i - 1] - num58 + (num57 - inLow[i - 1]);
                                }
                                else
                                {
                                    num56 = 0.0;
                                }

                                num59 = num56;
                            }

                            num60 = num59;
                        }

                        num61 = num60;
                    }

                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                    {
                        num55 = 2.0;
                    }
                    else
                    {
                        num55 = 1.0;
                    }

                    if (inHigh[i - 1] - num62 < Globals.candleSettings[7].factor * num61 / num55)
                    {
                        double num47;
                        double num53;
                        double num54;
                        if (inClose[i - 1] >= inOpen[i - 1])
                        {
                            num54 = inOpen[i - 1];
                        }
                        else
                        {
                            num54 = inClose[i - 1];
                        }

                        if (Globals.candleSettings[7].avgPeriod != 0.0)
                        {
                            num53 = shadowVeryShortPeriodTotal[1] / Globals.candleSettings[7].avgPeriod;
                        }
                        else
                        {
                            double num52;
                            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                            {
                                num52 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                            }
                            else
                            {
                                double num51;
                                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                {
                                    num51 = inHigh[i - 1] - inLow[i - 1];
                                }
                                else
                                {
                                    double num48;
                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        double num49;
                                        double num50;
                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num50 = inClose[i - 1];
                                        }
                                        else
                                        {
                                            num50 = inOpen[i - 1];
                                        }

                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num49 = inOpen[i - 1];
                                        }
                                        else
                                        {
                                            num49 = inClose[i - 1];
                                        }

                                        num48 = inHigh[i - 1] - num50 + (num49 - inLow[i - 1]);
                                    }
                                    else
                                    {
                                        num48 = 0.0;
                                    }

                                    num51 = num48;
                                }

                                num52 = num51;
                            }

                            num53 = num52;
                        }

                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            num47 = 2.0;
                        }
                        else
                        {
                            num47 = 1.0;
                        }

                        if (num54 - inLow[i - 1] < Globals.candleSettings[7].factor * num53 / num47)
                        {
                            double num40;
                            double num46;
                            if (Globals.candleSettings[0].avgPeriod != 0.0)
                            {
                                num46 = bodyLongPeriodTotal[0] / Globals.candleSettings[0].avgPeriod;
                            }
                            else
                            {
                                double num45;
                                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                                {
                                    num45 = Math.Abs(inClose[i] - inOpen[i]);
                                }
                                else
                                {
                                    double num44;
                                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                                    {
                                        num44 = inHigh[i] - inLow[i];
                                    }
                                    else
                                    {
                                        double num41;
                                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                                        {
                                            double num42;
                                            double num43;
                                            if (inClose[i] >= inOpen[i])
                                            {
                                                num43 = inClose[i];
                                            }
                                            else
                                            {
                                                num43 = inOpen[i];
                                            }

                                            if (inClose[i] >= inOpen[i])
                                            {
                                                num42 = inOpen[i];
                                            }
                                            else
                                            {
                                                num42 = inClose[i];
                                            }

                                            num41 = inHigh[i] - num43 + (num42 - inLow[i]);
                                        }
                                        else
                                        {
                                            num41 = 0.0;
                                        }

                                        num44 = num41;
                                    }

                                    num45 = num44;
                                }

                                num46 = num45;
                            }

                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                num40 = 2.0;
                            }
                            else
                            {
                                num40 = 1.0;
                            }

                            if (Math.Abs(inClose[i] - inOpen[i])
                                > Globals.candleSettings[0].factor * num46 / num40)
                            {
                                double num32;
                                double num38;
                                double num39;
                                if (inClose[i] >= inOpen[i])
                                {
                                    num39 = inClose[i];
                                }
                                else
                                {
                                    num39 = inOpen[i];
                                }

                                if (Globals.candleSettings[7].avgPeriod != 0.0)
                                {
                                    num38 = shadowVeryShortPeriodTotal[0]
                                            / Globals.candleSettings[7].avgPeriod;
                                }
                                else
                                {
                                    double num37;
                                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                                    {
                                        num37 = Math.Abs(inClose[i] - inOpen[i]);
                                    }
                                    else
                                    {
                                        double num36;
                                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                        {
                                            num36 = inHigh[i] - inLow[i];
                                        }
                                        else
                                        {
                                            double num33;
                                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                            {
                                                double num34;
                                                double num35;
                                                if (inClose[i] >= inOpen[i])
                                                {
                                                    num35 = inClose[i];
                                                }
                                                else
                                                {
                                                    num35 = inOpen[i];
                                                }

                                                if (inClose[i] >= inOpen[i])
                                                {
                                                    num34 = inOpen[i];
                                                }
                                                else
                                                {
                                                    num34 = inClose[i];
                                                }

                                                num33 = inHigh[i] - num35 + (num34 - inLow[i]);
                                            }
                                            else
                                            {
                                                num33 = 0.0;
                                            }

                                            num36 = num33;
                                        }

                                        num37 = num36;
                                    }

                                    num38 = num37;
                                }

                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    num32 = 2.0;
                                }
                                else
                                {
                                    num32 = 1.0;
                                }

                                if (inHigh[i] - num39 < Globals.candleSettings[7].factor * num38 / num32)
                                {
                                    double num24;
                                    double num30;
                                    double num31;
                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num31 = inOpen[i];
                                    }
                                    else
                                    {
                                        num31 = inClose[i];
                                    }

                                    if (Globals.candleSettings[7].avgPeriod != 0.0)
                                    {
                                        num30 = shadowVeryShortPeriodTotal[0]
                                                / Globals.candleSettings[7].avgPeriod;
                                    }
                                    else
                                    {
                                        double num29;
                                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                                        {
                                            num29 = Math.Abs(inClose[i] - inOpen[i]);
                                        }
                                        else
                                        {
                                            double num28;
                                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                            {
                                                num28 = inHigh[i] - inLow[i];
                                            }
                                            else
                                            {
                                                double num25;
                                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
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

                                        num30 = num29;
                                    }

                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        num24 = 2.0;
                                    }
                                    else
                                    {
                                        num24 = 1.0;
                                    }

                                    if (num31 - inLow[i] < Globals.candleSettings[7].factor * num30 / num24
                                        && ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1
                                            && inLow[i] > inHigh[i - 1]
                                            || inClose[i - 1] >= inOpen[i - 1] && inHigh[i] < inLow[i - 1]))
                                    {
                                        int num21;
                                        int num22;
                                        int num23;
                                        if (Math.Abs(inClose[i] - inOpen[i])
                                            > Math.Abs(inClose[i - 1] - inOpen[i - 1]))
                                        {
                                            num23 = i;
                                        }
                                        else
                                        {
                                            num23 = i - 1;
                                        }

                                        if (Math.Abs(inClose[i] - inOpen[i])
                                            > Math.Abs(inClose[i - 1] - inOpen[i - 1]))
                                        {
                                            num22 = i;
                                        }
                                        else
                                        {
                                            num22 = i - 1;
                                        }

                                        if (inClose[num23] >= inOpen[num22])
                                        {
                                            num21 = 1;
                                        }
                                        else
                                        {
                                            num21 = -1;
                                        }

                                        outInteger[outIdx] = num21 * 100;
                                        outIdx++;
                                        goto Label_0D39;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0D39:
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

        public static int CdlKickingByLengthLookback()
        {
            return (Globals.candleSettings[7].avgPeriod <= Globals.candleSettings[0].avgPeriod
                         ? Globals.candleSettings[0].avgPeriod
                         : Globals.candleSettings[7].avgPeriod) + 1;
        }
    }
}
