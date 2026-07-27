#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MacdSeries](MacdSeries.md 'TechnicalAnalysis\.Functions\.MacdSeries')

## MacdSeries\.AsOf\(int\) Method

Narrows every component so that it ends at the given BAR index\.

```csharp
public TechnicalAnalysis.Functions.MacdSeries AsOf(int bar);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MacdSeries.AsOf(int).bar'></a>

`bar` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The last BAR index the narrowed components are allowed to know about, with domain
`[0, BarCount)` of the components\.

#### Returns
[MacdSeries](MacdSeries.md 'TechnicalAnalysis\.Functions\.MacdSeries')  
A result whose three components have each been narrowed by [AsOf\(int\)](IndicatorSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.AsOf\(int\)')\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bar](MacdSeries.AsOf(int).md#TechnicalAnalysis.Functions.MacdSeries.AsOf(int).bar 'TechnicalAnalysis\.Functions\.MacdSeries\.AsOf\(int\)\.bar') is outside the bars the components cover\.