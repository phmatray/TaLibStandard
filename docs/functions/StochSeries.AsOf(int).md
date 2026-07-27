#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[StochSeries](StochSeries.md 'TechnicalAnalysis\.Functions\.StochSeries')

## StochSeries\.AsOf\(int\) Method

Narrows both lines so that they end at the given BAR index\.

```csharp
public TechnicalAnalysis.Functions.StochSeries AsOf(int bar);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.StochSeries.AsOf(int).bar'></a>

`bar` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The last BAR index the narrowed lines are allowed to know about, with domain
`[0, BarCount)` of the lines\.

#### Returns
[StochSeries](StochSeries.md 'TechnicalAnalysis\.Functions\.StochSeries')  
A result whose two lines have each been narrowed by [AsOf\(int\)](IndicatorSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.AsOf\(int\)')\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bar](StochSeries.AsOf(int).md#TechnicalAnalysis.Functions.StochSeries.AsOf(int).bar 'TechnicalAnalysis\.Functions\.StochSeries\.AsOf\(int\)\.bar') is outside the bars the lines cover\.