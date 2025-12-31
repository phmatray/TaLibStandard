// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Extended MACD (MACD with controllable MA type) indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="fastPeriod">The number of periods for the fast moving average (default: 12).</param>
    /// <param name="fastMAType">The type of moving average to use for the fast MA (default: Simple MA).</param>
    /// <param name="slowPeriod">The number of periods for the slow moving average (default: 26).</param>
    /// <param name="slowMAType">The type of moving average to use for the slow MA (default: Simple MA).</param>
    /// <param name="signalPeriod">The number of periods for the signal line (default: 9).</param>
    /// <param name="signalMAType">The type of moving average to use for the signal line (default: Simple MA).</param>
    /// <returns>A MacdExtResult containing the MACD line, signal line, and histogram values.</returns>
    /// <remarks>
    /// MACD Extended allows you to specify the type of moving average for each component,
    /// providing more flexibility than the standard MACD which uses only exponential moving averages.
    /// This can be useful for fine-tuning the indicator's responsiveness to price changes.
    /// </remarks>
    public static MacdExtResult MacdExt(
        int startIdx,
        int endIdx,
        double[] real,
        int fastPeriod,
        MAType fastMAType,
        int slowPeriod,
        MAType slowMAType,
        int signalPeriod,
        MAType signalMAType)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outMACD = new double[endIdx - startIdx + 1];
        double[] outMACDSignal = new double[endIdx - startIdx + 1];
        double[] outMACDHist = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MacdExt(
            startIdx,
            endIdx,
            real,
            fastPeriod,
            fastMAType,
            slowPeriod,
            slowMAType,
            signalPeriod,
            signalMAType,
            ref outBegIdx,
            ref outNBElement,
            ref outMACD,
            ref outMACDSignal,
            ref outMACDHist);
            
        return new MacdExtResult(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
    }
        
    /// <summary>
    /// Calculates the Extended MACD using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <returns>A MacdExtResult containing the MACD line, signal line, and histogram values.</returns>
    /// <remarks>
    /// Uses default values: fastPeriod=12, slowPeriod=26, signalPeriod=9, all with Simple Moving Average.
    /// </remarks>
    public static MacdExtResult MacdExt(int startIdx, int endIdx, double[] real)
        => MacdExt(startIdx, endIdx, real, 12, MAType.Sma, 26, MAType.Sma, 9, MAType.Sma);

    /// <summary>
    /// Calculates the Extended MACD (MACD with controllable MA type) indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="fastPeriod">The number of periods for the fast moving average.</param>
    /// <param name="fastMAType">The type of moving average to use for the fast MA.</param>
    /// <param name="slowPeriod">The number of periods for the slow moving average.</param>
    /// <param name="slowMAType">The type of moving average to use for the slow MA.</param>
    /// <param name="signalPeriod">The number of periods for the signal line.</param>
    /// <param name="signalMAType">The type of moving average to use for the signal line.</param>
    /// <returns>A MacdExtResult containing the MACD line, signal line, and histogram values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// </remarks>
    public static MacdExtResult MacdExt(
        int startIdx,
        int endIdx,
        float[] real,
        int fastPeriod,
        MAType fastMAType,
        int slowPeriod,
        MAType slowMAType,
        int signalPeriod,
        MAType signalMAType)
        => MacdExt(
            startIdx,
            endIdx,
            real.ToDouble(),
            fastPeriod,
            fastMAType,
            slowPeriod,
            slowMAType,
            signalPeriod,
            signalMAType);
        
    /// <summary>
    /// Calculates the Extended MACD using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <returns>A MacdExtResult containing the MACD line, signal line, and histogram values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// Uses default values: fastPeriod=12, slowPeriod=26, signalPeriod=9, all with Simple Moving Average.
    /// </remarks>
    public static MacdExtResult MacdExt(int startIdx, int endIdx, float[] real)
        => MacdExt(startIdx, endIdx, real, 12, MAType.Sma, 26, MAType.Sma, 9, MAType.Sma);
}
