#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## DivResult Class

Represents the result of the vector division operation \(DIV function\)\.

```csharp
public record DivResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.DivResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; DivResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[DivResult](DivResult.md 'TechnicalAnalysis\.Functions\.DivResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The DIV function performs element\-wise division of two input arrays,
producing an output array where each element is the quotient of the corresponding
elements from the input arrays \(first array divided by second array\)\.

| Constructors | |
| :--- | :--- |
| [DivResult\(RetCode, int, int, double\[\]\)](DivResult.DivResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.DivResult\.DivResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [DivResult](DivResult.md 'TechnicalAnalysis\.Functions\.DivResult') class\. |
