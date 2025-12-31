#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.LinearRegSlope Method

| Overloads | |
| :--- | :--- |
| [LinearRegSlope\(int, int, double\[\]\)](TAMath.LinearRegSlope.md#TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.LinearRegSlope\(int, int, double\[\]\)') | Calculates the Linear Regression Slope using default time period\. |
| [LinearRegSlope\(int, int, double\[\], int\)](TAMath.LinearRegSlope.md#TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.LinearRegSlope\(int, int, double\[\], int\)') | Calculates the Linear Regression Slope for the input price data\. |
| [LinearRegSlope\(int, int, float\[\]\)](TAMath.LinearRegSlope.md#TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.LinearRegSlope\(int, int, float\[\]\)') | Calculates the Linear Regression Slope using default time period\. |
| [LinearRegSlope\(int, int, float\[\], int\)](TAMath.LinearRegSlope.md#TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.LinearRegSlope\(int, int, float\[\], int\)') | Calculates the Linear Regression Slope for the input price data\. |

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,double[])'></a>

## TAMath\.LinearRegSlope\(int, int, double\[\]\) Method

Calculates the Linear Regression Slope using default time period\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

#### Returns
[LinearRegSlopeResult](LinearRegSlopeResult.md 'TechnicalAnalysis\.Functions\.LinearRegSlopeResult')  
A LinearRegSlopeResult containing the calculated slope values\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,double[],int)'></a>

## TAMath\.LinearRegSlope\(int, int, double\[\], int\) Method

Calculates the Linear Regression Slope for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[LinearRegSlopeResult](LinearRegSlopeResult.md 'TechnicalAnalysis\.Functions\.LinearRegSlopeResult')  
A LinearRegSlopeResult containing the calculated slope values\.

### Remarks
Linear Regression Slope calculates the slope of the linear regression line for the 
specified period\. The slope indicates the rate of change in the trend \- positive 
values indicate an upward trend, negative values indicate a downward trend, and 
the magnitude indicates the strength of the trend\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,float[])'></a>

## TAMath\.LinearRegSlope\(int, int, float\[\]\) Method

Calculates the Linear Regression Slope using default time period\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

#### Returns
[LinearRegSlopeResult](LinearRegSlopeResult.md 'TechnicalAnalysis\.Functions\.LinearRegSlopeResult')  
A LinearRegSlopeResult containing the calculated slope values\.

### Remarks
This overload accepts float input and converts it to double for calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,float[],int)'></a>

## TAMath\.LinearRegSlope\(int, int, float\[\], int\) Method

Calculates the Linear Regression Slope for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegSlope(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation\.

#### Returns
[LinearRegSlopeResult](LinearRegSlopeResult.md 'TechnicalAnalysis\.Functions\.LinearRegSlopeResult')  
A LinearRegSlopeResult containing the calculated slope values\.

### Remarks
This overload accepts float input and converts it to double for calculation\.