#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## LnResult Class

Represents the result of the vector natural logarithm operation \(LN function\)\.

```csharp
public record LnResult : TechnicalAnalysis.Common.Abstractions.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.LnResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.abstractions.singleoutputresult 'TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult') &#129106; LnResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[LnResult](LnResult.md 'TechnicalAnalysis\.Functions\.LnResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The LN function calculates the natural logarithm \(base e\) of each element in the input array\.
The natural logarithm is the inverse of the exponential function\. Input values must be positive\.
For example, ln\(e\) = 1, ln\(1\) = 0\.

| Constructors | |
| :--- | :--- |
| [LnResult\(RetCode, int, int, double\[\]\)](LnResult.LnResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.LnResult\.LnResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [LnResult](LnResult.md 'TechnicalAnalysis\.Functions\.LnResult') class\. |
