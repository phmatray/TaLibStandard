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
    /// Calculates the Aroon indicator (Aroon Up and Aroon Down).
    /// </summary>
    /// <remarks>
    /// The Aroon indicator, developed by Tushar Chande in 1995, is used to identify trend changes and the 
    /// strength of a trend. It consists of two lines: Aroon Up and Aroon Down.
    /// 
    /// Aroon Up = ((Period - Days Since Period High) / Period) × 100
    /// Aroon Down = ((Period - Days Since Period Low) / Period) × 100
    /// 
    /// The indicator oscillates between 0 and 100:
    /// - Aroon Up near 100 indicates a strong upward trend
    /// - Aroon Down near 100 indicates a strong downward trend
    /// - Both lines near 50 indicate a consolidating market
    /// 
    /// Trading signals:
    /// - When Aroon Up crosses above Aroon Down, it may signal a new uptrend
    /// - When Aroon Down crosses above Aroon Up, it may signal a new downtrend
    /// - When both lines are below 50, it indicates a weak or absent trend
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="timePeriod">The lookback period for the calculation (default: 14).</param>
    /// <returns>An AroonResult object containing both Aroon Down and Aroon Up values.</returns>
    public static AroonResult Aroon(int startIdx, int endIdx, double[] high, double[] low, int timePeriod = 14)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outAroonDown = new double[endIdx - startIdx + 1];
        double[] outAroonUp = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Aroon(
            startIdx,
            endIdx,
            high,
            low,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outAroonDown,
            ref outAroonUp);
            
        return new AroonResult(retCode, outBegIdx, outNBElement, outAroonDown, outAroonUp);
    }

    /// <summary>
    /// Calculates the Aroon indicator using float arrays.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// See the double array overload for a detailed description of the Aroon indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="timePeriod">The lookback period for the calculation (default: 14).</param>
    /// <returns>An AroonResult object containing both Aroon Down and Aroon Up values.</returns>
    public static AroonResult Aroon(int startIdx, int endIdx, float[] high, float[] low, int timePeriod = 14)
        => TAMathHelper.Execute(startIdx, endIdx, high, low, (s, e, h, l) => Aroon(s, e, h, l, timePeriod));
}
