#### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical.TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleMorningStar<T> Class

Morning Star (Pattern Recognition)

```csharp
public class CandleMorningStar<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleMorningStar_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleMorningStar_T_.md#TechnicalAnalysis.Candles.CandleMorningStar_T_.T 'TechnicalAnalysis.Candles.CandleMorningStar<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleMorningStar<T>

| Constructors | |
| :--- | :--- |
| [CandleMorningStar(T[], T[], T[], T[])](CandleMorningStar_T_.CandleMorningStar(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleMorningStar<T>.CandleMorningStar(T[], T[], T[], T[])') | Morning Star (Pattern Recognition) |

| Methods | |
| :--- | :--- |
| [Compute(int, int, T)](CandleMorningStar_T_.Compute(int,int,T).md 'TechnicalAnalysis.Candles.CandleMorningStar<T>.Compute(int, int, T)') | Computes the [CandleMorningStar&lt;T&gt;](CandleMorningStar_T_.md 'TechnicalAnalysis.Candles.CandleMorningStar<T>') indicator. |
| [GetLookback()](CandleMorningStar_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleMorningStar<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleMorningStar_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleMorningStar<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
