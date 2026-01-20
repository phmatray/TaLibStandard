#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TrendAnalysis Class

Provides high\-level trend analysis operations with fluent API and sensible defaults\.

```csharp
public sealed class TrendAnalysis
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; TrendAnalysis

### Remarks
TrendAnalysis simplifies the process of analyzing price trends by wrapping common indicators
with pre\-configured defaults suitable for most trading scenarios\. It supports method chaining
for combining multiple trend analysis operations\.

Common workflows:
\- Identifying trend direction and strength
\- Detecting trend changes and reversals
\- Confirming trend momentum

| Constructors | |
| :--- | :--- |
| [TrendAnalysis\(PriceData\)](TrendAnalysis.TrendAnalysis(PriceData).md 'TechnicalAnalysis\.Functions\.TrendAnalysis\.TrendAnalysis\(TechnicalAnalysis\.Functions\.PriceData\)') | Initializes a new instance of the TrendAnalysis class\. |

| Methods | |
| :--- | :--- |
| [Adx\(\)](TrendAnalysis.Adx.md#TechnicalAnalysis.Functions.TrendAnalysis.Adx() 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Adx\(\)') | Calculates the Average Directional Index \(ADX\) with default period of 14\. |
| [Adx\(int\)](TrendAnalysis.Adx.md#TechnicalAnalysis.Functions.TrendAnalysis.Adx(int) 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Adx\(int\)') | Calculates the Average Directional Index \(ADX\) with a custom period\. |
| [Ema\(\)](TrendAnalysis.Ema.md#TechnicalAnalysis.Functions.TrendAnalysis.Ema() 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Ema\(\)') | Calculates the Exponential Moving Average \(EMA\) with default period of 20\. |
| [Ema\(int\)](TrendAnalysis.Ema.md#TechnicalAnalysis.Functions.TrendAnalysis.Ema(int) 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Ema\(int\)') | Calculates the Exponential Moving Average \(EMA\) with a custom period\. |
| [Sma\(\)](TrendAnalysis.Sma.md#TechnicalAnalysis.Functions.TrendAnalysis.Sma() 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Sma\(\)') | Calculates the Simple Moving Average \(SMA\) with default period of 50\. |
| [Sma\(int\)](TrendAnalysis.Sma.md#TechnicalAnalysis.Functions.TrendAnalysis.Sma(int) 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Sma\(int\)') | Calculates the Simple Moving Average \(SMA\) with a custom period\. |
