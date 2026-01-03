#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.StochF Method

| Overloads | |
| :--- | :--- |
| [StochF\(int, int, double\[\], double\[\], double\[\], int, int, MAType\)](TAMath.StochF.md#TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.StochF\(int, int, double\[\], double\[\], double\[\], int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Fast Stochastic \(STOCHF\) which provides a more responsive version of the stochastic oscillator\. |
| [StochF\(int, int, float\[\], float\[\], float\[\], int, int, MAType\)](TAMath.StochF.md#TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.StochF\(int, int, float\[\], float\[\], float\[\], int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Fast Stochastic \(STOCHF\) which provides a more responsive version of the stochastic oscillator\. |

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.StochF\(int, int, double\[\], double\[\], double\[\], int, int, MAType\) Method

Calculates the Fast Stochastic \(STOCHF\) which provides a more responsive version of the stochastic oscillator\.

```csharp
public static TechnicalAnalysis.Functions.StochFResult StochF(int startIdx, int endIdx, double[] high, double[] low, double[] close, int fastKPeriod=5, int fastDPeriod=3, TechnicalAnalysis.Common.MAType fastDMAType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for Fast %K calculation \(default: 5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).fastDPeriod'></a>

`fastDPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The smoothing period for Fast %K to get Fast %D \(default: 3\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType).fastDMAType'></a>

`fastDMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

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

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.StochF\(int, int, float\[\], float\[\], float\[\], int, int, MAType\) Method

Calculates the Fast Stochastic \(STOCHF\) which provides a more responsive version of the stochastic oscillator\.

```csharp
public static TechnicalAnalysis.Functions.StochFResult StochF(int startIdx, int endIdx, float[] high, float[] low, float[] close, int fastKPeriod=5, int fastDPeriod=3, TechnicalAnalysis.Common.MAType fastDMAType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for Fast %K calculation \(default: 5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).fastDPeriod'></a>

`fastDPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The smoothing period for Fast %K to get Fast %D \(default: 3\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochF(int,int,float[],float[],float[],int,int,TechnicalAnalysis.Common.MAType).fastDMAType'></a>

`fastDMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for Fast %D calculation \(default: Simple MA\)\.

#### Returns
[StochFResult](StochFResult.md 'TechnicalAnalysis\.Functions\.StochFResult')  
A StochFResult containing the Fast %K and Fast %D values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.