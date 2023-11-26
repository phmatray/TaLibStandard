#### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md 'TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleTakuri<T> Class

```csharp
public class CandleTakuri<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleTakuri_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleTakuri_T_.md#TechnicalAnalysis.Candles.CandleTakuri_T_.T 'TechnicalAnalysis.Candles.CandleTakuri<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleTakuri<T>

| Constructors | |
| :--- | :--- |
| [CandleTakuri(T[], T[], T[], T[])](CandleTakuri_T_.CandleTakuri(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleTakuri<T>.CandleTakuri(T[], T[], T[], T[])') | |

| Methods | |
| :--- | :--- |
| [Compute(int, int)](CandleTakuri_T_.Compute(int,int).md 'TechnicalAnalysis.Candles.CandleTakuri<T>.Compute(int, int)') | |
| [GetLookback()](CandleTakuri_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleTakuri<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleTakuri_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleTakuri<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
