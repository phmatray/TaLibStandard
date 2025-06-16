// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Weighted Moving Average (WMA) - a moving average that gives more weight to recent data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the WMA calculation. Typical values: 10, 20.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the WMA values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// WMA assigns linearly decreasing weights to older data points:
    /// - Most recent value: weight = n
    /// - Second most recent: weight = n-1
    /// - Oldest value: weight = 1
    /// Where n is the period.
    /// 
    /// Formula: WMA = Σ(Price[i] × Weight[i]) / Σ(Weight[i])
    /// 
    /// Characteristics:
    /// - More responsive than SMA but less than EMA
    /// - Linear weighting scheme is intuitive
    /// - Smoother than EMA, less lag than SMA
    /// - Good balance between responsiveness and smoothness
    /// 
    /// WMA is often used when you want more weight on recent data
    /// but prefer a predictable linear weighting scheme.
    /// </remarks>
    public static RetCode Wma(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double tempReal;
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

        if (optInTimePeriod == 1)
        {
            outBegIdx = startIdx;
            outNBElement = endIdx - startIdx + 1;
            Array.Copy(inReal, startIdx, outReal, 0, outNBElement);
            return Success;
        }

        int divider = (optInTimePeriod * (optInTimePeriod + 1)) >> 1;
        int outIdx = 0;
        int trailingIdx = startIdx - lookbackTotal;
        double periodSub = 0.0;
        double periodSum = periodSub;
        int inIdx = trailingIdx;
        int i = 1;
        while (true)
        {
            if (inIdx >= startIdx)
            {
                break;
            }

            tempReal = inReal[inIdx];
            inIdx++;
            periodSub += tempReal;
            periodSum += tempReal * i;
            i++;
        }

        double trailingValue = 0.0;
        while (true)
        {
            if (inIdx > endIdx)
            {
                break;
            }

            tempReal = inReal[inIdx];
            inIdx++;
            periodSub += tempReal;
            periodSub -= trailingValue;
            periodSum += tempReal * optInTimePeriod;
            trailingValue = inReal[trailingIdx];
            trailingIdx++;
            outReal[outIdx] = periodSum / divider;
            outIdx++;
            periodSum -= periodSub;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for WMA calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the WMA calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid WMA value can be calculated, or -1 if parameters are invalid.</returns>
    public static int WmaLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
