#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.HtTrendMode\(int, int, double\[\], int, int, int\[\]\) Method

Calculates the Hilbert Transform \- Trend vs Cycle Mode\.

```csharp
public static TechnicalAnalysis.Common.RetCode HtTrendMode(int startIdx, int endIdx, in double[] inReal, ref int outBegIdx, ref int outNBElement, ref int[] outInteger);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendMode(int,int,double[],int,int,int[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendMode(int,int,double[],int,int,int[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendMode(int,int,double[],int,int,int[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendMode(int,int,double[],int,int,int[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendMode(int,int,double[],int,int,int[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtTrendMode(int,int,double[],int,int,int[]).outInteger'></a>

`outInteger` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the trend mode values \(0 = cycle mode, 1 = trend mode\)\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The Hilbert Transform \- Trend vs Cycle Mode is a market state indicator developed by John Ehlers
that determines whether the market is in a trending or cycling mode\. This distinction is crucial
for selecting appropriate trading strategies and indicators\.

How it works:
1\. Uses the Hilbert Transform to decompose price into in\-phase and quadrature components
2\. Calculates the dominant cycle period and phase
3\. Computes a trendline using weighted average of recent prices
4\. Applies multiple criteria to determine market mode:
   \- Phase relationship between sine and lead sine
   \- Duration in current trend relative to cycle period
   \- Rate of phase change
   \- Price deviation from trendline

Output interpretation:
\- 0 = Cycle Mode: Market is moving sideways in a cyclical pattern
\- 1 = Trend Mode: Market is in a directional trend

Market mode characteristics:
\- Cycle Mode: Use oscillators, support/resistance, mean reversion strategies
\- Trend Mode: Use trend\-following indicators, breakout strategies, momentum trading

Decision criteria for trend mode:
\- Price deviates more than 1\.5% from the trendline
\- Current trend has persisted for at least half the dominant cycle period
\- Phase is advancing at a normal rate \(not too fast or too slow\)
\- Sine/lead sine crossover patterns indicate trend continuation

Common applications:
\- Adaptive trading systems that switch strategies based on market state
\- Filter for trend\-following vs mean\-reversion signals
\- Risk management \(different position sizing for trends vs cycles\)
\- Indicator parameter adaptation based on market conditions

Limitations:
\- Requires significant historical data \(minimum 63 bars plus unstable period\)
\- Subject to lag in detecting mode transitions
\- May produce frequent mode switches in choppy markets
\- Most effective when combined with other confirmation indicators