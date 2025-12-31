#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MinMaxResult](MinMaxResult.md 'TechnicalAnalysis\.Functions\.MinMaxResult')

## MinMaxResult\(RetCode, int, int, double\[\], double\[\]\) Constructor

Initializes a new instance of the [MinMaxResult](MinMaxResult.md 'TechnicalAnalysis\.Functions\.MinMaxResult') class\.

```csharp
public MinMaxResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] min, double[] max);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MinMaxResult.MinMaxResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.MinMaxResult.MinMaxResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).begIdx'></a>

`begIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Functions.MinMaxResult.MinMaxResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).nbElement'></a>

`nbElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Functions.MinMaxResult.MinMaxResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).min'></a>

`min` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of minimum values found within each period\.

<a name='TechnicalAnalysis.Functions.MinMaxResult.MinMaxResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).max'></a>

`max` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of maximum values found within each period\.