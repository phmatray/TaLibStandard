#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MacdExtLookback\(int, MAType, int, MAType, int, MAType\) Method

Returns the lookback period required for MACD Extended calculation\.

```csharp
public static int MacdExtLookback(int optInFastPeriod, TechnicalAnalysis.Common.MAType optInFastMAType, int optInSlowPeriod, TechnicalAnalysis.Common.MAType optInSlowMAType, int optInSignalPeriod, TechnicalAnalysis.Common.MAType optInSignalMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExtLookback(int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).optInFastPeriod'></a>

`optInFastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the fast moving average\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExtLookback(int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).optInFastMAType'></a>

`optInFastMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use for the fast MA\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExtLookback(int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).optInSlowPeriod'></a>

`optInSlowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the slow moving average\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExtLookback(int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).optInSlowMAType'></a>

`optInSlowMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use for the slow MA\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExtLookback(int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).optInSignalPeriod'></a>

`optInSignalPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the signal line moving average\. Valid range: 1 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExtLookback(int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).optInSignalMAType'></a>

`optInSignalMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use for the signal line\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of historical data points required before the first valid MACD Extended value can be calculated, or \-1 if parameters are invalid\.

### Remarks
The lookback period is determined by finding the maximum lookback among the fast and slow moving averages,
then adding the signal line's lookback period\. Different MA types have different lookback requirements:
\- SMA: period \- 1
\- EMA: period \- 1
\- WMA: period \- 1
\- DEMA: 2 \* \(period \- 1\)
\- TEMA: 3 \* \(period \- 1\)
\- And others as defined by their specific algorithms