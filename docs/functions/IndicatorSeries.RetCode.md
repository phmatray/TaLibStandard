#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.RetCode Property

Gets the return code reported by the underlying TA\-Lib call\.

```csharp
public TechnicalAnalysis.Common.RetCode RetCode { get; }
```

#### Property Value
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
The raw TA\-Lib status\. This answers only "were the parameters acceptable"; it never answers
"are there values"\. A series can report [TechnicalAnalysis\.Common\.RetCode\.Success](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode.success 'TechnicalAnalysis\.Common\.RetCode\.Success') and still hold
nothing, because a period longer than the available data is a success that produces nothing\.
Use [HasValues](IndicatorSeries.HasValues.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.HasValues') to test for warmth\.