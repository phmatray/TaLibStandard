#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## Log10Result Class

Represents the result of the vector base\-10 logarithm operation \(LOG10 function\)\.

```csharp
public record Log10Result : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; Log10Result

### Remarks
The LOG10 function calculates the base\-10 logarithm of each element in the input array\.
The base\-10 logarithm answers the question: "10 to what power equals this number?"\.
Input values must be positive\. For example, log10\(100\) = 2, log10\(10\) = 1, log10\(1\) = 0\.

| Constructors | |
| :--- | :--- |
| [Log10Result\(RetCode, int, int, double\[\]\)](Log10Result.Log10Result(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.Log10Result\.Log10Result\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [Log10Result](Log10Result.md 'TechnicalAnalysis\.Functions\.Log10Result') class\. |
