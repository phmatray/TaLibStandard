// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Provides high-level volatility analysis operations with fluent API and sensible defaults.
/// </summary>
/// <remarks>
/// VolatilityAnalysis simplifies the process of analyzing price volatility by wrapping common indicators
/// with pre-configured defaults suitable for most trading scenarios. It supports method chaining
/// for combining multiple volatility analysis operations.
///
/// Common workflows:
/// - Measuring market volatility and risk
/// - Identifying volatility expansions and contractions
/// - Setting stop-loss levels based on volatility
/// - Detecting overbought and oversold conditions using bands
/// </remarks>
public sealed class VolatilityAnalysis
{
    private readonly PriceData _priceData;

    /// <summary>
    /// Initializes a new instance of the VolatilityAnalysis class.
    /// </summary>
    /// <param name="priceData">The price data to analyze.</param>
    public VolatilityAnalysis(PriceData priceData)
    {
        _priceData = priceData;
    }

    /// <summary>
    /// Calculates the Average True Range (ATR) with default period of 14.
    /// </summary>
    /// <returns>A VolatilityAtrResult containing the calculated ATR values.</returns>
    /// <remarks>
    /// ATR measures volatility by calculating the average of the True Range over a specified period.
    /// A 14-period ATR is the standard setting recommended by its creator, J. Welles Wilder.
    ///
    /// Interpretation:
    /// - Higher ATR values indicate higher volatility
    /// - Lower ATR values indicate lower volatility
    /// - ATR is non-directional (doesn't indicate trend direction)
    /// - Rising ATR suggests increasing volatility
    /// - Falling ATR suggests decreasing volatility
    ///
    /// Common uses:
    /// - Stop-loss placement: Often placed at 2-3 ATR from entry
    /// - Position sizing: Inversely proportional to ATR for risk management
    /// - Breakout confirmation: Moves exceeding 1-2 ATR can signal breakouts
    /// </remarks>
    public VolatilityAtrResult Atr()
    {
        return Atr(period: 14);
    }

    /// <summary>
    /// Calculates the Average True Range (ATR) with a custom period.
    /// </summary>
    /// <param name="period">Number of periods for the ATR calculation. Valid range: 1 to 100000. Standard is 14.</param>
    /// <returns>A VolatilityAtrResult containing the calculated ATR values.</returns>
    /// <remarks>
    /// ATR measures market volatility by decomposing the entire range of an asset for that period.
    /// True Range is the greatest of:
    /// - Current High - Current Low
    /// - |Current High - Previous Close|
    /// - |Current Low - Previous Close|
    ///
    /// Key points:
    /// - Shorter periods (5-10) are more reactive to price changes
    /// - Longer periods (20-50) provide smoother volatility readings
    /// - ATR values are in the same units as the price
    /// - ATR does not indicate price direction, only volatility
    ///
    /// Popular variations:
    /// - 7 ATR: Short-term volatility
    /// - 14 ATR: Standard setting
    /// - 21 ATR: Intermediate-term volatility
    /// </remarks>
    public VolatilityAtrResult Atr(int period)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[_priceData.Length];

        RetCode retCode = TAFunc.Atr(
            startIdx: 0,
            endIdx: _priceData.Length - 1,
            inHigh: _priceData.High,
            inLow: _priceData.Low,
            inClose: _priceData.Close,
            optInTimePeriod: period,
            outBegIdx: ref outBegIdx,
            outNBElement: ref outNBElement,
            outReal: ref outReal);

        return new VolatilityAtrResult(retCode, outBegIdx, outNBElement, outReal, period);
    }

    /// <summary>
    /// Calculates Bollinger Bands with default settings (20 period, 2.0 standard deviations, SMA).
    /// </summary>
    /// <returns>A VolatilityBollingerBandsResult containing the upper band, middle band, and lower band values.</returns>
    /// <remarks>
    /// Bollinger Bands create an envelope around price based on standard deviations from a moving average.
    /// The standard settings are 20-period SMA with ±2 standard deviations.
    ///
    /// Interpretation:
    /// - Price touching upper band: Potentially overbought
    /// - Price touching lower band: Potentially oversold
    /// - Bands expanding: Increasing volatility
    /// - Bands contracting: Decreasing volatility (consolidation)
    /// - Bollinger Squeeze: Very narrow bands often precede significant moves
    ///
    /// Common uses:
    /// - Identifying overbought/oversold levels
    /// - Detecting volatility changes
    /// - Spotting potential reversals
    /// - Setting dynamic support/resistance levels
    /// </remarks>
    public VolatilityBollingerBandsResult BollingerBands()
    {
        return BollingerBands(period: 20, nbDevUp: 2.0, nbDevDn: 2.0);
    }

    /// <summary>
    /// Calculates Bollinger Bands with custom settings.
    /// </summary>
    /// <param name="period">Number of periods for the moving average calculation. Valid range: 2 to 100000. Typical: 20.</param>
    /// <param name="nbDevUp">Number of standard deviations for the upper band. Valid range: -3.0e37 to 3.0e37. Typical: 2.0.</param>
    /// <param name="nbDevDn">Number of standard deviations for the lower band. Valid range: -3.0e37 to 3.0e37. Typical: 2.0.</param>
    /// <param name="maType">Type of moving average to use (SMA, EMA, etc.). Default: SMA.</param>
    /// <returns>A VolatilityBollingerBandsResult containing the upper band, middle band, and lower band values.</returns>
    /// <remarks>
    /// Bollinger Bands consist of three lines:
    /// - Upper Band = Moving Average + (Standard Deviation × nbDevUp)
    /// - Middle Band = Moving Average (typically 20-period SMA)
    /// - Lower Band = Moving Average - (Standard Deviation × nbDevDn)
    ///
    /// Key points:
    /// - Shorter periods (10-15) are more reactive and generate more signals
    /// - Longer periods (30-50) are smoother and generate fewer signals
    /// - Higher deviation values (2.5-3.0) create wider bands (fewer touches)
    /// - Lower deviation values (1.5-1.8) create narrower bands (more touches)
    /// - Different MA types (EMA vs SMA) affect band sensitivity
    ///
    /// Advanced concepts:
    /// - Band width can be calculated as (Upper Band - Lower Band) / Middle Band
    /// - %B indicator = (Close - Lower Band) / (Upper Band - Lower Band)
    /// - Price can remain at band extremes during strong trends
    /// - M-top and W-bottom patterns form at the bands
    ///
    /// Popular variations:
    /// - Conservative (20, 2.5, 2.5): Wider bands, fewer signals
    /// - Standard (20, 2.0, 2.0): Balanced approach
    /// - Aggressive (20, 1.5, 1.5): Narrower bands, more signals
    /// - Short-term (10, 1.9, 1.9): For day trading
    /// </remarks>
    public VolatilityBollingerBandsResult BollingerBands(int period, double nbDevUp, double nbDevDn, MAType maType = MAType.Sma)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outRealUpperBand = new double[_priceData.Length];
        double[] outRealMiddleBand = new double[_priceData.Length];
        double[] outRealLowerBand = new double[_priceData.Length];

        RetCode retCode = TAFunc.BollingerBands(
            startIdx: 0,
            endIdx: _priceData.Length - 1,
            inReal: _priceData.Close,
            optInTimePeriod: period,
            optInNbDevUp: nbDevUp,
            optInNbDevDn: nbDevDn,
            optInMAType: maType,
            outBegIdx: ref outBegIdx,
            outNBElement: ref outNBElement,
            outRealUpperBand: ref outRealUpperBand,
            outRealMiddleBand: ref outRealMiddleBand,
            outRealLowerBand: ref outRealLowerBand);

        return new VolatilityBollingerBandsResult(retCode, outBegIdx, outNBElement, outRealUpperBand, outRealMiddleBand, outRealLowerBand, period, nbDevUp, nbDevDn, maType);
    }
}

/// <summary>
/// Represents the result of an Average True Range (ATR) volatility analysis.
/// </summary>
/// <param name="RetCode">The return code indicating the status of the calculation.</param>
/// <param name="BegIdx">The beginning index of the output series.</param>
/// <param name="NBElement">The number of elements in the output series.</param>
/// <param name="Values">The calculated ATR values.</param>
/// <param name="Period">The number of periods used in the ATR calculation.</param>
public sealed record VolatilityAtrResult(
    RetCode RetCode,
    int BegIdx,
    int NBElement,
    double[] Values,
    int Period) : AnalysisResult(RetCode, BegIdx, NBElement)
{
    /// <summary>
    /// Gets the most recent ATR value.
    /// </summary>
    public double Current => NBElement > 0 ? Values[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets a value indicating whether the analysis completed successfully.
    /// </summary>
    public bool IsSuccess => RetCode == RetCode.Success;

    /// <summary>
    /// Gets a value indicating whether volatility is low (current ATR is below the average ATR).
    /// </summary>
    /// <remarks>
    /// This compares the current ATR to the average of all ATR values.
    /// Low volatility may precede significant price movements.
    /// </remarks>
    public bool IsLowVolatility
    {
        get
        {
            if (NBElement == 0) return false;
            double avgAtr = 0;
            for (int i = BegIdx; i < BegIdx + NBElement; i++)
            {
                avgAtr += Values[i];
            }
            avgAtr /= NBElement;
            return Current < avgAtr;
        }
    }

    /// <summary>
    /// Gets a value indicating whether volatility is high (current ATR is above the average ATR).
    /// </summary>
    /// <remarks>
    /// This compares the current ATR to the average of all ATR values.
    /// High volatility indicates increased market activity and risk.
    /// </remarks>
    public bool IsHighVolatility
    {
        get
        {
            if (NBElement == 0) return false;
            double avgAtr = 0;
            for (int i = BegIdx; i < BegIdx + NBElement; i++)
            {
                avgAtr += Values[i];
            }
            avgAtr /= NBElement;
            return Current > avgAtr;
        }
    }
}

/// <summary>
/// Represents the result of a Bollinger Bands volatility analysis.
/// </summary>
/// <param name="RetCode">The return code indicating the status of the calculation.</param>
/// <param name="BegIdx">The beginning index of the output series.</param>
/// <param name="NBElement">The number of elements in the output series.</param>
/// <param name="UpperBand">The calculated upper band values.</param>
/// <param name="MiddleBand">The calculated middle band (moving average) values.</param>
/// <param name="LowerBand">The calculated lower band values.</param>
/// <param name="Period">The number of periods used in the calculation.</param>
/// <param name="NbDevUp">The number of standard deviations used for the upper band.</param>
/// <param name="NbDevDn">The number of standard deviations used for the lower band.</param>
/// <param name="MAType">The type of moving average used.</param>
public sealed record VolatilityBollingerBandsResult(
    RetCode RetCode,
    int BegIdx,
    int NBElement,
    double[] UpperBand,
    double[] MiddleBand,
    double[] LowerBand,
    int Period,
    double NbDevUp,
    double NbDevDn,
    MAType MAType) : AnalysisResult(RetCode, BegIdx, NBElement)
{
    /// <summary>
    /// Gets the most recent upper band value.
    /// </summary>
    public double CurrentUpper => NBElement > 0 ? UpperBand[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets the most recent middle band value.
    /// </summary>
    public double CurrentMiddle => NBElement > 0 ? MiddleBand[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets the most recent lower band value.
    /// </summary>
    public double CurrentLower => NBElement > 0 ? LowerBand[BegIdx + NBElement - 1] : double.NaN;

    /// <summary>
    /// Gets a value indicating whether the analysis completed successfully.
    /// </summary>
    public bool IsSuccess => RetCode == RetCode.Success;

    /// <summary>
    /// Gets the current band width as a percentage of the middle band.
    /// </summary>
    /// <remarks>
    /// Band width = (Upper Band - Lower Band) / Middle Band × 100
    /// Lower values indicate band contraction (low volatility).
    /// Higher values indicate band expansion (high volatility).
    /// </remarks>
    public double BandWidth
    {
        get
        {
            if (NBElement == 0 || CurrentMiddle == 0) return double.NaN;
            return ((CurrentUpper - CurrentLower) / CurrentMiddle) * 100.0;
        }
    }

    /// <summary>
    /// Gets the %B indicator value for the most recent price point.
    /// </summary>
    /// <param name="currentPrice">The current price to evaluate.</param>
    /// <returns>
    /// A value indicating where the price is relative to the bands:
    /// - Above 1.0: Price is above the upper band
    /// - 1.0: Price is at the upper band
    /// - 0.5: Price is at the middle band
    /// - 0.0: Price is at the lower band
    /// - Below 0.0: Price is below the lower band
    /// </returns>
    /// <remarks>
    /// %B = (Close - Lower Band) / (Upper Band - Lower Band)
    /// This indicator quantifies price position relative to the bands.
    /// </remarks>
    public double GetPercentB(double currentPrice)
    {
        if (NBElement == 0) return double.NaN;
        double bandRange = CurrentUpper - CurrentLower;
        if (bandRange == 0) return double.NaN;
        return (currentPrice - CurrentLower) / bandRange;
    }

    /// <summary>
    /// Gets a value indicating whether the bands are contracting (Bollinger Squeeze).
    /// </summary>
    /// <remarks>
    /// Compares current band width to the average band width.
    /// A Bollinger Squeeze (narrow bands) often precedes significant price movements.
    /// </remarks>
    public bool IsSqueeze
    {
        get
        {
            if (NBElement < 2) return false;

            // Calculate average band width over all periods
            double avgBandWidth = 0;
            int count = 0;
            for (int i = BegIdx; i < BegIdx + NBElement; i++)
            {
                double middle = MiddleBand[i];
                if (middle != 0)
                {
                    double width = ((UpperBand[i] - LowerBand[i]) / middle) * 100.0;
                    avgBandWidth += width;
                    count++;
                }
            }

            if (count == 0) return false;
            avgBandWidth /= count;

            // Current band width is significantly below average
            return BandWidth < avgBandWidth * 0.75;
        }
    }

    /// <summary>
    /// Gets a value indicating whether the bands are expanding.
    /// </summary>
    /// <remarks>
    /// Compares current band width to the average band width.
    /// Expanding bands indicate increasing volatility.
    /// </remarks>
    public bool IsExpansion
    {
        get
        {
            if (NBElement < 2) return false;

            // Calculate average band width over all periods
            double avgBandWidth = 0;
            int count = 0;
            for (int i = BegIdx; i < BegIdx + NBElement; i++)
            {
                double middle = MiddleBand[i];
                if (middle != 0)
                {
                    double width = ((UpperBand[i] - LowerBand[i]) / middle) * 100.0;
                    avgBandWidth += width;
                    count++;
                }
            }

            if (count == 0) return false;
            avgBandWidth /= count;

            // Current band width is significantly above average
            return BandWidth > avgBandWidth * 1.25;
        }
    }
}
