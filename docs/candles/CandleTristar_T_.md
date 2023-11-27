#### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical.TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleTristar<T> Class

Tristar Pattern (Pattern Recognition)

```csharp
public class CandleTristar<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleTristar_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleTristar_T_.md#TechnicalAnalysis.Candles.CandleTristar_T_.T 'TechnicalAnalysis.Candles.CandleTristar<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleTristar<T>

| Constructors | |
| :--- | :--- |
| [CandleTristar(T[], T[], T[], T[])](CandleTristar_T_.CandleTristar(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleTristar<T>.CandleTristar(T[], T[], T[], T[])') | Tristar Pattern (Pattern Recognition) |

| Methods | |
| :--- | :--- |
| [Compute(int, int)](CandleTristar_T_.Compute(int,int).md 'TechnicalAnalysis.Candles.CandleTristar<T>.Compute(int, int)') | Computes the [CandleTristar&lt;T&gt;](CandleTristar_T_.md 'TechnicalAnalysis.Candles.CandleTristar<T>') indicator. |
| [GetLookback()](CandleTristar_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleTristar<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleTristar_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleTristar<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
