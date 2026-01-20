// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Provides high-level momentum analysis operations with fluent API and sensible defaults.
/// </summary>
/// <remarks>
/// MomentumAnalysis simplifies the process of analyzing price momentum by wrapping common indicators
/// with pre-configured defaults suitable for most trading scenarios. It supports method chaining
/// for combining multiple momentum analysis operations.
///
/// Common workflows:
/// - Identifying overbought and oversold conditions
/// - Detecting momentum shifts and divergences
/// - Confirming trend strength through momentum
/// </remarks>
public sealed class MomentumAnalysis
{
    private readonly PriceData _priceData;

    /// <summary>
    /// Initializes a new instance of the MomentumAnalysis class.
    /// </summary>
    /// <param name="priceData">The price data to analyze.</param>
    public MomentumAnalysis(PriceData priceData)
    {
        _priceData = priceData;
    }

    /// <summary>
    /// Calculates the Relative Strength Index (RSI) with default period of 14.
    /// </summary>
    /// <returns>A MomentumRsiResult containing the calculated RSI values.</returns>
    /// <remarks>
    /// The RSI is a momentum oscillator that measures the speed and magnitude of price changes.
    /// A 14-period RSI is the standard setting recommended by its creator, J. Welles Wilder.
    ///
    /// Interpretation:
    /// - RSI above 70: Potentially overbought
    /// - RSI below 30: Potentially oversold
    /// - RSI at 50: Neutral momentum
    /// - RSI crossing above 30: Potential buy signal
    /// - RSI crossing below 70: Potential sell signal
    /// </remarks>
    public MomentumRsiResult Rsi()
    {
        return Rsi(period: 14);
    }

    /// <summary>
    /// Calculates the Relative Strength Index (RSI) with a custom period.
    /// </summary>
    /// <param name="period">Number of periods for the RSI calculation. Valid range: 2 to 100000. Standard is 14.</param>
    /// <returns>A MomentumRsiResult containing the calculated RSI values.</returns>
    /// <remarks>
    /// The RSI compares the magnitude of recent gains to recent losses to determine
    /// overbought and oversold conditions. RSI values range from 0 to 100.
    ///
    /// Key points:
    /// - Shorter periods (9-11) are more sensitive and generate more signals
    /// - Longer periods (21-25) are smoother and generate fewer signals
    /// - Divergences between price and RSI can indicate potential reversals
    /// - RSI can remain in overbought/oversold territory for extended periods during strong trends
    ///
    /// Common uses:
    /// - 9 RSI: Short-term trading
    /// - 14 RSI: Standard setting
    /// - 25 RSI: Longer-term analysis
    /// </remarks>
    public MomentumRsiResult Rsi(int period)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[_priceData.Length];

        RetCode retCode = TAFunc.Rsi(
            startIdx: 0,
            endIdx: _priceData.Length - 1,
            inReal: _priceData.Close,
            optInTimePeriod: period,
            outBegIdx: ref outBegIdx,
            outNBElement: ref outNBElement,
            outReal: ref outReal);

        return new MomentumRsiResult(retCode, outBegIdx, outNBElement, outReal, period);
    }

    /// <summary>
    /// Calculates the Moving Average Convergence Divergence (MACD) with default periods (12, 26, 9).
    /// </summary>
    /// <returns>A MomentumMacdResult containing the calculated MACD line, signal line, and histogram values.</returns>
    /// <remarks>
    /// MACD is a trend-following momentum indicator that shows the relationship between two moving averages.
    /// The standard settings are 12-period fast EMA, 26-period slow EMA, and 9-period signal line.
    ///
    /// Interpretation:
    /// - MACD line crosses above signal line: Bullish signal
    /// - MACD line crosses below signal line: Bearish signal
    /// - MACD crosses above zero: Bullish momentum
    /// - MACD crosses below zero: Bearish momentum
    /// - Histogram expanding: Increasing momentum
    /// - Histogram contracting: Decreasing momentum
    /// </remarks>
    public MomentumMacdResult Macd()
    {
        return Macd(fastPeriod: 12, slowPeriod: 26, signalPeriod: 9);
    }

    /// <summary>
    /// Calculates the Moving Average Convergence Divergence (MACD) with custom periods.
    /// </summary>
    /// <param name="fastPeriod">Number of periods for the fast EMA. Valid range: 2 to 100000. Typical: 12.</param>
    /// <param name="slowPeriod">Number of periods for the slow EMA. Valid range: 2 to 100000. Typical: 26.</param>
    /// <param name="signalPeriod">Number of periods for the signal line EMA. Valid range: 1 to 100000. Typical: 9.</param>
    /// <returns>A MomentumMacdResult containing the calculated MACD line, signal line, and histogram values.</returns>
    /// <remarks>
    /// MACD consists of three components:
    /// - MACD Line = Fast EMA - Slow EMA
    /// - Signal Line = EMA of MACD Line
    /// - MACD Histogram = MACD Line - Signal Line
    ///
    /// Key points:
    /// - Shorter periods make MACD more sensitive and generate more signals
    /// - Longer periods make MACD smoother and generate fewer signals
    /// - Divergences between price and MACD can indicate potential reversals
    /// - MACD works best in trending markets
    ///
    /// Popular variations:
    /// - Fast settings (5, 13, 5): More responsive, more false signals
    /// - Standard settings (12, 26, 9): Balanced approach
    /// - Slow settings (19, 39, 9): More reliable, slower to react
    /// </remarks>
    public MomentumMacdResult Macd(int fastPeriod, int slowPeriod, int signalPeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outMACD = new double[_priceData.Length];
        double[] outMACDSignal = new double[_priceData.Length];
        double[] outMACDHist = new double[_priceData.Length];

        RetCode retCode = TAFunc.Macd(
            startIdx: 0,
            endIdx: _priceData.Length - 1,
            inReal: _priceData.Close,
            optInFastPeriod: fastPeriod,
            optInSlowPeriod: slowPeriod,
            optInSignalPeriod: signalPeriod,
            outBegIdx: ref outBegIdx,
            outNBElement: ref outNBElement,
            outMACD: ref outMACD,
            outMACDSignal: ref outMACDSignal,
            outMACDHist: ref outMACDHist);

        return new MomentumMacdResult(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist, fastPeriod, slowPeriod, signalPeriod);
    }

    /// <summary>
    /// Calculates the Stochastic Oscillator with default periods (14, 3, 3).
    /// </summary>
    /// <returns>A MomentumStochResult containing the calculated Slow %K and Slow %D values.</returns>
    /// <remarks>
    /// The Stochastic Oscillator is a momentum indicator comparing closing price to the price range.
    /// The standard settings are 14-period %K, 3-period Slow %K smoothing, and 3-period %D.
    ///
    /// Interpretation:
    /// - Stochastic above 80: Potentially overbought
    /// - Stochastic below 20: Potentially oversold
    /// - %K crosses above %D: Bullish signal
    /// - %K crosses below %D: Bearish signal
    /// - Divergences between price and Stochastic can indicate reversals
    /// </remarks>
    public MomentumStochResult Stoch()
    {
        return Stoch(fastKPeriod: 14, slowKPeriod: 3, slowDPeriod: 3);
    }

    /// <summary>
    /// Calculates the Stochastic Oscillator with custom periods.
    /// </summary>
    /// <param name="fastKPeriod">Number of periods for %K calculation. Valid range: 1 to 100000. Typical: 14.</param>
    /// <param name="slowKPeriod">Smoothing periods for %K (to create Slow %K). Valid range: 1 to 100000. Typical: 3.</param>
    /// <param name="slowDPeriod">Number of periods for %D calculation. Valid range: 1 to 100000. Typical: 3.</param>
    /// <returns>A MomentumStochResult containing the calculated Slow %K and Slow %D values.</returns>
    /// <remarks>
    /// The Stochastic Oscillator calculation:
    /// - Fast %K = 100 × (Close - Lowest Low) / (Highest High - Lowest Low)
    /// - Slow %K = Moving Average of Fast %K
    /// - Slow %D = Moving Average of Slow %K
    ///
    /// Key points:
    /// - Values range from 0 to 100
    /// - Requires High, Low, and Close price data
    /// - More responsive than RSI, generating more signals
    /// - Works well in range-bound markets
    ///
    /// Popular variations:
    /// - Fast Stochastic (5, 3, 3): Very sensitive, many signals
    /// - Standard Stochastic (14, 3, 3): Balanced approach
    /// - Slow Stochastic (21, 5, 5): Smoother, fewer signals
    /// </remarks>
    public MomentumStochResult Stoch(int fastKPeriod, int slowKPeriod, int slowDPeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outSlowK = new double[_priceData.Length];
        double[] outSlowD = new double[_priceData.Length];

        RetCode retCode = TAFunc.Stoch(
            startIdx: 0,
            endIdx: _priceData.Length - 1,
            inHigh: _priceData.High,
            inLow: _priceData.Low,
            inClose: _priceData.Close,
            optInFastKPeriod: fastKPeriod,
            optInSlowKPeriod: slowKPeriod,
            optInSlowKMAType: MAType.Sma,
            optInSlowDPeriod: slowDPeriod,
            optInSlowDMAType: MAType.Sma,
            outBegIdx: ref outBegIdx,
            outNBElement: ref outNBElement,
            outSlowK: ref outSlowK,
            outSlowD: ref outSlowD);

        return new MomentumStochResult(retCode, outBegIdx, outNBElement, outSlowK, outSlowD, fastKPeriod, slowKPeriod, slowDPeriod);
    }
}

/// <summary>
/// Represents the result of a Relative Strength Index (RSI) momentum analysis.
/// </summary>
/// <param name="RetCode">The return code indicating the status of the calculation.</param>
/// <param name="BegIdx">The beginning index of the output series.</param>
/// <param name="NBElement">The number of elements in the output series.</param>
/// <param name="Values">The calculated RSI values.</param>
/// <param name="Period">The number of periods used in the RSI calculation.</param>
public sealed record MomentumRsiResult(
    RetCode RetCode,
    int BegIdx,
    int NBElement,
    double[] Values,
    int Period) : AnalysisResult(RetCode, BegIdx, NBElement)
{
    /// <summary>
    /// Gets the most recent RSI value.
    /// </summary>
    public double Current => NBElement > 0 ? Values[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets a value indicating whether the analysis completed successfully.
    /// </summary>
    public bool IsSuccess => RetCode == RetCode.Success;

    /// <summary>
    /// Gets a value indicating whether the RSI is in overbought territory (above 70).
    /// </summary>
    public bool IsOverbought => Current > 70.0;

    /// <summary>
    /// Gets a value indicating whether the RSI is in oversold territory (below 30).
    /// </summary>
    public bool IsOversold => Current < 30.0;

    /// <summary>
    /// Gets a value indicating whether the RSI is neutral (between 40 and 60).
    /// </summary>
    public bool IsNeutral => Current >= 40.0 && Current <= 60.0;
}

/// <summary>
/// Represents the result of a Moving Average Convergence Divergence (MACD) momentum analysis.
/// </summary>
/// <param name="RetCode">The return code indicating the status of the calculation.</param>
/// <param name="BegIdx">The beginning index of the output series.</param>
/// <param name="NBElement">The number of elements in the output series.</param>
/// <param name="MacdLine">The calculated MACD line values (fast EMA - slow EMA).</param>
/// <param name="SignalLine">The calculated signal line values (EMA of MACD line).</param>
/// <param name="Histogram">The calculated histogram values (MACD line - signal line).</param>
/// <param name="FastPeriod">The number of periods used for the fast EMA.</param>
/// <param name="SlowPeriod">The number of periods used for the slow EMA.</param>
/// <param name="SignalPeriod">The number of periods used for the signal line.</param>
public sealed record MomentumMacdResult(
    RetCode RetCode,
    int BegIdx,
    int NBElement,
    double[] MacdLine,
    double[] SignalLine,
    double[] Histogram,
    int FastPeriod,
    int SlowPeriod,
    int SignalPeriod) : AnalysisResult(RetCode, BegIdx, NBElement)
{
    /// <summary>
    /// Gets the most recent MACD line value.
    /// </summary>
    public double CurrentMacd => NBElement > 0 ? MacdLine[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets the most recent signal line value.
    /// </summary>
    public double CurrentSignal => NBElement > 0 ? SignalLine[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets the most recent histogram value.
    /// </summary>
    public double CurrentHistogram => NBElement > 0 ? Histogram[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets a value indicating whether the analysis completed successfully.
    /// </summary>
    public bool IsSuccess => RetCode == RetCode.Success;

    /// <summary>
    /// Gets a value indicating whether the MACD line is above the signal line (bullish).
    /// </summary>
    public bool IsBullish => CurrentMacd > CurrentSignal;

    /// <summary>
    /// Gets a value indicating whether the MACD line is below the signal line (bearish).
    /// </summary>
    public bool IsBearish => CurrentMacd < CurrentSignal;

    /// <summary>
    /// Gets a value indicating whether the MACD line is above zero (positive momentum).
    /// </summary>
    public bool IsPositiveMomentum => CurrentMacd > 0.0;

    /// <summary>
    /// Gets a value indicating whether the MACD line is below zero (negative momentum).
    /// </summary>
    public bool IsNegativeMomentum => CurrentMacd < 0.0;
}

/// <summary>
/// Represents the result of a Stochastic Oscillator momentum analysis.
/// </summary>
/// <param name="RetCode">The return code indicating the status of the calculation.</param>
/// <param name="BegIdx">The beginning index of the output series.</param>
/// <param name="NBElement">The number of elements in the output series.</param>
/// <param name="SlowK">The calculated Slow %K values (smoothed %K).</param>
/// <param name="SlowD">The calculated Slow %D values (moving average of Slow %K).</param>
/// <param name="FastKPeriod">The number of periods used for %K calculation.</param>
/// <param name="SlowKPeriod">The smoothing periods for %K.</param>
/// <param name="SlowDPeriod">The number of periods used for %D calculation.</param>
public sealed record MomentumStochResult(
    RetCode RetCode,
    int BegIdx,
    int NBElement,
    double[] SlowK,
    double[] SlowD,
    int FastKPeriod,
    int SlowKPeriod,
    int SlowDPeriod) : AnalysisResult(RetCode, BegIdx, NBElement)
{
    /// <summary>
    /// Gets the most recent Slow %K value.
    /// </summary>
    public double CurrentK => NBElement > 0 ? SlowK[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets the most recent Slow %D value.
    /// </summary>
    public double CurrentD => NBElement > 0 ? SlowD[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets a value indicating whether the analysis completed successfully.
    /// </summary>
    public bool IsSuccess => RetCode == RetCode.Success;

    /// <summary>
    /// Gets a value indicating whether the Stochastic is in overbought territory (above 80).
    /// </summary>
    public bool IsOverbought => CurrentK > 80.0;

    /// <summary>
    /// Gets a value indicating whether the Stochastic is in oversold territory (below 20).
    /// </summary>
    public bool IsOversold => CurrentK < 20.0;

    /// <summary>
    /// Gets a value indicating whether %K is above %D (bullish).
    /// </summary>
    public bool IsBullish => CurrentK > CurrentD;

    /// <summary>
    /// Gets a value indicating whether %K is below %D (bearish).
    /// </summary>
    public bool IsBearish => CurrentK < CurrentD;
}
