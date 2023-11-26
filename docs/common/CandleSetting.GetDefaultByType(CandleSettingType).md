#### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md 'TechnicalAnalysis.Common')
### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis.Common').[CandleSetting](CandleSetting.md 'TechnicalAnalysis.Common.CandleSetting')

## CandleSetting.GetDefaultByType(CandleSettingType) Method

Gets the default setting for a given type.

```csharp
public static TechnicalAnalysis.Common.CandleSetting GetDefaultByType(TechnicalAnalysis.Common.CandleSettingType settingType);
```
#### Parameters

<a name='TechnicalAnalysis.Common.CandleSetting.GetDefaultByType(TechnicalAnalysis.Common.CandleSettingType).settingType'></a>

`settingType` [CandleSettingType](CandleSettingType.md 'TechnicalAnalysis.Common.CandleSettingType')

The type of the candlestick setting.

#### Returns
[CandleSetting](CandleSetting.md 'TechnicalAnalysis.Common.CandleSetting')  
The default setting for the given type.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when the setting type is AllCandleSettings.

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when the setting type is not recognized.