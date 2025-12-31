#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult')

## StochResult\(RetCode, int, int, double\[\], double\[\]\) Constructor

Initializes a new instance of the [StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult') class\.

```csharp
public StochResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] slowK, double[] slowD);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.StochResult.StochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.StochResult.StochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).begIdx'></a>

`begIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Functions.StochResult.StochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).nbElement'></a>

`nbElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Functions.StochResult.StochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).slowK'></a>

`slowK` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array containing the %K line values \(smoothed\)\.

<a name='TechnicalAnalysis.Functions.StochResult.StochResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).slowD'></a>

`slowD` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array containing the %D line values \(signal line\)\.