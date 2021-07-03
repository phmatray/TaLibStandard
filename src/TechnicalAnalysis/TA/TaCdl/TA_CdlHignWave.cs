using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlHighWave(
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
            double num38;
            double num44;
            
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
            int lookbackTotal = CdlHighWaveLookback();

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
            double bodyPeriodTotal = 0.0;
            int bodyTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            double shadowPeriodTotal = 0.0;
            int shadowTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryLong);
            
            int i = bodyTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal += GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = shadowTrailingIdx;
            while (i < startIdx)
            {
                shadowPeriodTotal += GetCandleRange(ShadowVeryLong, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - short real body
             * - very long upper and lower shadow
             * The meaning of "short" and "very long" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when white or negative (-1 to -100) when black;
             * it does not mean bullish or bearish
             */
            int outIdx = 0;
            Label_022E:
            if (GetCandleAvgPeriod(BodyShort) != 0.0)
            {
                num44 = bodyPeriodTotal / GetCandleAvgPeriod(BodyShort);
            }
            else
            {
                double num43;
                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                {
                    num43 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num42;
                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                    {
                        num42 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num39;
                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
            {
                num38 = 2.0;
            }
            else
            {
                num38 = 1.0;
            }

            if (Math.Abs(inClose[i] - inOpen[i]) < Globals.candleSettings[2].factor * num44 / num38)
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

                if (GetCandleAvgPeriod(ShadowVeryLong) != 0.0)
                {
                    num36 = shadowPeriodTotal / GetCandleAvgPeriod(ShadowVeryLong);
                }
                else
                {
                    double num35;
                    if (Globals.candleSettings[5].rangeType == RangeType.RealBody)
                    {
                        num35 = Math.Abs(inClose[i] - inOpen[i]);
                    }
                    else
                    {
                        double num34;
                        if (Globals.candleSettings[5].rangeType == RangeType.HighLow)
                        {
                            num34 = inHigh[i] - inLow[i];
                        }
                        else
                        {
                            double num31;
                            if (Globals.candleSettings[5].rangeType == RangeType.Shadows)
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

                if (Globals.candleSettings[5].rangeType == RangeType.Shadows)
                {
                    num30 = 2.0;
                }
                else
                {
                    num30 = 1.0;
                }

                if (inHigh[i] - num37 > Globals.candleSettings[5].factor * num36 / num30)
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

                    if (GetCandleAvgPeriod(ShadowVeryLong) != 0.0)
                    {
                        num28 = shadowPeriodTotal / GetCandleAvgPeriod(ShadowVeryLong);
                    }
                    else
                    {
                        double num27;
                        if (Globals.candleSettings[5].rangeType == RangeType.RealBody)
                        {
                            num27 = Math.Abs(inClose[i] - inOpen[i]);
                        }
                        else
                        {
                            double num26;
                            if (Globals.candleSettings[5].rangeType == RangeType.HighLow)
                            {
                                num26 = inHigh[i] - inLow[i];
                            }
                            else
                            {
                                double num23;
                                if (Globals.candleSettings[5].rangeType == RangeType.Shadows)
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

                    if (Globals.candleSettings[5].rangeType == RangeType.Shadows)
                    {
                        num22 = 2.0;
                    }
                    else
                    {
                        num22 = 1.0;
                    }

                    if (num29 - inLow[i] > Globals.candleSettings[5].factor * num28 / num22)
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
                        goto Label_062D;
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_062D:
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
                num15 = Math.Abs(inClose[bodyTrailingIdx] - inOpen[bodyTrailingIdx]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[bodyTrailingIdx] - inLow[bodyTrailingIdx];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        double num12;
                        double num13;
                        if (inClose[bodyTrailingIdx] >= inOpen[bodyTrailingIdx])
                        {
                            num13 = inClose[bodyTrailingIdx];
                        }
                        else
                        {
                            num13 = inOpen[bodyTrailingIdx];
                        }

                        if (inClose[bodyTrailingIdx] >= inOpen[bodyTrailingIdx])
                        {
                            num12 = inOpen[bodyTrailingIdx];
                        }
                        else
                        {
                            num12 = inClose[bodyTrailingIdx];
                        }

                        num11 = inHigh[bodyTrailingIdx] - num13 + (num12 - inLow[bodyTrailingIdx]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            bodyPeriodTotal += num20 - num15;
            if (Globals.candleSettings[5].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[5].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[5].rangeType == RangeType.Shadows)
                    {
                        double num7;
                        double num8;
                        if (inClose[i] >= inOpen[i])
                        {
                            num8 = inClose[i];
                        }
                        else
                        {
                            num8 = inOpen[i];
                        }

                        if (inClose[i] >= inOpen[i])
                        {
                            num7 = inOpen[i];
                        }
                        else
                        {
                            num7 = inClose[i];
                        }

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

            if (Globals.candleSettings[5].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[shadowTrailingIdx] - inOpen[shadowTrailingIdx]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[5].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[shadowTrailingIdx] - inLow[shadowTrailingIdx];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[5].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[shadowTrailingIdx] >= inOpen[shadowTrailingIdx])
                        {
                            num3 = inClose[shadowTrailingIdx];
                        }
                        else
                        {
                            num3 = inOpen[shadowTrailingIdx];
                        }

                        if (inClose[shadowTrailingIdx] >= inOpen[shadowTrailingIdx])
                        {
                            num2 = inOpen[shadowTrailingIdx];
                        }
                        else
                        {
                            num2 = inClose[shadowTrailingIdx];
                        }

                        num = inHigh[shadowTrailingIdx] - num3 + (num2 - inLow[shadowTrailingIdx]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            shadowPeriodTotal += num10 - num5;
            i++;
            bodyTrailingIdx++;
            shadowTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_022E;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlHighWaveLookback()
        {
            return GetCandleAvgPeriod(BodyShort) <= GetCandleAvgPeriod(ShadowVeryLong)
                        ? GetCandleAvgPeriod(ShadowVeryLong)
                        : GetCandleAvgPeriod(BodyShort);
        }
    }
}
