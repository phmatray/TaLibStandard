#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.BarCount Property

Gets the number of bars in the source price series\.

```csharp
public int BarCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A count, not an index\. The domain of every bar index on this type is
`[0, BarCount)`, so this — not [WarmCount](IndicatorSeries.WarmCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmCount') — is the bound of a loop over
[this\[int\]](IndicatorSeries.this[int].md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.this\[int\]')\.