#### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical.TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleEngulfing<T> Class

Engulfing Pattern (Pattern Recognition)

```csharp
public class CandleEngulfing<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleEngulfing_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleEngulfing_T_.md#TechnicalAnalysis.Candles.CandleEngulfing_T_.T 'TechnicalAnalysis.Candles.CandleEngulfing<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleEngulfing<T>

| Constructors | |
| :--- | :--- |
| [CandleEngulfing(T[], T[], T[], T[])](CandleEngulfing_T_.CandleEngulfing(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleEngulfing<T>.CandleEngulfing(T[], T[], T[], T[])') | Engulfing Pattern (Pattern Recognition) |

| Methods | |
| :--- | :--- |
| [Compute(int, int)](CandleEngulfing_T_.Compute(int,int).md 'TechnicalAnalysis.Candles.CandleEngulfing<T>.Compute(int, int)') | Computes the [CandleEngulfing&lt;T&gt;](CandleEngulfing_T_.md 'TechnicalAnalysis.Candles.CandleEngulfing<T>') indicator. |
| [GetLookback()](CandleEngulfing_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleEngulfing<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleEngulfing_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleEngulfing<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
