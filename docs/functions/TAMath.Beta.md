#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Beta Method

| Overloads | |
| :--- | :--- |
| [Beta\(int, int, double\[\], double\[\]\)](TAMath.Beta.md#TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Beta\(int, int, double\[\], double\[\]\)') | Calculates the Beta coefficient between two price series using default parameters\. |
| [Beta\(int, int, double\[\], double\[\], int\)](TAMath.Beta.md#TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Beta\(int, int, double\[\], double\[\], int\)') | Calculates the Beta coefficient between two price series\. |
| [Beta\(int, int, float\[\], float\[\]\)](TAMath.Beta.md#TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Beta\(int, int, float\[\], float\[\]\)') | Calculates the Beta coefficient between two price series using float arrays with default parameters\. |
| [Beta\(int, int, float\[\], float\[\], int\)](TAMath.Beta.md#TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Beta\(int, int, float\[\], float\[\], int\)') | Calculates the Beta coefficient between two price series using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[])'></a>

## TAMath\.Beta\(int, int, double\[\], double\[\]\) Method

Calculates the Beta coefficient between two price series using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.BetaResult Beta(int startIdx, int endIdx, double[] real0, double[] real1);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[]).real0'></a>

`real0` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the first security \(typically the security being analyzed\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[]).real1'></a>

`real1` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the second security \(typically the market benchmark\)\.

#### Returns
[BetaResult](BetaResult.md 'TechnicalAnalysis\.Functions\.BetaResult')  
A [BetaResult](BetaResult.md 'TechnicalAnalysis\.Functions\.BetaResult') object containing the calculated beta values
and associated metadata\.

### Remarks
This overload uses a default time period of 5\. Beta measures the volatility or systematic risk
of a security compared to the market as a whole\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[],int)'></a>

## TAMath\.Beta\(int, int, double\[\], double\[\], int\) Method

Calculates the Beta coefficient between two price series\.

```csharp
public static TechnicalAnalysis.Functions.BetaResult Beta(int startIdx, int endIdx, double[] real0, double[] real1, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[],int).real0'></a>

`real0` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the first security \(typically the security being analyzed\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[],int).real1'></a>

`real1` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the second security \(typically the market benchmark\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation\.

#### Returns
[BetaResult](BetaResult.md 'TechnicalAnalysis\.Functions\.BetaResult')  
A [BetaResult](BetaResult.md 'TechnicalAnalysis\.Functions\.BetaResult') object containing the calculated beta values
and associated metadata\.

### Remarks
Beta measures the volatility or systematic risk of a security or portfolio compared to the market as a whole\.
It is calculated as the covariance between the returns of the security and the market divided by the variance
of the market returns\. A beta of 1 indicates the security moves with the market, greater than 1 indicates
higher volatility than the market, and less than 1 indicates lower volatility\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[])'></a>

## TAMath\.Beta\(int, int, float\[\], float\[\]\) Method

Calculates the Beta coefficient between two price series using float arrays with default parameters\.

```csharp
public static TechnicalAnalysis.Functions.BetaResult Beta(int startIdx, int endIdx, float[] real0, float[] real1);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[]).real0'></a>

`real0` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the first security \(typically the security being analyzed\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[]).real1'></a>

`real1` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the second security \(typically the market benchmark\)\.

#### Returns
[BetaResult](BetaResult.md 'TechnicalAnalysis\.Functions\.BetaResult')  
A [BetaResult](BetaResult.md 'TechnicalAnalysis\.Functions\.BetaResult') object containing the calculated beta values
and associated metadata\.

### Remarks
This overload accepts float arrays and uses a default time period of 5\. The arrays are converted
to double arrays before performing the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[],int)'></a>

## TAMath\.Beta\(int, int, float\[\], float\[\], int\) Method

Calculates the Beta coefficient between two price series using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.BetaResult Beta(int startIdx, int endIdx, float[] real0, float[] real1, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[],int).real0'></a>

`real0` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the first security \(typically the security being analyzed\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[],int).real1'></a>

`real1` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of prices for the second security \(typically the market benchmark\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Beta(int,int,float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation\.

#### Returns
[BetaResult](BetaResult.md 'TechnicalAnalysis\.Functions\.BetaResult')  
A [BetaResult](BetaResult.md 'TechnicalAnalysis\.Functions\.BetaResult') object containing the calculated beta values
and associated metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
Beta measures the volatility or systematic risk of a security compared to the market as a whole\.