using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlGapSideSideWhite(
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
            double num52;
            double num53;
            double num54;
            double num55;
            double num58;
            double num59;
            
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
            int lookbackTotal = CdlGapSideSideWhiteLookback();

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
            double nearPeriodTotal = 0.0;
            double equalPeriodTotal = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            
            int i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal += GetCandleRange(Near, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal += GetCandleRange(Equal, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - upside or downside gap (between the bodies)
             * - first candle after the window: white candlestick
             * - second candle after the window: white candlestick with similar size (near the same) and about the same 
             *   open (equal) of the previous candle
             * - the second candle does not close the window
             * The meaning of "near" and "equal" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) or negative (-1 to -100): the user should consider that upside 
             * or downside gap side-by-side white lines is significant when it appears in a trend, while this function 
             * does not consider the trend
             */
            int outIdx = 0;
            Label_0272:
            if (inOpen[i - 1] < inClose[i - 1])
            {
                num59 = inOpen[i - 1];
            }
            else
            {
                num59 = inClose[i - 1];
            }

            if (inOpen[i - 2] > inClose[i - 2])
            {
                num58 = inOpen[i - 2];
            }
            else
            {
                num58 = inClose[i - 2];
            }

            if (num59 > num58)
            {
                double num56;
                double num57;
                if (inOpen[i] < inClose[i])
                {
                    num57 = inOpen[i];
                }
                else
                {
                    num57 = inClose[i];
                }

                if (inOpen[i - 2] > inClose[i - 2])
                {
                    num56 = inOpen[i - 2];
                }
                else
                {
                    num56 = inClose[i - 2];
                }

                if (num57 > num56)
                {
                    goto Label_0373;
                }
            }

            if (inOpen[i - 1] > inClose[i - 1])
            {
                num55 = inOpen[i - 1];
            }
            else
            {
                num55 = inClose[i - 1];
            }

            if (inOpen[i - 2] < inClose[i - 2])
            {
                num54 = inOpen[i - 2];
            }
            else
            {
                num54 = inClose[i - 2];
            }

            if (num55 >= num54)
            {
                goto Label_0990;
            }

            if (inOpen[i] > inClose[i])
            {
                num53 = inOpen[i];
            }
            else
            {
                num53 = inClose[i];
            }

            if (inOpen[i - 2] < inClose[i - 2])
            {
                num52 = inOpen[i - 2];
            }
            else
            {
                num52 = inClose[i - 2];
            }

            if (num53 >= num52)
            {
                goto Label_0990;
            }

            Label_0373:
            if (inClose[i - 1] >= inOpen[i - 1] && inClose[i] >= inOpen[i])
            {
                double num45;
                double num51;
                if (GetCandleAvgPeriod(Near) != 0.0)
                {
                    num51 = nearPeriodTotal / GetCandleAvgPeriod(Near);
                }
                else
                {
                    double num50;
                    if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                    {
                        num50 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num49;
                        if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                        {
                            num49 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num46;
                            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                            {
                                double num47;
                                double num48;
                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num48 = inClose[i - 1];
                                }
                                else
                                {
                                    num48 = inOpen[i - 1];
                                }

                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num47 = inOpen[i - 1];
                                }
                                else
                                {
                                    num47 = inClose[i - 1];
                                }

                                num46 = inHigh[i - 1] - num48 + (num47 - inLow[i - 1]);
                            }
                            else
                            {
                                num46 = 0.0;
                            }

                            num49 = num46;
                        }

                        num50 = num49;
                    }

                    num51 = num50;
                }

                if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                {
                    num45 = 2.0;
                }
                else
                {
                    num45 = 1.0;
                }

                if (Math.Abs(inClose[i] - inOpen[i])
                    >= Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    - Globals.candleSettings[8].factor * num51 / num45)
                {
                    double num38;
                    double num44;
                    if (GetCandleAvgPeriod(Near) != 0.0)
                    {
                        num44 = nearPeriodTotal / GetCandleAvgPeriod(Near);
                    }
                    else
                    {
                        double num43;
                        if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                        {
                            num43 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num42;
                            if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                            {
                                num42 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num39;
                                if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                {
                                    double num40;
                                    double num41;
                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num41 = inClose[i - 1];
                                    }
                                    else
                                    {
                                        num41 = inOpen[i - 1];
                                    }

                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num40 = inOpen[i - 1];
                                    }
                                    else
                                    {
                                        num40 = inClose[i - 1];
                                    }

                                    num39 = inHigh[i - 1] - num41 + (num40 - inLow[i - 1]);
                                }
                                else
                                {
                                    num39 = 0.0;
                                }

                                num42 = num39;
                            }

                            num43 = num42;
                        }

                        num44 = num43;
                    }

                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        num38 = 2.0;
                    }
                    else
                    {
                        num38 = 1.0;
                    }

                    if (Math.Abs(inClose[i] - inOpen[i])
                        <= Math.Abs(inClose[i - 1] - inOpen[i - 1])
                        + Globals.candleSettings[8].factor * num44 / num38)
                    {
                        double num31;
                        double num37;
                        if (GetCandleAvgPeriod(Equal) != 0.0)
                        {
                            num37 = equalPeriodTotal / GetCandleAvgPeriod(Equal);
                        }
                        else
                        {
                            double num36;
                            if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                            {
                                num36 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                            }
                            else
                            {
                                double num35;
                                if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                                {
                                    num35 = inHigh[i - 1] - inLow[i - 1];
                                }
                                else
                                {
                                    double num32;
                                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                    {
                                        double num33;
                                        double num34;
                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num34 = inClose[i - 1];
                                        }
                                        else
                                        {
                                            num34 = inOpen[i - 1];
                                        }

                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num33 = inOpen[i - 1];
                                        }
                                        else
                                        {
                                            num33 = inClose[i - 1];
                                        }

                                        num32 = inHigh[i - 1] - num34 + (num33 - inLow[i - 1]);
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

                        if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                        {
                            num31 = 2.0;
                        }
                        else
                        {
                            num31 = 1.0;
                        }

                        if (inOpen[i] >= inOpen[i - 1] - Globals.candleSettings[10].factor * num37 / num31)
                        {
                            double num24;
                            double num30;
                            if (GetCandleAvgPeriod(Equal) != 0.0)
                            {
                                num30 = equalPeriodTotal / GetCandleAvgPeriod(Equal);
                            }
                            else
                            {
                                double num29;
                                if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                                {
                                    num29 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                                }
                                else
                                {
                                    double num28;
                                    if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                                    {
                                        num28 = inHigh[i - 1] - inLow[i - 1];
                                    }
                                    else
                                    {
                                        double num25;
                                        if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                        {
                                            double num26;
                                            double num27;
                                            if (inClose[i - 1] >= inOpen[i - 1])
                                            {
                                                num27 = inClose[i - 1];
                                            }
                                            else
                                            {
                                                num27 = inOpen[i - 1];
                                            }

                                            if (inClose[i - 1] >= inOpen[i - 1])
                                            {
                                                num26 = inOpen[i - 1];
                                            }
                                            else
                                            {
                                                num26 = inClose[i - 1];
                                            }

                                            num25 = inHigh[i - 1] - num27 + (num26 - inLow[i - 1]);
                                        }
                                        else
                                        {
                                            num25 = 0.0;
                                        }

                                        num28 = num25;
                                    }

                                    num29 = num28;
                                }

                                num30 = num29;
                            }

                            if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                            {
                                num24 = 2.0;
                            }
                            else
                            {
                                num24 = 1.0;
                            }

                            if (inOpen[i] <= inOpen[i - 1] + Globals.candleSettings[10].factor * num30 / num24)
                            {
                                int num21;
                                double num22;
                                double num23;
                                if (inOpen[i - 1] < inClose[i - 1])
                                {
                                    num23 = inOpen[i - 1];
                                }
                                else
                                {
                                    num23 = inClose[i - 1];
                                }

                                if (inOpen[i - 2] > inClose[i - 2])
                                {
                                    num22 = inOpen[i - 2];
                                }
                                else
                                {
                                    num22 = inClose[i - 2];
                                }

                                if (num23 > num22)
                                {
                                    num21 = 100;
                                }
                                else
                                {
                                    num21 = -100;
                                }

                                outInteger[outIdx] = num21;
                                outIdx++;
                                goto Label_0999;
                            }
                        }
                    }
                }
            }

            Label_0990:
            outInteger[outIdx] = 0;
            outIdx++;
            Label_0999:
            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num15 = Math.Abs(inClose[nearTrailingIdx - 1] - inOpen[nearTrailingIdx - 1]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[nearTrailingIdx - 1] - inLow[nearTrailingIdx - 1];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        double num12;
                        double num13;
                        if (inClose[nearTrailingIdx - 1] >= inOpen[nearTrailingIdx - 1])
                        {
                            num13 = inClose[nearTrailingIdx - 1];
                        }
                        else
                        {
                            num13 = inOpen[nearTrailingIdx - 1];
                        }

                        if (inClose[nearTrailingIdx - 1] >= inOpen[nearTrailingIdx - 1])
                        {
                            num12 = inOpen[nearTrailingIdx - 1];
                        }
                        else
                        {
                            num12 = inClose[nearTrailingIdx - 1];
                        }

                        num11 = inHigh[nearTrailingIdx - 1] - num13 + (num12 - inLow[nearTrailingIdx - 1]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            nearPeriodTotal += num20 - num15;
            if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[equalTrailingIdx - 1] - inOpen[equalTrailingIdx - 1]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[equalTrailingIdx - 1] - inLow[equalTrailingIdx - 1];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[equalTrailingIdx - 1] >= inOpen[equalTrailingIdx - 1])
                        {
                            num3 = inClose[equalTrailingIdx - 1];
                        }
                        else
                        {
                            num3 = inOpen[equalTrailingIdx - 1];
                        }

                        if (inClose[equalTrailingIdx - 1] >= inOpen[equalTrailingIdx - 1])
                        {
                            num2 = inOpen[equalTrailingIdx - 1];
                        }
                        else
                        {
                            num2 = inClose[equalTrailingIdx - 1];
                        }

                        num = inHigh[equalTrailingIdx - 1] - num3 + (num2 - inLow[equalTrailingIdx - 1]);
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
            nearTrailingIdx++;
            equalTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0272;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlGapSideSideWhiteLookback()
        {
            return (GetCandleAvgPeriod(Near) <= GetCandleAvgPeriod(Equal)
                         ? GetCandleAvgPeriod(Equal)
                         : GetCandleAvgPeriod(Near)) + 2;
        }
    }
}
