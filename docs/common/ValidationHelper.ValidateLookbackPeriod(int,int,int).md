#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[ValidationHelper](ValidationHelper.md 'TechnicalAnalysis\.Common\.ValidationHelper')

## ValidationHelper\.ValidateLookbackPeriod\(int, int, int\) Method

Validates a lookback period parameter and returns the adjusted lookback value\.

```csharp
public static int ValidateLookbackPeriod(int period, int minPeriod=2, int maxPeriod=100000);
```
#### Parameters

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateLookbackPeriod(int,int,int).period'></a>

`period` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The time period to validate\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateLookbackPeriod(int,int,int).minPeriod'></a>

`minPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The minimum allowed period \(default: 2\)\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateLookbackPeriod(int,int,int).maxPeriod'></a>

`maxPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum allowed period \(default: 100000\)\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
\-1 if the period is out of range;
the validated period value otherwise\.