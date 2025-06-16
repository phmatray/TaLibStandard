// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the MACD Extended - a flexible version of MACD allowing different moving average types.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInFastPeriod">Number of periods for the fast moving average. Typical value: 12.</param>
    /// <param name="optInFastMAType">Type of moving average to use for the fast MA (SMA, EMA, WMA, etc.).</param>
    /// <param name="optInSlowPeriod">Number of periods for the slow moving average. Typical value: 26.</param>
    /// <param name="optInSlowMAType">Type of moving average to use for the slow MA (SMA, EMA, WMA, etc.).</param>
    /// <param name="optInSignalPeriod">Number of periods for the signal line moving average. Typical value: 9.</param>
    /// <param name="optInSignalMAType">Type of moving average to use for the signal line (SMA, EMA, WMA, etc.).</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outMACD">Output array for the MACD line values (fast MA - slow MA).</param>
    /// <param name="outMACDSignal">Output array for the signal line values (MA of MACD line).</param>
    /// <param name="outMACDHist">Output array for the MACD histogram values (MACD line - signal line).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// MACD Extended provides the same three components as standard MACD but with customizable moving average types:
    /// - MACD Line = Fast MA - Slow MA
    /// - Signal Line = MA of MACD Line
    /// - MACD Histogram = MACD Line - Signal Line
    /// 
    /// This extended version allows experimentation with different MA types (SMA, WMA, DEMA, TEMA, etc.)
    /// for potentially better responsiveness or smoothing characteristics.
    /// 
    /// Common configurations:
    /// - Standard MACD: All MAs use EMA
    /// - Responsive MACD: Fast/Slow use DEMA, Signal uses EMA
    /// - Smooth MACD: Fast/Slow use EMA, Signal uses SMA
    /// 
    /// The function automatically swaps fast and slow periods if slow period is less than fast period.
    /// </remarks>
    public static RetCode MacdExt(
        int startIdx,
        int endIdx,
        in double[] inReal,
        int optInFastPeriod,
        MAType optInFastMAType,
        int optInSlowPeriod,
        MAType optInSlowMAType,
        in int optInSignalPeriod,
        in MAType optInSignalMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outMACD,
        ref double[] outMACDSignal,
        ref double[] outMACDHist)
    {
        int i;
        int outNbElement1 = 0;
        int outNbElement2 = 0;
        int outBegIdx2 = 0;
        int outBegIdx1 = 0;
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

        if (optInFastPeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (optInSlowPeriod is < 2 or > 100000)
        {
            return BadParam;
        }

        if (optInSignalPeriod is < 1 or > 100000)
        {
            return BadParam;
        }

        if (outMACD == null!)
        {
            return BadParam;
        }

        if (outMACDSignal == null!)
        {
            return BadParam;
        }

        if (outMACDHist == null!)
        {
            return BadParam;
        }

        int tempInteger;
        if (optInSlowPeriod < optInFastPeriod)
        {
            tempInteger = optInSlowPeriod;
            optInSlowPeriod = optInFastPeriod;
            optInFastPeriod = tempInteger;
            (optInSlowMAType, optInFastMAType) = (optInFastMAType, optInSlowMAType);
        }

        int lookbackLargest = MovingAverageLookback(optInFastPeriod, optInFastMAType);
        tempInteger = MovingAverageLookback(optInSlowPeriod, optInSlowMAType);
        if (tempInteger > lookbackLargest)
        {
            lookbackLargest = tempInteger;
        }

        int lookbackSignal = MovingAverageLookback(optInSignalPeriod, optInSignalMAType);
        int lookbackTotal = lookbackSignal + lookbackLargest;
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

        tempInteger = endIdx - startIdx + 1 + lookbackSignal;
        double[] fastMABuffer = new double[tempInteger];
        double[] slowMABuffer = new double[tempInteger];

        tempInteger = startIdx - lookbackSignal;
        RetCode retCode = MovingAverage(
            tempInteger,
            endIdx,
            inReal,
            optInSlowPeriod,
            optInSlowMAType,
            ref outBegIdx1,
            ref outNbElement1,
            ref slowMABuffer);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        retCode = MovingAverage(
            tempInteger,
            endIdx,
            inReal,
            optInFastPeriod,
            optInFastMAType,
            ref outBegIdx2,
            ref outNbElement2,
            ref fastMABuffer);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        if (outBegIdx1 != tempInteger || outBegIdx2 != tempInteger || outNbElement1 != outNbElement2 || outNbElement1 != endIdx - startIdx + 1 + lookbackSignal)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return InternalError;
        }

        for (i = 0; i < outNbElement1; i++)
        {
            fastMABuffer[i] -= slowMABuffer[i];
        }

        Array.Copy(fastMABuffer, lookbackSignal, outMACD, 0, endIdx - startIdx + 1);
        retCode = MovingAverage(
            0,
            outNbElement1 - 1,
            fastMABuffer,
            optInSignalPeriod,
            optInSignalMAType,
            ref outBegIdx2,
            ref outNbElement2,
            ref outMACDSignal);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        for (i = 0; i < outNbElement2; i++)
        {
            outMACDHist[i] = outMACD[i] - outMACDSignal[i];
        }

        outBegIdx = startIdx;
        outNBElement = outNbElement2;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for MACD Extended calculation.
    /// </summary>
    /// <param name="optInFastPeriod">Number of periods for the fast moving average. Valid range: 2 to 100000.</param>
    /// <param name="optInFastMAType">Type of moving average to use for the fast MA.</param>
    /// <param name="optInSlowPeriod">Number of periods for the slow moving average. Valid range: 2 to 100000.</param>
    /// <param name="optInSlowMAType">Type of moving average to use for the slow MA.</param>
    /// <param name="optInSignalPeriod">Number of periods for the signal line moving average. Valid range: 1 to 100000.</param>
    /// <param name="optInSignalMAType">Type of moving average to use for the signal line.</param>
    /// <returns>The number of historical data points required before the first valid MACD Extended value can be calculated, or -1 if parameters are invalid.</returns>
    /// <remarks>
    /// The lookback period is determined by finding the maximum lookback among the fast and slow moving averages,
    /// then adding the signal line's lookback period. Different MA types have different lookback requirements:
    /// - SMA: period - 1
    /// - EMA: period - 1
    /// - WMA: period - 1
    /// - DEMA: 2 * (period - 1)
    /// - TEMA: 3 * (period - 1)
    /// - And others as defined by their specific algorithms
    /// </remarks>
    public static int MacdExtLookback(
        int optInFastPeriod,
        MAType optInFastMAType,
        int optInSlowPeriod,
        MAType optInSlowMAType,
        int optInSignalPeriod,
        MAType optInSignalMAType)
    {
        if (optInFastPeriod is < 2 or > 100000)
        {
            return -1;
        }

        if (optInSlowPeriod is < 2 or > 100000)
        {
            return -1;
        }

        if (optInSignalPeriod is < 1 or > 100000)
        {
            return -1;
        }

        int lookbackLargest = MovingAverageLookback(optInFastPeriod, optInFastMAType);
        int tempInteger = MovingAverageLookback(optInSlowPeriod, optInSlowMAType);
        if (tempInteger > lookbackLargest)
        {
            lookbackLargest = tempInteger;
        }

        return lookbackLargest + MovingAverageLookback(optInSignalPeriod, optInSignalMAType);
    }
}
