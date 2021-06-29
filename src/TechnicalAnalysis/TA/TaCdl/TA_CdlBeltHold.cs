using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlBeltHold(
            int startIdx,
            int endIdx,
            double[] inOpen,
            double[] inHigh,
            double[] inLow,
            double[] inClose,
            ref int outBegIdx,
            ref int outNBElement,
            int[] outInteger)
        {
            double num5;
            double num10;
            double num15;
            double num20;
            int num21;
            double num28;
            double num44;
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inOpen == null || inHigh == null || inLow == null || inClose == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            int lookbackTotal = CdlBeltHoldLookback();
            if (startIdx < lookbackTotal)
            {
                startIdx = lookbackTotal;
            }

            if (startIdx > endIdx)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
            }

            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - Globals.candleSettings[0].avgPeriod;
            double shadowVeryShortPeriodTotal = 0.0;
            int shadowVeryShortTrailingIdx = startIdx - Globals.candleSettings[7].avgPeriod;
            int i = bodyLongTrailingIdx;
            while (true)
            {
                double num54;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
                {
                    num54 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num53;
                    if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                    {
                        num53 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num50;
                        if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
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

                bodyLongPeriodTotal += num54;
                i++;
            }

            i = shadowVeryShortTrailingIdx;
            while (true)
            {
                double num49;
                if (i >= startIdx)
                {
                    break;
                }

                if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
                {
                    num49 = Math.Abs(inClose[i] - inOpen[i]);
                }
                else
                {
                    double num48;
                    if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                    {
                        num48 = inHigh[i] - inLow[i];
                    }
                    else
                    {
                        double num45;
                        if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                        {
                            double num47 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num46 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
                            num45 = inHigh[i] - num47 + (num46 - inLow[i]);
                        }
                        else
                        {
                            num45 = 0.0;
                        }

                        num48 = num45;
                    }

                    num49 = num48;
                }

                shadowVeryShortPeriodTotal += num49;
                i++;
            }

            int outIdx = 0;
            Label_022E:
            if (Globals.candleSettings[0].avgPeriod != 0.0)
            {
                num44 = bodyLongPeriodTotal / Globals.candleSettings[0].avgPeriod;
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
                            double num41 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num40 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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

            double num38 = Globals.candleSettings[0].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (Math.Abs(inClose[i] - inOpen[i]) <= Globals.candleSettings[0].factor * num44 / num38)
            {
                goto Label_064A;
            }

            if (inClose[i] >= inOpen[i])
            {
                double num36;
                double num37 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];

                if (Globals.candleSettings[7].avgPeriod != 0.0)
                {
                    num36 = shadowVeryShortPeriodTotal / Globals.candleSettings[7].avgPeriod;
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
                                double num33 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                                double num32 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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

                double num30 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

                if (num37 - inLow[i] < Globals.candleSettings[7].factor * num36 / num30)
                {
                    goto Label_062A;
                }
            }

            if ((inClose[i] < inOpen[i] ? -1 : 1) != -1)
            {
                goto Label_064A;
            }

            double num29 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];

            if (Globals.candleSettings[7].avgPeriod != 0.0)
            {
                num28 = shadowVeryShortPeriodTotal / Globals.candleSettings[7].avgPeriod;
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
                            double num25 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                            double num24 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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

            double num22 = Globals.candleSettings[7].rangeType == RangeType.Shadows ? 2.0 : 1.0;

            if (inHigh[i] - num29 >= Globals.candleSettings[7].factor * num28 / num22)
            {
                goto Label_064A;
            }

            Label_062A:
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
            goto Label_0653;
            Label_064A:
            outInteger[outIdx] = 0;
            outIdx++;
            Label_0653:
            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num20 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num19;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num19 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num16;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num18 = inClose[i] >= inOpen[i] ? inClose[i] : inOpen[i];
                        double num17 = inClose[i] >= inOpen[i] ? inOpen[i] : inClose[i];
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

            if (Globals.candleSettings[0].rangeType == RangeType.RealBody)
            {
                num15 = Math.Abs(inClose[bodyLongTrailingIdx] - inOpen[bodyLongTrailingIdx]);
            }
            else
            {
                double num14;
                if (Globals.candleSettings[0].rangeType == RangeType.HighLow)
                {
                    num14 = inHigh[bodyLongTrailingIdx] - inLow[bodyLongTrailingIdx];
                }
                else
                {
                    double num11;
                    if (Globals.candleSettings[0].rangeType == RangeType.Shadows)
                    {
                        double num13 = inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx] ? inClose[bodyLongTrailingIdx] : inOpen[bodyLongTrailingIdx];
                        double num12 = inClose[bodyLongTrailingIdx] >= inOpen[bodyLongTrailingIdx] ? inOpen[bodyLongTrailingIdx] : inClose[bodyLongTrailingIdx];
                        num11 = inHigh[bodyLongTrailingIdx] - num13 + (num12 - inLow[bodyLongTrailingIdx]);
                    }
                    else
                    {
                        num11 = 0.0;
                    }

                    num14 = num11;
                }

                num15 = num14;
            }

            bodyLongPeriodTotal += num20 - num15;
            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
            {
                num10 = Math.Abs(inClose[i] - inOpen[i]);
            }
            else
            {
                double num9;
                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                {
                    num9 = inHigh[i] - inLow[i];
                }
                else
                {
                    double num6;
                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
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

            if (Globals.candleSettings[7].rangeType == RangeType.RealBody)
            {
                num5 = Math.Abs(inClose[shadowVeryShortTrailingIdx] - inOpen[shadowVeryShortTrailingIdx]);
            }
            else
            {
                double num4;
                if (Globals.candleSettings[7].rangeType == RangeType.HighLow)
                {
                    num4 = inHigh[shadowVeryShortTrailingIdx] - inLow[shadowVeryShortTrailingIdx];
                }
                else
                {
                    double num;
                    if (Globals.candleSettings[7].rangeType == RangeType.Shadows)
                    {
                        double num3 = inClose[shadowVeryShortTrailingIdx] >= inOpen[shadowVeryShortTrailingIdx] ? inClose[shadowVeryShortTrailingIdx] : inOpen[shadowVeryShortTrailingIdx];
                        double num2 = inClose[shadowVeryShortTrailingIdx] >= inOpen[shadowVeryShortTrailingIdx] ? inOpen[shadowVeryShortTrailingIdx] : inClose[shadowVeryShortTrailingIdx];
                        num = inHigh[shadowVeryShortTrailingIdx] - num3 + (num2 - inLow[shadowVeryShortTrailingIdx]);
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
            shadowVeryShortTrailingIdx++;
            if (i <= endIdx)
            {
                goto Label_022E;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlBeltHoldLookback()
        {
            return Globals.candleSettings[0].avgPeriod <= Globals.candleSettings[7].avgPeriod
                        ? Globals.candleSettings[7].avgPeriod
                        : Globals.candleSettings[0].avgPeriod;
        }
    }
}
