#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MaxIndex Method

| Overloads | |
| :--- | :--- |
| [MaxIndex\(int, int, double\[\], int\)](TAMath.MaxIndex.md#TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MaxIndex\(int, int, double\[\], int\)') | Calculates the index of the highest value over a specified time period \(MAXINDEX\)\. |
| [MaxIndex\(int, int, double\[\]\)](TAMath.MaxIndex.md#TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.MaxIndex\(int, int, double\[\]\)') | Calculates the index of the highest value over a specified time period \(MAXINDEX\) using default period\. |
| [MaxIndex\(int, int, float\[\], int\)](TAMath.MaxIndex.md#TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MaxIndex\(int, int, float\[\], int\)') | Calculates the index of the highest value over a specified time period \(MAXINDEX\) using float arrays\. |
| [MaxIndex\(int, int, float\[\]\)](TAMath.MaxIndex.md#TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.MaxIndex\(int, int, float\[\]\)') | Calculates the index of the highest value over a specified time period \(MAXINDEX\) using float arrays and default period\. |

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int)'></a>

## TAMath\.MaxIndex\(int, int, double\[\], int\) Method

Calculates the index of the highest value over a specified time period \(MAXINDEX\)\.

```csharp
public static TechnicalAnalysis.Functions.MaxIndexResult MaxIndex(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to look back for finding the maximum value\.

#### Returns
[MaxIndexResult](MaxIndexResult.md 'TechnicalAnalysis\.Functions\.MaxIndexResult')  
A MaxIndexResult containing the indices of maximum values over each rolling window\.

### Remarks
The MAXINDEX function returns the index \(position\) of the highest value within a moving window
of the specified time period\. This is useful for identifying exactly when maximum values occurred
in the data series\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[])'></a>

## TAMath\.MaxIndex\(int, int, double\[\]\) Method

Calculates the index of the highest value over a specified time period \(MAXINDEX\) using default period\.

```csharp
public static TechnicalAnalysis.Functions.MaxIndexResult MaxIndex(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

#### Returns
[MaxIndexResult](MaxIndexResult.md 'TechnicalAnalysis\.Functions\.MaxIndexResult')  
A MaxIndexResult containing the indices of maximum values over each rolling window\.

### Remarks
This overload uses a default time period of 30\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int)'></a>

## TAMath\.MaxIndex\(int, int, float\[\], int\) Method

Calculates the index of the highest value over a specified time period \(MAXINDEX\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MaxIndexResult MaxIndex(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to look back for finding the maximum value\.

#### Returns
[MaxIndexResult](MaxIndexResult.md 'TechnicalAnalysis\.Functions\.MaxIndexResult')  
A MaxIndexResult containing the indices of maximum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
The conversion may result in minor precision differences\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[])'></a>

## TAMath\.MaxIndex\(int, int, float\[\]\) Method

Calculates the index of the highest value over a specified time period \(MAXINDEX\) using float arrays and default period\.

```csharp
public static TechnicalAnalysis.Functions.MaxIndexResult MaxIndex(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

#### Returns
[MaxIndexResult](MaxIndexResult.md 'TechnicalAnalysis\.Functions\.MaxIndexResult')  
A MaxIndexResult containing the indices of maximum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
Uses a default time period of 30\.