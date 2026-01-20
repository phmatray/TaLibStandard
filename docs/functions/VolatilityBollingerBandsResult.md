#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## VolatilityBollingerBandsResult Class

Represents the result of a Bollinger Bands volatility analysis\.

```csharp
public sealed record VolatilityBollingerBandsResult : TechnicalAnalysis.Functions.AnalysisResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [AnalysisResult](AnalysisResult.md 'TechnicalAnalysis\.Functions\.AnalysisResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; VolatilityBollingerBandsResult

| Constructors | |
| :--- | :--- |
| [VolatilityBollingerBandsResult\(RetCode, int, int, double\[\], double\[\], double\[\], int, double, double, MAType\)](VolatilityBollingerBandsResult.VolatilityBollingerBandsResult(RetCode,int,int,double[],double[],double[],int,double,double,MAType).md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.VolatilityBollingerBandsResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\], double\[\], int, double, double, TechnicalAnalysis\.Common\.MAType\)') | Represents the result of a Bollinger Bands volatility analysis\. |

| Properties | |
| :--- | :--- |
| [BandWidth](VolatilityBollingerBandsResult.BandWidth.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.BandWidth') | Gets the current band width as a percentage of the middle band\. |
| [CurrentLower](VolatilityBollingerBandsResult.CurrentLower.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.CurrentLower') | Gets the most recent lower band value\. |
| [CurrentMiddle](VolatilityBollingerBandsResult.CurrentMiddle.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.CurrentMiddle') | Gets the most recent middle band value\. |
| [CurrentUpper](VolatilityBollingerBandsResult.CurrentUpper.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.CurrentUpper') | Gets the most recent upper band value\. |
| [IsExpansion](VolatilityBollingerBandsResult.IsExpansion.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.IsExpansion') | Gets a value indicating whether the bands are expanding\. |
| [IsSqueeze](VolatilityBollingerBandsResult.IsSqueeze.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.IsSqueeze') | Gets a value indicating whether the bands are contracting \(Bollinger Squeeze\)\. |
| [IsSuccess](VolatilityBollingerBandsResult.IsSuccess.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.IsSuccess') | Gets a value indicating whether the analysis completed successfully\. |
| [LowerBand](VolatilityBollingerBandsResult.LowerBand.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.LowerBand') | The calculated lower band values\. |
| [MAType](VolatilityBollingerBandsResult.MAType.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.MAType') | The type of moving average used\. |
| [MiddleBand](VolatilityBollingerBandsResult.MiddleBand.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.MiddleBand') | The calculated middle band \(moving average\) values\. |
| [NbDevDn](VolatilityBollingerBandsResult.NbDevDn.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.NbDevDn') | The number of standard deviations used for the lower band\. |
| [NbDevUp](VolatilityBollingerBandsResult.NbDevUp.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.NbDevUp') | The number of standard deviations used for the upper band\. |
| [Period](VolatilityBollingerBandsResult.Period.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.Period') | The number of periods used in the calculation\. |
| [UpperBand](VolatilityBollingerBandsResult.UpperBand.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.UpperBand') | The calculated upper band values\. |

| Methods | |
| :--- | :--- |
| [GetPercentB\(double\)](VolatilityBollingerBandsResult.GetPercentB(double).md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult\.GetPercentB\(double\)') | Gets the %B indicator value for the most recent price point\. |
