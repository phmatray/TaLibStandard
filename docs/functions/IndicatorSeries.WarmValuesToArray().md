#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.WarmValuesToArray\(\) Method

Copies the values into a new array whose element `k` describes bar
`FirstBar + k`\.

```csharp
public double[] WarmValuesToArray();
```

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
A new array of exactly [WarmCount](IndicatorSeries.WarmCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmCount') elements, ARRAY\-indexed exactly as
[WarmValues](IndicatorSeries.WarmValues.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmValues') is\. It exists because [WarmValues](IndicatorSeries.WarmValues.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmValues') is a
[System\.ReadOnlySpan&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1') and therefore cannot escape into a LINQ query, an
`async` method or a field\.