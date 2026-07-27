#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[BollingerBandsSeries](BollingerBandsSeries.md 'TechnicalAnalysis\.Functions\.BollingerBandsSeries')

## BollingerBandsSeries\.AsOf\(int\) Method

Narrows every band so that it ends at the given BAR index\.

```csharp
public TechnicalAnalysis.Functions.BollingerBandsSeries AsOf(int bar);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.BollingerBandsSeries.AsOf(int).bar'></a>

`bar` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The last BAR index the narrowed bands are allowed to know about, with domain
`[0, BarCount)` of the bands\.

#### Returns
[BollingerBandsSeries](BollingerBandsSeries.md 'TechnicalAnalysis\.Functions\.BollingerBandsSeries')  
A result whose three bands have each been narrowed by [AsOf\(int\)](IndicatorSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.AsOf\(int\)')\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bar](BollingerBandsSeries.AsOf(int).md#TechnicalAnalysis.Functions.BollingerBandsSeries.AsOf(int).bar 'TechnicalAnalysis\.Functions\.BollingerBandsSeries\.AsOf\(int\)\.bar') is outside the bars the bands cover\.