// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Summation - rolling sum of values over a specified period.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of values to sum.</param>
    /// <param name="optInTimePeriod">Number of periods for the summation. Typical range: 10-50.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the summation values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The Summation function calculates a rolling sum over a specified window.
    /// 
    /// Calculation:
    /// Sum[i] = inReal[i] + inReal[i-1] + ... + inReal[i-period+1]
    /// 
    /// Common applications:
    /// - Volume accumulation over time periods
    /// - Cumulative price changes
    /// - Building block for other indicators
    /// - Statistical analysis of accumulated values
    /// 
    /// Examples of use:
    /// - Sum of volume over 20 days to identify accumulation/distribution
    /// - Sum of price changes to calculate cumulative performance
    /// - Component in calculating averages (Sum/Period = Average)
    /// 
    /// Key characteristics:
    /// - Sensitive to outliers (large values have significant impact)
    /// - Increases/decreases as values enter/exit the window
    /// - Can be used to detect trends in cumulative data
    /// 
    /// The Sum function differs from cumulative sum (running total) as it
    /// maintains a fixed window size, dropping old values as new ones are added.
    /// </remarks>
    public static RetCode Sum(
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

        int lookbackTotal = optInTimePeriod - 1;
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

        double periodTotal = 0.0;
        int trailingIdx = startIdx - lookbackTotal;
        int i = trailingIdx;
        while (i < startIdx)
        {
            periodTotal += inReal[i];
            i++;
        }

        int outIdx = 0;
        do
        {
            periodTotal += inReal[i];
            i++;
            double tempReal = periodTotal;
            periodTotal -= inReal[trailingIdx];
            trailingIdx++;
            outReal[outIdx] = tempReal;
            outIdx++;
        }
        while (i <= endIdx);

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Calculates the lookback period for the Summation function.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the summation.</param>
    /// <returns>The minimum number of data points required (period - 1), or -1 for invalid parameters.</returns>
    public static int SumLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 2 or > 100000 ? -1 : optInTimePeriod - 1;
    }
}
