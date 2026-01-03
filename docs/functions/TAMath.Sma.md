#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Sma Method

| Overloads | |
| :--- | :--- |
| [Sma\(int, int, double\[\], int\)](TAMath.Sma.md#TechnicalAnalysis.Functions.TAMath.Sma(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Sma\(int, int, double\[\], int\)') | Calculates the Simple Moving Average \(SMA\) for the input price data\. |
| [Sma\(int, int, float\[\], int\)](TAMath.Sma.md#TechnicalAnalysis.Functions.TAMath.Sma(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Sma\(int, int, float\[\], int\)') | Calculates the Simple Moving Average \(SMA\) for float input data\. |

<a name='TechnicalAnalysis.Functions.TAMath.Sma(int,int,double[],int)'></a>

## TAMath\.Sma\(int, int, double\[\], int\) Method

Calculates the Simple Moving Average \(SMA\) for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.SmaResult Sma(int startIdx, int endIdx, double[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sma(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sma(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sma(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\) to calculate the SMA for\.

<a name='TechnicalAnalysis.Functions.TAMath.Sma(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the moving average calculation\. Default is 30\.

#### Returns
[SmaResult](SmaResult.md 'TechnicalAnalysis\.Functions\.SmaResult')  
A [SmaResult](SmaResult.md 'TechnicalAnalysis\.Functions\.SmaResult') containing the calculated SMA values,
along with the starting index of the result and the number of elements generated\.

### Remarks
The Simple Moving Average is the unweighted mean of the previous n data points\.
It is commonly used to smooth out short\-term fluctuations and highlight longer\-term trends\.
The SMA gives equal weight to all values in the calculation period, making it less
responsive to recent price changes compared to exponential moving averages\.

<a name='TechnicalAnalysis.Functions.TAMath.Sma(int,int,float[],int)'></a>

## TAMath\.Sma\(int, int, float\[\], int\) Method

Calculates the Simple Moving Average \(SMA\) for float input data\.

```csharp
public static TechnicalAnalysis.Functions.SmaResult Sma(int startIdx, int endIdx, float[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sma(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sma(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sma(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\) to calculate the SMA for\.

<a name='TechnicalAnalysis.Functions.TAMath.Sma(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the moving average calculation\. Default is 30\.

#### Returns
[SmaResult](SmaResult.md 'TechnicalAnalysis\.Functions\.SmaResult')  
A [SmaResult](SmaResult.md 'TechnicalAnalysis\.Functions\.SmaResult') containing the calculated SMA values,
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values for convenience and internally converts them to double precision
before performing the calculation\. This may result in minor precision differences compared to
using double values directly\.