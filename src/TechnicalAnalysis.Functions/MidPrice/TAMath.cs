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
    /// Calculates the midpoint price over a specified time period (MIDPRICE).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="timePeriod">The number of periods to look back for calculating the midprice.</param>
    /// <returns>A MidPriceResult containing the midprice values over each rolling window.</returns>
    /// <remarks>
    /// The MIDPRICE function calculates the midpoint between the highest high and lowest low within a moving window:
    /// (Highest High + Lowest Low) / 2. This indicator is commonly used in trading systems to identify the center
    /// of the price range and can help determine trend direction and support/resistance levels.
    /// </remarks>
    public static MidPriceResult MidPrice(int startIdx, int endIdx, double[] high, double[] low, int timePeriod = 14)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MidPrice(
            startIdx,
            endIdx,
            high,
            low,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new MidPriceResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the midpoint price over a specified time period (MIDPRICE) using default period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <returns>A MidPriceResult containing the midprice values over each rolling window.</returns>
    /// <remarks>
    /// This overload uses a default time period of 14.
    /// </remarks>
    public static MidPriceResult MidPrice(int startIdx, int endIdx, float[] high, float[] low, int timePeriod = 14)
        => TAMathHelper.Execute(startIdx, endIdx, high, low, (s, e, h, l) => MidPrice(s, e, h, l, timePeriod));
}
