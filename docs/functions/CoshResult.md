#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## CoshResult Class

Represents the result of the vector hyperbolic cosine operation \(COSH function\)\.

```csharp
public record CoshResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.CoshResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; CoshResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[CoshResult](CoshResult.md 'TechnicalAnalysis\.Functions\.CoshResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The COSH function calculates the hyperbolic cosine of each element in the input array\.
The hyperbolic cosine is defined as cosh\(x\) = \(e^x \+ e^\(\-x\)\) / 2\.
The result values are always greater than or equal to 1\.

| Constructors | |
| :--- | :--- |
| [CoshResult\(RetCode, int, int, double\[\]\)](CoshResult.CoshResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.CoshResult\.CoshResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [CoshResult](CoshResult.md 'TechnicalAnalysis\.Functions\.CoshResult') class\. |
