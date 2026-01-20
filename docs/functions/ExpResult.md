#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## ExpResult Class

Represents the result of the vector exponential operation \(EXP function\)\.

```csharp
public record ExpResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; ExpResult

### Remarks
The EXP function calculates the exponential \(e^x\) of each element in the input array,
where e is Euler's number \(approximately 2\.71828\)\. The result is an array where each
element represents e raised to the power of the corresponding input value\.

| Constructors | |
| :--- | :--- |
| [ExpResult\(RetCode, int, int, double\[\]\)](ExpResult.ExpResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.ExpResult\.ExpResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [ExpResult](ExpResult.md 'TechnicalAnalysis\.Functions\.ExpResult') class\. |
