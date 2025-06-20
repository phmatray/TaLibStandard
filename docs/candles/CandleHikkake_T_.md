#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleHikkake\<T\> Class

Hikkake Pattern \(Pattern Recognition\)

```csharp
public class CandleHikkake<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleHikkake_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleHikkake_T_.md#TechnicalAnalysis.Candles.CandleHikkake_T_.T 'TechnicalAnalysis\.Candles\.CandleHikkake\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleHikkake\<T\>

| Constructors | |
| :--- | :--- |
| [CandleHikkake\(T\[\], T\[\], T\[\], T\[\]\)](CandleHikkake_T_.CandleHikkake(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleHikkake\<T\>\.CandleHikkake\(T\[\], T\[\], T\[\], T\[\]\)') | Hikkake Pattern \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleHikkake_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleHikkake\<T\>\.Compute\(int, int\)') | Computes the [CandleHikkake&lt;T&gt;](CandleHikkake_T_.md 'TechnicalAnalysis\.Candles\.CandleHikkake\<T\>') indicator\. |
| [GetLookback\(\)](CandleHikkake_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleHikkake\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleHikkake_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleHikkake\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
