using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleAdvanceBlock : CandleIndicator
    {
        public CandleAdvanceBlock(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlAdvanceBlock(
            int startIdx,
            int endIdx,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
            // Local variables
            double[] shadowShortPeriodTotal = new double[3];
            double[] shadowLongPeriodTotal = new double[2];
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
            int lookbackTotal = this.CdlAdvanceBlockLookback();

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
            shadowShortPeriodTotal[2] = 0.0;
            shadowShortPeriodTotal[1] = 0.0;
            shadowShortPeriodTotal[0] = 0.0;
            int shadowShortTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowShort);
            shadowLongPeriodTotal[1] = 0.0;
            shadowLongPeriodTotal[0] = 0.0;
            int shadowLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowLong);
            nearPeriodTotal[2] = 0.0;
            nearPeriodTotal[1] = 0.0;
            nearPeriodTotal[0] = 0.0;
            int nearTrailingIdx = startIdx - this.GetCandleAvgPeriod(Near);
            farPeriodTotal[2] = 0.0;
            farPeriodTotal[1] = 0.0;
            farPeriodTotal[0] = 0.0;
            int farTrailingIdx = startIdx - this.GetCandleAvgPeriod(Far);
            double bodyLongPeriodTotal = 0.0;
            int bodyLongTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyLong);
            
            int i = shadowShortTrailingIdx;
            while (i < startIdx)
            {
                shadowShortPeriodTotal[2] += this.GetCandleRange(ShadowShort, i - 2, this.open, this.high, this.low, this.close);
                shadowShortPeriodTotal[1] += this.GetCandleRange(ShadowShort, i - 1, this.open, this.high, this.low, this.close);
                shadowShortPeriodTotal[0] += this.GetCandleRange(ShadowShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = shadowLongTrailingIdx;
            while (i < startIdx)
            {
                shadowLongPeriodTotal[1] += this.GetCandleRange(ShadowLong, i - 1, this.open, this.high, this.low, this.close);
                shadowLongPeriodTotal[0] += this.GetCandleRange(ShadowLong, i, this.open, this.high, this.low, this.close);
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

            i = bodyLongTrailingIdx;
            while (i < startIdx)
            {
                bodyLongPeriodTotal += this.GetCandleRange(BodyLong, i - 2, this.open, this.high, this.low, this.close);
                i++;
            }

            i = startIdx;
            
            /* Proceed with the calculation for the requested range.
             * Must have:
             * - three white candlesticks with consecutively higher closes
             * - each candle opens within or near the previous white real body 
             * - first candle: long white with no or very short upper shadow (a short shadow is accepted too for more flexibility)
             * - second and third candles, or only third candle, show signs of weakening: progressively smaller white real bodies 
             * and/or relatively long upper shadows; see below for specific conditions
             * The meanings of "long body", "short shadow", "far" and "near" are specified with TA_SetCandleSettings;
             * outInteger is negative (-1 to -100): advance block is always bearish;
             * the user should consider that advance block is significant when it appears in uptrend, while this function 
             * does not consider it
             */
            int outIdx = 0;
            do
            {
                bool isAdvanceBlock =
                    // 1st white
                    this.GetCandleColor(i - 2, this.open, this.close) == 1 &&
                    // 2nd white
                    this.GetCandleColor(i - 1, this.open, this.close) == 1 &&
                    // 3rd white
                    this.GetCandleColor(i, this.open, this.close) == 1 &&
                    // consecutive higher closes
                    this.close[i] > this.close[i - 1] && this.close[i - 1] > this.close[i - 2] &&
                    // 2nd opens within/near 1st real body
                    this.open[i - 1] > this.open[i - 2] &&
                    this.open[i - 1] <= this.close[i - 2] + this.GetCandleAverage(Near, nearPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    // 3rd opens within/near 2nd real body
                    this.open[i] > this.open[i - 1] &&
                    this.open[i] <= this.close[i - 1] +
                    this.GetCandleAverage(Near, nearPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close) &&
                    // 1st: long real body
                    this.GetRealBody(i - 2, this.open, this.close) >
                    this.GetCandleAverage(BodyLong, bodyLongPeriodTotal, i - 2, this.open, this.high, this.low, this.close) &&
                    // 1st: short upper shadow
                    this.GetUpperShadow(i - 2, this.open, this.low, this.close) <
                    this.GetCandleAverage(ShadowShort, shadowShortPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                    (
                        // ( 2 far smaller than 1 && 3 not longer than 2 )
                        // advance blocked with the 2nd, 3rd must not carry on the advance
                        (
                            this.GetRealBody(i - 1, this.open, this.close) < this.GetRealBody(i - 2, this.open, this.close) -
                            this.GetCandleAverage(Far, farPeriodTotal[2], i - 2, this.open, this.high, this.low, this.close) &&
                            this.GetRealBody(i, this.open, this.close) < this.GetRealBody(i - 1, this.open, this.close) +
                            this.GetCandleAverage(Near, nearPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close)
                        ) ||
                        // 3 far smaller than 2
                        // advance blocked with the 3rd
                        (
                            this.GetRealBody(i, this.open, this.close) < this.GetRealBody(i - 1, this.open, this.close) -
                            this.GetCandleAverage(Far, farPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close)
                        ) ||
                        // ( 3 smaller than 2 && 2 smaller than 1 && (3 or 2 not short upper shadow) )
                        // advance blocked with progressively smaller real bodies and some upper shadows
                        (
                            this.GetRealBody(i, this.open, this.close) < this.GetRealBody(i - 1, this.open, this.close) &&
                            this.GetRealBody(i - 1, this.open, this.close) < this.GetRealBody(i - 2, this.open, this.close) &&
                            (
                                this.GetUpperShadow(i, this.open, this.low, this.close) > 
                                this.GetCandleAverage(ShadowShort, shadowShortPeriodTotal[0], i, this.open, this.high, this.low, this.close) ||
                                this.GetUpperShadow(i - 1, this.open, this.low, this.close) > 
                                this.GetCandleAverage(ShadowShort, shadowShortPeriodTotal[1], i - 1, this.open, this.high, this.low, this.close)
                            )
                        ) ||
                        // ( 3 smaller than 2 && 3 long upper shadow )
                        // advance blocked with 3rd candle's long upper shadow and smaller body
                        (
                            this.GetRealBody(i, this.open, this.close) < this.GetRealBody(i - 1, this.open, this.close) &&
                            this.GetUpperShadow(i, this.open, this.low, this.close) >
                            this.GetCandleAverage(ShadowLong, shadowLongPeriodTotal[0], i, this.open, this.high, this.low, this.close)
                        )
                    );

                outInteger[outIdx++] = isAdvanceBlock ? -100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                for (int totIdx = 2; totIdx >= 0; --totIdx)
                {
                    shadowShortPeriodTotal[totIdx] +=
                        this.GetCandleRange(ShadowShort, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(ShadowShort, shadowShortTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
                }

                for (int totIdx = 1; totIdx >= 0; --totIdx)
                {
                    shadowLongPeriodTotal[totIdx] +=
                        this.GetCandleRange(ShadowLong, i - totIdx, this.open, this.high, this.low, this.close) -
                        this.GetCandleRange(ShadowLong, shadowLongTrailingIdx - totIdx, this.open, this.high, this.low, this.close);
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

                bodyLongPeriodTotal +=
                    this.GetCandleRange(BodyLong, i - 2, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyLong, bodyLongTrailingIdx - 2, this.open, this.high, this.low, this.close);

                i++;
                shadowShortTrailingIdx++;
                shadowLongTrailingIdx++;
                nearTrailingIdx++;
                farTrailingIdx++;
                bodyLongTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlAdvanceBlockLookback()
        {
            return Math.Max(
                Math.Max(
                    Math.Max(this.GetCandleAvgPeriod(ShadowLong), this.GetCandleAvgPeriod(ShadowShort)),
                    Math.Max(this.GetCandleAvgPeriod(Far), this.GetCandleAvgPeriod(Near))),
                this.GetCandleAvgPeriod(BodyLong)
            ) + 2;
        }
    }
}
