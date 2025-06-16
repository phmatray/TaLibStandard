// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Linear Regression Angle (LINEARREG_ANGLE) indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods for the linear regression (default: 14).</param>
    /// <returns>A LinearRegAngleResult object containing the calculated angle values in degrees.</returns>
    /// <remarks>
    /// The Linear Regression Angle indicator calculates the angle of the linear regression line
    /// over the specified period. The angle is expressed in degrees and represents the slope of the trend.
    /// Positive angles indicate an uptrend, while negative angles indicate a downtrend.
    /// The steeper the angle, the stronger the trend. This indicator can be used to quantify
    /// trend strength and identify potential trend changes when the angle crosses through zero.
    /// </remarks>
    public static LinearRegAngleResult LinearRegAngle(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.LinearRegAngle(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new LinearRegAngleResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Linear Regression Angle (LINEARREG_ANGLE) indicator using the default time period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <returns>A LinearRegAngleResult object containing the calculated angle values in degrees.</returns>
    /// <remarks>Uses the default time period of 14.</remarks>
    public static LinearRegAngleResult LinearRegAngle(int startIdx, int endIdx, double[] real)
        => LinearRegAngle(startIdx, endIdx, real, 14);

    /// <summary>
    /// Calculates the Linear Regression Angle (LINEARREG_ANGLE) indicator using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <param name="timePeriod">The number of periods for the linear regression.</param>
    /// <returns>A LinearRegAngleResult object containing the calculated angle values in degrees.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before processing.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static LinearRegAngleResult LinearRegAngle(int startIdx, int endIdx, float[] real, int timePeriod)
        => LinearRegAngle(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Linear Regression Angle (LINEARREG_ANGLE) indicator using float arrays and the default time period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">An array of real values (typically closing prices).</param>
    /// <returns>A LinearRegAngleResult object containing the calculated angle values in degrees.</returns>
    /// <remarks>
    /// Uses the default time period of 14. This overload accepts float arrays and converts them to double arrays.
    /// </remarks>
    public static LinearRegAngleResult LinearRegAngle(int startIdx, int endIdx, float[] real)
        => LinearRegAngle(startIdx, endIdx, real, 14);
}
