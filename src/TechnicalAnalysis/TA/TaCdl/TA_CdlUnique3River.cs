using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlUnique3River(
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
            double num28;
            double num34;
            
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
            int lookbackTotal = CdlUnique3RiverLookback();

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
            int bodyLongTrailingIdx = startIdx - 2 - GetCandleAvgPeriod(BodyLong);
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx - 2)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyShortPeriodTotal += GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black candle
             * - second candle: black harami candle with a lower low than the first candle's low
             * - third candle: small white candle with open not lower than the second candle's low, better if its open and 
             *   close are under the second candle's close
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100): unique 3 river is always bullish and should appear in a downtrend 
             * to be significant, while this function does not consider the trend
             */
            int outIdx = 0;
            Label_0234:
            if (GetCandleAvgPeriod(BodyLong) != 0.0)
            {
                num34 = bodyLongPeriodTotal / GetCandleAvgPeriod(BodyLong);
            }
            else
            {
                double num33;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num33 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num32;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num32 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num29;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num30;
                            double num31;
                            if (inClose[i - 2] >= inOpen[i - 2])
                            {
                                num31 = inClose[i - 2];
                            }
                            else
                            {
                                num31 = inOpen[i - 2];
                            }

                            if (inClose[i - 2] >= inOpen[i - 2])
                            {
                                num30 = inOpen[i - 2];
                            }
                            else
                            {
                                num30 = inClose[i - 2];
                            }

                            num29 = inHigh[i - 2] - num31 + (num30 - inLow[i - 2]);
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

            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
            {
                num28 = 2.0;
            }
            else
            {
                num28 = 1.0;
            }

            if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                > Globals.candleSettings[0].factor * num34 / num28
                && (inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == -1
                && (inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1 && inClose[i - 1] > inClose[i - 2] && inOpen[i - 1] <= inOpen[i - 2] && inLow[i - 1] < inLow[i - 2])
            {
                double num21;
                double num27;
                if (GetCandleAvgPeriod(BodyShort) != 0.0)
                {
                    num27 = bodyShortPeriodTotal / GetCandleAvgPeriod(BodyShort);
                }
                else
                {
                    double num26;
                    if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                    {
                        num26 = Math.Abs(inClose[i] - inOpen[i]);
                    }
                    else
                    {
                        double num25;
                        if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                        {
                            num25 = inHigh[i] - inLow[i];
                        }
                        else
                        {
                            double num22;
                            if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                            {
                                double num23;
                                double num24;
                                if (inClose[i] >= inOpen[i])
                                {
                                    num24 = inClose[i];
                                }
                                else
                                {
                                    num24 = inOpen[i];
                                }

                                if (inClose[i] >= inOpen[i])
                                {
                                    num23 = inOpen[i];
                                }
                                else
                                {
                                    num23 = inClose[i];
                                }

                                num22 = inHigh[i] - num24 + (num23 - inLow[i]);
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

                if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                {
                    num21 = 2.0;
                }
                else
                {
                    num21 = 1.0;
                }

                if (Math.Abs(inClose[i] - inOpen[i]) < Globals.candleSettings[2].factor * num27 / num21
                    && (inClose[i] < inOpen[i] ? -1 : 1) == 1 && inOpen[i] > inLow[i - 1])
                {
                    outInteger[outIdx] = 100;
                    outIdx++;
                    goto Label_055F;
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_055F:
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num17;
                        double num18;
                        if (inClose[i - 2] >= inOpen[i - 2])
                        {
                            num18 = inClose[i - 2];
                        }
                        else
                        {
                            num18 = inOpen[i - 2];
                        }

                        if (inClose[i - 2] >= inOpen[i - 2])
                        {
                            num17 = inOpen[i - 2];
                        }
                        else
                        {
                            num17 = inClose[i - 2];
                        }

                        num16 = inHigh[i - 2] - num18 + (num17 - inLow[i - 2]);
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
                num15 = Math.Abs(inClose[bodyLongTrailingIdx] - inOpen[bodyLongTrailingIdx]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[bodyLongTrailingIdx] - inLow[bodyLongTrailingIdx];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num12;
                        double num13;
                        if (inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx])
                        {
                            num13 = inClose[bodyLongTrailingIdx];
                        }
                        else
                        {
                            num13 = inOpen[bodyLongTrailingIdx];
                        }

                        if (inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx])
                        {
                            num12 = inOpen[bodyLongTrailingIdx];
                        }
                        else
                        {
                            num12 = inClose[bodyLongTrailingIdx];
                        }

                        num11 = inHigh[bodyLongTrailingIdx] - num13 + (num12 - inLow[bodyLongTrailingIdx]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            bodyLongPeriodTotal += num20 - num15;
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
                        double num2;
                        double num3;
                        if (inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx])
                        {
                            num3 = inClose[bodyShortTrailingIdx];
                        }
                        else
                        {
                            num3 = inOpen[bodyShortTrailingIdx];
                        }

                        if (inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx])
                        {
                            num2 = inOpen[bodyShortTrailingIdx];
                        }
                        else
                        {
                            num2 = inClose[bodyShortTrailingIdx];
                        }

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
            bodyShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0234;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlUnique3RiverLookback()
        {
            return (GetCandleAvgPeriod(BodyShort) <= GetCandleAvgPeriod(BodyLong)
                         ? GetCandleAvgPeriod(BodyLong)
                         : GetCandleAvgPeriod(BodyShort)) + 2;
        }
    }
}
