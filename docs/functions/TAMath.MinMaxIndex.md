#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MinMaxIndex Method

| Overloads | |
| :--- | :--- |
| [MinMaxIndex\(int, int, double\[\]\)](TAMath.MinMaxIndex.md#TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.MinMaxIndex\(int, int, double\[\]\)') | Calculates the indices of both the lowest and highest values over a specified time period \(MINMAXINDEX\) using default period\. |
| [MinMaxIndex\(int, int, double\[\], int\)](TAMath.MinMaxIndex.md#TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinMaxIndex\(int, int, double\[\], int\)') | Calculates the indices of both the lowest and highest values over a specified time period \(MINMAXINDEX\)\. |
| [MinMaxIndex\(int, int, float\[\]\)](TAMath.MinMaxIndex.md#TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.MinMaxIndex\(int, int, float\[\]\)') | Calculates the indices of both the lowest and highest values over a specified time period \(MINMAXINDEX\) using float arrays and default period\. |
| [MinMaxIndex\(int, int, float\[\], int\)](TAMath.MinMaxIndex.md#TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinMaxIndex\(int, int, float\[\], int\)') | Calculates the indices of both the lowest and highest values over a specified time period \(MINMAXINDEX\) using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,double[])'></a>

## TAMath\.MinMaxIndex\(int, int, double\[\]\) Method

Calculates the indices of both the lowest and highest values over a specified time period \(MINMAXINDEX\) using default period\.

```csharp
public static TechnicalAnalysis.Functions.MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

#### Returns
[MinMaxIndexResult](MinMaxIndexResult.md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult')  
A MinMaxIndexResult containing the indices of both minimum and maximum values over each rolling window\.

### Remarks
This overload uses a default time period of 30\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,double[],int)'></a>

## TAMath\.MinMaxIndex\(int, int, double\[\], int\) Method

Calculates the indices of both the lowest and highest values over a specified time period \(MINMAXINDEX\)\.

```csharp
public static TechnicalAnalysis.Functions.MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to look back for finding the minimum and maximum values\.

#### Returns
[MinMaxIndexResult](MinMaxIndexResult.md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult')  
A MinMaxIndexResult containing the indices of both minimum and maximum values over each rolling window\.

### Remarks
The MINMAXINDEX function returns the indices \(positions\) of both the lowest and highest values within
a moving window in a single pass\. This is useful for identifying exactly when extreme values occurred
in the data series\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,float[])'></a>

## TAMath\.MinMaxIndex\(int, int, float\[\]\) Method

Calculates the indices of both the lowest and highest values over a specified time period \(MINMAXINDEX\) using float arrays and default period\.

```csharp
public static TechnicalAnalysis.Functions.MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

#### Returns
[MinMaxIndexResult](MinMaxIndexResult.md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult')  
A MinMaxIndexResult containing the indices of both minimum and maximum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
Uses a default time period of 30\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,float[],int)'></a>

## TAMath\.MinMaxIndex\(int, int, float\[\], int\) Method

Calculates the indices of both the lowest and highest values over a specified time period \(MINMAXINDEX\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MinMaxIndex(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to look back for finding the minimum and maximum values\.

#### Returns
[MinMaxIndexResult](MinMaxIndexResult.md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult')  
A MinMaxIndexResult containing the indices of both minimum and maximum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
The conversion may result in minor precision differences\.