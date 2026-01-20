#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MomentumAnalysis Class

Provides high\-level momentum analysis operations with fluent API and sensible defaults\.

```csharp
public sealed class MomentumAnalysis
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; MomentumAnalysis

### Remarks
MomentumAnalysis simplifies the process of analyzing price momentum by wrapping common indicators
with pre\-configured defaults suitable for most trading scenarios\. It supports method chaining
for combining multiple momentum analysis operations\.

Common workflows:
\- Identifying overbought and oversold conditions
\- Detecting momentum shifts and divergences
\- Confirming trend strength through momentum

| Constructors | |
| :--- | :--- |
| [MomentumAnalysis\(PriceData\)](MomentumAnalysis.MomentumAnalysis(PriceData).md 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.MomentumAnalysis\(TechnicalAnalysis\.Functions\.PriceData\)') | Initializes a new instance of the MomentumAnalysis class\. |

| Methods | |
| :--- | :--- |
| [Macd\(\)](MomentumAnalysis.Macd.md#TechnicalAnalysis.Functions.MomentumAnalysis.Macd() 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Macd\(\)') | Calculates the Moving Average Convergence Divergence \(MACD\) with default periods \(12, 26, 9\)\. |
| [Macd\(int, int, int\)](MomentumAnalysis.Macd.md#TechnicalAnalysis.Functions.MomentumAnalysis.Macd(int,int,int) 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Macd\(int, int, int\)') | Calculates the Moving Average Convergence Divergence \(MACD\) with custom periods\. |
| [Rsi\(\)](MomentumAnalysis.Rsi.md#TechnicalAnalysis.Functions.MomentumAnalysis.Rsi() 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Rsi\(\)') | Calculates the Relative Strength Index \(RSI\) with default period of 14\. |
| [Rsi\(int\)](MomentumAnalysis.Rsi.md#TechnicalAnalysis.Functions.MomentumAnalysis.Rsi(int) 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Rsi\(int\)') | Calculates the Relative Strength Index \(RSI\) with a custom period\. |
| [Stoch\(\)](MomentumAnalysis.Stoch.md#TechnicalAnalysis.Functions.MomentumAnalysis.Stoch() 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Stoch\(\)') | Calculates the Stochastic Oscillator with default periods \(14, 3, 3\)\. |
| [Stoch\(int, int, int\)](MomentumAnalysis.Stoch.md#TechnicalAnalysis.Functions.MomentumAnalysis.Stoch(int,int,int) 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Stoch\(int, int, int\)') | Calculates the Stochastic Oscillator with custom periods\. |
