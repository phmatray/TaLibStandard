#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TanhResult Class

Represents the result of the vector hyperbolic tangent operation \(TANH function\)\.

```csharp
public record TanhResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.TanhResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; TanhResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[TanhResult](TanhResult.md 'TechnicalAnalysis\.Functions\.TanhResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The TANH function calculates the hyperbolic tangent of each element in the input array\.
The hyperbolic tangent is defined as tanh\(x\) = sinh\(x\)/cosh\(x\) = \(e^x \- e^\(\-x\)\)/\(e^x \+ e^\(\-x\)\)\.
The output values are always in the range \(\-1, 1\), making it useful for normalization\.

| Constructors | |
| :--- | :--- |
| [TanhResult\(RetCode, int, int, double\[\]\)](TanhResult.TanhResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.TanhResult\.TanhResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [TanhResult](TanhResult.md 'TechnicalAnalysis\.Functions\.TanhResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](TanhResult.Real.md 'TechnicalAnalysis\.Functions\.TanhResult\.Real') | Gets the array of hyperbolic tangent values resulting from the TANH operation\. |
