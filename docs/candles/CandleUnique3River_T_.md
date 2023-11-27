#### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical.TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleUnique3River<T> Class

Unique 3 River (Pattern Recognition)

```csharp
public class CandleUnique3River<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleUnique3River_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleUnique3River_T_.md#TechnicalAnalysis.Candles.CandleUnique3River_T_.T 'TechnicalAnalysis.Candles.CandleUnique3River<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleUnique3River<T>

| Constructors | |
| :--- | :--- |
| [CandleUnique3River(T[], T[], T[], T[])](CandleUnique3River_T_.CandleUnique3River(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleUnique3River<T>.CandleUnique3River(T[], T[], T[], T[])') | Unique 3 River (Pattern Recognition) |

| Methods | |
| :--- | :--- |
| [Compute(int, int)](CandleUnique3River_T_.Compute(int,int).md 'TechnicalAnalysis.Candles.CandleUnique3River<T>.Compute(int, int)') | Computes the [CandleUnique3River&lt;T&gt;](CandleUnique3River_T_.md 'TechnicalAnalysis.Candles.CandleUnique3River<T>') indicator. |
| [GetLookback()](CandleUnique3River_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleUnique3River<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleUnique3River_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleUnique3River<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
