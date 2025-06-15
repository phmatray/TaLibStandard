#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleClosingMarubozu\<T\> Class

Closing Marubozu \(Pattern Recognition\)

```csharp
public class CandleClosingMarubozu<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleClosingMarubozu_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleClosingMarubozu_T_.md#TechnicalAnalysis.Candles.CandleClosingMarubozu_T_.T 'TechnicalAnalysis\.Candles\.CandleClosingMarubozu\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleClosingMarubozu\<T\>

| Constructors | |
| :--- | :--- |
| [CandleClosingMarubozu\(T\[\], T\[\], T\[\], T\[\]\)](CandleClosingMarubozu_T_.CandleClosingMarubozu(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleClosingMarubozu\<T\>\.CandleClosingMarubozu\(T\[\], T\[\], T\[\], T\[\]\)') | Closing Marubozu \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleClosingMarubozu_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleClosingMarubozu\<T\>\.Compute\(int, int\)') | Computes the [CandleClosingMarubozu&lt;T&gt;](CandleClosingMarubozu_T_.md 'TechnicalAnalysis\.Candles\.CandleClosingMarubozu\<T\>') indicator\. |
| [GetLookback\(\)](CandleClosingMarubozu_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleClosingMarubozu\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleClosingMarubozu_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleClosingMarubozu\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
