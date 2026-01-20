#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MomentumStochResult Class

Represents the result of a Stochastic Oscillator momentum analysis\.

```csharp
public sealed record MomentumStochResult : TechnicalAnalysis.Functions.AnalysisResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [AnalysisResult](AnalysisResult.md 'TechnicalAnalysis\.Functions\.AnalysisResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; MomentumStochResult

| Constructors | |
| :--- | :--- |
| [MomentumStochResult\(RetCode, int, int, double\[\], double\[\], int, int, int\)](MomentumStochResult.MomentumStochResult(RetCode,int,int,double[],double[],int,int,int).md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.MomentumStochResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\], int, int, int\)') | Represents the result of a Stochastic Oscillator momentum analysis\. |

| Properties | |
| :--- | :--- |
| [CurrentD](MomentumStochResult.CurrentD.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.CurrentD') | Gets the most recent Slow %D value\. |
| [CurrentK](MomentumStochResult.CurrentK.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.CurrentK') | Gets the most recent Slow %K value\. |
| [FastKPeriod](MomentumStochResult.FastKPeriod.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.FastKPeriod') | The number of periods used for %K calculation\. |
| [IsBearish](MomentumStochResult.IsBearish.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.IsBearish') | Gets a value indicating whether %K is below %D \(bearish\)\. |
| [IsBullish](MomentumStochResult.IsBullish.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.IsBullish') | Gets a value indicating whether %K is above %D \(bullish\)\. |
| [IsOverbought](MomentumStochResult.IsOverbought.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.IsOverbought') | Gets a value indicating whether the Stochastic is in overbought territory \(above 80\)\. |
| [IsOversold](MomentumStochResult.IsOversold.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.IsOversold') | Gets a value indicating whether the Stochastic is in oversold territory \(below 20\)\. |
| [IsSuccess](MomentumStochResult.IsSuccess.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.IsSuccess') | Gets a value indicating whether the analysis completed successfully\. |
| [SlowD](MomentumStochResult.SlowD.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.SlowD') | The calculated Slow %D values \(moving average of Slow %K\)\. |
| [SlowDPeriod](MomentumStochResult.SlowDPeriod.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.SlowDPeriod') | The number of periods used for %D calculation\. |
| [SlowK](MomentumStochResult.SlowK.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.SlowK') | The calculated Slow %K values \(smoothed %K\)\. |
| [SlowKPeriod](MomentumStochResult.SlowKPeriod.md 'TechnicalAnalysis\.Functions\.MomentumStochResult\.SlowKPeriod') | The smoothing periods for %K\. |
