#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[CandleIndicator&lt;T&gt;](CandleIndicator_T_.md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>')

## CandleIndicator\<T\>\.GetCandleColor\(int\) Method

Gets the color of the candle at a specific index\.

```csharp
protected virtual TechnicalAnalysis.Common.CandleColor GetCandleColor(int index);
```
#### Parameters

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.GetCandleColor(int).index'></a>

`index` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index to get the candle color for\.

#### Returns
[CandleColor](CandleColor.md 'TechnicalAnalysis\.Common\.CandleColor')  
1 if the candle is bullish, \-1 if the candle is bearish\.