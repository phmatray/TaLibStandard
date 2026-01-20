#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AnalysisResult Class

Represents an abstract base class for high\-level technical analysis results\.

```csharp
public abstract record AnalysisResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; AnalysisResult

Derived  
&#8627; [MomentumMacdResult](MomentumMacdResult.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult')  
&#8627; [MomentumRsiResult](MomentumRsiResult.md 'TechnicalAnalysis\.Functions\.MomentumRsiResult')  
&#8627; [MomentumStochResult](MomentumStochResult.md 'TechnicalAnalysis\.Functions\.MomentumStochResult')  
&#8627; [TrendAdxResult](TrendAdxResult.md 'TechnicalAnalysis\.Functions\.TrendAdxResult')  
&#8627; [TrendEmaResult](TrendEmaResult.md 'TechnicalAnalysis\.Functions\.TrendEmaResult')  
&#8627; [TrendSmaResult](TrendSmaResult.md 'TechnicalAnalysis\.Functions\.TrendSmaResult')  
&#8627; [VolatilityAtrResult](VolatilityAtrResult.md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult')  
&#8627; [VolatilityBollingerBandsResult](VolatilityBollingerBandsResult.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult')

| Constructors | |
| :--- | :--- |
| [AnalysisResult\(RetCode, int, int\)](AnalysisResult.AnalysisResult(RetCode,int,int).md 'TechnicalAnalysis\.Functions\.AnalysisResult\.AnalysisResult\(TechnicalAnalysis\.Common\.RetCode, int, int\)') | Initializes a new instance of the AnalysisResult class\. |

| Properties | |
| :--- | :--- |
| [BegIdx](AnalysisResult.BegIdx.md 'TechnicalAnalysis\.Functions\.AnalysisResult\.BegIdx') | Gets the beginning index of the analyzed output series\. |
| [NBElement](AnalysisResult.NBElement.md 'TechnicalAnalysis\.Functions\.AnalysisResult\.NBElement') | Gets the number of elements in the analyzed output series\. |
| [RetCode](AnalysisResult.RetCode.md 'TechnicalAnalysis\.Functions\.AnalysisResult\.RetCode') | Gets the return code indicating the status of the analysis calculation\. |
