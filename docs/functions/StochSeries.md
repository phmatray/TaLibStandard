#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## StochSeries Struct

The two bar\-aligned outputs of a stochastic oscillator calculation\.

```csharp
public readonly record struct StochSeries : System.IEquatable<TechnicalAnalysis.Functions.StochSeries>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[StochSeries](StochSeries.md 'TechnicalAnalysis\.Functions\.StochSeries')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The component names match [StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult'), so moving between the raw and fluent layers
costs nothing\. A %K/%D crossing is `stoch.SlowK.CrossedAbove(stoch.SlowD, bar)`\.

| Constructors | |
| :--- | :--- |
| [StochSeries\(IndicatorSeries, IndicatorSeries\)](StochSeries.StochSeries(IndicatorSeries,IndicatorSeries).md 'TechnicalAnalysis\.Functions\.StochSeries\.StochSeries\(TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries\)') | The two bar\-aligned outputs of a stochastic oscillator calculation\. |

| Properties | |
| :--- | :--- |
| [SlowD](StochSeries.SlowD.md 'TechnicalAnalysis\.Functions\.StochSeries\.SlowD') | The slow %D line: a moving average of SlowK, acting as its signal line\. Bar\-aligned\. |
| [SlowK](StochSeries.SlowK.md 'TechnicalAnalysis\.Functions\.StochSeries\.SlowK') | The slow %K line: the smoothed position of the close within the recent high\-low range, expressed from 0 to 100\. Bar\-aligned\. |

| Methods | |
| :--- | :--- |
| [AsOf\(int\)](StochSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.StochSeries\.AsOf\(int\)') | Narrows both lines so that they end at the given BAR index\. |
