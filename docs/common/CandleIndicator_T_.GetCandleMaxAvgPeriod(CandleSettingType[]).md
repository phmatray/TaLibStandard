#### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md 'TechnicalAnalysis.Common')
### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis.Common').[CandleIndicator&lt;T&gt;](CandleIndicator_T_.md 'TechnicalAnalysis.Common.CandleIndicator<T>')

## CandleIndicator<T>.GetCandleMaxAvgPeriod(CandleSettingType[]) Method

Gets the maximum average period among the specified candle settings.

```csharp
protected virtual int GetCandleMaxAvgPeriod(params TechnicalAnalysis.Common.CandleSettingType[] candleSettingTypes);
```
#### Parameters

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.GetCandleMaxAvgPeriod(TechnicalAnalysis.Common.CandleSettingType[]).candleSettingTypes'></a>

`candleSettingTypes` [CandleSettingType](CandleSettingType.md 'TechnicalAnalysis.Common.CandleSettingType')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of candle setting types to get the maximum average period for.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
An integer representing the maximum average period.