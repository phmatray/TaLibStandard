#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## SinResult Class

Represents the result of the vector sine operation \(SIN function\)\.

```csharp
public record SinResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; SinResult

### Remarks
The SIN function calculates the sine of each element in the input array\.
Input values are expected to be in radians\. The result is an array where each
element represents the sine of the corresponding input angle, with values in the range \[\-1, 1\]\.

| Constructors | |
| :--- | :--- |
| [SinResult\(RetCode, int, int, double\[\]\)](SinResult.SinResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.SinResult\.SinResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [SinResult](SinResult.md 'TechnicalAnalysis\.Functions\.SinResult') class\. |
