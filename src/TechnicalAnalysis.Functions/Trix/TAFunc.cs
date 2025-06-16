// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the TRIX indicator - a triple exponentially smoothed momentum oscillator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the EMA calculations. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the TRIX values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// TRIX is calculated by:
    /// 1. Applying EMA three times (triple exponential smoothing)
    /// 2. Calculating the 1-period rate of change of the triple EMA
    /// 
    /// The triple smoothing filters out insignificant price movements and market noise,
    /// making TRIX excellent for identifying significant trend changes.
    /// 
    /// Key characteristics:
    /// - Values oscillate around zero
    /// - Positive values indicate upward momentum
    /// - Negative values indicate downward momentum
    /// - Zero line crossovers signal trend changes
    /// 
    /// Trading signals:
    /// - TRIX crossing above zero: Buy signal
    /// - TRIX crossing below zero: Sell signal
    /// - Divergences with price: Potential reversals
    /// - Signal line crossovers (9-period EMA of TRIX)
    /// 
    /// Advantages:
    /// - Excellent filter for market noise
    /// - Leading indicator for trend changes
    /// - Minimal lag despite triple smoothing
    /// 
    /// Best used for medium to long-term trend identification.
    /// </remarks>
    public static RetCode Trix(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int nbElement = 0;
        int begIdx = 0;
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

        if (optInTimePeriod is < 1 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        int emaLookback = EmaLookback(optInTimePeriod);
        int rocLookback = RocRLookback(1);
        int totalLookback = (emaLookback * 3) + rocLookback;
        if (startIdx < totalLookback)
        {
            startIdx = totalLookback;
        }

        if (startIdx > endIdx)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return Success;
        }

        outBegIdx = startIdx;
        int nbElementToOutput = endIdx - startIdx + 1 + totalLookback;
        double[] tempBuffer = new double[nbElementToOutput];

        double k = 2.0 / (optInTimePeriod + 1);
        RetCode retCode = TA_INT_EMA(
            startIdx - totalLookback,
            endIdx,
            inReal,
            optInTimePeriod,
            k,
            ref begIdx,
            ref nbElement,
            tempBuffer);
        if (retCode != Success || nbElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        nbElementToOutput--;
        nbElementToOutput -= emaLookback;
        retCode = TA_INT_EMA(
            0,
            nbElementToOutput,
            tempBuffer,
            optInTimePeriod,
            k,
            ref begIdx,
            ref nbElement,
            tempBuffer);
        if (retCode != Success || nbElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        nbElementToOutput -= emaLookback;
        retCode = TA_INT_EMA(
            0,
            nbElementToOutput,
            tempBuffer,
            optInTimePeriod,
            k,
            ref begIdx,
            ref nbElement,
            tempBuffer);
        if (retCode != Success || nbElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        nbElementToOutput -= emaLookback;
        retCode = Roc(0, nbElementToOutput, tempBuffer, 1, ref begIdx, ref outNBElement, ref outReal);
            
        if (retCode != Success || outNBElement == 0)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return retCode;
        }

        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for TRIX calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the EMA calculations. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid TRIX value can be calculated, or -1 if parameters are invalid.</returns>
    public static int TrixLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 1 or > 100000 ? -1 : (EmaLookback(optInTimePeriod) * 3) + RocRLookback(1);
    }
}
