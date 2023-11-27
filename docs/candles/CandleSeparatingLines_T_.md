#### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical.TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleSeparatingLines<T> Class

Separating Lines (Pattern Recognition)

```csharp
public class CandleSeparatingLines<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleSeparatingLines_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleSeparatingLines_T_.md#TechnicalAnalysis.Candles.CandleSeparatingLines_T_.T 'TechnicalAnalysis.Candles.CandleSeparatingLines<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleSeparatingLines<T>

| Constructors | |
| :--- | :--- |
| [CandleSeparatingLines(T[], T[], T[], T[])](CandleSeparatingLines_T_.CandleSeparatingLines(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleSeparatingLines<T>.CandleSeparatingLines(T[], T[], T[], T[])') | Separating Lines (Pattern Recognition) |

| Methods | |
| :--- | :--- |
| [Compute(int, int)](CandleSeparatingLines_T_.Compute(int,int).md 'TechnicalAnalysis.Candles.CandleSeparatingLines<T>.Compute(int, int)') | Computes the [CandleSeparatingLines&lt;T&gt;](CandleSeparatingLines_T_.md 'TechnicalAnalysis.Candles.CandleSeparatingLines<T>') indicator. |
| [GetLookback()](CandleSeparatingLines_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleSeparatingLines<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleSeparatingLines_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleSeparatingLines<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
