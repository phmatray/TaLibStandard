#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleHomingPigeon\<T\> Class

Homing Pigeon \(Pattern Recognition\)

```csharp
public class CandleHomingPigeon<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleHomingPigeon_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleHomingPigeon_T_.md#TechnicalAnalysis.Candles.CandleHomingPigeon_T_.T 'TechnicalAnalysis\.Candles\.CandleHomingPigeon\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleHomingPigeon\<T\>

| Constructors | |
| :--- | :--- |
| [CandleHomingPigeon\(T\[\], T\[\], T\[\], T\[\]\)](CandleHomingPigeon_T_.CandleHomingPigeon(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleHomingPigeon\<T\>\.CandleHomingPigeon\(T\[\], T\[\], T\[\], T\[\]\)') | Homing Pigeon \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleHomingPigeon_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleHomingPigeon\<T\>\.Compute\(int, int\)') | Computes the [CandleHomingPigeon&lt;T&gt;](CandleHomingPigeon_T_.md 'TechnicalAnalysis\.Candles\.CandleHomingPigeon\<T\>') indicator\. |
| [GetLookback\(\)](CandleHomingPigeon_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleHomingPigeon\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleHomingPigeon_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleHomingPigeon\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
