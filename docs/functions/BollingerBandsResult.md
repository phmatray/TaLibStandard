#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## BollingerBandsResult Class

Represents the result of the Bollinger Bands indicator calculation\.
Bollinger Bands consist of a middle band \(SMA\) and two outer bands that represent standard deviations from the middle band, used to measure volatility and identify overbought/oversold conditions\.

```csharp
public record BollingerBandsResult : TechnicalAnalysis.Common.TripleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.BollingerBandsResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.TripleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.tripleoutputresult 'TechnicalAnalysis\.Common\.TripleOutputResult') &#129106; BollingerBandsResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[BollingerBandsResult](BollingerBandsResult.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [BollingerBandsResult\(RetCode, int, int, double\[\], double\[\], double\[\]\)](BollingerBandsResult.BollingerBandsResult(RetCode,int,int,double[],double[],double[]).md 'TechnicalAnalysis\.Functions\.BollingerBandsResult\.BollingerBandsResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\], double\[\]\)') | Initializes a new instance of the [BollingerBandsResult](BollingerBandsResult.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult') class\. |

| Properties | |
| :--- | :--- |
| [RealLowerBand](BollingerBandsResult.RealLowerBand.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult\.RealLowerBand') | Gets the array of lower band values\. The lower band is typically calculated as the middle band minus \(n × standard deviation\)\. Prices near or below this band may indicate oversold conditions\. |
| [RealMiddleBand](BollingerBandsResult.RealMiddleBand.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult\.RealMiddleBand') | Gets the array of middle band values\. The middle band is a simple moving average of the specified period\. This band represents the intermediate trend of the price\. |
| [RealUpperBand](BollingerBandsResult.RealUpperBand.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult\.RealUpperBand') | Gets the array of upper band values\. The upper band is typically calculated as the middle band plus \(n × standard deviation\)\. Prices near or above this band may indicate overbought conditions\. |
