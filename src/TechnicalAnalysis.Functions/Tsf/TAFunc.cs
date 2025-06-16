// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Time Series Forecast (TSF) - a linear regression indicator that projects the regression line forward.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the linear regression. Typical values: 14, 20.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the TSF values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// TSF fits a linear regression line through the specified number of price points
    /// and then projects that line forward by one period. This creates a forecast
    /// of where prices might be if the current trend continues.
    /// 
    /// Calculation:
    /// 1. Calculate linear regression line: y = mx + b
    /// 2. Project forward: TSF = b + m * (period + 1)
    /// 
    /// Key characteristics:
    /// - Acts as a moving average with predictive capabilities
    /// - Smooths price data while maintaining trend direction
    /// - Less lag than traditional moving averages
    /// - Provides one-period-ahead price forecast
    /// 
    /// Trading applications:
    /// - Trend identification: Price above TSF = uptrend
    /// - Support/resistance: TSF acts as dynamic support/resistance
    /// - Crossover signals: Price crossing TSF indicates trend changes
    /// - Divergence analysis: TSF diverging from price suggests weakness
    /// 
    /// Advantages:
    /// - Forward-looking indicator
    /// - Smooth trend representation
    /// - Adapts quickly to trend changes
    /// 
    /// Best combined with momentum indicators for confirmation.
    /// </remarks>
    public static RetCode Tsf(
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

        int lookbackTotal = TsfLookback(optInTimePeriod);
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

        int outIdx = 0;
        int today = startIdx;
        double sumX = optInTimePeriod * (optInTimePeriod - 1) * 0.5;
        double sumXSqr = (double)(optInTimePeriod * (optInTimePeriod - 1) * ((optInTimePeriod * 2) - 1)) / 6;
        double divisor = (sumX * sumX) - (optInTimePeriod * sumXSqr);
        while (true)
        {
            if (today > endIdx)
            {
                outBegIdx = startIdx;
                outNBElement = outIdx;
                return Success;
            }

            double sumXY = 0.0;
            double sumY = 0.0;
            int i = optInTimePeriod;
            while (true)
            {
                i--;
                if (i == 0)
                {
                    break;
                }

                double tempValue1 = inReal[today - i];
                sumY += tempValue1;
                sumXY += i * tempValue1;
            }

            double m = ((optInTimePeriod * sumXY) - (sumX * sumY)) / divisor;
            double b = (sumY - (m * sumX)) / optInTimePeriod;
            outReal[outIdx] = b + (m * optInTimePeriod);
            outIdx++;
            today++;
        }
    }

    /// <summary>
    /// Returns the lookback period required for TSF calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the linear regression. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid TSF value can be calculated, or -1 if parameters are invalid.</returns>
    public static int TsfLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
