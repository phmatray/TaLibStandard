#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleDarkCloudCover\<T\> Class

Dark Cloud Cover \(Pattern Recognition\)

```csharp
public class CandleDarkCloudCover<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleDarkCloudCover_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleDarkCloudCover_T_.md#TechnicalAnalysis.Candles.CandleDarkCloudCover_T_.T 'TechnicalAnalysis\.Candles\.CandleDarkCloudCover\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleDarkCloudCover\<T\>

| Constructors | |
| :--- | :--- |
| [CandleDarkCloudCover\(T\[\], T\[\], T\[\], T\[\]\)](CandleDarkCloudCover_T_.CandleDarkCloudCover(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleDarkCloudCover\<T\>\.CandleDarkCloudCover\(T\[\], T\[\], T\[\], T\[\]\)') | Dark Cloud Cover \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int, T\)](CandleDarkCloudCover_T_.Compute(int,int,T).md 'TechnicalAnalysis\.Candles\.CandleDarkCloudCover\<T\>\.Compute\(int, int, T\)') | Computes the [CandleDarkCloudCover&lt;T&gt;](CandleDarkCloudCover_T_.md 'TechnicalAnalysis\.Candles\.CandleDarkCloudCover\<T\>') indicator\. |
| [GetLookback\(\)](CandleDarkCloudCover_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleDarkCloudCover\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleDarkCloudCover_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleDarkCloudCover\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
