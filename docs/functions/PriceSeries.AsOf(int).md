#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

## PriceSeries\.AsOf\(int\) Method

Returns the same price series truncated so that it ends at the given BAR index\.

```csharp
public TechnicalAnalysis.Functions.PriceSeries AsOf(int bar);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.PriceSeries.AsOf(int).bar'></a>

`bar` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The last BAR index the narrowed series is allowed to know about, with domain
`[0, BarCount)`\.

#### Returns
[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')  
A series with [BarCount](PriceSeries.BarCount.md 'TechnicalAnalysis\.Functions\.PriceSeries\.BarCount') equal to `bar + 1`, sharing the same underlying
data\. Every span truncates accordingly, and bar indices are not rebased\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bar](PriceSeries.AsOf(int).md#TechnicalAnalysis.Functions.PriceSeries.AsOf(int).bar 'TechnicalAnalysis\.Functions\.PriceSeries\.AsOf\(int\)\.bar') is negative or greater than or equal to [BarCount](PriceSeries.BarCount.md 'TechnicalAnalysis\.Functions\.PriceSeries\.BarCount')\.

### Remarks
This is how a backtest hands a strategy the prices without handing it the future: the later
bars are not part of the value at all, so no discipline is required to avoid reading them\.
It is allocation\-free, which is what makes it usable as the default idiom inside a per\-bar
loop\.