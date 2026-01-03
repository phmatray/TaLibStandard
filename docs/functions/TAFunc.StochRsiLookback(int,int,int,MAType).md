#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.StochRsiLookback\(int, int, int, MAType\) Method

Returns the lookback period required for Stochastic RSI calculation\.

```csharp
public static int StochRsiLookback(int optInTimePeriod, int optInFastKPeriod, int optInFastDPeriod, TechnicalAnalysis.Common.MAType optInFastDMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsiLookback(int,int,int,TechnicalAnalysis.Common.MAType).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for RSI calculation\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsiLookback(int,int,int,TechnicalAnalysis.Common.MAType).optInFastKPeriod'></a>

`optInFastKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for Stochastic %K\. Valid range: 1 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsiLookback(int,int,int,TechnicalAnalysis.Common.MAType).optInFastDPeriod'></a>

`optInFastDPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for Stochastic %D smoothing\. Valid range: 1 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsiLookback(int,int,int,TechnicalAnalysis.Common.MAType).optInFastDMAType'></a>

`optInFastDMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Moving average type for %D line smoothing\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of historical data points required before the first valid StochRSI value can be calculated, or \-1 if parameters are invalid\.