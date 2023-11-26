#### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md 'TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandlePiercing<T> Class

```csharp
public class CandlePiercing<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandlePiercing_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandlePiercing_T_.md#TechnicalAnalysis.Candles.CandlePiercing_T_.T 'TechnicalAnalysis.Candles.CandlePiercing<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandlePiercing<T>

| Constructors | |
| :--- | :--- |
| [CandlePiercing(T[], T[], T[], T[])](CandlePiercing_T_.CandlePiercing(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandlePiercing<T>.CandlePiercing(T[], T[], T[], T[])') | |

| Methods | |
| :--- | :--- |
| [Compute(int, int)](CandlePiercing_T_.Compute(int,int).md 'TechnicalAnalysis.Candles.CandlePiercing<T>.Compute(int, int)') | |
| [GetLookback()](CandlePiercing_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandlePiercing<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandlePiercing_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandlePiercing<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
