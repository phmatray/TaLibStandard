#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.LinearRegSlope\(int, int, double\[\], int, int, int, double\[\]\) Method

Calculates the Linear Regression Slope \- the slope of a linear regression line over a specified period\.

```csharp
public static TechnicalAnalysis.Common.RetCode LinearRegSlope(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegSlope(int,int,double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegSlope(int,int,double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegSlope(int,int,double[],int,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of prices \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegSlope(int,int,double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the linear regression slope calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegSlope(int,int,double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegSlope(int,int,double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegSlope(int,int,double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the linear regression slope values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Linear Regression Slope measures the slope of the linear regression line, indicating the rate of change
in the trend\. It quantifies how much the regression line rises or falls per unit of time\.

Mathematical basis:
\- Uses least squares method to calculate the slope \(m\) in y = mx \+ b
\- Slope formula: m = \(n\*Σ\(xy\) \- Σx\*Σy\) / \(n\*Σ\(x²\) \- \(Σx\)²\)
\- Positive values indicate upward trend, negative values indicate downward trend
\- The magnitude indicates the strength of the trend

Key characteristics:
\- Zero\-centered oscillator \(can be positive or negative\)
\- Leading indicator that can signal trend changes early
\- More responsive than moving average based indicators
\- Smooths price action while maintaining sensitivity to changes

Trading applications:
\- Trend strength: Larger absolute values indicate stronger trends
\- Trend direction: Positive for uptrends, negative for downtrends
\- Divergence analysis: Price making new highs/lows while slope decreases
\- Momentum shifts: Slope crossing zero line signals potential trend reversal
\- Overbought/Oversold: Extreme slope values may indicate exhaustion

The Linear Regression Slope is often used with Linear Regression and Linear Regression Intercept
to form a complete picture of the trend's characteristics\. It can also be normalized or converted
to angles for additional analytical perspectives\.