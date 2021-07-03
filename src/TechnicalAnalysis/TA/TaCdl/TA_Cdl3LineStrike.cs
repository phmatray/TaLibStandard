using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Cdl3LineStrike(
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
            int num46;
            double[] nearPeriodTotal = new double[4];
            
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
            int lookbackTotal = Cdl3LineStrikeLookback();

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
            nearPeriodTotal[3] = 0.0;
            nearPeriodTotal[2] = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
            int i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[3] += GetCandleRange(Near, i - 3, inOpen, inHigh, inLow, inClose);
                nearPeriodTotal[2] += GetCandleRange(Near, i - 2, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three white soldiers (three black crows): three white (black) candlesticks with consecutively higher (lower) closes,
             * each opening within or near the previous real body
             * - fourth candle: black (white) candle that opens above (below) prior candle's close and closes below (above) 
             * the first candle's open
             * The meaning of "near" is specified with TA_SetCandleSettings;
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that 3-line strike is significant when it appears in a trend in the same direction of
             * the first three candles, while this function does not consider it
             */
            int outIdx = 0;
            Label_0256:
            if (inClose[i - 2] >= inOpen[i - 2])
            {
                num46 = 1;
            }
            else
            {
                num46 = -1;
            }

            if ((inClose[i - 3] < inOpen[i - 3] ? -1 : 1) == num46)
            {
                int num45;
                if (inClose[i - 1] >= inOpen[i - 1])
                {
                    num45 = 1;
                }
                else
                {
                    num45 = -1;
                }

                if ((inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == num45)
                {
                    int num44;
                    if (inClose[i - 1] >= inOpen[i - 1])
                    {
                        num44 = 1;
                    }
                    else
                    {
                        num44 = -1;
                    }

                    if ((inClose[i] < inOpen[i] ? -1 : 1) == -num44)
                    {
                        double num42;
                        double num43 = inOpen[i - 3] < inClose[i - 3] ? inOpen[i - 3] : inClose[i - 3];

                        if (GetCandleAvgPeriod(Near) != 0.0)
                        {
                            num42 = nearPeriodTotal[3] / GetCandleAvgPeriod(Near);
                        }
                        else
                        {
                            double num41;
                            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                            {
                                num41 = Math.Abs(inClose[i - 3] - inOpen[i - 3]);
                            }
                            else
                            {
                                double num40;
                                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                {
                                    num40 = inHigh[i - 3] - inLow[i - 3];
                                }
                                else
                                {
                                    double num37;
                                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                    {
                                        double num39 = inClose[i - 3] >= inOpen[i - 3] ? inClose[i - 3] : inOpen[i - 3];
                                        double num38 = inClose[i - 3] >= inOpen[i - 3] ? inOpen[i - 3] : inClose[i - 3];
                                        num37 = inHigh[i - 3] - num39 + (num38 - inLow[i - 3]);
                                    }
                                    else
                                    {
                                        num37 = 0.0;
                                    }

                                    num40 = num37;
                                }

                                num41 = num40;
                            }

                            num42 = num41;
                        }

                        double num36 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                        if (inOpen[i - 2] >= num43 - Globals.candleSettings[8].factor * num42 / num36)
                        {
                            double num34;
                            double num35 = inOpen[i - 3] > inClose[i - 3] ? inOpen[i - 3] : inClose[i - 3];

                            if (GetCandleAvgPeriod(Near) != 0.0)
                            {
                                num34 = nearPeriodTotal[3] / GetCandleAvgPeriod(Near);
                            }
                            else
                            {
                                double num33;
                                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                                {
                                    num33 = Math.Abs(inClose[i - 3] - inOpen[i - 3]);
                                }
                                else
                                {
                                    double num32;
                                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                    {
                                        num32 = inHigh[i - 3] - inLow[i - 3];
                                    }
                                    else
                                    {
                                        double num29;
                                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                        {
                                            double num31 = inClose[i - 3] >= inOpen[i - 3] ? inClose[i - 3] : inOpen[i - 3];
                                            double num30 = inClose[i - 3] >= inOpen[i - 3] ? inOpen[i - 3] : inClose[i - 3];
                                            num29 = inHigh[i - 3] - num31 + (num30 - inLow[i - 3]);
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

                            double num28 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                            if (inOpen[i - 2] <= num35 + Globals.candleSettings[8].factor * num34 / num28)
                            {
                                double num26;
                                double num27 = inOpen[i - 2] < inClose[i - 2] ? inOpen[i - 2] : inClose[i - 2];

                                if (GetCandleAvgPeriod(Near) != 0.0)
                                {
                                    num26 = nearPeriodTotal[2] / GetCandleAvgPeriod(Near);
                                }
                                else
                                {
                                    double num25;
                                    if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                                    {
                                        num25 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                                    }
                                    else
                                    {
                                        double num24;
                                        if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                        {
                                            num24 = inHigh[i - 2] - inLow[i - 2];
                                        }
                                        else
                                        {
                                            double num21;
                                            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                            {
                                                double num23 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                                double num22 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                                num21 = inHigh[i - 2] - num23 + (num22 - inLow[i - 2]);
                                            }
                                            else
                                            {
                                                num21 = 0.0;
                                            }

                                            num24 = num21;
                                        }

                                        num25 = num24;
                                    }

                                    num26 = num25;
                                }

                                double num20 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                if (inOpen[i - 1] >= num27 - Globals.candleSettings[8].factor * num26 / num20)
                                {
                                    double num18;
                                    double num19 = inOpen[i - 2] > inClose[i - 2] ? inOpen[i - 2] : inClose[i - 2];

                                    if (GetCandleAvgPeriod(Near) != 0.0)
                                    {
                                        num18 = nearPeriodTotal[2] / GetCandleAvgPeriod(Near);
                                    }
                                    else
                                    {
                                        double num17;
                                        if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                                        {
                                            num17 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                                        }
                                        else
                                        {
                                            double num16;
                                            if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                            {
                                                num16 = inHigh[i - 2] - inLow[i - 2];
                                            }
                                            else
                                            {
                                                double num13;
                                                if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                                {
                                                    double num15 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                                    double num14 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                                    num13 = inHigh[i - 2] - num15 + (num14 - inLow[i - 2]);
                                                }
                                                else
                                                {
                                                    num13 = 0.0;
                                                }

                                                num16 = num13;
                                            }

                                            num17 = num16;
                                        }

                                        num18 = num17;
                                    }

                                    double num12 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                    if (
                                        inOpen[i - 1]
                                        <= num19 + Globals.candleSettings[8].factor * num18 / num12
                                        && (inClose[i - 1] >= inOpen[i - 1] && inClose[i - 1] > inClose[i - 2] && inClose[i - 2] > inClose[i - 3] && inOpen[i] > inClose[i - 1] && inClose[i] < inOpen[i - 3]
                                            || (inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1
                                            && inClose[i - 1] < inClose[i - 2] && inClose[i - 2] < inClose[i - 3] && inOpen[i] < inClose[i - 1] && inClose[i] > inOpen[i - 3]))
                                    {
                                        int num11;
                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num11 = 1;
                                        }
                                        else
                                        {
                                            num11 = -1;
                                        }

                                        outInteger[outIdx] = num11 * 100;
                                        outIdx++;
                                        goto Label_0975;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0975:
            int totIdx = 3;
            while (totIdx >= 2)
            {
                double num5;
                double num10;
                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num10 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num9;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num9 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num6;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num8 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inClose[i - totIdx] : inOpen[i - totIdx];
                            double num7 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inOpen[i - totIdx] : inClose[i - totIdx];
                            num6 = inHigh[i - totIdx] - num8 + (num7 - inLow[i - totIdx]);
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
                    num5 = Math.Abs(inClose[nearTrailingIdx - totIdx] - inOpen[nearTrailingIdx - totIdx]);
                }
                else
                {
                    double num4;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num4 = inHigh[nearTrailingIdx - totIdx] - inLow[nearTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num3 = inClose[nearTrailingIdx - totIdx] >= inOpen[nearTrailingIdx - totIdx] ? inClose[nearTrailingIdx - totIdx] : inOpen[nearTrailingIdx - totIdx];
                            double num2 = inClose[nearTrailingIdx - totIdx] >= inOpen[nearTrailingIdx - totIdx] ? inOpen[nearTrailingIdx - totIdx] : inClose[nearTrailingIdx - totIdx];
                            num = inHigh[nearTrailingIdx - totIdx] - num3 + (num2 - inLow[nearTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num = 0.0;
                        }

                        num4 = num;
                    }

                    num5 = num4;
                }

                nearPeriodTotal[totIdx] += num10 - num5;
                totIdx--;
            }

            i++;
            nearTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0256;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int Cdl3LineStrikeLookback()
        {
            return GetCandleAvgPeriod(Near) + 3;
        }
    }
}
