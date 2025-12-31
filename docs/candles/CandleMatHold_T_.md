#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleMatHold\<T\> Class

Mat Hold \(Pattern Recognition\)

```csharp
public class CandleMatHold<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleMatHold_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleMatHold_T_.md#TechnicalAnalysis.Candles.CandleMatHold_T_.T 'TechnicalAnalysis\.Candles\.CandleMatHold\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleMatHold\<T\>

| Constructors | |
| :--- | :--- |
| [CandleMatHold\(T\[\], T\[\], T\[\], T\[\]\)](CandleMatHold_T_.CandleMatHold(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleMatHold\<T\>\.CandleMatHold\(T\[\], T\[\], T\[\], T\[\]\)') | Mat Hold \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int, T\)](CandleMatHold_T_.Compute(int,int,T).md 'TechnicalAnalysis\.Candles\.CandleMatHold\<T\>\.Compute\(int, int, T\)') | Computes the [CandleMatHold&lt;T&gt;](CandleMatHold_T_.md 'TechnicalAnalysis\.Candles\.CandleMatHold\<T\>') indicator\. |
| [GetLookback\(\)](CandleMatHold_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleMatHold\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleMatHold_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleMatHold\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
