using System;
using TechnicalAnalysis.Abstractions;
using static TechnicalAnalysis.CandleSettingType;

namespace TechnicalAnalysis.Candle
{
    public class CandleHighWave : CandleIndicator
    {
        public CandleHighWave(in double[] open, in double[] high, in double[] low, in double[] close)
            : base(open, high, low, close)
        {
        }

        public RetCode CdlHighWave(
            int startIdx,
            int endIdx,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
        {
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
            int lookbackTotal = this.CdlHighWaveLookback();

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
            int bodyTrailingIdx = startIdx - this.GetCandleAvgPeriod(BodyShort);
            double shadowPeriodTotal = 0.0;
            int shadowTrailingIdx = startIdx - this.GetCandleAvgPeriod(ShadowVeryLong);
            
            int i = bodyTrailingIdx;
            while (i < startIdx)
            {
                bodyPeriodTotal += this.GetCandleRange(BodyShort, i, this.open, this.high, this.low, this.close);
                i++;
            }

            i = shadowTrailingIdx;
            while (i < startIdx)
            {
                shadowPeriodTotal += this.GetCandleRange(ShadowVeryLong, i, this.open, this.high, this.low, this.close);
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
            do
            {
                bool isHighWave =
                    this.GetRealBody(i, this.open, this.close) <
                    this.GetCandleAverage(BodyShort, bodyPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    this.GetUpperShadow(i, this.open, this.low, this.close) >
                    this.GetCandleAverage(ShadowVeryLong, shadowPeriodTotal, i, this.open, this.high, this.low, this.close) &&
                    this.GetLowerShadow(i, this.open, this.low, this.close) >
                    this.GetCandleAverage(ShadowVeryLong, shadowPeriodTotal, i, this.open, this.high, this.low, this.close);

                outInteger[outIdx++] = isHighWave ? this.GetCandleColor(i, this.open, this.close) * 100 : 0;

                /* add the current range and subtract the first range: this is done after the pattern recognition 
                 * when avgPeriod is not 0, that means "compare with the previous candles" (it excludes the current candle)
                 */
                bodyPeriodTotal +=
                    this.GetCandleRange(BodyShort, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(BodyShort, bodyTrailingIdx, this.open, this.high, this.low, this.close);

                shadowPeriodTotal +=
                    this.GetCandleRange(ShadowVeryLong, i, this.open, this.high, this.low, this.close) -
                    this.GetCandleRange(ShadowVeryLong, shadowTrailingIdx, this.open, this.high, this.low, this.close);

                i++;
                bodyTrailingIdx++;
                shadowTrailingIdx++;
            } while (i <= endIdx);

            // All done. Indicate the output limits and return.
            outNBElement = outIdx;
            outBegIdx = startIdx;
            
            return RetCode.Success;
        }

        public int CdlHighWaveLookback()
        {
            return Math.Max(this.GetCandleAvgPeriod(BodyShort), this.GetCandleAvgPeriod(ShadowVeryLong));
        }
    }
}
