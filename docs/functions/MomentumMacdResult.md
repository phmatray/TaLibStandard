#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MomentumMacdResult Class

Represents the result of a Moving Average Convergence Divergence \(MACD\) momentum analysis\.

```csharp
public sealed record MomentumMacdResult : TechnicalAnalysis.Functions.AnalysisResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [AnalysisResult](AnalysisResult.md 'TechnicalAnalysis\.Functions\.AnalysisResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; MomentumMacdResult

| Constructors | |
| :--- | :--- |
| [MomentumMacdResult\(RetCode, int, int, double\[\], double\[\], double\[\], int, int, int\)](MomentumMacdResult.MomentumMacdResult(RetCode,int,int,double[],double[],double[],int,int,int).md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.MomentumMacdResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\], double\[\], int, int, int\)') | Represents the result of a Moving Average Convergence Divergence \(MACD\) momentum analysis\. |

| Properties | |
| :--- | :--- |
| [CurrentHistogram](MomentumMacdResult.CurrentHistogram.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.CurrentHistogram') | Gets the most recent histogram value\. |
| [CurrentMacd](MomentumMacdResult.CurrentMacd.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.CurrentMacd') | Gets the most recent MACD line value\. |
| [CurrentSignal](MomentumMacdResult.CurrentSignal.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.CurrentSignal') | Gets the most recent signal line value\. |
| [FastPeriod](MomentumMacdResult.FastPeriod.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.FastPeriod') | The number of periods used for the fast EMA\. |
| [Histogram](MomentumMacdResult.Histogram.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.Histogram') | The calculated histogram values \(MACD line \- signal line\)\. |
| [IsBearish](MomentumMacdResult.IsBearish.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.IsBearish') | Gets a value indicating whether the MACD line is below the signal line \(bearish\)\. |
| [IsBullish](MomentumMacdResult.IsBullish.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.IsBullish') | Gets a value indicating whether the MACD line is above the signal line \(bullish\)\. |
| [IsNegativeMomentum](MomentumMacdResult.IsNegativeMomentum.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.IsNegativeMomentum') | Gets a value indicating whether the MACD line is below zero \(negative momentum\)\. |
| [IsPositiveMomentum](MomentumMacdResult.IsPositiveMomentum.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.IsPositiveMomentum') | Gets a value indicating whether the MACD line is above zero \(positive momentum\)\. |
| [IsSuccess](MomentumMacdResult.IsSuccess.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.IsSuccess') | Gets a value indicating whether the analysis completed successfully\. |
| [MacdLine](MomentumMacdResult.MacdLine.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.MacdLine') | The calculated MACD line values \(fast EMA \- slow EMA\)\. |
| [SignalLine](MomentumMacdResult.SignalLine.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.SignalLine') | The calculated signal line values \(EMA of MACD line\)\. |
| [SignalPeriod](MomentumMacdResult.SignalPeriod.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.SignalPeriod') | The number of periods used for the signal line\. |
| [SlowPeriod](MomentumMacdResult.SlowPeriod.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult\.SlowPeriod') | The number of periods used for the slow EMA\. |
