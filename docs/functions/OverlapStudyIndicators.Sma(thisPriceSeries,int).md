#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[OverlapStudyIndicators](OverlapStudyIndicators.md 'TechnicalAnalysis\.Functions\.OverlapStudyIndicators')

## OverlapStudyIndicators\.Sma\(this PriceSeries, int\) Method

Computes the simple moving average of the closing prices\.

```csharp
public static TechnicalAnalysis.Functions.IndicatorSeries Sma(this TechnicalAnalysis.Functions.PriceSeries prices, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.OverlapStudyIndicators.Sma(thisTechnicalAnalysis.Functions.PriceSeries,int).prices'></a>

`prices` [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

The price series\.

<a name='TechnicalAnalysis.Functions.OverlapStudyIndicators.Sma(thisTechnicalAnalysis.Functions.PriceSeries,int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of bars to average\. Defaults to 30, as in the raw layer\.

#### Returns
[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')  
A bar\-aligned series whose first bar is `timePeriod - 1`\. If the series holds fewer bars
than the period needs, the result is empty and reports success — that is not an error\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[timePeriod](OverlapStudyIndicators.Sma(thisPriceSeries,int).md#TechnicalAnalysis.Functions.OverlapStudyIndicators.Sma(thisTechnicalAnalysis.Functions.PriceSeries,int).timePeriod 'TechnicalAnalysis\.Functions\.OverlapStudyIndicators\.Sma\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)\.timePeriod') is outside 2 to 100000\.