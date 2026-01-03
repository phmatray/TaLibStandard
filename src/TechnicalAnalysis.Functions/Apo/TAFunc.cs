// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Absolute Price Oscillator (APO) - a momentum indicator that displays the difference between two moving averages.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInFastPeriod">Number of periods for the fast moving average. Typical value: 12.</param>
    /// <param name="optInSlowPeriod">Number of periods for the slow moving average. Typical value: 26.</param>
    /// <param name="optInMAType">Type of moving average to use (SMA, EMA, etc.). Default: EMA.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the APO values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// APO measures the difference between two moving averages of different periods.
    /// 
    /// Calculation:
    /// APO = Fast Moving Average - Slow Moving Average
    /// 
    /// Interpretation:
    /// - Positive APO: Fast MA is above Slow MA (bullish momentum)
    /// - Negative APO: Fast MA is below Slow MA (bearish momentum)
    /// - Zero line crossovers signal potential trend changes
    /// - Increasing APO indicates strengthening momentum
    /// - Decreasing APO indicates weakening momentum
    /// 
    /// Unlike the Percentage Price Oscillator (PPO), APO shows absolute price differences,
    /// making it more suitable for comparing momentum in the same security over time.
    /// </remarks>
    public static RetCode Apo(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInFastPeriod,
        in int optInSlowPeriod,
        in MAType optInMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        var inRealLocal = inReal;
        var outRealLocal = outReal;
        var optInFastPeriodLocal = optInFastPeriod;
        var optInSlowPeriodLocal = optInSlowPeriod;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inRealLocal, outRealLocal),
            () => ValidationHelper.ValidatePeriodRange(optInFastPeriodLocal),
            () => ValidationHelper.ValidatePeriodRange(optInSlowPeriodLocal)
        );
        if (validation != Success)
        {
            return validation;
        }

        double[] tempBuffer = new double[endIdx - startIdx + 1];

        return TA_INT_PO(
            startIdx,
            endIdx,
            inReal,
            optInFastPeriod,
            optInSlowPeriod,
            optInMAType,
            ref outBegIdx,
            ref outNBElement,
            outReal,
            tempBuffer,
            0);
    }

    /// <summary>
    /// Returns the lookback period required for APO calculation.
    /// </summary>
    /// <param name="optInFastPeriod">Number of periods for the fast moving average. Valid range: 2 to 100000.</param>
    /// <param name="optInSlowPeriod">Number of periods for the slow moving average. Valid range: 2 to 100000.</param>
    /// <param name="optInMAType">Type of moving average to use.</param>
    /// <returns>The number of historical data points required before the first valid APO value can be calculated, or -1 if parameters are invalid.</returns>
    public static int ApoLookback(int optInFastPeriod, int optInSlowPeriod, MAType optInMAType)
    {
        return optInFastPeriod is < 2 or > 100000 || optInSlowPeriod is < 2 or > 100000
            ? -1
            : MovingAverageLookback(
                optInSlowPeriod <= optInFastPeriod ? optInFastPeriod : optInSlowPeriod,
                optInMAType);
    }
}
