#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## CosResult Class

Represents the result of the vector cosine operation \(COS function\)\.

```csharp
public record CosResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.CosResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; CosResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[CosResult](CosResult.md 'TechnicalAnalysis\.Functions\.CosResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The COS function calculates the cosine of each element in the input array\.
Input values are expected to be in radians\. The result is an array where each
element represents the cosine of the corresponding input angle, with values in the range \[\-1, 1\]\.

| Constructors | |
| :--- | :--- |
| [CosResult\(RetCode, int, int, double\[\]\)](CosResult.CosResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.CosResult\.CosResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [CosResult](CosResult.md 'TechnicalAnalysis\.Functions\.CosResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](CosResult.Real.md 'TechnicalAnalysis\.Functions\.CosResult\.Real') | Gets the array of cosine values resulting from the COS operation\. |
