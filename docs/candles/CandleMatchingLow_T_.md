#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleMatchingLow\<T\> Class

Matching Low \(Pattern Recognition\)

```csharp
public class CandleMatchingLow<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleMatchingLow_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleMatchingLow_T_.md#TechnicalAnalysis.Candles.CandleMatchingLow_T_.T 'TechnicalAnalysis\.Candles\.CandleMatchingLow\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleMatchingLow\<T\>

| Constructors | |
| :--- | :--- |
| [CandleMatchingLow\(T\[\], T\[\], T\[\], T\[\]\)](CandleMatchingLow_T_.CandleMatchingLow(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleMatchingLow\<T\>\.CandleMatchingLow\(T\[\], T\[\], T\[\], T\[\]\)') | Matching Low \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleMatchingLow_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleMatchingLow\<T\>\.Compute\(int, int\)') | Computes the [CandleMatchingLow&lt;T&gt;](CandleMatchingLow_T_.md 'TechnicalAnalysis\.Candles\.CandleMatchingLow\<T\>') indicator\. |
| [GetLookback\(\)](CandleMatchingLow_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleMatchingLow\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleMatchingLow_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleMatchingLow\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
