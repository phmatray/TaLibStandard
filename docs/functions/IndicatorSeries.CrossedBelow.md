#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.CrossedBelow Method

| Overloads | |
| :--- | :--- |
| [CrossedBelow\(double, int\)](IndicatorSeries.CrossedBelow.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(double,int) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(double, int\)') | Determines whether this series crossed below a fixed level at the given BAR index\. |
| [CrossedBelow\(IndicatorSeries, int\)](IndicatorSeries.CrossedBelow.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(TechnicalAnalysis.Functions.IndicatorSeries,int) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)') | Determines whether this series crossed below another series at the given BAR index\. |

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(double,int)'></a>

## IndicatorSeries\.CrossedBelow\(double, int\) Method

Determines whether this series crossed below a fixed level at the given BAR index\.

```csharp
public bool CrossedBelow(double level, int bar);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(double,int).level'></a>

`level` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The level to test against\.

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(double,int).bar'></a>

`bar` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The BAR index at which the crossing is tested, with domain `[0, BarCount)`\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when the value at [bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(double,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(double, int\)\.bar') is strictly below
            [level](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(double,int).level 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(double, int\)\.level') and the value at `bar - 1` was at or above it\. Returns
            `false` when [bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(double,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(double, int\)\.bar') is `0`, or when either bar has no value\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(double,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(double, int\)\.bar') is negative or greater than or equal to [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount')\.

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(TechnicalAnalysis.Functions.IndicatorSeries,int)'></a>

## IndicatorSeries\.CrossedBelow\(IndicatorSeries, int\) Method

Determines whether this series crossed below another series at the given BAR index\.

```csharp
public bool CrossedBelow(TechnicalAnalysis.Functions.IndicatorSeries other, int bar);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(TechnicalAnalysis.Functions.IndicatorSeries,int).other'></a>

`other` [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

The series to cross against\. It must cover the same number of bars as this one\.

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(TechnicalAnalysis.Functions.IndicatorSeries,int).bar'></a>

`bar` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The BAR index at which the crossing is tested, with domain `[0, BarCount)`\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when this series is strictly below [other](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(TechnicalAnalysis.Functions.IndicatorSeries,int).other 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)\.other') at
            [bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(TechnicalAnalysis.Functions.IndicatorSeries,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)\.bar') and was at or above it at `bar - 1`\. Returns `false` when
            [bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(TechnicalAnalysis.Functions.IndicatorSeries,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)\.bar') is `0`, or when any of the four values involved is missing\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[other](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(TechnicalAnalysis.Functions.IndicatorSeries,int).other 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)\.other') covers a different number of bars than this series\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(TechnicalAnalysis.Functions.IndicatorSeries,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)\.bar') is negative or greater than or equal to [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount')\.