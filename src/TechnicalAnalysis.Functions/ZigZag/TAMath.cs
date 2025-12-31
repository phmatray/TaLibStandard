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
    /// Calculates the ZigZag indicator which filters out minor price movements to identify significant trends.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="deviation">The minimum percentage deviation required to form a new ZigZag line (default: 5.0).</param>
    /// <returns>A ZigZagResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The ZigZag indicator is used to filter out market noise and identify significant price movements.
    /// It connects significant tops and bottoms in the price data, ignoring smaller movements that don't
    /// meet the specified deviation threshold. The indicator is primarily used to identify chart patterns
    /// and for Elliott Wave analysis. Note that ZigZag repaints - the last leg may change as new data
    /// comes in, making it unsuitable for real-time trading signals.
    /// </remarks>
    public static ZigZagResult ZigZag(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double deviation = 5.0)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outZigZag = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.ZigZag(
            startIdx,
            endIdx,
            high,
            low,
            deviation,
            ref outBegIdx,
            ref outNBElement,
            ref outZigZag);
            
        return new ZigZagResult(retCode, outBegIdx, outNBElement, outZigZag);
    }

    /// <summary>
    /// Calculates the ZigZag indicator using a default deviation of 5.0%.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <returns>A ZigZagResult object containing the calculated values and metadata.</returns>
    public static ZigZagResult ZigZag(int startIdx, int endIdx, float[] high, float[] low, double deviation = 5.0)
        => TAMathHelper.Execute(startIdx, endIdx, high, low, (s, e, h, l) => ZigZag(s, e, h, l, deviation));
}
