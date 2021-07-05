using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class Candle3WhiteSoldiers : CandleIndicator
    {
        public Candle3WhiteSoldiers(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode Cdl3WhiteSoldiers(
            int startIdx,
            int endIdx,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
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
            if (this.open == null || this.high == null || this.low == null || this.close == null)
            {
                return RetCode.BadParam;
            }

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            // Identify the minimum number of price bar needed to calculate at least one output.
            int lookbackTotal = this.Cdl3WhiteSoldiersLookback();

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
            int shadowVeryShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryShort);
            nearPeriodTotal[2] = 0.0;
            nearPeriodTotal[1] = 0.0;
            nearPeriodTotal[0] = 0.0;
            int nearTrailingIdx = startIdx - this.GetCandleAvgPeriod(Near);
            farPeriodTotal[2] = 0.0;
            farPeriodTotal[1] = 0.0;
            farPeriodTotal[0] = 0.0;
            int farTrailingIdx = startIdx - this.GetCandleAvgPeriod(Far);
            double bodyShortPeriodTotal = 0.0;
            int bodyShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyShort);
            
            int i = shadowVeryShortTrailingIdx;
            while (i < startIdx)
            {
                shadowVeryShortPeriodTotal[2] += this.GetCandleRange(ShadowVeryShort, i - 2, this.open, this.high, this.low, this.close);
                shadowVeryShortPeriodTotal[1] += this.GetCandleRange(ShadowVeryShort, i - 1, this.open, this.high, this.low, this.close);
                shadowVeryShortPeriodTotal[0] += this.GetCandleRange(ShadowVeryShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = nearTrailingIdx;
            while (i < startIdx)
            {
                nearPeriodTotal[2] += this.GetCandleRange(Near, i - 2, this.open, this.high, this.low, this.close);
                nearPeriodTotal[1] += this.GetCandleRange(Near, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = farTrailingIdx;
            while (i < startIdx)
            {
                farPeriodTotal[2] += this.GetCandleRange(Far, i - 2, this.open, this.high, this.low, this.close);
                farPeriodTotal[1] += this.GetCandleRange(Far, i - 1, this.open, this.high, this.low, this.close);
                i++;
            }

            i = bodyShortTrailingIdx;
            while (i < startIdx)
            {
                bodyShortPeriodTotal += this.GetCandleRange(BodyShort, i, this.open, this.high, this.low, this.close);
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
            do
            {
                bool is3WhiteSoldiers =
                    // 1st white
                    this.GetCandleColor(i - 2, this.open, this.close) == 1 &&
                    // very short upper shadow
                    this.GetUpperShadow(i - 2, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    // 2nd white                
                    this.GetCandleColor(i - 1, this.open, this.close) == 1 &&
                    // very short upper shadow
                    this.GetUpperShadow(i - 1, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // 3rd white   
                    this.GetCandleColor(i, this.open, this.close) == 1 &&
                    // very short upper shadow
                    this.GetUpperShadow(i, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowVeryShort, shadowVeryShortPeriodTotal[0], i, this.open, this.high, this.low, this.close) &&
                    // consecutive higher closes           
                    this.close[i] > this.close[i - 1] &&
                    this.close[i - 1] > this.close[i - 2] &&
                    // 2nd opens within/near 1st real body
                    this.open[i - 1] > this.open[i - 2] &&
                    this.open[i - 1] <= this.close[i - 2] +
                    this.GetCandleAverage(Near, nearPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    // 3rd opens within/near 2nd real body
                    this.open[i] > this.open[i - 1] &&
                    this.open[i] <= this.close[i - 1] +
                    this.GetCandleAverage(Near, nearPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // 2nd not far shorter than 1st
                    this.GetRealBody(i - 1, this.open, this.close) > this.GetRealBody(i - 2, this.open, this.close) -
                    this.GetCandleAverage(Far, farPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    // 3rd not far shorter than 2nd
                    this.GetRealBody(i, this.open, this.close) > this.GetRealBody(i - 1, this.open, this.close) -
                    this.GetCandleAverage(Far, farPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // not short real body
                    this.GetRealBody(i, this.open, this.close) > 
                    this.GetCandleAverage(BodyShort, bodyShortPeriodTotal, i, this.open, this.high, this.low, this.close);

                outInteger[outIdx++] = is3WhiteSoldiers ? 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 0; --totIdx)
                {
                    shadowVeryShortPeriodTotal[totIdx] +=
                        this.GetCandleRange(ShadowVeryShort, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(ShadowVeryShort, shadowVeryShortTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                for (int totIdx = 2; totIdx >= 1; --totIdx)
                {
                    farPeriodTotal[totIdx] +=
                        this.GetCandleRange(Far, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(Far, farTrailingIdx - totIdx, this.open, this.high, this.low, this.close);

                    nearPeriodTotal[totIdx] +=
                        this.GetCandleRange(Near, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(Near, nearTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                bodyShortPeriodTotal +=
                    this.GetCandleRange(BodyShort, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyShort, bodyShortTrailingIdx, this.open, this.high, this.low, this.close);

                i++;
                shadowVeryShortTrailingIdx++;
                nearTrailingIdx++;
                farTrailingIdx++;
                bodyShortTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int Cdl3WhiteSoldiersLookback()
        {
            return Math.Max(
                Math.Max(this.GetCandleAvgPeriod(ShadowVeryShort), this.GetCandleAvgPeriod(BodyShort)),
                Math.Max(this.GetCandleAvgPeriod(Far), this.GetCandleAvgPeriod(Near))
            ) + 2;
        }
    }
}
