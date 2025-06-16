#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MacdFix\(int, int, double\[\], int, int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Moving Average Convergence Divergence Fixed 12/26 \(MACDFIX\) \- a momentum indicator with fixed fast and slow periods\.

```csharp
public static TechnicalAnalysis.Common.RetCode MacdFix(int startIdx, int endIdx, in double[] inReal, in int optInSignalPeriod, ref int outBegIdx, ref int outNBElement, ref double[] outMACD, ref double[] outMACDSignal, ref double[] outMACDHist);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MacdFix(int,int,double[],int,int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdFix(int,int,double[],int,int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdFix(int,int,double[],int,int,int,double[],double[],double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdFix(int,int,double[],int,int,int,double[],double[],double[]).optInSignalPeriod'></a>

`optInSignalPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the signal line EMA\. Valid range: 1 to 100000\. Typical value: 9\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdFix(int,int,double[],int,int,int,double[],double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdFix(int,int,double[],int,int,int,double[],double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdFix(int,int,double[],int,int,int,double[],double[],double[]).outMACD'></a>

`outMACD` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the MACD line values \(12\-period EMA \- 26\-period EMA\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdFix(int,int,double[],int,int,int,double[],double[],double[]).outMACDSignal'></a>

`outMACDSignal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the signal line values \(EMA of MACD line\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdFix(int,int,double[],int,int,int,double[],double[],double[]).outMACDHist'></a>

`outMACDHist` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the MACD histogram values \(MACD line \- signal line\)\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
MACDFIX is a specialized version of MACD that uses fixed periods:
\- Fast EMA: Fixed at 12 periods
\- Slow EMA: Fixed at 26 periods
\- Signal Line: Customizable EMA of MACD line \(typically 9 periods\)

The three output components are:
\- MACD Line = 12\-period EMA \- 26\-period EMA
\- Signal Line = EMA of MACD Line \(period specified by optInSignalPeriod\)
\- MACD Histogram = MACD Line \- Signal Line

This function is ideal when you want to use the traditional MACD settings \(12, 26, 9\)
without having to specify the fast and slow periods each time\. Only the signal period
can be customized\.

Trading signals are the same as regular MACD:
\- Bullish: MACD line crosses above signal line
\- Bearish: MACD line crosses below signal line
\- Divergence: Price makes new high/low but MACD doesn't confirm
\- Zero line crossovers indicate trend changes