#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MomentumMacdResult](MomentumMacdResult.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult')

## MomentumMacdResult\(RetCode, int, int, double\[\], double\[\], double\[\], int, int, int\) Constructor

Represents the result of a Moving Average Convergence Divergence \(MACD\) momentum analysis\.

```csharp
public MomentumMacdResult(TechnicalAnalysis.Common.RetCode RetCode, int BegIdx, int NBElement, double[] MacdLine, double[] SignalLine, double[] Histogram, int FastPeriod, int SlowPeriod, int SignalPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MomentumMacdResult.MomentumMacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,int,int).RetCode'></a>

`RetCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the status of the calculation\.

<a name='TechnicalAnalysis.Functions.MomentumMacdResult.MomentumMacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,int,int).BegIdx'></a>

`BegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The beginning index of the output series\.

<a name='TechnicalAnalysis.Functions.MomentumMacdResult.MomentumMacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,int,int).NBElement'></a>

`NBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of elements in the output series\.

<a name='TechnicalAnalysis.Functions.MomentumMacdResult.MomentumMacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,int,int).MacdLine'></a>

`MacdLine` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The calculated MACD line values \(fast EMA \- slow EMA\)\.

<a name='TechnicalAnalysis.Functions.MomentumMacdResult.MomentumMacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,int,int).SignalLine'></a>

`SignalLine` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The calculated signal line values \(EMA of MACD line\)\.

<a name='TechnicalAnalysis.Functions.MomentumMacdResult.MomentumMacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,int,int).Histogram'></a>

`Histogram` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The calculated histogram values \(MACD line \- signal line\)\.

<a name='TechnicalAnalysis.Functions.MomentumMacdResult.MomentumMacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,int,int).FastPeriod'></a>

`FastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods used for the fast EMA\.

<a name='TechnicalAnalysis.Functions.MomentumMacdResult.MomentumMacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,int,int).SlowPeriod'></a>

`SlowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods used for the slow EMA\.

<a name='TechnicalAnalysis.Functions.MomentumMacdResult.MomentumMacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,int,int).SignalPeriod'></a>

`SignalPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods used for the signal line\.