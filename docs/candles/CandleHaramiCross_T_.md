#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleHaramiCross\<T\> Class

Harami Cross Pattern \(Pattern Recognition\)

```csharp
public class CandleHaramiCross<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleHaramiCross_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleHaramiCross_T_.md#TechnicalAnalysis.Candles.CandleHaramiCross_T_.T 'TechnicalAnalysis\.Candles\.CandleHaramiCross\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleHaramiCross\<T\>

| Constructors | |
| :--- | :--- |
| [CandleHaramiCross\(T\[\], T\[\], T\[\], T\[\]\)](CandleHaramiCross_T_.CandleHaramiCross(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleHaramiCross\<T\>\.CandleHaramiCross\(T\[\], T\[\], T\[\], T\[\]\)') | Harami Cross Pattern \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleHaramiCross_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleHaramiCross\<T\>\.Compute\(int, int\)') | Computes the [CandleHaramiCross&lt;T&gt;](CandleHaramiCross_T_.md 'TechnicalAnalysis\.Candles\.CandleHaramiCross\<T\>') indicator\. |
| [GetLookback\(\)](CandleHaramiCross_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleHaramiCross\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleHaramiCross_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleHaramiCross\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
