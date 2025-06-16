// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Stochastic RSI (STOCHRSI) which applies stochastic calculations to RSI values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="timePeriod">The number of periods for RSI calculation (default: 14).</param>
    /// <param name="fastKPeriod">The number of periods for stochastic %K calculation (default: 5).</param>
    /// <param name="fastDPeriod">The smoothing period for %K to get %D (default: 3).</param>
    /// <param name="fastDMAType">The type of moving average for %D calculation (default: Simple MA).</param>
    /// <returns>A StochRsiResult containing the Stochastic RSI %K and %D values.</returns>
    /// <remarks>
    /// The Stochastic RSI is an oscillator that measures the level of RSI relative to its high-low range
    /// over a set time period. It applies the stochastic oscillator formula to RSI values instead of price.
    /// This creates a more sensitive indicator that generates more overbought/oversold signals than regular RSI.
    /// Values range from 0 to 1 (or 0 to 100 when expressed as percentage).
    /// </remarks>
    public static StochRsiResult StochRsi(
        int startIdx,
        int endIdx,
        double[] real,
        int timePeriod,
        int fastKPeriod,
        int fastDPeriod,
        MAType fastDMAType)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outFastK = new double[endIdx - startIdx + 1];
        double[] outFastD = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.StochRsi(
            startIdx,
            endIdx,
            real,
            timePeriod,
            fastKPeriod,
            fastDPeriod,
            fastDMAType,
            ref outBegIdx,
            ref outNBElement,
            ref outFastK,
            ref outFastD);
            
        return new StochRsiResult(retCode, outBegIdx, outNBElement, outFastK, outFastD);
    }

    /// <summary>
    /// Calculates the Stochastic RSI using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <returns>A StochRsiResult containing the Stochastic RSI %K and %D values.</returns>
    /// <remarks>
    /// Uses default values: timePeriod=14, fastKPeriod=5, fastDPeriod=3, fastDMAType=Simple Moving Average.
    /// </remarks>
    public static StochRsiResult StochRsi(int startIdx, int endIdx, double[] real)
        => StochRsi(startIdx, endIdx, real, 14, 5, 3, MAType.Sma);

    /// <summary>
    /// Calculates the Stochastic RSI (STOCHRSI) which applies stochastic calculations to RSI values.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <param name="timePeriod">The number of periods for RSI calculation.</param>
    /// <param name="fastKPeriod">The number of periods for stochastic %K calculation.</param>
    /// <param name="fastDPeriod">The smoothing period for %K to get %D.</param>
    /// <param name="fastDMAType">The type of moving average for %D calculation.</param>
    /// <returns>A StochRsiResult containing the Stochastic RSI %K and %D values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// </remarks>
    public static StochRsiResult StochRsi(
        int startIdx,
        int endIdx,
        float[] real,
        int timePeriod,
        int fastKPeriod,
        int fastDPeriod,
        MAType fastDMAType)
        => StochRsi(startIdx, endIdx, real.ToDouble(), timePeriod, fastKPeriod, fastDPeriod, fastDMAType);
        
    /// <summary>
    /// Calculates the Stochastic RSI using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">Array of input values (usually closing prices).</param>
    /// <returns>A StochRsiResult containing the Stochastic RSI %K and %D values.</returns>
    /// <remarks>
    /// This overload accepts float arrays and converts them to double arrays for calculation.
    /// Uses default values: timePeriod=14, fastKPeriod=5, fastDPeriod=3, fastDMAType=Simple Moving Average.
    /// </remarks>
    public static StochRsiResult StochRsi(int startIdx, int endIdx, float[] real)
        => StochRsi(startIdx, endIdx, real, 14, 5, 3, MAType.Sma);
}
