#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleInvertedHammer\<T\> Class

Inverted Hammer \(Pattern Recognition\)

```csharp
public class CandleInvertedHammer<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleInvertedHammer_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleInvertedHammer_T_.md#TechnicalAnalysis.Candles.CandleInvertedHammer_T_.T 'TechnicalAnalysis\.Candles\.CandleInvertedHammer\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleInvertedHammer\<T\>

| Constructors | |
| :--- | :--- |
| [CandleInvertedHammer\(T\[\], T\[\], T\[\], T\[\]\)](CandleInvertedHammer_T_.CandleInvertedHammer(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleInvertedHammer\<T\>\.CandleInvertedHammer\(T\[\], T\[\], T\[\], T\[\]\)') | Inverted Hammer \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleInvertedHammer_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleInvertedHammer\<T\>\.Compute\(int, int\)') | Computes the [CandleInvertedHammer&lt;T&gt;](CandleInvertedHammer_T_.md 'TechnicalAnalysis\.Candles\.CandleInvertedHammer\<T\>') indicator\. |
| [GetLookback\(\)](CandleInvertedHammer_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleInvertedHammer\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleInvertedHammer_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleInvertedHammer\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
