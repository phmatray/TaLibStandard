// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Provides technical analysis functions for financial market analysis.
/// </summary>
/// <remarks>
/// This class contains a comprehensive set of technical indicators and mathematical functions
/// commonly used in financial market analysis. All functions are static methods that operate
/// on arrays of price data (open, high, low, close, volume) and return calculated indicator values.
/// 
/// Categories of functions include:
/// - Overlap Studies (Moving Averages, Bollinger Bands, etc.)
/// - Momentum Indicators (RSI, MACD, Stochastic, etc.)
/// - Volume Indicators (OBV, AD, MFI, etc.)
/// - Volatility Indicators (ATR, Standard Deviation, etc.)
/// - Price Transform (Typical Price, Weighted Close, etc.)
/// - Cycle Indicators (Hilbert Transform functions)
/// - Pattern Recognition (Candlestick patterns - in separate classes)
/// - Statistical Functions (Correlation, Beta, etc.)
/// - Mathematical Operations (Trigonometric, Logarithmic, etc.)
/// 
/// All functions follow a consistent pattern:
/// - Input parameters include start/end indices and price arrays
/// - Output parameters include beginning index, number of elements, and result arrays
/// - Return value is a RetCode indicating success or failure
/// - Lookback functions return the number of historical data points required
/// 
/// Thread Safety: All methods are thread-safe as they don't modify shared state.
/// </remarks>
public static partial class TAFunc
{
    /// <summary>
    /// Internal implementation of Exponential Moving Average calculation.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="inReal0">Input array of values.</param>
    /// <param name="optInTimePeriod0">Number of periods for the EMA.</param>
    /// <param name="optInK1">The smoothing factor (2/(period+1)).</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNbElement">The number of valid output elements.</param>
    /// <param name="outReal0">Output array for the EMA values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// This internal method provides the core EMA calculation used by multiple public functions.
    /// It handles both default and compatibility modes for initialization.
    /// </remarks>
    private static RetCode TA_INT_EMA(int startIdx, int endIdx, double[] inReal0, int optInTimePeriod0, double optInK1, ref int outBegIdx, ref int outNbElement, double[] outReal0)
    {
        int today;
        double prevMA;
        int lookbackTotal = EmaLookback(optInTimePeriod0);
            
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }
            
        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return Success;
        }
            
        outBegIdx = startIdx;
            
        if (TACore.Globals.Compatibility != Compatibility.Default)
        {
            prevMA = inReal0[0];
            today = 1;
        }
        else
        {
            today = startIdx - lookbackTotal;
            int i = optInTimePeriod0;
            double tempReal = 0.0;
            while (true)
            {
                i--;
                    
                if (i <= 0)
                {
                    break;
                }
                    
                tempReal += inReal0[today];
                today++;
            }
            prevMA = tempReal / optInTimePeriod0;
        }
            
        while (today <= startIdx)
        {
            prevMA = ((inReal0[today] - prevMA) * optInK1) + prevMA;
            today++;
        }
            
        outReal0[0] = prevMA;
        int outIdx = 1;
            
        while (true)
        {
            if (today > endIdx)
            {
                break;
            }
                
            prevMA = ((inReal0[today] - prevMA) * optInK1) + prevMA;
            today++;
            outReal0[outIdx] = prevMA;
            outIdx++;
        }
            
        outNbElement = outIdx;
        return Success;
    }
        
    /// <summary>
    /// Internal implementation of MACD (Moving Average Convergence Divergence) calculation.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="inReal0">Input array of values (typically closing prices).</param>
    /// <param name="optInFastPeriod0">Fast EMA period (typically 12).</param>
    /// <param name="optInSlowPeriod1">Slow EMA period (typically 26).</param>
    /// <param name="optInSignalPeriod2">Signal line EMA period (typically 9).</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNbElement">The number of valid output elements.</param>
    /// <param name="outMACD0">Output array for MACD line values.</param>
    /// <param name="outMACDSignal1">Output array for signal line values.</param>
    /// <param name="outMACDHist2">Output array for histogram values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Calculates all three MACD components: MACD line (fast EMA - slow EMA),
    /// signal line (EMA of MACD), and histogram (MACD - signal).
    /// </remarks>
    private static RetCode TA_INT_MACD(int startIdx, int endIdx, double[] inReal0, int optInFastPeriod0, int optInSlowPeriod1, int optInSignalPeriod2, ref int outBegIdx, ref int outNbElement, double[] outMACD0, double[] outMACDSignal1, double[] outMACDHist2)
    {
        int i;
        int outNbElement1 = 0;
        int outNbElement2 = 0;
        double k2;
        double k1;
        int outBegIdx2 = 0;
        int outBegIdx1 = 0;

        int tempInteger;
        if (optInSlowPeriod1 < optInFastPeriod0)
        {
            tempInteger = optInSlowPeriod1;
            optInSlowPeriod1 = optInFastPeriod0;
            optInFastPeriod0 = tempInteger;
        }

        if (optInSlowPeriod1 != 0)
        {
            k1 = 2.0 / (optInSlowPeriod1 + 1);
        }
        else
        {
            optInSlowPeriod1 = 26;
            k1 = 0.075;
        }
            
        if (optInFastPeriod0 != 0)
        {
            k2 = 2.0 / (optInFastPeriod0 + 1);
        }
        else
        {
            optInFastPeriod0 = 12;
            k2 = 0.15;
        }
            
        int lookbackSignal = EmaLookback(optInSignalPeriod2);
        int lookbackTotal = lookbackSignal;
        lookbackTotal += EmaLookback(optInSlowPeriod1);
            
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }
            
        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return Success;
        }
            
        tempInteger = endIdx - startIdx + 1 + lookbackSignal;
            
        double[] fastEMABuffer = new double[tempInteger];
        double[] slowEMABuffer = new double[tempInteger];
            
        tempInteger = startIdx - lookbackSignal;
        RetCode retCode = TA_INT_EMA(tempInteger, endIdx, inReal0, optInSlowPeriod1, k1, ref outBegIdx1, ref outNbElement1, slowEMABuffer);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return retCode;
        }
            
        retCode = TA_INT_EMA(tempInteger, endIdx, inReal0, optInFastPeriod0, k2, ref outBegIdx2, ref outNbElement2, fastEMABuffer);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return retCode;
        }
            
        if (outBegIdx1 != tempInteger || outBegIdx2 != tempInteger || outNbElement1 != outNbElement2 || outNbElement1 != endIdx - startIdx + 1 + lookbackSignal)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return InternalError;
        }
            
        for (i = 0; i < outNbElement1; i++)
        {
            fastEMABuffer[i] -= slowEMABuffer[i];
        }
            
        Array.Copy(fastEMABuffer, lookbackSignal, outMACD0, 0, endIdx - startIdx + 1);
        retCode = TA_INT_EMA(0, outNbElement1 - 1, fastEMABuffer, optInSignalPeriod2, 2.0 / (optInSignalPeriod2 + 1), ref outBegIdx2, ref outNbElement2, outMACDSignal1);
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return retCode;
        }
            
        for (i = 0; i < outNbElement2; i++)
        {
            outMACDHist2[i] = outMACD0[i] - outMACDSignal1[i];
        }
            
        outBegIdx = startIdx;
        outNbElement = outNbElement2;
        return Success;
    }
        
    /// <summary>
    /// Internal implementation for Price Oscillator calculations (APO and PPO).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="inReal0">Input array of values.</param>
    /// <param name="optInFastPeriod0">Fast moving average period.</param>
    /// <param name="optInSlowPeriod1">Slow moving average period.</param>
    /// <param name="optInMethod2">Moving average type to use.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNbElement">The number of valid output elements.</param>
    /// <param name="outReal0">Output array for oscillator values.</param>
    /// <param name="tempBuffer">Temporary buffer for intermediate calculations.</param>
    /// <param name="doPercentageOutput">0 for absolute values (APO), 1 for percentage values (PPO).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// This method calculates the difference between two moving averages,
    /// either as an absolute value (APO) or as a percentage (PPO).
    /// </remarks>
    private static RetCode TA_INT_PO(int startIdx, int endIdx, double[] inReal0, int optInFastPeriod0, int optInSlowPeriod1, MAType optInMethod2, ref int outBegIdx, ref int outNbElement, double[] outReal0, double[] tempBuffer, int doPercentageOutput)
    {
        int tempInteger = 0;
        int outBegIdx2 = 0;
        int outNbElement2 = 0;
            
        if (optInSlowPeriod1 < optInFastPeriod0)
        {
            tempInteger = optInSlowPeriod1;
            optInSlowPeriod1 = optInFastPeriod0;
            optInFastPeriod0 = tempInteger;
        }
            
        RetCode retCode = MovingAverage(startIdx, endIdx, inReal0, optInFastPeriod0, optInMethod2, ref outBegIdx2, ref outNbElement2, ref tempBuffer);
            
        if (retCode == Success)
        {
            int outNbElement1 = 0;
            int outBegIdx1 = 0;
            retCode = MovingAverage(startIdx, endIdx, inReal0, optInSlowPeriod1, optInMethod2, ref outBegIdx1, ref outNbElement1, ref outReal0);
                
            if (retCode == Success)
            {
                int i;
                int j;
                tempInteger = outBegIdx1 - outBegIdx2;
                    
                if (doPercentageOutput == 0)
                {
                    i = 0;
                    j = tempInteger;
                    while (i < outNbElement1)
                    {
                        outReal0[i] = tempBuffer[j] - outReal0[i];
                        i++;
                        j++;
                    }
                }
                else
                {
                    i = 0;
                    for (j = tempInteger; i < outNbElement1; j++)
                    {
                        double tempReal = outReal0[i];
                        outReal0[i] = (tempBuffer[j] - tempReal) / tempReal * 100.0;
                        i++;
                    }
                }
                outBegIdx = outBegIdx1;
                outNbElement = outNbElement1;
            }
        }
            
        if (retCode != Success)
        {
            outBegIdx = 0;
            outNbElement = 0;
        }
            
        return retCode;
    }
        
    /// <summary>
    /// Internal implementation of Simple Moving Average calculation.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="inReal0">Input array of values.</param>
    /// <param name="optInTimePeriod0">Number of periods for the moving average.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNbElement">The number of valid output elements.</param>
    /// <param name="outReal0">Output array for the SMA values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Calculates the arithmetic mean of the last n periods using a sliding window approach
    /// for efficient computation.
    /// </remarks>
    private static RetCode TA_INT_SMA(int startIdx, int endIdx, double[] inReal0, int optInTimePeriod0, ref int outBegIdx, ref int outNbElement, double[] outReal0)
    {
        int lookbackTotal = optInTimePeriod0 - 1;
            
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }
            
        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return Success;
        }
            
        double periodTotal = 0.0;
        int trailingIdx = startIdx - lookbackTotal;
        int i = trailingIdx;
            
        if (optInTimePeriod0 > 1)
        {
            while (i < startIdx)
            {
                periodTotal += inReal0[i];
                i++;
            }
        }
            
        int outIdx = 0;
            
        do
        {
            periodTotal += inReal0[i];
            i++;
            double tempReal = periodTotal;
            periodTotal -= inReal0[trailingIdx];
            trailingIdx++;
            outReal0[outIdx] = tempReal / optInTimePeriod0;
            outIdx++;
        }
        while (i <= endIdx);
            
        outNbElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }
        
    /// <summary>
    /// Internal method to calculate standard deviation using pre-calculated moving average values.
    /// </summary>
    /// <param name="inReal">Input array of values.</param>
    /// <param name="inMovAvg">Pre-calculated moving average values.</param>
    /// <param name="inMovAvgBegIdx">Starting index of the moving average array.</param>
    /// <param name="inMovAvgNbElement">Number of elements in the moving average array.</param>
    /// <param name="timePeriod">Period used for the moving average calculation.</param>
    /// <param name="output">Output array for the standard deviation values.</param>
    /// <remarks>
    /// This optimization calculates standard deviation more efficiently when the moving average
    /// has already been computed, avoiding redundant calculations.
    /// Uses the formula: StdDev = sqrt(E[X²] - E[X]²)
    /// </remarks>
    private static void TA_INT_stddev_using_precalc_ma(double[] inReal, double[] inMovAvg, int inMovAvgBegIdx, int inMovAvgNbElement, int timePeriod, double[] output)
    {
        double tempReal;
        int outIdx;
        int startSum = inMovAvgBegIdx + 1 - timePeriod;
        int endSum = inMovAvgBegIdx;
        double periodTotal2 = 0.0;
            
        for (outIdx = startSum; outIdx < endSum; outIdx++)
        {
            tempReal = inReal[outIdx];
            tempReal *= tempReal;
            periodTotal2 += tempReal;
        }
            
        outIdx = 0;
            
        while (outIdx < inMovAvgNbElement)
        {
            tempReal = inReal[endSum];
            tempReal *= tempReal;
            periodTotal2 += tempReal;
            double meanValue2 = periodTotal2 / timePeriod;
            tempReal = inReal[startSum];
            tempReal *= tempReal;
            periodTotal2 -= tempReal;
            tempReal = inMovAvg[outIdx];
            tempReal *= tempReal;
            meanValue2 -= tempReal;
            output[outIdx] = meanValue2 >= 1E-08 ? Math.Sqrt(meanValue2) : 0.0;
            outIdx++;
            startSum++;
            endSum++;
        }
    }
        
    /// <summary>
    /// Internal implementation of Variance calculation.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="inReal0">Input array of values.</param>
    /// <param name="optInTimePeriod0">Number of periods for the variance calculation.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNbElement">The number of valid output elements.</param>
    /// <param name="outReal0">Output array for the variance values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Calculates variance using the formula: Var = E[X²] - E[X]²
    /// This method uses a sliding window approach for efficient computation,
    /// maintaining running sums of values and squared values.
    /// </remarks>
    private static RetCode TA_INT_VAR(int startIdx, int endIdx, double[] inReal0, int optInTimePeriod0, ref int outBegIdx, ref int outNbElement, double[] outReal0)
    {
        double tempReal;
        int nbInitialElementNeeded = optInTimePeriod0 - 1;
            
        if (startIdx < nbInitialElementNeeded)
        {
            startIdx = nbInitialElementNeeded;
        }
            
        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNbElement = 0;
            return Success;
        }
            
        double periodTotal1 = 0.0;
        double periodTotal2 = 0.0;
        int trailingIdx = startIdx - nbInitialElementNeeded;
        int i = trailingIdx;
            
        if (optInTimePeriod0 > 1)
        {
            while (i < startIdx)
            {
                tempReal = inReal0[i];
                i++;
                periodTotal1 += tempReal;
                tempReal *= tempReal;
                periodTotal2 += tempReal;
            }
        }
            
        int outIdx = 0;
            
        do
        {
            tempReal = inReal0[i];
            i++;
            periodTotal1 += tempReal;
            tempReal *= tempReal;
            periodTotal2 += tempReal;
            double meanValue1 = periodTotal1 / optInTimePeriod0;
            double meanValue2 = periodTotal2 / optInTimePeriod0;
            tempReal = inReal0[trailingIdx];
            trailingIdx++;
            periodTotal1 -= tempReal;
            tempReal *= tempReal;
            periodTotal2 -= tempReal;
            outReal0[outIdx] = meanValue2 - (meanValue1 * meanValue1);
            outIdx++;
        }
        while (i <= endIdx);
            
        outNbElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Internal implementation for finding the index of extreme values (min or max) over a rolling window.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="inReal">Input array of values.</param>
    /// <param name="optInTimePeriod">The period for the rolling window.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outInteger">Output array for the indices of extreme values.</param>
    /// <param name="comparer">Comparison function: returns true if first value is more extreme than second.</param>
    /// <param name="comparerOrEqual">Comparison function with equality: returns true if first value is more extreme or equal to second.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// This method implements an efficient trailing window algorithm to find the index
    /// of extreme values (minimum or maximum) within a rolling period.
    /// The comparer functions determine whether to find minimum or maximum values.
    /// </remarks>
    private static RetCode TA_INT_ExtremeIndex(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref int[] outInteger,
        Func<double, double, bool> comparer,
        Func<double, double, bool> comparerOrEqual)
    {
        double[]? inRealLocal = inReal;
        int optInTimePeriodLocal = optInTimePeriod;
        int[]? outIntegerLocal = outInteger;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => inRealLocal == null! || outIntegerLocal == null! ? BadParam : Success,
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriodLocal)
        );
        if (validation != Success)
        {
            return validation;
        }

        int nbInitialElementNeeded = optInTimePeriod - 1;
        if (startIdx < nbInitialElementNeeded)
        {
            startIdx = nbInitialElementNeeded;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outIdx = 0;
        int today = startIdx;
        int trailingIdx = startIdx - nbInitialElementNeeded;
        int extremeIdx = -1;
        double extreme = 0.0;

        while (today <= endIdx)
        {
            double tmp = inReal[today];
            if (extremeIdx < trailingIdx)
            {
                extremeIdx = trailingIdx;
                extreme = inReal[extremeIdx];
                int i = extremeIdx;
                while (i <= today)
                {
                    tmp = inReal[i];
                    if (comparer(tmp, extreme))
                    {
                        extremeIdx = i;
                        extreme = tmp;
                    }
                    i++;
                }
            }
            else if (comparerOrEqual(tmp, extreme))
            {
                extremeIdx = today;
                extreme = tmp;
            }

            outInteger[outIdx] = extremeIdx;
            outIdx++;
            trailingIdx++;
            today++;
        }

        outBegIdx = startIdx;
        outNBElement = outIdx;
        return Success;
    }
}
