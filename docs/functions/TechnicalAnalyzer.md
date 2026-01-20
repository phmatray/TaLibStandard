#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TechnicalAnalyzer Class

Provides a unified entry point for all technical analysis operations with a fluent API\.

```csharp
public sealed class TechnicalAnalyzer
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; TechnicalAnalyzer

### Remarks
TechnicalAnalyzer orchestrates access to trend, momentum, and volatility analysis operations,
enabling a fluent and intuitive workflow for comprehensive technical analysis\.
This class serves as the main facade for the high\-level technical analysis API\.

Common workflows:
\- Analyze price trends using moving averages and directional indicators
\- Assess momentum with RSI, MACD, and Stochastic oscillators
\- Measure volatility with ATR and Bollinger Bands
\- Combine multiple indicators for comprehensive market analysis

Example usage:

```csharp
var priceData = PriceData.FromOHLC(open, high, low, close);
var analyzer = new TechnicalAnalyzer(priceData);

// Analyze trend
var ema = analyzer.Trend.Ema();
var sma = analyzer.Trend.Sma(period: 50);

// Analyze momentum
var rsi = analyzer.Momentum.Rsi();
var macd = analyzer.Momentum.Macd();

// Analyze volatility
var atr = analyzer.Volatility.Atr();
var bb = analyzer.Volatility.BollingerBands();
```

| Constructors | |
| :--- | :--- |
| [TechnicalAnalyzer\(PriceData\)](TechnicalAnalyzer.TechnicalAnalyzer(PriceData).md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer\.TechnicalAnalyzer\(TechnicalAnalysis\.Functions\.PriceData\)') | Initializes a new instance of the TechnicalAnalyzer class\. |

| Properties | |
| :--- | :--- |
| [Momentum](TechnicalAnalyzer.Momentum.md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer\.Momentum') | Gets the momentum analysis operations for the price data\. |
| [Trend](TechnicalAnalyzer.Trend.md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer\.Trend') | Gets the trend analysis operations for the price data\. |
| [Volatility](TechnicalAnalyzer.Volatility.md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer\.Volatility') | Gets the volatility analysis operations for the price data\. |

| Methods | |
| :--- | :--- |
| [FromClose\(double\[\]\)](TechnicalAnalyzer.FromClose(double[]).md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer\.FromClose\(double\[\]\)') | Creates a new TechnicalAnalyzer instance from closing prices only\. |
| [FromOHLC\(double\[\], double\[\], double\[\], double\[\]\)](TechnicalAnalyzer.FromOHLC(double[],double[],double[],double[]).md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer\.FromOHLC\(double\[\], double\[\], double\[\], double\[\]\)') | Creates a new TechnicalAnalyzer instance from OHLC price data\. |
| [FromOHLCV\(double\[\], double\[\], double\[\], double\[\], double\[\]\)](TechnicalAnalyzer.FromOHLCV(double[],double[],double[],double[],double[]).md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer\.FromOHLCV\(double\[\], double\[\], double\[\], double\[\], double\[\]\)') | Creates a new TechnicalAnalyzer instance from OHLCV price data\. |
