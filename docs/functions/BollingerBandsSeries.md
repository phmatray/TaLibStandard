#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## BollingerBandsSeries Struct

The three bar\-aligned bands of a Bollinger Bands calculation\.

```csharp
public readonly record struct BollingerBandsSeries : System.IEquatable<TechnicalAnalysis.Functions.BollingerBandsSeries>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[BollingerBandsSeries](BollingerBandsSeries.md 'TechnicalAnalysis\.Functions\.BollingerBandsSeries')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
Each band is an independently addressable [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')\. Derived measures such
as %B or bandwidth are deliberately not provided: they are arithmetic on three numbers the
caller already has, and every convention for them is an opinion\.

| Constructors | |
| :--- | :--- |
| [BollingerBandsSeries\(IndicatorSeries, IndicatorSeries, IndicatorSeries\)](BollingerBandsSeries.BollingerBandsSeries(IndicatorSeries,IndicatorSeries,IndicatorSeries).md 'TechnicalAnalysis\.Functions\.BollingerBandsSeries\.BollingerBandsSeries\(TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries\)') | The three bar\-aligned bands of a Bollinger Bands calculation\. |

| Properties | |
| :--- | :--- |
| [Lower](BollingerBandsSeries.Lower.md 'TechnicalAnalysis\.Functions\.BollingerBandsSeries\.Lower') | The lower band: the middle band minus the requested number of standard deviations\. Bar\-aligned\. |
| [Middle](BollingerBandsSeries.Middle.md 'TechnicalAnalysis\.Functions\.BollingerBandsSeries\.Middle') | The middle band: the moving average of the closing prices\. Bar\-aligned\. |
| [Upper](BollingerBandsSeries.Upper.md 'TechnicalAnalysis\.Functions\.BollingerBandsSeries\.Upper') | The upper band: the middle band plus the requested number of standard deviations\. Bar\-aligned\. |

| Methods | |
| :--- | :--- |
| [AsOf\(int\)](BollingerBandsSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.BollingerBandsSeries\.AsOf\(int\)') | Narrows every band so that it ends at the given BAR index\. |
