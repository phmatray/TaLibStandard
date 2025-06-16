#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MaxResult Class

Represents the result of calculating the highest values over a specified period\.
The MAX function identifies the maximum value within a rolling window of data points\.

```csharp
public record MaxResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MaxResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MaxResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[MaxResult](MaxResult.md 'TechnicalAnalysis\.Functions\.MaxResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [MaxResult\(RetCode, int, int, double\[\]\)](MaxResult.MaxResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MaxResult\.MaxResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MaxResult](MaxResult.md 'TechnicalAnalysis\.Functions\.MaxResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](MaxResult.Real.md 'TechnicalAnalysis\.Functions\.MaxResult\.Real') | Gets the array of maximum values\. Each value represents the highest data point within the specified rolling period\. |
