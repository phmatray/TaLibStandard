#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.StochF\(int, int, double\[\], double\[\], double\[\], int, int, MAType, int, int, double\[\], double\[\]\) Method

Calculates the Fast Stochastic Oscillator \- a momentum indicator showing the location of the close relative to the high\-low range\.

```csharp
public static TechnicalAnalysis.Common.RetCode StochF(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double[] inClose, in int optInFastKPeriod, in int optInFastDPeriod, in TechnicalAnalysis.Common.MAType optInFastDMAType, ref int outBegIdx, ref int outNBElement, ref double[] outFastK, ref double[] outFastD);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).inHigh'></a>

`inHigh` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).inLow'></a>

`inLow` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).inClose'></a>

`inClose` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInFastKPeriod'></a>

`optInFastKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for Fast %K calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInFastDPeriod'></a>

`optInFastDPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for Fast %D calculation\. Typical value: 3\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInFastDMAType'></a>

`optInFastDMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Moving average type for Fast %D calculation\. Typical: SMA\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outFastK'></a>

`outFastK` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for Fast %K values \(raw stochastic\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochF(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outFastD'></a>

`outFastD` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for Fast %D values \(moving average of Fast %K\)\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The Fast Stochastic Oscillator calculation:
\- Fast %K = 100 × \(Close \- Lowest Low\) / \(Highest High \- Lowest Low\)
\- Fast %D = Moving Average of Fast %K

Key differences from Slow Stochastic:
\- Fast Stochastic uses raw %K values \(no smoothing\)
\- More responsive but generates more signals
\- Can be more prone to whipsaws

Interpretation:
\- Values range from 0 to 100
\- Above 80: Potentially overbought
\- Below 20: Potentially oversold
\- %K crossing above %D: Bullish signal
\- %K crossing below %D: Bearish signal

Trading strategies:
\- Overbought/Oversold: Look for reversals when extreme levels are reached
\- Crossovers: Trade when %K crosses %D in the direction of the trend
\- Divergences: Price making new highs/lows while oscillator doesn't

The Fast Stochastic is best used:
\- In trending markets with clear support/resistance levels
\- For short\-term trading due to its sensitivity
\- In combination with trend\-following indicators to filter signals