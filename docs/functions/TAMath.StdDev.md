#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.StdDev Method

| Overloads | |
| :--- | :--- |
| [StdDev\(int, int, double\[\], int, double\)](TAMath.StdDev.md#TechnicalAnalysis.Functions.TAMath.StdDev(int,int,double[],int,double) 'TechnicalAnalysis\.Functions\.TAMath\.StdDev\(int, int, double\[\], int, double\)') | Calculates the standard deviation of a price series\. |
| [StdDev\(int, int, float\[\], int, double\)](TAMath.StdDev.md#TechnicalAnalysis.Functions.TAMath.StdDev(int,int,float[],int,double) 'TechnicalAnalysis\.Functions\.TAMath\.StdDev\(int, int, float\[\], int, double\)') | Calculates the standard deviation of a price series using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,double[],int,double)'></a>

## TAMath\.StdDev\(int, int, double\[\], int, double\) Method

Calculates the standard deviation of a price series\.

```csharp
public static TechnicalAnalysis.Functions.StdDevResult StdDev(int startIdx, int endIdx, double[] real, int timePeriod=5, double nbDev=1.0);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,double[],int,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,double[],int,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,double[],int,double).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of price values\.

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,double[],int,double).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,double[],int,double).nbDev'></a>

`nbDev` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The number of standard deviations to scale the output by\.

#### Returns
[StdDevResult](StdDevResult.md 'TechnicalAnalysis\.Functions\.StdDevResult')  
A [StdDevResult](StdDevResult.md 'TechnicalAnalysis\.Functions\.StdDevResult') object containing the calculated standard deviation values
and associated metadata\.

### Remarks
Standard deviation is a statistical measure of the dispersion of values in a dataset\.
In financial markets, it is commonly used as a measure of volatility\. Higher standard
deviation indicates greater price volatility\. The nbDev parameter allows scaling the
output by a number of standard deviations \(e\.g\., for Bollinger Bands calculations\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,float[],int,double)'></a>

## TAMath\.StdDev\(int, int, float\[\], int, double\) Method

Calculates the standard deviation of a price series using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.StdDevResult StdDev(int startIdx, int endIdx, float[] real, int timePeriod=5, double nbDev=1.0);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,float[],int,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,float[],int,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,float[],int,double).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of price values\.

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,float[],int,double).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.StdDev(int,int,float[],int,double).nbDev'></a>

`nbDev` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The number of standard deviations to scale the output by \(default: 1\.0\)\.

#### Returns
[StdDevResult](StdDevResult.md 'TechnicalAnalysis\.Functions\.StdDevResult')  
A [StdDevResult](StdDevResult.md 'TechnicalAnalysis\.Functions\.StdDevResult') object containing the calculated standard deviation values
and associated metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
Standard deviation is a measure of volatility in financial markets\.