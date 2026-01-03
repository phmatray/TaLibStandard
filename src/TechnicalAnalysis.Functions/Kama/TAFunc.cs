// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates Kaufman's Adaptive Moving Average (KAMA) - an adaptive moving average that adjusts to market volatility.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of prices (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the efficiency ratio calculation. Typical value: 10.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the KAMA values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// KAMA adapts to market conditions by varying its speed based on the efficiency ratio.
    /// It moves quickly when prices are trending and slowly during consolidation.
    /// 
    /// Key concepts:
    /// - Efficiency Ratio (ER) = Direction / Volatility
    /// - Direction = |Close - Close[n periods ago]|
    /// - Volatility = Sum of |Close - Previous Close| over n periods
    /// - Smoothing Constant (SC) = [ER * (fastest SC - slowest SC) + slowest SC]²
    /// 
    /// The adaptive nature helps to:
    /// - Reduce lag during trends
    /// - Minimize whipsaws during sideways markets
    /// - Provide better entries and exits than fixed-period moving averages
    /// 
    /// Typical uses:
    /// - Trend following with reduced false signals
    /// - Dynamic support/resistance levels
    /// - Adaptive stop-loss placement
    /// - Momentum confirmation
    /// 
    /// KAMA is particularly effective in markets that alternate between trending and ranging phases.
    /// </remarks>
    public static RetCode Kama(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double tempReal;
        const double ConstMax = 0.064516129032258063;
        const double ConstDiff = 0.66666666666666663 - ConstMax;
        RetCode validationResult = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal, optInTimePeriod);
        if (validationResult != Success)
        {
            return validationResult;
        }

        int lookbackTotal = optInTimePeriod + (int)TACore.Globals.UnstablePeriod[FuncUnstId.Kama];
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        double sumRoc1 = 0.0;
        int today = startIdx - lookbackTotal;
        int trailingIdx = today;
        int i = optInTimePeriod;
        while (true)
        {
            i--;
            if (i <= 0)
            {
                break;
            }

            tempReal = inReal[today];
            today++;
            tempReal -= inReal[today];
            sumRoc1 += Math.Abs(tempReal);
        }

        double prevKama = inReal[today - 1];
        tempReal = inReal[today];
        double tempReal2 = inReal[trailingIdx];
        trailingIdx++;
        double periodRoc = tempReal - tempReal2;
        double trailingValue = tempReal2;
        tempReal = sumRoc1 <= periodRoc ? 1.0 : Math.Abs(periodRoc / sumRoc1);

        tempReal = (tempReal * ConstDiff) + ConstMax;
        tempReal *= tempReal;
        prevKama = ((inReal[today] - prevKama) * tempReal) + prevKama;
        today++;
        while (true)
        {
            if (today > startIdx)
            {
                break;
            }

            tempReal = inReal[today];
            tempReal2 = inReal[trailingIdx];
            trailingIdx++;
            periodRoc = tempReal - tempReal2;
            sumRoc1 -= Math.Abs(trailingValue - tempReal2);
            sumRoc1 += Math.Abs(tempReal - inReal[today - 1]);
            trailingValue = tempReal2;
            tempReal = sumRoc1 <= periodRoc ? 1.0 : Math.Abs(periodRoc / sumRoc1);

            tempReal = (tempReal * ConstDiff) + ConstMax;
            tempReal *= tempReal;
            prevKama = ((inReal[today] - prevKama) * tempReal) + prevKama;
            today++;
        }

        outReal[0] = prevKama;
        int outIdx = 1;
        outBegIdx = today - 1;
        while (true)
        {
            if (today > endIdx)
            {
                break;
            }

            tempReal = inReal[today];
            tempReal2 = inReal[trailingIdx];
            trailingIdx++;
            periodRoc = tempReal - tempReal2;
            sumRoc1 -= Math.Abs(trailingValue - tempReal2);
            sumRoc1 += Math.Abs(tempReal - inReal[today - 1]);
            trailingValue = tempReal2;
            tempReal = sumRoc1 <= periodRoc ? 1.0 : Math.Abs(periodRoc / sumRoc1);

            tempReal = (tempReal * ConstDiff) + ConstMax;
            tempReal *= tempReal;
            prevKama = ((inReal[today] - prevKama) * tempReal) + prevKama;
            today++;
            outReal[outIdx] = prevKama;
            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for KAMA calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the efficiency ratio calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid KAMA value can be calculated, or -1 if parameters are invalid.</returns>
    public static int KamaLookback(int optInTimePeriod)
    {
        return ValidationHelper.ValidateLookback(optInTimePeriod, unstablePeriod: FuncUnstId.Kama);
    }
}
