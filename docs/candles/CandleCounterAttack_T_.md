#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles')

## CandleCounterAttack\<T\> Class

Counterattack \(Pattern Recognition\)

```csharp
public class CandleCounterAttack<T> : TechnicalAnalysis.Common.CandleIndicator<T>
    where T : System.Numerics.IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.CandleCounterAttack_T_.T'></a>

`T`

The type of the array elements\.

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.CandleIndicator&lt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1')[T](CandleCounterAttack_T_.md#TechnicalAnalysis.Candles.CandleCounterAttack_T_.T 'TechnicalAnalysis\.Candles\.CandleCounterAttack\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicator-1 'TechnicalAnalysis\.Common\.CandleIndicator\`1') &#129106; CandleCounterAttack\<T\>

| Constructors | |
| :--- | :--- |
| [CandleCounterAttack\(T\[\], T\[\], T\[\], T\[\]\)](CandleCounterAttack_T_.CandleCounterAttack(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Candles\.CandleCounterAttack\<T\>\.CandleCounterAttack\(T\[\], T\[\], T\[\], T\[\]\)') | Counterattack \(Pattern Recognition\) |

| Methods | |
| :--- | :--- |
| [Compute\(int, int\)](CandleCounterAttack_T_.Compute(int,int).md 'TechnicalAnalysis\.Candles\.CandleCounterAttack\<T\>\.Compute\(int, int\)') | Computes the [CandleCounterAttack&lt;T&gt;](CandleCounterAttack_T_.md 'TechnicalAnalysis\.Candles\.CandleCounterAttack\<T\>') indicator\. |
| [GetLookback\(\)](CandleCounterAttack_T_.GetLookback().md 'TechnicalAnalysis\.Candles\.CandleCounterAttack\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetPatternRecognition\(int\)](CandleCounterAttack_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Candles\.CandleCounterAttack\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
