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
    /// Calculates the Normalized Average True Range (NATR) indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of closing prices.</param>
    /// <param name="timePeriod">The number of periods for the average (default: 14).</param>
    /// <returns>A NatrResult object containing the calculated values.</returns>
    /// <remarks>
    /// NATR is the Average True Range (ATR) normalized as a percentage of the closing price.
    /// This normalization allows for better comparison of volatility across different price levels and instruments.
    /// The formula is: NATR = (ATR / Close) * 100
    /// This indicator is useful for position sizing and comparing volatility between different securities
    /// regardless of their price levels.
    /// </remarks>
    public static NatrResult Natr(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod = 14)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Natr(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new NatrResult(retCode, outBegIdx, outNBElement, outReal);
    }
        
    /// <summary>
    /// Calculates the Normalized Average True Range (NATR) indicator using the default time period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of closing prices.</param>
    /// <returns>A NatrResult object containing the calculated values.</returns>
    /// <remarks>Uses the default time period of 14.</remarks>
    public static NatrResult Natr(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod = 14)
        => TAMathHelper.Execute(startIdx, endIdx, high, low, close, (s, e, h, l, c) => Natr(s, e, h, l, c, timePeriod));
}
