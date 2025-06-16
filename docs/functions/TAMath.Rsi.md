#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Rsi Method

| Overloads | |
| :--- | :--- |
| [Rsi\(int, int, double\[\], int\)](TAMath.Rsi.md#TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Rsi\(int, int, double\[\], int\)') | Calculates the Relative Strength Index \(RSI\) for the input price data\. |
| [Rsi\(int, int, double\[\]\)](TAMath.Rsi.md#TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Rsi\(int, int, double\[\]\)') | Calculates the Relative Strength Index \(RSI\) for the input price data using the default period of 14\. |
| [Rsi\(int, int, float\[\], int\)](TAMath.Rsi.md#TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Rsi\(int, int, float\[\], int\)') | Calculates the Relative Strength Index \(RSI\) for the input price data\. |
| [Rsi\(int, int, float\[\]\)](TAMath.Rsi.md#TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Rsi\(int, int, float\[\]\)') | Calculates the Relative Strength Index \(RSI\) for the input price data using the default period of 14\. |

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int)'></a>

## TAMath\.Rsi\(int, int, double\[\], int\) Method

Calculates the Relative Strength Index \(RSI\) for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.RsiResult Rsi(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values \(typically closing prices\) to calculate the RSI for\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the RSI calculation \(commonly 14\)\.

#### Returns
[RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult')  
A [RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult') containing the calculated RSI values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
The RSI is a momentum oscillator that measures the speed and magnitude of price changes\.
It oscillates between 0 and 100, with traditional overbought levels at 70 and oversold levels at 30\.
The RSI is calculated using the average gains and losses over the specified time period\.
Higher time periods result in a smoother RSI line with fewer signals\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[])'></a>

## TAMath\.Rsi\(int, int, double\[\]\) Method

Calculates the Relative Strength Index \(RSI\) for the input price data using the default period of 14\.

```csharp
public static TechnicalAnalysis.Functions.RsiResult Rsi(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values \(typically closing prices\) to calculate the RSI for\.

#### Returns
[RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult')  
A [RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult') containing the calculated RSI values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload uses the standard 14\-period RSI calculation, which is the most commonly used setting
in technical analysis\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int)'></a>

## TAMath\.Rsi\(int, int, float\[\], int\) Method

Calculates the Relative Strength Index \(RSI\) for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.RsiResult Rsi(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values \(typically closing prices\) to calculate the RSI for\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the RSI calculation \(commonly 14\)\.

#### Returns
[RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult')  
A [RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult') containing the calculated RSI values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values for convenience and internally converts them to double precision
before performing the calculation\. This may result in minor precision differences compared to 
using double values directly\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[])'></a>

## TAMath\.Rsi\(int, int, float\[\]\) Method

Calculates the Relative Strength Index \(RSI\) for the input price data using the default period of 14\.

```csharp
public static TechnicalAnalysis.Functions.RsiResult Rsi(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values \(typically closing prices\) to calculate the RSI for\.

#### Returns
[RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult')  
A [RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult') containing the calculated RSI values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values and uses the standard 14\-period RSI calculation\.
The values are internally converted to double precision before performing the calculation\.