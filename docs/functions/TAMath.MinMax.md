#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MinMax Method

| Overloads | |
| :--- | :--- |
| [MinMax\(int, int, double\[\]\)](TAMath.MinMax.md#TechnicalAnalysis.Functions.TAMath.MinMax(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.MinMax\(int, int, double\[\]\)') | Calculates both the lowest and highest values over a specified time period \(MINMAX\) using default period\. |
| [MinMax\(int, int, double\[\], int\)](TAMath.MinMax.md#TechnicalAnalysis.Functions.TAMath.MinMax(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinMax\(int, int, double\[\], int\)') | Calculates both the lowest and highest values over a specified time period \(MINMAX\)\. |
| [MinMax\(int, int, float\[\]\)](TAMath.MinMax.md#TechnicalAnalysis.Functions.TAMath.MinMax(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.MinMax\(int, int, float\[\]\)') | Calculates both the lowest and highest values over a specified time period \(MINMAX\) using float arrays and default period\. |
| [MinMax\(int, int, float\[\], int\)](TAMath.MinMax.md#TechnicalAnalysis.Functions.TAMath.MinMax(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinMax\(int, int, float\[\], int\)') | Calculates both the lowest and highest values over a specified time period \(MINMAX\) using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,double[])'></a>

## TAMath\.MinMax\(int, int, double\[\]\) Method

Calculates both the lowest and highest values over a specified time period \(MINMAX\) using default period\.

```csharp
public static TechnicalAnalysis.Functions.MinMaxResult MinMax(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

#### Returns
[MinMaxResult](MinMaxResult.md 'TechnicalAnalysis\.Functions\.MinMaxResult')  
A MinMaxResult containing both the minimum and maximum values over each rolling window\.

### Remarks
This overload uses a default time period of 30\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,double[],int)'></a>

## TAMath\.MinMax\(int, int, double\[\], int\) Method

Calculates both the lowest and highest values over a specified time period \(MINMAX\)\.

```csharp
public static TechnicalAnalysis.Functions.MinMaxResult MinMax(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to look back for finding the minimum and maximum values\.

#### Returns
[MinMaxResult](MinMaxResult.md 'TechnicalAnalysis\.Functions\.MinMaxResult')  
A MinMaxResult containing both the minimum and maximum values over each rolling window\.

### Remarks
The MINMAX function efficiently calculates both the minimum and maximum values within a moving window
in a single pass\. This is useful for identifying price ranges and volatility over the specified period\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,float[])'></a>

## TAMath\.MinMax\(int, int, float\[\]\) Method

Calculates both the lowest and highest values over a specified time period \(MINMAX\) using float arrays and default period\.

```csharp
public static TechnicalAnalysis.Functions.MinMaxResult MinMax(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

#### Returns
[MinMaxResult](MinMaxResult.md 'TechnicalAnalysis\.Functions\.MinMaxResult')  
A MinMaxResult containing both the minimum and maximum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
Uses a default time period of 30\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,float[],int)'></a>

## TAMath\.MinMax\(int, int, float\[\], int\) Method

Calculates both the lowest and highest values over a specified time period \(MINMAX\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MinMaxResult MinMax(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMax(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to look back for finding the minimum and maximum values\.

#### Returns
[MinMaxResult](MinMaxResult.md 'TechnicalAnalysis\.Functions\.MinMaxResult')  
A MinMaxResult containing both the minimum and maximum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
The conversion may result in minor precision differences\.