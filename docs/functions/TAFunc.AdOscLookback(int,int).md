#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.AdOscLookback\(int, int\) Method

Returns the lookback period required for A/D Oscillator calculation\.

```csharp
public static int AdOscLookback(int optInFastPeriod, int optInSlowPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.AdOscLookback(int,int).optInFastPeriod'></a>

`optInFastPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the fast EMA\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.AdOscLookback(int,int).optInSlowPeriod'></a>

`optInSlowPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the slow EMA\. Valid range: 2 to 100000\.

#### Returns
[System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')  
The number of historical data points required before the first valid A/D Oscillator value can be calculated, or \-1 if parameters are invalid\.