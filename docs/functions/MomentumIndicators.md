#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MomentumIndicators Class

Fluent momentum indicators\.

```csharp
public static class MomentumIndicators
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → MomentumIndicators

### Remarks

The class name is TA-Lib's own function group and never appears at a call site: these are
extension methods on [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries').

No indicator here returns a thresholded verdict such as "overbought". A wrong number looks
wrong; a wrong [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean') looks authoritative and has already destroyed the evidence
that would have shown it was wrong. The conventional levels are also conventions — 70 and 30
come from a 1978 book about daily bars — so they belong in your source file, under your review,
not in the library.

| Methods | |
| :--- | :--- |
| [Adx\(this PriceSeries, int\)](MomentumIndicators.Adx(thisPriceSeries,int).md 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Adx\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)') | Computes the average directional index — the strength of a trend, without its direction\. |
| [Macd\(this PriceSeries, int, int, int\)](MomentumIndicators.Macd(thisPriceSeries,int,int,int).md 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Macd\(this TechnicalAnalysis\.Functions\.PriceSeries, int, int, int\)') | Computes the moving average convergence divergence of the closing prices\. |
| [Rsi\(this PriceSeries, int\)](MomentumIndicators.Rsi(thisPriceSeries,int).md 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Rsi\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)') | Computes the relative strength index of the closing prices\. |
| [Stoch\(this PriceSeries, int, int, MAType, int, MAType\)](MomentumIndicators.Stoch(thisPriceSeries,int,int,MAType,int,MAType).md 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Stoch\(this TechnicalAnalysis\.Functions\.PriceSeries, int, int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType\)') | Computes the slow stochastic oscillator\. |
