#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.LinearRegIntercept\(int, int, double\[\], int, int, int, double\[\]\) Method

Calculates the Linear Regression Intercept \- the y\-intercept value of a linear regression line over a specified period\.

```csharp
public static TechnicalAnalysis.Common.RetCode LinearRegIntercept(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegIntercept(int,int,double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegIntercept(int,int,double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegIntercept(int,int,double[],int,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of prices \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegIntercept(int,int,double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the linear regression calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegIntercept(int,int,double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegIntercept(int,int,double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegIntercept(int,int,double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the linear regression intercept values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Linear Regression Intercept calculates the y\-intercept \(b\) of the linear regression line,
which represents where the regression line would cross the y\-axis if extended backwards\.

Mathematical basis:
\- Uses least squares method to find the best\-fitting line: y = mx \+ b
\- Intercept \(b\) = \(Σy \- m×Σx\) / n
\- Where m is the slope and n is the number of periods
\- The intercept represents the theoretical price when x=0

Key characteristics:
\- Provides the baseline value of the linear regression equation
\- Changes as new data points are added and old ones are removed
\- Used in conjunction with slope to define the complete regression line
\- Can indicate the overall price level adjusted for trend

Trading applications:
\- Support/Resistance levels: Intercept can act as a dynamic support/resistance
\- Trend channels: Used with slope to construct regression channels
\- Mean reversion: Large deviations from intercept may signal overbought/oversold
\- Forecasting: Combined with slope for price projections
\- Relative value: Compare current price to intercept for over/undervaluation

The Linear Regression Intercept is often used together with Linear Regression Slope
to fully define the regression line equation for forecasting and analysis\.