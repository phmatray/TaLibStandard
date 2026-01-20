#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TrendSmaResult Class

Represents the result of a Simple Moving Average \(SMA\) trend analysis\.

```csharp
public sealed record TrendSmaResult : TechnicalAnalysis.Functions.AnalysisResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [AnalysisResult](AnalysisResult.md 'TechnicalAnalysis\.Functions\.AnalysisResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; TrendSmaResult

| Constructors | |
| :--- | :--- |
| [TrendSmaResult\(RetCode, int, int, double\[\], int\)](TrendSmaResult.TrendSmaResult(RetCode,int,int,double[],int).md 'TechnicalAnalysis\.Functions\.TrendSmaResult\.TrendSmaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)') | Represents the result of a Simple Moving Average \(SMA\) trend analysis\. |

| Properties | |
| :--- | :--- |
| [Current](TrendSmaResult.Current.md 'TechnicalAnalysis\.Functions\.TrendSmaResult\.Current') | Gets the most recent SMA value\. |
| [IsSuccess](TrendSmaResult.IsSuccess.md 'TechnicalAnalysis\.Functions\.TrendSmaResult\.IsSuccess') | Gets a value indicating whether the analysis completed successfully\. |
| [Period](TrendSmaResult.Period.md 'TechnicalAnalysis\.Functions\.TrendSmaResult\.Period') | The number of periods used in the SMA calculation\. |
| [Values](TrendSmaResult.Values.md 'TechnicalAnalysis\.Functions\.TrendSmaResult\.Values') | The calculated SMA values\. |
