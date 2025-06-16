#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.LinearReg\(int, int, double\[\], int, int, int, double\[\]\) Method

Calculates the Linear Regression \- the end point of a linear regression line over a specified period\.

```csharp
public static TechnicalAnalysis.Common.RetCode LinearReg(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.LinearReg(int,int,double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearReg(int,int,double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearReg(int,int,double[],int,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of prices \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearReg(int,int,double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the linear regression calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearReg(int,int,double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearReg(int,int,double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearReg(int,int,double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the linear regression values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Linear Regression calculates the projected value based on a least squares fit over the specified period\.
It represents where the price "should be" according to the linear trend\.

Mathematical basis:
\- Uses least squares method to find the best\-fitting straight line
\- Formula: y = mx \+ b \(where m is slope, b is intercept\)
\- Output is the y\-value at the end of the regression line

Key characteristics:
\- Smoother than moving averages
\- Less lag than traditional moving averages
\- Projects the current trend forward
\- Adapts to the overall direction of prices

Trading applications:
\- Trend identification: Price above/below regression line
\- Support/Resistance: Acts as dynamic support in uptrends, resistance in downtrends
\- Reversal signals: Price diverging significantly from regression line
\- Entry/Exit points: When price crosses the regression line

The Linear Regression indicator is the foundation for other indicators like
Linear Regression Slope, Linear Regression Angle, and Time Series Forecast\.