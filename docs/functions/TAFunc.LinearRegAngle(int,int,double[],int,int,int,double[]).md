#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.LinearRegAngle\(int, int, double\[\], int, int, int, double\[\]\) Method

Calculates the Linear Regression Angle \- the angle of a linear regression line over a specified period\.

```csharp
public static TechnicalAnalysis.Common.RetCode LinearRegAngle(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegAngle(int,int,double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegAngle(int,int,double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegAngle(int,int,double[],int,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of prices \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegAngle(int,int,double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the linear regression calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegAngle(int,int,double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegAngle(int,int,double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegAngle(int,int,double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the linear regression angle values in degrees\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Linear Regression Angle measures the angle of the linear regression line in degrees,
providing a visual representation of the trend's steepness and direction\.

Mathematical basis:
\- Calculates the slope \(m\) of the linear regression line using least squares method
\- Converts slope to angle: angle = arctan\(m\) × \(180/π\)
\- Output is in degrees: positive for uptrend, negative for downtrend
\- Range: typically between \-90 and \+90 degrees

Key characteristics:
\- Quantifies trend strength: steeper angles indicate stronger trends
\- Direction indicator: positive angles = uptrend, negative = downtrend
\- Normalized measure: angle representation is independent of price scale
\- More intuitive than slope values for visual interpretation

Trading applications:
\- Trend strength: Angles above 30° or below \-30° suggest strong trends
\- Trend changes: Angle crossing zero indicates potential trend reversal
\- Momentum: Increasing angle suggests accelerating trend
\- Divergence: Price making new highs/lows while angle decreases
\- Filter: Only take trades when angle exceeds threshold \(e\.g\., ±15°\)

Note: The angle depends on the scaling of time vs\. price\. While the relative
changes in angle are meaningful, the absolute angle values should be interpreted
within the context of the specific market and timeframe\.