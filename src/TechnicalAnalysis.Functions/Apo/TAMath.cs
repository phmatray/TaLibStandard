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
    /// Calculates the Absolute Price Oscillator (APO) which shows the difference between two moving averages.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="fastPeriod">The number of periods for the fast moving average (default: 12).</param>
    /// <param name="slowPeriod">The number of periods for the slow moving average (default: 26).</param>
    /// <param name="maType">The type of moving average to use (default: Simple Moving Average).</param>
    /// <returns>An ApoResult containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The APO is calculated as: Fast MA - Slow MA.
    /// Unlike the PPO (Percentage Price Oscillator), the APO provides the absolute difference,
    /// making it useful for comparing momentum across different time periods of the same security.
    /// </remarks>
    public static ApoResult Apo(int startIdx, int endIdx, double[] real, int fastPeriod = 12, int slowPeriod = 26, MAType maType = MAType.Sma)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Apo(
            startIdx,
            endIdx,
            real,
            fastPeriod,
            slowPeriod,
            maType,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);

        return new ApoResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Absolute Price Oscillator (APO) which shows the difference between two moving averages.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="fastPeriod">The number of periods for the fast moving average (default: 12).</param>
    /// <param name="slowPeriod">The number of periods for the slow moving average (default: 26).</param>
    /// <param name="maType">The type of moving average to use (default: Simple Moving Average).</param>
    /// <returns>An ApoResult containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// </remarks>
    public static ApoResult Apo(int startIdx, int endIdx, float[] real, int fastPeriod = 12, int slowPeriod = 26, MAType maType = MAType.Sma)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => Apo(s, e, r, fastPeriod, slowPeriod, maType));
}
