#### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical.TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles')

## CandleDojiStar<T> Class

Doji Star (Pattern Recognition)

```csharp
public class CandleDojiStar<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleDojiStar_T_.T'></a>

`T`

The type of the array elements.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [TechnicalAnalysis.Common.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1')[T](CandleDojiStar_T_.md#TechnicalAnalysis.Candles.CandleDojiStar_T_.T 'TechnicalAnalysis.Candles.CandleDojiStar<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis.Common.CandleIndicator`1') &#129106; CandleDojiStar<T>

| Constructors | |
| :--- | :--- |
| [CandleDojiStar(T[], T[], T[], T[])](CandleDojiStar_T_.CandleDojiStar(T[],T[],T[],T[]).md 'TechnicalAnalysis.Candles.CandleDojiStar<T>.CandleDojiStar(T[], T[], T[], T[])') | Doji Star (Pattern Recognition) |

| Methods | |
| :--- | :--- |
| [Compute(int, int)](CandleDojiStar_T_.Compute(int,int).md 'TechnicalAnalysis.Candles.CandleDojiStar<T>.Compute(int, int)') | Computes the [CandleDojiStar&lt;T&gt;](CandleDojiStar_T_.md 'TechnicalAnalysis.Candles.CandleDojiStar<T>') indicator. |
| [GetLookback()](CandleDojiStar_T_.GetLookback().md 'TechnicalAnalysis.Candles.CandleDojiStar<T>.GetLookback()') | Returns the lookback period for the indicator. |
| [GetPatternRecognition(int)](CandleDojiStar_T_.GetPatternRecognition(int).md 'TechnicalAnalysis.Candles.CandleDojiStar<T>.GetPatternRecognition(int)') | Checks if the pattern is recognized at a specific index. |
