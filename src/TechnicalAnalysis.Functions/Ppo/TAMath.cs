// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Percentage Price Oscillator (PPO) which shows the percentage difference between two moving averages.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="fastPeriod">The number of periods for the fast moving average (default: 12).</param>
    /// <param name="slowPeriod">The number of periods for the slow moving average (default: 26).</param>
    /// <param name="maType">The type of moving average to use (default: Simple Moving Average).</param>
    /// <returns>A PpoResult containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The PPO is calculated as: ((Fast MA - Slow MA) / Slow MA) * 100.
    /// Unlike the APO (Absolute Price Oscillator), the PPO provides a percentage-based measure,
    /// making it useful for comparing momentum across different securities regardless of their price levels.
    /// </remarks>
    public static PpoResult Ppo(int startIdx, int endIdx, double[] real, int fastPeriod, int slowPeriod, MAType maType)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Ppo(
            startIdx,
            endIdx,
            real,
            fastPeriod,
            slowPeriod,
            maType,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new PpoResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Percentage Price Oscillator (PPO) using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <returns>A PpoResult containing the calculated values and metadata.</returns>
    /// <remarks>
    /// Uses default values: fastPeriod=12, slowPeriod=26, maType=Simple Moving Average.
    /// </remarks>
    public static PpoResult Ppo(int startIdx, int endIdx, double[] real)
        => Ppo(startIdx, endIdx, real, 12, 26, MAType.Sma);

    /// <summary>
    /// Calculates the Percentage Price Oscillator (PPO) which shows the percentage difference between two moving averages.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="fastPeriod">The number of periods for the fast moving average.</param>
    /// <param name="slowPeriod">The number of periods for the slow moving average.</param>
    /// <param name="maType">The type of moving average to use.</param>
    /// <returns>A PpoResult containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// </remarks>
    public static PpoResult Ppo(int startIdx, int endIdx, float[] real, int fastPeriod, int slowPeriod, MAType maType)
        => Ppo(startIdx, endIdx, real.ToDouble(), fastPeriod, slowPeriod, maType);
        
    /// <summary>
    /// Calculates the Percentage Price Oscillator (PPO) using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <returns>A PpoResult containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// Uses default values: fastPeriod=12, slowPeriod=26, maType=Simple Moving Average.
    /// </remarks>
    public static PpoResult Ppo(int startIdx, int endIdx, float[] real)
        => Ppo(startIdx, endIdx, real, 12, 26, MAType.Sma);
}
