#### [TechnicalAnalysis.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical.TechnicalAnalysis.Common')
### [TechnicalAnalysis.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis.Common')

## CandleIndicatorResult Class

Represents the result of the candlestick pattern indicator.

```csharp
public class CandleIndicatorResult : TechnicalAnalysis.Common.IndicatorResult,
System.IEquatable<TechnicalAnalysis.Common.CandleIndicatorResult>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [IndicatorResult](IndicatorResult.md 'TechnicalAnalysis.Common.IndicatorResult') &#129106; CandleIndicatorResult

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[CandleIndicatorResult](CandleIndicatorResult.md 'TechnicalAnalysis.Common.CandleIndicatorResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [CandleIndicatorResult(RetCode, int, int, int[])](CandleIndicatorResult.CandleIndicatorResult(RetCode,int,int,int[]).md 'TechnicalAnalysis.Common.CandleIndicatorResult.CandleIndicatorResult(TechnicalAnalysis.Common.RetCode, int, int, int[])') | Initializes a new instance of the CandleResult class. |

| Properties | |
| :--- | :--- |
| [Integers](CandleIndicatorResult.Integers.md 'TechnicalAnalysis.Common.CandleIndicatorResult.Integers') | Gets the array of integers indicating the presence of the candle pattern. (values are -100, 0 or 100) |
