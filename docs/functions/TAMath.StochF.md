#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.StochF Method

| Overloads | |
| :--- | :--- |
| [StochF\(int, int, double\[\], double\[\], double\[\], int, int, MAType\)](TAMath.StochF.md#TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.StochF\(int, int, double\[\], double\[\], double\[\], int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Fast Stochastic \(STOCHF\) which provides a more responsive version of the stochastic oscillator\. |
| [StochF\(int, int, double\[\], double\[\], double\[\]\)](TAMath.StochF.md#TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.StochF\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the Fast Stochastic using default parameters\. |
| [StochF\(int, int, float\[\], float\[\], float\[\], int, int, MAType\)](TAMath.StochF.md#TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.StochF\(int, int, float\[\], float\[\], float\[\], int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Fast Stochastic \(STOCHF\) which provides a more responsive version of the stochastic oscillator\. |
| [StochF\(int, int, float\[\], float\[\], float\[\]\)](TAMath.StochF.md#TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.StochF\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the Fast Stochastic using default parameters\. |

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.StochF\(int, int, double\[\], double\[\], double\[\], int, int, MAType\) Method

Calculates the Fast Stochastic \(STOCHF\) which provides a more responsive version of the stochastic oscillator\.

```csharp
public static TechnicalAnalysis.Functions.StochFResult StochF(int startIdx, int endIdx, double[] high, double[] low, double[] close, int fastKPeriod, int fastDPeriod, TechnicalAnalysis.Common.MAType fastDMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for Fast %K calculation \(default: 5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).fastDPeriod'></a>

`fastDPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The smoothing period for Fast %K to get Fast %D \(default: 3\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).fastDMAType'></a>

`fastDMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for Fast %D calculation \(default: Simple MA\)\.

#### Returns
[StochFResult](StochFResult.md 'TechnicalAnalysis\.Functions\.StochFResult')  
A StochFResult containing the Fast %K and Fast %D values\.

### Remarks
The Fast Stochastic is more responsive to price changes than the slow stochastic\.
It uses unsmoothed %K line and a smoothed %D line:
\- Fast %K: Raw stochastic calculation
\- Fast %D: Moving average of Fast %K
This indicator is useful for short\-term trading but can be more prone to false signals\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[])'></a>

## TAMath\.StochF\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Fast Stochastic using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.StochFResult StochF(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[StochFResult](StochFResult.md 'TechnicalAnalysis\.Functions\.StochFResult')  
A StochFResult containing the Fast %K and Fast %D values\.

### Remarks
Uses default values: fastKPeriod=5, fastDPeriod=3, fastDMAType=Simple Moving Average\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.StochF\(int, int, float\[\], float\[\], float\[\], int, int, MAType\) Method

Calculates the Fast Stochastic \(STOCHF\) which provides a more responsive version of the stochastic oscillator\.

```csharp
public static TechnicalAnalysis.Functions.StochFResult StochF(int startIdx, int endIdx, float[] high, float[] low, float[] close, int fastKPeriod, int fastDPeriod, TechnicalAnalysis.Common.MAType fastDMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for Fast %K calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).fastDPeriod'></a>

`fastDPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The smoothing period for Fast %K to get Fast %D\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).fastDMAType'></a>

`fastDMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for Fast %D calculation\.

#### Returns
[StochFResult](StochFResult.md 'TechnicalAnalysis\.Functions\.StochFResult')  
A StochFResult containing the Fast %K and Fast %D values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[])'></a>

## TAMath\.StochF\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the Fast Stochastic using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.StochFResult StochF(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[StochFResult](StochFResult.md 'TechnicalAnalysis\.Functions\.StochFResult')  
A StochFResult containing the Fast %K and Fast %D values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.
Uses default values: fastKPeriod=5, fastDPeriod=3, fastDMAType=Simple Moving Average\.