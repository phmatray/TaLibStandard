using System;
using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlSpinningTop(
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
            double num14;
            double num20;
            
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
            int lookbackTotal = CdlSpinningTopLookback();

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
            
            int i = bodyTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal += GetCandleRange(BodyShort, i, inOpen, inHigh, inLow, inClose);
                i++;
            }

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - small real body
             * - shadows longer than the real body
             * The meaning of "short" is specified with TA_SetCandleSettings
             * outInteger is positive (1 to 100) when white or negative (-1 to -100) when black;
             * it does not mean bullish or bearish
             */
            int outIdx = 0;
            Label_0147:
            if (GetCandleAvgPeriod(BodyShort) != 0.0)
            {
                num20 = bodyPeriodTotal / GetCandleAvgPeriod(BodyShort);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
                {
                    num19 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num18;
                    if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                    {
                        num18 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num15;
                        if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                        {
                            double num16;
                            double num17;
                            if (inClose[i] >= inOpen[i])
                            {
                                num17 = inClose[i];
                            }
                            else
                            {
                                num17 = inOpen[i];
                            }

                            if (inClose[i] >= inOpen[i])
                            {
                                num16 = inOpen[i];
                            }
                            else
                            {
                                num16 = inClose[i];
                            }

                            num15 = inHigh[i] - num17 + (num16 - inLow[i]);
                        }
                        else
                        {
                            num15 = 0.0;
                        }

                        num18 = num15;
                    }

                    num19 = num18;
                }

                num20 = num19;
            }

            if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
            {
                num14 = 2.0;
            }
            else
            {
                num14 = 1.0;
            }

            if (Math.Abs(inClose[i] - inOpen[i]) < Globals.candleSettings[2].factor * num20 / num14)
            {
                double num13;
                if (inClose[i] >= inOpen[i])
                {
                    num13 = inClose[i];
                }
                else
                {
                    num13 = inOpen[i];
                }

                if (inHigh[i] - num13 > Math.Abs(inClose[i] - inOpen[i]))
                {
                    double num12;
                    if (inClose[i] >= inOpen[i])
                    {
                        num12 = inOpen[i];
                    }
                    else
                    {
                        num12 = inClose[i];
                    }

                    if (num12 - inLow[i] > Math.Abs(inClose[i] - inOpen[i]))
                    {
                        int num11;
                        if (inClose[i] >= inOpen[i])
                        {
                            num11 = 1;
                        }
                        else
                        {
                            num11 = -1;
                        }

                        outInteger[outIdx] = num11 * 100;
                        outIdx++;
                        goto Label_0304;
                    }
                }
            }

            outInteger[outIdx] = 0;
            outIdx++;
            Label_0304:
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

            if (Globals.candleSettings[2].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[bodyTrailingIdx] - inOpen[bodyTrailingIdx]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[2].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[bodyTrailingIdx] - inLow[bodyTrailingIdx];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[2].rangeType == RangeType.Shadows)
                    {
                        double num2;
                        double num3;
                        if (inClose[bodyTrailingIdx] >= inOpen[bodyTrailingIdx])
                        {
                            num3 = inClose[bodyTrailingIdx];
                        }
                        else
                        {
                            num3 = inOpen[bodyTrailingIdx];
                        }

                        if (inClose[bodyTrailingIdx] >= inOpen[bodyTrailingIdx])
                        {
                            num2 = inOpen[bodyTrailingIdx];
                        }
                        else
                        {
                            num2 = inClose[bodyTrailingIdx];
                        }

                        num = inHigh[bodyTrailingIdx] - num3 + (num2 - inLow[bodyTrailingIdx]);
                    }
                    else
                    {
                        num = 0.0;
                    }

                    num4 = num;
                }

                num5 = num4;
            }

            bodyPeriodTotal += num10 - num5;
            i++;
            bodyTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_0147;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlSpinningTopLookback()
        {
            return GetCandleAvgPeriod(BodyShort);
        }
    }
}
