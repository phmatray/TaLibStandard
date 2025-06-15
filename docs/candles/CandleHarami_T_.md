#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleHarami\<T\> Class

Harami Pattern \(Pattern Recognition\)

```csharp
public class CandleHarami<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleHarami_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleHarami_T_.md#TechnicalAnalysis.Candles.CandleHarami_T_.T 'TechnicalAnalysis\.Candles\.CandleHarami\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleHarami\<T\>

| Constructors | |
| :--- | :--- |
| [CandleHarami\(T\[\], T\[\], T\[\], T\[\]\)](CandleHarami_T_.CandleHarami(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleHarami\<T\>\.CandleHarami\(T\[\], T\[\], T\[\], T\[\]\)') | Harami Pattern \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleHarami_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleHarami\<T\>\.Compute\(int, int\)') | Computes the [CandleHarami&lt;T&gt;](CandleHarami_T_.md 'TechnicalAnalysis\.Candles\.CandleHarami\<T\>') indicator\. |
| [GetLookback\(\)](CandleHarami_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleHarami\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleHarami_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleHarami\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
