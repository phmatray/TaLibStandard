#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## DivResult Class

Represents the result of the vector division operation \(DIV function\)\.

```csharp
public record DivResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.DivResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; DivResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[DivResult](DivResult.md 'TechnicalAnalysis\.Functions\.DivResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The DIV function performs element\-wise division of two input arrays,
producing an output array where each element is the quotient of the corresponding
elements from the input arrays \(first array divided by second array\)\.

| Constructors | |
| :--- | :--- |
| [DivResult\(RetCode, int, int, double\[\]\)](DivResult.DivResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.DivResult\.DivResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [DivResult](DivResult.md 'TechnicalAnalysis\.Functions\.DivResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](DivResult.Real.md 'TechnicalAnalysis\.Functions\.DivResult\.Real') | Gets the array of quotient values resulting from the element\-wise division operation\. |
