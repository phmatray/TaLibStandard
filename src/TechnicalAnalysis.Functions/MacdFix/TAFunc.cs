// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Moving Average Convergence Divergence Fixed 12/26 (MACDFIX) - a momentum indicator with fixed fast and slow periods.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInSignalPeriod">Number of periods for the signal line EMA. Valid range: 1 to 100000. Typical value: 9.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outMACD">Output array for the MACD line values (12-period EMA - 26-period EMA).</param>
    /// <param name="outMACDSignal">Output array for the signal line values (EMA of MACD line).</param>
    /// <param name="outMACDHist">Output array for the MACD histogram values (MACD line - signal line).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// MACDFIX is a specialized version of MACD that uses fixed periods:
    /// - Fast EMA: Fixed at 12 periods
    /// - Slow EMA: Fixed at 26 periods
    /// - Signal Line: Customizable EMA of MACD line (typically 9 periods)
    /// 
    /// The three output components are:
    /// - MACD Line = 12-period EMA - 26-period EMA
    /// - Signal Line = EMA of MACD Line (period specified by optInSignalPeriod)
    /// - MACD Histogram = MACD Line - Signal Line
    /// 
    /// This function is ideal when you want to use the traditional MACD settings (12, 26, 9)
    /// without having to specify the fast and slow periods each time. Only the signal period
    /// can be customized.
    /// 
    /// Trading signals are the same as regular MACD:
    /// - Bullish: MACD line crosses above signal line
    /// - Bearish: MACD line crosses below signal line
    /// - Divergence: Price makes new high/low but MACD doesn't confirm
    /// - Zero line crossovers indicate trend changes
    /// </remarks>
    public static RetCode MacdFix(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInSignalPeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outMACD,
        ref double[] outMACDSignal,
        ref double[] outMACDHist)
    {
        var inRealLocal = inReal;
        var outMACDLocal = outMACD;
        var outMACDHistLocal = outMACDHist;
        var outMACDSignalLocal = outMACDSignal;
        var optInSignalPeriodLocal = optInSignalPeriod;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inRealLocal, outMACDLocal, outMACDSignalLocal, outMACDHistLocal),
            () => ValidationHelper.ValidatePeriodRange(optInSignalPeriodLocal, 1)
        );
        if (validation != Success)
        {
            return validation;
        }

        RetCode taIntMACD = TA_INT_MACD(
            startIdx,
            endIdx,
            inReal,
            0,
            0,
            optInSignalPeriod,
            ref outBegIdx,
            ref outNBElement,
            outMACD,
            outMACDSignal,
            outMACDHist);
        
        return taIntMACD;
    }

    /// <summary>
    /// Returns the lookback period required for MACDFIX calculation.
    /// </summary>
    /// <param name="optInSignalPeriod">Number of periods for the signal line EMA. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid MACDFIX value can be calculated, or -1 if the signal period parameter is invalid.</returns>
    /// <remarks>
    /// The lookback period for MACDFIX is calculated based on:
    /// - The fixed 26-period slow EMA (since it's the longer of the two fixed EMAs)
    /// - The signal line EMA period
    /// 
    /// The total lookback is the sum of the lookback periods for the 26-period EMA
    /// and the signal line EMA. This ensures sufficient historical data is available
    /// for accurate calculation of all MACDFIX components.
    /// </remarks>
    public static int MacdFixLookback(int optInSignalPeriod)
    {
        return optInSignalPeriod is < 1 or > 100000 ? -1 : EmaLookback(26) + EmaLookback(optInSignalPeriod);
    }
}
