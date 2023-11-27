#### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical.TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleAbandonedBaby<T> Class

Abandoned Baby (Pattern Recognition)

```csharp
public class CandleAbandonedBaby<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleAbandonedBaby_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleAbandonedBaby_T_.md#TechnicalAnalysis.Candles.CandleAbandonedBaby_T_.T 'TechnicalAnalysis.Candles.CandleAbandonedBaby<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleAbandonedBaby<T>

| Constructors | |
| :--- | :--- |
| [CandleAbandonedBaby(T[], T[], T[], T[])](CandleAbandonedBaby_T_.CandleAbandonedBaby(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleAbandonedBaby<T>.CandleAbandonedBaby(T[], T[], T[], T[])') | Abandoned Baby (Pattern Recognition) |

| Methods | |
| :--- | :--- |
| [Compute(int, int, T)](CandleAbandonedBaby_T_.Compute(int,int,T).md 'TechnicalAnalysis.Candles.CandleAbandonedBaby<T>.Compute(int, int, T)') | Computes the [CandleAbandonedBaby&lt;T&gt;](CandleAbandonedBaby_T_.md 'TechnicalAnalysis.Candles.CandleAbandonedBaby<T>') indicator. |
| [GetLookback()](CandleAbandonedBaby_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleAbandonedBaby<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleAbandonedBaby_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleAbandonedBaby<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
