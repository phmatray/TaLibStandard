#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Variance Method

| Overloads | |
| :--- | :--- |
| [Variance\(int, int, double\[\], int, double\)](TAMath.Variance.md#TechnicalAnalysis.Functions.TAMath.Variance(int,int,double[],int,double) 'TechnicalAnalysis\.Functions\.TAMath\.Variance\(int, int, double\[\], int, double\)') | Calculates the variance of a price series\. |
| [Variance\(int, int, float\[\], int, double\)](TAMath.Variance.md#TechnicalAnalysis.Functions.TAMath.Variance(int,int,float[],int,double) 'TechnicalAnalysis\.Functions\.TAMath\.Variance\(int, int, float\[\], int, double\)') | Calculates the variance of a price series using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,double[],int,double)'></a>

## TAMath\.Variance\(int, int, double\[\], int, double\) Method

Calculates the variance of a price series\.

```csharp
public static TechnicalAnalysis.Functions.VarianceResult Variance(int startIdx, int endIdx, double[] real, int timePeriod=5, double nbDev=1.0);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,double[],int,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,double[],int,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,double[],int,double).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,double[],int,double).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,double[],int,double).nbDev'></a>

`nbDev` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The scaling factor for the output \(typically 1\.0\)\.

#### Returns
[VarianceResult](VarianceResult.md 'TechnicalAnalysis\.Functions\.VarianceResult')  
A [VarianceResult](VarianceResult.md 'TechnicalAnalysis\.Functions\.VarianceResult') object containing the calculated variance values
and associated metadata\.

### Remarks
Variance is a statistical measure that represents the average of the squared differences
from the mean\. It is the square of the standard deviation and measures the spread of a
dataset\. In financial analysis, variance is used to measure the volatility of returns\.
The nbDev parameter allows scaling the output, similar to its use in standard deviation\.

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,float[],int,double)'></a>

## TAMath\.Variance\(int, int, float\[\], int, double\) Method

Calculates the variance of a price series using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.VarianceResult Variance(int startIdx, int endIdx, float[] real, int timePeriod=5, double nbDev=1.0);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,float[],int,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,float[],int,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,float[],int,double).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,float[],int,double).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Variance(int,int,float[],int,double).nbDev'></a>

`nbDev` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The scaling factor for the output \(default: 1\.0\)\.

#### Returns
[VarianceResult](VarianceResult.md 'TechnicalAnalysis\.Functions\.VarianceResult')  
A [VarianceResult](VarianceResult.md 'TechnicalAnalysis\.Functions\.VarianceResult') object containing the calculated variance values
and associated metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
Variance measures the volatility of returns in financial analysis\.