#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MomentumStochResult](MomentumStochResult.md 'TechnicalAnalysis\.Functions\.MomentumStochResult')

## MomentumStochResult\(RetCode, int, int, double\[\], double\[\], int, int, int\) Constructor

Represents the result of a Stochastic Oscillator momentum analysis\.

```csharp
public MomentumStochResult(TechnicalAnalysis.Common.RetCode RetCode, int BegIdx, int NBElement, double[] SlowK, double[] SlowD, int FastKPeriod, int SlowKPeriod, int SlowDPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MomentumStochResult.MomentumStochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],int,int,int).RetCode'></a>

`RetCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the status of the calculation\.

<a name='TechnicalAnalysis.Functions.MomentumStochResult.MomentumStochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],int,int,int).BegIdx'></a>

`BegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The beginning index of the output series\.

<a name='TechnicalAnalysis.Functions.MomentumStochResult.MomentumStochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],int,int,int).NBElement'></a>

`NBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of elements in the output series\.

<a name='TechnicalAnalysis.Functions.MomentumStochResult.MomentumStochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],int,int,int).SlowK'></a>

`SlowK` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The calculated Slow %K values \(smoothed %K\)\.

<a name='TechnicalAnalysis.Functions.MomentumStochResult.MomentumStochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],int,int,int).SlowD'></a>

`SlowD` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The calculated Slow %D values \(moving average of Slow %K\)\.

<a name='TechnicalAnalysis.Functions.MomentumStochResult.MomentumStochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],int,int,int).FastKPeriod'></a>

`FastKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods used for %K calculation\.

<a name='TechnicalAnalysis.Functions.MomentumStochResult.MomentumStochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],int,int,int).SlowKPeriod'></a>

`SlowKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The smoothing periods for %K\.

<a name='TechnicalAnalysis.Functions.MomentumStochResult.MomentumStochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],int,int,int).SlowDPeriod'></a>

`SlowDPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods used for %D calculation\.