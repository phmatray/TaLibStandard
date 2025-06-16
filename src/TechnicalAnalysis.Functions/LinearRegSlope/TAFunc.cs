// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Linear Regression Slope - the slope of a linear regression line over a specified period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of prices (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the linear regression slope calculation. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the linear regression slope values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Linear Regression Slope measures the slope of the linear regression line, indicating the rate of change
    /// in the trend. It quantifies how much the regression line rises or falls per unit of time.
    /// 
    /// Mathematical basis:
    /// - Uses least squares method to calculate the slope (m) in y = mx + b
    /// - Slope formula: m = (n*Σ(xy) - Σx*Σy) / (n*Σ(x²) - (Σx)²)
    /// - Positive values indicate upward trend, negative values indicate downward trend
    /// - The magnitude indicates the strength of the trend
    /// 
    /// Key characteristics:
    /// - Zero-centered oscillator (can be positive or negative)
    /// - Leading indicator that can signal trend changes early
    /// - More responsive than moving average based indicators
    /// - Smooths price action while maintaining sensitivity to changes
    /// 
    /// Trading applications:
    /// - Trend strength: Larger absolute values indicate stronger trends
    /// - Trend direction: Positive for uptrends, negative for downtrends
    /// - Divergence analysis: Price making new highs/lows while slope decreases
    /// - Momentum shifts: Slope crossing zero line signals potential trend reversal
    /// - Overbought/Oversold: Extreme slope values may indicate exhaustion
    /// 
    /// The Linear Regression Slope is often used with Linear Regression and Linear Regression Intercept
    /// to form a complete picture of the trend's characteristics. It can also be normalized or converted
    /// to angles for additional analytical perspectives.
    /// </remarks>
    public static RetCode LinearRegSlope(
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

        int lookbackTotal = LinearRegSlopeLookback(optInTimePeriod);
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

            outReal[outIdx] = ((optInTimePeriod * sumXY) - (sumX * sumY)) / divisor;
            outIdx++;
            today++;
        }
    }

    /// <summary>
    /// Returns the lookback period required for Linear Regression Slope calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the linear regression slope calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid Linear Regression Slope value can be calculated, or -1 if parameters are invalid.</returns>
    public static int LinearRegSlopeLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
