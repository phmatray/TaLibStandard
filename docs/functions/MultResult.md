#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MultResult Class

Represents the result of the vector multiplication operation \(MULT function\)\.

```csharp
public record MultResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MultResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MultResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[MultResult](MultResult.md 'TechnicalAnalysis\.Functions\.MultResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The MULT function performs element\-wise multiplication of two input arrays,
producing an output array where each element is the product of the corresponding
elements from the input arrays\.

| Constructors | |
| :--- | :--- |
| [MultResult\(RetCode, int, int, double\[\]\)](MultResult.MultResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MultResult\.MultResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MultResult](MultResult.md 'TechnicalAnalysis\.Functions\.MultResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](MultResult.Real.md 'TechnicalAnalysis\.Functions\.MultResult\.Real') | Gets the array of product values resulting from the element\-wise multiplication operation\. |
