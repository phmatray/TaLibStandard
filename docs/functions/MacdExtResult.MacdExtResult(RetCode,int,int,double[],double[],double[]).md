#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MacdExtResult](MacdExtResult.md 'TechnicalAnalysis\.Functions\.MacdExtResult')

## MacdExtResult\(RetCode, int, int, double\[\], double\[\], double\[\]\) Constructor

Initializes a new instance of the [MacdExtResult](MacdExtResult.md 'TechnicalAnalysis\.Functions\.MacdExtResult') class\.

```csharp
public MacdExtResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] macd, double[] macdSignal, double[] macdHist);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MacdExtResult.MacdExtResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.MacdExtResult.MacdExtResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).begIdx'></a>

`begIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Functions.MacdExtResult.MacdExtResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).nbElement'></a>

`nbElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Functions.MacdExtResult.MacdExtResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).macd'></a>

`macd` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of MACD line values \(fast MA \- slow MA\)\.

<a name='TechnicalAnalysis.Functions.MacdExtResult.MacdExtResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).macdSignal'></a>

`macdSignal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of signal line values \(MA of MACD line\)\.

<a name='TechnicalAnalysis.Functions.MacdExtResult.MacdExtResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).macdHist'></a>

`macdHist` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of histogram values \(MACD line \- signal line\)\.