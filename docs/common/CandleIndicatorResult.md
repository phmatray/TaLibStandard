#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common')

## CandleIndicatorResult Class

Represents the result of the candlestick pattern indicator\.

```csharp
public record CandleIndicatorResult : TechnicalAnalysis.Common.IndicatorResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [IndicatorResult](IndicatorResult.md 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; CandleIndicatorResult

| Constructors | |
| :--- | :--- |
| [CandleIndicatorResult\(RetCode, int, int, int\[\]\)](CandleIndicatorResult.CandleIndicatorResult(RetCode,int,int,int[]).md 'TechnicalAnalysis\.Common\.CandleIndicatorResult\.CandleIndicatorResult\(TechnicalAnalysis\.Common\.RetCode, int, int, int\[\]\)') | Initializes a new instance of the CandleResult class\. |

| Properties | |
| :--- | :--- |
| [Integers](CandleIndicatorResult.Integers.md 'TechnicalAnalysis\.Common\.CandleIndicatorResult\.Integers') | Gets the array of integers indicating the presence of the candle pattern\. \(values are \-100, 0 or 100\) |
