// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Moving Average Convergence Divergence (MACD) - a trend-following momentum indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInFastPeriod">Number of periods for the fast EMA. Typical value: 12.</param>
    /// <param name="optInSlowPeriod">Number of periods for the slow EMA. Typical value: 26.</param>
    /// <param name="optInSignalPeriod">Number of periods for the signal line EMA. Typical value: 9.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outMACD">Output array for the MACD line values (fast EMA - slow EMA).</param>
    /// <param name="outMACDSignal">Output array for the signal line values (EMA of MACD line).</param>
    /// <param name="outMACDHist">Output array for the MACD histogram values (MACD line - signal line).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// MACD consists of three components:
    /// - MACD Line = Fast EMA - Slow EMA (typically 12-day EMA - 26-day EMA)
    /// - Signal Line = EMA of MACD Line (typically 9-day EMA)
    /// - MACD Histogram = MACD Line - Signal Line
    /// 
    /// Trading signals:
    /// - Bullish: MACD line crosses above signal line
    /// - Bearish: MACD line crosses below signal line
    /// - Divergence: Price makes new high/low but MACD doesn't confirm
    /// - Zero line crossovers also provide trend change signals
    /// </remarks>
    public static RetCode Macd(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInFastPeriod,
        in int optInSlowPeriod,
        in int optInSignalPeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outMACD,
        ref double[] outMACDSignal,
        ref double[] outMACDHist)
    {
        RetCode indexCheck = ValidationHelper.ValidateIndexRange(startIdx, endIdx);
        if (indexCheck != Success)
        {
            return indexCheck;
        }

        RetCode arrayCheck = ValidationHelper.ValidateArrays(inReal, outMACD, outMACDSignal, outMACDHist);
        if (arrayCheck != Success)
        {
            return arrayCheck;
        }

        RetCode fastPeriodCheck = ValidationHelper.ValidatePeriodRange(optInFastPeriod);
        if (fastPeriodCheck != Success)
        {
            return fastPeriodCheck;
        }

        RetCode slowPeriodCheck = ValidationHelper.ValidatePeriodRange(optInSlowPeriod);
        if (slowPeriodCheck != Success)
        {
            return slowPeriodCheck;
        }

        RetCode signalPeriodCheck = ValidationHelper.ValidatePeriodRange(optInSignalPeriod, 1);
        if (signalPeriodCheck != Success)
        {
            return signalPeriodCheck;
        }

        RetCode taIntMACD = TA_INT_MACD(
            startIdx,
            endIdx,
            inReal,
            optInFastPeriod,
            optInSlowPeriod,
            optInSignalPeriod,
            ref outBegIdx,
            ref outNBElement,
            outMACD,
            outMACDSignal,
            outMACDHist);
        
        return taIntMACD;
    }

    /// <summary>
    /// Returns the lookback period required for MACD calculation.
    /// </summary>
    /// <param name="optInFastPeriod">Number of periods for the fast EMA. Valid range: 2 to 100000.</param>
    /// <param name="optInSlowPeriod">Number of periods for the slow EMA. Valid range: 2 to 100000.</param>
    /// <param name="optInSignalPeriod">Number of periods for the signal line EMA. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid MACD value can be calculated, or -1 if parameters are invalid.</returns>
    public static int MacdLookback(int optInFastPeriod, int optInSlowPeriod, int optInSignalPeriod)
    {
        int validatedFastPeriod = ValidationHelper.ValidateLookbackPeriod(optInFastPeriod);
        int validatedSlowPeriod = ValidationHelper.ValidateLookbackPeriod(optInSlowPeriod);
        int validatedSignalPeriod = ValidationHelper.ValidateLookbackPeriod(optInSignalPeriod, 1);

        if (validatedFastPeriod == -1 || validatedSlowPeriod == -1 || validatedSignalPeriod == -1)
        {
            return -1;
        }

        if (optInSlowPeriod < optInFastPeriod)
        {
            (optInSlowPeriod, _) = (optInFastPeriod, optInSlowPeriod);
        }

        return EmaLookback(optInSlowPeriod) + EmaLookback(optInSignalPeriod);
    }
}
