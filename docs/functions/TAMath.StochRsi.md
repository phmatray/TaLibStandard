#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.StochRsi Method

| Overloads | |
| :--- | :--- |
| [StochRsi\(int, int, double\[\], int, int, int, MAType\)](TAMath.StochRsi.md#TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.StochRsi\(int, int, double\[\], int, int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Stochastic RSI \(STOCHRSI\) which applies stochastic calculations to RSI values\. |
| [StochRsi\(int, int, double\[\]\)](TAMath.StochRsi.md#TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.StochRsi\(int, int, double\[\]\)') | Calculates the Stochastic RSI using default parameters\. |
| [StochRsi\(int, int, float\[\], int, int, int, MAType\)](TAMath.StochRsi.md#TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[],int,int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.StochRsi\(int, int, float\[\], int, int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Stochastic RSI \(STOCHRSI\) which applies stochastic calculations to RSI values\. |
| [StochRsi\(int, int, float\[\]\)](TAMath.StochRsi.md#TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.StochRsi\(int, int, float\[\]\)') | Calculates the Stochastic RSI using default parameters\. |

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.StochRsi\(int, int, double\[\], int, int, int, MAType\) Method

Calculates the Stochastic RSI \(STOCHRSI\) which applies stochastic calculations to RSI values\.

```csharp
public static TechnicalAnalysis.Functions.StochRsiResult StochRsi(int startIdx, int endIdx, double[] real, int timePeriod, int fastKPeriod, int fastDPeriod, TechnicalAnalysis.Common.MAType fastDMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for RSI calculation \(default: 14\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for stochastic %K calculation \(default: 5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType).fastDPeriod'></a>

`fastDPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The smoothing period for %K to get %D \(default: 3\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType).fastDMAType'></a>

`fastDMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for %D calculation \(default: Simple MA\)\.

#### Returns
[StochRsiResult](StochRsiResult.md 'TechnicalAnalysis\.Functions\.StochRsiResult')  
A StochRsiResult containing the Stochastic RSI %K and %D values\.

### Remarks
The Stochastic RSI is an oscillator that measures the level of RSI relative to its high\-low range
over a set time period\. It applies the stochastic oscillator formula to RSI values instead of price\.
This creates a more sensitive indicator that generates more overbought/oversold signals than regular RSI\.
Values range from 0 to 1 \(or 0 to 100 when expressed as percentage\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[])'></a>

## TAMath\.StochRsi\(int, int, double\[\]\) Method

Calculates the Stochastic RSI using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.StochRsiResult StochRsi(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

#### Returns
[StochRsiResult](StochRsiResult.md 'TechnicalAnalysis\.Functions\.StochRsiResult')  
A StochRsiResult containing the Stochastic RSI %K and %D values\.

### Remarks
Uses default values: timePeriod=14, fastKPeriod=5, fastDPeriod=3, fastDMAType=Simple Moving Average\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[],int,int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.StochRsi\(int, int, float\[\], int, int, int, MAType\) Method

Calculates the Stochastic RSI \(STOCHRSI\) which applies stochastic calculations to RSI values\.

```csharp
public static TechnicalAnalysis.Functions.StochRsiResult StochRsi(int startIdx, int endIdx, float[] real, int timePeriod, int fastKPeriod, int fastDPeriod, TechnicalAnalysis.Common.MAType fastDMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[],int,int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[],int,int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[],int,int,int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[],int,int,int,TechnicalAnalysis.Common.MAType).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for RSI calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[],int,int,int,TechnicalAnalysis.Common.MAType).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for stochastic %K calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[],int,int,int,TechnicalAnalysis.Common.MAType).fastDPeriod'></a>

`fastDPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The smoothing period for %K to get %D\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[],int,int,int,TechnicalAnalysis.Common.MAType).fastDMAType'></a>

`fastDMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for %D calculation\.

#### Returns
[StochRsiResult](StochRsiResult.md 'TechnicalAnalysis\.Functions\.StochRsiResult')  
A StochRsiResult containing the Stochastic RSI %K and %D values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[])'></a>

## TAMath\.StochRsi\(int, int, float\[\]\) Method

Calculates the Stochastic RSI using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.StochRsiResult StochRsi(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StochRsi(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

#### Returns
[StochRsiResult](StochRsiResult.md 'TechnicalAnalysis\.Functions\.StochRsiResult')  
A StochRsiResult containing the Stochastic RSI %K and %D values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.
Uses default values: timePeriod=14, fastKPeriod=5, fastDPeriod=3, fastDMAType=Simple Moving Average\.