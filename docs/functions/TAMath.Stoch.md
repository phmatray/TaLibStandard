#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Stoch Method

| Overloads | |
| :--- | :--- |
| [Stoch\(int, int, double\[\], double\[\], double\[\], int, int, MAType, int, MAType\)](TAMath.Stoch.md#TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.Stoch\(int, int, double\[\], double\[\], double\[\], int, int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Stochastic Oscillator \(STOCH\) which measures momentum by comparing closing price to price range\. |
| [Stoch\(int, int, float\[\], float\[\], float\[\], int, int, MAType, int, MAType\)](TAMath.Stoch.md#TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.Stoch\(int, int, float\[\], float\[\], float\[\], int, int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Stochastic Oscillator \(STOCH\) which measures momentum by comparing closing price to price range\. |

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.Stoch\(int, int, double\[\], double\[\], double\[\], int, int, MAType, int, MAType\) Method

Calculates the Stochastic Oscillator \(STOCH\) which measures momentum by comparing closing price to price range\.

```csharp
public static TechnicalAnalysis.Functions.StochResult Stoch(int startIdx, int endIdx, double[] high, double[] low, double[] close, int fastKPeriod=5, int slowKPeriod=3, TechnicalAnalysis.Common.MAType slowKMAType=TechnicalAnalysis.Common.MAType.Sma, int slowDPeriod=3, TechnicalAnalysis.Common.MAType slowDMAType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for %K calculation \(default: 5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowKPeriod'></a>

`slowKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The smoothing period for %K to get Slow %K \(default: 3\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowKMAType'></a>

`slowKMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for Slow %K smoothing \(default: Simple MA\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowDPeriod'></a>

`slowDPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The smoothing period for Slow %K to get Slow %D \(default: 3\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowDMAType'></a>

`slowDMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for Slow %D smoothing \(default: Simple MA\)\.

#### Returns
[StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult')  
A StochResult containing the Slow %K and Slow %D values\.

### Remarks
The Stochastic Oscillator is a momentum indicator comparing the closing price to the range of prices
over a certain period\. It consists of two lines:
\- %K: The main line showing the current close relative to the high\-low range
\- %D: A moving average of %K, acting as a signal line
Values range from 0 to 100, with readings above 80 indicating overbought and below 20 indicating oversold\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.Stoch\(int, int, float\[\], float\[\], float\[\], int, int, MAType, int, MAType\) Method

Calculates the Stochastic Oscillator \(STOCH\) which measures momentum by comparing closing price to price range\.

```csharp
public static TechnicalAnalysis.Functions.StochResult Stoch(int startIdx, int endIdx, float[] high, float[] low, float[] close, int fastKPeriod=5, int slowKPeriod=3, TechnicalAnalysis.Common.MAType slowKMAType=TechnicalAnalysis.Common.MAType.Sma, int slowDPeriod=3, TechnicalAnalysis.Common.MAType slowDMAType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for %K calculation \(default: 5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowKPeriod'></a>

`slowKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The smoothing period for %K to get Slow %K \(default: 3\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowKMAType'></a>

`slowKMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for Slow %K smoothing \(default: Simple MA\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowDPeriod'></a>

`slowDPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The smoothing period for Slow %K to get Slow %D \(default: 3\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowDMAType'></a>

`slowDMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for Slow %D smoothing \(default: Simple MA\)\.

#### Returns
[StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult')  
A StochResult containing the Slow %K and Slow %D values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.