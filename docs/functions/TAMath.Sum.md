#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Sum Method

| Overloads | |
| :--- | :--- |
| [Sum\(int, int, double\[\]\)](TAMath.Sum.md#TechnicalAnalysis.Functions.TAMath.Sum(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Sum\(int, int, double\[\]\)') | Calculates the summation of values over a specified time period \(SUM\) using default period\. |
| [Sum\(int, int, double\[\], int\)](TAMath.Sum.md#TechnicalAnalysis.Functions.TAMath.Sum(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Sum\(int, int, double\[\], int\)') | Calculates the summation of values over a specified time period \(SUM\)\. |
| [Sum\(int, int, float\[\]\)](TAMath.Sum.md#TechnicalAnalysis.Functions.TAMath.Sum(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Sum\(int, int, float\[\]\)') | Calculates the summation of values over a specified time period \(SUM\) using float arrays and default period\. |
| [Sum\(int, int, float\[\], int\)](TAMath.Sum.md#TechnicalAnalysis.Functions.TAMath.Sum(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Sum\(int, int, float\[\], int\)') | Calculates the summation of values over a specified time period \(SUM\) using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,double[])'></a>

## TAMath\.Sum\(int, int, double\[\]\) Method

Calculates the summation of values over a specified time period \(SUM\) using default period\.

```csharp
public static TechnicalAnalysis.Functions.SumResult Sum(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

#### Returns
[SumResult](SumResult.md 'TechnicalAnalysis\.Functions\.SumResult')  
A SumResult containing the sum values over each rolling window\.

### Remarks
This overload uses a default time period of 30\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,double[],int)'></a>

## TAMath\.Sum\(int, int, double\[\], int\) Method

Calculates the summation of values over a specified time period \(SUM\)\.

```csharp
public static TechnicalAnalysis.Functions.SumResult Sum(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to sum\.

#### Returns
[SumResult](SumResult.md 'TechnicalAnalysis\.Functions\.SumResult')  
A SumResult containing the sum values over each rolling window\.

### Remarks
The SUM function calculates the total sum of values within a moving window of the specified time period\.
This is a fundamental calculation used in many other indicators and can help identify cumulative trends
or total volume/value over specific periods\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,float[])'></a>

## TAMath\.Sum\(int, int, float\[\]\) Method

Calculates the summation of values over a specified time period \(SUM\) using float arrays and default period\.

```csharp
public static TechnicalAnalysis.Functions.SumResult Sum(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

#### Returns
[SumResult](SumResult.md 'TechnicalAnalysis\.Functions\.SumResult')  
A SumResult containing the sum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
Uses a default time period of 30\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,float[],int)'></a>

## TAMath\.Sum\(int, int, float\[\], int\) Method

Calculates the summation of values over a specified time period \(SUM\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.SumResult Sum(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.Sum(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to sum\.

#### Returns
[SumResult](SumResult.md 'TechnicalAnalysis\.Functions\.SumResult')  
A SumResult containing the sum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
The conversion may result in minor precision differences\.