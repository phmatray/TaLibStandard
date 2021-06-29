namespace TechnicalAnalysis
{
    using System;

    internal static partial class TACore
    {
        public static RetCode Cdl3WhiteSoldiers(
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
            double[] shadowVeryShortPeriodTotal = new double[3];
            double[] nearPeriodTotal = new double[3];
            double[] farPeriodTotal = new double[3];
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

            int lookbackTotal = Cdl3WhiteSoldiersLookback();
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
            nearPeriodTotal[2] = 0.0;
            nearPeriodTotal[1] = 0.0;
            nearPeriodTotal[0] = 0.0;
            int nearTrailingIdx = startIdx - Globals.candleSettings[8].avgPeriod;
            farPeriodTotal[2] = 0.0;
            farPeriodTotal[1] = 0.0;
            farPeriodTotal[0] = 0.0;
            int farTrailingIdx = startIdx - Globals.candleSettings[9].avgPeriod;
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - Globals.candleSettings[2].avgPeriod;
            int i = shadowVeryShortTrailingIdx;
            while (true)
            {
                double num129;
                double num134;
                double num139;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num139 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num138;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num138 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num135;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num137 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num136 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num135 = inHigh[i - 2] - num137 + (num136 - inLow[i - 2]);
                        }
                        else
                        {
                            num135 = 0.0;
                        }

                        num138 = num135;
                    }

                    num139 = num138;
                }

                shadowVeryShortPeriodTotal[2] += num139;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num134 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num133;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num133 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num130;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num132 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                            double num131 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                            num130 = inHigh[i - 1] - num132 + (num131 - inLow[i - 1]);
                        }
                        else
                        {
                            num130 = 0.0;
                        }

                        num133 = num130;
                    }

                    num134 = num133;
                }

                shadowVeryShortPeriodTotal[1] += num134;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num129 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num128;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num128 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num125;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num127 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num126 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num125 = inHigh[i] - num127 + (num126 - inLow[i]);
                        }
                        else
                        {
                            num125 = 0.0;
                        }

                        num128 = num125;
                    }

                    num129 = num128;
                }

                shadowVeryShortPeriodTotal[0] += num129;
                i++;
            }

            i = nearTrailingIdx;
            while (true)
            {
                double num119;
                double num124;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num124 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num123;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num123 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num120;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num122 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num121 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num120 = inHigh[i - 2] - num122 + (num121 - inLow[i - 2]);
                        }
                        else
                        {
                            num120 = 0.0;
                        }

                        num123 = num120;
                    }

                    num124 = num123;
                }

                nearPeriodTotal[2] += num124;
                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num119 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num118;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num118 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num115;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num117 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                            double num116 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                            num115 = inHigh[i - 1] - num117 + (num116 - inLow[i - 1]);
                        }
                        else
                        {
                            num115 = 0.0;
                        }

                        num118 = num115;
                    }

                    num119 = num118;
                }

                nearPeriodTotal[1] += num119;
                i++;
            }

            i = farTrailingIdx;
            while (true)
            {
                double num109;
                double num114;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                {
                    num114 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num113;
                    if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                    {
                        num113 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num110;
                        if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                        {
                            double num112 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num111 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num110 = inHigh[i - 2] - num112 + (num111 - inLow[i - 2]);
                        }
                        else
                        {
                            num110 = 0.0;
                        }

                        num113 = num110;
                    }

                    num114 = num113;
                }

                farPeriodTotal[2] += num114;
                if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                {
                    num109 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num108;
                    if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                    {
                        num108 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num105;
                        if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                        {
                            double num107 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                            double num106 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                            num105 = inHigh[i - 1] - num107 + (num106 - inLow[i - 1]);
                        }
                        else
                        {
                            num105 = 0.0;
                        }

                        num108 = num105;
                    }

                    num109 = num108;
                }

                farPeriodTotal[1] += num109;
                i++;
            }

            i = bodyShortTrailingIdx;
            while (true)
            {
                double num104;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                {
                    num104 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num103;
                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                    {
                        num103 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num100;
                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                        {
                            double num102 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num101 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num100 = inHigh[i] - num102 + (num101 - inLow[i]);
                        }
                        else
                        {
                            num100 = 0.0;
                        }

                        num103 = num100;
                    }

                    num104 = num103;
                }

                bodyShortPeriodTotal += num104;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_08A5:
            if (inClose[i - 2] >= inOpen[i - 2])
            {
                double num98;
                double num99 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];

                if (Globals.candleSettings[7].avgPeriod != 0.0)
                {
                    num98 = shadowVeryShortPeriodTotal[2] / Globals.candleSettings[7].avgPeriod;
                }
                else
                {
                    double num97;
                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                    {
                        num97 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num96;
                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                        {
                            num96 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num93;
                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                            {
                                double num95 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                double num94 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                num93 = inHigh[i - 2] - num95 + (num94 - inLow[i - 2]);
                            }
                            else
                            {
                                num93 = 0.0;
                            }

                            num96 = num93;
                        }

                        num97 = num96;
                    }

                    num98 = num97;
                }

                double num92 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (inHigh[i - 2] - num99 < Globals.candleSettings[7].factor * num98 / num92
                    && inClose[i - 1] >= inOpen[i - 1])
                {
                    double num90;
                    double num91 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];

                    if (Globals.candleSettings[7].avgPeriod != 0.0)
                    {
                        num90 = shadowVeryShortPeriodTotal[1] / Globals.candleSettings[7].avgPeriod;
                    }
                    else
                    {
                        double num89;
                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                        {
                            num89 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num88;
                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                            {
                                num88 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num85;
                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    double num87 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                    double num86 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                    num85 = inHigh[i - 1] - num87 + (num86 - inLow[i - 1]);
                                }
                                else
                                {
                                    num85 = 0.0;
                                }

                                num88 = num85;
                            }

                            num89 = num88;
                        }

                        num90 = num89;
                    }

                    double num84 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                    if (inHigh[i - 1] - num91 < Globals.candleSettings[7].factor * num90 / num84
                        && inClose[i] >= inOpen[i])
                    {
                        double num82;
                        double num83 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];

                        if (Globals.candleSettings[7].avgPeriod != 0.0)
                        {
                            num82 = shadowVeryShortPeriodTotal[0] / Globals.candleSettings[7].avgPeriod;
                        }
                        else
                        {
                            double num81;
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

                            num82 = num81;
                        }

                        double num76 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                        if (inHigh[i] - num83 < Globals.candleSettings[7].factor * num82 / num76
                            && inClose[i] > inClose[i - 1] && inClose[i - 1] > inClose[i - 2] &&
                            inOpen[i - 1] > inOpen[i - 2])
                        {
                            double num75;
                            if (Globals.candleSettings[8].avgPeriod != 0.0)
                            {
                                num75 = nearPeriodTotal[2] / Globals.candleSettings[8].avgPeriod;
                            }
                            else
                            {
                                double num74;
                                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                                {
                                    num74 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                                }
                                else
                                {
                                    double num73;
                                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                    {
                                        num73 = inHigh[i - 2] - inLow[i - 2];
                                    }
                                    else
                                    {
                                        double num70;
                                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                        {
                                            double num72 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                            double num71 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                            num70 = inHigh[i - 2] - num72 + (num71 - inLow[i - 2]);
                                        }
                                        else
                                        {
                                            num70 = 0.0;
                                        }

                                        num73 = num70;
                                    }

                                    num74 = num73;
                                }

                                num75 = num74;
                            }

                            double num69 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                            if (inOpen[i - 1]
                                <= inClose[i - 2] + Globals.candleSettings[8].factor * num75 / num69
                                && inOpen[i] > inOpen[i - 1])
                            {
                                double num68;
                                if (Globals.candleSettings[8].avgPeriod != 0.0)
                                {
                                    num68 = nearPeriodTotal[1] / Globals.candleSettings[8].avgPeriod;
                                }
                                else
                                {
                                    double num67;
                                    if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                                    {
                                        num67 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                                    }
                                    else
                                    {
                                        double num66;
                                        if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                        {
                                            num66 = inHigh[i - 1] - inLow[i - 1];
                                        }
                                        else
                                        {
                                            double num63;
                                            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                            {
                                                double num65 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                                double num64 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                                num63 = inHigh[i - 1] - num65 + (num64 - inLow[i - 1]);
                                            }
                                            else
                                            {
                                                num63 = 0.0;
                                            }

                                            num66 = num63;
                                        }

                                        num67 = num66;
                                    }

                                    num68 = num67;
                                }

                                double num62 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                if (inOpen[i] <= inClose[i - 1]
                                    + Globals.candleSettings[8].factor * num68 / num62)
                                {
                                    double num61;
                                    if (Globals.candleSettings[9].avgPeriod != 0.0)
                                    {
                                        num61 = farPeriodTotal[2] / Globals.candleSettings[9].avgPeriod;
                                    }
                                    else
                                    {
                                        double num60;
                                        if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                                        {
                                            num60 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                                        }
                                        else
                                        {
                                            double num59;
                                            if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                                            {
                                                num59 = inHigh[i - 2] - inLow[i - 2];
                                            }
                                            else
                                            {
                                                double num56;
                                                if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                                                {
                                                    double num58 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                                    double num57 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                                    num56 = inHigh[i - 2] - num58 + (num57 - inLow[i - 2]);
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

                                    double num55 = Globals.candleSettings[9].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                    if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                                        > Math.Abs(inClose[i - 2] - inOpen[i - 2])
                                        - Globals.candleSettings[9].factor * num61 / num55)
                                    {
                                        double num54;
                                        if (Globals.candleSettings[9].avgPeriod != 0.0)
                                        {
                                            num54 = farPeriodTotal[1] / Globals.candleSettings[9].avgPeriod;
                                        }
                                        else
                                        {
                                            double num53;
                                            if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                                            {
                                                num53 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                                            }
                                            else
                                            {
                                                double num52;
                                                if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                                                {
                                                    num52 = inHigh[i - 1] - inLow[i - 1];
                                                }
                                                else
                                                {
                                                    double num49;
                                                    if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                                                    {
                                                        double num51 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                                        double num50 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                                        num49 = inHigh[i - 1] - num51 + (num50 - inLow[i - 1]);
                                                    }
                                                    else
                                                    {
                                                        num49 = 0.0;
                                                    }

                                                    num52 = num49;
                                                }

                                                num53 = num52;
                                            }

                                            num54 = num53;
                                        }

                                        double num48 = Globals.candleSettings[9].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                        if (Math.Abs(inClose[i] - inOpen[i])
                                            > Math.Abs(inClose[i - 1] - inOpen[i - 1])
                                            - Globals.candleSettings[9].factor * num54 / num48)
                                        {
                                            double num47;
                                            if (Globals.candleSettings[2].avgPeriod != 0.0)
                                            {
                                                num47 = bodyShortPeriodTotal
                                                        / Globals.candleSettings[2].avgPeriod;
                                            }
                                            else
                                            {
                                                double num46;
                                                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                                                {
                                                    num46 = Math.Abs(inClose[i] - inOpen[i]);
                                                }
                                                else
                                                {
                                                    double num45;
                                                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                                                    {
                                                        num45 = inHigh[i] - inLow[i];
                                                    }
                                                    else
                                                    {
                                                        double num42;
                                                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
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

                                            double num41 = Globals.candleSettings[2].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                            if (Math.Abs(inClose[i] - inOpen[i])
                                                > Globals.candleSettings[2].factor * num47 / num41)
                                            {
                                                outInteger[outIdx] = 100;
                                                outIdx++;
                                                goto Label_1465;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_1465:
            int totIdx = 2;
            while (totIdx >= 0)
            {
                double num35;
                double num40;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num40 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num39;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num39 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num36;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num38 = inClose[i - totIdx] >= inOpen[i - totIdx]
                                ? inClose[i - totIdx]
                                : inOpen[i - totIdx];
                            double num37 = inClose[i - totIdx] >= inOpen[i - totIdx]
                                ? inOpen[i - totIdx]
                                : inClose[i - totIdx];
                            num36 = inHigh[i - totIdx] - num38 + (num37 - inLow[i - totIdx]);
                        }
                        else
                        {
                            num36 = 0.0;
                        }

                        num39 = num36;
                    }

                    num40 = num39;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num35 = Math.Abs(
                        inClose[shadowVeryShortTrailingIdx - totIdx]
                        - inOpen[shadowVeryShortTrailingIdx - totIdx]);
                }
                else
                {
                    double num34;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num34 = inHigh[shadowVeryShortTrailingIdx - totIdx]
                                - inLow[shadowVeryShortTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num31;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num33 = inClose[shadowVeryShortTrailingIdx - totIdx] >= inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inClose[shadowVeryShortTrailingIdx - totIdx]
                                : inOpen[shadowVeryShortTrailingIdx - totIdx];

                            double num32 = inClose[shadowVeryShortTrailingIdx - totIdx] >= inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inOpen[shadowVeryShortTrailingIdx - totIdx]
                                : inClose[shadowVeryShortTrailingIdx - totIdx];

                            num31 = inHigh[shadowVeryShortTrailingIdx - totIdx] - num33
                                    + (num32 - inLow[shadowVeryShortTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num31 = 0.0;
                        }

                        num34 = num31;
                    }

                    num35 = num34;
                }

                shadowVeryShortPeriodTotal[totIdx] += num40 - num35;
                totIdx--;
            }

            for (totIdx = 2; totIdx >= 1; totIdx--)
            {
                double num15;
                double num20;
                double num25;
                double num30;
                if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                {
                    num30 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num29;
                    if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                    {
                        num29 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num26;
                        if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                        {
                            double num28 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inClose[i - totIdx] : inOpen[i - totIdx];
                            double num27 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inOpen[i - totIdx] : inClose[i - totIdx];
                            num26 = inHigh[i - totIdx] - num28 + (num27 - inLow[i - totIdx]);
                        }
                        else
                        {
                            num26 = 0.0;
                        }

                        num29 = num26;
                    }

                    num30 = num29;
                }

                if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                {
                    num25 = Math.Abs(inClose[farTrailingIdx - totIdx] - inOpen[farTrailingIdx - totIdx]);
                }
                else
                {
                    double num24;
                    if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                    {
                        num24 = inHigh[farTrailingIdx - totIdx] - inLow[farTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num21;
                        if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                        {
                            double num23 = inClose[farTrailingIdx - totIdx] >= inOpen[farTrailingIdx - totIdx] ? inClose[farTrailingIdx - totIdx] : inOpen[farTrailingIdx - totIdx];
                            double num22 = inClose[farTrailingIdx - totIdx] >= inOpen[farTrailingIdx - totIdx] ? inOpen[farTrailingIdx - totIdx] : inClose[farTrailingIdx - totIdx];
                            num21 = inHigh[farTrailingIdx - totIdx] - num23 + (num22 - inLow[farTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num21 = 0.0;
                        }

                        num24 = num21;
                    }

                    num25 = num24;
                }

                farPeriodTotal[totIdx] += num30 - num25;
                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num20 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num19;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num19 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num16;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
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

                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num15 = Math.Abs(inClose[nearTrailingIdx - totIdx] - inOpen[nearTrailingIdx - totIdx]);
                }
                else
                {
                    double num14;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num14 = inHigh[nearTrailingIdx - totIdx] - inLow[nearTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num11;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num13 = inClose[nearTrailingIdx - totIdx] >= inOpen[nearTrailingIdx - totIdx] ? inClose[nearTrailingIdx - totIdx] : inOpen[nearTrailingIdx - totIdx];
                            double num12 = inClose[nearTrailingIdx - totIdx] >= inOpen[nearTrailingIdx - totIdx] ? inOpen[nearTrailingIdx - totIdx] : inClose[nearTrailingIdx - totIdx];
                            num11 = inHigh[nearTrailingIdx - totIdx] - num13 + (num12 - inLow[nearTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num11 = 0.0;
                        }

                        num14 = num11;
                    }

                    num15 = num14;
                }

                nearPeriodTotal[totIdx] += num20 - num15;
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
            shadowVeryShortTrailingIdx++;
            nearTrailingIdx++;
            farTrailingIdx++;
            bodyShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_08A5;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int Cdl3WhiteSoldiersLookback()
        {
            int num;
            int avgPeriod = Globals.candleSettings[9].avgPeriod > Globals.candleSettings[8].avgPeriod ? Globals.candleSettings[9].avgPeriod : Globals.candleSettings[8].avgPeriod;

            if ((Globals.candleSettings[7].avgPeriod <= Globals.candleSettings[2].avgPeriod
                ? Globals.candleSettings[2].avgPeriod
                : Globals.candleSettings[7].avgPeriod) > avgPeriod)
            {
                num = Globals.candleSettings[7].avgPeriod <= Globals.candleSettings[2].avgPeriod
                    ? Globals.candleSettings[2].avgPeriod
                    : Globals.candleSettings[7].avgPeriod;
            }
            else
            {
                num = Globals.candleSettings[9].avgPeriod <= Globals.candleSettings[8].avgPeriod
                    ? Globals.candleSettings[8].avgPeriod
                    : Globals.candleSettings[9].avgPeriod;
            }

            return num + 2;
        }
    }
}
