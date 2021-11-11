using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Candles.Candle3Outside;

public class Candle3Outside : CandleIndicator
{
    public Candle3Outside(in double[] open, in double[] high, in double[] low, in double[] close)
        : base(open, high, low, close)
    {
    }

    public Candle3OutsideResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];
            
        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new(OutOfRangeStartIndex, outBegIdx, outNBElement, outInteger);
        }
            
        if (endIdx < 0 || endIdx < startIdx)
        {
            return new(OutOfRangeEndIndex, outBegIdx, outNBElement, outInteger);
        }

        // Verify required price component.
        if (_open == null || _high == null || _low == null || _close == null)
        {
            return new(BadParam, outBegIdx, outNBElement, outInteger);
        }

        // Identify the minimum number of price bar needed to calculate at least one output.
        int lookbackTotal = GetLookback();

        // Move up the start index if there is not enough initial data.
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        // Make sure there is still something to evaluate.
        if (startIdx > endIdx)
        {
            return new(Success, outBegIdx, outNBElement, outInteger);
        }

        // Do the calculation using tight loops.
        // Add-up the initial period, except for the last value.
        int i = startIdx;
            
        /* Proceed with the calculation for the requested range.
         * Must have:
         * - first: black (white) real body
         * - second: white (black) real body that engulfs the prior real body
         * - third: candle that closes higher (lower) than the second candle
         * outInteger is positive (1 to 100) for the three outside up or negative (-1 to -100) for the three outside down;
         * the user should consider that a three outside up must appear in a downtrend and three outside down must appear
         * in an uptrend, while this function does not consider it
         */
        int outIdx = 0;
        do
        {
            bool is3Outside = GetPatternRecognition(i);

            outInteger[outIdx++] = is3Outside ? GetCandleColor(i - 1) * 100 : 0;

            i++;
        } while (i <= endIdx);

        // All done. Indicate the output limits and return.
        outNBElement = outIdx;
        outBegIdx = startIdx;
            
        return new(Success, outBegIdx, outNBElement, outInteger);
    }

    public override bool GetPatternRecognition(int i)
    {
        bool is3Outside =
            (
                // white engulfs black
                GetCandleColor(i - 1) == 1 &&
                GetCandleColor(i - 2) == -1 &&
                _close[i - 1] > _open[i - 2] &&
                _open[i - 1] < _close[i - 2] &&
                // third candle higher
                _close[i] > _close[i - 1]
            )
            ||
            (
                // black engulfs white
                GetCandleColor(i - 1) == -1 &&
                GetCandleColor(i - 2) == 1 &&
                _open[i - 1] > _close[i - 2] &&
                _close[i - 1] < _open[i - 2] &&
                // third candle lower
                _close[i] < _close[i - 1]
            );
            
        return is3Outside;
    }

    public override int GetLookback()
    {
        return 3;
    }
}