#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## VolatilityAnalysis Class

Provides high\-level volatility analysis operations with fluent API and sensible defaults\.

```csharp
public sealed class VolatilityAnalysis
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; VolatilityAnalysis

### Remarks
VolatilityAnalysis simplifies the process of analyzing price volatility by wrapping common indicators
with pre\-configured defaults suitable for most trading scenarios\. It supports method chaining
for combining multiple volatility analysis operations\.

Common workflows:
\- Measuring market volatility and risk
\- Identifying volatility expansions and contractions
\- Setting stop\-loss levels based on volatility
\- Detecting overbought and oversold conditions using bands

| Constructors | |
| :--- | :--- |
| [VolatilityAnalysis\(PriceData\)](VolatilityAnalysis.VolatilityAnalysis(PriceData).md 'TechnicalAnalysis\.Functions\.VolatilityAnalysis\.VolatilityAnalysis\(TechnicalAnalysis\.Functions\.PriceData\)') | Initializes a new instance of the VolatilityAnalysis class\. |

| Methods | |
| :--- | :--- |
| [Atr\(\)](VolatilityAnalysis.Atr.md#TechnicalAnalysis.Functions.VolatilityAnalysis.Atr() 'TechnicalAnalysis\.Functions\.VolatilityAnalysis\.Atr\(\)') | Calculates the Average True Range \(ATR\) with default period of 14\. |
| [Atr\(int\)](VolatilityAnalysis.Atr.md#TechnicalAnalysis.Functions.VolatilityAnalysis.Atr(int) 'TechnicalAnalysis\.Functions\.VolatilityAnalysis\.Atr\(int\)') | Calculates the Average True Range \(ATR\) with a custom period\. |
| [BollingerBands\(\)](VolatilityAnalysis.BollingerBands.md#TechnicalAnalysis.Functions.VolatilityAnalysis.BollingerBands() 'TechnicalAnalysis\.Functions\.VolatilityAnalysis\.BollingerBands\(\)') | Calculates Bollinger Bands with default settings \(20 period, 2\.0 standard deviations, SMA\)\. |
| [BollingerBands\(int, double, double, MAType\)](VolatilityAnalysis.BollingerBands.md#TechnicalAnalysis.Functions.VolatilityAnalysis.BollingerBands(int,double,double,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.VolatilityAnalysis\.BollingerBands\(int, double, double, TechnicalAnalysis\.Common\.MAType\)') | Calculates Bollinger Bands with custom settings\. |
