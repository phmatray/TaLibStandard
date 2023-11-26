#### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md 'TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleEveningStar<T> Class

```csharp
public class CandleEveningStar<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleEveningStar_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleEveningStar_T_.md#TechnicalAnalysis.Candles.CandleEveningStar_T_.T 'TechnicalAnalysis.Candles.CandleEveningStar<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleEveningStar<T>

| Constructors | |
| :--- | :--- |
| [CandleEveningStar(T[], T[], T[], T[])](CandleEveningStar_T_.CandleEveningStar(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleEveningStar<T>.CandleEveningStar(T[], T[], T[], T[])') | |

| Methods | |
| :--- | :--- |
| [Compute(int, int, T)](CandleEveningStar_T_.Compute(int,int,T).md 'TechnicalAnalysis.Candles.CandleEveningStar<T>.Compute(int, int, T)') | |
| [GetLookback()](CandleEveningStar_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleEveningStar<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleEveningStar_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleEveningStar<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
