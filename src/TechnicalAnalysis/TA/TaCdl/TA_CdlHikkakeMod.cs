using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlHikkakeMod(
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
            int outIdx;
            double num5;
            double num10;
            double num18;
            double num30;
            double num35;
            double num42;
            
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
            int lookbackTotal = CdlHikkakeModLookback();

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
            int nearTrailingIdx = startIdx - 3 - GetCandleAvgPeriod(Near);
            
            int i = nearTrailingIdx;
            while (i < startIdx - 3)
            {
                nearPeriodTotal += GetCandleRange(Near, i - 2, inOpen, inHigh, inLow, inClose);
                i++;
            }

            int patternIdx = 0;
            int patternResult = 0;
            
            i = startIdx - 3;
            while (i < startIdx)
            {
                bool patternRecognition =
                    // 2nd: lower high and higher low than 1st
                    inHigh[i - 2] < inHigh[i - 3] && inLow[i - 2] > inLow[i - 3] &&
                    // 3rd: lower high and higher low than 2nd
                    inHigh[i - 1] < inHigh[i - 2] && inLow[i - 1] > inLow[i - 2] &&
                    (
                        // (bull) 4th: lower high and lower low
                        inHigh[i] < inHigh[i - 1] && inLow[i] < inLow[i - 1] &&
                        // (bull) 2nd: close near the low
                        inClose[i - 2] <= inLow[i - 2] + GetCandleAverage(Near, nearPeriodTotal, i - 2, inOpen, inHigh,
                            inLow, inClose) ||
                        // (bear) 4th: higher high and higher low
                        inHigh[i] > inHigh[i - 1] && inLow[i] > inLow[i - 1] &&
                        // (bull) 2nd: close near the top
                        inClose[i - 2] >= inHigh[i - 2] - GetCandleAverage(Near, nearPeriodTotal, i - 2, inOpen, inHigh,
                            inLow, inClose)
                    );
                
                if (patternRecognition)
                {
                    patternResult = 100 * (inHigh[i] < inHigh[i - 1] ? 1 : -1);
                    patternIdx = i;
                }
                else
                {
                    // search for confirmation if modified hikkake was no more than 3 bars ago
                    bool confirmation =
                        i <= patternIdx + 3 &&
                        (
                            // close higher than the high of 3rd
                            patternResult > 0 && inClose[i] > inHigh[patternIdx - 1] ||
                            // close lower than the low of 3rd
                            patternResult < 0 && inClose[i] < inLow[patternIdx - 1]
                        );
                    
                    if (confirmation)
                    {
                        patternIdx = 0;
                    }
                }

                nearPeriodTotal +=
                    GetCandleRange(Near, i - 2, inOpen, inHigh, inLow, inClose) -
                    GetCandleRange(Near, nearTrailingIdx - 2, inOpen, inHigh, inLow, inClose);
                nearTrailingIdx++;
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle
             * - second candle: candle with range less than first candle and close near the bottom (near the top)
             * - third candle: lower high and higher low than 2nd
             * - fourth candle: lower high and lower low (higher high and higher low) than 3rd
             * outInteger[hikkake bar] is positive (1 to 100) or negative (-1 to -100) meaning bullish or bearish hikkake
             * Confirmation could come in the next 3 days with:
             * - a day that closes higher than the high (lower than the low) of the 3rd candle
             * outInteger[confirmationbar] is equal to 100 + the bullish hikkake result or -100 - the bearish hikkake result
             * Note: if confirmation and a new hikkake come at the same bar, only the new hikkake is reported (the new hikkake
             * overwrites the confirmation of the old hikkake);
             * the user should consider that modified hikkake is a reversal pattern, while hikkake could be both a reversal 
             * or a continuation pattern, so bullish (bearish) modified hikkake is significant when appearing in a downtrend 
             * (uptrend)
             */
            
            Label_0174:
            if (i >= startIdx)
            {
                i = startIdx;
                outIdx = 0;
                goto Label_069A;
            }

            if (inHigh[i - 2] >= inHigh[i - 3] || inLow[i - 2] <= inLow[i - 3] || inHigh[i - 1] >= inHigh[i - 2] || inLow[i - 1] <= inLow[i - 2])
            {
                goto Label_04C0;
            }

            if (inHigh[i] < inHigh[i - 1] && inLow[i] < inLow[i - 1])
            {
                double num49;
                if (GetCandleAvgPeriod(Near) != 0.0)
                {
                    num49 = nearPeriodTotal / GetCandleAvgPeriod(Near);
                }
                else
                {
                    double num48;
                    if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                    {
                        num48 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num47;
                        if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                        {
                            num47 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num44;
                            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                            {
                                double num46 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                double num45 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                num44 = inHigh[i - 2] - num46 + (num45 - inLow[i - 2]);
                            }
                            else
                            {
                                num44 = 0.0;
                            }

                            num47 = num44;
                        }

                        num48 = num47;
                    }

                    num49 = num48;
                }

                double num43 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (inClose[i - 2] <= inLow[i - 2] + Globals.candleSettings[8].factor * num49 / num43)
                {
                    goto Label_04A9;
                }
            }

            if (inHigh[i] <= inHigh[i - 1] || inLow[i] <= inLow[i - 1])
            {
                goto Label_04C0;
            }

            if (GetCandleAvgPeriod(Near) != 0.0)
            {
                num42 = nearPeriodTotal / GetCandleAvgPeriod(Near);
            }
            else
            {
                double num41;
                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num41 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                }
                else
                {
                    double num40;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num40 = inHigh[i - 2] - inLow[i - 2];
                    }
                    else
                    {
                        double num37;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num39 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                            double num38 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                            num37 = inHigh[i - 2] - num39 + (num38 - inLow[i - 2]);
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

            if (inClose[i - 2] < inHigh[i - 2] - Globals.candleSettings[8].factor * num42 / num36)
            {
                goto Label_04C0;
            }

            Label_04A9:
            patternResult = (inHigh[i] >= inHigh[i - 1] ? -1 : 1) * 100;
            patternIdx = i;
            goto Label_04E9;
            Label_04C0:
            if (i <= patternIdx + 3 && (patternResult > 0 && inClose[i] > inHigh[patternIdx - 1]
                                        || patternResult < 0 && inClose[i] < inLow[patternIdx - 1]))
            {
                patternIdx = 0;
            }

            Label_04E9:
            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num35 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num34;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num34 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num31;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        double num33 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                        double num32 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
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

            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num30 = Math.Abs(inClose[nearTrailingIdx - 2] - inOpen[nearTrailingIdx - 2]);
            }
            else
            {
                double num29;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num29 = inHigh[nearTrailingIdx - 2] - inLow[nearTrailingIdx - 2];
                }
                else
                {
                    double num26;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        double num28 = inClose[nearTrailingIdx - 2] >= inOpen[nearTrailingIdx - 2] ? inClose[nearTrailingIdx - 2] : inOpen[nearTrailingIdx - 2];
                        double num27 = inClose[nearTrailingIdx - 2] >= inOpen[nearTrailingIdx - 2] ? inOpen[nearTrailingIdx - 2] : inClose[nearTrailingIdx - 2];
                        num26 = inHigh[nearTrailingIdx - 2] - num28 + (num27 - inLow[nearTrailingIdx - 2]);
                    }
                    else
                    {
                        num26 = 0.0;
                    }

                    num29 = num26;
                }

                num30 = num29;
            }

            nearPeriodTotal += num35 - num30;
            nearTrailingIdx++;
            i++;
            goto Label_0174;
            Label_069A:
            if (inHigh[i - 2] >= inHigh[i - 3] || inLow[i - 2] <= inLow[i - 3] || inHigh[i - 1] >= inHigh[i - 2] || inLow[i - 1] <= inLow[i - 2])
            {
                goto Label_09E9;
            }

            if (inHigh[i] < inHigh[i - 1] && inLow[i] < inLow[i - 1])
            {
                double num25;
                if (GetCandleAvgPeriod(Near) != 0.0)
                {
                    num25 = nearPeriodTotal / GetCandleAvgPeriod(Near);
                }
                else
                {
                    double num24;
                    if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                    {
                        num24 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num23;
                        if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                        {
                            num23 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num20;
                            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                            {
                                double num22 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                double num21 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                num20 = inHigh[i - 2] - num22 + (num21 - inLow[i - 2]);
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

                double num19 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (inClose[i - 2] <= inLow[i - 2] + Globals.candleSettings[8].factor * num25 / num19)
                {
                    goto Label_09C8;
                }
            }

            if (inHigh[i] <= inHigh[i - 1] || inLow[i] <= inLow[i - 1])
            {
                goto Label_09E9;
            }

            if (GetCandleAvgPeriod(Near) != 0.0)
            {
                num18 = nearPeriodTotal / GetCandleAvgPeriod(Near);
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

            if (inClose[i - 2] < inHigh[i - 2] - Globals.candleSettings[8].factor * num18 / num12)
            {
                goto Label_09E9;
            }

            Label_09C8:
            patternResult = (inHigh[i] >= inHigh[i - 1] ? -1 : 1) * 100;
            patternIdx = i;
            outInteger[outIdx] = patternResult;
            outIdx++;
            goto Label_0A3A;
            Label_09E9:
            if (i <= patternIdx + 3 && (patternResult > 0 && inClose[i] > inHigh[patternIdx - 1]
                                        || patternResult < 0 && inClose[i] < inLow[patternIdx - 1]))
            {
                int num11;
                if (patternResult > 0)
                {
                    num11 = 1;
                }
                else
                {
                    num11 = -1;
                }

                outInteger[outIdx] = patternResult + num11 * 100;
                outIdx++;
                patternIdx = 0;
            }
            else
            {
                outInteger[outIdx] = 0;
                outIdx++;
            }

            Label_0A3A:
            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        double num8 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                        double num7 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
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

            if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[nearTrailingIdx - 2] - inOpen[nearTrailingIdx - 2]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[nearTrailingIdx - 2] - inLow[nearTrailingIdx - 2];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                    {
                        double num3 = inClose[nearTrailingIdx - 2] >= inOpen[nearTrailingIdx - 2] ? inClose[nearTrailingIdx - 2] : inOpen[nearTrailingIdx - 2];
                        double num2 = inClose[nearTrailingIdx - 2] >= inOpen[nearTrailingIdx - 2] ? inOpen[nearTrailingIdx - 2] : inClose[nearTrailingIdx - 2];
                        num = inHigh[nearTrailingIdx - 2] - num3 + (num2 - inLow[nearTrailingIdx - 2]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            nearPeriodTotal += num10 - num5;
            nearTrailingIdx++;
            i++;
            if (i <= endIdx)
            {
                goto Label_069A;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlHikkakeModLookback()
        {
            return (1 <= GetCandleAvgPeriod(Near) ? GetCandleAvgPeriod(Near) : 1) + 5;
        }
    }
}
