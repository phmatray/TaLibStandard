#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleHighWave\<T\> Class

High\-Wave Candle \(Pattern Recognition\)

```csharp
public class CandleHighWave<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleHighWave_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleHighWave_T_.md#TechnicalAnalysis.Candles.CandleHighWave_T_.T 'TechnicalAnalysis\.Candles\.CandleHighWave\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleHighWave\<T\>

| Constructors | |
| :--- | :--- |
| [CandleHighWave\(T\[\], T\[\], T\[\], T\[\]\)](CandleHighWave_T_.CandleHighWave(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleHighWave\<T\>\.CandleHighWave\(T\[\], T\[\], T\[\], T\[\]\)') | High\-Wave Candle \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleHighWave_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleHighWave\<T\>\.Compute\(int, int\)') | Computes the [CandleHighWave&lt;T&gt;](CandleHighWave_T_.md 'TechnicalAnalysis\.Candles\.CandleHighWave\<T\>') indicator\. |
| [GetLookback\(\)](CandleHighWave_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleHighWave\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleHighWave_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleHighWave\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
