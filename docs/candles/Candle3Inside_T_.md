#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## Candle3Inside\<T\> Class

Three Inside Up/Down \(Pattern Recognition\)

```csharp
public class Candle3Inside<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.Candle3Inside_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](Candle3Inside_T_.md#TechnicalAnalysis.Candles.Candle3Inside_T_.T 'TechnicalAnalysis\.Candles\.Candle3Inside\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; Candle3Inside\<T\>

| Constructors | |
| :--- | :--- |
| [Candle3Inside\(T\[\], T\[\], T\[\], T\[\]\)](Candle3Inside_T_.Candle3Inside(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.Candle3Inside\<T\>\.Candle3Inside\(T\[\], T\[\], T\[\], T\[\]\)') | Three Inside Up/Down \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](Candle3Inside_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.Candle3Inside\<T\>\.Compute\(int, int\)') | Computes the [Candle3Inside&lt;T&gt;](Candle3Inside_T_.md 'TechnicalAnalysis\.Candles\.Candle3Inside\<T\>') indicator\. |
| [GetLookback\(\)](Candle3Inside_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.Candle3Inside\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](Candle3Inside_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.Candle3Inside\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
