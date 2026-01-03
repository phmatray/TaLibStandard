#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleTasukiGap\<T\> Class

Tasuki Gap \(Pattern Recognition\)

```csharp
public class CandleTasukiGap<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleTasukiGap_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleTasukiGap_T_.md#TechnicalAnalysis.Candles.CandleTasukiGap_T_.T 'TechnicalAnalysis\.Candles\.CandleTasukiGap\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleTasukiGap\<T\>

| Constructors | |
| :--- | :--- |
| [CandleTasukiGap\(T\[\], T\[\], T\[\], T\[\]\)](CandleTasukiGap_T_.CandleTasukiGap(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleTasukiGap\<T\>\.CandleTasukiGap\(T\[\], T\[\], T\[\], T\[\]\)') | Tasuki Gap \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleTasukiGap_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleTasukiGap\<T\>\.Compute\(int, int\)') | Computes the [CandleTasukiGap&lt;T&gt;](CandleTasukiGap_T_.md 'TechnicalAnalysis\.Candles\.CandleTasukiGap\<T\>') indicator\. |
| [GetLookback\(\)](CandleTasukiGap_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleTasukiGap\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleTasukiGap_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleTasukiGap\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
