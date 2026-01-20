// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Provides a unified entry point for all technical analysis operations with a fluent API.
/// </summary>
/// <remarks>
/// TechnicalAnalyzer orchestrates access to trend, momentum, and volatility analysis operations,
/// enabling a fluent and intuitive workflow for comprehensive technical analysis.
/// This class serves as the main facade for the high-level technical analysis API.
///
/// Common workflows:
/// - Analyze price trends using moving averages and directional indicators
/// - Assess momentum with RSI, MACD, and Stochastic oscillators
/// - Measure volatility with ATR and Bollinger Bands
/// - Combine multiple indicators for comprehensive market analysis
///
/// Example usage:
/// <code>
/// var priceData = PriceData.FromOHLC(open, high, low, close);
/// var analyzer = new TechnicalAnalyzer(priceData);
///
/// // Analyze trend
/// var ema = analyzer.Trend.Ema();
/// var sma = analyzer.Trend.Sma(period: 50);
///
/// // Analyze momentum
/// var rsi = analyzer.Momentum.Rsi();
/// var macd = analyzer.Momentum.Macd();
///
/// // Analyze volatility
/// var atr = analyzer.Volatility.Atr();
/// var bb = analyzer.Volatility.BollingerBands();
/// </code>
/// </remarks>
public sealed class TechnicalAnalyzer
{
    private readonly PriceData _priceData;
    private TrendAnalysis? _trendAnalysis;
    private MomentumAnalysis? _momentumAnalysis;
    private VolatilityAnalysis? _volatilityAnalysis;

    /// <summary>
    /// Initializes a new instance of the TechnicalAnalyzer class.
    /// </summary>
    /// <param name="priceData">The price data to analyze.</param>
    /// <remarks>
    /// The price data should contain sufficient historical data points for the indicators
    /// you plan to calculate. Most indicators require a minimum number of periods before
    /// they can produce meaningful results.
    /// </remarks>
    public TechnicalAnalyzer(PriceData priceData)
    {
        _priceData = priceData;
    }

    /// <summary>
    /// Gets the trend analysis operations for the price data.
    /// </summary>
    /// <remarks>
    /// Provides access to trend indicators including:
    /// - Exponential Moving Average (EMA)
    /// - Simple Moving Average (SMA)
    /// - Average Directional Index (ADX)
    ///
    /// Use trend analysis to identify market direction, trend strength, and potential reversals.
    /// </remarks>
    public TrendAnalysis Trend
    {
        get
        {
            _trendAnalysis ??= new TrendAnalysis(_priceData);
            return _trendAnalysis;
        }
    }

    /// <summary>
    /// Gets the momentum analysis operations for the price data.
    /// </summary>
    /// <remarks>
    /// Provides access to momentum indicators including:
    /// - Relative Strength Index (RSI)
    /// - Moving Average Convergence Divergence (MACD)
    /// - Stochastic Oscillator
    ///
    /// Use momentum analysis to identify overbought/oversold conditions, momentum shifts,
    /// and potential entry/exit points.
    /// </remarks>
    public MomentumAnalysis Momentum
    {
        get
        {
            _momentumAnalysis ??= new MomentumAnalysis(_priceData);
            return _momentumAnalysis;
        }
    }

    /// <summary>
    /// Gets the volatility analysis operations for the price data.
    /// </summary>
    /// <remarks>
    /// Provides access to volatility indicators including:
    /// - Average True Range (ATR)
    /// - Bollinger Bands
    ///
    /// Use volatility analysis to measure market risk, set stop-loss levels,
    /// and identify potential breakout opportunities.
    /// </remarks>
    public VolatilityAnalysis Volatility
    {
        get
        {
            _volatilityAnalysis ??= new VolatilityAnalysis(_priceData);
            return _volatilityAnalysis;
        }
    }

    /// <summary>
    /// Creates a new TechnicalAnalyzer instance from closing prices only.
    /// </summary>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A TechnicalAnalyzer instance ready for analysis.</returns>
    /// <remarks>
    /// This convenience method is useful when you only have closing price data.
    /// Note that some indicators (like ADX, Stochastic, ATR) require High, Low, and Close
    /// prices for accurate calculation. When using this method, all OHLC values will be
    /// set to the closing prices, which may affect indicator accuracy.
    /// </remarks>
    public static TechnicalAnalyzer FromClose(double[] close)
    {
        var priceData = PriceData.FromClose(close);
        return new TechnicalAnalyzer(priceData);
    }

    /// <summary>
    /// Creates a new TechnicalAnalyzer instance from OHLC price data.
    /// </summary>
    /// <param name="open">Array of opening prices.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <returns>A TechnicalAnalyzer instance ready for analysis.</returns>
    /// <remarks>
    /// This is the recommended method for creating a TechnicalAnalyzer when you have
    /// complete OHLC data. All indicators will have access to the full price range,
    /// ensuring accurate calculations.
    /// </remarks>
    public static TechnicalAnalyzer FromOHLC(
        double[] open,
        double[] high,
        double[] low,
        double[] close)
    {
        var priceData = PriceData.FromOHLC(open, high, low, close);
        return new TechnicalAnalyzer(priceData);
    }

    /// <summary>
    /// Creates a new TechnicalAnalyzer instance from OHLCV price data.
    /// </summary>
    /// <param name="open">Array of opening prices.</param>
    /// <param name="high">Array of high prices.</param>
    /// <param name="low">Array of low prices.</param>
    /// <param name="close">Array of closing prices.</param>
    /// <param name="volume">Array of volume data.</param>
    /// <returns>A TechnicalAnalyzer instance ready for analysis.</returns>
    /// <remarks>
    /// Use this method when you have volume data available. While the current high-level
    /// indicators don't use volume, having it available enables future volume-based
    /// analysis operations.
    /// </remarks>
    public static TechnicalAnalyzer FromOHLCV(
        double[] open,
        double[] high,
        double[] low,
        double[] close,
        double[] volume)
    {
        var priceData = PriceData.FromOHLCV(open, high, low, close, volume);
        return new TechnicalAnalyzer(priceData);
    }
}
