// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Fixed MACD indicator using the standard 12/26 period configuration.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="signalPeriod">The number of periods for the signal line EMA (default: 9).</param>
    /// <returns>A MacdFixResult containing the MACD line, signal line, and histogram values.</returns>
    /// <remarks>
    /// MACD Fix uses fixed fast period (12) and slow period (26) for the MACD calculation,
    /// only allowing customization of the signal line period. This maintains the traditional
    /// MACD configuration while providing some flexibility for the signal line smoothing.
    /// </remarks>
    public static MacdFixResult MacdFix(int startIdx, int endIdx, double[] real, int signalPeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outMACD = new double[endIdx - startIdx + 1];
        double[] outMACDSignal = new double[endIdx - startIdx + 1];
        double[] outMACDHist = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MacdFix(
            startIdx,
            endIdx,
            real,
            signalPeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outMACD,
            ref outMACDSignal,
            ref outMACDHist);
            
        return new MacdFixResult(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
    }

    /// <summary>
    /// Calculates the Fixed MACD indicator using default signal period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <returns>A MacdFixResult containing the MACD line, signal line, and histogram values.</returns>
    /// <remarks>
    /// Uses fixed values: fastPeriod=12, slowPeriod=26, signalPeriod=9.
    /// </remarks>
    public static MacdFixResult MacdFix(int startIdx, int endIdx, double[] real)
        => MacdFix(startIdx, endIdx, real, 9);

    /// <summary>
    /// Calculates the Fixed MACD indicator using the standard 12/26 period configuration.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="signalPeriod">The number of periods for the signal line EMA.</param>
    /// <returns>A MacdFixResult containing the MACD line, signal line, and histogram values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// </remarks>
    public static MacdFixResult MacdFix(int startIdx, int endIdx, float[] real, int signalPeriod)
        => MacdFix(startIdx, endIdx, real.ToDouble(), signalPeriod);
        
    /// <summary>
    /// Calculates the Fixed MACD indicator using default signal period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <returns>A MacdFixResult containing the MACD line, signal line, and histogram values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// Uses fixed values: fastPeriod=12, slowPeriod=26, signalPeriod=9.
    /// </remarks>
    public static MacdFixResult MacdFix(int startIdx, int endIdx, float[] real)
        => MacdFix(startIdx, endIdx, real, 9);
}
