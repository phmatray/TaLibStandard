#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.LinearReg Method

| Overloads | |
| :--- | :--- |
| [LinearReg\(int, int, double\[\]\)](TAMath.LinearReg.md#TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.LinearReg\(int, int, double\[\]\)') | Calculates the Linear Regression \(LINEARREG\) indicator using the default time period\. |
| [LinearReg\(int, int, double\[\], int\)](TAMath.LinearReg.md#TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.LinearReg\(int, int, double\[\], int\)') | Calculates the Linear Regression \(LINEARREG\) indicator\. |
| [LinearReg\(int, int, float\[\]\)](TAMath.LinearReg.md#TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.LinearReg\(int, int, float\[\]\)') | Calculates the Linear Regression \(LINEARREG\) indicator using float arrays and the default time period\. |
| [LinearReg\(int, int, float\[\], int\)](TAMath.LinearReg.md#TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.LinearReg\(int, int, float\[\], int\)') | Calculates the Linear Regression \(LINEARREG\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,double[])'></a>

## TAMath\.LinearReg\(int, int, double\[\]\) Method

Calculates the Linear Regression \(LINEARREG\) indicator using the default time period\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegResult LinearReg(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\)\.

#### Returns
[LinearRegResult](LinearRegResult.md 'TechnicalAnalysis\.Functions\.LinearRegResult')  
A LinearRegResult object containing the calculated values\.

### Remarks
Uses the default time period of 14\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,double[],int)'></a>

## TAMath\.LinearReg\(int, int, double\[\], int\) Method

Calculates the Linear Regression \(LINEARREG\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegResult LinearReg(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the linear regression \(default: 14\)\.

#### Returns
[LinearRegResult](LinearRegResult.md 'TechnicalAnalysis\.Functions\.LinearRegResult')  
A LinearRegResult object containing the calculated values\.

### Remarks
Linear Regression uses the least squares method to fit a straight line through the price data
over the specified period\. The indicator returns the endpoint value of the linear regression line\.
This can be used to identify the underlying trend direction and strength\.
The indicator is similar to a moving average but with less lag, as it projects the current trend forward\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,float[])'></a>

## TAMath\.LinearReg\(int, int, float\[\]\) Method

Calculates the Linear Regression \(LINEARREG\) indicator using float arrays and the default time period\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegResult LinearReg(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\)\.

#### Returns
[LinearRegResult](LinearRegResult.md 'TechnicalAnalysis\.Functions\.LinearRegResult')  
A LinearRegResult object containing the calculated values\.

### Remarks
Uses the default time period of 14\. This overload accepts float arrays and converts them to double arrays\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,float[],int)'></a>

## TAMath\.LinearReg\(int, int, float\[\], int\) Method

Calculates the Linear Regression \(LINEARREG\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegResult LinearReg(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearReg(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the linear regression\.

#### Returns
[LinearRegResult](LinearRegResult.md 'TechnicalAnalysis\.Functions\.LinearRegResult')  
A LinearRegResult object containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
This may result in a minor performance overhead due to the conversion process\.