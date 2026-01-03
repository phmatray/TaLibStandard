#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleEveningDojiStar\<T\> Class

Evening Doji Star \(Pattern Recognition\)

```csharp
public class CandleEveningDojiStar<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleEveningDojiStar_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleEveningDojiStar_T_.md#TechnicalAnalysis.Candles.CandleEveningDojiStar_T_.T 'TechnicalAnalysis\.Candles\.CandleEveningDojiStar\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleEveningDojiStar\<T\>

| Constructors | |
| :--- | :--- |
| [CandleEveningDojiStar\(T\[\], T\[\], T\[\], T\[\]\)](CandleEveningDojiStar_T_.CandleEveningDojiStar(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleEveningDojiStar\<T\>\.CandleEveningDojiStar\(T\[\], T\[\], T\[\], T\[\]\)') | Evening Doji Star \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int, T\)](CandleEveningDojiStar_T_.Compute(int,int,T).md 'TechnicalAnalysis\.Candles\.CandleEveningDojiStar\<T\>\.Compute\(int, int, T\)') | Computes the [CandleEveningDojiStar&lt;T&gt;](CandleEveningDojiStar_T_.md 'TechnicalAnalysis\.Candles\.CandleEveningDojiStar\<T\>') indicator\. |
| [GetLookback\(\)](CandleEveningDojiStar_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleEveningDojiStar\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleEveningDojiStar_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleEveningDojiStar\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
