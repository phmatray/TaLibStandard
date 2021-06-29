namespace TechnicalAnalysis
{
    using System;

    internal partial class TACore
    {
        public static RetCode CdlRickshawMan(
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
            double num63;
            double num69;
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

            int lookbackTotal = CdlRickshawManLookback();
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
            double nearPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - Globals.candleSettings[8].avgPeriod;
            int i = bodyDojiTrailingIdx;
            while (true)
            {
                double num84;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
                {
                    num84 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num83;
                    if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                    {
                        num83 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num80;
                        if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                        {
                            double num81;
                            double num82;
                            if (inClose[i] >= inOpen[i])
                            {
                                num82 = inClose[i];
                            }
                            else
                            {
                                num82 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num81 = inOpen[i];
                            }
                            else
                            {
                                num81 = inClose[i];
                            }

                            num80 = inHigh[i] - num82 + (num81 - inLow[i]);
                        }
                        else
                        {
                            num80 = 0.0;
                        }

                        num83 = num80;
                    }

                    num84 = num83;
                }

                bodyDojiPeriodTotal += num84;
                i++;
            }

            i = shadowLongTrailingIdx;
            while (true)
            {
                double num79;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                {
                    num79 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num78;
                    if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                    {
                        num78 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num75;
                        if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                        {
                            double num76;
                            double num77;
                            if (inClose[i] >= inOpen[i])
                            {
                                num77 = inClose[i];
                            }
                            else
                            {
                                num77 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num76 = inOpen[i];
                            }
                            else
                            {
                                num76 = inClose[i];
                            }

                            num75 = inHigh[i] - num77 + (num76 - inLow[i]);
                        }
                        else
                        {
                            num75 = 0.0;
                        }

                        num78 = num75;
                    }

                    num79 = num78;
                }

                shadowLongPeriodTotal += num79;
                i++;
            }

            i = nearTrailingIdx;
            while (true)
            {
                double num74;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num74 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num73;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num73 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num70;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num71;
                            double num72;
                            if (inClose[i] >= inOpen[i])
                            {
                                num72 = inClose[i];
                            }
                            else
                            {
                                num72 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num71 = inOpen[i];
                            }
                            else
                            {
                                num71 = inClose[i];
                            }

                            num70 = inHigh[i] - num72 + (num71 - inLow[i]);
                        }
                        else
                        {
                            num70 = 0.0;
                        }

                        num73 = num70;
                    }

                    num74 = num73;
                }

                nearPeriodTotal += num74;
                i++;
            }

            int outIdx = 0;
            Label_0313:
            if (Globals.candleSettings[3].avgPeriod != 0.0)
            {
                num69 = bodyDojiPeriodTotal / Globals.candleSettings[3].avgPeriod;
            }
            else
            {
                double num68;
                if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
                {
                    num68 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num67;
                    if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                    {
                        num67 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num64;
                        if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                        {
                            double num65;
                            double num66;
                            if (inClose[i] >= inOpen[i])
                            {
                                num66 = inClose[i];
                            }
                            else
                            {
                                num66 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num65 = inOpen[i];
                            }
                            else
                            {
                                num65 = inClose[i];
                            }

                            num64 = inHigh[i] - num66 + (num65 - inLow[i]);
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

            if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
            {
                num63 = 2.0;
            }
            else
            {
                num63 = 1.0;
            }

            if (Math.Abs(inClose[i] - inOpen[i]) <= Globals.candleSettings[3].factor * num69 / num63)
            {
                double num55;
                double num61;
                double num62;
                if (inClose[i] >= inOpen[i])
                {
                    num62 = inOpen[i];
                }
                else
                {
                    num62 = inClose[i];
                }

                if (Globals.candleSettings[4].avgPeriod != 0.0)
                {
                    num61 = shadowLongPeriodTotal / Globals.candleSettings[4].avgPeriod;
                }
                else
                {
                    double num60;
                    if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                    {
                        num60 = Math.Abs(inClose[i] - inOpen[i]);
                    }
                    else
                    {
                        double num59;
                        if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                        {
                            num59 = inHigh[i] - inLow[i];
                        }
                        else
                        {
                            double num56;
                            if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                            {
                                double num57;
                                double num58;
                                if (inClose[i] >= inOpen[i])
                                {
                                    num58 = inClose[i];
                                }
                                else
                                {
                                    num58 = inOpen[i];
                                }

                                if (inClose[i] >= inOpen[i])
                                {
                                    num57 = inOpen[i];
                                }
                                else
                                {
                                    num57 = inClose[i];
                                }

                                num56 = inHigh[i] - num58 + (num57 - inLow[i]);
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

                if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                {
                    num55 = 2.0;
                }
                else
                {
                    num55 = 1.0;
                }

                if (num62 - inLow[i] > Globals.candleSettings[4].factor * num61 / num55)
                {
                    double num47;
                    double num53;
                    double num54;
                    if (inClose[i] >= inOpen[i])
                    {
                        num54 = inClose[i];
                    }
                    else
                    {
                        num54 = inOpen[i];
                    }

                    if (Globals.candleSettings[4].avgPeriod != 0.0)
                    {
                        num53 = shadowLongPeriodTotal / Globals.candleSettings[4].avgPeriod;
                    }
                    else
                    {
                        double num52;
                        if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                        {
                            num52 = Math.Abs(inClose[i] - inOpen[i]);
                        }
                        else
                        {
                            double num51;
                            if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                            {
                                num51 = inHigh[i] - inLow[i];
                            }
                            else
                            {
                                double num48;
                                if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                                {
                                    double num49;
                                    double num50;
                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num50 = inClose[i];
                                    }
                                    else
                                    {
                                        num50 = inOpen[i];
                                    }

                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num49 = inOpen[i];
                                    }
                                    else
                                    {
                                        num49 = inClose[i];
                                    }

                                    num48 = inHigh[i] - num50 + (num49 - inLow[i]);
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

                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                    {
                        num47 = 2.0;
                    }
                    else
                    {
                        num47 = 1.0;
                    }

                    if (inHigh[i] - num54 > Globals.candleSettings[4].factor * num53 / num47)
                    {
                        double num39;
                        double num45;
                        double num46;
                        if (inOpen[i] < inClose[i])
                        {
                            num46 = inOpen[i];
                        }
                        else
                        {
                            num46 = inClose[i];
                        }

                        if (Globals.candleSettings[8].avgPeriod != 0.0)
                        {
                            num45 = nearPeriodTotal / Globals.candleSettings[8].avgPeriod;
                        }
                        else
                        {
                            double num44;
                            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                            {
                                num44 = Math.Abs(inClose[i] - inOpen[i]);
                            }
                            else
                            {
                                double num43;
                                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                {
                                    num43 = inHigh[i] - inLow[i];
                                }
                                else
                                {
                                    double num40;
                                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                    {
                                        double num41;
                                        double num42;
                                        if (inClose[i] >= inOpen[i])
                                        {
                                            num42 = inClose[i];
                                        }
                                        else
                                        {
                                            num42 = inOpen[i];
                                        }

                                        if (inClose[i] >= inOpen[i])
                                        {
                                            num41 = inOpen[i];
                                        }
                                        else
                                        {
                                            num41 = inClose[i];
                                        }

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

                            num45 = num44;
                        }

                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            num39 = 2.0;
                        }
                        else
                        {
                            num39 = 1.0;
                        }

                        if (num46 <= inLow[i] + (inHigh[i] - inLow[i]) / 2.0
                                              + Globals.candleSettings[8].factor * num45 / num39)
                        {
                            double num31;
                            double num37;
                            double num38;
                            if (inOpen[i] > inClose[i])
                            {
                                num38 = inOpen[i];
                            }
                            else
                            {
                                num38 = inClose[i];
                            }

                            if (Globals.candleSettings[8].avgPeriod != 0.0)
                            {
                                num37 = nearPeriodTotal / Globals.candleSettings[8].avgPeriod;
                            }
                            else
                            {
                                double num36;
                                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                                {
                                    num36 = Math.Abs(inClose[i] - inOpen[i]);
                                }
                                else
                                {
                                    double num35;
                                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                    {
                                        num35 = inHigh[i] - inLow[i];
                                    }
                                    else
                                    {
                                        double num32;
                                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                        {
                                            double num33;
                                            double num34;
                                            if (inClose[i] >= inOpen[i])
                                            {
                                                num34 = inClose[i];
                                            }
                                            else
                                            {
                                                num34 = inOpen[i];
                                            }

                                            if (inClose[i] >= inOpen[i])
                                            {
                                                num33 = inOpen[i];
                                            }
                                            else
                                            {
                                                num33 = inClose[i];
                                            }

                                            num32 = inHigh[i] - num34 + (num33 - inLow[i]);
                                        }
                                        else
                                        {
                                            num32 = 0.0;
                                        }

                                        num35 = num32;
                                    }

                                    num36 = num35;
                                }

                                num37 = num36;
                            }

                            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                            {
                                num31 = 2.0;
                            }
                            else
                            {
                                num31 = 1.0;
                            }

                            if (num38 >= inLow[i] + (inHigh[i] - inLow[i]) / 2.0
                                - Globals.candleSettings[8].factor * num37 / num31)
                            {
                                outInteger[outIdx] = 100;
                                outIdx++;
                                goto Label_09C6;
                            }
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_09C6:
            if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
            {
                num30 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num29;
                if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                {
                    num29 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num26;
                    if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
            {
                num25 = Math.Abs(inClose[bodyDojiTrailingIdx] - inOpen[bodyDojiTrailingIdx]);
            }
            else
            {
                double num24;
                if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                {
                    num24 = inHigh[bodyDojiTrailingIdx] - inLow[bodyDojiTrailingIdx];
                }
                else
                {
                    double num21;
                    if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                    {
                        double num22;
                        double num23;
                        if (inClose[bodyDojiTrailingIdx] >= inOpen[bodyDojiTrailingIdx])
                        {
                            num23 = inClose[bodyDojiTrailingIdx];
                        }
                        else
                        {
                            num23 = inOpen[bodyDojiTrailingIdx];
                        }

                        if (inClose[bodyDojiTrailingIdx] >= inOpen[bodyDojiTrailingIdx])
                        {
                            num22 = inOpen[bodyDojiTrailingIdx];
                        }
                        else
                        {
                            num22 = inClose[bodyDojiTrailingIdx];
                        }

                        num21 = inHigh[bodyDojiTrailingIdx] - num23 + (num22 - inLow[bodyDojiTrailingIdx]);
                    }
                    else
                    {
                        num21 = 0.0;
                    }

                    num24 = num21;
                }

                num25 = num24;
            }

            bodyDojiPeriodTotal += num30 - num25;
            if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
            {
                num15 = Math.Abs(inClose[shadowLongTrailingIdx] - inOpen[shadowLongTrailingIdx]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[shadowLongTrailingIdx] - inLow[shadowLongTrailingIdx];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                    {
                        double num12;
                        double num13;
                        if (inClose[shadowLongTrailingIdx] >= inOpen[shadowLongTrailingIdx])
                        {
                            num13 = inClose[shadowLongTrailingIdx];
                        }
                        else
                        {
                            num13 = inOpen[shadowLongTrailingIdx];
                        }

                        if (inClose[shadowLongTrailingIdx] >= inOpen[shadowLongTrailingIdx])
                        {
                            num12 = inOpen[shadowLongTrailingIdx];
                        }
                        else
                        {
                            num12 = inClose[shadowLongTrailingIdx];
                        }

                        num11 = inHigh[shadowLongTrailingIdx] - num13 + (num12 - inLow[shadowLongTrailingIdx]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            shadowLongPeriodTotal += num20 - num15;
            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
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
            bodyDojiTrailingIdx++;
            shadowLongTrailingIdx++;
            nearTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0313;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlRickshawManLookback()
        {
            if ((Globals.candleSettings[3].avgPeriod <= Globals.candleSettings[4].avgPeriod
                     ? Globals.candleSettings[4].avgPeriod
                     : Globals.candleSettings[3].avgPeriod) > Globals.candleSettings[8].avgPeriod)
            {
                return Globals.candleSettings[3].avgPeriod <= Globals.candleSettings[4].avgPeriod
                            ? Globals.candleSettings[4].avgPeriod
                            : Globals.candleSettings[3].avgPeriod;
            }

            return Globals.candleSettings[8].avgPeriod;
        }
    }
}
