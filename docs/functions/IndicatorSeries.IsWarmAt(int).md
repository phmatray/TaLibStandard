#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.IsWarmAt\(int\) Method

Determines whether the given BAR index has a value\.

```csharp
public bool IsWarmAt(int bar);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.IsWarmAt(int).bar'></a>

`bar` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

A BAR index into the source price series, with domain `[0, BarCount)`\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when [bar](IndicatorSeries.IsWarmAt(int).md#TechnicalAnalysis.Functions.IndicatorSeries.IsWarmAt(int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.IsWarmAt\(int\)\.bar') lies in `[FirstBar, LastBar]`; otherwise
            `false`\. Equivalent to `this[bar] is not null`, without the nullable value\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bar](IndicatorSeries.IsWarmAt(int).md#TechnicalAnalysis.Functions.IndicatorSeries.IsWarmAt(int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.IsWarmAt\(int\)\.bar') is negative or greater than or equal to [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount')\.