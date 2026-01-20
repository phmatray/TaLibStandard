// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Provides high-level trend analysis operations with fluent API and sensible defaults.
/// </summary>
/// <remarks>
/// TrendAnalysis simplifies the process of analyzing price trends by wrapping common indicators
/// with pre-configured defaults suitable for most trading scenarios. It supports method chaining
/// for combining multiple trend analysis operations.
///
/// Common workflows:
/// - Identifying trend direction and strength
/// - Detecting trend changes and reversals
/// - Confirming trend momentum
/// </remarks>
public sealed class TrendAnalysis
{
    private readonly PriceData _priceData;

    /// <summary>
    /// Initializes a new instance of the TrendAnalysis class.
    /// </summary>
    /// <param name="priceData">The price data to analyze.</param>
    public TrendAnalysis(PriceData priceData)
    {
        _priceData = priceData;
    }

    /// <summary>
    /// Calculates the Exponential Moving Average (EMA) with default period of 20.
    /// </summary>
    /// <returns>A TrendEmaResult containing the calculated EMA values.</returns>
    /// <remarks>
    /// The EMA reacts more quickly to recent price changes than the SMA.
    /// A 20-period EMA is commonly used for short to medium-term trend identification.
    /// Price above EMA suggests an uptrend; price below EMA suggests a downtrend.
    /// </remarks>
    public TrendEmaResult Ema()
    {
        return Ema(period: 20);
    }

    /// <summary>
    /// Calculates the Exponential Moving Average (EMA) with a custom period.
    /// </summary>
    /// <param name="period">Number of periods for the EMA calculation. Common values: 12, 20, 26, 50, 200.</param>
    /// <returns>A TrendEmaResult containing the calculated EMA values.</returns>
    /// <remarks>
    /// The EMA gives more weight to recent prices, making it more responsive to price changes.
    /// Shorter periods (12-20) are more responsive; longer periods (50-200) are smoother.
    ///
    /// Common uses:
    /// - 12 EMA: Very short-term trend
    /// - 20 EMA: Short-term trend
    /// - 50 EMA: Intermediate trend
    /// - 200 EMA: Long-term trend
    /// </remarks>
    public TrendEmaResult Ema(int period)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[_priceData.Length];

        RetCode retCode = TAFunc.Ema(
            startIdx: 0,
            endIdx: _priceData.Length - 1,
            inReal: _priceData.Close,
            optInTimePeriod: period,
            outBegIdx: ref outBegIdx,
            outNBElement: ref outNBElement,
            outReal: ref outReal);

        return new TrendEmaResult(retCode, outBegIdx, outNBElement, outReal, period);
    }

    /// <summary>
    /// Calculates the Simple Moving Average (SMA) with default period of 50.
    /// </summary>
    /// <returns>A TrendSmaResult containing the calculated SMA values.</returns>
    /// <remarks>
    /// The SMA provides a smooth average of prices, less sensitive to short-term fluctuations.
    /// A 50-period SMA is commonly used for medium-term trend identification.
    /// Price above SMA suggests an uptrend; price below SMA suggests a downtrend.
    /// </remarks>
    public TrendSmaResult Sma()
    {
        return Sma(period: 50);
    }

    /// <summary>
    /// Calculates the Simple Moving Average (SMA) with a custom period.
    /// </summary>
    /// <param name="period">Number of periods for the SMA calculation. Common values: 20, 50, 100, 200.</param>
    /// <returns>A TrendSmaResult containing the calculated SMA values.</returns>
    /// <remarks>
    /// The SMA calculates the arithmetic mean of prices over the specified period.
    /// It provides smoother trend identification but lags more than the EMA.
    ///
    /// Common uses:
    /// - 20 SMA: Short-term trend
    /// - 50 SMA: Medium-term trend
    /// - 100 SMA: Intermediate trend
    /// - 200 SMA: Long-term trend (major support/resistance)
    ///
    /// Popular patterns:
    /// - Golden Cross: 50 SMA crosses above 200 SMA (bullish)
    /// - Death Cross: 50 SMA crosses below 200 SMA (bearish)
    /// </remarks>
    public TrendSmaResult Sma(int period)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[_priceData.Length];

        RetCode retCode = TAFunc.Sma(
            startIdx: 0,
            endIdx: _priceData.Length - 1,
            inReal: _priceData.Close,
            optInTimePeriod: period,
            outBegIdx: ref outBegIdx,
            outNBElement: ref outNBElement,
            outReal: ref outReal);

        return new TrendSmaResult(retCode, outBegIdx, outNBElement, outReal, period);
    }

    /// <summary>
    /// Calculates the Average Directional Index (ADX) with default period of 14.
    /// </summary>
    /// <returns>A TrendAdxResult containing the calculated ADX values.</returns>
    /// <remarks>
    /// The ADX measures trend strength regardless of direction.
    /// A 14-period ADX is the standard setting recommended by its creator, Welles Wilder.
    ///
    /// Interpretation:
    /// - ADX below 20: Weak or no trend (range-bound market)
    /// - ADX 20-25: Emerging trend
    /// - ADX above 25: Strong trend
    /// - ADX above 40: Very strong trend
    /// - ADX above 50: Extremely strong trend
    /// </remarks>
    public TrendAdxResult Adx()
    {
        return Adx(period: 14);
    }

    /// <summary>
    /// Calculates the Average Directional Index (ADX) with a custom period.
    /// </summary>
    /// <param name="period">Number of periods for the ADX calculation. Valid range: 2 to 100000. Standard is 14.</param>
    /// <returns>A TrendAdxResult containing the calculated ADX values.</returns>
    /// <remarks>
    /// The ADX quantifies trend strength without indicating direction.
    /// It requires High, Low, and Close price data.
    ///
    /// Key points:
    /// - Higher ADX values indicate stronger trends
    /// - Lower ADX values indicate weaker trends or consolidation
    /// - ADX does not indicate if the trend is bullish or bearish
    /// - Rising ADX suggests strengthening trend; falling ADX suggests weakening trend
    /// - Crossovers of ADX with threshold levels (20, 25, 40) provide trading signals
    /// </remarks>
    public TrendAdxResult Adx(int period)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[_priceData.Length];

        RetCode retCode = TAFunc.Adx(
            startIdx: 0,
            endIdx: _priceData.Length - 1,
            inHigh: _priceData.High,
            inLow: _priceData.Low,
            inClose: _priceData.Close,
            optInTimePeriod: period,
            outBegIdx: ref outBegIdx,
            outNBElement: ref outNBElement,
            outReal: ref outReal);

        return new TrendAdxResult(retCode, outBegIdx, outNBElement, outReal, period);
    }
}

/// <summary>
/// Represents the result of an Exponential Moving Average (EMA) trend analysis.
/// </summary>
/// <param name="RetCode">The return code indicating the status of the calculation.</param>
/// <param name="BegIdx">The beginning index of the output series.</param>
/// <param name="NBElement">The number of elements in the output series.</param>
/// <param name="Values">The calculated EMA values.</param>
/// <param name="Period">The number of periods used in the EMA calculation.</param>
public sealed record TrendEmaResult(
    RetCode RetCode,
    int BegIdx,
    int NBElement,
    double[] Values,
    int Period) : AnalysisResult(RetCode, BegIdx, NBElement)
{
    /// <summary>
    /// Gets the most recent EMA value.
    /// </summary>
    public double Current => NBElement > 0 ? Values[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets a value indicating whether the analysis completed successfully.
    /// </summary>
    public bool IsSuccess => RetCode == RetCode.Success;
}

/// <summary>
/// Represents the result of a Simple Moving Average (SMA) trend analysis.
/// </summary>
/// <param name="RetCode">The return code indicating the status of the calculation.</param>
/// <param name="BegIdx">The beginning index of the output series.</param>
/// <param name="NBElement">The number of elements in the output series.</param>
/// <param name="Values">The calculated SMA values.</param>
/// <param name="Period">The number of periods used in the SMA calculation.</param>
public sealed record TrendSmaResult(
    RetCode RetCode,
    int BegIdx,
    int NBElement,
    double[] Values,
    int Period) : AnalysisResult(RetCode, BegIdx, NBElement)
{
    /// <summary>
    /// Gets the most recent SMA value.
    /// </summary>
    public double Current => NBElement > 0 ? Values[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets a value indicating whether the analysis completed successfully.
    /// </summary>
    public bool IsSuccess => RetCode == RetCode.Success;
}

/// <summary>
/// Represents the result of an Average Directional Index (ADX) trend analysis.
/// </summary>
/// <param name="RetCode">The return code indicating the status of the calculation.</param>
/// <param name="BegIdx">The beginning index of the output series.</param>
/// <param name="NBElement">The number of elements in the output series.</param>
/// <param name="Values">The calculated ADX values.</param>
/// <param name="Period">The number of periods used in the ADX calculation.</param>
public sealed record TrendAdxResult(
    RetCode RetCode,
    int BegIdx,
    int NBElement,
    double[] Values,
    int Period) : AnalysisResult(RetCode, BegIdx, NBElement)
{
    /// <summary>
    /// Gets the most recent ADX value.
    /// </summary>
    public double Current => NBElement > 0 ? Values[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets a value indicating whether the analysis completed successfully.
    /// </summary>
    public bool IsSuccess => RetCode == RetCode.Success;

    /// <summary>
    /// Gets a value indicating whether the trend is weak (ADX below 20).
    /// </summary>
    public bool IsWeakTrend => Current < 20.0;

    /// <summary>
    /// Gets a value indicating whether the trend is emerging (ADX between 20 and 25).
    /// </summary>
    public bool IsEmergingTrend => Current >= 20.0 && Current < 25.0;

    /// <summary>
    /// Gets a value indicating whether the trend is strong (ADX above 25).
    /// </summary>
    public bool IsStrongTrend => Current >= 25.0;

    /// <summary>
    /// Gets a value indicating whether the trend is very strong (ADX above 40).
    /// </summary>
    public bool IsVeryStrongTrend => Current >= 40.0;
}
