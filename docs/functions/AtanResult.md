#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AtanResult Class

Represents the result of the vector arctangent operation \(ATAN function\)\.

```csharp
public record AtanResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.AtanResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; AtanResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[AtanResult](AtanResult.md 'TechnicalAnalysis\.Functions\.AtanResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The ATAN function calculates the arctangent \(inverse tangent\) of each element in the input array\.
The result is an array of angles in radians, where each element represents the arctangent
of the corresponding input value\. The output range is \(\-π/2, π/2\)\.

| Constructors | |
| :--- | :--- |
| [AtanResult\(RetCode, int, int, double\[\]\)](AtanResult.AtanResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.AtanResult\.AtanResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [AtanResult](AtanResult.md 'TechnicalAnalysis\.Functions\.AtanResult') class\. |
