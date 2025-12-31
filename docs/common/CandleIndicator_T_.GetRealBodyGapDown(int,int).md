#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[CandleIndicator&lt;T&gt;](CandleIndicator_T_.md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>')

## CandleIndicator\<T\>\.GetRealBodyGapDown\(int, int\) Method

Checks if there is a real body gap down between two candles\.

```csharp
protected virtual bool GetRealBodyGapDown(int index2, int index1);
```
#### Parameters

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.GetRealBodyGapDown(int,int).index2'></a>

`index2` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the second candle\.

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.GetRealBodyGapDown(int,int).index1'></a>

`index1` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first candle\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if there is a real body gap down, false otherwise\.