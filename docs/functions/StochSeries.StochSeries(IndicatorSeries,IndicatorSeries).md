#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[StochSeries](StochSeries.md 'TechnicalAnalysis\.Functions\.StochSeries')

## StochSeries\(IndicatorSeries, IndicatorSeries\) Constructor

The two bar\-aligned outputs of a stochastic oscillator calculation\.

```csharp
public StochSeries(TechnicalAnalysis.Functions.IndicatorSeries SlowK, TechnicalAnalysis.Functions.IndicatorSeries SlowD);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.StochSeries.StochSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).SlowK'></a>

`SlowK` [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

The slow %K line: the smoothed position of the close within the recent high\-low range,
expressed from 0 to 100\. Bar\-aligned\.

<a name='TechnicalAnalysis.Functions.StochSeries.StochSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).SlowD'></a>

`SlowD` [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

The slow %D line: a moving average of [SlowK](StochSeries.StochSeries(IndicatorSeries,IndicatorSeries).md#TechnicalAnalysis.Functions.StochSeries.StochSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).SlowK 'TechnicalAnalysis\.Functions\.StochSeries\.StochSeries\(TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries\)\.SlowK'), acting as its signal line\.
Bar\-aligned\.

### Remarks
The component names match [StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult'), so moving between the raw and fluent layers
costs nothing\. A %K/%D crossing is `stoch.SlowK.CrossedAbove(stoch.SlowD, bar)`\.