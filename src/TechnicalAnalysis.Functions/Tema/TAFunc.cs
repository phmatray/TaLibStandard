// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Triple Exponential Moving Average (TEMA) - an indicator with minimal lag.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the EMA calculation. Typical values: 12, 20.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the TEMA values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// TEMA is calculated as:
    /// TEMA = 3 × EMA - 3 × EMA(EMA) + EMA(EMA(EMA))
    /// 
    /// TEMA reduces lag even more than DEMA by using triple exponential smoothing.
    /// It reacts very quickly to price changes while maintaining smoothness.
    /// 
    /// Benefits:
    /// - Minimal lag compared to traditional moving averages
    /// - Excellent for identifying trend changes early
    /// - Smooth enough to filter out market noise
    /// 
    /// Considerations:
    /// - Can overshoot during volatile periods due to its responsiveness
    /// - Requires more computation than simple moving averages
    /// - Best suited for short to medium-term trend following
    /// </remarks>
    public static RetCode Tema(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        RetCode validationResult = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal, optInTimePeriod);
        if (validationResult != Success)
        {
            return validationResult;
        }

        outNBElement = 0;
        outBegIdx = 0;
        int lookbackEMA = EmaLookback(optInTimePeriod);
        int lookbackTotal = lookbackEMA * 3;
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx <= endIdx)
        {
            int firstEMANbElement = 0;
            int thirdEMANbElement = 0;
            int thirdEMABegIdx = 0;
            int secondEMANbElement = 0;
            int secondEMABegIdx = 0;
            int firstEMABegIdx = 0;
            int tempInt = lookbackTotal + (endIdx - startIdx) + 1;
            double[] firstEMA = new double[tempInt];

            double k = 2.0 / (optInTimePeriod + 1);
            RetCode retCode = TA_INT_EMA(
                startIdx - (lookbackEMA * 2),
                endIdx,
                inReal,
                optInTimePeriod,
                k,
                ref firstEMABegIdx,
                ref firstEMANbElement,
                firstEMA);
            if (retCode != Success || firstEMANbElement == 0)
            {
                return retCode;
            }

            double[] secondEMA = new double[firstEMANbElement];

            retCode = TA_INT_EMA(
                0,
                firstEMANbElement - 1,
                firstEMA,
                optInTimePeriod,
                k,
                ref secondEMABegIdx,
                ref secondEMANbElement,
                secondEMA);
            if (retCode != Success || secondEMANbElement == 0)
            {
                return retCode;
            }

            retCode = TA_INT_EMA(
                0,
                secondEMANbElement - 1,
                secondEMA,
                optInTimePeriod,
                k,
                ref thirdEMABegIdx,
                ref thirdEMANbElement,
                outReal);
            if (retCode != Success || thirdEMANbElement == 0)
            {
                return retCode;
            }

            int firstEMAIdx = thirdEMABegIdx + secondEMABegIdx;
            int secondEMAIdx = thirdEMABegIdx;
            outBegIdx = firstEMAIdx + firstEMABegIdx;
            int outIdx = 0;
            while (true)
            {
                if (outIdx >= thirdEMANbElement)
                {
                    break;
                }

                outReal[outIdx] += (3.0 * firstEMA[firstEMAIdx]) - (3.0 * secondEMA[secondEMAIdx]);
                secondEMAIdx++;
                firstEMAIdx++;
                outIdx++;
            }

            outNBElement = outIdx;
        }

        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for TEMA calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the EMA calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid TEMA value can be calculated, or -1 if parameters are invalid.</returns>
    public static int TemaLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : EmaLookback(optInTimePeriod) * 3;
    }
}
