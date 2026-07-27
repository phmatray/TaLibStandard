#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.GetEnumerator\(\) Method

Returns an allocation\-free enumerator over the bars of this series that carry a value\.

```csharp
public TechnicalAnalysis.Functions.IndicatorSeries.Enumerator GetEnumerator();
```

#### Returns
[Enumerator](IndicatorSeries.Enumerator.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Enumerator')  
An enumerator yielding `(Bar, Value)` pairs in ascending BAR order, one per bar with a
value, where `Bar` is a BAR index in `[FirstBar, LastBar]`\. Bars with no value are
skipped entirely, so enumerating a series with no values performs zero iterations\.