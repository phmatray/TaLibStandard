#### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md 'TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleOnNeck<T> Class

```csharp
public class CandleOnNeck<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleOnNeck_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleOnNeck_T_.md#TechnicalAnalysis.Candles.CandleOnNeck_T_.T 'TechnicalAnalysis.Candles.CandleOnNeck<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleOnNeck<T>

| Constructors | |
| :--- | :--- |
| [CandleOnNeck(T[], T[], T[], T[])](CandleOnNeck_T_.CandleOnNeck(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleOnNeck<T>.CandleOnNeck(T[], T[], T[], T[])') | |

| Methods | |
| :--- | :--- |
| [Compute(int, int)](CandleOnNeck_T_.Compute(int,int).md 'TechnicalAnalysis.Candles.CandleOnNeck<T>.Compute(int, int)') | |
| [GetLookback()](CandleOnNeck_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleOnNeck<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleOnNeck_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleOnNeck<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
