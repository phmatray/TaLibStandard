// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Exponential Moving Average (EMA) - a type of moving average that gives more weight to recent prices.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the EMA calculation. Typical values: 12, 26, 50, 200.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the EMA values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The Exponential Moving Average (EMA) is calculated using:
    /// EMA = (Price × Multiplier) + (Previous EMA × (1 - Multiplier))
    /// Where Multiplier = 2 / (Time Period + 1)
    /// 
    /// EMAs react more quickly to recent price changes than Simple Moving Averages (SMAs).
    /// Common uses:
    /// - Trend identification: Price above EMA suggests uptrend, below suggests downtrend
    /// - Dynamic support/resistance levels
    /// - Entry/exit signals when price crosses the EMA
    /// - Component of other indicators like MACD
    /// </remarks>
    public static RetCode Ema(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode validationResult = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal, optInTimePeriod);
        if (validationResult != Success)
        {
            return validationResult;
        }

        RetCode taIntEMA = TA_INT_EMA(
            startIdx,
            endIdx,
            inReal,
            optInTimePeriod,
            2.0 / (optInTimePeriod + 1),
            ref outBegIdx,
            ref outNBElement,
            outReal);

        return taIntEMA;
    }

    /// <summary>
    /// Returns the lookback period required for EMA calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the EMA calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid EMA value can be calculated, or -1 if parameters are invalid.</returns>
    public static int EmaLookback(int optInTimePeriod)
    {
        int validatedPeriod = ValidationHelper.ValidateLookbackPeriod(optInTimePeriod);
        return validatedPeriod == -1 ? -1 : validatedPeriod - 1 + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Ema];
    }
}
