#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[VolatilityIndicators](VolatilityIndicators.md 'TechnicalAnalysis\.Functions\.VolatilityIndicators')

## VolatilityIndicators\.Atr\(this PriceSeries, int\) Method

Computes the average true range\.

```csharp
public static TechnicalAnalysis.Functions.IndicatorSeries Atr(this TechnicalAnalysis.Functions.PriceSeries prices, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.VolatilityIndicators.Atr(thisTechnicalAnalysis.Functions.PriceSeries,int).prices'></a>

`prices` [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

The price series\. It must carry high and low prices: a true range is a property of a bar's
range, and the absolute change in close is not a substitute for it\.

<a name='TechnicalAnalysis.Functions.VolatilityIndicators.Atr(thisTechnicalAnalysis.Functions.PriceSeries,int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The smoothing period\. Defaults to 14, as in the raw layer\.

#### Returns
[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')  
A bar\-aligned series whose first bar is [timePeriod](VolatilityIndicators.Atr(thisPriceSeries,int).md#TechnicalAnalysis.Functions.VolatilityIndicators.Atr(thisTechnicalAnalysis.Functions.PriceSeries,int).timePeriod 'TechnicalAnalysis\.Functions\.VolatilityIndicators\.Atr\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)\.timePeriod')\. If the series holds
fewer bars than the period needs, the result is empty and reports success\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[timePeriod](VolatilityIndicators.Atr(thisPriceSeries,int).md#TechnicalAnalysis.Functions.VolatilityIndicators.Atr(thisTechnicalAnalysis.Functions.PriceSeries,int).timePeriod 'TechnicalAnalysis\.Functions\.VolatilityIndicators\.Atr\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)\.timePeriod') is outside 2 to 100000\. This is deliberately stricter than the
            raw entry point, which accepts 1, in exchange for one period rule that holds everywhere\.

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The price series carries no high and low prices\.