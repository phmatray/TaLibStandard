#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[AroonResult](AroonResult.md 'TechnicalAnalysis\.Functions\.AroonResult')

## AroonResult\(RetCode, int, int, double\[\], double\[\]\) Constructor

Initializes a new instance of the [AroonResult](AroonResult.md 'TechnicalAnalysis\.Functions\.AroonResult') class\.

```csharp
public AroonResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] aroonDown, double[] aroonUp);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.AroonResult.AroonResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.AroonResult.AroonResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).begIdx'></a>

`begIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Functions.AroonResult.AroonResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).nbElement'></a>

`nbElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Functions.AroonResult.AroonResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).aroonDown'></a>

`aroonDown` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array containing the calculated Aroon Down values\.

<a name='TechnicalAnalysis.Functions.AroonResult.AroonResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).aroonUp'></a>

`aroonUp` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array containing the calculated Aroon Up values\.