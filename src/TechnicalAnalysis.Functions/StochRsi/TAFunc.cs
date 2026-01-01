// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Stochastic RSI - applies stochastic oscillator formula to RSI values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of prices (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for RSI calculation. Typical value: 14.</param>
    /// <param name="optInFastKPeriod">Number of periods for Stochastic %K. Typical value: 14.</param>
    /// <param name="optInFastDPeriod">Number of periods for Stochastic %D smoothing. Typical value: 3.</param>
    /// <param name="optInFastDMAType">Moving average type for %D line smoothing.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outFastK">Output array for the Stochastic RSI %K values.</param>
    /// <param name="outFastD">Output array for the Stochastic RSI %D values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Stochastic RSI combines two popular indicators to create a more sensitive momentum oscillator.
    /// It measures where RSI is relative to its high/low range over a set period.
    /// 
    /// Calculation:
    /// 1. Calculate RSI for the specified period
    /// 2. Apply Stochastic formula to RSI values:
    ///    StochRSI = (RSI - Lowest RSI) / (Highest RSI - Lowest RSI) * 100
    /// 3. Smooth the result to get %K and %D lines
    /// 
    /// Values range from 0 to 100:
    /// - Above 80: Overbought condition
    /// - Below 20: Oversold condition
    /// - 50: Neutral level
    /// 
    /// Trading signals:
    /// - %K crossing above %D in oversold zone: Buy signal
    /// - %K crossing below %D in overbought zone: Sell signal
    /// - Divergences with price: Potential reversals
    /// - Centerline (50) crossovers: Trend changes
    /// 
    /// Advantages over standard RSI:
    /// - More sensitive to price changes
    /// - Generates more trading signals
    /// - Better for identifying short-term turning points
    /// 
    /// Best used in conjunction with trend analysis to filter signals.
    /// </remarks>
    public static RetCode StochRsi(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        in int optInFastKPeriod,
        in int optInFastDPeriod,
        in MAType optInFastDMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outFastK,
        ref double[] outFastD)
    {
        int outNbElement1 = 0;
        int outBegIdx2 = 0;
        int outBegIdx1 = 0;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inReal, outFastK, outFastD),
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriod),
            () => ValidationHelper.ValidatePeriodRange(optInFastKPeriod, 1),
            () => ValidationHelper.ValidatePeriodRange(optInFastDPeriod, 1)
        );
        if (validation != Success)
        {
            return validation;
        }

        outNBElement = 0;
        int lookbackStochF = StochFLookback(optInFastKPeriod, optInFastDPeriod, optInFastDMAType);
        int lookbackTotal = RsiLookback(optInTimePeriod) + lookbackStochF;
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

        outBegIdx = startIdx;
        int tempArraySize = endIdx - startIdx + 1 + lookbackStochF;
        double[] tempRSIBuffer = new double[tempArraySize];
        RetCode retCode = Rsi(
            startIdx - lookbackStochF,
            endIdx,
            inReal,
            optInTimePeriod,
            ref outBegIdx1,
            ref outNbElement1,
            ref tempRSIBuffer);
            
        if (retCode != Success || outNbElement1 == 0)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        retCode = StochF(
            0,
            tempArraySize - 1,
            tempRSIBuffer,
            tempRSIBuffer,
            tempRSIBuffer,
            optInFastKPeriod,
            optInFastDPeriod,
            optInFastDMAType,
            ref outBegIdx2,
            ref outNBElement,
            ref outFastK,
            ref outFastD);
            
        if (retCode != Success || outNBElement == 0)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Stochastic RSI calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for RSI calculation. Valid range: 2 to 100000.</param>
    /// <param name="optInFastKPeriod">Number of periods for Stochastic %K. Valid range: 1 to 100000.</param>
    /// <param name="optInFastDPeriod">Number of periods for Stochastic %D smoothing. Valid range: 1 to 100000.</param>
    /// <param name="optInFastDMAType">Moving average type for %D line smoothing.</param>
    /// <returns>The number of historical data points required before the first valid StochRSI value can be calculated, or -1 if parameters are invalid.</returns>
    public static int StochRsiLookback(
        int optInTimePeriod,
        int optInFastKPeriod,
        int optInFastDPeriod,
        MAType optInFastDMAType)
    {
        return optInTimePeriod is < 2 or > 100000 ||
               optInFastKPeriod is < 1 or > 100000 ||
               optInFastDPeriod is < 1 or > 100000
            ? -1
            : RsiLookback(optInTimePeriod) + StochFLookback(
                optInFastKPeriod,
                optInFastDPeriod,
                optInFastDMAType);
    }
}
