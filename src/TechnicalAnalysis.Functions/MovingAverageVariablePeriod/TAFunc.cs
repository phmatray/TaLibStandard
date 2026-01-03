// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates a moving average where the period can vary for each data point.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The MovingAverageVariablePeriod function provides a unique capability to calculate moving averages
    /// where the period (window size) can change dynamically for each data point. This allows for adaptive
    /// behavior based on market conditions or other criteria encoded in the periods array.
    /// </para>
    /// 
    /// <para>
    /// Key features:
    /// - Each element in the output can have a different period for its moving average calculation
    /// - Periods are constrained between optInMinPeriod and optInMaxPeriod for stability
    /// - The function optimizes calculations by grouping identical periods together
    /// - Supports all the same moving average types as the standard MovingAverage function
    /// </para>
    /// 
    /// <para>
    /// Common use cases:
    /// - Adaptive moving averages that respond to volatility
    /// - Custom trading systems that adjust period based on market conditions
    /// - Multi-timeframe analysis within a single calculation
    /// </para>
    /// 
    /// <para>
    /// The function uses the maximum period (optInMaxPeriod) to determine the overall lookback requirement,
    /// ensuring sufficient data is available for all possible period values.
    /// </para>
    /// </remarks>
    /// <param name="startIdx">The starting index for the input data. Must be non-negative.</param>
    /// <param name="endIdx">The ending index for the input data. Must be greater than or equal to startIdx.</param>
    /// <param name="inReal">Array of input values to calculate the variable period moving average from.</param>
    /// <param name="inPeriods">
    /// Array of period values, one for each potential output point. Values outside the min/max range
    /// will be clamped to the nearest boundary. The array should be at least as long as the input data.
    /// </param>
    /// <param name="optInMinPeriod">
    /// The minimum allowed period value. Must be between 2 and 100000.
    /// Period values below this will be adjusted up to this minimum.
    /// </param>
    /// <param name="optInMaxPeriod">
    /// The maximum allowed period value. Must be between 2 and 100000.
    /// Period values above this will be adjusted down to this maximum.
    /// This also determines the overall lookback requirement.
    /// </param>
    /// <param name="optInMAType">
    /// The type of moving average to calculate. The same MA type is used for all periods,
    /// only the period length varies.
    /// </param>
    /// <param name="outBegIdx">
    /// Output parameter that indicates the index in the input array corresponding to the first output value.
    /// This is based on the maximum period's lookback requirement.
    /// </param>
    /// <param name="outNBElement">
    /// Output parameter that indicates the number of elements written to the output array.
    /// </param>
    /// <param name="outReal">
    /// Output array containing the calculated variable period moving average values.
    /// Each value is calculated using the period specified in the corresponding inPeriods element.
    /// The array must be pre-allocated with sufficient size.
    /// </param>
    /// <returns>
    /// A <see cref="RetCode"/> indicating the success or failure of the operation:
    /// - Success: Calculation completed successfully
    /// - OutOfRangeStartIndex: startIdx is less than 0
    /// - OutOfRangeEndIndex: endIdx is less than 0 or less than startIdx
    /// - BadParam: Invalid parameters (null arrays, invalid period ranges)
    /// </returns>
    /// <example>
    /// <code>
    /// double[] prices = { 10.0, 12.0, 11.0, 13.0, 14.0, 15.0, 14.0, 13.0, 12.0, 11.0 };
    /// double[] periods = { 3.0, 3.0, 4.0, 4.0, 5.0, 5.0, 3.0, 3.0, 4.0, 4.0 };
    /// double[] output = new double[prices.Length];
    /// int outBegIdx = 0;
    /// int outNBElement = 0;
    /// 
    /// // Calculate variable period SMA with periods ranging from 3 to 5
    /// RetCode result = TAFunc.MovingAverageVariablePeriod(
    ///     0, prices.Length - 1, prices, periods, 
    ///     2, 10, MAType.Sma,
    ///     ref outBegIdx, ref outNBElement, ref output);
    /// 
    /// // Each output[i] is calculated using periods[i] as the moving average period
    /// </code>
    /// </example>
    public static RetCode MovingAverageVariablePeriod(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in double[] inPeriods,
        in int optInMinPeriod,
        in int optInMaxPeriod,
        in MAType optInMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        int i;
        var inPeriodsLocal = inPeriods;
        var inRealLocal = inReal;
        var outRealLocal = outReal;
        var optInMaxPeriodLocal = optInMaxPeriod;
        var optInMinPeriodLocal = optInMinPeriod;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inRealLocal, inPeriodsLocal, outRealLocal),
            () => ValidationHelper.ValidatePeriodRange(optInMinPeriodLocal),
            () => ValidationHelper.ValidatePeriodRange(optInMaxPeriodLocal)
        );
        if (validation != Success)
        {
            return validation;
        }

        int lookbackTotal = MovingAverageLookback(optInMaxPeriod, optInMAType);
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

        int tempInt = lookbackTotal > startIdx ? lookbackTotal : startIdx;

        if (tempInt > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int outputSize = endIdx - tempInt + 1;
        double[] localOutputArray = new double[outputSize];
        int[] localPeriodArray = new int[outputSize];
        for (i = 0; i < outputSize; i++)
        {
            tempInt = (int)inPeriods[startIdx + i];
            if (tempInt < optInMinPeriod)
            {
                tempInt = optInMinPeriod;
            }
            else if (tempInt > optInMaxPeriod)
            {
                tempInt = optInMaxPeriod;
            }

            localPeriodArray[i] = tempInt;
        }

        i = 0;
        while (true)
        {
            if (i >= outputSize)
            {
                outBegIdx = startIdx;
                outNBElement = outputSize;
                return Success;
            }

            int curPeriod = localPeriodArray[i];
            if (curPeriod != 0)
            {
                int localNbElement = 0;
                int localBegIdx = 0;
                RetCode retCode = MovingAverage(
                    startIdx,
                    endIdx,
                    inReal,
                    curPeriod,
                    optInMAType,
                    ref localBegIdx,
                    ref localNbElement,
                    ref localOutputArray);
                if (retCode != Success)
                {
                    outBegIdx = 0;
                    outNBElement = 0;
                    return retCode;
                }

                outReal[i] = localOutputArray[i];
                for (int j = i + 1; j < outputSize; j++)
                {
                    if (localPeriodArray[j] == curPeriod)
                    {
                        localPeriodArray[j] = 0;
                        outReal[j] = localOutputArray[j];
                    }
                }
            }

            i++;
        }
    }

    /// <summary>
    /// Calculates the lookback period required for a variable period moving average calculation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The lookback period for a variable period moving average is determined by the maximum
    /// possible period value (optInMaxPeriod). This ensures that sufficient historical data
    /// is available regardless of which period values are actually used in the calculation.
    /// </para>
    /// 
    /// <para>
    /// The lookback calculation follows these rules:
    /// - Uses the optInMaxPeriod to determine the worst-case lookback requirement
    /// - The actual lookback depends on the specified moving average type
    /// - Returns -1 if the period parameters are outside valid ranges
    /// </para>
    /// 
    /// <para>
    /// This conservative approach guarantees that the function will have enough data
    /// to calculate any valid moving average within the specified period range.
    /// </para>
    /// </remarks>
    /// <param name="optInMinPeriod">
    /// The minimum allowed period value. Must be between 2 and 100000.
    /// This parameter is validated but does not affect the lookback calculation.
    /// </param>
    /// <param name="optInMaxPeriod">
    /// The maximum allowed period value. Must be between 2 and 100000.
    /// This value determines the actual lookback period returned.
    /// </param>
    /// <param name="optInMAType">
    /// The type of moving average for which to calculate the lookback.
    /// Different MA types have different lookback requirements for the same period.
    /// </param>
    /// <returns>
    /// The number of data points required before the first variable period moving average
    /// value can be calculated. This is based on the maximum period's requirements.
    /// Returns -1 if either period parameter is outside the valid range.
    /// </returns>
    /// <example>
    /// <code>
    /// // Get lookback for variable period EMA with periods ranging from 5 to 20
    /// int lookback = TAFunc.MovingAverageVariablePeriodLookback(5, 20, MAType.Ema);
    /// // lookback will be based on a 20-period EMA requirement
    /// 
    /// // For SMA with the same range
    /// int lookbackSma = TAFunc.MovingAverageVariablePeriodLookback(5, 20, MAType.Sma);
    /// // lookbackSma will be 19 (20 - 1)
    /// </code>
    /// </example>
    public static int MovingAverageVariablePeriodLookback(
        int optInMinPeriod,
        int optInMaxPeriod,
        MAType optInMAType)
    {
        return optInMinPeriod is < 2 or > 100000 ||
            optInMaxPeriod is < 2 or > 100000
            ? -1
            : MovingAverageLookback(optInMaxPeriod, optInMAType);
    }
}
