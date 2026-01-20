#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## VolatilityAtrResult Class

Represents the result of an Average True Range \(ATR\) volatility analysis\.

```csharp
public sealed record VolatilityAtrResult : TechnicalAnalysis.Functions.AnalysisResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [AnalysisResult](AnalysisResult.md 'TechnicalAnalysis\.Functions\.AnalysisResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; VolatilityAtrResult

| Constructors | |
| :--- | :--- |
| [VolatilityAtrResult\(RetCode, int, int, double\[\], int\)](VolatilityAtrResult.VolatilityAtrResult(RetCode,int,int,double[],int).md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult\.VolatilityAtrResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)') | Represents the result of an Average True Range \(ATR\) volatility analysis\. |

| Properties | |
| :--- | :--- |
| [Current](VolatilityAtrResult.Current.md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult\.Current') | Gets the most recent ATR value\. |
| [IsHighVolatility](VolatilityAtrResult.IsHighVolatility.md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult\.IsHighVolatility') | Gets a value indicating whether volatility is high \(current ATR is above the average ATR\)\. |
| [IsLowVolatility](VolatilityAtrResult.IsLowVolatility.md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult\.IsLowVolatility') | Gets a value indicating whether volatility is low \(current ATR is below the average ATR\)\. |
| [IsSuccess](VolatilityAtrResult.IsSuccess.md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult\.IsSuccess') | Gets a value indicating whether the analysis completed successfully\. |
| [Period](VolatilityAtrResult.Period.md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult\.Period') | The number of periods used in the ATR calculation\. |
| [Values](VolatilityAtrResult.Values.md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult\.Values') | The calculated ATR values\. |
