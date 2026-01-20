#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## HtTrendModeResult Class

Represents the result of the Hilbert Transform \- Trend vs Cycle Mode \(HT\_TRENDMODE\) calculation\.
This indicator determines whether the market is in a trending or cycling mode using Hilbert Transform analysis,
helping traders choose appropriate strategies for different market conditions\.

```csharp
public record HtTrendModeResult : TechnicalAnalysis.Common.IndicatorResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; HtTrendModeResult

| Constructors | |
| :--- | :--- |
| [HtTrendModeResult\(RetCode, int, int, int\[\]\)](HtTrendModeResult.HtTrendModeResult(RetCode,int,int,int[]).md 'TechnicalAnalysis\.Functions\.HtTrendModeResult\.HtTrendModeResult\(TechnicalAnalysis\.Common\.RetCode, int, int, int\[\]\)') | Initializes a new instance of the [HtTrendModeResult](HtTrendModeResult.md 'TechnicalAnalysis\.Functions\.HtTrendModeResult') class\. |

| Properties | |
| :--- | :--- |
| [Integers](HtTrendModeResult.Integers.md 'TechnicalAnalysis\.Functions\.HtTrendModeResult\.Integers') | Gets the array of trend mode indicator values\. Each value is either 0 \(indicating cycle/ranging mode\) or 1 \(indicating trending mode\)\. This binary output helps determine which trading strategies are most appropriate for current market conditions\. |
