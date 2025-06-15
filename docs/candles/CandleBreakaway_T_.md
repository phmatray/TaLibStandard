#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleBreakaway\<T\> Class

Breakaway \(Pattern Recognition\)

```csharp
public class CandleBreakaway<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleBreakaway_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleBreakaway_T_.md#TechnicalAnalysis.Candles.CandleBreakaway_T_.T 'TechnicalAnalysis\.Candles\.CandleBreakaway\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleBreakaway\<T\>

| Constructors | |
| :--- | :--- |
| [CandleBreakaway\(T\[\], T\[\], T\[\], T\[\]\)](CandleBreakaway_T_.CandleBreakaway(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleBreakaway\<T\>\.CandleBreakaway\(T\[\], T\[\], T\[\], T\[\]\)') | Breakaway \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleBreakaway_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleBreakaway\<T\>\.Compute\(int, int\)') | Computes the [CandleBreakaway&lt;T&gt;](CandleBreakaway_T_.md 'TechnicalAnalysis\.Candles\.CandleBreakaway\<T\>') indicator\. |
| [GetLookback\(\)](CandleBreakaway_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleBreakaway\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleBreakaway_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleBreakaway\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
