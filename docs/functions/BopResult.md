#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## BopResult Class

Represents the result of calculating the Balance Of Power \(BOP\) indicator\.

```csharp
public record BopResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.BopResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; BopResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[BopResult](BopResult.md 'TechnicalAnalysis\.Functions\.BopResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The Balance Of Power indicator measures the strength of buyers versus sellers by
comparing the close price relative to the high\-low range\. Values range from \-1 to \+1,
where positive values indicate buying pressure and negative values indicate selling pressure\.

| Constructors | |
| :--- | :--- |
| [BopResult\(RetCode, int, int, double\[\]\)](BopResult.BopResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.BopResult\.BopResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [BopResult](BopResult.md 'TechnicalAnalysis\.Functions\.BopResult') class\. |
