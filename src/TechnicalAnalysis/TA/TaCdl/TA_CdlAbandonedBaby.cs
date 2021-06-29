namespace TechnicalAnalysis
{
    using System;

    internal partial class TACore
    {
        public static RetCode CdlAbandonedBaby(
            int startIdx,
            int endIdx,
            double[] inOpen,
            double[] inHigh,
            double[] inLow,
            double[] inClose,
            double optInPenetration,
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
            double num52;
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

            switch (optInPenetration)
            {
                case -4E+37:
                    optInPenetration = 0.3;
                    break;
                case < 0.0 or > 3E+37:
                    return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            int lookbackTotal = CdlAbandonedBabyLookback(optInPenetration);
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
            double bodyDojiPeriodTotal = 0.0;
            double bodyShortPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - 2 - Globals.candleSettings[0].avgPeriod;
            int bodyDojiTrailingIdx = startIdx - 1 - Globals.candleSettings[3].avgPeriod;
            int bodyShortTrailingIdx = startIdx - Globals.candleSettings[2].avgPeriod;
            int i = bodyLongTrailingIdx;
            while (true)
            {
                double num67;
                if (i >= startIdx - 2)
                {
                    break;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num67 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num66;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num66 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num63;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num65 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num64 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num63 = inHigh[i] - num65 + (num64 - inLow[i]);
                        }
                        else
                        {
                            num63 = 0.0;
                        }

                        num66 = num63;
                    }

                    num67 = num66;
                }

                bodyLongPeriodTotal += num67;
                i++;
            }

            i = bodyDojiTrailingIdx;
            while (true)
            {
                double num62;
                if (i >= startIdx - 1)
                {
                    break;
                }

                if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
                {
                    num62 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num61;
                    if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                    {
                        num61 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num58;
                        if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
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

                bodyDojiPeriodTotal += num62;
                i++;
            }

            i = bodyShortTrailingIdx;
            while (true)
            {
                double num57;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                {
                    num57 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num56;
                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                    {
                        num56 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num53;
                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                        {
                            double num55 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num54 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num53 = inHigh[i] - num55 + (num54 - inLow[i]);
                        }
                        else
                        {
                            num53 = 0.0;
                        }

                        num56 = num53;
                    }

                    num57 = num56;
                }

                bodyShortPeriodTotal += num57;
                i++;
            }

            i = startIdx;
            int outIdx = 0;
            Label_035B:
            if (Globals.candleSettings[0].avgPeriod != 0.0)
            {
                num52 = bodyLongPeriodTotal / Globals.candleSettings[0].avgPeriod;
            }
            else
            {
                double num51;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num51 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num50;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num50 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num47;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num49 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num48 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num47 = inHigh[i - 2] - num49 + (num48 - inLow[i - 2]);
                        }
                        else
                        {
                            num47 = 0.0;
                        }

                        num50 = num47;
                    }

                    num51 = num50;
                }

                num52 = num51;
            }

            double num46 = Globals.candleSettings[0].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                > Globals.candleSettings[0].factor * num52 / num46)
            {
                double num45;
                if (Globals.candleSettings[3].avgPeriod != 0.0)
                {
                    num45 = bodyDojiPeriodTotal / Globals.candleSettings[3].avgPeriod;
                }
                else
                {
                    double num44;
                    if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
                    {
                        num44 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num43;
                        if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                        {
                            num43 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num40;
                            if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
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

                    num45 = num44;
                }

                double num39 = Globals.candleSettings[3].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    <= Globals.candleSettings[3].factor * num45 / num39)
                {
                    double num38;
                    if (Globals.candleSettings[2].avgPeriod != 0.0)
                    {
                        num38 = bodyShortPeriodTotal / Globals.candleSettings[2].avgPeriod;
                    }
                    else
                    {
                        double num37;
                        if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                        {
                            num37 = Math.Abs(inClose[i] - inOpen[i]);
                        }
                        else
                        {
                            double num36;
                            if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                            {
                                num36 = inHigh[i] - inLow[i];
                            }
                            else
                            {
                                double num33;
                                if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                                {
                                    double num35 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                    double num34 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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

                    double num32 = Globals.candleSettings[2].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                    if (Math.Abs(inClose[i] - inOpen[i])
                        > Globals.candleSettings[2].factor * num38 / num32
                        && (inClose[i - 2] >= inOpen[i - 2] && (inClose[i] < inOpen[i] ? -1 : 1) == -1 && inClose[i] <
                            inClose[i - 2]
                            - Math.Abs(inClose[i - 2] - inOpen[i - 2])
                            * optInPenetration && inLow[i - 1] > inHigh[i - 2] && inHigh[i] < inLow[i - 1]
                            || (inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == -1 && inClose[i] >= inOpen[i] &&
                            inClose[i] > inClose[i - 2]
                            + Math.Abs(inClose[i - 2] - inOpen[i - 2])
                            * optInPenetration && inHigh[i - 1] < inLow[i - 2] && inLow[i] > inHigh[i - 1]))
                    {
                        int num31;
                        if (inClose[i] >= inOpen[i])
                        {
                            num31 = 1;
                        }
                        else
                        {
                            num31 = -1;
                        }

                        outInteger[outIdx] = num31 * 100;
                        outIdx++;
                        goto Label_0844;
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0844:
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num30 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num29;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num29 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num26;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num25 = Math.Abs(inClose[bodyLongTrailingIdx] - inOpen[bodyLongTrailingIdx]);
            }
            else
            {
                double num24;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num24 = inHigh[bodyLongTrailingIdx] - inLow[bodyLongTrailingIdx];
                }
                else
                {
                    double num21;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num23 = inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx]
                            ? inClose[bodyLongTrailingIdx]
                            : inOpen[bodyLongTrailingIdx];
                        
                        double num22 = inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx]
                            ? inOpen[bodyLongTrailingIdx]
                            : inClose[bodyLongTrailingIdx];
                        
                        num21 = inHigh[bodyLongTrailingIdx] - num23 + (num22 - inLow[bodyLongTrailingIdx]);
                    }
                    else
                    {
                        num21 = 0.0;
                    }

                    num24 = num21;
                }

                num25 = num24;
            }

            bodyLongPeriodTotal += num30 - num25;
            if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                    {
                        double num18 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                        double num17 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                        num16 = inHigh[i - 1] - num18 + (num17 - inLow[i - 1]);
                    }
                    else
                    {
                        num16 = 0.0;
                    }

                    num19 = num16;
                }

                num20 = num19;
            }

            if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
            {
                num15 = Math.Abs(inClose[bodyDojiTrailingIdx] - inOpen[bodyDojiTrailingIdx]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[bodyDojiTrailingIdx] - inLow[bodyDojiTrailingIdx];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
                    {
                        double num13 = inClose[bodyDojiTrailingIdx] >= inOpen[bodyDojiTrailingIdx]
                            ? inClose[bodyDojiTrailingIdx]
                            : inOpen[bodyDojiTrailingIdx];
                        
                        double num12 = inClose[bodyDojiTrailingIdx] >= inOpen[bodyDojiTrailingIdx]
                            ? inOpen[bodyDojiTrailingIdx]
                            : inClose[bodyDojiTrailingIdx];
                        
                        num11 = inHigh[bodyDojiTrailingIdx] - num13 + (num12 - inLow[bodyDojiTrailingIdx]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            bodyDojiPeriodTotal += num20 - num15;
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
                        double num3 = inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx]
                            ? inClose[bodyShortTrailingIdx]
                            : inOpen[bodyShortTrailingIdx];
                        
                        double num2 = inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx]
                            ? inOpen[bodyShortTrailingIdx]
                            : inClose[bodyShortTrailingIdx];
                        
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
            bodyDojiTrailingIdx++;
            bodyShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_035B;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlAbandonedBabyLookback(double optInPenetration)
        {
            int avgPeriod;
            if (optInPenetration == -4E+37)
            {
                optInPenetration = 0.3;
            }
            else if (optInPenetration is < 0.0 or > 3E+37)
            {
                return -1;
            }

            if ((Globals.candleSettings[3].avgPeriod <= Globals.candleSettings[0].avgPeriod
                ? Globals.candleSettings[0].avgPeriod
                : Globals.candleSettings[3].avgPeriod) > Globals.candleSettings[2].avgPeriod)
            {
                avgPeriod = Globals.candleSettings[3].avgPeriod <= Globals.candleSettings[0].avgPeriod
                    ? Globals.candleSettings[0].avgPeriod
                    : Globals.candleSettings[3].avgPeriod;
            }
            else
            {
                avgPeriod = Globals.candleSettings[2].avgPeriod;
            }

            return avgPeriod + 2;
        }
    }
}
