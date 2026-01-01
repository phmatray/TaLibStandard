// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Linear Regression Angle - the angle of a linear regression line over a specified period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of prices (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the linear regression calculation. Typical value: 14.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the linear regression angle values in degrees.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Linear Regression Angle measures the angle of the linear regression line in degrees,
    /// providing a visual representation of the trend's steepness and direction.
    /// 
    /// Mathematical basis:
    /// - Calculates the slope (m) of the linear regression line using least squares method
    /// - Converts slope to angle: angle = arctan(m) × (180/π)
    /// - Output is in degrees: positive for uptrend, negative for downtrend
    /// - Range: typically between -90 and +90 degrees
    /// 
    /// Key characteristics:
    /// - Quantifies trend strength: steeper angles indicate stronger trends
    /// - Direction indicator: positive angles = uptrend, negative = downtrend
    /// - Normalized measure: angle representation is independent of price scale
    /// - More intuitive than slope values for visual interpretation
    /// 
    /// Trading applications:
    /// - Trend strength: Angles above 30° or below -30° suggest strong trends
    /// - Trend changes: Angle crossing zero indicates potential trend reversal
    /// - Momentum: Increasing angle suggests accelerating trend
    /// - Divergence: Price making new highs/lows while angle decreases
    /// - Filter: Only take trades when angle exceeds threshold (e.g., ±15°)
    /// 
    /// Note: The angle depends on the scaling of time vs. price. While the relative
    /// changes in angle are meaningful, the absolute angle values should be interpreted
    /// within the context of the specific market and timeframe.
    /// </remarks>
    public static RetCode LinearRegAngle(
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

        int lookbackTotal = LinearRegAngleLookback(optInTimePeriod);
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
            outReal[outIdx] = Math.Atan(m) * 57.295779513082323;
            outIdx++;
            today++;
        }
    }

    /// <summary>
    /// Returns the lookback period required for Linear Regression Angle calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the linear regression calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid Linear Regression Angle value can be calculated, or -1 if parameters are invalid.</returns>
    public static int LinearRegAngleLookback(int optInTimePeriod)
    {
        return ValidationHelper.ValidateLookback(optInTimePeriod, adjustment: -1);
    }
}
