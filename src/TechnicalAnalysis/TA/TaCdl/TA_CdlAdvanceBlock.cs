using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlAdvanceBlock(
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
            double num81;
            double num95;
            double num102;
            double num110;
            double num117;
            double num124;
            double[] shadowShortPeriodTotal = new double[3];
            double[] shadowLongPeriodTotal = new double[2];
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

            int lookbackTotal = CdlAdvanceBlockLookback();
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

            shadowShortPeriodTotal[2] = 0.0;
            shadowShortPeriodTotal[1] = 0.0;
            shadowShortPeriodTotal[0] = 0.0;
            int shadowShortTrailingIdx = startIdx - Globals.candleSettings[6].avgPeriod;
            shadowLongPeriodTotal[1] = 0.0;
            shadowLongPeriodTotal[0] = 0.0;
            int shadowLongTrailingIdx = startIdx - Globals.candleSettings[4].avgPeriod;
            nearPeriodTotal[2] = 0.0;
            nearPeriodTotal[1] = 0.0;
            nearPeriodTotal[0] = 0.0;
            int nearTrailingIdx = startIdx - Globals.candleSettings[8].avgPeriod;
            farPeriodTotal[2] = 0.0;
            farPeriodTotal[1] = 0.0;
            farPeriodTotal[0] = 0.0;
            int farTrailingIdx = startIdx - Globals.candleSettings[9].avgPeriod;
            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - Globals.candleSettings[0].avgPeriod;
            int i = shadowShortTrailingIdx;
            while (true)
            {
                double num164;
                double num169;
                double num174;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[6].rangeType == RangeType.RealBody)
                {
                    num174 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num173;
                    if (Globals.candleSettings[6].rangeType == RangeType.HighLow)
                    {
                        num173 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num170;
                        if (Globals.candleSettings[6].rangeType == RangeType.Shadows)
                        {
                            double num172 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num171 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num170 = inHigh[i - 2] - num172 + (num171 - inLow[i - 2]);
                        }
                        else
                        {
                            num170 = 0.0;
                        }

                        num173 = num170;
                    }

                    num174 = num173;
                }

                shadowShortPeriodTotal[2] += num174;
                if (Globals.candleSettings[6].rangeType == RangeType.RealBody)
                {
                    num169 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num168;
                    if (Globals.candleSettings[6].rangeType == RangeType.HighLow)
                    {
                        num168 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num165;
                        if (Globals.candleSettings[6].rangeType == RangeType.Shadows)
                        {
                            double num167 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                            double num166 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                            num165 = inHigh[i - 1] - num167 + (num166 - inLow[i - 1]);
                        }
                        else
                        {
                            num165 = 0.0;
                        }

                        num168 = num165;
                    }

                    num169 = num168;
                }

                shadowShortPeriodTotal[1] += num169;
                if (Globals.candleSettings[6].rangeType == RangeType.RealBody)
                {
                    num164 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num163;
                    if (Globals.candleSettings[6].rangeType == RangeType.HighLow)
                    {
                        num163 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num160;
                        if (Globals.candleSettings[6].rangeType == RangeType.Shadows)
                        {
                            double num162 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num161 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num160 = inHigh[i] - num162 + (num161 - inLow[i]);
                        }
                        else
                        {
                            num160 = 0.0;
                        }

                        num163 = num160;
                    }

                    num164 = num163;
                }

                shadowShortPeriodTotal[0] += num164;
                i++;
            }

            i = shadowLongTrailingIdx;
            while (true)
            {
                double num154;
                double num159;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                {
                    num159 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num158;
                    if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                    {
                        num158 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num155;
                        if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                        {
                            double num157 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                            double num156 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                            num155 = inHigh[i - 1] - num157 + (num156 - inLow[i - 1]);
                        }
                        else
                        {
                            num155 = 0.0;
                        }

                        num158 = num155;
                    }

                    num159 = num158;
                }

                shadowLongPeriodTotal[1] += num159;
                if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                {
                    num154 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num153;
                    if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                    {
                        num153 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num150;
                        if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                        {
                            double num152 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num151 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num150 = inHigh[i] - num152 + (num151 - inLow[i]);
                        }
                        else
                        {
                            num150 = 0.0;
                        }

                        num153 = num150;
                    }

                    num154 = num153;
                }

                shadowLongPeriodTotal[0] += num154;
                i++;
            }

            i = nearTrailingIdx;
            while (true)
            {
                double num144;
                double num149;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num149 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num148;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num148 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num145;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num147 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num146 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num145 = inHigh[i - 2] - num147 + (num146 - inLow[i - 2]);
                        }
                        else
                        {
                            num145 = 0.0;
                        }

                        num148 = num145;
                    }

                    num149 = num148;
                }

                nearPeriodTotal[2] += num149;
                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num144 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num143;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num143 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num140;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num142 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                            double num141 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                            num140 = inHigh[i - 1] - num142 + (num141 - inLow[i - 1]);
                        }
                        else
                        {
                            num140 = 0.0;
                        }

                        num143 = num140;
                    }

                    num144 = num143;
                }

                nearPeriodTotal[1] += num144;
                i++;
            }

            i = farTrailingIdx;
            while (true)
            {
                double num134;
                double num139;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                {
                    num139 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num138;
                    if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                    {
                        num138 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num135;
                        if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
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

                farPeriodTotal[2] += num139;
                if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                {
                    num134 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num133;
                    if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                    {
                        num133 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num130;
                        if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
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

                farPeriodTotal[1] += num134;
                i++;
            }

            i = bodyLongTrailingIdx;
            while (true)
            {
                double num129;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num129 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num128;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num128 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num125;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num127 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num126 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num125 = inHigh[i - 2] - num127 + (num126 - inLow[i - 2]);
                        }
                        else
                        {
                            num125 = 0.0;
                        }

                        num128 = num125;
                    }

                    num129 = num128;
                }

                bodyLongPeriodTotal += num129;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_0B40:
            if (inClose[i - 2] < inOpen[i - 2] || inClose[i - 1] < inOpen[i - 1] || inClose[i] < inOpen[i] || inClose[i] <= inClose[i - 1] || inClose[i - 1] <= inClose[i - 2] || inOpen[i - 1] <= inOpen[i - 2])
            {
                goto Label_1A80;
            }

            if (Globals.candleSettings[8].avgPeriod != 0.0)
            {
                num124 = nearPeriodTotal[2] / Globals.candleSettings[8].avgPeriod;
            }
            else
            {
                double num123;
                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num123 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num122;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num122 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num119;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num121 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num120 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num119 = inHigh[i - 2] - num121 + (num120 - inLow[i - 2]);
                        }
                        else
                        {
                            num119 = 0.0;
                        }

                        num122 = num119;
                    }

                    num123 = num122;
                }

                num124 = num123;
            }

            double num118 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (inOpen[i - 1] > inClose[i - 2] + Globals.candleSettings[8].factor * num124 / num118
                || inOpen[i] <= inOpen[i - 1])
            {
                goto Label_1A80;
            }

            if (Globals.candleSettings[8].avgPeriod != 0.0)
            {
                num117 = nearPeriodTotal[1] / Globals.candleSettings[8].avgPeriod;
            }
            else
            {
                double num116;
                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num116 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num115;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num115 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num112;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num114 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                            double num113 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                            num112 = inHigh[i - 1] - num114 + (num113 - inLow[i - 1]);
                        }
                        else
                        {
                            num112 = 0.0;
                        }

                        num115 = num112;
                    }

                    num116 = num115;
                }

                num117 = num116;
            }

            double num111 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (inOpen[i] > inClose[i - 1] + Globals.candleSettings[8].factor * num117 / num111)
            {
                goto Label_1A80;
            }

            if (Globals.candleSettings[0].avgPeriod != 0.0)
            {
                num110 = bodyLongPeriodTotal / Globals.candleSettings[0].avgPeriod;
            }
            else
            {
                double num109;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num109 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num108;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num108 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num105;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num107 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num106 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num105 = inHigh[i - 2] - num107 + (num106 - inLow[i - 2]);
                        }
                        else
                        {
                            num105 = 0.0;
                        }

                        num108 = num105;
                    }

                    num109 = num108;
                }

                num110 = num109;
            }

            double num104 = Globals.candleSettings[0].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                <= Globals.candleSettings[0].factor * num110 / num104)
            {
                goto Label_1A80;
            }

            double num103 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];

            if (Globals.candleSettings[6].avgPeriod != 0.0)
            {
                num102 = shadowShortPeriodTotal[2] / Globals.candleSettings[6].avgPeriod;
            }
            else
            {
                double num101;
                if (Globals.candleSettings[6].rangeType == RangeType.RealBody)
                {
                    num101 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num100;
                    if (Globals.candleSettings[6].rangeType == RangeType.HighLow)
                    {
                        num100 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num97;
                        if (Globals.candleSettings[6].rangeType == RangeType.Shadows)
                        {
                            double num99 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num98 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num97 = inHigh[i - 2] - num99 + (num98 - inLow[i - 2]);
                        }
                        else
                        {
                            num97 = 0.0;
                        }

                        num100 = num97;
                    }

                    num101 = num100;
                }

                num102 = num101;
            }

            double num96 = Globals.candleSettings[6].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (inHigh[i - 2] - num103 >= Globals.candleSettings[6].factor * num102 / num96)
            {
                goto Label_1A80;
            }

            if (Globals.candleSettings[9].avgPeriod != 0.0)
            {
                num95 = farPeriodTotal[2] / Globals.candleSettings[9].avgPeriod;
            }
            else
            {
                double num94;
                if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                {
                    num94 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num93;
                    if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                    {
                        num93 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num90;
                        if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                        {
                            double num92 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num91 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num90 = inHigh[i - 2] - num92 + (num91 - inLow[i - 2]);
                        }
                        else
                        {
                            num90 = 0.0;
                        }

                        num93 = num90;
                    }

                    num94 = num93;
                }

                num95 = num94;
            }

            double num89 = Globals.candleSettings[9].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                < Math.Abs(inClose[i - 2] - inOpen[i - 2])
                - Globals.candleSettings[9].factor * num95 / num89)
            {
                double num88;
                if (Globals.candleSettings[8].avgPeriod != 0.0)
                {
                    num88 = nearPeriodTotal[1] / Globals.candleSettings[8].avgPeriod;
                }
                else
                {
                    double num87;
                    if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                    {
                        num87 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num86;
                        if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                        {
                            num86 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num83;
                            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                            {
                                double num85 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                double num84 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                num83 = inHigh[i - 1] - num85 + (num84 - inLow[i - 1]);
                            }
                            else
                            {
                                num83 = 0.0;
                            }

                            num86 = num83;
                        }

                        num87 = num86;
                    }

                    num88 = num87;
                }

                double num82 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (Math.Abs(inClose[i] - inOpen[i])
                    < Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    + Globals.candleSettings[8].factor * num88 / num82)
                {
                    goto Label_1A71;
                }
            }

            if (Globals.candleSettings[9].avgPeriod != 0.0)
            {
                num81 = farPeriodTotal[1] / Globals.candleSettings[9].avgPeriod;
            }
            else
            {
                double num80;
                if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                {
                    num80 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                }
                else
                {
                    double num79;
                    if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                    {
                        num79 = inHigh[i - 1] - inLow[i - 1];
                    }
                    else
                    {
                        double num76;
                        if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                        {
                            double num78 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                            double num77 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
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

                num81 = num80;
            }

            double num75 = Globals.candleSettings[9].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (Math.Abs(inClose[i] - inOpen[i])
                >= Math.Abs(inClose[i - 1] - inOpen[i - 1])
                - Globals.candleSettings[9].factor * num81 / num75)
            {
                double num57;
                if (Math.Abs(inClose[i] - inOpen[i]) < Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    && Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    < Math.Abs(inClose[i - 2] - inOpen[i - 2]))
                {
                    double num65;
                    double num73;
                    double num74 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];

                    if (Globals.candleSettings[6].avgPeriod != 0.0)
                    {
                        num73 = shadowShortPeriodTotal[0] / Globals.candleSettings[6].avgPeriod;
                    }
                    else
                    {
                        double num72;
                        if (Globals.candleSettings[6].rangeType == RangeType.RealBody)
                        {
                            num72 = Math.Abs(inClose[i] - inOpen[i]);
                        }
                        else
                        {
                            double num71;
                            if (Globals.candleSettings[6].rangeType == RangeType.HighLow)
                            {
                                num71 = inHigh[i] - inLow[i];
                            }
                            else
                            {
                                double num68;
                                if (Globals.candleSettings[6].rangeType == RangeType.Shadows)
                                {
                                    double num70 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                    double num69 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                                    num68 = inHigh[i] - num70 + (num69 - inLow[i]);
                                }
                                else
                                {
                                    num68 = 0.0;
                                }

                                num71 = num68;
                            }

                            num72 = num71;
                        }

                        num73 = num72;
                    }

                    double num67 = Globals.candleSettings[6].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                    if (inHigh[i] - num74 > Globals.candleSettings[6].factor * num73 / num67)
                    {
                        goto Label_1A71;
                    }

                    double num66 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];

                    if (Globals.candleSettings[6].avgPeriod != 0.0)
                    {
                        num65 = shadowShortPeriodTotal[1] / Globals.candleSettings[6].avgPeriod;
                    }
                    else
                    {
                        double num64;
                        if (Globals.candleSettings[6].rangeType == RangeType.RealBody)
                        {
                            num64 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num63;
                            if (Globals.candleSettings[6].rangeType == RangeType.HighLow)
                            {
                                num63 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num60;
                                if (Globals.candleSettings[6].rangeType == RangeType.Shadows)
                                {
                                    double num62 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                    double num61 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                    num60 = inHigh[i - 1] - num62 + (num61 - inLow[i - 1]);
                                }
                                else
                                {
                                    num60 = 0.0;
                                }

                                num63 = num60;
                            }

                            num64 = num63;
                        }

                        num65 = num64;
                    }

                    double num59 = Globals.candleSettings[6].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                    if (inHigh[i - 1] - num66 > Globals.candleSettings[6].factor * num65 / num59)
                    {
                        goto Label_1A71;
                    }
                }

                if (Math.Abs(inClose[i] - inOpen[i]) >= Math.Abs(inClose[i - 1] - inOpen[i - 1]))
                {
                    goto Label_1A80;
                }

                double num58 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];

                if (Globals.candleSettings[4].avgPeriod != 0.0)
                {
                    num57 = shadowLongPeriodTotal[0] / Globals.candleSettings[4].avgPeriod;
                }
                else
                {
                    double num56;
                    if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                    {
                        num56 = Math.Abs(inClose[i] - inOpen[i]);
                    }
                    else
                    {
                        double num55;
                        if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                        {
                            num55 = inHigh[i] - inLow[i];
                        }
                        else
                        {
                            double num52;
                            if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                            {
                                double num54 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                double num53 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                                num52 = inHigh[i] - num54 + (num53 - inLow[i]);
                            }
                            else
                            {
                                num52 = 0.0;
                            }

                            num55 = num52;
                        }

                        num56 = num55;
                    }

                    num57 = num56;
                }

                double num51 = Globals.candleSettings[4].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (inHigh[i] - num58 <= Globals.candleSettings[4].factor * num57 / num51)
                {
                    goto Label_1A80;
                }
            }

            Label_1A71:
            outInteger[outIdx] = -100;
            outIdx++;
            goto Label_1A8C;
            Label_1A80:
            outInteger[outIdx] = 0;
            outIdx++;
            Label_1A8C:
            int totIdx = 2;
            while (totIdx >= 0)
            {
                double num45;
                double num50;
                if (Globals.candleSettings[6].rangeType == RangeType.RealBody)
                {
                    num50 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num49;
                    if (Globals.candleSettings[6].rangeType == RangeType.HighLow)
                    {
                        num49 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num46;
                        if (Globals.candleSettings[6].rangeType == RangeType.Shadows)
                        {
                            double num48 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inClose[i - totIdx] : inOpen[i - totIdx];
                            double num47 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inOpen[i - totIdx] : inClose[i - totIdx];
                            num46 = inHigh[i - totIdx] - num48 + (num47 - inLow[i - totIdx]);
                        }
                        else
                        {
                            num46 = 0.0;
                        }

                        num49 = num46;
                    }

                    num50 = num49;
                }

                if (Globals.candleSettings[6].rangeType == RangeType.RealBody)
                {
                    num45 = Math.Abs(
                        inClose[shadowShortTrailingIdx - totIdx] - inOpen[shadowShortTrailingIdx - totIdx]);
                }
                else
                {
                    double num44;
                    if (Globals.candleSettings[6].rangeType == RangeType.HighLow)
                    {
                        num44 = inHigh[shadowShortTrailingIdx - totIdx] - inLow[shadowShortTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num41;
                        if (Globals.candleSettings[6].rangeType == RangeType.Shadows)
                        {
                            double num43 = inClose[shadowShortTrailingIdx - totIdx] >= inOpen[shadowShortTrailingIdx - totIdx] ? inClose[shadowShortTrailingIdx - totIdx] : inOpen[shadowShortTrailingIdx - totIdx];
                            double num42 = inClose[shadowShortTrailingIdx - totIdx] >= inOpen[shadowShortTrailingIdx - totIdx] ? inOpen[shadowShortTrailingIdx - totIdx] : inClose[shadowShortTrailingIdx - totIdx];
                            num41 = inHigh[shadowShortTrailingIdx - totIdx] - num43 + (num42 - inLow[shadowShortTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num41 = 0.0;
                        }

                        num44 = num41;
                    }

                    num45 = num44;
                }

                shadowShortPeriodTotal[totIdx] += num50 - num45;
                totIdx--;
            }

            for (totIdx = 1; totIdx >= 0; totIdx--)
            {
                double num35;
                double num40;
                if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                {
                    num40 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num39;
                    if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                    {
                        num39 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num36;
                        if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                        {
                            double num38 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inClose[i - totIdx] : inOpen[i - totIdx];
                            double num37 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inOpen[i - totIdx] : inClose[i - totIdx];
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

                if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                {
                    num35 = Math.Abs(
                        inClose[shadowLongTrailingIdx - totIdx] - inOpen[shadowLongTrailingIdx - totIdx]);
                }
                else
                {
                    double num34;
                    if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                    {
                        num34 = inHigh[shadowLongTrailingIdx - totIdx] - inLow[shadowLongTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num31;
                        if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                        {
                            double num33 = inClose[shadowLongTrailingIdx - totIdx] >= inOpen[shadowLongTrailingIdx - totIdx] ? inClose[shadowLongTrailingIdx - totIdx] : inOpen[shadowLongTrailingIdx - totIdx];
                            double num32 = inClose[shadowLongTrailingIdx - totIdx] >= inOpen[shadowLongTrailingIdx - totIdx] ? inOpen[shadowLongTrailingIdx - totIdx] : inClose[shadowLongTrailingIdx - totIdx];
                            num31 = inHigh[shadowLongTrailingIdx - totIdx] - num33 + (num32 - inLow[shadowLongTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num31 = 0.0;
                        }

                        num34 = num31;
                    }

                    num35 = num34;
                }

                shadowLongPeriodTotal[totIdx] += num40 - num35;
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

            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[bodyLongTrailingIdx - 2] - inOpen[bodyLongTrailingIdx - 2]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[bodyLongTrailingIdx - 2] - inLow[bodyLongTrailingIdx - 2];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num3 = inClose[bodyLongTrailingIdx - 2] >= inOpen[bodyLongTrailingIdx - 2] ? inClose[bodyLongTrailingIdx - 2] : inOpen[bodyLongTrailingIdx - 2];
                        double num2 = inClose[bodyLongTrailingIdx - 2] >= inOpen[bodyLongTrailingIdx - 2] ? inOpen[bodyLongTrailingIdx - 2] : inClose[bodyLongTrailingIdx - 2];
                        num = inHigh[bodyLongTrailingIdx - 2] - num3 + (num2 - inLow[bodyLongTrailingIdx - 2]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            bodyLongPeriodTotal += num10 - num5;
            i++;
            shadowShortTrailingIdx++;
            shadowLongTrailingIdx++;
            nearTrailingIdx++;
            farTrailingIdx++;
            bodyLongTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0B40;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlAdvanceBlockLookback()
        {
            int num;
            int num4;
            int avgPeriod = Globals.candleSettings[9].avgPeriod > Globals.candleSettings[8].avgPeriod ? Globals.candleSettings[9].avgPeriod : Globals.candleSettings[8].avgPeriod;

            if ((Globals.candleSettings[4].avgPeriod <= Globals.candleSettings[6].avgPeriod
                     ? Globals.candleSettings[6].avgPeriod
                     : Globals.candleSettings[4].avgPeriod) > avgPeriod)
            {
                num4 = Globals.candleSettings[4].avgPeriod <= Globals.candleSettings[6].avgPeriod
                           ? Globals.candleSettings[6].avgPeriod
                           : Globals.candleSettings[4].avgPeriod;
            }
            else
            {
                num4 = Globals.candleSettings[9].avgPeriod <= Globals.candleSettings[8].avgPeriod
                           ? Globals.candleSettings[8].avgPeriod
                           : Globals.candleSettings[9].avgPeriod;
            }

            if (num4 > Globals.candleSettings[0].avgPeriod)
            {
                int num2;
                int num3 = Globals.candleSettings[9].avgPeriod > Globals.candleSettings[8].avgPeriod ? Globals.candleSettings[9].avgPeriod : Globals.candleSettings[8].avgPeriod;

                if ((Globals.candleSettings[4].avgPeriod <= Globals.candleSettings[6].avgPeriod
                         ? Globals.candleSettings[6].avgPeriod
                         : Globals.candleSettings[4].avgPeriod) > num3)
                {
                    num2 = Globals.candleSettings[4].avgPeriod <= Globals.candleSettings[6].avgPeriod
                               ? Globals.candleSettings[6].avgPeriod
                               : Globals.candleSettings[4].avgPeriod;
                }
                else
                {
                    num2 = Globals.candleSettings[9].avgPeriod <= Globals.candleSettings[8].avgPeriod
                               ? Globals.candleSettings[8].avgPeriod
                               : Globals.candleSettings[9].avgPeriod;
                }

                num = num2;
            }
            else
            {
                num = Globals.candleSettings[0].avgPeriod;
            }

            return num + 2;
        }
    }
}
