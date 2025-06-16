#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## SinResult Class

Represents the result of the vector sine operation \(SIN function\)\.

```csharp
public record SinResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.SinResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; SinResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[SinResult](SinResult.md 'TechnicalAnalysis\.Functions\.SinResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The SIN function calculates the sine of each element in the input array\.
Input values are expected to be in radians\. The result is an array where each
element represents the sine of the corresponding input angle, with values in the range \[\-1, 1\]\.

| Constructors | |
| :--- | :--- |
| [SinResult\(RetCode, int, int, double\[\]\)](SinResult.SinResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.SinResult\.SinResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [SinResult](SinResult.md 'TechnicalAnalysis\.Functions\.SinResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](SinResult.Real.md 'TechnicalAnalysis\.Functions\.SinResult\.Real') | Gets the array of sine values resulting from the SIN operation\. |
