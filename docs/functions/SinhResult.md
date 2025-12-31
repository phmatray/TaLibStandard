#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## SinhResult Class

Represents the result of the vector hyperbolic sine operation \(SINH function\)\.

```csharp
public record SinhResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.SinhResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; SinhResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[SinhResult](SinhResult.md 'TechnicalAnalysis\.Functions\.SinhResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The SINH function calculates the hyperbolic sine of each element in the input array\.
The hyperbolic sine is defined as sinh\(x\) = \(e^x \- e^\(\-x\)\) / 2\.
Unlike the regular sine function, hyperbolic sine can produce values outside the range \[\-1, 1\]\.

| Constructors | |
| :--- | :--- |
| [SinhResult\(RetCode, int, int, double\[\]\)](SinhResult.SinhResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.SinhResult\.SinhResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [SinhResult](SinhResult.md 'TechnicalAnalysis\.Functions\.SinhResult') class\. |
