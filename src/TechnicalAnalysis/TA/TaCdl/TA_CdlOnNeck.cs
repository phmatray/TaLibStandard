using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlOnNeck(
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
            int lookbackTotal = CdlOnNeckLookback();

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
            double equalPeriodTotal = 0.0;
            int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += GetCandleRange(Equal, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle
             * - second candle: white candle with open below previous day low and close equal to previous day low
             * The meaning of "equal" is specified with TA_SetCandleSettings
             * outInteger is negative (-1 to -100): on-neck is always bearish
             * the user should consider that on-neck is significant when it appears in a downtrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            Label_0272:
            if ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1)
            {
                double num35;
                double num41;
                if (GetCandleAvgPeriod(BodyLong) != 0.0)
                {
                    num41 = bodyLongPeriodTotal / GetCandleAvgPeriod(BodyLong);
                }
                else
                {
                    double num40;
                    if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                    {
                        num40 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num39;
                        if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                        {
                            num39 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num36;
                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                double num37;
                                double num38;
                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num38 = inClose[i - 1];
                                }
                                else
                                {
                                    num38 = inOpen[i - 1];
                                }

                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num37 = inOpen[i - 1];
                                }
                                else
                                {
                                    num37 = inClose[i - 1];
                                }

                                num36 = inHigh[i - 1] - num38 + (num37 - inLow[i - 1]);
                            }
                            else
                            {
                                num36 = 0.0;
                            }

                            num39 = num36;
                        }

                        num40 = num39;
                    }

                    num41 = num40;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                {
                    num35 = 2.0;
                }
                else
                {
                    num35 = 1.0;
                }

                if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    > Globals.candleSettings[0].factor * num41 / num35 && inClose[i] >= inOpen[i]
                                                                       && inOpen[i] < inLow[i - 1])
                {
                    double num28;
                    double num34;
                    if (GetCandleAvgPeriod(Equal) != 0.0)
                    {
                        num34 = equalPeriodTotal / GetCandleAvgPeriod(Equal);
                    }
                    else
                    {
                        double num33;
                        if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                        {
                            num33 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num32;
                            if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                            {
                                num32 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num29;
                                if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                {
                                    double num30;
                                    double num31;
                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num31 = inClose[i - 1];
                                    }
                                    else
                                    {
                                        num31 = inOpen[i - 1];
                                    }

                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num30 = inOpen[i - 1];
                                    }
                                    else
                                    {
                                        num30 = inClose[i - 1];
                                    }

                                    num29 = inHigh[i - 1] - num31 + (num30 - inLow[i - 1]);
                                }
                                else
                                {
                                    num29 = 0.0;
                                }

                                num32 = num29;
                            }

                            num33 = num32;
                        }

                        num34 = num33;
                    }

                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                    {
                        num28 = 2.0;
                    }
                    else
                    {
                        num28 = 1.0;
                    }

                    if (inClose[i] <= inLow[i - 1] + Globals.candleSettings[10].factor * num34 / num28)
                    {
                        double num21;
                        double num27;
                        if (GetCandleAvgPeriod(Equal) != 0.0)
                        {
                            num27 = equalPeriodTotal / GetCandleAvgPeriod(Equal);
                        }
                        else
                        {
                            double num26;
                            if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                            {
                                num26 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                            }
                            else
                            {
                                double num25;
                                if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                                {
                                    num25 = inHigh[i - 1] - inLow[i - 1];
                                }
                                else
                                {
                                    double num22;
                                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                    {
                                        double num23;
                                        double num24;
                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num24 = inClose[i - 1];
                                        }
                                        else
                                        {
                                            num24 = inOpen[i - 1];
                                        }

                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num23 = inOpen[i - 1];
                                        }
                                        else
                                        {
                                            num23 = inClose[i - 1];
                                        }

                                        num22 = inHigh[i - 1] - num24 + (num23 - inLow[i - 1]);
                                    }
                                    else
                                    {
                                        num22 = 0.0;
                                    }

                                    num25 = num22;
                                }

                                num26 = num25;
                            }

                            num27 = num26;
                        }

                        if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                        {
                            num21 = 2.0;
                        }
                        else
                        {
                            num21 = 1.0;
                        }

                        if (inClose[i] >= inLow[i - 1] - Globals.candleSettings[10].factor * num27 / num21)
                        {
                            outInteger[outIdx] = -100;
                            outIdx++;
                            goto Label_06E1;
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_06E1:
            if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
            {
                num15 = Math.Abs(inClose[equalTrailingIdx - 1] - inOpen[equalTrailingIdx - 1]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[equalTrailingIdx - 1] - inLow[equalTrailingIdx - 1];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                    {
                        double num12;
                        double num13;
                        if (inClose[equalTrailingIdx - 1] >= inOpen[equalTrailingIdx - 1])
                        {
                            num13 = inClose[equalTrailingIdx - 1];
                        }
                        else
                        {
                            num13 = inOpen[equalTrailingIdx - 1];
                        }

                        if (inClose[equalTrailingIdx - 1] >= inOpen[equalTrailingIdx - 1])
                        {
                            num12 = inOpen[equalTrailingIdx - 1];
                        }
                        else
                        {
                            num12 = inClose[equalTrailingIdx - 1];
                        }

                        num11 = inHigh[equalTrailingIdx - 1] - num13 + (num12 - inLow[equalTrailingIdx - 1]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            equalPeriodTotal += num20 - num15;
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[bodyLongTrailingIdx - 1] - inOpen[bodyLongTrailingIdx - 1]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[bodyLongTrailingIdx - 1] - inLow[bodyLongTrailingIdx - 1];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[bodyLongTrailingIdx - 1] >= inOpen[bodyLongTrailingIdx - 1])
                        {
                            num3 = inClose[bodyLongTrailingIdx - 1];
                        }
                        else
                        {
                            num3 = inOpen[bodyLongTrailingIdx - 1];
                        }

                        if (inClose[bodyLongTrailingIdx - 1] >= inOpen[bodyLongTrailingIdx - 1])
                        {
                            num2 = inOpen[bodyLongTrailingIdx - 1];
                        }
                        else
                        {
                            num2 = inClose[bodyLongTrailingIdx - 1];
                        }

                        num = inHigh[bodyLongTrailingIdx - 1] - num3 + (num2 - inLow[bodyLongTrailingIdx - 1]);
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
            equalTrailingIdx++;
            bodyLongTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0272;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlOnNeckLookback()
        {
            return (GetCandleAvgPeriod(Equal) <= GetCandleAvgPeriod(BodyLong)
                         ? GetCandleAvgPeriod(BodyLong)
                         : GetCandleAvgPeriod(Equal)) + 1;
        }
    }
}
