// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Standard Deviation - a measure of volatility and dispersion from the mean.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the calculation. Typical values: 20, 50.</param>
    /// <param name="optInNbDev">Number of standard deviations to calculate. Typical value: 1.0.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the standard deviation values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Standard Deviation measures how spread out values are from their average.
    /// It's calculated as the square root of variance.
    /// 
    /// In technical analysis, standard deviation is used to:
    /// - Measure market volatility
    /// - Calculate Bollinger Bands (typically 2 standard deviations)
    /// - Identify periods of high/low volatility
    /// - Risk assessment and position sizing
    /// 
    /// Higher values indicate greater volatility/risk, while lower values
    /// suggest more stable price action. The optInNbDev parameter allows
    /// scaling the output (e.g., 2.0 for Bollinger Bands).
    /// </remarks>
    public static RetCode StdDev(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        in double optInNbDev,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int i;
        double tempReal;
        RetCode validationResult = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal, optInTimePeriod);
        if (validationResult != Success)
        {
            return validationResult;
        }

        RetCode retCode = TA_INT_VAR(
            startIdx,
            endIdx,
            inReal,
            optInTimePeriod,
            ref outBegIdx,
            ref outNBElement,
            outReal);
        
        if (retCode != Success)
        {
            return retCode;
        }

        if (Math.Abs(optInNbDev - 1.0) < 0.00000000000001)
        {
            for (i = 0; i < outNBElement; i++)
            {
                tempReal = outReal[i];
                outReal[i] = tempReal >= 1E-08 ? Math.Sqrt(tempReal) : 0.0;
            }
        }
        else
        {
            for (i = 0; i < outNBElement; i++)
            {
                tempReal = outReal[i];
                outReal[i] = tempReal >= 1E-08 ? Math.Sqrt(tempReal) * optInNbDev : 0.0;
            }
        }

        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Standard Deviation calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the calculation. Valid range: 2 to 100000.</param>
    /// <param name="optInNbDev">Number of standard deviations (not used in lookback calculation).</param>
    /// <returns>The number of historical data points required before the first valid standard deviation value can be calculated, or -1 if parameters are invalid.</returns>
    public static int StdDevLookback(int optInTimePeriod, double optInNbDev)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : VarianceLookback(optInTimePeriod);
    }
}
