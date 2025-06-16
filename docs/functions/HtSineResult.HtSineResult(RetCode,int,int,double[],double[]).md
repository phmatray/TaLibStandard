#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[HtSineResult](HtSineResult.md 'TechnicalAnalysis\.Functions\.HtSineResult')

## HtSineResult\(RetCode, int, int, double\[\], double\[\]\) Constructor

Initializes a new instance of the [HtSineResult](HtSineResult.md 'TechnicalAnalysis\.Functions\.HtSineResult') class\.

```csharp
public HtSineResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] sine, double[] leadSine);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.HtSineResult.HtSineResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.HtSineResult.HtSineResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).begIdx'></a>

`begIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Functions.HtSineResult.HtSineResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).nbElement'></a>

`nbElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Functions.HtSineResult.HtSineResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).sine'></a>

`sine` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of sine wave values derived from the dominant cycle\.

<a name='TechnicalAnalysis.Functions.HtSineResult.HtSineResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[]).leadSine'></a>

`leadSine` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of leading sine wave values, phase\-advanced for early signal generation\.