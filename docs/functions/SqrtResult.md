#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## SqrtResult Class

Represents the result of the vector square root operation \(SQRT function\)\.

```csharp
public record SqrtResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; SqrtResult

### Remarks
The SQRT function calculates the square root of each element in the input array\.
Input values must be non\-negative \(zero or positive\)\. The square root is the value that,
when multiplied by itself, gives the original number\. For example, sqrt\(4\) = 2, sqrt\(9\) = 3\.

| Constructors | |
| :--- | :--- |
| [SqrtResult\(RetCode, int, int, double\[\]\)](SqrtResult.SqrtResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.SqrtResult\.SqrtResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [SqrtResult](SqrtResult.md 'TechnicalAnalysis\.Functions\.SqrtResult') class\. |
