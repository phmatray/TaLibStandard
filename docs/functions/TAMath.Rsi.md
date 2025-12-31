#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Rsi Method

| Overloads | |
| :--- | :--- |
| [Rsi\(int, int, double\[\], int\)](TAMath.Rsi.md#TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Rsi\(int, int, double\[\], int\)') | Calculates the Relative Strength Index \(RSI\) for the input price data\. |
| [Rsi\(int, int, float\[\], int\)](TAMath.Rsi.md#TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Rsi\(int, int, float\[\], int\)') | Calculates the Relative Strength Index \(RSI\) for float input data\. |

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int)'></a>

## TAMath\.Rsi\(int, int, double\[\], int\) Method

Calculates the Relative Strength Index \(RSI\) for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.RsiResult Rsi(int startIdx, int endIdx, double[] real, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\) to calculate the RSI for\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the RSI calculation\. Default is 14\.

#### Returns
[RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult')  
A [RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult') containing the calculated RSI values,
along with the starting index of the result and the number of elements generated\.

### Remarks
The RSI is a momentum oscillator that measures the speed and magnitude of price changes\.
It oscillates between 0 and 100, with traditional overbought levels at 70 and oversold levels at 30\.
The RSI is calculated using the average gains and losses over the specified time period\.
Higher time periods result in a smoother RSI line with fewer signals\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int)'></a>

## TAMath\.Rsi\(int, int, float\[\], int\) Method

Calculates the Relative Strength Index \(RSI\) for float input data\.

```csharp
public static TechnicalAnalysis.Functions.RsiResult Rsi(int startIdx, int endIdx, float[] real, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\) to calculate the RSI for\.

<a name='TechnicalAnalysis.Functions.TAMath.Rsi(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the RSI calculation\. Default is 14\.

#### Returns
[RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult')  
A [RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult') containing the calculated RSI values,
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values for convenience and internally converts them to double precision
before performing the calculation\. This may result in minor precision differences compared to
using double values directly\.