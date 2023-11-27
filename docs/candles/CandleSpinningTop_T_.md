#### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical.TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleSpinningTop<T> Class

Spinning Top (Pattern Recognition)

```csharp
public class CandleSpinningTop<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleSpinningTop_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleSpinningTop_T_.md#TechnicalAnalysis.Candles.CandleSpinningTop_T_.T 'TechnicalAnalysis.Candles.CandleSpinningTop<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleSpinningTop<T>

| Constructors | |
| :--- | :--- |
| [CandleSpinningTop(T[], T[], T[], T[])](CandleSpinningTop_T_.CandleSpinningTop(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleSpinningTop<T>.CandleSpinningTop(T[], T[], T[], T[])') | Spinning Top (Pattern Recognition) |

| Methods | |
| :--- | :--- |
| [Compute(int, int)](CandleSpinningTop_T_.Compute(int,int).md 'TechnicalAnalysis.Candles.CandleSpinningTop<T>.Compute(int, int)') | Computes the [CandleSpinningTop&lt;T&gt;](CandleSpinningTop_T_.md 'TechnicalAnalysis.Candles.CandleSpinningTop<T>') indicator. |
| [GetLookback()](CandleSpinningTop_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleSpinningTop<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleSpinningTop_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleSpinningTop<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
