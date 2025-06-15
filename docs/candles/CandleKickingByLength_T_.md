#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleKickingByLength\<T\> Class

Kicking \- bull/bear determined by the longer marubozu \(Pattern Recognition\)

```csharp
public class CandleKickingByLength<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleKickingByLength_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleKickingByLength_T_.md#TechnicalAnalysis.Candles.CandleKickingByLength_T_.T 'TechnicalAnalysis\.Candles\.CandleKickingByLength\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleKickingByLength\<T\>

| Constructors | |
| :--- | :--- |
| [CandleKickingByLength\(T\[\], T\[\], T\[\], T\[\]\)](CandleKickingByLength_T_.CandleKickingByLength(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleKickingByLength\<T\>\.CandleKickingByLength\(T\[\], T\[\], T\[\], T\[\]\)') | Kicking \- bull/bear determined by the longer marubozu \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleKickingByLength_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleKickingByLength\<T\>\.Compute\(int, int\)') | Computes the [CandleKickingByLength&lt;T&gt;](CandleKickingByLength_T_.md 'TechnicalAnalysis\.Candles\.CandleKickingByLength\<T\>') indicator\. |
| [GetLookback\(\)](CandleKickingByLength_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleKickingByLength\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleKickingByLength_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleKickingByLength\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
