// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the True Range (TRANGE) indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of closing prices.</param>
    /// <returns>A TrueRangeResult object containing the calculated values.</returns>
    /// <remarks>
    /// True Range is the greatest of the following:
    /// - Current high minus current low
    /// - Absolute value of current high minus previous close
    /// - Absolute value of current low minus previous close
    /// 
    /// True Range captures volatility from gaps and limit moves. It is a component of the Average True Range (ATR) indicator.
    /// Unlike the traditional range calculation, True Range accounts for gaps between trading sessions.
    /// </remarks>
    public static TrueRangeResult TrueRange(int startIdx, int endIdx, double[] high, double[] low, double[] close)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.TrueRange(
            startIdx,
            endIdx,
            high,
            low,
            close,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new TrueRangeResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the True Range (TRANGE) indicator using float arrays.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of closing prices.</param>
    /// <returns>A TrueRangeResult object containing the calculated values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays before processing.
    /// This may result in a minor performance overhead due to the conversion process.
    /// </remarks>
    public static TrueRangeResult TrueRange(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => TrueRange(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble());
}
