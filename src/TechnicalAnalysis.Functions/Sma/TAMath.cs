// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Simple Moving Average (SMA) for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values (typically closing prices) to calculate the SMA for.</param>
    /// <param name="timePeriod">The number of periods to use in the moving average calculation.</param>
    /// <returns>
    /// A <see cref="SmaResult"/> containing the calculated SMA values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// The Simple Moving Average is the unweighted mean of the previous n data points.
    /// It is commonly used to smooth out short-term fluctuations and highlight longer-term trends.
    /// The SMA gives equal weight to all values in the calculation period, making it less
    /// responsive to recent price changes compared to exponential moving averages.
    /// </remarks>
    public static SmaResult Sma(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Sma(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new SmaResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Simple Moving Average (SMA) for the input price data using the default period of 30.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values (typically closing prices) to calculate the SMA for.</param>
    /// <returns>
    /// A <see cref="SmaResult"/> containing the calculated SMA values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// This overload uses a 30-period SMA calculation, which is commonly used for medium-term
    /// trend analysis in technical analysis.
    /// </remarks>
    public static SmaResult Sma(int startIdx, int endIdx, double[] real)
        => Sma(startIdx, endIdx, real, 30);

    /// <summary>
    /// Calculates the Simple Moving Average (SMA) for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values (typically closing prices) to calculate the SMA for.</param>
    /// <param name="timePeriod">The number of periods to use in the moving average calculation.</param>
    /// <returns>
    /// A <see cref="SmaResult"/> containing the calculated SMA values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// This overload accepts float values for convenience and internally converts them to double precision
    /// before performing the calculation. This may result in minor precision differences compared to 
    /// using double values directly.
    /// </remarks>
    public static SmaResult Sma(int startIdx, int endIdx, float[] real, int timePeriod)
        => Sma(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    /// <summary>
    /// Calculates the Simple Moving Average (SMA) for the input price data using the default period of 30.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the array.</param>
    /// <param name="endIdx">The ending index for the calculation within the array.</param>
    /// <param name="real">An array of real values (typically closing prices) to calculate the SMA for.</param>
    /// <returns>
    /// A <see cref="SmaResult"/> containing the calculated SMA values, 
    /// along with the starting index of the result and the number of elements generated.
    /// </returns>
    /// <remarks>
    /// This overload accepts float values and uses a 30-period SMA calculation.
    /// The values are internally converted to double precision before performing the calculation.
    /// </remarks>
    public static SmaResult Sma(int startIdx, int endIdx, float[] real)
        => Sma(startIdx, endIdx, real, 30);
}
