// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates a moving average with the flexibility to choose from multiple moving average types.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The MovingAverage function provides a unified interface to calculate various types of moving averages
    /// based on the specified MAType. This function acts as a dispatcher that routes to the appropriate
    /// moving average implementation.
    /// </para>
    /// 
    /// <para>
    /// Supported moving average types include:
    /// - SMA (Simple Moving Average): Equal weight to all values in the period
    /// - EMA (Exponential Moving Average): More weight to recent values
    /// - WMA (Weighted Moving Average): Linear weights favoring recent values
    /// - DEMA (Double Exponential Moving Average): Reduced lag version of EMA
    /// - TEMA (Triple Exponential Moving Average): Further reduced lag
    /// - TRIMA (Triangular Moving Average): Double smoothed SMA
    /// - KAMA (Kaufman Adaptive Moving Average): Adapts to market volatility
    /// - MAMA (MESA Adaptive Moving Average): Uses phase and amplitude adjustments
    /// - T3 (Tillson T3): Smooth moving average with reduced lag
    /// </para>
    /// 
    /// <para>
    /// Special behavior: When optInTimePeriod is 1, the function simply copies the input values
    /// to the output array, as no averaging is needed.
    /// </para>
    /// </remarks>
    /// <param name="startIdx">The starting index for the input data. Must be non-negative.</param>
    /// <param name="endIdx">The ending index for the input data. Must be greater than or equal to startIdx.</param>
    /// <param name="inReal">Array of input values to calculate the moving average from.</param>
    /// <param name="optInTimePeriod">
    /// The number of periods to use in the moving average calculation. 
    /// Valid range: 1 to 100000. When set to 1, input values are copied directly to output.
    /// </param>
    /// <param name="optInMAType">
    /// The type of moving average to calculate. Each type has different characteristics
    /// regarding smoothing, lag, and responsiveness to price changes.
    /// </param>
    /// <param name="outBegIdx">
    /// Output parameter that indicates the index in the input array corresponding to the first output value.
    /// This accounts for any lookback period required by the chosen moving average type.
    /// </param>
    /// <param name="outNBElement">
    /// Output parameter that indicates the number of elements written to the output array.
    /// </param>
    /// <param name="outReal">
    /// Output array containing the calculated moving average values. The array must be pre-allocated
    /// with sufficient size to hold the results.
    /// </param>
    /// <returns>
    /// A <see cref="RetCode"/> indicating the success or failure of the operation:
    /// - Success: Calculation completed successfully
    /// - OutOfRangeStartIndex: startIdx is less than 0
    /// - OutOfRangeEndIndex: endIdx is less than 0 or less than startIdx
    /// - BadParam: Invalid parameters (null arrays, invalid time period, or unsupported MA type)
    /// </returns>
    /// <example>
    /// <code>
    /// double[] prices = { 10.0, 12.0, 11.0, 13.0, 14.0, 15.0, 14.0, 13.0 };
    /// double[] smaOutput = new double[prices.Length];
    /// int outBegIdx = 0;
    /// int outNBElement = 0;
    /// 
    /// // Calculate a 3-period Simple Moving Average
    /// RetCode result = TAFunc.MovingAverage(
    ///     0, prices.Length - 1, prices, 3, MAType.Sma,
    ///     ref outBegIdx, ref outNBElement, ref smaOutput);
    /// </code>
    /// </example>
    public static RetCode MovingAverage(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        in MAType optInMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null!)
        {
            return BadParam;
        }

        if (optInTimePeriod is < 1 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        if (optInTimePeriod != 1)
        {
            switch (optInMAType)
            {
                case MAType.Sma:
                    return Sma(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Ema:
                    return Ema(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Wma:
                    return Wma(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Dema:
                    return Dema(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Tema:
                    return Tema(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Trima:
                    return Trima(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Kama:
                    return Kama(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Mama:
                    {
                        double[] dummyBuffer = new double[endIdx - startIdx + 1];
                            
                        return Mama(
                            startIdx,
                            endIdx,
                            inReal,
                            0.5,
                            0.05,
                            ref outBegIdx,
                            ref outNBElement,
                            ref outReal,
                            ref dummyBuffer);
                    }

                case MAType.T3:
                    return T3(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        0.7,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);
            }

            return BadParam;
        }

        int nbElement = endIdx - startIdx + 1;
        outNBElement = nbElement;
        int todayIdx = startIdx;
        int outIdx = 0;
        while (outIdx < nbElement)
        {
            outReal[outIdx] = inReal[todayIdx];
            outIdx++;
            todayIdx++;
        }

        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Calculates the lookback period required for a moving average calculation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The lookback period represents the number of data points needed before the first valid
    /// moving average value can be calculated. This varies depending on the type of moving average
    /// and the specified time period.
    /// </para>
    /// 
    /// <para>
    /// Different moving average types require different amounts of historical data:
    /// - Simple averages (SMA, WMA) need exactly the time period amount
    /// - Exponential averages (EMA, DEMA, TEMA) may need more data for stability
    /// - Adaptive averages (KAMA, MAMA) have their own specific requirements
    /// </para>
    /// 
    /// <para>
    /// For time period of 1, the lookback is always 0 as no historical data is needed.
    /// </para>
    /// </remarks>
    /// <param name="optInTimePeriod">
    /// The number of periods for the moving average calculation.
    /// Valid range: 1 to 100000.
    /// </param>
    /// <param name="optInMAType">
    /// The type of moving average to calculate the lookback for.
    /// </param>
    /// <returns>
    /// The number of data points required before the first moving average value can be calculated.
    /// Returns -1 if the time period is outside the valid range.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when an unsupported MAType is specified.
    /// </exception>
    /// <example>
    /// <code>
    /// // Get lookback for a 20-period EMA
    /// int lookback = TAFunc.MovingAverageLookback(20, MAType.Ema);
    /// // lookback will be 19 (20 - 1)
    /// 
    /// // Get lookback for a 10-period DEMA
    /// int lookbackDema = TAFunc.MovingAverageLookback(10, MAType.Dema);
    /// // lookbackDema will be larger due to the double exponential smoothing
    /// </code>
    /// </example>
    public static int MovingAverageLookback(int optInTimePeriod, MAType optInMAType)
    {
        return optInTimePeriod is < 1 or > 100000
            ? -1
            : optInTimePeriod > 1
                ? optInMAType switch
                {
                    MAType.Sma => SmaLookback(optInTimePeriod),
                    MAType.Ema => EmaLookback(optInTimePeriod),
                    MAType.Wma => WmaLookback(optInTimePeriod),
                    MAType.Dema => DemaLookback(optInTimePeriod),
                    MAType.Tema => TemaLookback(optInTimePeriod),
                    MAType.Trima => TrimaLookback(optInTimePeriod),
                    MAType.Kama => KamaLookback(optInTimePeriod),
                    MAType.Mama => MamaLookback(0.5, 0.05),
                    MAType.T3 => T3Lookback(optInTimePeriod, 0.7),
                    _ => throw new ArgumentOutOfRangeException(nameof(optInMAType), optInMAType, null)
                }
                : 0;
    }
}
