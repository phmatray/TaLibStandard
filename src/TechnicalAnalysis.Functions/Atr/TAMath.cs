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
    /// Calculates the Average True Range (ATR) indicator.
    /// </summary>
    /// <remarks>
    /// The Average True Range (ATR) is a technical analysis indicator that measures market volatility by decomposing 
    /// the entire range of an asset price for that period. Developed by J. Welles Wilder, the ATR indicator measures 
    /// volatility, taking into account any gaps in the price movement.
    /// 
    /// The true range is the greatest of:
    /// - Current high minus current low
    /// - Absolute value of current high minus previous close
    /// - Absolute value of current low minus previous close
    /// 
    /// The ATR is then calculated as a moving average (typically 14-period) of the true range values. Higher ATR 
    /// values indicate higher volatility, while lower values indicate lower volatility. ATR does not indicate 
    /// price direction, only volatility.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="timePeriod">The number of periods to average (default: 14).</param>
    /// <returns>An AtrResult object containing the calculated ATR values.</returns>
    public static AtrResult Atr(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod = 14)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Atr(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);

        return new AtrResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Average True Range (ATR) indicator using float arrays.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// See the double array overload for a detailed description of the ATR indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="timePeriod">The number of periods to average (default: 14).</param>
    /// <returns>An AtrResult object containing the calculated ATR values.</returns>
    public static AtrResult Atr(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod = 14)
        => TAMathHelper.Execute(startIdx, endIdx, high, low, close, (s, e, h, l, c) => Atr(s, e, h, l, c, timePeriod));
}
