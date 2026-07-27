#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.Latest Property

Gets the most recent value in the series, or `null` when no bar has a value\.

```csharp
public System.Nullable<double> Latest { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  
The value at [LastBar](IndicatorSeries.LastBar.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.LastBar')\. It is read from \<b\>array\</b\> index
`WarmCount - 1`, never from bar index `FirstBar + WarmCount - 1`; the latter would
index the array with a bar index, which is the historical alignment bug\.