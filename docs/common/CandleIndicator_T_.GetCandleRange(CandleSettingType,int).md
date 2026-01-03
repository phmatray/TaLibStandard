#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[CandleIndicator&lt;T&gt;](CandleIndicator_T_.md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>')

## CandleIndicator\<T\>\.GetCandleRange\(CandleSettingType, int\) Method

Gets the candle range of the specified candle setting at a specific index\.

```csharp
protected virtual T GetCandleRange(TechnicalAnalysis.Common.CandleSettingType candleSettingType, int index);
```
#### Parameters

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.GetCandleRange(TechnicalAnalysis.Common.CandleSettingType,int).candleSettingType'></a>

`candleSettingType` [CandleSettingType](CandleSettingType.md 'TechnicalAnalysis\.Common\.CandleSettingType')

The candle setting type to get the range for\.

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.GetCandleRange(TechnicalAnalysis.Common.CandleSettingType,int).index'></a>

`index` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index to get the range for\.

#### Returns
[T](CandleIndicator_T_.md#TechnicalAnalysis.Common.CandleIndicator_T_.T 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.T')  
A double representing the candle range\.