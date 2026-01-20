#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TrendEmaResult Class

Represents the result of an Exponential Moving Average \(EMA\) trend analysis\.

```csharp
public sealed record TrendEmaResult : TechnicalAnalysis.Functions.AnalysisResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [AnalysisResult](AnalysisResult.md 'TechnicalAnalysis\.Functions\.AnalysisResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; TrendEmaResult

| Constructors | |
| :--- | :--- |
| [TrendEmaResult\(RetCode, int, int, double\[\], int\)](TrendEmaResult.TrendEmaResult(RetCode,int,int,double[],int).md 'TechnicalAnalysis\.Functions\.TrendEmaResult\.TrendEmaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)') | Represents the result of an Exponential Moving Average \(EMA\) trend analysis\. |

| Properties | |
| :--- | :--- |
| [Current](TrendEmaResult.Current.md 'TechnicalAnalysis\.Functions\.TrendEmaResult\.Current') | Gets the most recent EMA value\. |
| [IsSuccess](TrendEmaResult.IsSuccess.md 'TechnicalAnalysis\.Functions\.TrendEmaResult\.IsSuccess') | Gets a value indicating whether the analysis completed successfully\. |
| [Period](TrendEmaResult.Period.md 'TechnicalAnalysis\.Functions\.TrendEmaResult\.Period') | The number of periods used in the EMA calculation\. |
| [Values](TrendEmaResult.Values.md 'TechnicalAnalysis\.Functions\.TrendEmaResult\.Values') | The calculated EMA values\. |
