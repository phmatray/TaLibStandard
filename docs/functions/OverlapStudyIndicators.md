#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## OverlapStudyIndicators Class

Fluent overlap study indicators — those plotted on the price scale\.

```csharp
public static class OverlapStudyIndicators
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → OverlapStudyIndicators

### Remarks

The class name is TA-Lib's own function group and never appears at a call site: these are
extension methods on [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries'), so they appear directly on `prices.` in
IntelliSense.

Every default here is copied verbatim from the corresponding raw entry point. The fluent layer
never invents a number, so that a fluent call and a raw call with the same arguments cannot
disagree.

| Methods | |
| :--- | :--- |
| [BollingerBands\(this PriceSeries, int, double, double, MAType\)](OverlapStudyIndicators.BollingerBands(thisPriceSeries,int,double,double,MAType).md 'TechnicalAnalysis\.Functions\.OverlapStudyIndicators\.BollingerBands\(this TechnicalAnalysis\.Functions\.PriceSeries, int, double, double, TechnicalAnalysis\.Common\.MAType\)') | Computes Bollinger Bands over the closing prices\. |
| [Ema\(this PriceSeries, int\)](OverlapStudyIndicators.Ema(thisPriceSeries,int).md 'TechnicalAnalysis\.Functions\.OverlapStudyIndicators\.Ema\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)') | Computes the exponential moving average of the closing prices\. |
| [Sma\(this PriceSeries, int\)](OverlapStudyIndicators.Sma(thisPriceSeries,int).md 'TechnicalAnalysis\.Functions\.OverlapStudyIndicators\.Sma\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)') | Computes the simple moving average of the closing prices\. |
