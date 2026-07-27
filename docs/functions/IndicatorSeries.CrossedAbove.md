#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.CrossedAbove Method

| Overloads | |
| :--- | :--- |
| [CrossedAbove\(double, int\)](IndicatorSeries.CrossedAbove.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(double,int) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(double, int\)') | Determines whether this series crossed above a fixed level at the given BAR index\. |
| [CrossedAbove\(IndicatorSeries, int\)](IndicatorSeries.CrossedAbove.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(TechnicalAnalysis.Functions.IndicatorSeries,int) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)') | Determines whether this series crossed above another series at the given BAR index\. |

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(double,int)'></a>

## IndicatorSeries\.CrossedAbove\(double, int\) Method

Determines whether this series crossed above a fixed level at the given BAR index\.

```csharp
public bool CrossedAbove(double level, int bar);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(double,int).level'></a>

`level` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The level to test against\.

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(double,int).bar'></a>

`bar` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The BAR index at which the crossing is tested, with domain `[0, BarCount)`\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when the value at [bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(double,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(double, int\)\.bar') is strictly above
            [level](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(double,int).level 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(double, int\)\.level') and the value at `bar - 1` was at or below it\. A crossing is a
            transition between two bars, not a state: a series that is already above the level does not
            keep reporting a crossing\. Returns `false` when [bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(double,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(double, int\)\.bar') is `0`, or
            when either bar has no value\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(double,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(double, int\)\.bar') is negative or greater than or equal to [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount')\.

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(TechnicalAnalysis.Functions.IndicatorSeries,int)'></a>

## IndicatorSeries\.CrossedAbove\(IndicatorSeries, int\) Method

Determines whether this series crossed above another series at the given BAR index\.

```csharp
public bool CrossedAbove(TechnicalAnalysis.Functions.IndicatorSeries other, int bar);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(TechnicalAnalysis.Functions.IndicatorSeries,int).other'></a>

`other` [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

The series to cross against\. It must cover the same number of bars as this one, so that a
bar index means the same thing in both\.

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(TechnicalAnalysis.Functions.IndicatorSeries,int).bar'></a>

`bar` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The BAR index at which the crossing is tested, with domain `[0, BarCount)`\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when this series is strictly above [other](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(TechnicalAnalysis.Functions.IndicatorSeries,int).other 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)\.other') at
            [bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(TechnicalAnalysis.Functions.IndicatorSeries,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)\.bar') and was at or below it at `bar - 1`\. Returns `false` when
            [bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(TechnicalAnalysis.Functions.IndicatorSeries,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)\.bar') is `0`, or when any of the four values involved is missing —
            which is what makes a fast/slow crossing with different warm\-ups work without any reasoning
            at the call site\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[other](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(TechnicalAnalysis.Functions.IndicatorSeries,int).other 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)\.other') covers a different number of bars than this series\. Crossing two
            series computed over different price series is a caller bug\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bar](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(TechnicalAnalysis.Functions.IndicatorSeries,int).bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)\.bar') is negative or greater than or equal to [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount')\.