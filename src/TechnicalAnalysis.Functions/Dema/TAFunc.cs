// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Double Exponential Moving Average (DEMA) - a smoothing indicator with reduced lag.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the EMA calculation. Typical values: 12, 20.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the DEMA values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// DEMA is calculated as:
    /// DEMA = 2 × EMA - EMA(EMA)
    /// 
    /// This formula reduces the lag inherent in traditional moving averages while
    /// maintaining smoothness. DEMA responds more quickly to price changes than
    /// a standard EMA with the same period.
    /// 
    /// Benefits:
    /// - Reduced lag compared to EMA or SMA
    /// - Smoother than raw price data
    /// - Better trend following in fast-moving markets
    /// 
    /// Note: Despite the name, DEMA is not simply an EMA applied twice,
    /// but uses a specific formula to achieve lag reduction.
    /// </remarks>
    public static RetCode Dema(
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
        int lookbackTotal = lookbackEMA * 2;
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx <= endIdx)
        {
            double[] firstEMA;
            int firstEMANbElement = 0;
            int secondEMANbElement = 0;
            int secondEMABegIdx = 0;
            int firstEMABegIdx = 0;
            if (inReal == outReal)
            {
                firstEMA = outReal;
            }
            else
            {
                int tempInt = lookbackTotal + (endIdx - startIdx) + 1;
                firstEMA = new double[tempInt];
            }

            double k = 2.0 / (optInTimePeriod + 1);
            RetCode retCode = TA_INT_EMA(
                startIdx - lookbackEMA,
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

            int firstEMAIdx = secondEMABegIdx;
            int outIdx = 0;
            while (true)
            {
                if (outIdx >= secondEMANbElement)
                {
                    break;
                }

                outReal[outIdx] = (2.0 * firstEMA[firstEMAIdx]) - secondEMA[outIdx];
                firstEMAIdx++;
                outIdx++;
            }

            outBegIdx = firstEMABegIdx + secondEMABegIdx;
            outNBElement = outIdx;
        }

        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for DEMA calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the EMA calculation. Valid range: 2 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid DEMA value can be calculated, or -1 if parameters are invalid.</returns>
    public static int DemaLookback(int optInTimePeriod)
        => optInTimePeriod is < 2 or > 100000
            ? -1
            : EmaLookback(optInTimePeriod) * 2;
}
