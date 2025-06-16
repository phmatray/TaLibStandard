#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Stoch Method

| Overloads | |
| :--- | :--- |
| [Stoch\(int, int, double\[\], double\[\], double\[\], int, int, MAType, int, MAType\)](TAMath.Stoch.md#TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.Stoch\(int, int, double\[\], double\[\], double\[\], int, int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Stochastic Oscillator \(STOCH\) which measures momentum by comparing closing price to price range\. |
| [Stoch\(int, int, double\[\], double\[\], double\[\]\)](TAMath.Stoch.md#TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Stoch\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the Stochastic Oscillator using default parameters\. |
| [Stoch\(int, int, float\[\], float\[\], float\[\], int, int, MAType, int, MAType\)](TAMath.Stoch.md#TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.Stoch\(int, int, float\[\], float\[\], float\[\], int, int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Stochastic Oscillator \(STOCH\) which measures momentum by comparing closing price to price range\. |
| [Stoch\(int, int, float\[\], float\[\], float\[\]\)](TAMath.Stoch.md#TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Stoch\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the Stochastic Oscillator using default parameters\. |

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.Stoch\(int, int, double\[\], double\[\], double\[\], int, int, MAType, int, MAType\) Method

Calculates the Stochastic Oscillator \(STOCH\) which measures momentum by comparing closing price to price range\.

```csharp
public static TechnicalAnalysis.Functions.StochResult Stoch(int startIdx, int endIdx, double[] high, double[] low, double[] close, int fastKPeriod, int slowKPeriod, TechnicalAnalysis.Common.MAType slowKMAType, int slowDPeriod, TechnicalAnalysis.Common.MAType slowDMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for %K calculation \(default: 5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowKPeriod'></a>

`slowKPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The smoothing period for %K to get Slow %K \(default: 3\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowKMAType'></a>

`slowKMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for Slow %K smoothing \(default: Simple MA\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowDPeriod'></a>

`slowDPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The smoothing period for Slow %K to get Slow %D \(default: 3\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowDMAType'></a>

`slowDMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

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

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[])'></a>

## TAMath\.Stoch\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Stochastic Oscillator using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.StochResult Stoch(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult')  
A StochResult containing the Slow %K and Slow %D values\.

### Remarks
Uses default values: fastKPeriod=5, slowKPeriod=3, slowDPeriod=3, both using Simple Moving Average\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.Stoch\(int, int, float\[\], float\[\], float\[\], int, int, MAType, int, MAType\) Method

Calculates the Stochastic Oscillator \(STOCH\) which measures momentum by comparing closing price to price range\.

```csharp
public static TechnicalAnalysis.Functions.StochResult Stoch(int startIdx, int endIdx, float[] high, float[] low, float[] close, int fastKPeriod, int slowKPeriod, TechnicalAnalysis.Common.MAType slowKMAType, int slowDPeriod, TechnicalAnalysis.Common.MAType slowDMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for %K calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowKPeriod'></a>

`slowKPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The smoothing period for %K to get Slow %K\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowKMAType'></a>

`slowKMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for Slow %K smoothing\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowDPeriod'></a>

`slowDPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The smoothing period for Slow %K to get Slow %D\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowDMAType'></a>

`slowDMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for Slow %D smoothing\.

#### Returns
[StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult')  
A StochResult containing the Slow %K and Slow %D values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[])'></a>

## TAMath\.Stoch\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the Stochastic Oscillator using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.StochResult Stoch(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Stoch(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult')  
A StochResult containing the Slow %K and Slow %D values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.
Uses default values: fastKPeriod=5, slowKPeriod=3, slowDPeriod=3, both using Simple Moving Average\.