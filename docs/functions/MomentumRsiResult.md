#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MomentumRsiResult Class

Represents the result of a Relative Strength Index \(RSI\) momentum analysis\.

```csharp
public sealed record MomentumRsiResult : TechnicalAnalysis.Functions.AnalysisResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [AnalysisResult](AnalysisResult.md 'TechnicalAnalysis\.Functions\.AnalysisResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; MomentumRsiResult

| Constructors | |
| :--- | :--- |
| [MomentumRsiResult\(RetCode, int, int, double\[\], int\)](MomentumRsiResult.MomentumRsiResult(RetCode,int,int,double[],int).md 'TechnicalAnalysis\.Functions\.MomentumRsiResult\.MomentumRsiResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)') | Represents the result of a Relative Strength Index \(RSI\) momentum analysis\. |

| Properties | |
| :--- | :--- |
| [Current](MomentumRsiResult.Current.md 'TechnicalAnalysis\.Functions\.MomentumRsiResult\.Current') | Gets the most recent RSI value\. |
| [IsNeutral](MomentumRsiResult.IsNeutral.md 'TechnicalAnalysis\.Functions\.MomentumRsiResult\.IsNeutral') | Gets a value indicating whether the RSI is neutral \(between 40 and 60\)\. |
| [IsOverbought](MomentumRsiResult.IsOverbought.md 'TechnicalAnalysis\.Functions\.MomentumRsiResult\.IsOverbought') | Gets a value indicating whether the RSI is in overbought territory \(above 70\)\. |
| [IsOversold](MomentumRsiResult.IsOversold.md 'TechnicalAnalysis\.Functions\.MomentumRsiResult\.IsOversold') | Gets a value indicating whether the RSI is in oversold territory \(below 30\)\. |
| [IsSuccess](MomentumRsiResult.IsSuccess.md 'TechnicalAnalysis\.Functions\.MomentumRsiResult\.IsSuccess') | Gets a value indicating whether the analysis completed successfully\. |
| [Period](MomentumRsiResult.Period.md 'TechnicalAnalysis\.Functions\.MomentumRsiResult\.Period') | The number of periods used in the RSI calculation\. |
| [Values](MomentumRsiResult.Values.md 'TechnicalAnalysis\.Functions\.MomentumRsiResult\.Values') | The calculated RSI values\. |
