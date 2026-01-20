#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## HtTrendlineResult Class

Represents the result of the Hilbert Transform \- Instantaneous Trendline \(HT\_TRENDLINE\) calculation\.
This indicator creates a smooth trendline by removing the dominant cycle component from price data,
effectively filtering out short\-term fluctuations to reveal the underlying trend\.

```csharp
public record HtTrendlineResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; HtTrendlineResult

| Constructors | |
| :--- | :--- |
| [HtTrendlineResult\(RetCode, int, int, double\[\]\)](HtTrendlineResult.HtTrendlineResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.HtTrendlineResult\.HtTrendlineResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [HtTrendlineResult](HtTrendlineResult.md 'TechnicalAnalysis\.Functions\.HtTrendlineResult') class\. |
