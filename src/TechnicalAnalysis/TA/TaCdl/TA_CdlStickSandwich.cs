using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlStickSandwich(
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
            int lookbackTotal = CdlStickSandwichLookback();

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
            
            int i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += GetCandleRange(Equal, i - 2, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: black candle
             * - second candle: white candle that trades only above the prior close (low > prior close)
             * - third candle: black candle with the close equal to the first candle's close
             * The meaning of "equal" is specified with TA_SetCandleSettings
             * outInteger is always positive (1 to 100): stick sandwich is always bullish;
             * the user should consider that stick sandwich is significant when coming in a downtrend, 
             * while this function does not consider it
             */
            int outIdx = 0;
            Label_016C:
            if ((inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == -1 && inClose[i - 1] >= inOpen[i - 1]
                                                                && (inClose[i] < inOpen[i] ? -1 : 1) == -1 && inLow[i - 1] > inClose[i - 2])
            {
                double num18;
                double num24;
                if (GetCandleAvgPeriod(Equal) != 0.0)
                {
                    num24 = equalPeriodTotal / GetCandleAvgPeriod(Equal);
                }
                else
                {
                    double num23;
                    if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                    {
                        num23 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num22;
                        if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                        {
                            num22 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num19;
                            if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                            {
                                double num20;
                                double num21;
                                if (inClose[i - 2] >= inOpen[i - 2])
                                {
                                    num21 = inClose[i - 2];
                                }
                                else
                                {
                                    num21 = inOpen[i - 2];
                                }

                                if (inClose[i - 2] >= inOpen[i - 2])
                                {
                                    num20 = inOpen[i - 2];
                                }
                                else
                                {
                                    num20 = inClose[i - 2];
                                }

                                num19 = inHigh[i - 2] - num21 + (num20 - inLow[i - 2]);
                            }
                            else
                            {
                                num19 = 0.0;
                            }

                            num22 = num19;
                        }

                        num23 = num22;
                    }

                    num24 = num23;
                }

                if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                {
                    num18 = 2.0;
                }
                else
                {
                    num18 = 1.0;
                }

                if (inClose[i] <= inClose[i - 2] + Globals.candleSettings[10].factor * num24 / num18)
                {
                    double num11;
                    double num17;
                    if (GetCandleAvgPeriod(Equal) != 0.0)
                    {
                        num17 = equalPeriodTotal / GetCandleAvgPeriod(Equal);
                    }
                    else
                    {
                        double num16;
                        if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                        {
                            num16 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                        }
                        else
                        {
                            double num15;
                            if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                            {
                                num15 = inHigh[i - 2] - inLow[i - 2];
                            }
                            else
                            {
                                double num12;
                                if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                {
                                    double num13;
                                    double num14;
                                    if (inClose[i - 2] >= inOpen[i - 2])
                                    {
                                        num14 = inClose[i - 2];
                                    }
                                    else
                                    {
                                        num14 = inOpen[i - 2];
                                    }

                                    if (inClose[i - 2] >= inOpen[i - 2])
                                    {
                                        num13 = inOpen[i - 2];
                                    }
                                    else
                                    {
                                        num13 = inClose[i - 2];
                                    }

                                    num12 = inHigh[i - 2] - num14 + (num13 - inLow[i - 2]);
                                }
                                else
                                {
                                    num12 = 0.0;
                                }

                                num15 = num12;
                            }

                            num16 = num15;
                        }

                        num17 = num16;
                    }

                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                    {
                        num11 = 2.0;
                    }
                    else
                    {
                        num11 = 1.0;
                    }

                    if (inClose[i] >= inClose[i - 2] - Globals.candleSettings[10].factor * num17 / num11)
                    {
                        outInteger[outIdx] = 100;
                        outIdx++;
                        goto Label_0492;
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0492:
            if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                    {
                        double num7;
                        double num8;
                        if (inClose[i - 2] >= inOpen[i - 2])
                        {
                            num8 = inClose[i - 2];
                        }
                        else
                        {
                            num8 = inOpen[i - 2];
                        }

                        if (inClose[i - 2] >= inOpen[i - 2])
                        {
                            num7 = inOpen[i - 2];
                        }
                        else
                        {
                            num7 = inClose[i - 2];
                        }

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

            if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[equalTrailingIdx - 2] - inOpen[equalTrailingIdx - 2]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[equalTrailingIdx - 2] - inLow[equalTrailingIdx - 2];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[equalTrailingIdx - 2] >= inOpen[equalTrailingIdx - 2])
                        {
                            num3 = inClose[equalTrailingIdx - 2];
                        }
                        else
                        {
                            num3 = inOpen[equalTrailingIdx - 2];
                        }

                        if (inClose[equalTrailingIdx - 2] >= inOpen[equalTrailingIdx - 2])
                        {
                            num2 = inOpen[equalTrailingIdx - 2];
                        }
                        else
                        {
                            num2 = inClose[equalTrailingIdx - 2];
                        }

                        num = inHigh[equalTrailingIdx - 2] - num3 + (num2 - inLow[equalTrailingIdx - 2]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            equalPeriodTotal += num10 - num5;
            i++;
            equalTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_016C;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlStickSandwichLookback()
        {
            return GetCandleAvgPeriod(Equal) + 2;
        }
    }
}
