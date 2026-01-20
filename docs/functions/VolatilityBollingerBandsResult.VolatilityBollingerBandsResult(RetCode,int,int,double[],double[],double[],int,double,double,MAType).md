#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[VolatilityBollingerBandsResult](VolatilityBollingerBandsResult.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult')

## VolatilityBollingerBandsResult\(RetCode, int, int, double\[\], double\[\], double\[\], int, double, double, MAType\) Constructor

Represents the result of a Bollinger Bands volatility analysis\.

```csharp
public VolatilityBollingerBandsResult(TechnicalAnalysis.Common.RetCode RetCode, int BegIdx, int NBElement, double[] UpperBand, double[] MiddleBand, double[] LowerBand, int Period, double NbDevUp, double NbDevDn, TechnicalAnalysis.Common.MAType MAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.VolatilityBollingerBandsResult.VolatilityBollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,double,double,TechnicalAnalysis.Common.MAType).RetCode'></a>

`RetCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the status of the calculation\.

<a name='TechnicalAnalysis.Functions.VolatilityBollingerBandsResult.VolatilityBollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,double,double,TechnicalAnalysis.Common.MAType).BegIdx'></a>

`BegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The beginning index of the output series\.

<a name='TechnicalAnalysis.Functions.VolatilityBollingerBandsResult.VolatilityBollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,double,double,TechnicalAnalysis.Common.MAType).NBElement'></a>

`NBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of elements in the output series\.

<a name='TechnicalAnalysis.Functions.VolatilityBollingerBandsResult.VolatilityBollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,double,double,TechnicalAnalysis.Common.MAType).UpperBand'></a>

`UpperBand` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The calculated upper band values\.

<a name='TechnicalAnalysis.Functions.VolatilityBollingerBandsResult.VolatilityBollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,double,double,TechnicalAnalysis.Common.MAType).MiddleBand'></a>

`MiddleBand` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The calculated middle band \(moving average\) values\.

<a name='TechnicalAnalysis.Functions.VolatilityBollingerBandsResult.VolatilityBollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,double,double,TechnicalAnalysis.Common.MAType).LowerBand'></a>

`LowerBand` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The calculated lower band values\.

<a name='TechnicalAnalysis.Functions.VolatilityBollingerBandsResult.VolatilityBollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,double,double,TechnicalAnalysis.Common.MAType).Period'></a>

`Period` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods used in the calculation\.

<a name='TechnicalAnalysis.Functions.VolatilityBollingerBandsResult.VolatilityBollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,double,double,TechnicalAnalysis.Common.MAType).NbDevUp'></a>

`NbDevUp` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The number of standard deviations used for the upper band\.

<a name='TechnicalAnalysis.Functions.VolatilityBollingerBandsResult.VolatilityBollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,double,double,TechnicalAnalysis.Common.MAType).NbDevDn'></a>

`NbDevDn` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The number of standard deviations used for the lower band\.

<a name='TechnicalAnalysis.Functions.VolatilityBollingerBandsResult.VolatilityBollingerBandsResult(TechnicalAnalysis.Common.RetCode,int,int,double[],double[],double[],int,double,double,TechnicalAnalysis.Common.MAType).MAType'></a>

`MAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average used\.