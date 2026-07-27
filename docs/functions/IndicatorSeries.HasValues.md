#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.HasValues Property

Gets a value indicating whether any bar of this series carries a value\.

```csharp
public bool HasValues { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when [WarmCount](IndicatorSeries.WarmCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmCount') is greater than zero\. This is the only warmth test;
            a series can carry nothing and still report [TechnicalAnalysis\.Common\.RetCode\.Success](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode.success 'TechnicalAnalysis\.Common\.RetCode\.Success')\. It is
            deliberately not called `IsEmpty`: [IsEmpty](PriceSeries.IsEmpty.md 'TechnicalAnalysis\.Functions\.PriceSeries\.IsEmpty') means "no bars",
            and a series here can carry no values while covering a hundred bars\.