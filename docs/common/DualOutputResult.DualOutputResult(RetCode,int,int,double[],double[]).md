#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[DualOutputResult](DualOutputResult.md 'TechnicalAnalysis\.Common\.DualOutputResult')

## DualOutputResult\(RetCode, int, int, double\[\], double\[\]\) Constructor

Initializes a new instance of the [DualOutputResult](DualOutputResult.md 'TechnicalAnalysis\.Common\.DualOutputResult') class\.

```csharp
protected DualOutputResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] real0, double[] real1);
```
#### Parameters

<a name='TechnicalAnalysis.Common.DualOutputResult.DualOutputResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).retCode'></a>

`retCode` [RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Common.DualOutputResult.DualOutputResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).begIdx'></a>

`begIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Common.DualOutputResult.DualOutputResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).nbElement'></a>

`nbElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Common.DualOutputResult.DualOutputResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).real0'></a>

`real0` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The first array of calculated indicator values\.

<a name='TechnicalAnalysis.Common.DualOutputResult.DualOutputResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).real1'></a>

`real1` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The second array of calculated indicator values\.