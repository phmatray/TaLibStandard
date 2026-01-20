#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TrendAdxResult Class

Represents the result of an Average Directional Index \(ADX\) trend analysis\.

```csharp
public sealed record TrendAdxResult : TechnicalAnalysis.Functions.AnalysisResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [AnalysisResult](AnalysisResult.md 'TechnicalAnalysis\.Functions\.AnalysisResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; TrendAdxResult

| Constructors | |
| :--- | :--- |
| [TrendAdxResult\(RetCode, int, int, double\[\], int\)](TrendAdxResult.TrendAdxResult(RetCode,int,int,double[],int).md 'TechnicalAnalysis\.Functions\.TrendAdxResult\.TrendAdxResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)') | Represents the result of an Average Directional Index \(ADX\) trend analysis\. |

| Properties | |
| :--- | :--- |
| [Current](TrendAdxResult.Current.md 'TechnicalAnalysis\.Functions\.TrendAdxResult\.Current') | Gets the most recent ADX value\. |
| [IsEmergingTrend](TrendAdxResult.IsEmergingTrend.md 'TechnicalAnalysis\.Functions\.TrendAdxResult\.IsEmergingTrend') | Gets a value indicating whether the trend is emerging \(ADX between 20 and 25\)\. |
| [IsStrongTrend](TrendAdxResult.IsStrongTrend.md 'TechnicalAnalysis\.Functions\.TrendAdxResult\.IsStrongTrend') | Gets a value indicating whether the trend is strong \(ADX above 25\)\. |
| [IsSuccess](TrendAdxResult.IsSuccess.md 'TechnicalAnalysis\.Functions\.TrendAdxResult\.IsSuccess') | Gets a value indicating whether the analysis completed successfully\. |
| [IsVeryStrongTrend](TrendAdxResult.IsVeryStrongTrend.md 'TechnicalAnalysis\.Functions\.TrendAdxResult\.IsVeryStrongTrend') | Gets a value indicating whether the trend is very strong \(ADX above 40\)\. |
| [IsWeakTrend](TrendAdxResult.IsWeakTrend.md 'TechnicalAnalysis\.Functions\.TrendAdxResult\.IsWeakTrend') | Gets a value indicating whether the trend is weak \(ADX below 20\)\. |
| [Period](TrendAdxResult.Period.md 'TechnicalAnalysis\.Functions\.TrendAdxResult\.Period') | The number of periods used in the ADX calculation\. |
| [Values](TrendAdxResult.Values.md 'TechnicalAnalysis\.Functions\.TrendAdxResult\.Values') | The calculated ADX values\. |
