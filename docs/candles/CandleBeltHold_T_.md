#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleBeltHold\<T\> Class

Belt\-hold \(Pattern Recognition\)

```csharp
public class CandleBeltHold<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleBeltHold_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleBeltHold_T_.md#TechnicalAnalysis.Candles.CandleBeltHold_T_.T 'TechnicalAnalysis\.Candles\.CandleBeltHold\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleBeltHold\<T\>

| Constructors | |
| :--- | :--- |
| [CandleBeltHold\(T\[\], T\[\], T\[\], T\[\]\)](CandleBeltHold_T_.CandleBeltHold(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleBeltHold\<T\>\.CandleBeltHold\(T\[\], T\[\], T\[\], T\[\]\)') | Belt\-hold \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleBeltHold_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleBeltHold\<T\>\.Compute\(int, int\)') | Computes the [CandleBeltHold&lt;T&gt;](CandleBeltHold_T_.md 'TechnicalAnalysis\.Candles\.CandleBeltHold\<T\>') indicator\. |
| [GetLookback\(\)](CandleBeltHold_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleBeltHold\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleBeltHold_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleBeltHold\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
