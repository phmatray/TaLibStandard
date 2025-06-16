// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Triangular Moving Average (TRIMA) - a double-smoothed average that gives more weight to middle values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the TRIMA calculation. Valid range: 2 to 100000.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the TRIMA values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The Triangular Moving Average (TRIMA) is a weighted moving average that places the most weight
    /// on the middle portion of the data series. It's essentially a double-smoothed simple moving average,
    /// calculated by averaging a simple moving average.
    /// 
    /// Calculation method:
    /// - For even periods: SMA of SMA using period/2
    /// - For odd periods: SMA of SMA using (period+1)/2
    /// 
    /// Key characteristics:
    /// - Smoother than SMA or EMA
    /// - Greater lag than simple or exponential moving averages
    /// - Filters out short-term fluctuations effectively
    /// - Triangular weighting gives more importance to middle values
    /// 
    /// Common uses:
    /// - Long-term trend identification
    /// - Filtering market noise in volatile conditions
    /// - Confirming trends identified by faster moving averages
    /// - Support and resistance levels in trending markets
    /// 
    /// The increased smoothing makes TRIMA less responsive to recent price changes,
    /// making it better suited for identifying the overall trend rather than timing entries.
    /// </remarks>
    public static RetCode Trima(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int i;
        double tempReal;
        double numerator;
        double numeratorAdd;
        double numeratorSub;
        int middleIdx;
        int trailingIdx;
        int todayIdx;
        double factor;
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null!)
        {
            return BadParam;
        }

        if (optInTimePeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        int lookbackTotal = optInTimePeriod - 1;
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outIdx;
        if (optInTimePeriod % 2 != 1)
        {
            i = optInTimePeriod >> 1;
            factor = i * (i + 1);
            factor = 1.0 / factor;
            trailingIdx = startIdx - lookbackTotal;
            middleIdx = trailingIdx + i - 1;
            todayIdx = middleIdx + i;
            numerator = 0.0;
            numeratorSub = 0.0;
            i = middleIdx;
            while (i >= trailingIdx)
            {
                tempReal = inReal[i];
                numeratorSub += tempReal;
                numerator += numeratorSub;
                i--;
            }

            numeratorAdd = 0.0;
            middleIdx++;
            for (i = middleIdx; i <= todayIdx; i++)
            {
                tempReal = inReal[i];
                numeratorAdd += tempReal;
                numerator += numeratorAdd;
            }

            outIdx = 0;
            tempReal = inReal[trailingIdx];
            trailingIdx++;
            outReal[outIdx] = numerator * factor;
            outIdx++;
            todayIdx++;
            while (todayIdx <= endIdx)
            {
                numerator -= numeratorSub;
                numeratorSub -= tempReal;
                tempReal = inReal[middleIdx];
                middleIdx++;
                numeratorSub += tempReal;
                numeratorAdd -= tempReal;
                numerator += numeratorAdd;
                tempReal = inReal[todayIdx];
                todayIdx++;
                numeratorAdd += tempReal;
                numerator += tempReal;
                tempReal = inReal[trailingIdx];
                trailingIdx++;
                outReal[outIdx] = numerator * factor;
                outIdx++;
            }
        }
        else
        {
            i = optInTimePeriod >> 1;
            factor = (i + 1) * (i + 1);
            factor = 1.0 / factor;
            trailingIdx = startIdx - lookbackTotal;
            middleIdx = trailingIdx + i;
            todayIdx = middleIdx + i;
            numerator = 0.0;
            numeratorSub = 0.0;
            for (i = middleIdx; i >= trailingIdx; i--)
            {
                tempReal = inReal[i];
                numeratorSub += tempReal;
                numerator += numeratorSub;
            }

            numeratorAdd = 0.0;
            middleIdx++;
            for (i = middleIdx; i <= todayIdx; i++)
            {
                tempReal = inReal[i];
                numeratorAdd += tempReal;
                numerator += numeratorAdd;
            }

            outIdx = 0;
            tempReal = inReal[trailingIdx];
            trailingIdx++;
            outReal[outIdx] = numerator * factor;
            outIdx++;
            todayIdx++;
            while (todayIdx <= endIdx)
            {
                numerator -= numeratorSub;
                numeratorSub -= tempReal;
                tempReal = inReal[middleIdx];
                middleIdx++;
                numeratorSub += tempReal;
                numerator += numeratorAdd;
                numeratorAdd -= tempReal;
                tempReal = inReal[todayIdx];
                todayIdx++;
                numeratorAdd += tempReal;
                numerator += tempReal;
                tempReal = inReal[trailingIdx];
                trailingIdx++;
                outReal[outIdx] = numerator * factor;
                outIdx++;
            }
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for TRIMA calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the TRIMA calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid TRIMA value can be calculated, or -1 if parameters are invalid.</returns>
    public static int TrimaLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
