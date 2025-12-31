#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Correl Method

| Overloads | |
| :--- | :--- |
| [Correl\(int, int, double\[\], double\[\], int\)](TAMath.Correl.md#TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Correl\(int, int, double\[\], double\[\], int\)') | Calculates the Pearson correlation coefficient between two price series\. |
| [Correl\(int, int, float\[\], float\[\], int\)](TAMath.Correl.md#TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Correl\(int, int, float\[\], float\[\], int\)') | Calculates the Pearson correlation coefficient between two price series using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int)'></a>

## TAMath\.Correl\(int, int, double\[\], double\[\], int\) Method

Calculates the Pearson correlation coefficient between two price series\.

```csharp
public static TechnicalAnalysis.Functions.CorrelResult Correl(int startIdx, int endIdx, double[] real0, double[] real1, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int).real0'></a>

`real0` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the first security\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int).real1'></a>

`real1` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the second security\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation\.

#### Returns
[CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult')  
A [CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult') object containing the calculated correlation coefficients
and associated metadata\.

### Remarks
The correlation coefficient measures the linear relationship between two variables\.
It ranges from \-1 to \+1, where \+1 indicates perfect positive correlation,
\-1 indicates perfect negative correlation, and 0 indicates no linear correlation\.
This is useful for determining how closely two securities move together\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int)'></a>

## TAMath\.Correl\(int, int, float\[\], float\[\], int\) Method

Calculates the Pearson correlation coefficient between two price series using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.CorrelResult Correl(int startIdx, int endIdx, float[] real0, float[] real1, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int).real0'></a>

`real0` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the first security\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int).real1'></a>

`real1` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the second security\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation\.

#### Returns
[CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult')  
A [CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult') object containing the calculated correlation coefficients
and associated metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
The correlation coefficient measures the linear relationship between two variables\.