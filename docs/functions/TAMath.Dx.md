#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Dx Method

| Overloads | |
| :--- | :--- |
| [Dx\(int, int, double\[\], double\[\], double\[\]\)](TAMath.Dx.md#TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Dx\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the Directional Movement Index \(DX\) indicator with default period\. |
| [Dx\(int, int, double\[\], double\[\], double\[\], int\)](TAMath.Dx.md#TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Dx\(int, int, double\[\], double\[\], double\[\], int\)') | Calculates the Directional Movement Index \(DX\) indicator\. |
| [Dx\(int, int, float\[\], float\[\], float\[\]\)](TAMath.Dx.md#TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Dx\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the Directional Movement Index \(DX\) indicator using float arrays with default period\. |
| [Dx\(int, int, float\[\], float\[\], float\[\], int\)](TAMath.Dx.md#TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Dx\(int, int, float\[\], float\[\], float\[\], int\)') | Calculates the Directional Movement Index \(DX\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[])'></a>

## TAMath\.Dx\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Directional Movement Index \(DX\) indicator with default period\.

```csharp
public static TechnicalAnalysis.Functions.DxResult Dx(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

#### Returns
[DxResult](DxResult.md 'TechnicalAnalysis\.Functions\.DxResult')  
A DxResult object containing the calculated DX values\.

### Remarks
This overload uses a default time period of 14\.
See the main overload for a detailed description of the DX indicator\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[],int)'></a>

## TAMath\.Dx\(int, int, double\[\], double\[\], double\[\], int\) Method

Calculates the Directional Movement Index \(DX\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.DxResult Dx(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[],int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[],int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[],int).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,double[],double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[DxResult](DxResult.md 'TechnicalAnalysis\.Functions\.DxResult')  
A DxResult object containing the calculated DX values\.

### Remarks
The Directional Movement Index \(DX\) is a component of the Directional Movement System developed by J\. Welles Wilder\.
It measures the strength of the dominant trend by analyzing the difference between two directional indicators:
the Positive Directional Indicator \(\+DI\) and the Negative Directional Indicator \(\-DI\)\.

The DX is calculated as:
DX = 100 × \|\(\(\+DI\) \- \(\-DI\)\)\| / \(\(\+DI\) \+ \(\-DI\)\)

The DX ranges from 0 to 100, where:
\- Values below 20 indicate a weak trend
\- Values between 20\-40 indicate a moderate trend
\- Values above 40 indicate a strong trend

Note that DX measures trend strength but not trend direction\. It is often smoothed to create the 
Average Directional Index \(ADX\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[])'></a>

## TAMath\.Dx\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the Directional Movement Index \(DX\) indicator using float arrays with default period\.

```csharp
public static TechnicalAnalysis.Functions.DxResult Dx(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

#### Returns
[DxResult](DxResult.md 'TechnicalAnalysis\.Functions\.DxResult')  
A DxResult object containing the calculated DX values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
Uses a default time period of 14\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[],int)'></a>

## TAMath\.Dx\(int, int, float\[\], float\[\], float\[\], int\) Method

Calculates the Directional Movement Index \(DX\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.DxResult Dx(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[],int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[],int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[],int).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Dx(int,int,float[],float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation\.

#### Returns
[DxResult](DxResult.md 'TechnicalAnalysis\.Functions\.DxResult')  
A DxResult object containing the calculated DX values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
See the double array overload for a detailed description of the DX indicator\.