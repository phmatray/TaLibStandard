using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlBreakaway(
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
            int num11;
            double num12;
            double num13;
            int num16;
            int num17;
            int num18;
            double num19;
            double num25;
            
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
            int lookbackTotal = CdlBreakawayLookback();

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
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 4, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long black (white)
             * - second candle: black (white) day whose body gaps down (up)
             * - third candle: black or white day with lower (higher) high and lower (higher) low than prior candle's
             * - fourth candle: black (white) day with lower (higher) high and lower (higher) low than prior candle's
             * - fifth candle: white (black) day that closes inside the gap, erasing the prior 3 days
             * The meaning of "long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that breakaway is significant in a trend opposite to the last candle, while this 
             * function does not consider it
             */
            int outIdx = 0;
            Label_0168:
            if (GetCandleAvgPeriod(BodyLong) != 0.0)
            {
                num25 = bodyLongPeriodTotal / GetCandleAvgPeriod(BodyLong);
            }
            else
            {
                double num24;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num24 = Math.Abs(inClose[i - 4] - inOpen[i - 4]);
                }
                else
                {
                    double num23;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num23 = inHigh[i - 4] - inLow[i - 4];
                    }
                    else
                    {
                        double num20;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num21;
                            double num22;
                            if (inClose[i - 4] >= inOpen[i - 4])
                            {
                                num22 = inClose[i - 4];
                            }
                            else
                            {
                                num22 = inOpen[i - 4];
                            }

                            if (inClose[i - 4] >= inOpen[i - 4])
                            {
                                num21 = inOpen[i - 4];
                            }
                            else
                            {
                                num21 = inClose[i - 4];
                            }

                            num20 = inHigh[i - 4] - num22 + (num21 - inLow[i - 4]);
                        }
                        else
                        {
                            num20 = 0.0;
                        }

                        num23 = num20;
                    }

                    num24 = num23;
                }

                num25 = num24;
            }

            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
            {
                num19 = 2.0;
            }
            else
            {
                num19 = 1.0;
            }

            if (Math.Abs(inClose[i - 4] - inOpen[i - 4])
                <= Globals.candleSettings[0].factor * num25 / num19)
            {
                goto Label_04B7;
            }

            if (inClose[i - 3] >= inOpen[i - 3])
            {
                num18 = 1;
            }
            else
            {
                num18 = -1;
            }

            if ((inClose[i - 4] < inOpen[i - 4] ? -1 : 1) != num18)
            {
                goto Label_04B7;
            }

            if (inClose[i - 1] >= inOpen[i - 1])
            {
                num17 = 1;
            }
            else
            {
                num17 = -1;
            }

            if ((inClose[i - 3] < inOpen[i - 3] ? -1 : 1) != num17)
            {
                goto Label_04B7;
            }

            if (inClose[i] >= inOpen[i])
            {
                num16 = 1;
            }
            else
            {
                num16 = -1;
            }

            if ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) != -num16)
            {
                goto Label_04B7;
            }

            if ((inClose[i - 4] < inOpen[i - 4] ? -1 : 1) == -1)
            {
                double num14;
                double num15;
                if (inOpen[i - 3] > inClose[i - 3])
                {
                    num15 = inOpen[i - 3];
                }
                else
                {
                    num15 = inClose[i - 3];
                }

                if (inOpen[i - 4] < inClose[i - 4])
                {
                    num14 = inOpen[i - 4];
                }
                else
                {
                    num14 = inClose[i - 4];
                }

                if (num15 < num14 && inHigh[i - 2] < inHigh[i - 3] && inLow[i - 2] < inLow[i - 3] && inHigh[i - 1] < inHigh[i - 2] && inLow[i - 1] < inLow[i - 2] && inClose[i] > inOpen[i - 3] && inClose[i] < inClose[i - 4])
                {
                    goto Label_0497;
                }
            }

            if (inClose[i - 4] < inOpen[i - 4])
            {
                goto Label_04B7;
            }

            if (inOpen[i - 3] < inClose[i - 3])
            {
                num13 = inOpen[i - 3];
            }
            else
            {
                num13 = inClose[i - 3];
            }

            if (inOpen[i - 4] > inClose[i - 4])
            {
                num12 = inOpen[i - 4];
            }
            else
            {
                num12 = inClose[i - 4];
            }

            if (num13 <= num12 || inHigh[i - 2] <= inHigh[i - 3] || inLow[i - 2] <= inLow[i - 3] || inHigh[i - 1] <= inHigh[i - 2] || inLow[i - 1] <= inLow[i - 2] || inClose[i] >= inOpen[i - 3] || inClose[i] <= inClose[i - 4])
            {
                goto Label_04B7;
            }

            Label_0497:
            if (inClose[i] >= inOpen[i])
            {
                num11 = 1;
            }
            else
            {
                num11 = -1;
            }

            outInteger[outIdx] = num11 * 100;
            outIdx++;
            goto Label_04C0;
            Label_04B7:
            outInteger[outIdx] = 0;
            outIdx++;
            Label_04C0:
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 4] - inOpen[i - 4]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 4] - inLow[i - 4];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num7;
                        double num8;
                        if (inClose[i - 4] >= inOpen[i - 4])
                        {
                            num8 = inClose[i - 4];
                        }
                        else
                        {
                            num8 = inOpen[i - 4];
                        }

                        if (inClose[i - 4] >= inOpen[i - 4])
                        {
                            num7 = inOpen[i - 4];
                        }
                        else
                        {
                            num7 = inClose[i - 4];
                        }

                        num6 = inHigh[i - 4] - num8 + (num7 - inLow[i - 4]);
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
                num5 = Math.Abs(inClose[bodyLongTrailingIdx - 4] - inOpen[bodyLongTrailingIdx - 4]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[bodyLongTrailingIdx - 4] - inLow[bodyLongTrailingIdx - 4];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[bodyLongTrailingIdx - 4] >= inOpen[bodyLongTrailingIdx - 4])
                        {
                            num3 = inClose[bodyLongTrailingIdx - 4];
                        }
                        else
                        {
                            num3 = inOpen[bodyLongTrailingIdx - 4];
                        }

                        if (inClose[bodyLongTrailingIdx - 4] >= inOpen[bodyLongTrailingIdx - 4])
                        {
                            num2 = inOpen[bodyLongTrailingIdx - 4];
                        }
                        else
                        {
                            num2 = inClose[bodyLongTrailingIdx - 4];
                        }

                        num = inHigh[bodyLongTrailingIdx - 4] - num3 + (num2 - inLow[bodyLongTrailingIdx - 4]);
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
            bodyLongTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0168;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlBreakawayLookback()
        {
            return GetCandleAvgPeriod(BodyLong) + 4;
        }
    }
}
