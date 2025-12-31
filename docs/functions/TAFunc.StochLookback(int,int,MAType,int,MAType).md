#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.StochLookback\(int, int, MAType, int, MAType\) Method

Returns the lookback period required for Stochastic Oscillator calculation\.

```csharp
public static int StochLookback(int optInFastKPeriod, int optInSlowKPeriod, TechnicalAnalysis.Common.MAType optInSlowKMAType, int optInSlowDPeriod, TechnicalAnalysis.Common.MAType optInSlowDMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.StochLookback(int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).optInFastKPeriod'></a>

`optInFastKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for %K calculation\. Valid range: 1 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochLookback(int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).optInSlowKPeriod'></a>

`optInSlowKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Smoothing periods for %K\. Valid range: 1 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochLookback(int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).optInSlowKMAType'></a>

`optInSlowKMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Moving average type for Slow %K smoothing\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochLookback(int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).optInSlowDPeriod'></a>

`optInSlowDPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for %D calculation\. Valid range: 1 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochLookback(int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).optInSlowDMAType'></a>

`optInSlowDMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Moving average type for %D calculation\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of historical data points required before the first valid Stochastic value can be calculated, or \-1 if parameters are invalid\.