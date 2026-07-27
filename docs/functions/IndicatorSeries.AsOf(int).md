#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.AsOf\(int\) Method

Returns the same series truncated so that it ends at the given BAR index, making look\-ahead
unrepresentable rather than merely detectable\.

```csharp
public TechnicalAnalysis.Functions.IndicatorSeries AsOf(int bar);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.AsOf(int).bar'></a>

`bar` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The last BAR index the narrowed series is allowed to know about, with domain
`[0, BarCount)`\.

#### Returns
[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')  
A series with [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount') equal to `bar + 1` and the same
[FirstBar](IndicatorSeries.FirstBar.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.FirstBar'), holding only the values at bars up to and including
[bar](IndicatorSeries.AsOf(int).md#TechnicalAnalysis.Functions.IndicatorSeries.AsOf(int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.AsOf\(int\)\.bar')\. If no value survives, the result carries none at all\. Bar indices
are \<b\>not\</b\> rebased: they remain absolute positions in the original price series\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bar](IndicatorSeries.AsOf(int).md#TechnicalAnalysis.Functions.IndicatorSeries.AsOf(int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.AsOf\(int\)\.bar') is negative or greater than or equal to [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount')\.

### Remarks

Asking the narrowed series about a later bar throws, because that bar is outside its domain:
`series.AsOf(50)[51]` is an [System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException'), not a value and
not `null`. The future is simply not part of the value handed over.

All shipped indicators are causal, so narrowing the end never changes an earlier value:
`prices.AsOf(bar).Sma(30).Latest` equals `prices.Sma(30).AsOf(bar).Latest`
exactly. This is the reason to prefer computing once and narrowing per bar — which is
allocation-free and O(1) — over recomputing the indicator inside a per-bar loop, which is
O(n²).