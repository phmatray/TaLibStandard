using static TechnicalAnalysis.TACore.CandleSettingType;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlXSideGap3Methods(
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
            int num;
            double num2;
            double num3;
            double num6;
            double num7;
            double num8;
            double num9;
            int num10;
            int num11;
            
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
            int lookbackTotal = CdlXSideGap3MethodsLookback();

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
            int i = startIdx;

            /* Proceed with the calculation for the requested range.
             * Must have:
             * - first candle: white (black) candle
             * - second candle: white (black) candle
             * - upside (downside) gap between the first and the second real bodies
             * - third candle: black (white) candle that opens within the second real body and closes within the first real body
             * outInteger is positive (1 to 100) when bullish or negative (-1 to -100) when bearish;
             * the user should consider that up/downside gap 3 methods is significant when it appears in a trend, while this 
             * function does not consider it
             */
            int outIdx = 0;
            Label_0063:
            if (inClose[i - 1] >= inOpen[i - 1])
            {
                num11 = 1;
            }
            else
            {
                num11 = -1;
            }

            if ((inClose[i - 2] < inOpen[i - 2] ? -1 : 1) != num11)
            {
                goto Label_0229;
            }

            if (inClose[i] >= inOpen[i])
            {
                num10 = 1;
            }
            else
            {
                num10 = -1;
            }

            if ((inClose[i - 1] < inOpen[i - 1] ? -1 : 1) != -num10)
            {
                goto Label_0229;
            }

            if (inClose[i - 1] > inOpen[i - 1])
            {
                num9 = inClose[i - 1];
            }
            else
            {
                num9 = inOpen[i - 1];
            }

            if (inOpen[i] >= num9)
            {
                goto Label_0229;
            }

            if (inClose[i - 1] < inOpen[i - 1])
            {
                num8 = inClose[i - 1];
            }
            else
            {
                num8 = inOpen[i - 1];
            }

            if (inOpen[i] <= num8)
            {
                goto Label_0229;
            }

            if (inClose[i - 2] > inOpen[i - 2])
            {
                num7 = inClose[i - 2];
            }
            else
            {
                num7 = inOpen[i - 2];
            }

            if (inClose[i] >= num7)
            {
                goto Label_0229;
            }

            if (inClose[i - 2] < inOpen[i - 2])
            {
                num6 = inClose[i - 2];
            }
            else
            {
                num6 = inOpen[i - 2];
            }

            if (inClose[i] <= num6)
            {
                goto Label_0229;
            }

            if (inClose[i - 2] >= inOpen[i - 2])
            {
                double num4;
                double num5;
                if (inOpen[i - 1] < inClose[i - 1])
                {
                    num5 = inOpen[i - 1];
                }
                else
                {
                    num5 = inClose[i - 1];
                }

                if (inOpen[i - 2] > inClose[i - 2])
                {
                    num4 = inOpen[i - 2];
                }
                else
                {
                    num4 = inClose[i - 2];
                }

                if (num5 > num4)
                {
                    goto Label_0208;
                }
            }

            if ((inClose[i - 2] < inOpen[i - 2] ? -1 : 1) != -1)
            {
                goto Label_0229;
            }

            if (inOpen[i - 1] > inClose[i - 1])
            {
                num3 = inOpen[i - 1];
            }
            else
            {
                num3 = inClose[i - 1];
            }

            if (inOpen[i - 2] < inClose[i - 2])
            {
                num2 = inOpen[i - 2];
            }
            else
            {
                num2 = inClose[i - 2];
            }

            if (num3 >= num2)
            {
                goto Label_0229;
            }

            Label_0208:
            if (inClose[i - 2] >= inOpen[i - 2])
            {
                num = 1;
            }
            else
            {
                num = -1;
            }

            outInteger[outIdx] = num * 100;
            outIdx++;
            goto Label_0232;
            Label_0229:
            outInteger[outIdx] = 0;
            outIdx++;
            Label_0232:
            i++;
            if (i <= endIdx)
            {
                goto Label_0063;
            }

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public static int CdlXSideGap3MethodsLookback()
        {
            return 2;
        }
    }
}
