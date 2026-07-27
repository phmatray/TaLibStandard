#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MacdSeries Struct

The three bar\-aligned outputs of a MACD calculation\.

```csharp
public readonly record struct MacdSeries : System.IEquatable<TechnicalAnalysis.Functions.MacdSeries>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[MacdSeries](MacdSeries.md 'TechnicalAnalysis\.Functions\.MacdSeries')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
Each component is an independently addressable [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries'), so a signal\-line
crossing needs no dedicated member: `macd.Line.CrossedAbove(macd.Signal, bar)` already says
it, in bar indices, with the differing warm\-ups handled for you\.

| Constructors | |
| :--- | :--- |
| [MacdSeries\(IndicatorSeries, IndicatorSeries, IndicatorSeries\)](MacdSeries.MacdSeries(IndicatorSeries,IndicatorSeries,IndicatorSeries).md 'TechnicalAnalysis\.Functions\.MacdSeries\.MacdSeries\(TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries\)') | The three bar\-aligned outputs of a MACD calculation\. |

| Properties | |
| :--- | :--- |
| [Histogram](MacdSeries.Histogram.md 'TechnicalAnalysis\.Functions\.MacdSeries\.Histogram') | The histogram: Line minus Signal\. Bar\-aligned\. |
| [Line](MacdSeries.Line.md 'TechnicalAnalysis\.Functions\.MacdSeries\.Line') | The MACD line: the fast exponential moving average minus the slow one\. Bar\-aligned\. |
| [Signal](MacdSeries.Signal.md 'TechnicalAnalysis\.Functions\.MacdSeries\.Signal') | The signal line: an exponential moving average of Line\. Bar\-aligned\. |

| Methods | |
| :--- | :--- |
| [AsOf\(int\)](MacdSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.MacdSeries\.AsOf\(int\)') | Narrows every component so that it ends at the given BAR index\. |
