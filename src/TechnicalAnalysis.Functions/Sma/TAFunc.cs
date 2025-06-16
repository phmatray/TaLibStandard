// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Simple Moving Average (SMA) - the average price over a specified number of periods.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the SMA calculation. Typical values: 20, 50, 100, 200.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the SMA values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The Simple Moving Average is calculated as:
    /// SMA = Sum of prices over N periods / N
    /// 
    /// SMAs smooth price data by creating a constantly updated average price.
    /// Common uses:
    /// - Trend identification: Price above SMA suggests uptrend, below suggests downtrend
    /// - Support and resistance levels
    /// - Entry/exit signals when price or faster MAs cross the SMA
    /// - Golden cross (50 SMA crosses above 200 SMA) and death cross patterns
    /// 
    /// SMAs lag more than EMAs but are less sensitive to whipsaws.
    /// </remarks>
    public static RetCode Sma(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null! ||
            optInTimePeriod is < 2 or > 100000 ||
            outReal == null!)
        {
            return BadParam;
        }

        RetCode taIntSma = TA_INT_SMA(startIdx, endIdx, inReal, optInTimePeriod, ref outBegIdx, ref outNBElement, outReal);
        
        return taIntSma;
    }

    /// <summary>
    /// Returns the lookback period required for SMA calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the SMA calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid SMA value can be calculated, or -1 if parameters are invalid.</returns>
    public static int SmaLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
