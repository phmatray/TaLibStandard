#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AddResult Class

Represents the result of the vector addition operation \(ADD function\)\.

```csharp
public record AddResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.AddResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; AddResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[AddResult](AddResult.md 'TechnicalAnalysis\.Functions\.AddResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The ADD function performs element\-wise addition of two input arrays,
producing an output array where each element is the sum of the corresponding
elements from the input arrays\.

| Constructors | |
| :--- | :--- |
| [AddResult\(RetCode, int, int, double\[\]\)](AddResult.AddResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.AddResult\.AddResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [AddResult](AddResult.md 'TechnicalAnalysis\.Functions\.AddResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](AddResult.Real.md 'TechnicalAnalysis\.Functions\.AddResult\.Real') | Gets the array of sum values resulting from the element\-wise addition operation\. |
