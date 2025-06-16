#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Max Method

| Overloads | |
| :--- | :--- |
| [Max\(int, int, double\[\], int\)](TAMath.Max.md#TechnicalAnalysis.Functions.TAMath.Max(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Max\(int, int, double\[\], int\)') | Calculates the highest value over a specified time period \(MAX\)\. |
| [Max\(int, int, double\[\]\)](TAMath.Max.md#TechnicalAnalysis.Functions.TAMath.Max(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Max\(int, int, double\[\]\)') | Calculates the highest value over a specified time period \(MAX\) using default period\. |
| [Max\(int, int, float\[\], int\)](TAMath.Max.md#TechnicalAnalysis.Functions.TAMath.Max(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Max\(int, int, float\[\], int\)') | Calculates the highest value over a specified time period \(MAX\) using float arrays\. |
| [Max\(int, int, float\[\]\)](TAMath.Max.md#TechnicalAnalysis.Functions.TAMath.Max(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Max\(int, int, float\[\]\)') | Calculates the highest value over a specified time period \(MAX\) using float arrays and default period\. |

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,double[],int)'></a>

## TAMath\.Max\(int, int, double\[\], int\) Method

Calculates the highest value over a specified time period \(MAX\)\.

```csharp
public static TechnicalAnalysis.Functions.MaxResult Max(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to look back for finding the maximum value\.

#### Returns
[MaxResult](MaxResult.md 'TechnicalAnalysis\.Functions\.MaxResult')  
A MaxResult containing the maximum values over each rolling window\.

### Remarks
The MAX function identifies the highest value within a moving window of the specified time period\.
This is useful for identifying resistance levels and tracking the upper boundaries of price movements\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,double[])'></a>

## TAMath\.Max\(int, int, double\[\]\) Method

Calculates the highest value over a specified time period \(MAX\) using default period\.

```csharp
public static TechnicalAnalysis.Functions.MaxResult Max(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

#### Returns
[MaxResult](MaxResult.md 'TechnicalAnalysis\.Functions\.MaxResult')  
A MaxResult containing the maximum values over each rolling window\.

### Remarks
This overload uses a default time period of 30\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,float[],int)'></a>

## TAMath\.Max\(int, int, float\[\], int\) Method

Calculates the highest value over a specified time period \(MAX\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MaxResult Max(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to look back for finding the maximum value\.

#### Returns
[MaxResult](MaxResult.md 'TechnicalAnalysis\.Functions\.MaxResult')  
A MaxResult containing the maximum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
The conversion may result in minor precision differences\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,float[])'></a>

## TAMath\.Max\(int, int, float\[\]\) Method

Calculates the highest value over a specified time period \(MAX\) using float arrays and default period\.

```csharp
public static TechnicalAnalysis.Functions.MaxResult Max(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Max(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

#### Returns
[MaxResult](MaxResult.md 'TechnicalAnalysis\.Functions\.MaxResult')  
A MaxResult containing the maximum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
Uses a default time period of 30\.