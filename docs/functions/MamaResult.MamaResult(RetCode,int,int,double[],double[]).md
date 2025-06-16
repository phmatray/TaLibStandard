#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MamaResult](MamaResult.md 'TechnicalAnalysis\.Functions\.MamaResult')

## MamaResult\(RetCode, int, int, double\[\], double\[\]\) Constructor

Initializes a new instance of the [MamaResult](MamaResult.md 'TechnicalAnalysis\.Functions\.MamaResult') class\.

```csharp
public MamaResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] mama, double[] fama);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MamaResult.MamaResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.MamaResult.MamaResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).begIdx'></a>

`begIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Functions.MamaResult.MamaResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).nbElement'></a>

`nbElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Functions.MamaResult.MamaResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).mama'></a>

`mama` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of MESA Adaptive Moving Average values\.

<a name='TechnicalAnalysis.Functions.MamaResult.MamaResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).fama'></a>

`fama` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of Following Adaptive Moving Average values\.