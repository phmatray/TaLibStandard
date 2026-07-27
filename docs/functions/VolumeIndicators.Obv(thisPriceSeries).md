#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[VolumeIndicators](VolumeIndicators.md 'TechnicalAnalysis\.Functions\.VolumeIndicators')

## VolumeIndicators\.Obv\(this PriceSeries\) Method

Computes on\-balance volume: the running total of volume, signed by the direction of the
close\.

```csharp
public static TechnicalAnalysis.Functions.IndicatorSeries Obv(this TechnicalAnalysis.Functions.PriceSeries prices);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.VolumeIndicators.Obv(thisTechnicalAnalysis.Functions.PriceSeries).prices'></a>

`prices` [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

The price series\. It must carry volumes, which only [FromOhlcv\(ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;\)](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)')
supplies; substituting a constant volume would turn this into a signed bar counter\.

#### Returns
[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')  
A bar\-aligned series that is warm from bar `0`, because the running total needs no
lookback\. The absolute level carries no meaning — it depends on where the series happens to
start — so only its direction and its divergence from price are read\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The price series carries no volumes\.