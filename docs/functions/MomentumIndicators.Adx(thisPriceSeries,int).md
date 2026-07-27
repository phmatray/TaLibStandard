#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MomentumIndicators](MomentumIndicators.md 'TechnicalAnalysis\.Functions\.MomentumIndicators')

## MomentumIndicators\.Adx\(this PriceSeries, int\) Method

Computes the average directional index — the strength of a trend, without its direction\.

```csharp
public static TechnicalAnalysis.Functions.IndicatorSeries Adx(this TechnicalAnalysis.Functions.PriceSeries prices, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Adx(thisTechnicalAnalysis.Functions.PriceSeries,int).prices'></a>

`prices` [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

The price series\. It must carry high and low prices, because the directional movement of a
bar is defined by how its range extends beyond the previous bar's\.

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Adx(thisTechnicalAnalysis.Functions.PriceSeries,int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The Wilder smoothing period\. Defaults to 14, as in the raw layer\.

#### Returns
[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')  
A bar\-aligned series of values from 0 to 100\. The first bar is
`(2 * timePeriod) + unstablePeriod - 1`, which is 27 for the default period — the
longest warm\-up of any indicator on this surface, because the index is a smoothed average of
a smoothed average\. A value says only how strongly price is trending; whether it is trending
up or down is what `TAMath.PlusDI` and `TAMath.MinusDI` answer\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[timePeriod](MomentumIndicators.Adx(thisPriceSeries,int).md#TechnicalAnalysis.Functions.MomentumIndicators.Adx(thisTechnicalAnalysis.Functions.PriceSeries,int).timePeriod 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Adx\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)\.timePeriod') is outside 2 to 100000\.

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The price series carries no high and low prices\.