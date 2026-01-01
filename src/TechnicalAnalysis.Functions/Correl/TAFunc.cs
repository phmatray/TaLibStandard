// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Pearson Correlation Coefficient - a measure of linear correlation between two variables.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inReal0">Input array of first variable values (e.g., first security's prices).</param>
    /// <param name="inReal1">Input array of second variable values (e.g., second security's prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the correlation calculation. Typical value: 20.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the correlation coefficient values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Correlation measures the strength and direction of the linear relationship between two variables.
    /// 
    /// Values range from -1 to +1:
    /// - +1: Perfect positive correlation (variables move together)
    /// - 0: No linear correlation
    /// - -1: Perfect negative correlation (variables move inversely)
    /// 
    /// Interpretation:
    /// - 0.8 to 1.0: Very strong positive correlation
    /// - 0.6 to 0.8: Strong positive correlation
    /// - 0.4 to 0.6: Moderate positive correlation
    /// - 0.2 to 0.4: Weak positive correlation
    /// - -0.2 to 0.2: No or negligible correlation
    /// - -0.4 to -0.2: Weak negative correlation
    /// - -0.6 to -0.4: Moderate negative correlation
    /// - -0.8 to -0.6: Strong negative correlation
    /// - -1.0 to -0.8: Very strong negative correlation
    /// 
    /// Uses in trading:
    /// - Pairs trading: Finding highly correlated securities
    /// - Portfolio diversification: Selecting uncorrelated assets
    /// - Risk management: Understanding market relationships
    /// - Intermarket analysis: Studying cross-asset relationships
    /// 
    /// Note: Correlation does not imply causation.
    /// </remarks>
    public static RetCode Correl(
        int startIdx,
        int endIdx,
        in double[] inReal0,
        in double[] inReal1,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double y;
        double x;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inReal0, inReal1, outReal),
            () => ValidationHelper.ValidatePeriodRange(optInTimePeriod, 1)
        );
        if (validation != Success)
        {
            return validation;
        }

        int lookbackTotal = optInTimePeriod - 1;
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
        int trailingIdx = startIdx - lookbackTotal;
        double sumY2 = 0.0;
        double sumX2 = sumY2;
        double sumY = sumX2;
        double sumX = sumY;
        double sumXY = sumX;
        int today = trailingIdx;
        while (today <= startIdx)
        {
            x = inReal0[today];
            sumX += x;
            sumX2 += x * x;
            y = inReal1[today];
            sumXY += x * y;
            sumY += y;
            sumY2 += y * y;
            today++;
        }

        double trailingX = inReal0[trailingIdx];
        double trailingY = inReal1[trailingIdx];
        trailingIdx++;
        double tempReal = (sumX2 - (sumX * sumX / optInTimePeriod))
                          * (sumY2 - (sumY * sumY / optInTimePeriod));
        outReal[0] = tempReal >= 1E-08 ? (sumXY - (sumX * sumY / optInTimePeriod)) / Math.Sqrt(tempReal) : 0.0;

        int outIdx = 1;
        while (today <= endIdx)
        {
            sumX -= trailingX;
            sumX2 -= trailingX * trailingX;
            sumXY -= trailingX * trailingY;
            sumY -= trailingY;
            sumY2 -= trailingY * trailingY;
            x = inReal0[today];
            sumX += x;
            sumX2 += x * x;
            y = inReal1[today];
            today++;
            sumXY += x * y;
            sumY += y;
            sumY2 += y * y;
            trailingX = inReal0[trailingIdx];
            trailingY = inReal1[trailingIdx];
            trailingIdx++;
            tempReal = (sumX2 - (sumX * sumX / optInTimePeriod))
                       * (sumY2 - (sumY * sumY / optInTimePeriod));
            if (tempReal >= 1E-08)
            {
                outReal[outIdx] = (sumXY - (sumX * sumY / optInTimePeriod)) / Math.Sqrt(tempReal);
                outIdx++;
            }
            else
            {
                outReal[outIdx] = 0.0;
                outIdx++;
            }
        }

        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Correlation calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the correlation calculation. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid correlation value can be calculated, or -1 if parameters are invalid.</returns>
    public static int CorrelLookback(int optInTimePeriod)
    {
        return ValidationHelper.ValidateLookback(optInTimePeriod, adjustment: -1, minPeriod: 1);
    }
}
