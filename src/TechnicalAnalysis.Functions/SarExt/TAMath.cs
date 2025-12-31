// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Functions.Internal;

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Parabolic SAR Extended (SAREXT) indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="startValue">The starting value for the SAR (default: 0.0).</param>
    /// <param name="offsetOnReverse">The offset on reverse (default: 0.0).</param>
    /// <param name="accelerationInitLong">The initial acceleration for long positions (default: 0.02).</param>
    /// <param name="accelerationLong">The acceleration increment for long positions (default: 0.02).</param>
    /// <param name="accelerationMaxLong">The maximum acceleration for long positions (default: 0.2).</param>
    /// <param name="accelerationInitShort">The initial acceleration for short positions (default: 0.02).</param>
    /// <param name="accelerationShort">The acceleration increment for short positions (default: 0.02).</param>
    /// <param name="accelerationMaxShort">The maximum acceleration for short positions (default: 0.2).</param>
    /// <returns>A SarExtResult object containing the calculated values.</returns>
    /// <remarks>
    /// The Parabolic SAR Extended is an enhanced version of the standard Parabolic SAR that allows
    /// different acceleration parameters for long and short positions. This provides more flexibility
    /// in adapting the indicator to different market conditions and trading styles.
    /// The offset on reverse can be used to add a buffer when the SAR reverses direction.
    /// </remarks>
    public static SarExtResult SarExt(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double startValue = 0.0,
        double offsetOnReverse = 0.0,
        double accelerationInitLong = 0.02,
        double accelerationLong = 0.02,
        double accelerationMaxLong = 0.2,
        double accelerationInitShort = 0.02,
        double accelerationShort = 0.02,
        double accelerationMaxShort = 0.2)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.SarExt(
            startIdx,
            endIdx,
            high,
            low,
            startValue,
            offsetOnReverse,
            accelerationInitLong,
            accelerationLong,
            accelerationMaxLong,
            accelerationInitShort,
            accelerationShort,
            accelerationMaxShort,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new SarExtResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Parabolic SAR Extended (SAREXT) indicator using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="startValue">The starting value for the SAR (default: 0.0).</param>
    /// <param name="offsetOnReverse">The offset on reverse (default: 0.0).</param>
    /// <param name="accelerationInitLong">The initial acceleration for long positions (default: 0.02).</param>
    /// <param name="accelerationLong">The acceleration increment for long positions (default: 0.02).</param>
    /// <param name="accelerationMaxLong">The maximum acceleration for long positions (default: 0.2).</param>
    /// <param name="accelerationInitShort">The initial acceleration for short positions (default: 0.02).</param>
    /// <param name="accelerationShort">The acceleration increment for short positions (default: 0.02).</param>
    /// <param name="accelerationMaxShort">The maximum acceleration for short positions (default: 0.2).</param>
    /// <returns>A SarExtResult object containing the calculated values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before processing.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static SarExtResult SarExt(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        double startValue = 0.0,
        double offsetOnReverse = 0.0,
        double accelerationInitLong = 0.02,
        double accelerationLong = 0.02,
        double accelerationMaxLong = 0.2,
        double accelerationInitShort = 0.02,
        double accelerationShort = 0.02,
        double accelerationMaxShort = 0.2)
        => TAMathHelper.Execute(startIdx, endIdx, high, low, (s, e, h, l) =>
            SarExt(s, e, h, l, startValue, offsetOnReverse, accelerationInitLong, accelerationLong,
                   accelerationMaxLong, accelerationInitShort, accelerationShort, accelerationMaxShort));
}
