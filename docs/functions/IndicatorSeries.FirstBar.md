#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.FirstBar Property

Gets the BAR index of the first bar that has a value, or `null` when no bar has one\.

```csharp
public System.Nullable<int> FirstBar { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  
A bar index in `[0, BarCount)` — TA\-Lib's `BegIdx`, reinterpreted as the true
lookback of the indicator\. `null` if and only if [HasValues](IndicatorSeries.HasValues.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.HasValues') is
`false`\.