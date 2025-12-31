// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Commodity Channel Index (CCI) indicator.
    /// </summary>
    /// <remarks>
    /// The Commodity Channel Index (CCI) is a momentum-based oscillator used to help determine when an investment 
    /// vehicle is reaching a condition of being overbought or oversold. Developed by Donald Lambert, this technical 
    /// indicator assesses price trend direction and strength, allowing traders to determine if they want to enter 
    /// or exit a trade, refrain from taking a trade, or add to an existing position.
    /// 
    /// The CCI is calculated as:
    /// CCI = (Typical Price - SMA of Typical Price) / (0.015 × Mean Deviation)
    /// Where Typical Price = (High + Low + Close) / 3
    /// 
    /// CCI values above +100 indicate an overbought condition, while values below -100 indicate an oversold condition.
    /// The indicator can also be used to identify divergences and trend reversals.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation (default: 14).</param>
    /// <returns>A CciResult object containing the calculated CCI values.</returns>
    public static CciResult Cci(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Cci(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new CciResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Commodity Channel Index (CCI) indicator with default period.
    /// </summary>
    /// <remarks>
    /// This overload uses a default time period of 14.
    /// See the main overload for a detailed description of the CCI indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A CciResult object containing the calculated CCI values.</returns>
    public static CciResult Cci(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => Cci(startIdx, endIdx, high, low, close, 14);

    /// <summary>
    /// Calculates the Commodity Channel Index (CCI) indicator using float arrays.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// See the double array overload for a detailed description of the CCI indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="timePeriod">The number of periods to use in the calculation.</param>
    /// <returns>A CciResult object containing the calculated CCI values.</returns>
    public static CciResult Cci(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
        => Cci(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);

    /// <summary>
    /// Calculates the Commodity Channel Index (CCI) indicator using float arrays with default period.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// Uses a default time period of 14.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A CciResult object containing the calculated CCI values.</returns>
    public static CciResult Cci(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => Cci(startIdx, endIdx, high, low, close, 14);
}
