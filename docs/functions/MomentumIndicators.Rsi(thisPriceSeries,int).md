#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MomentumIndicators](MomentumIndicators.md 'TechnicalAnalysis\.Functions\.MomentumIndicators')

## MomentumIndicators\.Rsi\(this PriceSeries, int\) Method

Computes the relative strength index of the closing prices\.

```csharp
public static TechnicalAnalysis.Functions.IndicatorSeries Rsi(this TechnicalAnalysis.Functions.PriceSeries prices, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Rsi(thisTechnicalAnalysis.Functions.PriceSeries,int).prices'></a>

`prices` [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

The price series\.

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Rsi(thisTechnicalAnalysis.Functions.PriceSeries,int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The lookback period\. Defaults to 14, as in the raw layer\.

#### Returns
[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')  
A bar\-aligned series of values from 0 to 100\. A strictly rising series is pinned at 100 and a
flat series reads 0, matching the reference C implementation\. If the series holds fewer bars
than the period needs, the result is empty and reports success — and an empty result answers
`null` rather than `0`, so it can never be mistaken for an oversold reading\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[timePeriod](MomentumIndicators.Rsi(thisPriceSeries,int).md#TechnicalAnalysis.Functions.MomentumIndicators.Rsi(thisTechnicalAnalysis.Functions.PriceSeries,int).timePeriod 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Rsi\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)\.timePeriod') is outside 2 to 100000\.