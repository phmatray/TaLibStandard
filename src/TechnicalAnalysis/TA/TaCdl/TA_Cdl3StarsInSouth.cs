using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Cdl3StarsInSouth(
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
            double num25;
            double num30;
            double num35;
            double num40;
            double[] shadowVeryShortPeriodTotal = new double[2];
            
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
            int lookbackTotal = Cdl3StarsInSouthLookback();

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
            double shadowLongPeriodTotal = 0.0;
            int shadowLongTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowLong);
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += GetCandleRange(BodyLong, i - 2, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal += GetCandleRange(ShadowLong, i - 2, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
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
             * - first candle: long black candle with long lower shadow
             * - second candle: smaller black candle that opens higher than prior close but within prior candle's range 
             *   and trades lower than prior close but not lower than prior low and closes off of its low (it has a shadow)
             * - third candle: small black marubozu (or candle with very short shadows) engulfed by prior candle's range
             * The meanings of "long body", "short body", "very short shadow" are specified with TA_SetCandleSettings;
             * outInteger is positive (1 to 100): 3 stars in the south is always bullish;
             * the user should consider that 3 stars in the south is significant when it appears in downtrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            Label_052C:
            if ((inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == -1
                && (inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1 && (inClose[i] < inOpen[i] ? -1 : 1) == -1)
            {
                double num86;
                if (GetCandleAvgPeriod(BodyLong) != 0.0)
                {
                    num86 = bodyLongPeriodTotal / GetCandleAvgPeriod(BodyLong);
                }
                else
                {
                    double num85;
                    if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                    {
                        num85 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num84;
                        if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                        {
                            num84 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num81;
                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                double num83 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                double num82 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                num81 = inHigh[i - 2] - num83 + (num82 - inLow[i - 2]);
                            }
                            else
                            {
                                num81 = 0.0;
                            }

                            num84 = num81;
                        }

                        num85 = num84;
                    }

                    num86 = num85;
                }

                double num80 = Globals.candleSettings[0].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                    > Globals.candleSettings[0].factor * num86 / num80)
                {
                    double num78;
                    double num79 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];

                    if (GetCandleAvgPeriod(ShadowLong) != 0.0)
                    {
                        num78 = shadowLongPeriodTotal / GetCandleAvgPeriod(ShadowLong);
                    }
                    else
                    {
                        double num77;
                        if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
                        {
                            num77 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                        }
                        else
                        {
                            double num76;
                            if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                            {
                                num76 = inHigh[i - 2] - inLow[i - 2];
                            }
                            else
                            {
                                double num73;
                                if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                                {
                                    double num75 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                    double num74 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                    num73 = inHigh[i - 2] - num75 + (num74 - inLow[i - 2]);
                                }
                                else
                                {
                                    num73 = 0.0;
                                }

                                num76 = num73;
                            }

                            num77 = num76;
                        }

                        num78 = num77;
                    }

                    double num72 = Globals.candleSettings[4].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                    if (num79 - inLow[i - 2] > Globals.candleSettings[4].factor * num78 / num72
                        && Math.Abs(inClose[i - 1] - inOpen[i - 1])
                        < Math.Abs(inClose[i - 2] - inOpen[i - 2]) && inOpen[i - 1] > inClose[i - 2] && inOpen[i - 1] <= inHigh[i - 2] && inLow[i - 1] < inClose[i - 2] && inLow[i - 1] >= inLow[i - 2])
                    {
                        double num70;
                        double num71 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];

                        if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                        {
                            num70 = shadowVeryShortPeriodTotal[1] / GetCandleAvgPeriod(ShadowVeryShort);
                        }
                        else
                        {
                            double num69;
                            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                            {
                                num69 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                            }
                            else
                            {
                                double num68;
                                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                {
                                    num68 = inHigh[i - 1] - inLow[i - 1];
                                }
                                else
                                {
                                    double num65;
                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        double num67 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                        double num66 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                        num65 = inHigh[i - 1] - num67 + (num66 - inLow[i - 1]);
                                    }
                                    else
                                    {
                                        num65 = 0.0;
                                    }

                                    num68 = num65;
                                }

                                num69 = num68;
                            }

                            num70 = num69;
                        }

                        double num64 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                        if (num71 - inLow[i - 1] > Globals.candleSettings[7].factor * num70 / num64)
                        {
                            double num63;
                            if (GetCandleAvgPeriod(BodyShort) != 0.0)
                            {
                                num63 = bodyShortPeriodTotal / GetCandleAvgPeriod(BodyShort);
                            }
                            else
                            {
                                double num62;
                                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                                {
                                    num62 = Math.Abs(inClose[i] - inOpen[i]);
                                }
                                else
                                {
                                    double num61;
                                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                                    {
                                        num61 = inHigh[i] - inLow[i];
                                    }
                                    else
                                    {
                                        double num58;
                                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                                        {
                                            double num60 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                            double num59 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                                            num58 = inHigh[i] - num60 + (num59 - inLow[i]);
                                        }
                                        else
                                        {
                                            num58 = 0.0;
                                        }

                                        num61 = num58;
                                    }

                                    num62 = num61;
                                }

                                num63 = num62;
                            }

                            double num57 = Globals.candleSettings[2].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                            if (Math.Abs(inClose[i] - inOpen[i])
                                < Globals.candleSettings[2].factor * num63 / num57)
                            {
                                double num55;
                                double num56 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];

                                if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                                {
                                    num55 = shadowVeryShortPeriodTotal[0]
                                            / GetCandleAvgPeriod(ShadowVeryShort);
                                }
                                else
                                {
                                    double num54;
                                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                                    {
                                        num54 = Math.Abs(inClose[i] - inOpen[i]);
                                    }
                                    else
                                    {
                                        double num53;
                                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                        {
                                            num53 = inHigh[i] - inLow[i];
                                        }
                                        else
                                        {
                                            double num50;
                                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                            {
                                                double num52 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                                double num51 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                                                num50 = inHigh[i] - num52 + (num51 - inLow[i]);
                                            }
                                            else
                                            {
                                                num50 = 0.0;
                                            }

                                            num53 = num50;
                                        }

                                        num54 = num53;
                                    }

                                    num55 = num54;
                                }

                                double num49 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                if (num56 - inLow[i] < Globals.candleSettings[7].factor * num55 / num49)
                                {
                                    double num47;
                                    double num48 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];

                                    if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                                    {
                                        num47 = shadowVeryShortPeriodTotal[0]
                                                / GetCandleAvgPeriod(ShadowVeryShort);
                                    }
                                    else
                                    {
                                        double num46;
                                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                                        {
                                            num46 = Math.Abs(inClose[i] - inOpen[i]);
                                        }
                                        else
                                        {
                                            double num45;
                                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                            {
                                                num45 = inHigh[i] - inLow[i];
                                            }
                                            else
                                            {
                                                double num42;
                                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                                {
                                                    double num44 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                                    double num43 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                                                    num42 = inHigh[i] - num44 + (num43 - inLow[i]);
                                                }
                                                else
                                                {
                                                    num42 = 0.0;
                                                }

                                                num45 = num42;
                                            }

                                            num46 = num45;
                                        }

                                        num47 = num46;
                                    }

                                    double num41 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                    if (inHigh[i] - num48 < Globals.candleSettings[7].factor * num47 / num41
                                        && inLow[i] > inLow[i - 1] && inHigh[i] < inHigh[i - 1])
                                    {
                                        outInteger[outIdx] = 100;
                                        outIdx++;
                                        goto Label_0E31;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0E31:
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num40 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num39;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num39 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num36;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num38 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                        double num37 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                        num36 = inHigh[i - 2] - num38 + (num37 - inLow[i - 2]);
                    }
                    else
                    {
                        num36 = 0.0;
                    }

                    num39 = num36;
                }

                num40 = num39;
            }

            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num35 = Math.Abs(inClose[bodyLongTrailingIdx - 2] - inOpen[bodyLongTrailingIdx - 2]);
            }
            else
            {
                double num34;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num34 = inHigh[bodyLongTrailingIdx - 2] - inLow[bodyLongTrailingIdx - 2];
                }
                else
                {
                    double num31;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num33 = inClose[bodyLongTrailingIdx - 2] >= inOpen[bodyLongTrailingIdx - 2] ? inClose[bodyLongTrailingIdx - 2] : inOpen[bodyLongTrailingIdx - 2];
                        double num32 = inClose[bodyLongTrailingIdx - 2] >= inOpen[bodyLongTrailingIdx - 2] ? inOpen[bodyLongTrailingIdx - 2] : inClose[bodyLongTrailingIdx - 2];
                        num31 = inHigh[bodyLongTrailingIdx - 2] - num33 + (num32 - inLow[bodyLongTrailingIdx - 2]);
                    }
                    else
                    {
                        num31 = 0.0;
                    }

                    num34 = num31;
                }

                num35 = num34;
            }

            bodyLongPeriodTotal += num40 - num35;
            if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
            {
                num30 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
            }
            else
            {
                double num29;
                if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                {
                    num29 = inHigh[i - 2] - inLow[i - 2];
                }
                else
                {
                    double num26;
                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                    {
                        double num28 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                        double num27 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
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

            if (Globals.candleSettings[4].rangeType == RangeType.RealBody)
            {
                num25 = Math.Abs(inClose[shadowLongTrailingIdx - 2] - inOpen[shadowLongTrailingIdx - 2]);
            }
            else
            {
                double num24;
                if (Globals.candleSettings[4].rangeType == RangeType.HighLow)
                {
                    num24 = inHigh[shadowLongTrailingIdx - 2] - inLow[shadowLongTrailingIdx - 2];
                }
                else
                {
                    double num21;
                    if (Globals.candleSettings[4].rangeType == RangeType.Shadows)
                    {
                        double num23 = inClose[shadowLongTrailingIdx - 2] >= inOpen[shadowLongTrailingIdx - 2] ? inClose[shadowLongTrailingIdx - 2] : inOpen[shadowLongTrailingIdx - 2];
                        double num22 = inClose[shadowLongTrailingIdx - 2] >= inOpen[shadowLongTrailingIdx - 2] ? inOpen[shadowLongTrailingIdx - 2] : inClose[shadowLongTrailingIdx - 2];
                        num21 = inHigh[shadowLongTrailingIdx - 2] - num23 + (num22 - inLow[shadowLongTrailingIdx - 2]);
                    }
                    else
                    {
                        num21 = 0.0;
                    }

                    num24 = num21;
                }

                num25 = num24;
            }

            shadowLongPeriodTotal += num30 - num25;
            for (int totIdx = 1; totIdx >= 0; totIdx--)
            {
                double num15;
                double num20;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num20 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num19;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num19 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num16;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num18 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inClose[i - totIdx] : inOpen[i - totIdx];
                            double num17 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inOpen[i - totIdx] : inClose[i - totIdx];
                            num16 = inHigh[i - totIdx] - num18 + (num17 - inLow[i - totIdx]);
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
                    num15 = Math.Abs(
                        inClose[shadowVeryShortTrailingIdx - totIdx]
                        - inOpen[shadowVeryShortTrailingIdx - totIdx]);
                }
                else
                {
                    double num14;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num14 = inHigh[shadowVeryShortTrailingIdx - totIdx]
                                - inLow[shadowVeryShortTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num11;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num13 = inClose[shadowVeryShortTrailingIdx - totIdx] >= inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inClose[shadowVeryShortTrailingIdx - totIdx]
                                : inOpen[shadowVeryShortTrailingIdx - totIdx];

                            double num12 = inClose[shadowVeryShortTrailingIdx - totIdx] >= inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inOpen[shadowVeryShortTrailingIdx - totIdx]
                                : inClose[shadowVeryShortTrailingIdx - totIdx];

                            num11 = inHigh[shadowVeryShortTrailingIdx - totIdx] - num13
                                    + (num12 - inLow[shadowVeryShortTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num11 = 0.0;
                        }

                        num14 = num11;
                    }

                    num15 = num14;
                }

                shadowVeryShortPeriodTotal[totIdx] += num20 - num15;
            }

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
                        double num8 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                        double num7 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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
                        double num3 = inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx] ? inClose[bodyShortTrailingIdx] : inOpen[bodyShortTrailingIdx];
                        double num2 = inClose[bodyShortTrailingIdx] >= inOpen[bodyShortTrailingIdx] ? inOpen[bodyShortTrailingIdx] : inClose[bodyShortTrailingIdx];
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
            shadowLongTrailingIdx++;
            shadowVeryShortTrailingIdx++;
            bodyShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_052C;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int Cdl3StarsInSouthLookback()
        {
            int num;
            int avgPeriod = GetCandleAvgPeriod(BodyLong) > GetCandleAvgPeriod(BodyShort)
                ? GetCandleAvgPeriod(BodyLong)
                : GetCandleAvgPeriod(BodyShort);

            if ((GetCandleAvgPeriod(ShadowVeryShort) <= GetCandleAvgPeriod(ShadowLong)
                     ? GetCandleAvgPeriod(ShadowLong)
                     : GetCandleAvgPeriod(ShadowVeryShort)) > avgPeriod)
            {
                num = GetCandleAvgPeriod(ShadowVeryShort) <= GetCandleAvgPeriod(ShadowLong)
                    ? GetCandleAvgPeriod(ShadowLong)
                    : GetCandleAvgPeriod(ShadowVeryShort);
            }
            else
            {
                num = GetCandleAvgPeriod(BodyLong) <= GetCandleAvgPeriod(BodyShort)
                    ? GetCandleAvgPeriod(BodyShort)
                    : GetCandleAvgPeriod(BodyLong);
            }

            return num + 2;
        }
    }
}
