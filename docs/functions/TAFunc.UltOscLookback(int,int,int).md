#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.UltOscLookback\(int, int, int\) Method

Returns the lookback period required for Ultimate Oscillator calculation\.

```csharp
public static int UltOscLookback(int optInTimePeriod1, int optInTimePeriod2, int optInTimePeriod3);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.UltOscLookback(int,int,int).optInTimePeriod1'></a>

`optInTimePeriod1` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

First time period\. Valid range: 1 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOscLookback(int,int,int).optInTimePeriod2'></a>

`optInTimePeriod2` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Second time period\. Valid range: 1 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOscLookback(int,int,int).optInTimePeriod3'></a>

`optInTimePeriod3` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Third time period\. Valid range: 1 to 100000\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of historical data points required before the first valid Ultimate Oscillator value can be calculated, or \-1 if parameters are invalid\.