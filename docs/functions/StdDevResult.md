#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## StdDevResult Class

Represents the result of the Standard Deviation \(StdDev\) indicator calculation\.
Standard Deviation is a statistical measure of volatility that shows how much variation exists from the average \(mean\) price\.

```csharp
public record StdDevResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.StdDevResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; StdDevResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[StdDevResult](StdDevResult.md 'TechnicalAnalysis\.Functions\.StdDevResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [StdDevResult\(RetCode, int, int, double\[\]\)](StdDevResult.StdDevResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.StdDevResult\.StdDevResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [StdDevResult](StdDevResult.md 'TechnicalAnalysis\.Functions\.StdDevResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](StdDevResult.Real.md 'TechnicalAnalysis\.Functions\.StdDevResult\.Real') | Gets the array of Standard Deviation values\. Higher values indicate greater price volatility and dispersion from the mean\. Lower values suggest prices are staying close to the average with less volatility\. |
