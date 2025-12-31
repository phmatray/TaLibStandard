#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[HtPhasorResult](HtPhasorResult.md 'TechnicalAnalysis\.Functions\.HtPhasorResult')

## HtPhasorResult\(RetCode, int, int, double\[\], double\[\]\) Constructor

Initializes a new instance of the [HtPhasorResult](HtPhasorResult.md 'TechnicalAnalysis\.Functions\.HtPhasorResult') class\.

```csharp
public HtPhasorResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] inPhase, double[] quadrature);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.HtPhasorResult.HtPhasorResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.HtPhasorResult.HtPhasorResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).begIdx'></a>

`begIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Functions.HtPhasorResult.HtPhasorResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).nbElement'></a>

`nbElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Functions.HtPhasorResult.HtPhasorResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).inPhase'></a>

`inPhase` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of in\-phase component values representing the real part of the complex signal\.

<a name='TechnicalAnalysis.Functions.HtPhasorResult.HtPhasorResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).quadrature'></a>

`quadrature` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of quadrature component values representing the imaginary part of the complex signal\.