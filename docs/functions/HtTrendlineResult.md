#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## HtTrendlineResult Class

Represents the result of the Hilbert Transform \- Instantaneous Trendline \(HT\_TRENDLINE\) calculation\.
This indicator creates a smooth trendline by removing the dominant cycle component from price data,
effectively filtering out short\-term fluctuations to reveal the underlying trend\.

```csharp
public record HtTrendlineResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.HtTrendlineResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; HtTrendlineResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[HtTrendlineResult](HtTrendlineResult.md 'TechnicalAnalysis\.Functions\.HtTrendlineResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [HtTrendlineResult\(RetCode, int, int, double\[\]\)](HtTrendlineResult.HtTrendlineResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.HtTrendlineResult\.HtTrendlineResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [HtTrendlineResult](HtTrendlineResult.md 'TechnicalAnalysis\.Functions\.HtTrendlineResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](HtTrendlineResult.Real.md 'TechnicalAnalysis\.Functions\.HtTrendlineResult\.Real') | Gets the array of instantaneous trendline values\. These values represent a smoothed version of the price with dominant cycles filtered out, providing a clear view of the underlying trend direction and strength\. |
