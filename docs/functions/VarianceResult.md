#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## VarianceResult Class

Represents the result of the Variance indicator calculation\.
Variance is a statistical measure of volatility that represents the squared deviations from the mean price\.

```csharp
public record VarianceResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.VarianceResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; VarianceResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[VarianceResult](VarianceResult.md 'TechnicalAnalysis\.Functions\.VarianceResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [VarianceResult\(RetCode, int, int, double\[\]\)](VarianceResult.VarianceResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.VarianceResult\.VarianceResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [VarianceResult](VarianceResult.md 'TechnicalAnalysis\.Functions\.VarianceResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](VarianceResult.Real.md 'TechnicalAnalysis\.Functions\.VarianceResult\.Real') | Gets the array of Variance values\. Each value represents the average of the squared differences from the mean\. Variance is the square of standard deviation and provides a measure of price dispersion\. |
