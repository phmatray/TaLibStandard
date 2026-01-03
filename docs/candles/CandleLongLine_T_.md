#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleLongLine\<T\> Class

Long Line Candle \(Pattern Recognition\)

```csharp
public class CandleLongLine<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleLongLine_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleLongLine_T_.md#TechnicalAnalysis.Candles.CandleLongLine_T_.T 'TechnicalAnalysis\.Candles\.CandleLongLine\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleLongLine\<T\>

| Constructors | |
| :--- | :--- |
| [CandleLongLine\(T\[\], T\[\], T\[\], T\[\]\)](CandleLongLine_T_.CandleLongLine(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleLongLine\<T\>\.CandleLongLine\(T\[\], T\[\], T\[\], T\[\]\)') | Long Line Candle \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleLongLine_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleLongLine\<T\>\.Compute\(int, int\)') | Computes the [CandleLongLine&lt;T&gt;](CandleLongLine_T_.md 'TechnicalAnalysis\.Candles\.CandleLongLine\<T\>') indicator\. |
| [GetLookback\(\)](CandleLongLine_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleLongLine\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleLongLine_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleLongLine\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
