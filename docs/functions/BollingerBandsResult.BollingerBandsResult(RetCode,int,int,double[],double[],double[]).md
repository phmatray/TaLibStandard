#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[BollingerBandsResult](BollingerBandsResult.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult')

## BollingerBandsResult\(RetCode, int, int, double\[\], double\[\], double\[\]\) Constructor

Initializes a new instance of the [BollingerBandsResult](BollingerBandsResult.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult') class\.

```csharp
public BollingerBandsResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] realUpperBand, double[] realMiddleBand, double[] realLowerBand);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.BollingerBandsResult.BollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.BollingerBandsResult.BollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).begIdx'></a>

`begIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Functions.BollingerBandsResult.BollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).nbElement'></a>

`nbElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Functions.BollingerBandsResult.BollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).realUpperBand'></a>

`realUpperBand` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array containing the upper band values\.

<a name='TechnicalAnalysis.Functions.BollingerBandsResult.BollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).realMiddleBand'></a>

`realMiddleBand` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array containing the middle band \(SMA\) values\.

<a name='TechnicalAnalysis.Functions.BollingerBandsResult.BollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[]).realLowerBand'></a>

`realLowerBand` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array containing the lower band values\.