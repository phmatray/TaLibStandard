using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlKickingByLength(
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
            int num70;
            double[] shadowVeryShortPeriodTotal = new double[2];
            double[] bodyLongPeriodTotal = new double[2];
            
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
            int lookbackTotal = CdlKickingByLengthLookback();

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
            shadowVeryShortPeriodTotal[1] = 0.0;
            shadowVeryShortPeriodTotal[0] = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            bodyLongPeriodTotal[1] = 0.0;
            bodyLongPeriodTotal[0] = 0.0;
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal[1] += GetCandleRange(BodyLong, i - 1, inOpen, inHigh, inLow, inClose);
                bodyLongPeriodTotal[0] += GetCandleRange(BodyLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: marubozu
             * - second candle: opposite color marubozu
             * - gap between the two candles: upside gap if black then white, downside gap if white then black
             * The meaning of "long body" and "very short shadow" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish; the longer of the two
             * marubozu determines the bullishness or bearishness of this pattern
             */
            int outIdx = 0;
            Label_0413:
            if (inClose[i] >= inOpen[i])
            {
                num70 = 1;
            }
            else
            {
                num70 = -1;
            }

            if ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -num70)
            {
                double num63;
                double num69;
                if (GetCandleAvgPeriod(BodyLong) != 0.0)
                {
                    num69 = bodyLongPeriodTotal[1] / GetCandleAvgPeriod(BodyLong);
                }
                else
                {
                    double num68;
                    if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                    {
                        num68 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num67;
                        if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                        {
                            num67 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num64;
                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                double num65;
                                double num66;
                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num66 = inClose[i - 1];
                                }
                                else
                                {
                                    num66 = inOpen[i - 1];
                                }

                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num65 = inOpen[i - 1];
                                }
                                else
                                {
                                    num65 = inClose[i - 1];
                                }

                                num64 = inHigh[i - 1] - num66 + (num65 - inLow[i - 1]);
                            }
                            else
                            {
                                num64 = 0.0;
                            }

                            num67 = num64;
                        }

                        num68 = num67;
                    }

                    num69 = num68;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                {
                    num63 = 2.0;
                }
                else
                {
                    num63 = 1.0;
                }

                if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    > Globals.candleSettings[0].factor * num69 / num63)
                {
                    double num55;
                    double num61;
                    double num62;
                    if (inClose[i - 1] >= inOpen[i - 1])
                    {
                        num62 = inClose[i - 1];
                    }
                    else
                    {
                        num62 = inOpen[i - 1];
                    }

                    if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                    {
                        num61 = shadowVeryShortPeriodTotal[1] / GetCandleAvgPeriod(ShadowVeryShort);
                    }
                    else
                    {
                        double num60;
                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                        {
                            num60 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num59;
                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                            {
                                num59 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num56;
                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    double num57;
                                    double num58;
                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num58 = inClose[i - 1];
                                    }
                                    else
                                    {
                                        num58 = inOpen[i - 1];
                                    }

                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num57 = inOpen[i - 1];
                                    }
                                    else
                                    {
                                        num57 = inClose[i - 1];
                                    }

                                    num56 = inHigh[i - 1] - num58 + (num57 - inLow[i - 1]);
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

                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                    {
                        num55 = 2.0;
                    }
                    else
                    {
                        num55 = 1.0;
                    }

                    if (inHigh[i - 1] - num62 < Globals.candleSettings[7].factor * num61 / num55)
                    {
                        double num47;
                        double num53;
                        double num54;
                        if (inClose[i - 1] >= inOpen[i - 1])
                        {
                            num54 = inOpen[i - 1];
                        }
                        else
                        {
                            num54 = inClose[i - 1];
                        }

                        if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                        {
                            num53 = shadowVeryShortPeriodTotal[1] / GetCandleAvgPeriod(ShadowVeryShort);
                        }
                        else
                        {
                            double num52;
                            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                            {
                                num52 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                            }
                            else
                            {
                                double num51;
                                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                {
                                    num51 = inHigh[i - 1] - inLow[i - 1];
                                }
                                else
                                {
                                    double num48;
                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        double num49;
                                        double num50;
                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num50 = inClose[i - 1];
                                        }
                                        else
                                        {
                                            num50 = inOpen[i - 1];
                                        }

                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num49 = inOpen[i - 1];
                                        }
                                        else
                                        {
                                            num49 = inClose[i - 1];
                                        }

                                        num48 = inHigh[i - 1] - num50 + (num49 - inLow[i - 1]);
                                    }
                                    else
                                    {
                                        num48 = 0.0;
                                    }

                                    num51 = num48;
                                }

                                num52 = num51;
                            }

                            num53 = num52;
                        }

                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            num47 = 2.0;
                        }
                        else
                        {
                            num47 = 1.0;
                        }

                        if (num54 - inLow[i - 1] < Globals.candleSettings[7].factor * num53 / num47)
                        {
                            double num40;
                            double num46;
                            if (GetCandleAvgPeriod(BodyLong) != 0.0)
                            {
                                num46 = bodyLongPeriodTotal[0] / GetCandleAvgPeriod(BodyLong);
                            }
                            else
                            {
                                double num45;
                                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                                {
                                    num45 = Math.Abs(inClose[i] - inOpen[i]);
                                }
                                else
                                {
                                    double num44;
                                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                                    {
                                        num44 = inHigh[i] - inLow[i];
                                    }
                                    else
                                    {
                                        double num41;
                                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                                        {
                                            double num42;
                                            double num43;
                                            if (inClose[i] >= inOpen[i])
                                            {
                                                num43 = inClose[i];
                                            }
                                            else
                                            {
                                                num43 = inOpen[i];
                                            }

                                            if (inClose[i] >= inOpen[i])
                                            {
                                                num42 = inOpen[i];
                                            }
                                            else
                                            {
                                                num42 = inClose[i];
                                            }

                                            num41 = inHigh[i] - num43 + (num42 - inLow[i]);
                                        }
                                        else
                                        {
                                            num41 = 0.0;
                                        }

                                        num44 = num41;
                                    }

                                    num45 = num44;
                                }

                                num46 = num45;
                            }

                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                num40 = 2.0;
                            }
                            else
                            {
                                num40 = 1.0;
                            }

                            if (Math.Abs(inClose[i] - inOpen[i])
                                > Globals.candleSettings[0].factor * num46 / num40)
                            {
                                double num32;
                                double num38;
                                double num39;
                                if (inClose[i] >= inOpen[i])
                                {
                                    num39 = inClose[i];
                                }
                                else
                                {
                                    num39 = inOpen[i];
                                }

                                if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                                {
                                    num38 = shadowVeryShortPeriodTotal[0]
                                            / GetCandleAvgPeriod(ShadowVeryShort);
                                }
                                else
                                {
                                    double num37;
                                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                                    {
                                        num37 = Math.Abs(inClose[i] - inOpen[i]);
                                    }
                                    else
                                    {
                                        double num36;
                                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                        {
                                            num36 = inHigh[i] - inLow[i];
                                        }
                                        else
                                        {
                                            double num33;
                                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                            {
                                                double num34;
                                                double num35;
                                                if (inClose[i] >= inOpen[i])
                                                {
                                                    num35 = inClose[i];
                                                }
                                                else
                                                {
                                                    num35 = inOpen[i];
                                                }

                                                if (inClose[i] >= inOpen[i])
                                                {
                                                    num34 = inOpen[i];
                                                }
                                                else
                                                {
                                                    num34 = inClose[i];
                                                }

                                                num33 = inHigh[i] - num35 + (num34 - inLow[i]);
                                            }
                                            else
                                            {
                                                num33 = 0.0;
                                            }

                                            num36 = num33;
                                        }

                                        num37 = num36;
                                    }

                                    num38 = num37;
                                }

                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    num32 = 2.0;
                                }
                                else
                                {
                                    num32 = 1.0;
                                }

                                if (inHigh[i] - num39 < Globals.candleSettings[7].factor * num38 / num32)
                                {
                                    double num24;
                                    double num30;
                                    double num31;
                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num31 = inOpen[i];
                                    }
                                    else
                                    {
                                        num31 = inClose[i];
                                    }

                                    if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                                    {
                                        num30 = shadowVeryShortPeriodTotal[0]
                                                / GetCandleAvgPeriod(ShadowVeryShort);
                                    }
                                    else
                                    {
                                        double num29;
                                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                                        {
                                            num29 = Math.Abs(inClose[i] - inOpen[i]);
                                        }
                                        else
                                        {
                                            double num28;
                                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                            {
                                                num28 = inHigh[i] - inLow[i];
                                            }
                                            else
                                            {
                                                double num25;
                                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                                {
                                                    double num26;
                                                    double num27;
                                                    if (inClose[i] >= inOpen[i])
                                                    {
                                                        num27 = inClose[i];
                                                    }
                                                    else
                                                    {
                                                        num27 = inOpen[i];
                                                    }

                                                    if (inClose[i] >= inOpen[i])
                                                    {
                                                        num26 = inOpen[i];
                                                    }
                                                    else
                                                    {
                                                        num26 = inClose[i];
                                                    }

                                                    num25 = inHigh[i] - num27 + (num26 - inLow[i]);
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

                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        num24 = 2.0;
                                    }
                                    else
                                    {
                                        num24 = 1.0;
                                    }

                                    if (num31 - inLow[i] < Globals.candleSettings[7].factor * num30 / num24
                                        && ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1
                                            && inLow[i] > inHigh[i - 1]
                                            || inClose[i - 1] >= inOpen[i - 1] && inHigh[i] < inLow[i - 1]))
                                    {
                                        int num21;
                                        int num22;
                                        int num23;
                                        if (Math.Abs(inClose[i] - inOpen[i])
                                            > Math.Abs(inClose[i - 1] - inOpen[i - 1]))
                                        {
                                            num23 = i;
                                        }
                                        else
                                        {
                                            num23 = i - 1;
                                        }

                                        if (Math.Abs(inClose[i] - inOpen[i])
                                            > Math.Abs(inClose[i - 1] - inOpen[i - 1]))
                                        {
                                            num22 = i;
                                        }
                                        else
                                        {
                                            num22 = i - 1;
                                        }

                                        if (inClose[num23] >= inOpen[num22])
                                        {
                                            num21 = 1;
                                        }
                                        else
                                        {
                                            num21 = -1;
                                        }

                                        outInteger[outIdx] = num21 * 100;
                                        outIdx++;
                                        goto Label_0D39;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0D39:
            totIdx = 1;
            while (totIdx >= 0)
            {
                double num5;
                double num10;
                double num15;
                double num20;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num20 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num19;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num19 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num16;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num17;
                            double num18;
                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num18 = inClose[i - totIdx];
                            }
                            else
                            {
                                num18 = inOpen[i - totIdx];
                            }

                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num17 = inOpen[i - totIdx];
                            }
                            else
                            {
                                num17 = inClose[i - totIdx];
                            }

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

                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num15 = Math.Abs(
                        inClose[bodyLongTrailingIdx - totIdx] - inOpen[bodyLongTrailingIdx - totIdx]);
                }
                else
                {
                    double num14;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num14 = inHigh[bodyLongTrailingIdx - totIdx] - inLow[bodyLongTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num11;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num12;
                            double num13;
                            if (inClose[bodyLongTrailingIdx - totIdx] >= inOpen[bodyLongTrailingIdx - totIdx])
                            {
                                num13 = inClose[bodyLongTrailingIdx - totIdx];
                            }
                            else
                            {
                                num13 = inOpen[bodyLongTrailingIdx - totIdx];
                            }

                            if (inClose[bodyLongTrailingIdx - totIdx] >= inOpen[bodyLongTrailingIdx - totIdx])
                            {
                                num12 = inOpen[bodyLongTrailingIdx - totIdx];
                            }
                            else
                            {
                                num12 = inClose[bodyLongTrailingIdx - totIdx];
                            }

                            num11 = inHigh[bodyLongTrailingIdx - totIdx] - num13
                                    + (num12 - inLow[bodyLongTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num11 = 0.0;
                        }

                        num14 = num11;
                    }

                    num15 = num14;
                }

                bodyLongPeriodTotal[totIdx] += num20 - num15;
                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num10 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num9;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num9 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num6;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num7;
                            double num8;
                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num8 = inClose[i - totIdx];
                            }
                            else
                            {
                                num8 = inOpen[i - totIdx];
                            }

                            if (inClose[i - totIdx] >= inOpen[i - totIdx])
                            {
                                num7 = inOpen[i - totIdx];
                            }
                            else
                            {
                                num7 = inClose[i - totIdx];
                            }

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

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num5 = Math.Abs(
                        inClose[shadowVeryShortTrailingIdx - totIdx]
                        - inOpen[shadowVeryShortTrailingIdx - totIdx]);
                }
                else
                {
                    double num4;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num4 = inHigh[shadowVeryShortTrailingIdx - totIdx] - inLow[shadowVeryShortTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num2;
                            double num3;
                            if (inClose[shadowVeryShortTrailingIdx - totIdx]
                                >= inOpen[shadowVeryShortTrailingIdx - totIdx])
                            {
                                num3 = inClose[shadowVeryShortTrailingIdx - totIdx];
                            }
                            else
                            {
                                num3 = inOpen[shadowVeryShortTrailingIdx - totIdx];
                            }

                            if (inClose[shadowVeryShortTrailingIdx - totIdx]
                                >= inOpen[shadowVeryShortTrailingIdx - totIdx])
                            {
                                num2 = inOpen[shadowVeryShortTrailingIdx - totIdx];
                            }
                            else
                            {
                                num2 = inClose[shadowVeryShortTrailingIdx - totIdx];
                            }

                            num = inHigh[shadowVeryShortTrailingIdx - totIdx] - num3
                                  + (num2 - inLow[shadowVeryShortTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num = 0.0;
                        }

                        num4 = num;
                    }

                    num5 = num4;
                }

                shadowVeryShortPeriodTotal[totIdx] += num10 - num5;
                totIdx--;
            }

            i++;
            shadowVeryShortTrailingIdx++;
            bodyLongTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0413;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlKickingByLengthLookback()
        {
            return (GetCandleAvgPeriod(ShadowVeryShort) <= GetCandleAvgPeriod(BodyLong)
                         ? GetCandleAvgPeriod(BodyLong)
                         : GetCandleAvgPeriod(ShadowVeryShort)) + 1;
        }
    }
}
