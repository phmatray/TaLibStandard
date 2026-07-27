#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.this\[int\] Property

Gets the value at the given BAR index, or `null` when that bar has no value\.

```csharp
public System.Nullable<double> this[int bar] { get; }
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.this[int].bar'></a>

`bar` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

A BAR index into the source price series, with domain `[0, BarCount)`\. This is
\<b\>not\</b\> an index into the raw TA\-Lib output array\.

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  
The value describing [bar](IndicatorSeries.this[int].md#TechnicalAnalysis.Functions.IndicatorSeries.this[int].bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.this\[int\]\.bar'), or `null` when [bar](IndicatorSeries.this[int].md#TechnicalAnalysis.Functions.IndicatorSeries.this[int].bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.this\[int\]\.bar') is
inside the series but outside `[FirstBar, LastBar]` — typically a bar before the
indicator warmed up\. Never `0.0` and never [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') for a bar that has
no value\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bar](IndicatorSeries.this[int].md#TechnicalAnalysis.Functions.IndicatorSeries.this[int].bar 'TechnicalAnalysis\.Functions\.IndicatorSeries\.this\[int\]\.bar') is negative or greater than or equal to [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount')\.
            Asking about a bar the series does not cover is a caller bug, whereas asking about a bar
            that has not warmed up is a legitimate question answered with `null`\.