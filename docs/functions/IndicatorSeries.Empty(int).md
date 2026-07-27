#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.Empty\(int\) Method

Creates a series covering the given number of bars in which no bar has a value\.

```csharp
public static TechnicalAnalysis.Functions.IndicatorSeries Empty(int barCount);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.Empty(int).barCount'></a>

`barCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of bars in the source price series\. Must not be negative\.

#### Returns
[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')  
A series reporting [TechnicalAnalysis\.Common\.RetCode\.Success](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode.success 'TechnicalAnalysis\.Common\.RetCode\.Success') with [WarmCount](IndicatorSeries.WarmCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmCount') zero,
[BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount') equal to [barCount](IndicatorSeries.Empty(int).md#TechnicalAnalysis.Functions.IndicatorSeries.Empty(int).barCount 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Empty\(int\)\.barCount'), and [FirstBar](IndicatorSeries.FirstBar.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.FirstBar')`null`\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[barCount](IndicatorSeries.Empty(int).md#TechnicalAnalysis.Functions.IndicatorSeries.Empty(int).barCount 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Empty\(int\)\.barCount') is negative\.