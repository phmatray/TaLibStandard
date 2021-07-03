using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlUpsideGap2Crows(
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
            int lookbackTotal = CdlUpsideGap2CrowsLookback();

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
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: white candle, usually long
             * - second candle: small black real body
             * - gap between the first and the second candle's real bodies
             * - third candle: black candle with a real body that engulfs the preceding candle 
             *   and closes above the white candle's close
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings
             * outInteger is negative (-1 to -100): upside gap two crows is always bearish; 
             * the user should consider that an upside gap two crows is significant when it appears in an uptrend, 
             * while this function does not consider the trend
             */
            int outIdx = 0;
            Label_0238:
            if (inClose[i - 2] >= inOpen[i - 2])
            {
                double num30;
                double num36;
                if (GetCandleAvgPeriod(BodyLong) != 0.0)
                {
                    num36 = bodyLongPeriodTotal / GetCandleAvgPeriod(BodyLong);
                }
                else
                {
                    double num35;
                    if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                    {
                        num35 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num34;
                        if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                        {
                            num34 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num31;
                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                double num32;
                                double num33;
                                if (inClose[i - 2] >= inOpen[i - 2])
                                {
                                    num33 = inClose[i - 2];
                                }
                                else
                                {
                                    num33 = inOpen[i - 2];
                                }

                                if (inClose[i - 2] >= inOpen[i - 2])
                                {
                                    num32 = inOpen[i - 2];
                                }
                                else
                                {
                                    num32 = inClose[i - 2];
                                }

                                num31 = inHigh[i - 2] - num33 + (num32 - inLow[i - 2]);
                            }
                            else
                            {
                                num31 = 0.0;
                            }

                            num34 = num31;
                        }

                        num35 = num34;
                    }

                    num36 = num35;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                {
                    num30 = 2.0;
                }
                else
                {
                    num30 = 1.0;
                }

                if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                    > Globals.candleSettings[0].factor * num36 / num30
                    && (inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1)
                {
                    double num23;
                    double num29;
                    if (GetCandleAvgPeriod(BodyShort) != 0.0)
                    {
                        num29 = bodyShortPeriodTotal / GetCandleAvgPeriod(BodyShort);
                    }
                    else
                    {
                        double num28;
                        if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                        {
                            num28 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num27;
                            if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                            {
                                num27 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num24;
                                if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                                {
                                    double num25;
                                    double num26;
                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num26 = inClose[i - 1];
                                    }
                                    else
                                    {
                                        num26 = inOpen[i - 1];
                                    }

                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num25 = inOpen[i - 1];
                                    }
                                    else
                                    {
                                        num25 = inClose[i - 1];
                                    }

                                    num24 = inHigh[i - 1] - num26 + (num25 - inLow[i - 1]);
                                }
                                else
                                {
                                    num24 = 0.0;
                                }

                                num27 = num24;
                            }

                            num28 = num27;
                        }

                        num29 = num28;
                    }

                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        num23 = 2.0;
                    }
                    else
                    {
                        num23 = 1.0;
                    }

                    if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                        <= Globals.candleSettings[2].factor * num29 / num23)
                    {
                        double num21;
                        double num22;
                        if (inOpen[i - 1] < inClose[i - 1])
                        {
                            num22 = inOpen[i - 1];
                        }
                        else
                        {
                            num22 = inClose[i - 1];
                        }

                        if (inOpen[i - 2] > inClose[i - 2])
                        {
                            num21 = inOpen[i - 2];
                        }
                        else
                        {
                            num21 = inClose[i - 2];
                        }

                        if (num22 > num21 && (inClose[i] < inOpen[i] ? -1 : 1) == -1 && inOpen[i] > inOpen[i - 1] && inClose[i] < inClose[i - 1] && inClose[i] > inClose[i - 2])
                        {
                            outInteger[outIdx] = -100;
                            outIdx++;
                            goto Label_05B1;
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_05B1:
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
                num10 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
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
                goto Label_0238;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlUpsideGap2CrowsLookback()
        {
            return (GetCandleAvgPeriod(BodyShort) <= GetCandleAvgPeriod(BodyLong)
                         ? GetCandleAvgPeriod(BodyLong)
                         : GetCandleAvgPeriod(BodyShort)) + 2;
        }
    }
}
