namespace TechnicalAnalysis
{
    using System;

    internal partial class TACore
    {
        public static RetCode Cdl3StarsInSouth(
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
            double num25;
            double num30;
            double num35;
            double num40;
            double[] shadowVeryShortPeriodTotal = new double[2];
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

            int lookbackTotal = Cdl3StarsInSouthLookback();
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
            int bodyLongTrailingIdx = startIdx - Globals.candleSettings[0].avgPeriod;
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - Globals.candleSettings[4].avgPeriod;
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - Globals.candleSettings[7].avgPeriod;
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - Globals.candleSettings[2].avgPeriod;
            int i = bodyLongTrailingIdx;
            while (true)
            {
                double num111;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num111 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num110;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num110 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num107;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num109 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num108 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num107 = inHigh[i - 2] - num109 + (num108 - inLow[i - 2]);
                        }
                        else
                        {
                            num107 = 0.0;
                        }

                        num110 = num107;
                    }

                    num111 = num110;
                }

                bodyLongPeriodTotal += num111;
                i++;
            }

            i = shadowLongTrailingIdx;
            while (true)
            {
                double num106;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                {
                    num106 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num105;
                    if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                    {
                        num105 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num102;
                        if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                        {
                            double num104 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num103 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num102 = inHigh[i - 2] - num104 + (num103 - inLow[i - 2]);
                        }
                        else
                        {
                            num102 = 0.0;
                        }

                        num105 = num102;
                    }

                    num106 = num105;
                }

                shadowLongPeriodTotal += num106;
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (true)
            {
                double num96;
                double num101;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num101 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num100;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num100 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num97;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num99 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                            double num98 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                            num97 = inHigh[i - 1] - num99 + (num98 - inLow[i - 1]);
                        }
                        else
                        {
                            num97 = 0.0;
                        }

                        num100 = num97;
                    }

                    num101 = num100;
                }

                shadowVeryShortPeriodTotal[1] += num101;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num96 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num95;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num95 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num92;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num94 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num93 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num92 = inHigh[i] - num94 + (num93 - inLow[i]);
                        }
                        else
                        {
                            num92 = 0.0;
                        }

                        num95 = num92;
                    }

                    num96 = num95;
                }

                shadowVeryShortPeriodTotal[0] += num96;
                i++;
            }

            i = bodyShortTrailingIdx;
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

                bodyShortPeriodTotal += num91;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_052C:
            if ((inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == -1
                && (inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1 && (inClose[i] < inOpen[i] ? -1 : 1) == -1)
            {
                double num86;
                if (Globals.candleSettings[0].avgPeriod != 0.0)
                {
                    num86 = bodyLongPeriodTotal / Globals.candleSettings[0].avgPeriod;
                }
                else
                {
                    double num85;
                    if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                    {
                        num85 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num84;
                        if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                        {
                            num84 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num81;
                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                double num83 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                double num82 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                num81 = inHigh[i - 2] - num83 + (num82 - inLow[i - 2]);
                            }
                            else
                            {
                                num81 = 0.0;
                            }

                            num84 = num81;
                        }

                        num85 = num84;
                    }

                    num86 = num85;
                }

                double num80 = Globals.candleSettings[0].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                    > Globals.candleSettings[0].factor * num86 / num80)
                {
                    double num78;
                    double num79 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];

                    if (Globals.candleSettings[4].avgPeriod != 0.0)
                    {
                        num78 = shadowLongPeriodTotal / Globals.candleSettings[4].avgPeriod;
                    }
                    else
                    {
                        double num77;
                        if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                        {
                            num77 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                        }
                        else
                        {
                            double num76;
                            if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                            {
                                num76 = inHigh[i - 2] - inLow[i - 2];
                            }
                            else
                            {
                                double num73;
                                if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                                {
                                    double num75 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                    double num74 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                    num73 = inHigh[i - 2] - num75 + (num74 - inLow[i - 2]);
                                }
                                else
                                {
                                    num73 = 0.0;
                                }

                                num76 = num73;
                            }

                            num77 = num76;
                        }

                        num78 = num77;
                    }

                    double num72 = Globals.candleSettings[4].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                    if (num79 - inLow[i - 2] > Globals.candleSettings[4].factor * num78 / num72
                        && Math.Abs(inClose[i - 1] - inOpen[i - 1])
                        < Math.Abs(inClose[i - 2] - inOpen[i - 2]) && inOpen[i - 1] > inClose[i - 2] && inOpen[i - 1] <= inHigh[i - 2] && inLow[i - 1] < inClose[i - 2] && inLow[i - 1] >= inLow[i - 2])
                    {
                        double num70;
                        double num71 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];

                        if (Globals.candleSettings[7].avgPeriod != 0.0)
                        {
                            num70 = shadowVeryShortPeriodTotal[1] / Globals.candleSettings[7].avgPeriod;
                        }
                        else
                        {
                            double num69;
                            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                            {
                                num69 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                            }
                            else
                            {
                                double num68;
                                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                {
                                    num68 = inHigh[i - 1] - inLow[i - 1];
                                }
                                else
                                {
                                    double num65;
                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        double num67 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                        double num66 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                        num65 = inHigh[i - 1] - num67 + (num66 - inLow[i - 1]);
                                    }
                                    else
                                    {
                                        num65 = 0.0;
                                    }

                                    num68 = num65;
                                }

                                num69 = num68;
                            }

                            num70 = num69;
                        }

                        double num64 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                        if (num71 - inLow[i - 1] > Globals.candleSettings[7].factor * num70 / num64)
                        {
                            double num63;
                            if (Globals.candleSettings[2].avgPeriod != 0.0)
                            {
                                num63 = bodyShortPeriodTotal / Globals.candleSettings[2].avgPeriod;
                            }
                            else
                            {
                                double num62;
                                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                                {
                                    num62 = Math.Abs(inClose[i] - inOpen[i]);
                                }
                                else
                                {
                                    double num61;
                                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                                    {
                                        num61 = inHigh[i] - inLow[i];
                                    }
                                    else
                                    {
                                        double num58;
                                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                                        {
                                            double num60 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                            double num59 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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

                            double num57 = Globals.candleSettings[2].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                            if (Math.Abs(inClose[i] - inOpen[i])
                                < Globals.candleSettings[2].factor * num63 / num57)
                            {
                                double num55;
                                double num56 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];

                                if (Globals.candleSettings[7].avgPeriod != 0.0)
                                {
                                    num55 = shadowVeryShortPeriodTotal[0]
                                            / Globals.candleSettings[7].avgPeriod;
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
                                                double num52 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                                double num51 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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

                                double num49 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                if (num56 - inLow[i] < Globals.candleSettings[7].factor * num55 / num49)
                                {
                                    double num47;
                                    double num48 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];

                                    if (Globals.candleSettings[7].avgPeriod != 0.0)
                                    {
                                        num47 = shadowVeryShortPeriodTotal[0]
                                                / Globals.candleSettings[7].avgPeriod;
                                    }
                                    else
                                    {
                                        double num46;
                                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                                        {
                                            num46 = Math.Abs(inClose[i] - inOpen[i]);
                                        }
                                        else
                                        {
                                            double num45;
                                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                            {
                                                num45 = inHigh[i] - inLow[i];
                                            }
                                            else
                                            {
                                                double num42;
                                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                                {
                                                    double num44 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                                    double num43 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                                                    num42 = inHigh[i] - num44 + (num43 - inLow[i]);
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

                                    double num41 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                    if (inHigh[i] - num48 < Globals.candleSettings[7].factor * num47 / num41
                                        && inLow[i] > inLow[i - 1] && inHigh[i] < inHigh[i - 1])
                                    {
                                        outInteger[outIdx] = 100;
                                        outIdx++;
                                        goto Label_0E31;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0E31:
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num40 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num39;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num39 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num36;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num38 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                        double num37 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                        num36 = inHigh[i - 2] - num38 + (num37 - inLow[i - 2]);
                    }
                    else
                    {
                        num36 = 0.0;
                    }

                    num39 = num36;
                }

                num40 = num39;
            }

            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num35 = Math.Abs(inClose[bodyLongTrailingIdx - 2] - inOpen[bodyLongTrailingIdx - 2]);
            }
            else
            {
                double num34;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num34 = inHigh[bodyLongTrailingIdx - 2] - inLow[bodyLongTrailingIdx - 2];
                }
                else
                {
                    double num31;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num33 = inClose[bodyLongTrailingIdx - 2] >= inOpen[bodyLongTrailingIdx - 2] ? inClose[bodyLongTrailingIdx - 2] : inOpen[bodyLongTrailingIdx - 2];
                        double num32 = inClose[bodyLongTrailingIdx - 2] >= inOpen[bodyLongTrailingIdx - 2] ? inOpen[bodyLongTrailingIdx - 2] : inClose[bodyLongTrailingIdx - 2];
                        num31 = inHigh[bodyLongTrailingIdx - 2] - num33 + (num32 - inLow[bodyLongTrailingIdx - 2]);
                    }
                    else
                    {
                        num31 = 0.0;
                    }

                    num34 = num31;
                }

                num35 = num34;
            }

            bodyLongPeriodTotal += num40 - num35;
            if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
            {
                num30 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num29;
                if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                {
                    num29 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num26;
                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                    {
                        double num28 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                        double num27 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                        num26 = inHigh[i - 2] - num28 + (num27 - inLow[i - 2]);
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
                num25 = Math.Abs(inClose[shadowLongTrailingIdx - 2] - inOpen[shadowLongTrailingIdx - 2]);
            }
            else
            {
                double num24;
                if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                {
                    num24 = inHigh[shadowLongTrailingIdx - 2] - inLow[shadowLongTrailingIdx - 2];
                }
                else
                {
                    double num21;
                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                    {
                        double num23 = inClose[shadowLongTrailingIdx - 2] >= inOpen[shadowLongTrailingIdx - 2] ? inClose[shadowLongTrailingIdx - 2] : inOpen[shadowLongTrailingIdx - 2];
                        double num22 = inClose[shadowLongTrailingIdx - 2] >= inOpen[shadowLongTrailingIdx - 2] ? inOpen[shadowLongTrailingIdx - 2] : inClose[shadowLongTrailingIdx - 2];
                        num21 = inHigh[shadowLongTrailingIdx - 2] - num23 + (num22 - inLow[shadowLongTrailingIdx - 2]);
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
            for (int totIdx = 1; totIdx >= 0; totIdx--)
            {
                double num15;
                double num20;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num20 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num19;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num19 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num16;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num18 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inClose[i - totIdx] : inOpen[i - totIdx];
                            double num17 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inOpen[i - totIdx] : inClose[i - totIdx];
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

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num15 = Math.Abs(
                        inClose[shadowVeryShortTrailingIdx - totIdx]
                        - inOpen[shadowVeryShortTrailingIdx - totIdx]);
                }
                else
                {
                    double num14;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num14 = inHigh[shadowVeryShortTrailingIdx - totIdx]
                                - inLow[shadowVeryShortTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num11;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num13 = inClose[shadowVeryShortTrailingIdx - totIdx] >= inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inClose[shadowVeryShortTrailingIdx - totIdx]
                                : inOpen[shadowVeryShortTrailingIdx - totIdx];

                            double num12 = inClose[shadowVeryShortTrailingIdx - totIdx] >= inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inOpen[shadowVeryShortTrailingIdx - totIdx]
                                : inClose[shadowVeryShortTrailingIdx - totIdx];

                            num11 = inHigh[shadowVeryShortTrailingIdx - totIdx] - num13
                                    + (num12 - inLow[shadowVeryShortTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num11 = 0.0;
                        }

                        num14 = num11;
                    }

                    num15 = num14;
                }

                shadowVeryShortPeriodTotal[totIdx] += num20 - num15;
            }

            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        double num8 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                        double num7 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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
            shadowLongTrailingIdx++;
            shadowVeryShortTrailingIdx++;
            bodyShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_052C;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int Cdl3StarsInSouthLookback()
        {
            int num;
            int avgPeriod = Globals.candleSettings[0].avgPeriod > Globals.candleSettings[2].avgPeriod
                ? Globals.candleSettings[0].avgPeriod
                : Globals.candleSettings[2].avgPeriod;

            if ((Globals.candleSettings[7].avgPeriod <= Globals.candleSettings[4].avgPeriod
                     ? Globals.candleSettings[4].avgPeriod
                     : Globals.candleSettings[7].avgPeriod) > avgPeriod)
            {
                num = Globals.candleSettings[7].avgPeriod <= Globals.candleSettings[4].avgPeriod
                    ? Globals.candleSettings[4].avgPeriod
                    : Globals.candleSettings[7].avgPeriod;
            }
            else
            {
                num = Globals.candleSettings[0].avgPeriod <= Globals.candleSettings[2].avgPeriod
                    ? Globals.candleSettings[2].avgPeriod
                    : Globals.candleSettings[0].avgPeriod;
            }

            return num + 2;
        }
    }
}
