#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TrendEmaResult](TrendEmaResult.md 'TechnicalAnalysis\.Functions\.TrendEmaResult')

## TrendEmaResult\(RetCode, int, int, double\[\], int\) Constructor

Represents the result of an Exponential Moving Average \(EMA\) trend analysis\.

```csharp
public TrendEmaResult(TechnicalAnalysis.Common.RetCode RetCode, int BegIdx, int NBElement, double[] Values, int Period);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TrendEmaResult.TrendEmaResult(TechnicalAnalysis.Common.RetCode,int,int,double[],int).RetCode'></a>

`RetCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the status of the calculation\.

<a name='TechnicalAnalysis.Functions.TrendEmaResult.TrendEmaResult(TechnicalAnalysis.Common.RetCode,int,int,double[],int).BegIdx'></a>

`BegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The beginning index of the output series\.

<a name='TechnicalAnalysis.Functions.TrendEmaResult.TrendEmaResult(TechnicalAnalysis.Common.RetCode,int,int,double[],int).NBElement'></a>

`NBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of elements in the output series\.

<a name='TechnicalAnalysis.Functions.TrendEmaResult.TrendEmaResult(TechnicalAnalysis.Common.RetCode,int,int,double[],int).Values'></a>

`Values` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The calculated EMA values\.

<a name='TechnicalAnalysis.Functions.TrendEmaResult.TrendEmaResult(TechnicalAnalysis.Common.RetCode,int,int,double[],int).Period'></a>

`Period` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods used in the EMA calculation\.