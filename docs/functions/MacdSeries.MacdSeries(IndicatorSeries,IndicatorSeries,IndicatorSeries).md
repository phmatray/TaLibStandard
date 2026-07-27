#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MacdSeries](MacdSeries.md 'TechnicalAnalysis\.Functions\.MacdSeries')

## MacdSeries\(IndicatorSeries, IndicatorSeries, IndicatorSeries\) Constructor

The three bar\-aligned outputs of a MACD calculation\.

```csharp
public MacdSeries(TechnicalAnalysis.Functions.IndicatorSeries Line, TechnicalAnalysis.Functions.IndicatorSeries Signal, TechnicalAnalysis.Functions.IndicatorSeries Histogram);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MacdSeries.MacdSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).Line'></a>

`Line` [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

The MACD line: the fast exponential moving average minus the slow one\. Bar\-aligned\.

<a name='TechnicalAnalysis.Functions.MacdSeries.MacdSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).Signal'></a>

`Signal` [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

The signal line: an exponential moving average of [Line](MacdSeries.MacdSeries(IndicatorSeries,IndicatorSeries,IndicatorSeries).md#TechnicalAnalysis.Functions.MacdSeries.MacdSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).Line 'TechnicalAnalysis\.Functions\.MacdSeries\.MacdSeries\(TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries\)\.Line')\. Bar\-aligned\.

<a name='TechnicalAnalysis.Functions.MacdSeries.MacdSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).Histogram'></a>

`Histogram` [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

The histogram: [Line](MacdSeries.MacdSeries(IndicatorSeries,IndicatorSeries,IndicatorSeries).md#TechnicalAnalysis.Functions.MacdSeries.MacdSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).Line 'TechnicalAnalysis\.Functions\.MacdSeries\.MacdSeries\(TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries\)\.Line') minus [Signal](MacdSeries.MacdSeries(IndicatorSeries,IndicatorSeries,IndicatorSeries).md#TechnicalAnalysis.Functions.MacdSeries.MacdSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).Signal 'TechnicalAnalysis\.Functions\.MacdSeries\.MacdSeries\(TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries\)\.Signal')\. Bar\-aligned\.

### Remarks
Each component is an independently addressable [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries'), so a signal\-line
crossing needs no dedicated member: `macd.Line.CrossedAbove(macd.Signal, bar)` already says
it, in bar indices, with the differing warm\-ups handled for you\.