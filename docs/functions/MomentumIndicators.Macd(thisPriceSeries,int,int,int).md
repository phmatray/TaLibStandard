#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MomentumIndicators](MomentumIndicators.md 'TechnicalAnalysis\.Functions\.MomentumIndicators')

## MomentumIndicators\.Macd\(this PriceSeries, int, int, int\) Method

Computes the moving average convergence divergence of the closing prices\.

```csharp
public static TechnicalAnalysis.Functions.MacdSeries Macd(this TechnicalAnalysis.Functions.PriceSeries prices, int fastPeriod=12, int slowPeriod=26, int signalPeriod=9);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Macd(thisTechnicalAnalysis.Functions.PriceSeries,int,int,int).prices'></a>

`prices` [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

The price series\.

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Macd(thisTechnicalAnalysis.Functions.PriceSeries,int,int,int).fastPeriod'></a>

`fastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The fast exponential moving average period\. Defaults to 12, as in the raw layer\.

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Macd(thisTechnicalAnalysis.Functions.PriceSeries,int,int,int).slowPeriod'></a>

`slowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The slow exponential moving average period\. Defaults to 26, as in the raw layer\.

<a name='TechnicalAnalysis.Functions.MomentumIndicators.Macd(thisTechnicalAnalysis.Functions.PriceSeries,int,int,int).signalPeriod'></a>

`signalPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The period of the signal line, an exponential moving average of the MACD line\. Defaults to 9,
as in the raw layer\.

#### Returns
[MacdSeries](MacdSeries.md 'TechnicalAnalysis\.Functions\.MacdSeries')  
The line, signal and histogram, each independently bar\-aligned and sharing the same first
bar\. A signal crossing is `macd.Line.CrossedAbove(macd.Signal, bar)`\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[fastPeriod](MomentumIndicators.Macd(thisPriceSeries,int,int,int).md#TechnicalAnalysis.Functions.MomentumIndicators.Macd(thisTechnicalAnalysis.Functions.PriceSeries,int,int,int).fastPeriod 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Macd\(this TechnicalAnalysis\.Functions\.PriceSeries, int, int, int\)\.fastPeriod'), [slowPeriod](MomentumIndicators.Macd(thisPriceSeries,int,int,int).md#TechnicalAnalysis.Functions.MomentumIndicators.Macd(thisTechnicalAnalysis.Functions.PriceSeries,int,int,int).slowPeriod 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Macd\(this TechnicalAnalysis\.Functions\.PriceSeries, int, int, int\)\.slowPeriod') or
            [signalPeriod](MomentumIndicators.Macd(thisPriceSeries,int,int,int).md#TechnicalAnalysis.Functions.MomentumIndicators.Macd(thisTechnicalAnalysis.Functions.PriceSeries,int,int,int).signalPeriod 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Macd\(this TechnicalAnalysis\.Functions\.PriceSeries, int, int, int\)\.signalPeriod') is outside 2 to 100000\. The signal period matters most: the
            raw layer does not reject a signal period of 1, it fails inside an internal array copy\.