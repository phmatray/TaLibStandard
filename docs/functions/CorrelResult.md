#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## CorrelResult Class

Represents the result of the Pearson Correlation Coefficient calculation\.

```csharp
public record CorrelResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.CorrelResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; CorrelResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The Correlation Coefficient measures the linear relationship between two data series, 
typically two securities or a security and a benchmark\. Values range from \-1 to \+1, 
where \+1 indicates perfect positive correlation \(both move in the same direction\), 
\-1 indicates perfect negative correlation \(move in opposite directions\), and 0 indicates 
no linear relationship\. This statistical measure is crucial for portfolio diversification, 
pairs trading strategies, and understanding market relationships\.

| Constructors | |
| :--- | :--- |
| [CorrelResult\(RetCode, int, int, double\[\]\)](CorrelResult.CorrelResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.CorrelResult\.CorrelResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](CorrelResult.Real.md 'TechnicalAnalysis\.Functions\.CorrelResult\.Real') | Gets the array of correlation coefficient values\. |
