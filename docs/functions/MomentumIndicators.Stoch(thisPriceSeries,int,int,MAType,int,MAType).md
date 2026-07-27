#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MomentumIndicators](MomentumIndicators.md 'TechnicalAnalysis\.Functions\.MomentumIndicators')

## MomentumIndicators\.Stoch\(this PriceSeries, int, int, MAType, int, MAType\) Method

Computes the slow stochastic oscillator\.

```csharp
public static TechnicalAnalysis.Functions.StochSeries Stoch(this TechnicalAnalysis.Functions.PriceSeries prices, int fastKPeriod=5, int slowKPeriod=3, TechnicalAnalysis.Common.MAType slowKMAType=TechnicalAnalysis.Common.MAType.Sma, int slowDPeriod=3, TechnicalAnalysis.Common.MAType slowDMAType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Stoch(thisTechnicalAnalysis.Functions.PriceSeries,int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).prices'></a>

`prices` [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

The price series\. It must carry high and low prices, because the oscillator measures where
the close sits inside the recent range\.

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Stoch(thisTechnicalAnalysis.Functions.PriceSeries,int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The lookback of the raw %K\. Defaults to 5, as in the raw layer\.

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Stoch(thisTechnicalAnalysis.Functions.PriceSeries,int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowKPeriod'></a>

`slowKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The smoothing period applied to %K\. Defaults to 3, as in the raw layer\.

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Stoch(thisTechnicalAnalysis.Functions.PriceSeries,int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowKMAType'></a>

`slowKMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The moving average used to smooth %K\. Defaults to simple\.

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Stoch(thisTechnicalAnalysis.Functions.PriceSeries,int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowDPeriod'></a>

`slowDPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The period of %D\. Defaults to 3, as in the raw layer\.

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Stoch(thisTechnicalAnalysis.Functions.PriceSeries,int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowDMAType'></a>

`slowDMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The moving average used for %D\. Defaults to simple\.

#### Returns
[StochSeries](StochSeries.md 'TechnicalAnalysis\.Functions\.StochSeries')  
The %K and %D lines, each independently bar\-aligned\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[fastKPeriod](MomentumIndicators.Stoch(thisPriceSeries,int,int,MAType,int,MAType).md#TechnicalAnalysis.Functions.MomentumIndicators.Stoch(thisTechnicalAnalysis.Functions.PriceSeries,int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).fastKPeriod 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Stoch\(this TechnicalAnalysis\.Functions\.PriceSeries, int, int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType\)\.fastKPeriod'), [slowKPeriod](MomentumIndicators.Stoch(thisPriceSeries,int,int,MAType,int,MAType).md#TechnicalAnalysis.Functions.MomentumIndicators.Stoch(thisTechnicalAnalysis.Functions.PriceSeries,int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowKPeriod 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Stoch\(this TechnicalAnalysis\.Functions\.PriceSeries, int, int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType\)\.slowKPeriod') or
            [slowDPeriod](MomentumIndicators.Stoch(thisPriceSeries,int,int,MAType,int,MAType).md#TechnicalAnalysis.Functions.MomentumIndicators.Stoch(thisTechnicalAnalysis.Functions.PriceSeries,int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowDPeriod 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Stoch\(this TechnicalAnalysis\.Functions\.PriceSeries, int, int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType\)\.slowDPeriod') is outside 2 to 100000\.

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The price series carries no high and low prices\.