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
    /// Calculates the Relative Strength Index (RSI) for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values (typically closing prices) to calculate the RSI for.</param>
    /// <param name="timePeriod">The number of periods to use in the RSI calculation. Default is 14.</param>
    /// <returns>
    /// A <see cref="RsiResult"/> containing the calculated RSI values,
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// The RSI is a momentum oscillator that measures the speed and magnitude of price changes.
    /// It oscillates between 0 and 100, with traditional overbought levels at 70 and oversold levels at 30.
    /// The RSI is calculated using the average gains and losses over the specified time period.
    /// Higher time periods result in a smoother RSI line with fewer signals.
    /// </remarks>
    public static RsiResult Rsi(int startIdx, int endIdx, double[] real, int timePeriod = 14)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Rsi(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
        return new RsiResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Relative Strength Index (RSI) for float input data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values (typically closing prices) to calculate the RSI for.</param>
    /// <param name="timePeriod">The number of periods to use in the RSI calculation. Default is 14.</param>
    /// <returns>
    /// A <see cref="RsiResult"/> containing the calculated RSI values,
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// This overload accepts float values for convenience and internally converts them to double precision
    /// before performing the calculation. This may result in minor precision differences compared to
    /// using double values directly.
    /// </remarks>
    public static RsiResult Rsi(int startIdx, int endIdx, float[] real, int timePeriod = 14)
        => TAMathHelper.Execute(startIdx, endIdx, real, (s, e, r) => Rsi(s, e, r, timePeriod));
}
