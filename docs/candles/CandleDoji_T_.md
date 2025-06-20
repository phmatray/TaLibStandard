#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleDoji\<T\> Class

Doji \(Pattern Recognition\)

```csharp
public class CandleDoji<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleDoji_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleDoji_T_.md#TechnicalAnalysis.Candles.CandleDoji_T_.T 'TechnicalAnalysis\.Candles\.CandleDoji\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleDoji\<T\>

| Constructors | |
| :--- | :--- |
| [CandleDoji\(T\[\], T\[\], T\[\], T\[\]\)](CandleDoji_T_.CandleDoji(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleDoji\<T\>\.CandleDoji\(T\[\], T\[\], T\[\], T\[\]\)') | Doji \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleDoji_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleDoji\<T\>\.Compute\(int, int\)') | Computes the [CandleDoji&lt;T&gt;](CandleDoji_T_.md 'TechnicalAnalysis\.Candles\.CandleDoji\<T\>') indicator\. |
| [GetLookback\(\)](CandleDoji_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleDoji\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleDoji_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleDoji\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
