#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[BollingerBandsSeries](BollingerBandsSeries.md 'TechnicalAnalysis\.Functions\.BollingerBandsSeries')

## BollingerBandsSeries\(IndicatorSeries, IndicatorSeries, IndicatorSeries\) Constructor

The three bar\-aligned bands of a Bollinger Bands calculation\.

```csharp
public BollingerBandsSeries(TechnicalAnalysis.Functions.IndicatorSeries Upper, TechnicalAnalysis.Functions.IndicatorSeries Middle, TechnicalAnalysis.Functions.IndicatorSeries Lower);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.BollingerBandsSeries.BollingerBandsSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).Upper'></a>

`Upper` [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

The upper band: the middle band plus the requested number of standard deviations\. Bar\-aligned\.

<a name='TechnicalAnalysis.Functions.BollingerBandsSeries.BollingerBandsSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).Middle'></a>

`Middle` [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

The middle band: the moving average of the closing prices\. Bar\-aligned\.

<a name='TechnicalAnalysis.Functions.BollingerBandsSeries.BollingerBandsSeries(TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries,TechnicalAnalysis.Functions.IndicatorSeries).Lower'></a>

`Lower` [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

The lower band: the middle band minus the requested number of standard deviations\. Bar\-aligned\.

### Remarks
Each band is an independently addressable [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')\. Derived measures such
as %B or bandwidth are deliberately not provided: they are arithmetic on three numbers the
caller already has, and every convention for them is an opinion\.