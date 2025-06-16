#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MidPoint Method

| Overloads | |
| :--- | :--- |
| [MidPoint\(int, int, double\[\], int\)](TAMath.MidPoint.md#TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MidPoint\(int, int, double\[\], int\)') | Calculates the midpoint value over a specified time period \(MIDPOINT\)\. |
| [MidPoint\(int, int, double\[\]\)](TAMath.MidPoint.md#TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.MidPoint\(int, int, double\[\]\)') | Calculates the midpoint value over a specified time period \(MIDPOINT\) using default period\. |
| [MidPoint\(int, int, float\[\], int\)](TAMath.MidPoint.md#TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MidPoint\(int, int, float\[\], int\)') | Calculates the midpoint value over a specified time period \(MIDPOINT\) using float arrays\. |
| [MidPoint\(int, int, float\[\]\)](TAMath.MidPoint.md#TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.MidPoint\(int, int, float\[\]\)') | Calculates the midpoint value over a specified time period \(MIDPOINT\) using float arrays and default period\. |

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int)'></a>

## TAMath\.MidPoint\(int, int, double\[\], int\) Method

Calculates the midpoint value over a specified time period \(MIDPOINT\)\.

```csharp
public static TechnicalAnalysis.Functions.MidPointResult MidPoint(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to look back for calculating the midpoint\.

#### Returns
[MidPointResult](MidPointResult.md 'TechnicalAnalysis\.Functions\.MidPointResult')  
A MidPointResult containing the midpoint values over each rolling window\.

### Remarks
The MIDPOINT function calculates the midpoint between the highest and lowest values within a moving window:
\(Highest Value \+ Lowest Value\) / 2\. This indicator is useful for identifying the center of the price range
and can be used as a simple trend\-following indicator\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[])'></a>

## TAMath\.MidPoint\(int, int, double\[\]\) Method

Calculates the midpoint value over a specified time period \(MIDPOINT\) using default period\.

```csharp
public static TechnicalAnalysis.Functions.MidPointResult MidPoint(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

#### Returns
[MidPointResult](MidPointResult.md 'TechnicalAnalysis\.Functions\.MidPointResult')  
A MidPointResult containing the midpoint values over each rolling window\.

### Remarks
This overload uses a default time period of 14\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int)'></a>

## TAMath\.MidPoint\(int, int, float\[\], int\) Method

Calculates the midpoint value over a specified time period \(MIDPOINT\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MidPointResult MidPoint(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to look back for calculating the midpoint\.

#### Returns
[MidPointResult](MidPointResult.md 'TechnicalAnalysis\.Functions\.MidPointResult')  
A MidPointResult containing the midpoint values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
The conversion may result in minor precision differences\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[])'></a>

## TAMath\.MidPoint\(int, int, float\[\]\) Method

Calculates the midpoint value over a specified time period \(MIDPOINT\) using float arrays and default period\.

```csharp
public static TechnicalAnalysis.Functions.MidPointResult MidPoint(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

#### Returns
[MidPointResult](MidPointResult.md 'TechnicalAnalysis\.Functions\.MidPointResult')  
A MidPointResult containing the midpoint values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
Uses a default time period of 14\.