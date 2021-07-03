using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlMatHold(
            int startIdx,
            int endIdx,
            in double[] inOpen,
            in double[] inHigh,
            in double[] inLow,
            in double[] inClose,
            in double optInPenetration,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            double num15;
            double num20;
            double num54;
            double num60;
            double[] bodyPeriodTotal = new double[5];
            
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

            if (optInPenetration < 0.0)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = CdlMatHoldLookback(optInPenetration);

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
            bodyPeriodTotal[4] = 0.0;
            bodyPeriodTotal[3] = 0.0;
            bodyPeriodTotal[2] = 0.0;
            bodyPeriodTotal[1] = 0.0;
            bodyPeriodTotal[0] = 0.0;
            int bodyShortTrailingIdx = startIdx - GetCandleAvgPeriod(BodyShort);
            int bodyLongTrailingIdx = startIdx - GetCandleAvgPeriod(BodyLong);
            
            int i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal[3] += GetCandleRange(BodyShort, i - 3, inOpen, inHigh, inLow, inClose);
                bodyPeriodTotal[2] += GetCandleRange(BodyShort, i - 2, inOpen, inHigh, inLow, inClose);
                bodyPeriodTotal[1] += GetCandleRange(BodyShort, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal[4] += GetCandleRange(BodyLong, i - 4, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: long white candle
             * - upside gap between the first and the second bodies
             * - second candle: small black candle
             * - third and fourth candles: falling small real body candlesticks (commonly black) that hold within the long 
             *   white candle's body and are higher than the reaction days of the rising three methods
             * - fifth candle: white candle that opens above the previous small candle's close and closes higher than the 
             *   high of the highest reaction day
             * The meaning of "short" and "long" is specified with TA_SetCandleSettings; 
             * "hold within" means "a part of the real body must be within";
             * optInPenetration is the maximum percentage of the first white body the reaction days can penetrate (it is 
             * to specify how much the reaction days should be "higher than the reaction days of the rising three methods")
             * outInteger is positive (1 to 100): mat hold is always bullish
             */
            int outIdx = 0;
            Label_0488:
            if (GetCandleAvgPeriod(BodyLong) != 0.0)
            {
                num60 = bodyPeriodTotal[4] / GetCandleAvgPeriod(BodyLong);
            }
            else
            {
                double num59;
                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num59 = Math.Abs(inClose[i - 4] - inOpen[i - 4]);
                }
                else
                {
                    double num58;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num58 = inHigh[i - 4] - inLow[i - 4];
                    }
                    else
                    {
                        double num55;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                        {
                            double num56;
                            double num57;
                            if (inClose[i - 4] >= inOpen[i - 4])
                            {
                                num57 = inClose[i - 4];
                            }
                            else
                            {
                                num57 = inOpen[i - 4];
                            }

                            if (inClose[i - 4] >= inOpen[i - 4])
                            {
                                num56 = inOpen[i - 4];
                            }
                            else
                            {
                                num56 = inClose[i - 4];
                            }

                            num55 = inHigh[i - 4] - num57 + (num56 - inLow[i - 4]);
                        }
                        else
                        {
                            num55 = 0.0;
                        }

                        num58 = num55;
                    }

                    num59 = num58;
                }

                num60 = num59;
            }

            if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
            {
                num54 = 2.0;
            }
            else
            {
                num54 = 1.0;
            }

            if (Math.Abs(inClose[i - 4] - inOpen[i - 4])
                > Globals.candleSettings[0].factor * num60 / num54)
            {
                double num47;
                double num53;
                if (GetCandleAvgPeriod(BodyShort) != 0.0)
                {
                    num53 = bodyPeriodTotal[3] / GetCandleAvgPeriod(BodyShort);
                }
                else
                {
                    double num52;
                    if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                    {
                        num52 = Math.Abs(inClose[i - 3] - inOpen[i - 3]);
                    }
                    else
                    {
                        double num51;
                        if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                        {
                            num51 = inHigh[i - 3] - inLow[i - 3];
                        }
                        else
                        {
                            double num48;
                            if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                            {
                                double num49;
                                double num50;
                                if (inClose[i - 3] >= inOpen[i - 3])
                                {
                                    num50 = inClose[i - 3];
                                }
                                else
                                {
                                    num50 = inOpen[i - 3];
                                }

                                if (inClose[i - 3] >= inOpen[i - 3])
                                {
                                    num49 = inOpen[i - 3];
                                }
                                else
                                {
                                    num49 = inClose[i - 3];
                                }

                                num48 = inHigh[i - 3] - num50 + (num49 - inLow[i - 3]);
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

                if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                {
                    num47 = 2.0;
                }
                else
                {
                    num47 = 1.0;
                }

                if (Math.Abs(inClose[i - 3] - inOpen[i - 3])
                    < Globals.candleSettings[2].factor * num53 / num47)
                {
                    double num40;
                    double num46;
                    if (GetCandleAvgPeriod(BodyShort) != 0.0)
                    {
                        num46 = bodyPeriodTotal[2] / GetCandleAvgPeriod(BodyShort);
                    }
                    else
                    {
                        double num45;
                        if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                        {
                            num45 = Math.Abs(inClose[i - 2] - inOpen[i - 2]);
                        }
                        else
                        {
                            double num44;
                            if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                            {
                                num44 = inHigh[i - 2] - inLow[i - 2];
                            }
                            else
                            {
                                double num41;
                                if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                                {
                                    double num42;
                                    double num43;
                                    if (inClose[i - 2] >= inOpen[i - 2])
                                    {
                                        num43 = inClose[i - 2];
                                    }
                                    else
                                    {
                                        num43 = inOpen[i - 2];
                                    }

                                    if (inClose[i - 2] >= inOpen[i - 2])
                                    {
                                        num42 = inOpen[i - 2];
                                    }
                                    else
                                    {
                                        num42 = inClose[i - 2];
                                    }

                                    num41 = inHigh[i - 2] - num43 + (num42 - inLow[i - 2]);
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

                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        num40 = 2.0;
                    }
                    else
                    {
                        num40 = 1.0;
                    }

                    if (Math.Abs(inClose[i - 2] - inOpen[i - 2])
                        < Globals.candleSettings[2].factor * num46 / num40)
                    {
                        double num33;
                        double num39;
                        if (GetCandleAvgPeriod(BodyShort) != 0.0)
                        {
                            num39 = bodyPeriodTotal[1] / GetCandleAvgPeriod(BodyShort);
                        }
                        else
                        {
                            double num38;
                            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                            {
                                num38 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                            }
                            else
                            {
                                double num37;
                                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                                {
                                    num37 = inHigh[i - 1] - inLow[i - 1];
                                }
                                else
                                {
                                    double num34;
                                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                                    {
                                        double num35;
                                        double num36;
                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num36 = inClose[i - 1];
                                        }
                                        else
                                        {
                                            num36 = inOpen[i - 1];
                                        }

                                        if (inClose[i - 1] >= inOpen[i - 1])
                                        {
                                            num35 = inOpen[i - 1];
                                        }
                                        else
                                        {
                                            num35 = inClose[i - 1];
                                        }

                                        num34 = inHigh[i - 1] - num36 + (num35 - inLow[i - 1]);
                                    }
                                    else
                                    {
                                        num34 = 0.0;
                                    }

                                    num37 = num34;
                                }

                                num38 = num37;
                            }

                            num39 = num38;
                        }

                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                        {
                            num33 = 2.0;
                        }
                        else
                        {
                            num33 = 1.0;
                        }

                        if (Math.Abs(inClose[i - 1] - inOpen[i - 1])
                            < Globals.candleSettings[2].factor * num39 / num33
                            && inClose[i - 4] >= inOpen[i - 4]
                            && (inClose[i - 3] < inOpen[i - 3] ? -1 : 1) == -1 && inClose[i] >= inOpen[i])
                        {
                            double num31;
                            double num32;
                            if (inOpen[i - 3] < inClose[i - 3])
                            {
                                num32 = inOpen[i - 3];
                            }
                            else
                            {
                                num32 = inClose[i - 3];
                            }

                            if (inOpen[i - 4] > inClose[i - 4])
                            {
                                num31 = inOpen[i - 4];
                            }
                            else
                            {
                                num31 = inClose[i - 4];
                            }

                            if (num32 > num31)
                            {
                                double num30;
                                if (inOpen[i - 2] < inClose[i - 2])
                                {
                                    num30 = inOpen[i - 2];
                                }
                                else
                                {
                                    num30 = inClose[i - 2];
                                }

                                if (num30 < inClose[i - 4])
                                {
                                    double num29;
                                    if (inOpen[i - 1] < inClose[i - 1])
                                    {
                                        num29 = inOpen[i - 1];
                                    }
                                    else
                                    {
                                        num29 = inClose[i - 1];
                                    }

                                    if (num29 < inClose[i - 4])
                                    {
                                        double num28;
                                        if (inOpen[i - 2] < inClose[i - 2])
                                        {
                                            num28 = inOpen[i - 2];
                                        }
                                        else
                                        {
                                            num28 = inClose[i - 2];
                                        }

                                        if (num28 > inClose[i - 4]
                                            - Math.Abs(inClose[i - 4] - inOpen[i - 4])
                                            * optInPenetration)
                                        {
                                            double num27;
                                            if (inOpen[i - 1] < inClose[i - 1])
                                            {
                                                num27 = inOpen[i - 1];
                                            }
                                            else
                                            {
                                                num27 = inClose[i - 1];
                                            }

                                            if (num27 > inClose[i - 4]
                                                - Math.Abs(inClose[i - 4] - inOpen[i - 4])
                                                * optInPenetration)
                                            {
                                                double num26;
                                                if (inClose[i - 2] > inOpen[i - 2])
                                                {
                                                    num26 = inClose[i - 2];
                                                }
                                                else
                                                {
                                                    num26 = inOpen[i - 2];
                                                }

                                                if (num26 < inOpen[i - 3])
                                                {
                                                    double num24;
                                                    double num25;
                                                    if (inClose[i - 1] > inOpen[i - 1])
                                                    {
                                                        num25 = inClose[i - 1];
                                                    }
                                                    else
                                                    {
                                                        num25 = inOpen[i - 1];
                                                    }

                                                    if (inClose[i - 2] > inOpen[i - 2])
                                                    {
                                                        num24 = inClose[i - 2];
                                                    }
                                                    else
                                                    {
                                                        num24 = inOpen[i - 2];
                                                    }

                                                    if (num25 < num24 && inOpen[i] > inClose[i - 1])
                                                    {
                                                        double num21;
                                                        double num23;
                                                        if (inHigh[i - 3] > inHigh[i - 2])
                                                        {
                                                            num23 = inHigh[i - 3];
                                                        }
                                                        else
                                                        {
                                                            num23 = inHigh[i - 2];
                                                        }

                                                        if (num23 > inHigh[i - 1])
                                                        {
                                                            double num22;
                                                            if (inHigh[i - 3] > inHigh[i - 2])
                                                            {
                                                                num22 = inHigh[i - 3];
                                                            }
                                                            else
                                                            {
                                                                num22 = inHigh[i - 2];
                                                            }

                                                            num21 = num22;
                                                        }
                                                        else
                                                        {
                                                            num21 = inHigh[i - 1];
                                                        }

                                                        if (inClose[i] > num21)
                                                        {
                                                            outInteger[outIdx] = 100;
                                                            outIdx++;
                                                            goto Label_0C54;
                                                        }
                                                    }
                                                }
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
            Label_0C54:
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i - 4] - inOpen[i - 4]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i - 4] - inLow[i - 4];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num17;
                        double num18;
                        if (inClose[i - 4] >= inOpen[i - 4])
                        {
                            num18 = inClose[i - 4];
                        }
                        else
                        {
                            num18 = inOpen[i - 4];
                        }

                        if (inClose[i - 4] >= inOpen[i - 4])
                        {
                            num17 = inOpen[i - 4];
                        }
                        else
                        {
                            num17 = inClose[i - 4];
                        }

                        num16 = inHigh[i - 4] - num18 + (num17 - inLow[i - 4]);
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
                num15 = Math.Abs(inClose[bodyLongTrailingIdx - 4] - inOpen[bodyLongTrailingIdx - 4]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[bodyLongTrailingIdx - 4] - inLow[bodyLongTrailingIdx - 4];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num12;
                        double num13;
                        if (inClose[bodyLongTrailingIdx - 4] >= inOpen[bodyLongTrailingIdx - 4])
                        {
                            num13 = inClose[bodyLongTrailingIdx - 4];
                        }
                        else
                        {
                            num13 = inOpen[bodyLongTrailingIdx - 4];
                        }

                        if (inClose[bodyLongTrailingIdx - 4] >= inOpen[bodyLongTrailingIdx - 4])
                        {
                            num12 = inOpen[bodyLongTrailingIdx - 4];
                        }
                        else
                        {
                            num12 = inClose[bodyLongTrailingIdx - 4];
                        }

                        num11 = inHigh[bodyLongTrailingIdx - 4] - num13 + (num12 - inLow[bodyLongTrailingIdx - 4]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            bodyPeriodTotal[4] += num20 - num15;
            for (int totIdx = 3; totIdx >= 1; totIdx--)
            {
                double num5;
                double num10;
                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                {
                    num10 = Math.Abs(inClose[i - totIdx] - inOpen[i - totIdx]);
                }
                else
                {
                    double num9;
                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                    {
                        num9 = inHigh[i - totIdx] - inLow[i - totIdx];
                    }
                    else
                    {
                        double num6;
                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
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

                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                {
                    num5 = Math.Abs(
                        inClose[bodyShortTrailingIdx - totIdx] - inOpen[bodyShortTrailingIdx - totIdx]);
                }
                else
                {
                    double num4;
                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                    {
                        num4 = inHigh[bodyShortTrailingIdx - totIdx] - inLow[bodyShortTrailingIdx - totIdx];
                    }
                    else
                    {
                        double num;
                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                        {
                            double num2;
                            double num3;
                            if (inClose[bodyShortTrailingIdx - totIdx] >= inOpen[bodyShortTrailingIdx - totIdx])
                            {
                                num3 = inClose[bodyShortTrailingIdx - totIdx];
                            }
                            else
                            {
                                num3 = inOpen[bodyShortTrailingIdx - totIdx];
                            }

                            if (inClose[bodyShortTrailingIdx - totIdx] >= inOpen[bodyShortTrailingIdx - totIdx])
                            {
                                num2 = inOpen[bodyShortTrailingIdx - totIdx];
                            }
                            else
                            {
                                num2 = inClose[bodyShortTrailingIdx - totIdx];
                            }

                            num = inHigh[bodyShortTrailingIdx - totIdx] - num3
                                  + (num2 - inLow[bodyShortTrailingIdx - totIdx]);
                        }
                        else
                        {
                            num = 0.0;
                        }

                        num4 = num;
                    }

                    num5 = num4;
                }

                bodyPeriodTotal[totIdx] += num10 - num5;
            }

            i++;
            bodyShortTrailingIdx++;
            bodyLongTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0488;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlMatHoldLookback(double optInPenetration)
        {
            if (optInPenetration < 0.0)
            {
                return -1;
            }

            return (GetCandleAvgPeriod(BodyShort) <= GetCandleAvgPeriod(BodyLong)
                         ? GetCandleAvgPeriod(BodyLong)
                         : GetCandleAvgPeriod(BodyShort)) + 4;
        }
    }
}
