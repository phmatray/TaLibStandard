using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlTakuri(
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
            // Local variables
            double num5;
            double num10;
            double num15;
            double num20;
            double num25;
            double num30;
            double num47;
            double num53;
            
            // Validate the requested output range.
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            // Verify required price component.
            if (inOpen == null || inHigh == null || inLow == null || inClose == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlTakuriLookback();

            // Move up the start index if there is not enough initial data.
            if (startIdx < lookbackTotal)
            {
                startIdx = lookbackTotal;
            }

            // Make sure there is still something to evaluate.
            if (startIdx > endIdx)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
            }

            // Do the calculation using tight loops.
            // Add-up the initial period, except for the last value.
            double bodyDojiPeriodTotal = 0.0;
            int bodyDojiTrailingIdx = startIdx - GetCandleAvgPeriod(BodyDoji);
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            double shadowVeryLongPeriodTotal = 0.0;
            int shadowVeryLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryLong);
            
            int i = bodyDojiTrailingIdx;
            while (i < startIdx)
            {
                bodyDojiPeriodTotal += GetCandleRange(BodyDoji, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowVeryLongTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryLongPeriodTotal += GetCandleRange(ShadowVeryLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             *
             * Must have:
             * - doji body
             * - open and close at the high of the day = no or very short upper shadow
             * - very long lower shadow
             * The meaning of "doji", "very short" and "very long" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100) but this does not mean it is bullish: takuri must be considered
             * relatively to the trend
             */
            int outIdx = 0;
            Label_0313:
            if (GetCandleAvgPeriod(BodyDoji) != 0.0)
            {
                num53 = bodyDojiPeriodTotal / GetCandleAvgPeriod(BodyDoji);
            }
            else
            {
                double num52;
                if (Globals.candleSettings[3].rangeType == RangeType.RealBody)
                {
                    num52 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num51;
                    if (Globals.candleSettings[3].rangeType == RangeType.HighLow)
                    {
                        num51 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num48;
                        if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[3].rangeType == RangeType.Shadows)
            {
                num47 = 2.0;
            }
            else
            {
                num47 = 1.0;
            }

            if (Math.Abs(inClose[i] - inOpen[i]) <= Globals.candleSettings[3].factor * num53 / num47)
            {
                double num39;
                double num45;
                double num46;
                if (inClose[i] >= inOpen[i])
                {
                    num46 = inClose[i];
                }
                else
                {
                    num46 = inOpen[i];
                }

                if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                {
                    num45 = shadowVeryShortPeriodTotal / GetCandleAvgPeriod(ShadowVeryShort);
                }
                else
                {
                    double num44;
                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                    {
                        num44 = Math.Abs(inClose[i] - inOpen[i]);
                    }
                    else
                    {
                        double num43;
                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                        {
                            num43 = inHigh[i] - inLow[i];
                        }
                        else
                        {
                            double num40;
                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
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

                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                {
                    num39 = 2.0;
                }
                else
                {
                    num39 = 1.0;
                }

                if (inHigh[i] - num46 < Globals.candleSettings[7].factor * num45 / num39)
                {
                    double num31;
                    double num37;
                    double num38;
                    if (inClose[i] >= inOpen[i])
                    {
                        num38 = inOpen[i];
                    }
                    else
                    {
                        num38 = inClose[i];
                    }

                    if (GetCandleAvgPeriod(ShadowVeryLong) != 0.0)
                    {
                        num37 = shadowVeryLongPeriodTotal / GetCandleAvgPeriod(ShadowVeryLong);
                    }
                    else
                    {
                        double num36;
                        if (Globals.candleSettings[5].rangeType == RangeType.RealBody)
                        {
                            num36 = Math.Abs(inClose[i] - inOpen[i]);
                        }
                        else
                        {
                            double num35;
                            if (Globals.candleSettings[5].rangeType == RangeType.HighLow)
                            {
                                num35 = inHigh[i] - inLow[i];
                            }
                            else
                            {
                                double num32;
                                if (Globals.candleSettings[5].rangeType == RangeType.Shadows)
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

                    if (Globals.candleSettings[5].rangeType == RangeType.Shadows)
                    {
                        num31 = 2.0;
                    }
                    else
                    {
                        num31 = 1.0;
                    }

                    if (num38 - inLow[i] > Globals.candleSettings[5].factor * num37 / num31)
                    {
                        outInteger[outIdx] = 100;
                        outIdx++;
                        goto Label_0704;
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0704:
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
            if (Globals.candleSettings[5].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[5].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[5].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[5].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[shadowVeryLongTrailingIdx] - inOpen[shadowVeryLongTrailingIdx]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[5].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[shadowVeryLongTrailingIdx] - inLow[shadowVeryLongTrailingIdx];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[5].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[shadowVeryLongTrailingIdx] >= inOpen[shadowVeryLongTrailingIdx])
                        {
                            num3 = inClose[shadowVeryLongTrailingIdx];
                        }
                        else
                        {
                            num3 = inOpen[shadowVeryLongTrailingIdx];
                        }

                        if (inClose[shadowVeryLongTrailingIdx] >= inOpen[shadowVeryLongTrailingIdx])
                        {
                            num2 = inOpen[shadowVeryLongTrailingIdx];
                        }
                        else
                        {
                            num2 = inClose[shadowVeryLongTrailingIdx];
                        }

                        num = inHigh[shadowVeryLongTrailingIdx] - num3 + (num2 - inLow[shadowVeryLongTrailingIdx]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            shadowVeryLongPeriodTotal += num10 - num5;
            i++;
            bodyDojiTrailingIdx++;
            shadowVeryShortTrailingIdx++;
            shadowVeryLongTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0313;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlTakuriLookback()
        {
            if ((GetCandleAvgPeriod(BodyDoji) <= GetCandleAvgPeriod(ShadowVeryShort)
                     ? GetCandleAvgPeriod(ShadowVeryShort)
                     : GetCandleAvgPeriod(BodyDoji)) > GetCandleAvgPeriod(ShadowVeryLong))
            {
                return GetCandleAvgPeriod(BodyDoji) <= GetCandleAvgPeriod(ShadowVeryShort)
                            ? GetCandleAvgPeriod(ShadowVeryShort)
                            : GetCandleAvgPeriod(BodyDoji);
            }

            return GetCandleAvgPeriod(ShadowVeryLong);
        }
    }
}
