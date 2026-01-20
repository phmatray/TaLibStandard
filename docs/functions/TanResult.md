#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TanResult Class

Represents the result of the vector tangent operation \(TAN function\)\.

```csharp
public record TanResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; TanResult

### Remarks
The TAN function calculates the tangent of each element in the input array\.
Input values are expected to be in radians\. The tangent is defined as sin\(x\)/cos\(x\)\.
Note that tangent has vertical asymptotes at odd multiples of π/2, where the function is undefined\.

| Constructors | |
| :--- | :--- |
| [TanResult\(RetCode, int, int, double\[\]\)](TanResult.TanResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.TanResult\.TanResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [TanResult](TanResult.md 'TechnicalAnalysis\.Functions\.TanResult') class\. |
