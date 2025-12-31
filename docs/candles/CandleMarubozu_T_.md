#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleMarubozu\<T\> Class

Marubozu \(Pattern Recognition\)

```csharp
public class CandleMarubozu<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleMarubozu_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleMarubozu_T_.md#TechnicalAnalysis.Candles.CandleMarubozu_T_.T 'TechnicalAnalysis\.Candles\.CandleMarubozu\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleMarubozu\<T\>

| Constructors | |
| :--- | :--- |
| [CandleMarubozu\(T\[\], T\[\], T\[\], T\[\]\)](CandleMarubozu_T_.CandleMarubozu(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleMarubozu\<T\>\.CandleMarubozu\(T\[\], T\[\], T\[\], T\[\]\)') | Marubozu \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleMarubozu_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleMarubozu\<T\>\.Compute\(int, int\)') | Computes the [CandleMarubozu&lt;T&gt;](CandleMarubozu_T_.md 'TechnicalAnalysis\.Candles\.CandleMarubozu\<T\>') indicator\. |
| [GetLookback\(\)](CandleMarubozu_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleMarubozu\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleMarubozu_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleMarubozu\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
