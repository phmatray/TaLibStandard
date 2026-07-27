#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries').[Enumerator](IndicatorSeries.Enumerator.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Enumerator')

## IndicatorSeries\.Enumerator\.MoveNext\(\) Method

Advances to the next warm bar\.

```csharp
public bool MoveNext();
```

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when another warm bar is available and [Current](IndicatorSeries.Enumerator.Current.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Enumerator\.Current') has been
            positioned on it; `false` when the series is exhausted\.