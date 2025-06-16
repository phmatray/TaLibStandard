#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[StochRsiResult](StochRsiResult.md 'TechnicalAnalysis\.Functions\.StochRsiResult')

## StochRsiResult\(RetCode, int, int, double\[\], double\[\]\) Constructor

Initializes a new instance of the [StochRsiResult](StochRsiResult.md 'TechnicalAnalysis\.Functions\.StochRsiResult') class\.

```csharp
public StochRsiResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] fastK, double[] fastD);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.StochRsiResult.StochRsiResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.StochRsiResult.StochRsiResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).begIdx'></a>

`begIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Functions.StochRsiResult.StochRsiResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).nbElement'></a>

`nbElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Functions.StochRsiResult.StochRsiResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).fastK'></a>

`fastK` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of %K values representing the raw stochastic of RSI\.

<a name='TechnicalAnalysis.Functions.StochRsiResult.StochRsiResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).fastD'></a>

`fastD` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of %D values representing the smoothed %K line\.