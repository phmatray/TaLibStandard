#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.HtTrendline\(int, int, double\[\], int, int, double\[\]\) Method

Calculates the Hilbert Transform \- Instantaneous Trendline indicator\.

```csharp
public static TechnicalAnalysis.Common.RetCode HtTrendline(int startIdx, int endIdx, in double[] inReal, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendline(int,int,double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendline(int,int,double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendline(int,int,double[],int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendline(int,int,double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendline(int,int,double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendline(int,int,double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the Instantaneous Trendline values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The Hilbert Transform \- Instantaneous Trendline was developed by John Ehlers as part of his
suite of digital signal processing indicators for financial markets\. It creates an adaptive
moving average that adjusts to the dominant market cycle\.

How it works:
\- Uses the Hilbert Transform to decompose price into in\-phase and quadrature components
\- Calculates the dominant cycle period from these components
\- Creates a moving average using the dominant cycle period as its length
\- Applies additional smoothing using a weighted moving average formula

Key features:
\- Automatically adapts to changing market cycles
\- Provides smoother results than fixed\-period moving averages
\- Minimizes lag while maintaining smoothness
\- Works best in cycling \(non\-trending\) markets

Interpretation:
\- Price above trendline: Upward bias in the current cycle
\- Price below trendline: Downward bias in the current cycle
\- Trendline slope indicates short\-term trend direction
\- Crossovers can signal cycle\-based entry/exit points

Common use cases:
\- Dynamic support and resistance levels
\- Trend identification that adapts to market conditions
\- Smoothing price data while preserving important turning points
\- Generating trading signals in conjunction with other indicators

Implementation details:
\- Uses Weighted Moving Average \(WMA\) for initial smoothing
\- Applies complex Hilbert Transform calculations for cycle detection
\- Final output is smoothed using the formula: \(4\*current \+ 3\*prev1 \+ 2\*prev2 \+ prev3\) / 10

Limitations:
\- Requires significant historical data \(lookback period of 63\+ bars\)
\- May lag during rapid trend changes
\- Less effective in strongly trending markets where cycles are less apparent
\- Can produce whipsaws during transition periods between trends and cycles