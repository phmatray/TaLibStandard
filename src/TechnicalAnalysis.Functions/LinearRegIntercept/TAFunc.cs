// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Linear Regression Intercept - the y-intercept value of a linear regression line over a specified period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of prices (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the linear regression calculation. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the linear regression intercept values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Linear Regression Intercept calculates the y-intercept (b) of the linear regression line,
    /// which represents where the regression line would cross the y-axis if extended backwards.
    /// 
    /// Mathematical basis:
    /// - Uses least squares method to find the best-fitting line: y = mx + b
    /// - Intercept (b) = (Σy - m×Σx) / n
    /// - Where m is the slope and n is the number of periods
    /// - The intercept represents the theoretical price when x=0
    /// 
    /// Key characteristics:
    /// - Provides the baseline value of the linear regression equation
    /// - Changes as new data points are added and old ones are removed
    /// - Used in conjunction with slope to define the complete regression line
    /// - Can indicate the overall price level adjusted for trend
    /// 
    /// Trading applications:
    /// - Support/Resistance levels: Intercept can act as a dynamic support/resistance
    /// - Trend channels: Used with slope to construct regression channels
    /// - Mean reversion: Large deviations from intercept may signal overbought/oversold
    /// - Forecasting: Combined with slope for price projections
    /// - Relative value: Compare current price to intercept for over/undervaluation
    /// 
    /// The Linear Regression Intercept is often used together with Linear Regression Slope
    /// to fully define the regression line equation for forecasting and analysis.
    /// </remarks>
    public static RetCode LinearRegIntercept(
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

        int lookbackTotal = LinearRegInterceptLookback(optInTimePeriod);
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
        double sumXSqr = (double)optInTimePeriod * (optInTimePeriod - 1) * ((optInTimePeriod * 2) - 1) / 6;
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
            outReal[outIdx] = (sumY - (m * sumX)) / optInTimePeriod;
            outIdx++;
            today++;
        }
    }

    /// <summary>
    /// Returns the lookback period required for Linear Regression Intercept calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the linear regression calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid Linear Regression Intercept value can be calculated, or -1 if parameters are invalid.</returns>
    public static int LinearRegInterceptLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
