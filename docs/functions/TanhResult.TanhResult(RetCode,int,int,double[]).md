#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TanhResult](TanhResult.md 'TechnicalAnalysis\.Functions\.TanhResult')

## TanhResult\(RetCode, int, int, double\[\]\) Constructor

Initializes a new instance of the [TanhResult](TanhResult.md 'TechnicalAnalysis\.Functions\.TanhResult') class\.

```csharp
public TanhResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TanhResult.TanhResult(TechnicalAnalysis.Common.RetCode,int,int,double[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.TanhResult.TanhResult(TechnicalAnalysis.Common.RetCode,int,int,double[]).begIdx'></a>

`begIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid data point in the output array\.

<a name='TechnicalAnalysis.Functions.TanhResult.TanhResult(TechnicalAnalysis.Common.RetCode,int,int,double[]).nbElement'></a>

`nbElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid data points in the output array\.

<a name='TechnicalAnalysis.Functions.TanhResult.TanhResult(TechnicalAnalysis.Common.RetCode,int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array containing the hyperbolic tangent values\.