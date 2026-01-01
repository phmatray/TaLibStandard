// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

/// <summary>
/// Provides centralized validation methods for technical analysis indicators.
/// </summary>
/// <remarks>
/// This helper class consolidates repetitive validation logic that appears across
/// 100+ indicator functions, reducing code duplication and ensuring consistent
/// validation behavior throughout the library.
/// </remarks>
public static class ValidationHelper
{
    /// <summary>
    /// The minimum allowed period for most indicators.
    /// </summary>
    public const int MinPeriod = 2;

    /// <summary>
    /// The maximum allowed period for all indicators.
    /// </summary>
    public const int MaxPeriod = 100000;
    /// <summary>
    /// Validates the index range for indicator calculations.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <returns>
    /// <see cref="RetCode.Success"/> if validation passes;
    /// <see cref="RetCode.OutOfRangeStartIndex"/> if startIdx is negative;
    /// <see cref="RetCode.OutOfRangeEndIndex"/> if endIdx is invalid.
    /// </returns>
    public static RetCode ValidateIndexRange(int startIdx, int endIdx)
    {
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        return Success;
    }

    /// <summary>
    /// Validates a time period parameter is within acceptable range.
    /// </summary>
    /// <param name="period">The time period to validate.</param>
    /// <param name="minPeriod">The minimum allowed period (default: 2).</param>
    /// <param name="maxPeriod">The maximum allowed period (default: 100000).</param>
    /// <returns>
    /// <see cref="RetCode.Success"/> if the period is within range;
    /// <see cref="RetCode.BadParam"/> otherwise.
    /// </returns>
    public static RetCode ValidatePeriodRange(int period, int minPeriod = 2, int maxPeriod = 100000)
    {
        return period < minPeriod || period > maxPeriod
            ? BadParam
            : Success;
    }

    /// <summary>
    /// Validates that input and output arrays are not null.
    /// </summary>
    /// <param name="arrays">Variable number of arrays to validate.</param>
    /// <returns>
    /// <see cref="RetCode.Success"/> if all arrays are non-null;
    /// <see cref="RetCode.BadParam"/> if any array is null.
    /// </returns>
    public static RetCode ValidateArrays(params double[]?[] arrays)
    {
        return arrays.Any(array => array == null)
            ? BadParam
            : Success;
    }

    /// <summary>
    /// Validates OHLC (Open, High, Low, Close) input arrays for candle-based indicators.
    /// </summary>
    /// <param name="open">Array of opening prices.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>
    /// <see cref="RetCode.Success"/> if all OHLC arrays are non-null;
    /// <see cref="RetCode.BadParam"/> if any array is null.
    /// </returns>
    public static RetCode ValidateOhlcArrays(
        double[]? open,
        double[]? high,
        double[]? low,
        double[]? close)
    {
        return open == null || high == null || low == null || close == null
            ? BadParam
            : Success;
    }

    /// <summary>
    /// Validates OHLCV (Open, High, Low, Close, Volume) input arrays.
    /// </summary>
    /// <param name="open">Array of opening prices.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of volume data.</param>
    /// <returns>
    /// <see cref="RetCode.Success"/> if all OHLCV arrays are non-null;
    /// <see cref="RetCode.BadParam"/> if any array is null.
    /// </returns>
    public static RetCode ValidateOhlcvArrays(
        double[]? open,
        double[]? high,
        double[]? low,
        double[]? close,
        double[]? volume)
    {
        return open == null || high == null || low == null || close == null || volume == null
            ? BadParam 
            : Success;
    }

    /// <summary>
    /// Performs comprehensive validation for single-input indicators.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="inReal">Input array of price data.</param>
    /// <param name="outReal">Output array for indicator values.</param>
    /// <param name="optInTimePeriod">Optional time period parameter.</param>
    /// <param name="minPeriod">Minimum allowed period (default: 2).</param>
    /// <param name="maxPeriod">Maximum allowed period (default: 100000).</param>
    /// <returns>
    /// <see cref="RetCode.Success"/> if all validations pass;
    /// appropriate error code otherwise.
    /// </returns>
    public static RetCode ValidateSingleInputIndicator(
        int startIdx,
        int endIdx,
        double[]? inReal,
        double[]? outReal,
        int? optInTimePeriod = null,
        int minPeriod = 2,
        int maxPeriod = 100000)
    {
        RetCode indexCheck = ValidateIndexRange(startIdx, endIdx);
        if (indexCheck != Success)
        {
            return indexCheck;
        }

        RetCode arrayCheck = ValidateArrays(inReal, outReal);
        if (arrayCheck != Success)
        {
            return arrayCheck;
        }

        if (optInTimePeriod.HasValue)
        {
            return ValidatePeriodRange(optInTimePeriod.Value, minPeriod, maxPeriod);
        }

        return Success;
    }

    /// <summary>
    /// Executes multiple validation functions sequentially, returning the first error encountered.
    /// </summary>
    /// <param name="validations">One or more validation functions that return RetCode.</param>
    /// <returns>
    /// <see cref="RetCode.Success"/> if all validations pass;
    /// the first non-Success RetCode encountered otherwise.
    /// </returns>
    /// <remarks>
    /// This method consolidates the common pattern of running multiple validation checks
    /// and returning early on the first failure. It reduces boilerplate code across
    /// indicator functions that typically perform 3-5 sequential validation checks.
    ///
    /// Example usage:
    /// <code>
    /// RetCode validation = ValidationHelper.ValidateAll(
    ///     () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
    ///     () => ValidationHelper.ValidateArrays(inReal, outReal),
    ///     () => ValidationHelper.ValidatePeriodRange(optInTimePeriod)
    /// );
    /// if (validation != Success) return validation;
    /// </code>
    /// </remarks>
    public static RetCode ValidateAll(params Func<RetCode>[] validations)
    {
        foreach (var validate in validations)
        {
            RetCode result = validate();
            if (result != Success)
            {
                return result;
            }
        }

        return Success;
    }

    /// <summary>
    /// Adjusts the start index based on lookback period and validates the calculation range.
    /// </summary>
    /// <param name="lookbackTotal">The total lookback period required.</param>
    /// <param name="startIdx">The starting index (will be adjusted if needed).</param>
    /// <param name="endIdx">The ending index.</param>
    /// <param name="outBegIdx">Output beginning index (set to 0 if range invalid).</param>
    /// <param name="outNBElement">Output number of elements (set to 0 if range invalid).</param>
    /// <returns>
    /// <c>true</c> if calculation should proceed;
    /// <c>false</c> if the range is invalid and calculation should be skipped.
    /// </returns>
    public static bool PrepareCalculationRange(
        int lookbackTotal,
        ref int startIdx,
        int endIdx,
        ref int outBegIdx,
        ref int outNBElement)
    {
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return false;
        }

        return true;
    }

    /// <summary>
    /// Validates a lookback period and returns the adjusted lookback value with optional modifications.
    /// </summary>
    /// <param name="period">The time period to validate.</param>
    /// <param name="adjustment">Value to add to the period (e.g., -1 for period-1 lookback). Default: 0.</param>
    /// <param name="minPeriod">The minimum allowed period. Default: <see cref="MinPeriod"/> (2).</param>
    /// <param name="maxPeriod">The maximum allowed period. Default: <see cref="MaxPeriod"/> (100000).</param>
    /// <param name="unstablePeriod">Optional unstable period function ID to add to the result.</param>
    /// <returns>
    /// -1 if the period is out of range;
    /// the validated and adjusted lookback value otherwise.
    /// </returns>
    /// <remarks>
    /// This method consolidates the common lookback validation pattern used across 40+ indicators.
    /// It handles several common cases:
    /// - Simple period validation: ValidateLookback(period)
    /// - With adjustment: ValidateLookback(period, adjustment: -1)
    /// - With min period: ValidateLookback(period, minPeriod: 1)
    /// - With unstable period: ValidateLookback(period, unstablePeriod: FuncUnstId.Ema)
    /// - Complex: ValidateLookback(period, adjustment: -1, unstablePeriod: FuncUnstId.Ema)
    ///
    /// Examples:
    /// <code>
    /// // CCI: period - 1
    /// public static int CciLookback(int optInTimePeriod) =>
    ///     ValidationHelper.ValidateLookback(optInTimePeriod, adjustment: -1);
    ///
    /// // SMA: period (no adjustment)
    ///public static int SmaLookback(int optInTimePeriod) =>
    ///     ValidationHelper.ValidateLookback(optInTimePeriod, minPeriod: 1);
    ///
    /// // EMA: period - 1 + unstable period
    /// public static int EmaLookback(int optInTimePeriod) =>
    ///     ValidationHelper.ValidateLookback(optInTimePeriod, adjustment: -1,
    ///         unstablePeriod: FuncUnstId.Ema);
    /// </code>
    /// </remarks>
    public static int ValidateLookback(
        int period,
        int adjustment = 0,
        int minPeriod = MinPeriod,
        int maxPeriod = MaxPeriod,
        FuncUnstId? unstablePeriod = null)
    {
        if (period < minPeriod || period > maxPeriod)
        {
            return -1;
        }

        int result = period + adjustment;

        if (unstablePeriod.HasValue)
        {
            result += (int)TACore.Globals.UnstablePeriod[unstablePeriod.Value];
        }

        return result;
    }

    /// <summary>
    /// Validates a lookback period parameter and returns the adjusted lookback value.
    /// </summary>
    /// <param name="period">The time period to validate.</param>
    /// <param name="minPeriod">The minimum allowed period (default: 2).</param>
    /// <param name="maxPeriod">The maximum allowed period (default: 100000).</param>
    /// <returns>
    /// -1 if the period is out of range;
    /// the validated period value otherwise.
    /// </returns>
    [Obsolete("Use ValidateLookback() instead for better flexibility and consistency.")]
    public static int ValidateLookbackPeriod(int period, int minPeriod = 2, int maxPeriod = 100000)
    {
        return period < minPeriod || period > maxPeriod ? -1 : period;
    }
}
