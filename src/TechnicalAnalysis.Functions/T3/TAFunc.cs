// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the T3 Moving Average (Triple Exponential Moving Average) - a smoother and less lagging moving average.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInTimePeriod">Number of periods for the T3 calculation. Valid range: 2 to 100000.</param>
    /// <param name="optInVFactor">Volume Factor controls the smoothing. Valid range: 0.0 to 1.0. Default: 0.7.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the T3 values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The T3 Moving Average is a sophisticated smoothing indicator developed by Tim Tillson.
    /// It uses multiple exponential moving averages and a volume factor to create a smooth line
    /// that is responsive to market movements while filtering out market noise.
    /// 
    /// Key characteristics:
    /// - Less lag than traditional moving averages
    /// - Smoother than EMA or DEMA
    /// - The volume factor (V-Factor) controls the amount of smoothing:
    ///   - V-Factor = 0: Equivalent to an EMA
    ///   - V-Factor = 1: Maximum smoothing
    ///   - V-Factor = 0.7: Common default value
    /// 
    /// Common uses:
    /// - Trend identification with reduced false signals
    /// - Dynamic support and resistance levels
    /// - Entry/exit signals when price crosses the T3
    /// - Smoothing other indicators to reduce noise
    /// </remarks>
    public static RetCode T3(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        in double optInVFactor,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int i;
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null! ||
            optInTimePeriod is < 2 or > 100000 ||
            optInVFactor is < 0.0 or > 1.0 ||
            outReal == null!)
        {
            return BadParam;
        }

        int lookbackTotal = ((optInTimePeriod - 1) * 6) + (int)TACore.Globals.UnstablePeriod[FuncUnstId.T3];
        if (startIdx <= lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            outNBElement = 0;
            outBegIdx = 0;
            return Success;
        }

        outBegIdx = startIdx;
        int today = startIdx - lookbackTotal;
        double k = 2.0 / (optInTimePeriod + 1.0);
        double oneMinusK = 1.0 - k;
        double tempReal = inReal[today];
        today++;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            tempReal += inReal[today];
            today++;
        }

        double e1 = tempReal / optInTimePeriod;
        tempReal = e1;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            e1 = (k * inReal[today]) + (oneMinusK * e1);
            today++;
            tempReal += e1;
        }

        double e2 = tempReal / optInTimePeriod;
        tempReal = e2;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            e1 = (k * inReal[today]) + (oneMinusK * e1);
            today++;
            e2 = (k * e1) + (oneMinusK * e2);
            tempReal += e2;
        }

        double e3 = tempReal / optInTimePeriod;
        tempReal = e3;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            e1 = (k * inReal[today]) + (oneMinusK * e1);
            today++;
            e2 = (k * e1) + (oneMinusK * e2);
            e3 = (k * e2) + (oneMinusK * e3);
            tempReal += e3;
        }

        double e4 = tempReal / optInTimePeriod;
        tempReal = e4;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            e1 = (k * inReal[today]) + (oneMinusK * e1);
            today++;
            e2 = (k * e1) + (oneMinusK * e2);
            e3 = (k * e2) + (oneMinusK * e3);
            e4 = (k * e3) + (oneMinusK * e4);
            tempReal += e4;
        }

        double e5 = tempReal / optInTimePeriod;
        tempReal = e5;
        for (i = optInTimePeriod - 1; i > 0; i--)
        {
            e1 = (k * inReal[today]) + (oneMinusK * e1);
            today++;
            e2 = (k * e1) + (oneMinusK * e2);
            e3 = (k * e2) + (oneMinusK * e3);
            e4 = (k * e3) + (oneMinusK * e4);
            e5 = (k * e4) + (oneMinusK * e5);
            tempReal += e5;
        }

        double e6 = tempReal / optInTimePeriod;
        while (true)
        {
            if (today > startIdx)
            {
                break;
            }

            e1 = (k * inReal[today]) + (oneMinusK * e1);
            today++;
            e2 = (k * e1) + (oneMinusK * e2);
            e3 = (k * e2) + (oneMinusK * e3);
            e4 = (k * e3) + (oneMinusK * e4);
            e5 = (k * e4) + (oneMinusK * e5);
            e6 = (k * e5) + (oneMinusK * e6);
        }

        tempReal = optInVFactor * optInVFactor;
        double c1 = -(tempReal * optInVFactor);
        double c2 = 3.0 * (tempReal - c1);
        double c3 = (-6.0 * tempReal) - (3.0 * (optInVFactor - c1));
        double c4 = 1.0 + (3.0 * optInVFactor) - c1 + (3.0 * tempReal);
        int outIdx = 0;
        outReal[outIdx] = (c1 * e6) + (c2 * e5) + (c3 * e4) + (c4 * e3);
        outIdx++;
        while (true)
        {
            if (today > endIdx)
            {
                break;
            }

            e1 = (k * inReal[today]) + (oneMinusK * e1);
            today++;
            e2 = (k * e1) + (oneMinusK * e2);
            e3 = (k * e2) + (oneMinusK * e3);
            e4 = (k * e3) + (oneMinusK * e4);
            e5 = (k * e4) + (oneMinusK * e5);
            e6 = (k * e5) + (oneMinusK * e6);
            outReal[outIdx] = (c1 * e6) + (c2 * e5) + (c3 * e4) + (c4 * e3);
            outIdx++;
        }

        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for T3 calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the T3 calculation. Valid range: 2 to 100000.</param>
    /// <param name="optInVFactor">Volume Factor controls the smoothing. Valid range: 0.0 to 1.0.</param>
    /// <returns>The number of historical data points required before the first valid T3 value can be calculated, or -1 if parameters are invalid.</returns>
    public static int T3Lookback(int optInTimePeriod, double optInVFactor)
    {
        return optInTimePeriod is < 2 or > 100000 ||
            optInVFactor is < 0.0 or > 1.0
            ? -1
            : ((optInTimePeriod - 1) * 6) + (int)TACore.Globals.UnstablePeriod[FuncUnstId.T3];
    }
}
