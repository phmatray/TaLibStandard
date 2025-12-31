// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Variance - a measure of the dispersion of values around their mean.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the calculation. Typical values: 20, 50.</param>
    /// <param name="optInNbDev">Deviation multiplier (must be greater than 0). Typical value: 1.0.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the variance values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Variance measures the average squared deviation from the mean.
    /// It's the square of the standard deviation.
    /// 
    /// Formula: Variance = Σ(x - mean)² / n
    /// 
    /// Uses in technical analysis:
    /// - Foundation for calculating standard deviation
    /// - Risk measurement (higher variance = higher risk)
    /// - Volatility analysis
    /// - Input for other statistical indicators
    /// 
    /// Variance is always non-negative, with larger values indicating
    /// greater dispersion of data points from the mean.
    /// </remarks>
    public static RetCode Variance(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        in double optInNbDev,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode validationResult = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal, optInTimePeriod, 1);
        if (validationResult != Success)
        {
            return validationResult;
        }

        if (optInNbDev <= 0)
        {
            return BadParam;
        }

        RetCode taIntVar = TA_INT_VAR(startIdx, endIdx, inReal, optInTimePeriod, ref outBegIdx, ref outNBElement, outReal);
        
        return taIntVar;
    }

    /// <summary>
    /// Returns the lookback period required for Variance calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the calculation. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid variance value can be calculated, or -1 if parameters are invalid.</returns>
    public static int VarianceLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 1 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
