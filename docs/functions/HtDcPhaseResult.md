#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## HtDcPhaseResult Class

Represents the result of the Hilbert Transform \- Dominant Cycle Phase \(HT\_DCPHASE\) calculation\.
This indicator measures the phase angle of the dominant market cycle using Hilbert Transform techniques,
helping to identify the current position within a price cycle\.

```csharp
public record HtDcPhaseResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.HtDcPhaseResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; HtDcPhaseResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[HtDcPhaseResult](HtDcPhaseResult.md 'TechnicalAnalysis\.Functions\.HtDcPhaseResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [HtDcPhaseResult\(RetCode, int, int, double\[\]\)](HtDcPhaseResult.HtDcPhaseResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.HtDcPhaseResult\.HtDcPhaseResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [HtDcPhaseResult](HtDcPhaseResult.md 'TechnicalAnalysis\.Functions\.HtDcPhaseResult') class\. |
