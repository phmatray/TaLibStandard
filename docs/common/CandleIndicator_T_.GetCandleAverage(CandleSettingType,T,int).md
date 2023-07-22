#### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md 'TechnicalAnalysis.Common')
### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis.Common').[CandleIndicator&lt;T&gt;](CandleIndicator_T_.md 'TechnicalAnalysis.Common.CandleIndicator<T>')

## CandleIndicator<T>.GetCandleAverage(CandleSettingType, T, int) Method

Gets the candle average of the specified candle setting at a specific index.

```csharp
protected virtual T GetCandleAverage(TechnicalAnalysis.Common.CandleSettingType candleSettingType, T sum, int index);
```
#### Parameters

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.GetCandleAverage(TechnicalAnalysis.Common.CandleSettingType,T,int).candleSettingType'></a>

`candleSettingType` [CandleSettingType](CandleSettingType.md 'TechnicalAnalysis.Common.CandleSettingType')

The candle setting type to get the average for.

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.GetCandleAverage(TechnicalAnalysis.Common.CandleSettingType,T,int).sum'></a>

`sum` [T](CandleIndicator_T_.md#TechnicalAnalysis.Common.CandleIndicator_T_.T 'TechnicalAnalysis.Common.CandleIndicator<T>.T')

The sum of the specified range of elements in the series.

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.GetCandleAverage(TechnicalAnalysis.Common.CandleSettingType,T,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The index to get the average for.

#### Returns
[T](CandleIndicator_T_.md#TechnicalAnalysis.Common.CandleIndicator_T_.T 'TechnicalAnalysis.Common.CandleIndicator<T>.T')  
A double representing the candle average.