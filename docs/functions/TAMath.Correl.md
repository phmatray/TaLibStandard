#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Correl Method

| Overloads | |
| :--- | :--- |
| [Correl\(int, int, double\[\], double\[\], int\)](TAMath.Correl.md#TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Correl\(int, int, double\[\], double\[\], int\)') | Calculates the Pearson correlation coefficient between two price series\. |
| [Correl\(int, int, double\[\], double\[\]\)](TAMath.Correl.md#TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Correl\(int, int, double\[\], double\[\]\)') | Calculates the Pearson correlation coefficient between two price series using default parameters\. |
| [Correl\(int, int, float\[\], float\[\], int\)](TAMath.Correl.md#TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Correl\(int, int, float\[\], float\[\], int\)') | Calculates the Pearson correlation coefficient between two price series using float arrays\. |
| [Correl\(int, int, float\[\], float\[\]\)](TAMath.Correl.md#TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Correl\(int, int, float\[\], float\[\]\)') | Calculates the Pearson correlation coefficient between two price series using float arrays with default parameters\. |

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int)'></a>

## TAMath\.Correl\(int, int, double\[\], double\[\], int\) Method

Calculates the Pearson correlation coefficient between two price series\.

```csharp
public static TechnicalAnalysis.Functions.CorrelResult Correl(int startIdx, int endIdx, double[] real0, double[] real1, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int).real0'></a>

`real0` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of prices for the first security\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int).real1'></a>

`real1` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of prices for the second security\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

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

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[])'></a>

## TAMath\.Correl\(int, int, double\[\], double\[\]\) Method

Calculates the Pearson correlation coefficient between two price series using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.CorrelResult Correl(int startIdx, int endIdx, double[] real0, double[] real1);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[]).real0'></a>

`real0` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of prices for the first security\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,double[],double[]).real1'></a>

`real1` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of prices for the second security\.

#### Returns
[CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult')  
A [CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult') object containing the calculated correlation coefficients
and associated metadata\.

### Remarks
This overload uses a default time period of 30\. The correlation coefficient measures
the linear relationship between two variables, ranging from \-1 to \+1\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int)'></a>

## TAMath\.Correl\(int, int, float\[\], float\[\], int\) Method

Calculates the Pearson correlation coefficient between two price series using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.CorrelResult Correl(int startIdx, int endIdx, float[] real0, float[] real1, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int).real0'></a>

`real0` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of prices for the first security\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int).real1'></a>

`real1` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of prices for the second security\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the calculation\.

#### Returns
[CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult')  
A [CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult') object containing the calculated correlation coefficients
and associated metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
The correlation coefficient measures the linear relationship between two variables\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[])'></a>

## TAMath\.Correl\(int, int, float\[\], float\[\]\) Method

Calculates the Pearson correlation coefficient between two price series using float arrays with default parameters\.

```csharp
public static TechnicalAnalysis.Functions.CorrelResult Correl(int startIdx, int endIdx, float[] real0, float[] real1);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[]).real0'></a>

`real0` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of prices for the first security\.

<a name='TechnicalAnalysis.Functions.TAMath.Correl(int,int,float[],float[]).real1'></a>

`real1` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of prices for the second security\.

#### Returns
[CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult')  
A [CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult') object containing the calculated correlation coefficients
and associated metadata\.

### Remarks
This overload accepts float arrays and uses a default time period of 30\. The arrays are converted
to double arrays before performing the calculation\.