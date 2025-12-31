#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[ValidationHelper](ValidationHelper.md 'TechnicalAnalysis\.Common\.ValidationHelper')

## ValidationHelper\.ValidatePeriodRange\(int, int, int\) Method

Validates a time period parameter is within acceptable range\.

```csharp
public static TechnicalAnalysis.Common.RetCode ValidatePeriodRange(int period, int minPeriod=2, int maxPeriod=100000);
```
#### Parameters

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidatePeriodRange(int,int,int).period'></a>

`period` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The time period to validate\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidatePeriodRange(int,int,int).minPeriod'></a>

`minPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The minimum allowed period \(default: 2\)\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidatePeriodRange(int,int,int).maxPeriod'></a>

`maxPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum allowed period \(default: 100000\)\.

#### Returns
[RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')  
[Success](RetCode.md#TechnicalAnalysis.Common.RetCode.Success 'TechnicalAnalysis\.Common\.RetCode\.Success') if the period is within range;
            [BadParam](RetCode.md#TechnicalAnalysis.Common.RetCode.BadParam 'TechnicalAnalysis\.Common\.RetCode\.BadParam') otherwise\.