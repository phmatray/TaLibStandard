#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleThrusting\<T\> Class

Thrusting Pattern \(Pattern Recognition\)

```csharp
public class CandleThrusting<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleThrusting_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleThrusting_T_.md#TechnicalAnalysis.Candles.CandleThrusting_T_.T 'TechnicalAnalysis\.Candles\.CandleThrusting\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleThrusting\<T\>

| Constructors | |
| :--- | :--- |
| [CandleThrusting\(T\[\], T\[\], T\[\], T\[\]\)](CandleThrusting_T_.CandleThrusting(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleThrusting\<T\>\.CandleThrusting\(T\[\], T\[\], T\[\], T\[\]\)') | Thrusting Pattern \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleThrusting_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleThrusting\<T\>\.Compute\(int, int\)') | Computes the [CandleThrusting&lt;T&gt;](CandleThrusting_T_.md 'TechnicalAnalysis\.Candles\.CandleThrusting\<T\>') indicator\. |
| [GetLookback\(\)](CandleThrusting_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleThrusting\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleThrusting_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleThrusting\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
