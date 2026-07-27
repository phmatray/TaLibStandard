#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[OverlapStudyIndicators](OverlapStudyIndicators.md 'TechnicalAnalysis\.Functions\.OverlapStudyIndicators')

## OverlapStudyIndicators\.BollingerBands\(this PriceSeries, int, double, double, MAType\) Method

Computes Bollinger Bands over the closing prices\.

```csharp
public static TechnicalAnalysis.Functions.BollingerBandsSeries BollingerBands(this TechnicalAnalysis.Functions.PriceSeries prices, int timePeriod=5, double nbDevUp=2.0, double nbDevDn=2.0, TechnicalAnalysis.Common.MAType maType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.OverlapStudyIndicators.BollingerBands(thisTechnicalAnalysis.Functions.PriceSeries,int,double,double,TechnicalAnalysis.Common.MAType).prices'></a>

`prices` [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

The price series\.

<a name='TechnicalAnalysis.Functions.OverlapStudyIndicators.BollingerBands(thisTechnicalAnalysis.Functions.PriceSeries,int,double,double,TechnicalAnalysis.Common.MAType).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The period of the middle band and of the standard deviation\. \<b\>Defaults to 5, which is
TA\-Lib's own default\</b\>, even though 20 is the conventional trading choice; pass 20
explicitly if that is what you want\. The fluent layer never silently redefines a default\.

<a name='TechnicalAnalysis.Functions.OverlapStudyIndicators.BollingerBands(thisTechnicalAnalysis.Functions.PriceSeries,int,double,double,TechnicalAnalysis.Common.MAType).nbDevUp'></a>

`nbDevUp` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The number of standard deviations for the upper band\. Defaults to 2\. Not validated: any
finite deviation is meaningful\.

<a name='TechnicalAnalysis.Functions.OverlapStudyIndicators.BollingerBands(thisTechnicalAnalysis.Functions.PriceSeries,int,double,double,TechnicalAnalysis.Common.MAType).nbDevDn'></a>

`nbDevDn` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The number of standard deviations for the lower band\. Defaults to 2\. Not validated\.

<a name='TechnicalAnalysis.Functions.OverlapStudyIndicators.BollingerBands(thisTechnicalAnalysis.Functions.PriceSeries,int,double,double,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average used for the middle band\. Defaults to simple\.

#### Returns
[BollingerBandsSeries](BollingerBandsSeries.md 'TechnicalAnalysis\.Functions\.BollingerBandsSeries')  
The three bands, each independently bar\-aligned and sharing the same first bar\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[timePeriod](OverlapStudyIndicators.BollingerBands(thisPriceSeries,int,double,double,MAType).md#TechnicalAnalysis.Functions.OverlapStudyIndicators.BollingerBands(thisTechnicalAnalysis.Functions.PriceSeries,int,double,double,TechnicalAnalysis.Common.MAType).timePeriod 'TechnicalAnalysis\.Functions\.OverlapStudyIndicators\.BollingerBands\(this TechnicalAnalysis\.Functions\.PriceSeries, int, double, double, TechnicalAnalysis\.Common\.MAType\)\.timePeriod') is outside 2 to 100000\.