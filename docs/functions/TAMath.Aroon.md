#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Aroon Method

| Overloads | |
| :--- | :--- |
| [Aroon\(int, int, double\[\], double\[\]\)](TAMath.Aroon.md#TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Aroon\(int, int, double\[\], double\[\]\)') | Calculates the Aroon indicator with default period\. |
| [Aroon\(int, int, double\[\], double\[\], int\)](TAMath.Aroon.md#TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Aroon\(int, int, double\[\], double\[\], int\)') | Calculates the Aroon indicator \(Aroon Up and Aroon Down\)\. |
| [Aroon\(int, int, float\[\], float\[\]\)](TAMath.Aroon.md#TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Aroon\(int, int, float\[\], float\[\]\)') | Calculates the Aroon indicator using float arrays with default period\. |
| [Aroon\(int, int, float\[\], float\[\], int\)](TAMath.Aroon.md#TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Aroon\(int, int, float\[\], float\[\], int\)') | Calculates the Aroon indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[])'></a>

## TAMath\.Aroon\(int, int, double\[\], double\[\]\) Method

Calculates the Aroon indicator with default period\.

```csharp
public static TechnicalAnalysis.Functions.AroonResult Aroon(int startIdx, int endIdx, double[] high, double[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

#### Returns
[AroonResult](AroonResult.md 'TechnicalAnalysis\.Functions\.AroonResult')  
An AroonResult object containing both Aroon Down and Aroon Up values\.

### Remarks
This overload uses a default time period of 14\.
See the main overload for a detailed description of the Aroon indicator\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[],int)'></a>

## TAMath\.Aroon\(int, int, double\[\], double\[\], int\) Method

Calculates the Aroon indicator \(Aroon Up and Aroon Down\)\.

```csharp
public static TechnicalAnalysis.Functions.AroonResult Aroon(int startIdx, int endIdx, double[] high, double[] low, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[],int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[],int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The lookback period for the calculation \(default: 14\)\.

#### Returns
[AroonResult](AroonResult.md 'TechnicalAnalysis\.Functions\.AroonResult')  
An AroonResult object containing both Aroon Down and Aroon Up values\.

### Remarks
The Aroon indicator, developed by Tushar Chande in 1995, is used to identify trend changes and the 
strength of a trend\. It consists of two lines: Aroon Up and Aroon Down\.

Aroon Up = \(\(Period \- Days Since Period High\) / Period\) × 100
Aroon Down = \(\(Period \- Days Since Period Low\) / Period\) × 100

The indicator oscillates between 0 and 100:
\- Aroon Up near 100 indicates a strong upward trend
\- Aroon Down near 100 indicates a strong downward trend
\- Both lines near 50 indicate a consolidating market

Trading signals:
\- When Aroon Up crosses above Aroon Down, it may signal a new uptrend
\- When Aroon Down crosses above Aroon Up, it may signal a new downtrend
\- When both lines are below 50, it indicates a weak or absent trend

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[])'></a>

## TAMath\.Aroon\(int, int, float\[\], float\[\]\) Method

Calculates the Aroon indicator using float arrays with default period\.

```csharp
public static TechnicalAnalysis.Functions.AroonResult Aroon(int startIdx, int endIdx, float[] high, float[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[]).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[]).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

#### Returns
[AroonResult](AroonResult.md 'TechnicalAnalysis\.Functions\.AroonResult')  
An AroonResult object containing both Aroon Down and Aroon Up values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
Uses a default time period of 14\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[],int)'></a>

## TAMath\.Aroon\(int, int, float\[\], float\[\], int\) Method

Calculates the Aroon indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.AroonResult Aroon(int startIdx, int endIdx, float[] high, float[] low, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[],int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[],int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Aroon(int,int,float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The lookback period for the calculation\.

#### Returns
[AroonResult](AroonResult.md 'TechnicalAnalysis\.Functions\.AroonResult')  
An AroonResult object containing both Aroon Down and Aroon Up values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
See the double array overload for a detailed description of the Aroon indicator\.