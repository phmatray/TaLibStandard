#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.BollingerBands Method

| Overloads | |
| :--- | :--- |
| [BollingerBands\(int, int, double\[\], int, double, double, MAType\)](TAMath.BollingerBands.md#TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.BollingerBands\(int, int, double\[\], int, double, double, TechnicalAnalysis\.Common\.MAType\)') | Calculates Bollinger Bands for a price series\. |
| [BollingerBands\(int, int, float\[\], int, double, double, MAType\)](TAMath.BollingerBands.md#TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,float[],int,double,double,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.BollingerBands\(int, int, float\[\], int, double, double, TechnicalAnalysis\.Common\.MAType\)') | Calculates Bollinger Bands for a price series using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.BollingerBands\(int, int, double\[\], int, double, double, MAType\) Method

Calculates Bollinger Bands for a price series\.

```csharp
public static TechnicalAnalysis.Functions.BollingerBandsResult BollingerBands(int startIdx, int endIdx, double[] real, int timePeriod=5, double nbDevUp=2.0, double nbDevDn=2.0, TechnicalAnalysis.Common.MAType maType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of price values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the moving average calculation \(default: 5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType).nbDevUp'></a>

`nbDevUp` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The number of standard deviations for the upper band \(default: 2\.0\)\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType).nbDevDn'></a>

`nbDevDn` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The number of standard deviations for the lower band \(default: 2\.0\)\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use for the middle band \(default: SMA\)\.

#### Returns
[BollingerBandsResult](BollingerBandsResult.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult')  
A [BollingerBandsResult](BollingerBandsResult.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult') object containing the upper band, middle band,
lower band values, and associated metadata\.

### Remarks
Bollinger Bands are a volatility indicator consisting of three lines: a middle band \(moving average\),
an upper band \(middle band \+ n standard deviations\), and a lower band \(middle band \- n standard deviations\)\.
The bands expand during periods of high volatility and contract during periods of low volatility\.
They are commonly used to identify overbought/oversold conditions and potential support/resistance levels\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,float[],int,double,double,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.BollingerBands\(int, int, float\[\], int, double, double, MAType\) Method

Calculates Bollinger Bands for a price series using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.BollingerBandsResult BollingerBands(int startIdx, int endIdx, float[] real, int timePeriod=5, double nbDevUp=2.0, double nbDevDn=2.0, TechnicalAnalysis.Common.MAType maType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,float[],int,double,double,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,float[],int,double,double,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,float[],int,double,double,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of price values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,float[],int,double,double,TechnicalAnalysis.Common.MAType).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the moving average calculation \(default: 5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,float[],int,double,double,TechnicalAnalysis.Common.MAType).nbDevUp'></a>

`nbDevUp` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The number of standard deviations for the upper band \(default: 2\.0\)\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,float[],int,double,double,TechnicalAnalysis.Common.MAType).nbDevDn'></a>

`nbDevDn` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The number of standard deviations for the lower band \(default: 2\.0\)\.

<a name='TechnicalAnalysis.Functions.TAMath.BollingerBands(int,int,float[],int,double,double,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use for the middle band \(default: SMA\)\.

#### Returns
[BollingerBandsResult](BollingerBandsResult.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult')  
A [BollingerBandsResult](BollingerBandsResult.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult') object containing the upper band, middle band,
lower band values, and associated metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
Bollinger Bands are a popular technical indicator for measuring volatility and identifying
potential support and resistance levels\.