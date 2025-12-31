#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleRickshawMan\<T\> Class

Rickshaw Man \(Pattern Recognition\)

```csharp
public class CandleRickshawMan<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleRickshawMan_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleRickshawMan_T_.md#TechnicalAnalysis.Candles.CandleRickshawMan_T_.T 'TechnicalAnalysis\.Candles\.CandleRickshawMan\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleRickshawMan\<T\>

| Constructors | |
| :--- | :--- |
| [CandleRickshawMan\(T\[\], T\[\], T\[\], T\[\]\)](CandleRickshawMan_T_.CandleRickshawMan(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleRickshawMan\<T\>\.CandleRickshawMan\(T\[\], T\[\], T\[\], T\[\]\)') | Rickshaw Man \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleRickshawMan_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleRickshawMan\<T\>\.Compute\(int, int\)') | Computes the [CandleRickshawMan&lt;T&gt;](CandleRickshawMan_T_.md 'TechnicalAnalysis\.Candles\.CandleRickshawMan\<T\>') indicator\. |
| [GetLookback\(\)](CandleRickshawMan_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleRickshawMan\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleRickshawMan_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleRickshawMan\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
