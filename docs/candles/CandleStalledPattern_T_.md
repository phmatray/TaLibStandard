#### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical.TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleStalledPattern<T> Class

Stalled Pattern (Pattern Recognition)

```csharp
public class CandleStalledPattern<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleStalledPattern_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleStalledPattern_T_.md#TechnicalAnalysis.Candles.CandleStalledPattern_T_.T 'TechnicalAnalysis.Candles.CandleStalledPattern<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleStalledPattern<T>

| Constructors | |
| :--- | :--- |
| [CandleStalledPattern(T[], T[], T[], T[])](CandleStalledPattern_T_.CandleStalledPattern(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleStalledPattern<T>.CandleStalledPattern(T[], T[], T[], T[])') | Stalled Pattern (Pattern Recognition) |

| Methods | |
| :--- | :--- |
| [Compute(int, int)](CandleStalledPattern_T_.Compute(int,int).md 'TechnicalAnalysis.Candles.CandleStalledPattern<T>.Compute(int, int)') | Computes the [CandleStalledPattern&lt;T&gt;](CandleStalledPattern_T_.md 'TechnicalAnalysis.Candles.CandleStalledPattern<T>') indicator. |
| [GetLookback()](CandleStalledPattern_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleStalledPattern<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleStalledPattern_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleStalledPattern<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
