#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## DemaResult Class

Represents the result of calculating the Double Exponential Moving Average \(DEMA\) indicator\.

```csharp
public record DemaResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.DemaResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; DemaResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[DemaResult](DemaResult.md 'TechnicalAnalysis\.Functions\.DemaResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
DEMA is a technical indicator that uses two exponential moving averages to eliminate lag\.
It provides a smoother and more responsive moving average compared to traditional EMAs,
making it particularly useful for identifying trend changes more quickly\.

| Constructors | |
| :--- | :--- |
| [DemaResult\(RetCode, int, int, double\[\]\)](DemaResult.DemaResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.DemaResult\.DemaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [DemaResult](DemaResult.md 'TechnicalAnalysis\.Functions\.DemaResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](DemaResult.Real.md 'TechnicalAnalysis\.Functions\.DemaResult\.Real') | Gets the array of double exponential moving average values\. |
