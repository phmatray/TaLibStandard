using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlStalledPattern(
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
            int totIdx;
            double num5;
            double num10;
            double num15;
            double num20;
            double[] bodyLongPeriodTotal = new double[3];
            double[] nearPeriodTotal = new double[3];
            
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
            int lookbackTotal = CdlStalledPatternLookback();

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
            bodyLongPeriodTotal[2] = 0.0;
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            nearPeriodTotal[2] = 0.0;
            nearPeriodTotal[1] = 0.0;
            nearPeriodTotal[0] = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            
            int i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal[2] += GetCandleRange(BodyLong, i - 2, inOpen, inHigh, inLow, inClose);
                bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyShortPeriodTotal += GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[2] += GetCandleRange(Near, i - 2, inOpen, inHigh, inLow, inClose);
                nearPeriodTotal[1] += GetCandleRange(Near, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three white candlesticks with consecutively higher closes
             * - first candle: long white
             * - second candle: long white with no or very short upper shadow opening within or near the previous white real body
             * and closing higher than the prior candle
             * - third candle: small white that gaps away or "rides on the shoulder" of the prior long real body (= it's at 
             * the upper end of the prior real body)
             * The meanings of "long", "very short", "short", "near" are specified with TA_SetCandleSettings;
             * outInteger is negative (-1 to -100): stalled pattern is always bearish;
             * the user should consider that stalled pattern is significant when it appears in uptrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            Label_0656:
            if (inClose[i - 2] >= inOpen[i - 2] && inClose[i - 1] >= inOpen[i - 1] && inClose[i] >= inOpen[i] && inClose[i] > inClose[i - 1] && inClose[i - 1] > inClose[i - 2])
            {
                double num77;
                double num83;
                if (GetCandleAvgPeriod(BodyLong) != 0.0)
                {
                    num83 = bodyLongPeriodTotal[2] / GetCandleAvgPeriod(BodyLong);
                }
                else
                {
                    double num82;
                    if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                    {
                        num82 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num81;
                        if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                        {
                            num81 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num78;
                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                double num79;
                                double num80;
                                if (inClose[i - 2] >= inOpen[i - 2])
                                {
                                    num80 = inClose[i - 2];
                                }
                                else
                                {
                                    num80 = inOpen[i - 2];
                                }

                                if (inClose[i - 2] >= inOpen[i - 2])
                                {
                                    num79 = inOpen[i - 2];
                                }
                                else
                                {
                                    num79 = inClose[i - 2];
                                }

                                num78 = inHigh[i - 2] - num80 + (num79 - inLow[i - 2]);
                            }
                            else
                            {
                                num78 = 0.0;
                            }

                            num81 = num78;
                        }

                        num82 = num81;
                    }

                    num83 = num82;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                {
                    num77 = 2.0;
                }
                else
                {
                    num77 = 1.0;
                }

                if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                    > Globals.candleSettings[0].factor * num83 / num77)
                {
                    double num70;
                    double num76;
                    if (GetCandleAvgPeriod(BodyLong) != 0.0)
                    {
                        num76 = bodyLongPeriodTotal[1] / GetCandleAvgPeriod(BodyLong);
                    }
                    else
                    {
                        double num75;
                        if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                        {
                            num75 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num74;
                            if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                            {
                                num74 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num71;
                                if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                                {
                                    double num72;
                                    double num73;
                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num73 = inClose[i - 1];
                                    }
                                    else
                                    {
                                        num73 = inOpen[i - 1];
                                    }

                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num72 = inOpen[i - 1];
                                    }
                                    else
                                    {
                                        num72 = inClose[i - 1];
                                    }

                                    num71 = inHigh[i - 1] - num73 + (num72 - inLow[i - 1]);
                                }
                                else
                                {
                                    num71 = 0.0;
                                }

                                num74 = num71;
                            }

                            num75 = num74;
                        }

                        num76 = num75;
                    }

                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        num70 = 2.0;
                    }
                    else
                    {
                        num70 = 1.0;
                    }

                    if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                        > Globals.candleSettings[0].factor * num76 / num70)
                    {
                        double num62;
                        double num68;
                        double num69;
                        if (inClose[i - 1] >= inOpen[i - 1])
                        {
                            num69 = inClose[i - 1];
                        }
                        else
                        {
                            num69 = inOpen[i - 1];
                        }

                        if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                        {
                            num68 = shadowVeryShortPeriodTotal / GetCandleAvgPeriod(ShadowVeryShort);
                        }
                        else
                        {
                            double num67;
                            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                            {
                                num67 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                            }
                            else
                            {
                                double num66;
                                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                {
                                    num66 = inHigh[i - 1] - inLow[i - 1];
                                }
                                else
                                {
                                    double num63;
                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        double num64;
                                        double num65;
                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num65 = inClose[i - 1];
                                        }
                                        else
                                        {
                                            num65 = inOpen[i - 1];
                                        }

                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num64 = inOpen[i - 1];
                                        }
                                        else
                                        {
                                            num64 = inClose[i - 1];
                                        }

                                        num63 = inHigh[i - 1] - num65 + (num64 - inLow[i - 1]);
                                    }
                                    else
                                    {
                                        num63 = 0.0;
                                    }

                                    num66 = num63;
                                }

                                num67 = num66;
                            }

                            num68 = num67;
                        }

                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            num62 = 2.0;
                        }
                        else
                        {
                            num62 = 1.0;
                        }

                        if (inHigh[i - 1] - num69 < Globals.candleSettings[7].factor * num68 / num62
                            && inOpen[i - 1] > inOpen[i - 2])
                        {
                            double num55;
                            double num61;
                            if (GetCandleAvgPeriod(Near) != 0.0)
                            {
                                num61 = nearPeriodTotal[2] / GetCandleAvgPeriod(Near);
                            }
                            else
                            {
                                double num60;
                                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                                {
                                    num60 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                                }
                                else
                                {
                                    double num59;
                                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                    {
                                        num59 = inHigh[i - 2] - inLow[i - 2];
                                    }
                                    else
                                    {
                                        double num56;
                                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                        {
                                            double num57;
                                            double num58;
                                            if (inClose[i - 2] >= inOpen[i - 2])
                                            {
                                                num58 = inClose[i - 2];
                                            }
                                            else
                                            {
                                                num58 = inOpen[i - 2];
                                            }

                                            if (inClose[i - 2] >= inOpen[i - 2])
                                            {
                                                num57 = inOpen[i - 2];
                                            }
                                            else
                                            {
                                                num57 = inClose[i - 2];
                                            }

                                            num56 = inHigh[i - 2] - num58 + (num57 - inLow[i - 2]);
                                        }
                                        else
                                        {
                                            num56 = 0.0;
                                        }

                                        num59 = num56;
                                    }

                                    num60 = num59;
                                }

                                num61 = num60;
                            }

                            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                            {
                                num55 = 2.0;
                            }
                            else
                            {
                                num55 = 1.0;
                            }

                            if (inOpen[i - 1]
                                <= inClose[i - 2] + Globals.candleSettings[8].factor * num61 / num55)
                            {
                                double num48;
                                double num54;
                                if (GetCandleAvgPeriod(BodyShort) != 0.0)
                                {
                                    num54 = bodyShortPeriodTotal / GetCandleAvgPeriod(BodyShort);
                                }
                                else
                                {
                                    double num53;
                                    if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                                    {
                                        num53 = Math.Abs(inClose[i] - inOpen[i]);
                                    }
                                    else
                                    {
                                        double num52;
                                        if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                                        {
                                            num52 = inHigh[i] - inLow[i];
                                        }
                                        else
                                        {
                                            double num49;
                                            if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                                            {
                                                double num50;
                                                double num51;
                                                if (inClose[i] >= inOpen[i])
                                                {
                                                    num51 = inClose[i];
                                                }
                                                else
                                                {
                                                    num51 = inOpen[i];
                                                }

                                                if (inClose[i] >= inOpen[i])
                                                {
                                                    num50 = inOpen[i];
                                                }
                                                else
                                                {
                                                    num50 = inClose[i];
                                                }

                                                num49 = inHigh[i] - num51 + (num50 - inLow[i]);
                                            }
                                            else
                                            {
                                                num49 = 0.0;
                                            }

                                            num52 = num49;
                                        }

                                        num53 = num52;
                                    }

                                    num54 = num53;
                                }

                                if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                                {
                                    num48 = 2.0;
                                }
                                else
                                {
                                    num48 = 1.0;
                                }

                                if (Math.Abs(inClose[i] - inOpen[i])
                                    < Globals.candleSettings[2].factor * num54 / num48)
                                {
                                    double num41;
                                    double num47;
                                    if (GetCandleAvgPeriod(Near) != 0.0)
                                    {
                                        num47 = nearPeriodTotal[1] / GetCandleAvgPeriod(Near);
                                    }
                                    else
                                    {
                                        double num46;
                                        if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                                        {
                                            num46 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                                        }
                                        else
                                        {
                                            double num45;
                                            if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                            {
                                                num45 = inHigh[i - 1] - inLow[i - 1];
                                            }
                                            else
                                            {
                                                double num42;
                                                if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                                {
                                                    double num43;
                                                    double num44;
                                                    if (inClose[i - 1] >= inOpen[i - 1])
                                                    {
                                                        num44 = inClose[i - 1];
                                                    }
                                                    else
                                                    {
                                                        num44 = inOpen[i - 1];
                                                    }

                                                    if (inClose[i - 1] >= inOpen[i - 1])
                                                    {
                                                        num43 = inOpen[i - 1];
                                                    }
                                                    else
                                                    {
                                                        num43 = inClose[i - 1];
                                                    }

                                                    num42 = inHigh[i - 1] - num44 + (num43 - inLow[i - 1]);
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

                                    if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                    {
                                        num41 = 2.0;
                                    }
                                    else
                                    {
                                        num41 = 1.0;
                                    }

                                    if (inOpen[i] >= inClose[i - 1] - Math.Abs(inClose[i] - inOpen[i])
                                                                    - Globals.candleSettings[8].factor * num47 / num41)
                                    {
                                        outInteger[outIdx] = -100;
                                        outIdx++;
                                        goto Label_0F20;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0F20:
            totIdx = 2;
            while (totIdx >= 1)
            {
                double num25;
                double num30;
                double num35;
                double num40;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num40 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num39;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num39 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num36;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num37;
                            double num38;
                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num38 = inClose[i - totIdx];
                            }
                            else
                            {
                                num38 = inOpen[i - totIdx];
                            }

                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num37 = inOpen[i - totIdx];
                            }
                            else
                            {
                                num37 = inClose[i - totIdx];
                            }

                            num36 = inHigh[i - totIdx] - num38 + (num37 - inLow[i - totIdx]);
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
                    num35 = Math.Abs(
                        inClose[bodyLongTrailingIdx - totIdx] - inOpen[bodyLongTrailingIdx - totIdx]);
                }
                else
                {
                    double num34;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num34 = inHigh[bodyLongTrailingIdx - totIdx] - inLow[bodyLongTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num31;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num32;
                            double num33;
                            if (inClose[bodyLongTrailingIdx - totIdx] >= inOpen[bodyLongTrailingIdx - totIdx])
                            {
                                num33 = inClose[bodyLongTrailingIdx - totIdx];
                            }
                            else
                            {
                                num33 = inOpen[bodyLongTrailingIdx - totIdx];
                            }

                            if (inClose[bodyLongTrailingIdx - totIdx] >= inOpen[bodyLongTrailingIdx - totIdx])
                            {
                                num32 = inOpen[bodyLongTrailingIdx - totIdx];
                            }
                            else
                            {
                                num32 = inClose[bodyLongTrailingIdx - totIdx];
                            }

                            num31 = inHigh[bodyLongTrailingIdx - totIdx] - num33
                                    + (num32 - inLow[bodyLongTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num31 = 0.0;
                        }

                        num34 = num31;
                    }

                    num35 = num34;
                }

                bodyLongPeriodTotal[totIdx] += num40 - num35;
                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num30 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num29;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num29 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num26;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num27;
                            double num28;
                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num28 = inClose[i - totIdx];
                            }
                            else
                            {
                                num28 = inOpen[i - totIdx];
                            }

                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num27 = inOpen[i - totIdx];
                            }
                            else
                            {
                                num27 = inClose[i - totIdx];
                            }

                            num26 = inHigh[i - totIdx] - num28 + (num27 - inLow[i - totIdx]);
                        }
                        else
                        {
                            num26 = 0.0;
                        }

                        num29 = num26;
                    }

                    num30 = num29;
                }

                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num25 = Math.Abs(inClose[nearTrailingIdx - totIdx] - inOpen[nearTrailingIdx - totIdx]);
                }
                else
                {
                    double num24;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num24 = inHigh[nearTrailingIdx - totIdx] - inLow[nearTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num21;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num22;
                            double num23;
                            if (inClose[nearTrailingIdx - totIdx] >= inOpen[nearTrailingIdx - totIdx])
                            {
                                num23 = inClose[nearTrailingIdx - totIdx];
                            }
                            else
                            {
                                num23 = inOpen[nearTrailingIdx - totIdx];
                            }

                            if (inClose[nearTrailingIdx - totIdx] >= inOpen[nearTrailingIdx - totIdx])
                            {
                                num22 = inOpen[nearTrailingIdx - totIdx];
                            }
                            else
                            {
                                num22 = inClose[nearTrailingIdx - totIdx];
                            }

                            num21 = inHigh[nearTrailingIdx - totIdx] - num23
                                    + (num22 - inLow[nearTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num21 = 0.0;
                        }

                        num24 = num21;
                    }

                    num25 = num24;
                }

                nearPeriodTotal[totIdx] += num30 - num25;
                totIdx--;
            }

            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        double num17;
                        double num18;
                        if (inClose[i] >= inOpen[i])
                        {
                            num18 = inClose[i];
                        }
                        else
                        {
                            num18 = inOpen[i];
                        }

                        if (inClose[i] >= inOpen[i])
                        {
                            num17 = inOpen[i];
                        }
                        else
                        {
                            num17 = inClose[i];
                        }

                        num16 = inHigh[i] - num18 + (num17 - inLow[i]);
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
            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i - 1] - inLow[i - 1];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(
                    inClose[shadowVeryShortTrailingIdx - 1] - inOpen[shadowVeryShortTrailingIdx - 1]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[shadowVeryShortTrailingIdx - 1] - inLow[shadowVeryShortTrailingIdx - 1];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[shadowVeryShortTrailingIdx - 1] >= inOpen[shadowVeryShortTrailingIdx - 1])
                        {
                            num3 = inClose[shadowVeryShortTrailingIdx - 1];
                        }
                        else
                        {
                            num3 = inOpen[shadowVeryShortTrailingIdx - 1];
                        }

                        if (inClose[shadowVeryShortTrailingIdx - 1] >= inOpen[shadowVeryShortTrailingIdx - 1])
                        {
                            num2 = inOpen[shadowVeryShortTrailingIdx - 1];
                        }
                        else
                        {
                            num2 = inClose[shadowVeryShortTrailingIdx - 1];
                        }

                        num = inHigh[shadowVeryShortTrailingIdx - 1] - num3
                              + (num2 - inLow[shadowVeryShortTrailingIdx - 1]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            shadowVeryShortPeriodTotal += num10 - num5;
            i++;
            bodyLongTrailingIdx++;
            bodyShortTrailingIdx++;
            shadowVeryShortTrailingIdx++;
            nearTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0656;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlStalledPatternLookback()
        {
            int num;
            int avgPeriod;
            if (GetCandleAvgPeriod(ShadowVeryShort) > GetCandleAvgPeriod(Near))
            {
                avgPeriod = GetCandleAvgPeriod(ShadowVeryShort);
            }
            else
            {
                avgPeriod = GetCandleAvgPeriod(Near);
            }

            if ((GetCandleAvgPeriod(BodyLong) <= GetCandleAvgPeriod(BodyShort)
                     ? GetCandleAvgPeriod(BodyShort)
                     : GetCandleAvgPeriod(BodyLong)) > avgPeriod)
            {
                num = GetCandleAvgPeriod(BodyLong) <= GetCandleAvgPeriod(BodyShort)
                          ? GetCandleAvgPeriod(BodyShort)
                          : GetCandleAvgPeriod(BodyLong);
            }
            else
            {
                num = GetCandleAvgPeriod(ShadowVeryShort) <= GetCandleAvgPeriod(Near)
                          ? GetCandleAvgPeriod(Near)
                          : GetCandleAvgPeriod(ShadowVeryShort);
            }

            return num + 2;
        }
    }
}
