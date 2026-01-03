#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## CeilResult Class

Represents the result of the vector ceiling operation \(CEIL function\)\.

```csharp
public record CeilResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.CeilResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; CeilResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[CeilResult](CeilResult.md 'TechnicalAnalysis\.Functions\.CeilResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The CEIL function calculates the ceiling of each element in the input array\.
The ceiling of a number is the smallest integer that is greater than or equal to that number\.
For example, ceil\(2\.3\) = 3, ceil\(\-2\.3\) = \-2, ceil\(5\.0\) = 5\.

| Constructors | |
| :--- | :--- |
| [CeilResult\(RetCode, int, int, double\[\]\)](CeilResult.CeilResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.CeilResult\.CeilResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [CeilResult](CeilResult.md 'TechnicalAnalysis\.Functions\.CeilResult') class\. |
