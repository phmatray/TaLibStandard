#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## HtDcPeriodResult Class

Represents the result of the Hilbert Transform \- Dominant Cycle Period \(HT\_DCPERIOD\) calculation\.
This indicator identifies the dominant cycle period of market data using Hilbert Transform techniques,
providing insight into the cyclical nature of price movements\.

```csharp
public record HtDcPeriodResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.HtDcPeriodResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; HtDcPeriodResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[HtDcPeriodResult](HtDcPeriodResult.md 'TechnicalAnalysis\.Functions\.HtDcPeriodResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [HtDcPeriodResult\(RetCode, int, int, double\[\]\)](HtDcPeriodResult.HtDcPeriodResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.HtDcPeriodResult\.HtDcPeriodResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [HtDcPeriodResult](HtDcPeriodResult.md 'TechnicalAnalysis\.Functions\.HtDcPeriodResult') class\. |
