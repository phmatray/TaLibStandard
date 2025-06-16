// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Triangular Moving Average (TRIMA) for the specified range of data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <param name="timePeriod">The number of periods to use in the TRIMA calculation. Default is 30.</param>
    /// <returns>A TrimaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// The Triangular Moving Average (TRIMA) is a double-smoothed simple moving average that places
    /// the most weight on the middle portion of the data. It is calculated by averaging a simple
    /// moving average. This creates a smoother line that is less responsive to short-term fluctuations
    /// but better at identifying longer-term trends.
    /// </remarks>
    public static TrimaResult Trima(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Trima(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new TrimaResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Triangular Moving Average (TRIMA) using a default period of 30.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values.</param>
    /// <returns>A TrimaResult object containing the calculated values and metadata.</returns>
    public static TrimaResult Trima(int startIdx, int endIdx, double[] real)
        => Trima(startIdx, endIdx, real, 30);

    /// <summary>
    /// Calculates the Triangular Moving Average (TRIMA) for float input data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <param name="timePeriod">The number of periods to use in the TRIMA calculation.</param>
    /// <returns>A TrimaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static TrimaResult Trima(int startIdx, int endIdx, float[] real, int timePeriod)
        => Trima(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Triangular Moving Average (TRIMA) for float input data using a default period of 30.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input data array containing price values as floats.</param>
    /// <returns>A TrimaResult object containing the calculated values and metadata.</returns>
    /// <remarks>
    /// This overload converts the float array to double array before performing the calculation,
    /// as the underlying TAFunc library operates on double precision values.
    /// </remarks>
    public static TrimaResult Trima(int startIdx, int endIdx, float[] real)
        => Trima(startIdx, endIdx, real, 30);
}
