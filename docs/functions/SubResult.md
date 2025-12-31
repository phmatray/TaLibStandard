#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## SubResult Class

Represents the result of the vector subtraction operation \(SUB function\)\.

```csharp
public record SubResult : TechnicalAnalysis.Common.Abstractions.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.SubResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.abstractions.singleoutputresult 'TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult') &#129106; SubResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[SubResult](SubResult.md 'TechnicalAnalysis\.Functions\.SubResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The SUB function performs element\-wise subtraction of two input arrays,
producing an output array where each element is the difference between the corresponding
elements from the input arrays \(first array minus second array\)\.

| Constructors | |
| :--- | :--- |
| [SubResult\(RetCode, int, int, double\[\]\)](SubResult.SubResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.SubResult\.SubResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [SubResult](SubResult.md 'TechnicalAnalysis\.Functions\.SubResult') class\. |
