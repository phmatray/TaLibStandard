using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlEveningStar(
            int startIdx,
            int endIdx,
            in double[] inOpen,
            in double[] inHigh,
            in double[] inLow,
            in double[] inClose,
            in double optInPenetration,
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

            if (optInPenetration < 0.0)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlEveningStarLookback(optInPenetration);

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
            double bodyLongPeriodTotal = 0.0;
            double bodyShortPeriodTotal = 0.0;
            double bodyShortPeriodTotal2 = 0.0;
            int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);
            int bodyShortTrailingIdx = startIdx - 1 - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 2)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx - 1)
            {
                bodyShortPeriodTotal += GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose);
                bodyShortPeriodTotal2 += GetCandleRange(BodyShort, i + 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white real body
             * - second candle: star (short real body gapping up)
             * - third candle: black real body that moves well within the first candle's real body
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings
             * The meaning of "moves well within" is specified with optInPenetration and "moves" should mean the real body should
             * not be short ("short" is specified with TA_SetCandleSettings) - Greg Morris wants it to be long, someone else want
             * it to be relatively long
             * outInteger is negative (-1 to -100): evening star is always bearish; 
             * the user should consider that an evening star is significant when it appears in an uptrend, 
             * while this function does not consider the trend
             */
            int outIdx = 0;
            Label_0353:
            if (GetCandleAvgPeriod(BodyLong) != 0.0)
            {
                num53 = bodyLongPeriodTotal / GetCandleAvgPeriod(BodyLong);
            }
            else
            {
                double num52;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num52 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num51;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num51 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num48;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num49;
                            double num50;
                            if (inClose[i - 2] >= inOpen[i - 2])
                            {
                                num50 = inClose[i - 2];
                            }
                            else
                            {
                                num50 = inOpen[i - 2];
                            }

                            if (inClose[i - 2] >= inOpen[i - 2])
                            {
                                num49 = inOpen[i - 2];
                            }
                            else
                            {
                                num49 = inClose[i - 2];
                            }

                            num48 = inHigh[i - 2] - num50 + (num49 - inLow[i - 2]);
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

            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
            {
                num47 = 2.0;
            }
            else
            {
                num47 = 1.0;
            }

            if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                > Globals.candleSettings[0].factor * num53 / num47 && inClose[i - 2] >= inOpen[i - 2])
            {
                double num40;
                double num46;
                if (GetCandleAvgPeriod(BodyShort) != 0.0)
                {
                    num46 = bodyShortPeriodTotal / GetCandleAvgPeriod(BodyShort);
                }
                else
                {
                    double num45;
                    if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                    {
                        num45 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num44;
                        if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                        {
                            num44 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num41;
                            if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                            {
                                double num42;
                                double num43;
                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num43 = inClose[i - 1];
                                }
                                else
                                {
                                    num43 = inOpen[i - 1];
                                }

                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num42 = inOpen[i - 1];
                                }
                                else
                                {
                                    num42 = inClose[i - 1];
                                }

                                num41 = inHigh[i - 1] - num43 + (num42 - inLow[i - 1]);
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

                if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                {
                    num40 = 2.0;
                }
                else
                {
                    num40 = 1.0;
                }

                if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    <= Globals.candleSettings[2].factor * num46 / num40)
                {
                    double num38;
                    double num39;
                    if (inOpen[i - 1] < inClose[i - 1])
                    {
                        num39 = inOpen[i - 1];
                    }
                    else
                    {
                        num39 = inClose[i - 1];
                    }

                    if (inOpen[i - 2] > inClose[i - 2])
                    {
                        num38 = inOpen[i - 2];
                    }
                    else
                    {
                        num38 = inClose[i - 2];
                    }

                    if (num39 > num38)
                    {
                        double num31;
                        double num37;
                        if (GetCandleAvgPeriod(BodyShort) != 0.0)
                        {
                            num37 = bodyShortPeriodTotal2 / GetCandleAvgPeriod(BodyShort);
                        }
                        else
                        {
                            double num36;
                            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                            {
                                num36 = Math.Abs(inClose[i] - inOpen[i]);
                            }
                            else
                            {
                                double num35;
                                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                                {
                                    num35 = inHigh[i] - inLow[i];
                                }
                                else
                                {
                                    double num32;
                                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
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

                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                        {
                            num31 = 2.0;
                        }
                        else
                        {
                            num31 = 1.0;
                        }

                        if (Math.Abs(inClose[i] - inOpen[i])
                            > Globals.candleSettings[2].factor * num37 / num31
                            && (inClose[i] < inOpen[i] ? -1 : 1) == -1
                            && inClose[i] < inClose[i - 2]
                            - Math.Abs(inClose[i - 2] - inOpen[i - 2])
                            * optInPenetration)
                        {
                            outInteger[outIdx] = -100;
                            outIdx++;
                            goto Label_07F2;
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_07F2:
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
                        double num27;
                        double num28;
                        if (inClose[i - 2] >= inOpen[i - 2])
                        {
                            num28 = inClose[i - 2];
                        }
                        else
                        {
                            num28 = inOpen[i - 2];
                        }

                        if (inClose[i - 2] >= inOpen[i - 2])
                        {
                            num27 = inOpen[i - 2];
                        }
                        else
                        {
                            num27 = inClose[i - 2];
                        }

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
                        double num22;
                        double num23;
                        if (inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx])
                        {
                            num23 = inClose[bodyLongTrailingIdx];
                        }
                        else
                        {
                            num23 = inOpen[bodyLongTrailingIdx];
                        }

                        if (inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx])
                        {
                            num22 = inOpen[bodyLongTrailingIdx];
                        }
                        else
                        {
                            num22 = inClose[bodyLongTrailingIdx];
                        }

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
            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        double num17;
                        double num18;
                        if (inClose[i - 1] >= inOpen[i - 1])
                        {
                            num18 = inClose[i - 1];
                        }
                        else
                        {
                            num18 = inOpen[i - 1];
                        }

                        if (inClose[i - 1] >= inOpen[i - 1])
                        {
                            num17 = inOpen[i - 1];
                        }
                        else
                        {
                            num17 = inClose[i - 1];
                        }

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

            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num15 = Math.Abs(inClose[bodyShortTrailingIdx] - inOpen[bodyShortTrailingIdx]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[bodyShortTrailingIdx] - inLow[bodyShortTrailingIdx];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        double num12;
                        double num13;
                        if (inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx])
                        {
                            num13 = inClose[bodyShortTrailingIdx];
                        }
                        else
                        {
                            num13 = inOpen[bodyShortTrailingIdx];
                        }

                        if (inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx])
                        {
                            num12 = inOpen[bodyShortTrailingIdx];
                        }
                        else
                        {
                            num12 = inClose[bodyShortTrailingIdx];
                        }

                        num11 = inHigh[bodyShortTrailingIdx] - num13 + (num12 - inLow[bodyShortTrailingIdx]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            bodyShortPeriodTotal += num20 - num15;
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

            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[bodyShortTrailingIdx + 1] - inOpen[bodyShortTrailingIdx + 1]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[bodyShortTrailingIdx + 1] - inLow[bodyShortTrailingIdx + 1];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[bodyShortTrailingIdx + 1] >= inOpen[bodyShortTrailingIdx + 1])
                        {
                            num3 = inClose[bodyShortTrailingIdx + 1];
                        }
                        else
                        {
                            num3 = inOpen[bodyShortTrailingIdx + 1];
                        }

                        if (inClose[bodyShortTrailingIdx + 1] >= inOpen[bodyShortTrailingIdx + 1])
                        {
                            num2 = inOpen[bodyShortTrailingIdx + 1];
                        }
                        else
                        {
                            num2 = inClose[bodyShortTrailingIdx + 1];
                        }

                        num = inHigh[bodyShortTrailingIdx + 1] - num3 + (num2 - inLow[bodyShortTrailingIdx + 1]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            bodyShortPeriodTotal2 += num10 - num5;
            i++;
            bodyLongTrailingIdx++;
            bodyShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0353;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlEveningStarLookback(double optInPenetration)
        {
            if (optInPenetration < 0.0)
            {
                return -1;
            }

            return (GetCandleAvgPeriod(BodyShort) <= GetCandleAvgPeriod(BodyLong)
                         ? GetCandleAvgPeriod(BodyLong)
                         : GetCandleAvgPeriod(BodyShort)) + 2;
        }
    }
}
