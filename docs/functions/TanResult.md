#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TanResult Class

Represents the result of the vector tangent operation \(TAN function\)\.

```csharp
public record TanResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.TanResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; TanResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[TanResult](TanResult.md 'TechnicalAnalysis\.Functions\.TanResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The TAN function calculates the tangent of each element in the input array\.
Input values are expected to be in radians\. The tangent is defined as sin\(x\)/cos\(x\)\.
Note that tangent has vertical asymptotes at odd multiples of π/2, where the function is undefined\.

| Constructors | |
| :--- | :--- |
| [TanResult\(RetCode, int, int, double\[\]\)](TanResult.TanResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.TanResult\.TanResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [TanResult](TanResult.md 'TechnicalAnalysis\.Functions\.TanResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](TanResult.Real.md 'TechnicalAnalysis\.Functions\.TanResult\.Real') | Gets the array of tangent values resulting from the TAN operation\. |
