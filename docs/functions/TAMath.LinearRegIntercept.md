#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.LinearRegIntercept Method

| Overloads | |
| :--- | :--- |
| [LinearRegIntercept\(int, int, double\[\], int\)](TAMath.LinearRegIntercept.md#TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.LinearRegIntercept\(int, int, double\[\], int\)') | Calculates the Linear Regression Intercept for the input price data\. |
| [LinearRegIntercept\(int, int, double\[\]\)](TAMath.LinearRegIntercept.md#TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.LinearRegIntercept\(int, int, double\[\]\)') | Calculates the Linear Regression Intercept using default time period\. |
| [LinearRegIntercept\(int, int, float\[\], int\)](TAMath.LinearRegIntercept.md#TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.LinearRegIntercept\(int, int, float\[\], int\)') | Calculates the Linear Regression Intercept for the input price data\. |
| [LinearRegIntercept\(int, int, float\[\]\)](TAMath.LinearRegIntercept.md#TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.LinearRegIntercept\(int, int, float\[\]\)') | Calculates the Linear Regression Intercept using default time period\. |

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,double[],int)'></a>

## TAMath\.LinearRegIntercept\(int, int, double\[\], int\) Method

Calculates the Linear Regression Intercept for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegInterceptResult LinearRegIntercept(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input price data\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[LinearRegInterceptResult](LinearRegInterceptResult.md 'TechnicalAnalysis\.Functions\.LinearRegInterceptResult')  
A LinearRegInterceptResult containing the calculated intercept values\.

### Remarks
Linear Regression Intercept calculates the y\-intercept of the linear regression line 
for the specified period\. This represents where the regression line would intersect 
the y\-axis if extended\. It's useful for identifying the baseline value of the trend\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,double[])'></a>

## TAMath\.LinearRegIntercept\(int, int, double\[\]\) Method

Calculates the Linear Regression Intercept using default time period\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegInterceptResult LinearRegIntercept(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input price data\.

#### Returns
[LinearRegInterceptResult](LinearRegInterceptResult.md 'TechnicalAnalysis\.Functions\.LinearRegInterceptResult')  
A LinearRegInterceptResult containing the calculated intercept values\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,float[],int)'></a>

## TAMath\.LinearRegIntercept\(int, int, float\[\], int\) Method

Calculates the Linear Regression Intercept for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegInterceptResult LinearRegIntercept(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input price data\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the calculation\.

#### Returns
[LinearRegInterceptResult](LinearRegInterceptResult.md 'TechnicalAnalysis\.Functions\.LinearRegInterceptResult')  
A LinearRegInterceptResult containing the calculated intercept values\.

### Remarks
This overload accepts float input and converts it to double for calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,float[])'></a>

## TAMath\.LinearRegIntercept\(int, int, float\[\]\) Method

Calculates the Linear Regression Intercept using default time period\.

```csharp
public static TechnicalAnalysis.Functions.LinearRegInterceptResult LinearRegIntercept(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.LinearRegIntercept(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input price data\.

#### Returns
[LinearRegInterceptResult](LinearRegInterceptResult.md 'TechnicalAnalysis\.Functions\.LinearRegInterceptResult')  
A LinearRegInterceptResult containing the calculated intercept values\.

### Remarks
This overload accepts float input and converts it to double for calculation\.