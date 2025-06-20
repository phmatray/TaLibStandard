#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleAdvanceBlock\<T\> Class

Advance Block \(Pattern Recognition\)

```csharp
public class CandleAdvanceBlock<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleAdvanceBlock_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleAdvanceBlock_T_.md#TechnicalAnalysis.Candles.CandleAdvanceBlock_T_.T 'TechnicalAnalysis\.Candles\.CandleAdvanceBlock\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleAdvanceBlock\<T\>

| Constructors | |
| :--- | :--- |
| [CandleAdvanceBlock\(T\[\], T\[\], T\[\], T\[\]\)](CandleAdvanceBlock_T_.CandleAdvanceBlock(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleAdvanceBlock\<T\>\.CandleAdvanceBlock\(T\[\], T\[\], T\[\], T\[\]\)') | Advance Block \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleAdvanceBlock_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleAdvanceBlock\<T\>\.Compute\(int, int\)') | Computes the [CandleAdvanceBlock&lt;T&gt;](CandleAdvanceBlock_T_.md 'TechnicalAnalysis\.Candles\.CandleAdvanceBlock\<T\>') indicator\. |
| [GetLookback\(\)](CandleAdvanceBlock_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleAdvanceBlock\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleAdvanceBlock_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleAdvanceBlock\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
