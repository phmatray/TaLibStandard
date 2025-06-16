// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Linear Regression - the end point of a linear regression line over a specified period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of prices (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the linear regression calculation. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the linear regression values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Linear Regression calculates the projected value based on a least squares fit over the specified period.
    /// It represents where the price "should be" according to the linear trend.
    /// 
    /// Mathematical basis:
    /// - Uses least squares method to find the best-fitting straight line
    /// - Formula: y = mx + b (where m is slope, b is intercept)
    /// - Output is the y-value at the end of the regression line
    /// 
    /// Key characteristics:
    /// - Smoother than moving averages
    /// - Less lag than traditional moving averages
    /// - Projects the current trend forward
    /// - Adapts to the overall direction of prices
    /// 
    /// Trading applications:
    /// - Trend identification: Price above/below regression line
    /// - Support/Resistance: Acts as dynamic support in uptrends, resistance in downtrends
    /// - Reversal signals: Price diverging significantly from regression line
    /// - Entry/Exit points: When price crosses the regression line
    /// 
    /// The Linear Regression indicator is the foundation for other indicators like
    /// Linear Regression Slope, Linear Regression Angle, and Time Series Forecast.
    /// </remarks>
    public static RetCode LinearReg(
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

        int lookbackTotal = LinearRegLookback(optInTimePeriod);
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
            double b = (sumY - (m * sumX)) / optInTimePeriod;
            outReal[outIdx] = b + (m * (optInTimePeriod - 1));
            outIdx++;
            today++;
        }
    }

    /// <summary>
    /// Returns the lookback period required for Linear Regression calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the linear regression calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid Linear Regression value can be calculated, or -1 if parameters are invalid.</returns>
    public static int LinearRegLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
