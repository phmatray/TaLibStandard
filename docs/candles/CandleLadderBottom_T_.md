#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleLadderBottom\<T\> Class

Ladder Bottom \(Pattern Recognition\)

```csharp
public class CandleLadderBottom<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleLadderBottom_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleLadderBottom_T_.md#TechnicalAnalysis.Candles.CandleLadderBottom_T_.T 'TechnicalAnalysis\.Candles\.CandleLadderBottom\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleLadderBottom\<T\>

| Constructors | |
| :--- | :--- |
| [CandleLadderBottom\(T\[\], T\[\], T\[\], T\[\]\)](CandleLadderBottom_T_.CandleLadderBottom(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleLadderBottom\<T\>\.CandleLadderBottom\(T\[\], T\[\], T\[\], T\[\]\)') | Ladder Bottom \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleLadderBottom_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleLadderBottom\<T\>\.Compute\(int, int\)') | Computes the [CandleLadderBottom&lt;T&gt;](CandleLadderBottom_T_.md 'TechnicalAnalysis\.Candles\.CandleLadderBottom\<T\>') indicator\. |
| [GetLookback\(\)](CandleLadderBottom_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleLadderBottom\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleLadderBottom_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleLadderBottom\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
