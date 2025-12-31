#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AsinResult Class

Represents the result of the vector arcsine operation \(ASIN function\)\.

```csharp
public record AsinResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.AsinResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; AsinResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[AsinResult](AsinResult.md 'TechnicalAnalysis\.Functions\.AsinResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The ASIN function calculates the arcsine \(inverse sine\) of each element in the input array\.
The result is an array of angles in radians, where each element represents the arcsine
of the corresponding input value\. Input values must be in the range \[\-1, 1\]\.

| Constructors | |
| :--- | :--- |
| [AsinResult\(RetCode, int, int, double\[\]\)](AsinResult.AsinResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.AsinResult\.AsinResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [AsinResult](AsinResult.md 'TechnicalAnalysis\.Functions\.AsinResult') class\. |
