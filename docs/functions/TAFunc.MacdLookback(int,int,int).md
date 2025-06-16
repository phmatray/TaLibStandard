#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MacdLookback\(int, int, int\) Method

Returns the lookback period required for MACD calculation\.

```csharp
public static int MacdLookback(int optInFastPeriod, int optInSlowPeriod, int optInSignalPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MacdLookback(int,int,int).optInFastPeriod'></a>

`optInFastPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the fast EMA\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdLookback(int,int,int).optInSlowPeriod'></a>

`optInSlowPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the slow EMA\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdLookback(int,int,int).optInSignalPeriod'></a>

`optInSignalPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the signal line EMA\. Valid range: 1 to 100000\.

#### Returns
[System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')  
The number of historical data points required before the first valid MACD value can be calculated, or \-1 if parameters are invalid\.