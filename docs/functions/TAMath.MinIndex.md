#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MinIndex Method

| Overloads | |
| :--- | :--- |
| [MinIndex\(int, int, double\[\], int\)](TAMath.MinIndex.md#TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinIndex\(int, int, double\[\], int\)') | Calculates the index of the lowest value over a specified time period \(MININDEX\)\. |
| [MinIndex\(int, int, double\[\]\)](TAMath.MinIndex.md#TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.MinIndex\(int, int, double\[\]\)') | Calculates the index of the lowest value over a specified time period \(MININDEX\) using default period\. |
| [MinIndex\(int, int, float\[\], int\)](TAMath.MinIndex.md#TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinIndex\(int, int, float\[\], int\)') | Calculates the index of the lowest value over a specified time period \(MININDEX\) using float arrays\. |
| [MinIndex\(int, int, float\[\]\)](TAMath.MinIndex.md#TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.MinIndex\(int, int, float\[\]\)') | Calculates the index of the lowest value over a specified time period \(MININDEX\) using float arrays and default period\. |

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,double[],int)'></a>

## TAMath\.MinIndex\(int, int, double\[\], int\) Method

Calculates the index of the lowest value over a specified time period \(MININDEX\)\.

```csharp
public static TechnicalAnalysis.Functions.MinIndexResult MinIndex(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to look back for finding the minimum value\.

#### Returns
[MinIndexResult](MinIndexResult.md 'TechnicalAnalysis\.Functions\.MinIndexResult')  
A MinIndexResult containing the indices of minimum values over each rolling window\.

### Remarks
The MININDEX function returns the index \(position\) of the lowest value within a moving window
of the specified time period\. This is useful for identifying exactly when minimum values occurred
in the data series\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,double[])'></a>

## TAMath\.MinIndex\(int, int, double\[\]\) Method

Calculates the index of the lowest value over a specified time period \(MININDEX\) using default period\.

```csharp
public static TechnicalAnalysis.Functions.MinIndexResult MinIndex(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

#### Returns
[MinIndexResult](MinIndexResult.md 'TechnicalAnalysis\.Functions\.MinIndexResult')  
A MinIndexResult containing the indices of minimum values over each rolling window\.

### Remarks
This overload uses a default time period of 30\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,float[],int)'></a>

## TAMath\.MinIndex\(int, int, float\[\], int\) Method

Calculates the index of the lowest value over a specified time period \(MININDEX\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MinIndexResult MinIndex(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to look back for finding the minimum value\.

#### Returns
[MinIndexResult](MinIndexResult.md 'TechnicalAnalysis\.Functions\.MinIndexResult')  
A MinIndexResult containing the indices of minimum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
The conversion may result in minor precision differences\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,float[])'></a>

## TAMath\.MinIndex\(int, int, float\[\]\) Method

Calculates the index of the lowest value over a specified time period \(MININDEX\) using float arrays and default period\.

```csharp
public static TechnicalAnalysis.Functions.MinIndexResult MinIndex(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MinIndex(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

#### Returns
[MinIndexResult](MinIndexResult.md 'TechnicalAnalysis\.Functions\.MinIndexResult')  
A MinIndexResult containing the indices of minimum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
Uses a default time period of 30\.