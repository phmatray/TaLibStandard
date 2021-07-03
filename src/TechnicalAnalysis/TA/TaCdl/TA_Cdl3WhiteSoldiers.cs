using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Cdl3WhiteSoldiers(
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
            double[] shadowVeryShortPeriodTotal = new double[3];
            double[] nearPeriodTotal = new double[3];
            double[] farPeriodTotal = new double[3];
            
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
            int lookbackTotal = Cdl3WhiteSoldiersLookback();

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
            shadowVeryShortPeriodTotal[2] = 0.0;
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            nearPeriodTotal[2] = 0.0;
            nearPeriodTotal[1] = 0.0;
            nearPeriodTotal[0] = 0.0;
            int nearTrailingIdx = startIdx - GetCandleAvgPeriod(Near);
            farPeriodTotal[2] = 0.0;
            farPeriodTotal[1] = 0.0;
            farPeriodTotal[0] = 0.0;
            int farTrailingIdx = startIdx - GetCandleAvgPeriod(Far);
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[2] += GetCandleRange(ShadowVeryShort, i - 2, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[2] += GetCandleRange(Near, i - 2, inOpen, inHigh, inLow, inClose);
                nearPeriodTotal[1] += GetCandleRange(Near, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = farTrailingIdx;
            while (i < startIdx)
            {
                farPeriodTotal[2] += GetCandleRange(Far, i - 2, inOpen, inHigh, inLow, inClose);
                farPeriodTotal[1] += GetCandleRange(Far, i - 1, inOpen, inHigh, inLow, inClose);
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
             * - three white candlesticks with consecutively higher closes
             * - Greg Morris wants them to be long, Steve Nison doesn't; anyway they should not be short
             * - each candle opens within or near the previous white real body 
             * - each candle must have no or very short upper shadow
             * - to differentiate this pattern from advance block, each candle must not be far shorter than the prior candle
             * The meanings of "not short", "very short shadow", "far" and "near" are specified with TA_SetCandleSettings;
             * here the 3 candles must be not short, if you want them to be long use TA_SetCandleSettings on BodyShort;
             * outInteger is positive (1 to 100): advancing 3 white soldiers is always bullish;
             * the user should consider that 3 white soldiers is significant when it appears in downtrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            Label_08A5:
            if (inClose[i - 2] >= inOpen[i - 2])
            {
                double num98;
                double num99 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];

                if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                {
                    num98 = shadowVeryShortPeriodTotal[2] / GetCandleAvgPeriod(ShadowVeryShort);
                }
                else
                {
                    double num97;
                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                    {
                        num97 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num96;
                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                        {
                            num96 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num93;
                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                            {
                                double num95 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                double num94 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                num93 = inHigh[i - 2] - num95 + (num94 - inLow[i - 2]);
                            }
                            else
                            {
                                num93 = 0.0;
                            }

                            num96 = num93;
                        }

                        num97 = num96;
                    }

                    num98 = num97;
                }

                double num92 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (inHigh[i - 2] - num99 < Globals.candleSettings[7].factor * num98 / num92
                    && inClose[i - 1] >= inOpen[i - 1])
                {
                    double num90;
                    double num91 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];

                    if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                    {
                        num90 = shadowVeryShortPeriodTotal[1] / GetCandleAvgPeriod(ShadowVeryShort);
                    }
                    else
                    {
                        double num89;
                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                        {
                            num89 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num88;
                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                            {
                                num88 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num85;
                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    double num87 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                    double num86 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                    num85 = inHigh[i - 1] - num87 + (num86 - inLow[i - 1]);
                                }
                                else
                                {
                                    num85 = 0.0;
                                }

                                num88 = num85;
                            }

                            num89 = num88;
                        }

                        num90 = num89;
                    }

                    double num84 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                    if (inHigh[i - 1] - num91 < Globals.candleSettings[7].factor * num90 / num84
                        && inClose[i] >= inOpen[i])
                    {
                        double num82;
                        double num83 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];

                        if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                        {
                            num82 = shadowVeryShortPeriodTotal[0] / GetCandleAvgPeriod(ShadowVeryShort);
                        }
                        else
                        {
                            double num81;
                            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                            {
                                num81 = Math.Abs(inClose[i] - inOpen[i]);
                            }
                            else
                            {
                                double num80;
                                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                {
                                    num80 = inHigh[i] - inLow[i];
                                }
                                else
                                {
                                    double num77;
                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        double num79 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                        double num78 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                                        num77 = inHigh[i] - num79 + (num78 - inLow[i]);
                                    }
                                    else
                                    {
                                        num77 = 0.0;
                                    }

                                    num80 = num77;
                                }

                                num81 = num80;
                            }

                            num82 = num81;
                        }

                        double num76 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                        if (inHigh[i] - num83 < Globals.candleSettings[7].factor * num82 / num76
                            && inClose[i] > inClose[i - 1] && inClose[i - 1] > inClose[i - 2] &&
                            inOpen[i - 1] > inOpen[i - 2])
                        {
                            double num75;
                            if (GetCandleAvgPeriod(Near) != 0.0)
                            {
                                num75 = nearPeriodTotal[2] / GetCandleAvgPeriod(Near);
                            }
                            else
                            {
                                double num74;
                                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                                {
                                    num74 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                                }
                                else
                                {
                                    double num73;
                                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                    {
                                        num73 = inHigh[i - 2] - inLow[i - 2];
                                    }
                                    else
                                    {
                                        double num70;
                                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                        {
                                            double num72 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                            double num71 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
                                            num70 = inHigh[i - 2] - num72 + (num71 - inLow[i - 2]);
                                        }
                                        else
                                        {
                                            num70 = 0.0;
                                        }

                                        num73 = num70;
                                    }

                                    num74 = num73;
                                }

                                num75 = num74;
                            }

                            double num69 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                            if (inOpen[i - 1]
                                <= inClose[i - 2] + Globals.candleSettings[8].factor * num75 / num69
                                && inOpen[i] > inOpen[i - 1])
                            {
                                double num68;
                                if (GetCandleAvgPeriod(Near) != 0.0)
                                {
                                    num68 = nearPeriodTotal[1] / GetCandleAvgPeriod(Near);
                                }
                                else
                                {
                                    double num67;
                                    if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                                    {
                                        num67 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                                    }
                                    else
                                    {
                                        double num66;
                                        if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                                        {
                                            num66 = inHigh[i - 1] - inLow[i - 1];
                                        }
                                        else
                                        {
                                            double num63;
                                            if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                                            {
                                                double num65 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                                double num64 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
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

                                double num62 = Globals.candleSettings[8].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                if (inOpen[i] <= inClose[i - 1]
                                    + Globals.candleSettings[8].factor * num68 / num62)
                                {
                                    double num61;
                                    if (GetCandleAvgPeriod(Far) != 0.0)
                                    {
                                        num61 = farPeriodTotal[2] / GetCandleAvgPeriod(Far);
                                    }
                                    else
                                    {
                                        double num60;
                                        if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                                        {
                                            num60 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                                        }
                                        else
                                        {
                                            double num59;
                                            if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                                            {
                                                num59 = inHigh[i - 2] - inLow[i - 2];
                                            }
                                            else
                                            {
                                                double num56;
                                                if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                                                {
                                                    double num58 = inClose[i - 2] >= inOpen[i - 2] ? inClose[i - 2] : inOpen[i - 2];
                                                    double num57 = inClose[i - 2] >= inOpen[i - 2] ? inOpen[i - 2] : inClose[i - 2];
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

                                    double num55 = Globals.candleSettings[9].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                    if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                                        > Math.Abs(inClose[i - 2] - inOpen[i - 2])
                                        - Globals.candleSettings[9].factor * num61 / num55)
                                    {
                                        double num54;
                                        if (GetCandleAvgPeriod(Far) != 0.0)
                                        {
                                            num54 = farPeriodTotal[1] / GetCandleAvgPeriod(Far);
                                        }
                                        else
                                        {
                                            double num53;
                                            if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                                            {
                                                num53 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                                            }
                                            else
                                            {
                                                double num52;
                                                if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                                                {
                                                    num52 = inHigh[i - 1] - inLow[i - 1];
                                                }
                                                else
                                                {
                                                    double num49;
                                                    if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                                                    {
                                                        double num51 = inClose[i - 1] >= inOpen[i - 1] ? inClose[i - 1] : inOpen[i - 1];
                                                        double num50 = inClose[i - 1] >= inOpen[i - 1] ? inOpen[i - 1] : inClose[i - 1];
                                                        num49 = inHigh[i - 1] - num51 + (num50 - inLow[i - 1]);
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

                                        double num48 = Globals.candleSettings[9].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                        if (Math.Abs(inClose[i] - inOpen[i])
                                            > Math.Abs(inClose[i - 1] - inOpen[i - 1])
                                            - Globals.candleSettings[9].factor * num54 / num48)
                                        {
                                            double num47;
                                            if (GetCandleAvgPeriod(BodyShort) != 0.0)
                                            {
                                                num47 = bodyShortPeriodTotal
                                                        / GetCandleAvgPeriod(BodyShort);
                                            }
                                            else
                                            {
                                                double num46;
                                                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                                                {
                                                    num46 = Math.Abs(inClose[i] - inOpen[i]);
                                                }
                                                else
                                                {
                                                    double num45;
                                                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                                                    {
                                                        num45 = inHigh[i] - inLow[i];
                                                    }
                                                    else
                                                    {
                                                        double num42;
                                                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
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

                                            double num41 = Globals.candleSettings[2].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                                            if (Math.Abs(inClose[i] - inOpen[i])
                                                > Globals.candleSettings[2].factor * num47 / num41)
                                            {
                                                outInteger[outIdx] = 100;
                                                outIdx++;
                                                goto Label_1465;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_1465:
            int totIdx = 2;
            while (totIdx >= 0)
            {
                double num35;
                double num40;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num40 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num39;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num39 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num36;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num38 = inClose[i - totIdx] >= inOpen[i - totIdx]
                                ? inClose[i - totIdx]
                                : inOpen[i - totIdx];
                            double num37 = inClose[i - totIdx] >= inOpen[i - totIdx]
                                ? inOpen[i - totIdx]
                                : inClose[i - totIdx];
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

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num35 = Math.Abs(
                        inClose[shadowVeryShortTrailingIdx - totIdx]
                        - inOpen[shadowVeryShortTrailingIdx - totIdx]);
                }
                else
                {
                    double num34;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num34 = inHigh[shadowVeryShortTrailingIdx - totIdx]
                                - inLow[shadowVeryShortTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num31;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num33 = inClose[shadowVeryShortTrailingIdx - totIdx] >= inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inClose[shadowVeryShortTrailingIdx - totIdx]
                                : inOpen[shadowVeryShortTrailingIdx - totIdx];

                            double num32 = inClose[shadowVeryShortTrailingIdx - totIdx] >= inOpen[shadowVeryShortTrailingIdx - totIdx]
                                ? inOpen[shadowVeryShortTrailingIdx - totIdx]
                                : inClose[shadowVeryShortTrailingIdx - totIdx];

                            num31 = inHigh[shadowVeryShortTrailingIdx - totIdx] - num33
                                    + (num32 - inLow[shadowVeryShortTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num31 = 0.0;
                        }

                        num34 = num31;
                    }

                    num35 = num34;
                }

                shadowVeryShortPeriodTotal[totIdx] += num40 - num35;
                totIdx--;
            }

            for (totIdx = 2; totIdx >= 1; totIdx--)
            {
                double num15;
                double num20;
                double num25;
                double num30;
                if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                {
                    num30 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num29;
                    if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                    {
                        num29 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num26;
                        if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                        {
                            double num28 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inClose[i - totIdx] : inOpen[i - totIdx];
                            double num27 = inClose[i - totIdx] >= inOpen[i - totIdx] ? inOpen[i - totIdx] : inClose[i - totIdx];
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

                if (Globals.candleSettings[9].rangeType == RangeType.RealBody)
                {
                    num25 = Math.Abs(inClose[farTrailingIdx - totIdx] - inOpen[farTrailingIdx - totIdx]);
                }
                else
                {
                    double num24;
                    if (Globals.candleSettings[9].rangeType == RangeType.HighLow)
                    {
                        num24 = inHigh[farTrailingIdx - totIdx] - inLow[farTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num21;
                        if (Globals.candleSettings[9].rangeType == RangeType.Shadows)
                        {
                            double num23 = inClose[farTrailingIdx - totIdx] >= inOpen[farTrailingIdx - totIdx] ? inClose[farTrailingIdx - totIdx] : inOpen[farTrailingIdx - totIdx];
                            double num22 = inClose[farTrailingIdx - totIdx] >= inOpen[farTrailingIdx - totIdx] ? inOpen[farTrailingIdx - totIdx] : inClose[farTrailingIdx - totIdx];
                            num21 = inHigh[farTrailingIdx - totIdx] - num23 + (num22 - inLow[farTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num21 = 0.0;
                        }

                        num24 = num21;
                    }

                    num25 = num24;
                }

                farPeriodTotal[totIdx] += num30 - num25;
                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num20 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num19;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num19 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num16;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
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

                if (Globals.candleSettings[8].rangeType == RangeType.RealBody)
                {
                    num15 = Math.Abs(inClose[nearTrailingIdx - totIdx] - inOpen[nearTrailingIdx - totIdx]);
                }
                else
                {
                    double num14;
                    if (Globals.candleSettings[8].rangeType == RangeType.HighLow)
                    {
                        num14 = inHigh[nearTrailingIdx - totIdx] - inLow[nearTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num11;
                        if (Globals.candleSettings[8].rangeType == RangeType.Shadows)
                        {
                            double num13 = inClose[nearTrailingIdx - totIdx] >= inOpen[nearTrailingIdx - totIdx] ? inClose[nearTrailingIdx - totIdx] : inOpen[nearTrailingIdx - totIdx];
                            double num12 = inClose[nearTrailingIdx - totIdx] >= inOpen[nearTrailingIdx - totIdx] ? inOpen[nearTrailingIdx - totIdx] : inClose[nearTrailingIdx - totIdx];
                            num11 = inHigh[nearTrailingIdx - totIdx] - num13 + (num12 - inLow[nearTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num11 = 0.0;
                        }

                        num14 = num11;
                    }

                    num15 = num14;
                }

                nearPeriodTotal[totIdx] += num20 - num15;
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
            shadowVeryShortTrailingIdx++;
            nearTrailingIdx++;
            farTrailingIdx++;
            bodyShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_08A5;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int Cdl3WhiteSoldiersLookback()
        {
            int num;
            int avgPeriod = GetCandleAvgPeriod(Far) > GetCandleAvgPeriod(Near) ? GetCandleAvgPeriod(Far) : GetCandleAvgPeriod(Near);

            if ((GetCandleAvgPeriod(ShadowVeryShort) <= GetCandleAvgPeriod(BodyShort)
                ? GetCandleAvgPeriod(BodyShort)
                : GetCandleAvgPeriod(ShadowVeryShort)) > avgPeriod)
            {
                num = GetCandleAvgPeriod(ShadowVeryShort) <= GetCandleAvgPeriod(BodyShort)
                    ? GetCandleAvgPeriod(BodyShort)
                    : GetCandleAvgPeriod(ShadowVeryShort);
            }
            else
            {
                num = GetCandleAvgPeriod(Far) <= GetCandleAvgPeriod(Near)
                    ? GetCandleAvgPeriod(Near)
                    : GetCandleAvgPeriod(Far);
            }

            return num + 2;
        }
    }
}
