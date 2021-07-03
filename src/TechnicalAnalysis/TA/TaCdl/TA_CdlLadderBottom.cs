using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlLadderBottom(
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
            int lookbackTotal = CdlLadderBottomLookback();

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
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - GetCandleAvgPeriod(ShadowVeryShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal += GetCandleRange(ShadowVeryShort, i - 1, inOpen, inHigh, inLow, inClose);
                i++;
            }

            i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three black candlesticks with consecutively lower opens and closes
             * - fourth candle: black candle with an upper shadow (it's supposed to be not very short)
             * - fifth candle: white candle that opens above prior candle's body and closes above prior candle's high
             * The meaning of "very short" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100): ladder bottom is always bullish; 
             * the user should consider that ladder bottom is significant when it appears in a downtrend, 
             * while this function does not consider it
             */
            int outIdx = 0;
            Label_0168:
            if ((inClose[i - 4] < inOpen[i - 4] ? -1 : 1) == -1
                && (inClose[i - 3] < inOpen[i - 3] ? -1 : 1) == -1
                && (inClose[i - 2] < inOpen[i - 2] ? -1 : 1) == -1 && inOpen[i - 4] > inOpen[i - 3] && inOpen[i - 3] > inOpen[i - 2] && inClose[i - 4] > inClose[i - 3] && inClose[i - 3] > inClose[i - 2] && (inClose[i - 1] < inOpen[i - 1] ? -1 : 1) == -1)
            {
                double num11;
                double num17;
                double num18;
                if (inClose[i - 1] >= inOpen[i - 1])
                {
                    num18 = inClose[i - 1];
                }
                else
                {
                    num18 = inOpen[i - 1];
                }

                if (GetCandleAvgPeriod(ShadowVeryShort) != 0.0)
                {
                    num17 = shadowVeryShortPeriodTotal / GetCandleAvgPeriod(ShadowVeryShort);
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                    {
                        num16 = Math.Abs(inClose[i - 1] - inOpen[i - 1]);
                    }
                    else
                    {
                        double num15;
                        if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                        {
                            num15 = inHigh[i - 1] - inLow[i - 1];
                        }
                        else
                        {
                            double num12;
                            if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                            {
                                double num13;
                                double num14;
                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num14 = inClose[i - 1];
                                }
                                else
                                {
                                    num14 = inOpen[i - 1];
                                }

                                if (inClose[i - 1] >= inOpen[i - 1])
                                {
                                    num13 = inOpen[i - 1];
                                }
                                else
                                {
                                    num13 = inClose[i - 1];
                                }

                                num12 = inHigh[i - 1] - num14 + (num13 - inLow[i - 1]);
                            }
                            else
                            {
                                num12 = 0.0;
                            }

                            num15 = num12;
                        }

                        num16 = num15;
                    }

                    num17 = num16;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                {
                    num11 = 2.0;
                }
                else
                {
                    num11 = 1.0;
                }

                if (inHigh[i - 1] - num18 > Globals.candleSettings[7].factor * num17 / num11
                    && (inClose[i] < inOpen[i] ? -1 : 1) == 1 && inOpen[i] > inOpen[i - 1] && inClose[i] > inHigh[i - 1])
                {
                    outInteger[outIdx] = 100;
                    outIdx++;
                    goto Label_03B0;
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_03B0:
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
            shadowVeryShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0168;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlLadderBottomLookback()
        {
            return GetCandleAvgPeriod(ShadowVeryShort) + 4;
        }
    }
}
