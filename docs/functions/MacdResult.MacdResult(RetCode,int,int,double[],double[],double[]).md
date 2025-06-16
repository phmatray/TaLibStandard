#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MacdResult](MacdResult.md 'TechnicalAnalysis\.Functions\.MacdResult')

## MacdResult\(RetCode, int, int, double\[\], double\[\], double\[\]\) Constructor

Initializes a new instance of the [MacdResult](MacdResult.md 'TechnicalAnalysis\.Functions\.MacdResult') class\.

```csharp
public MacdResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] macdValue, double[] macdSignal, double[] macdHist);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MacdResult.MacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.MacdResult.MacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).begIdx'></a>

`begIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Functions.MacdResult.MacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).nbElement'></a>

`nbElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Functions.MacdResult.MacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).macdValue'></a>

`macdValue` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of MACD line values \(fast EMA \- slow EMA\)\.

<a name='TechnicalAnalysis.Functions.MacdResult.MacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).macdSignal'></a>

`macdSignal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of signal line values \(EMA of MACD line\)\.

<a name='TechnicalAnalysis.Functions.MacdResult.MacdResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).macdHist'></a>

`macdHist` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of histogram values \(MACD line \- signal line\)\.