using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlIdentical3Crows(
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
            double[] shadowVeryShortPeriodTotal = new double[3];
            double[] equalPeriodTotal = new double[3];
            
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
            int lookbackTotal = CdlIdentical3CrowsLookback();

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
            equalPeriodTotal[2] = 0.0;
            equalPeriodTotal[1] = 0.0;
            equalPeriodTotal[0] = 0.0;
            int equalTrailingIdx = startIdx - GetCandleAvgPeriod(Equal);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[2] += GetCandleRange(ShadowVeryShort, i - 2, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[1] += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                shadowVeryShortPeriodTotal[0] += GetCandleRange(ShadowVeryShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = equalTrailingIdx;
            while (i < startIdx)
            {
                equalPeriodTotal[2] += GetCandleRange(Equal, i - 2, inOpen, inHigh, inLow, inClose);
                equalPeriodTotal[1] += GetCandleRange(Equal, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three consecutive and declining black candlesticks
             * - each candle must have no or very short lower shadow
             * - each candle after the first must open at or very close to the prior candle's close
             * The meaning of "very short" is specified with TA_SetCandleSettings;
             * the meaning of "very close" is specified with TA_SetCandleSettings (Equal);
             * outInteger is negative (-1 to -100): identical three crows is always bearish; 
             * the user should consider that identical 3 crows is significant when it appears after a mature advance or at high levels, 
             * while this function does not consider it
             */
            int outIdx = 0;
            Label_0529:
            if ((inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == -1)
            {
                double num65;
                double num71;
                double num72;
                if (inClose[i - 2] >= inOpen[i - 2])
                {
                    num72 = inOpen[i - 2];
                }
                else
                {
                    num72 = inClose[i - 2];
                }

                if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                {
                    num71 = shadowVeryShortPeriodTotal[2] / GetCandleAvgPeriod(ShadowVeryShort);
                }
                else
                {
                    double num70;
                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                    {
                        num70 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                    }
                    else
                    {
                        double num69;
                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                        {
                            num69 = inHigh[i - 2] - inLow[i - 2];
                        }
                        else
                        {
                            double num66;
                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                            {
                                double num67;
                                double num68;
                                if (inClose[i - 2] >= inOpen[i - 2])
                                {
                                    num68 = inClose[i - 2];
                                }
                                else
                                {
                                    num68 = inOpen[i - 2];
                                }

                                if (inClose[i - 2] >= inOpen[i - 2])
                                {
                                    num67 = inOpen[i - 2];
                                }
                                else
                                {
                                    num67 = inClose[i - 2];
                                }

                                num66 = inHigh[i - 2] - num68 + (num67 - inLow[i - 2]);
                            }
                            else
                            {
                                num66 = 0.0;
                            }

                            num69 = num66;
                        }

                        num70 = num69;
                    }

                    num71 = num70;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                {
                    num65 = 2.0;
                }
                else
                {
                    num65 = 1.0;
                }

                if (num72 - inLow[i - 2] < Globals.candleSettings[7].factor * num71 / num65
                    && (inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1)
                {
                    double num57;
                    double num63;
                    double num64;
                    if (inClose[i - 1] >= inOpen[i - 1])
                    {
                        num64 = inOpen[i - 1];
                    }
                    else
                    {
                        num64 = inClose[i - 1];
                    }

                    if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                    {
                        num63 = shadowVeryShortPeriodTotal[1] / GetCandleAvgPeriod(ShadowVeryShort);
                    }
                    else
                    {
                        double num62;
                        if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                        {
                            num62 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                        }
                        else
                        {
                            double num61;
                            if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                            {
                                num61 = inHigh[i - 1] - inLow[i - 1];
                            }
                            else
                            {
                                double num58;
                                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                                {
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

                                    if (inClose[i - 1] >= inOpen[i - 1])
                                    {
                                        num59 = inOpen[i - 1];
                                    }
                                    else
                                    {
                                        num59 = inClose[i - 1];
                                    }

                                    num58 = inHigh[i - 1] - num60 + (num59 - inLow[i - 1]);
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

                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                    {
                        num57 = 2.0;
                    }
                    else
                    {
                        num57 = 1.0;
                    }

                    if (num64 - inLow[i - 1] < Globals.candleSettings[7].factor * num63 / num57
                        && (inClose[i] < inOpen[i] ? -1 : 1) == -1)
                    {
                        double num49;
                        double num55;
                        double num56;
                        if (inClose[i] >= inOpen[i])
                        {
                            num56 = inOpen[i];
                        }
                        else
                        {
                            num56 = inClose[i];
                        }

                        if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                        {
                            num55 = shadowVeryShortPeriodTotal[0] / GetCandleAvgPeriod(ShadowVeryShort);
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
                                        double num51;
                                        double num52;
                                        if (inClose[i] >= inOpen[i])
                                        {
                                            num52 = inClose[i];
                                        }
                                        else
                                        {
                                            num52 = inOpen[i];
                                        }

                                        if (inClose[i] >= inOpen[i])
                                        {
                                            num51 = inOpen[i];
                                        }
                                        else
                                        {
                                            num51 = inClose[i];
                                        }

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

                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            num49 = 2.0;
                        }
                        else
                        {
                            num49 = 1.0;
                        }

                        if (num56 - inLow[i] < Globals.candleSettings[7].factor * num55 / num49
                            && inClose[i - 2] > inClose[i - 1] && inClose[i - 1] > inClose[i])
                        {
                            double num42;
                            double num48;
                            if (GetCandleAvgPeriod(Equal) != 0.0)
                            {
                                num48 = equalPeriodTotal[2] / GetCandleAvgPeriod(Equal);
                            }
                            else
                            {
                                double num47;
                                if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                                {
                                    num47 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                                }
                                else
                                {
                                    double num46;
                                    if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                                    {
                                        num46 = inHigh[i - 2] - inLow[i - 2];
                                    }
                                    else
                                    {
                                        double num43;
                                        if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                        {
                                            double num44;
                                            double num45;
                                            if (inClose[i - 2] >= inOpen[i - 2])
                                            {
                                                num45 = inClose[i - 2];
                                            }
                                            else
                                            {
                                                num45 = inOpen[i - 2];
                                            }

                                            if (inClose[i - 2] >= inOpen[i - 2])
                                            {
                                                num44 = inOpen[i - 2];
                                            }
                                            else
                                            {
                                                num44 = inClose[i - 2];
                                            }

                                            num43 = inHigh[i - 2] - num45 + (num44 - inLow[i - 2]);
                                        }
                                        else
                                        {
                                            num43 = 0.0;
                                        }

                                        num46 = num43;
                                    }

                                    num47 = num46;
                                }

                                num48 = num47;
                            }

                            if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                            {
                                num42 = 2.0;
                            }
                            else
                            {
                                num42 = 1.0;
                            }

                            if (inOpen[i - 1]
                                <= inClose[i - 2] + Globals.candleSettings[10].factor * num48 / num42)
                            {
                                double num35;
                                double num41;
                                if (GetCandleAvgPeriod(Equal) != 0.0)
                                {
                                    num41 = equalPeriodTotal[2] / GetCandleAvgPeriod(Equal);
                                }
                                else
                                {
                                    double num40;
                                    if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                                    {
                                        num40 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                                    }
                                    else
                                    {
                                        double num39;
                                        if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                                        {
                                            num39 = inHigh[i - 2] - inLow[i - 2];
                                        }
                                        else
                                        {
                                            double num36;
                                            if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                            {
                                                double num37;
                                                double num38;
                                                if (inClose[i - 2] >= inOpen[i - 2])
                                                {
                                                    num38 = inClose[i - 2];
                                                }
                                                else
                                                {
                                                    num38 = inOpen[i - 2];
                                                }

                                                if (inClose[i - 2] >= inOpen[i - 2])
                                                {
                                                    num37 = inOpen[i - 2];
                                                }
                                                else
                                                {
                                                    num37 = inClose[i - 2];
                                                }

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

                                    num41 = num40;
                                }

                                if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                {
                                    num35 = 2.0;
                                }
                                else
                                {
                                    num35 = 1.0;
                                }

                                if (inOpen[i - 1]
                                    >= inClose[i - 2] - Globals.candleSettings[10].factor * num41 / num35)
                                {
                                    double num28;
                                    double num34;
                                    if (GetCandleAvgPeriod(Equal) != 0.0)
                                    {
                                        num34 = equalPeriodTotal[1] / GetCandleAvgPeriod(Equal);
                                    }
                                    else
                                    {
                                        double num33;
                                        if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                                        {
                                            num33 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                                        }
                                        else
                                        {
                                            double num32;
                                            if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                                            {
                                                num32 = inHigh[i - 1] - inLow[i - 1];
                                            }
                                            else
                                            {
                                                double num29;
                                                if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                                {
                                                    double num30;
                                                    double num31;
                                                    if (inClose[i - 1] >= inOpen[i - 1])
                                                    {
                                                        num31 = inClose[i - 1];
                                                    }
                                                    else
                                                    {
                                                        num31 = inOpen[i - 1];
                                                    }

                                                    if (inClose[i - 1] >= inOpen[i - 1])
                                                    {
                                                        num30 = inOpen[i - 1];
                                                    }
                                                    else
                                                    {
                                                        num30 = inClose[i - 1];
                                                    }

                                                    num29 = inHigh[i - 1] - num31 + (num30 - inLow[i - 1]);
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

                                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                    {
                                        num28 = 2.0;
                                    }
                                    else
                                    {
                                        num28 = 1.0;
                                    }

                                    if (inOpen[i] <= inClose[i - 1]
                                        + Globals.candleSettings[10].factor * num34 / num28)
                                    {
                                        double num21;
                                        double num27;
                                        if (GetCandleAvgPeriod(Equal) != 0.0)
                                        {
                                            num27 = equalPeriodTotal[1]
                                                    / GetCandleAvgPeriod(Equal);
                                        }
                                        else
                                        {
                                            double num26;
                                            if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                                            {
                                                num26 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                                            }
                                            else
                                            {
                                                double num25;
                                                if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                                                {
                                                    num25 = inHigh[i - 1] - inLow[i - 1];
                                                }
                                                else
                                                {
                                                    double num22;
                                                    if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                                    {
                                                        double num23;
                                                        double num24;
                                                        if (inClose[i - 1] >= inOpen[i - 1])
                                                        {
                                                            num24 = inClose[i - 1];
                                                        }
                                                        else
                                                        {
                                                            num24 = inOpen[i - 1];
                                                        }

                                                        if (inClose[i - 1] >= inOpen[i - 1])
                                                        {
                                                            num23 = inOpen[i - 1];
                                                        }
                                                        else
                                                        {
                                                            num23 = inClose[i - 1];
                                                        }

                                                        num22 = inHigh[i - 1] - num24 + (num23 - inLow[i - 1]);
                                                    }
                                                    else
                                                    {
                                                        num22 = 0.0;
                                                    }

                                                    num25 = num22;
                                                }

                                                num26 = num25;
                                            }

                                            num27 = num26;
                                        }

                                        if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                                        {
                                            num21 = 2.0;
                                        }
                                        else
                                        {
                                            num21 = 1.0;
                                        }

                                        if (inOpen[i] >= inClose[i - 1]
                                            - Globals.candleSettings[10].factor * num27 / num21)
                                        {
                                            outInteger[outIdx] = -100;
                                            outIdx++;
                                            goto Label_0F74;
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
            Label_0F74:
            totIdx = 2;
            while (totIdx >= 0)
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
                            double num12;
                            double num13;
                            if (inClose[shadowVeryShortTrailingIdx - totIdx]
                                >= inOpen[shadowVeryShortTrailingIdx - totIdx])
                            {
                                num13 = inClose[shadowVeryShortTrailingIdx - totIdx];
                            }
                            else
                            {
                                num13 = inOpen[shadowVeryShortTrailingIdx - totIdx];
                            }

                            if (inClose[shadowVeryShortTrailingIdx - totIdx]
                                >= inOpen[shadowVeryShortTrailingIdx - totIdx])
                            {
                                num12 = inOpen[shadowVeryShortTrailingIdx - totIdx];
                            }
                            else
                            {
                                num12 = inClose[shadowVeryShortTrailingIdx - totIdx];
                            }

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
                totIdx--;
            }

            for (totIdx = 2; totIdx >= 1; totIdx--)
            {
                double num5;
                double num10;
                if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                {
                    num10 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num9;
                    if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                    {
                        num9 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num6;
                        if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
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

                if (Globals.candleSettings[10].rangeType == RangeType.RealBody)
                {
                    num5 = Math.Abs(inClose[equalTrailingIdx - totIdx] - inOpen[equalTrailingIdx - totIdx]);
                }
                else
                {
                    double num4;
                    if (Globals.candleSettings[10].rangeType == RangeType.HighLow)
                    {
                        num4 = inHigh[equalTrailingIdx - totIdx] - inLow[equalTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num;
                        if (Globals.candleSettings[10].rangeType == RangeType.Shadows)
                        {
                            double num2;
                            double num3;
                            if (inClose[equalTrailingIdx - totIdx] >= inOpen[equalTrailingIdx - totIdx])
                            {
                                num3 = inClose[equalTrailingIdx - totIdx];
                            }
                            else
                            {
                                num3 = inOpen[equalTrailingIdx - totIdx];
                            }

                            if (inClose[equalTrailingIdx - totIdx] >= inOpen[equalTrailingIdx - totIdx])
                            {
                                num2 = inOpen[equalTrailingIdx - totIdx];
                            }
                            else
                            {
                                num2 = inClose[equalTrailingIdx - totIdx];
                            }

                            num = inHigh[equalTrailingIdx - totIdx] - num3
                                  + (num2 - inLow[equalTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num = 0.0;
                        }

                        num4 = num;
                    }

                    num5 = num4;
                }

                equalPeriodTotal[totIdx] += num10 - num5;
            }

            i++;
            shadowVeryShortTrailingIdx++;
            equalTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0529;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlIdentical3CrowsLookback()
        {
            return (GetCandleAvgPeriod(ShadowVeryShort) <= GetCandleAvgPeriod(Equal)
                         ? GetCandleAvgPeriod(Equal)
                         : GetCandleAvgPeriod(ShadowVeryShort)) + 2;
        }
    }
}
