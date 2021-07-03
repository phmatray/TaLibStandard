using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlKicking(
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
            int num68;
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
            int lookbackTotal = CdlKickingLookback();

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
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish
             */
            int outIdx = 0;
            Label_0413:
            if (inClose[i] >= inOpen[i])
            {
                num68 = 1;
            }
            else
            {
                num68 = -1;
            }

            if ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -num68)
            {
                double num61;
                double num67;
                if (GetCandleAvgPeriod(BodyLong) != 0.0)
                {
                    num67 = bodyLongPeriodTotal[1] / GetCandleAvgPeriod(BodyLong);
                }
                else
                {
                    double num66;
                    if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                    {
                        num66 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num65;
                        if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                        {
                            num65 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num62;
                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                double num63;
                                double num64;
                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num64 = inClose[i - 1];
                                }
                                else
                                {
                                    num64 = inOpen[i - 1];
                                }

                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num63 = inOpen[i - 1];
                                }
                                else
                                {
                                    num63 = inClose[i - 1];
                                }

                                num62 = inHigh[i - 1] - num64 + (num63 - inLow[i - 1]);
                            }
                            else
                            {
                                num62 = 0.0;
                            }

                            num65 = num62;
                        }

                        num66 = num65;
                    }

                    num67 = num66;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                {
                    num61 = 2.0;
                }
                else
                {
                    num61 = 1.0;
                }

                if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                    > Globals.candleSettings[0].factor * num67 / num61)
                {
                    double num53;
                    double num59;
                    double num60;
                    if (inClose[i - 1] >= inOpen[i - 1])
                    {
                        num60 = inClose[i - 1];
                    }
                    else
                    {
                        num60 = inOpen[i - 1];
                    }

                    if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                    {
                        num59 = shadowVeryShortPeriodTotal[1] / GetCandleAvgPeriod(ShadowVeryShort);
                    }
                    else
                    {
                        double num58;
                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                        {
                            num58 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num57;
                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                            {
                                num57 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num54;
                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    double num55;
                                    double num56;
                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num56 = inClose[i - 1];
                                    }
                                    else
                                    {
                                        num56 = inOpen[i - 1];
                                    }

                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num55 = inOpen[i - 1];
                                    }
                                    else
                                    {
                                        num55 = inClose[i - 1];
                                    }

                                    num54 = inHigh[i - 1] - num56 + (num55 - inLow[i - 1]);
                                }
                                else
                                {
                                    num54 = 0.0;
                                }

                                num57 = num54;
                            }

                            num58 = num57;
                        }

                        num59 = num58;
                    }

                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                    {
                        num53 = 2.0;
                    }
                    else
                    {
                        num53 = 1.0;
                    }

                    if (inHigh[i - 1] - num60 < Globals.candleSettings[7].factor * num59 / num53)
                    {
                        double num45;
                        double num51;
                        double num52;
                        if (inClose[i - 1] >= inOpen[i - 1])
                        {
                            num52 = inOpen[i - 1];
                        }
                        else
                        {
                            num52 = inClose[i - 1];
                        }

                        if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                        {
                            num51 = shadowVeryShortPeriodTotal[1] / GetCandleAvgPeriod(ShadowVeryShort);
                        }
                        else
                        {
                            double num50;
                            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                            {
                                num50 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                            }
                            else
                            {
                                double num49;
                                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                {
                                    num49 = inHigh[i - 1] - inLow[i - 1];
                                }
                                else
                                {
                                    double num46;
                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
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

                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            num45 = 2.0;
                        }
                        else
                        {
                            num45 = 1.0;
                        }

                        if (num52 - inLow[i - 1] < Globals.candleSettings[7].factor * num51 / num45)
                        {
                            double num38;
                            double num44;
                            if (GetCandleAvgPeriod(BodyLong) != 0.0)
                            {
                                num44 = bodyLongPeriodTotal[0] / GetCandleAvgPeriod(BodyLong);
                            }
                            else
                            {
                                double num43;
                                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                                {
                                    num43 = Math.Abs(inClose[i] - inOpen[i]);
                                }
                                else
                                {
                                    double num42;
                                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                                    {
                                        num42 = inHigh[i] - inLow[i];
                                    }
                                    else
                                    {
                                        double num39;
                                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                                        {
                                            double num40;
                                            double num41;
                                            if (inClose[i] >= inOpen[i])
                                            {
                                                num41 = inClose[i];
                                            }
                                            else
                                            {
                                                num41 = inOpen[i];
                                            }

                                            if (inClose[i] >= inOpen[i])
                                            {
                                                num40 = inOpen[i];
                                            }
                                            else
                                            {
                                                num40 = inClose[i];
                                            }

                                            num39 = inHigh[i] - num41 + (num40 - inLow[i]);
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

                            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                            {
                                num38 = 2.0;
                            }
                            else
                            {
                                num38 = 1.0;
                            }

                            if (Math.Abs(inClose[i] - inOpen[i])
                                > Globals.candleSettings[0].factor * num44 / num38)
                            {
                                double num30;
                                double num36;
                                double num37;
                                if (inClose[i] >= inOpen[i])
                                {
                                    num37 = inClose[i];
                                }
                                else
                                {
                                    num37 = inOpen[i];
                                }

                                if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                                {
                                    num36 = shadowVeryShortPeriodTotal[0]
                                            / GetCandleAvgPeriod(ShadowVeryShort);
                                }
                                else
                                {
                                    double num35;
                                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                                    {
                                        num35 = Math.Abs(inClose[i] - inOpen[i]);
                                    }
                                    else
                                    {
                                        double num34;
                                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                        {
                                            num34 = inHigh[i] - inLow[i];
                                        }
                                        else
                                        {
                                            double num31;
                                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                            {
                                                double num32;
                                                double num33;
                                                if (inClose[i] >= inOpen[i])
                                                {
                                                    num33 = inClose[i];
                                                }
                                                else
                                                {
                                                    num33 = inOpen[i];
                                                }

                                                if (inClose[i] >= inOpen[i])
                                                {
                                                    num32 = inOpen[i];
                                                }
                                                else
                                                {
                                                    num32 = inClose[i];
                                                }

                                                num31 = inHigh[i] - num33 + (num32 - inLow[i]);
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

                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
                                    num30 = 2.0;
                                }
                                else
                                {
                                    num30 = 1.0;
                                }

                                if (inHigh[i] - num37 < Globals.candleSettings[7].factor * num36 / num30)
                                {
                                    double num22;
                                    double num28;
                                    double num29;
                                    if (inClose[i] >= inOpen[i])
                                    {
                                        num29 = inOpen[i];
                                    }
                                    else
                                    {
                                        num29 = inClose[i];
                                    }

                                    if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                                    {
                                        num28 = shadowVeryShortPeriodTotal[0]
                                                / GetCandleAvgPeriod(ShadowVeryShort);
                                    }
                                    else
                                    {
                                        double num27;
                                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                                        {
                                            num27 = Math.Abs(inClose[i] - inOpen[i]);
                                        }
                                        else
                                        {
                                            double num26;
                                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                                            {
                                                num26 = inHigh[i] - inLow[i];
                                            }
                                            else
                                            {
                                                double num23;
                                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                                {
                                                    double num24;
                                                    double num25;
                                                    if (inClose[i] >= inOpen[i])
                                                    {
                                                        num25 = inClose[i];
                                                    }
                                                    else
                                                    {
                                                        num25 = inOpen[i];
                                                    }

                                                    if (inClose[i] >= inOpen[i])
                                                    {
                                                        num24 = inOpen[i];
                                                    }
                                                    else
                                                    {
                                                        num24 = inClose[i];
                                                    }

                                                    num23 = inHigh[i] - num25 + (num24 - inLow[i]);
                                                }
                                                else
                                                {
                                                    num23 = 0.0;
                                                }

                                                num26 = num23;
                                            }

                                            num27 = num26;
                                        }

                                        num28 = num27;
                                    }

                                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                    {
                                        num22 = 2.0;
                                    }
                                    else
                                    {
                                        num22 = 1.0;
                                    }

                                    if (num29 - inLow[i] < Globals.candleSettings[7].factor * num28 / num22
                                        && ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1
                                            && inLow[i] > inHigh[i - 1]
                                            || inClose[i - 1] >= inOpen[i - 1] && inHigh[i] < inLow[i - 1]))
                                    {
                                        int num21;
                                        if (inClose[i] >= inOpen[i])
                                        {
                                            num21 = 1;
                                        }
                                        else
                                        {
                                            num21 = -1;
                                        }

                                        outInteger[outIdx] = num21 * 100;
                                        outIdx++;
                                        goto Label_0CDA;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0CDA:
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

        public static int CdlKickingLookback()
        {
            return (GetCandleAvgPeriod(ShadowVeryShort) <= GetCandleAvgPeriod(BodyLong)
                         ? GetCandleAvgPeriod(BodyLong)
                         : GetCandleAvgPeriod(ShadowVeryShort)) + 1;
        }
    }
}
