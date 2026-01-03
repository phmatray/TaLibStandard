#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleKicking\<T\> Class

Kicking \(Pattern Recognition\)

```csharp
public class CandleKicking<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleKicking_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleKicking_T_.md#TechnicalAnalysis.Candles.CandleKicking_T_.T 'TechnicalAnalysis\.Candles\.CandleKicking\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleKicking\<T\>

| Constructors | |
| :--- | :--- |
| [CandleKicking\(T\[\], T\[\], T\[\], T\[\]\)](CandleKicking_T_.CandleKicking(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleKicking\<T\>\.CandleKicking\(T\[\], T\[\], T\[\], T\[\]\)') | Kicking \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleKicking_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleKicking\<T\>\.Compute\(int, int\)') | Computes the [CandleKicking&lt;T&gt;](CandleKicking_T_.md 'TechnicalAnalysis\.Candles\.CandleKicking\<T\>') indicator\. |
| [GetLookback\(\)](CandleKicking_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleKicking\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleKicking_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleKicking\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
