#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Macd\(int, int, double\[\], int, int, int, int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Moving Average Convergence Divergence \(MACD\) \- a trend\-following momentum indicator\.

```csharp
public static TechnicalAnalysis.Common.RetCode Macd(int startIdx, int endIdx, in double[] inReal, in int optInFastPeriod, in int optInSlowPeriod, in int optInSignalPeriod, ref int outBegIdx, ref int outNBElement, ref double[] outMACD, ref double[] outMACDSignal, ref double[] outMACDHist);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Macd(int,int,double[],int,int,int,int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Macd(int,int,double[],int,int,int,int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Macd(int,int,double[],int,int,int,int,int,double[],double[],double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Macd(int,int,double[],int,int,int,int,int,double[],double[],double[]).optInFastPeriod'></a>

`optInFastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the fast EMA\. Typical value: 12\.

<a name='TechnicalAnalysis.Functions.TAFunc.Macd(int,int,double[],int,int,int,int,int,double[],double[],double[]).optInSlowPeriod'></a>

`optInSlowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the slow EMA\. Typical value: 26\.

<a name='TechnicalAnalysis.Functions.TAFunc.Macd(int,int,double[],int,int,int,int,int,double[],double[],double[]).optInSignalPeriod'></a>

`optInSignalPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the signal line EMA\. Typical value: 9\.

<a name='TechnicalAnalysis.Functions.TAFunc.Macd(int,int,double[],int,int,int,int,int,double[],double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Macd(int,int,double[],int,int,int,int,int,double[],double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Macd(int,int,double[],int,int,int,int,int,double[],double[],double[]).outMACD'></a>

`outMACD` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the MACD line values \(fast EMA \- slow EMA\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Macd(int,int,double[],int,int,int,int,int,double[],double[],double[]).outMACDSignal'></a>

`outMACDSignal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the signal line values \(EMA of MACD line\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Macd(int,int,double[],int,int,int,int,int,double[],double[],double[]).outMACDHist'></a>

`outMACDHist` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the MACD histogram values \(MACD line \- signal line\)\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
MACD consists of three components:
\- MACD Line = Fast EMA \- Slow EMA \(typically 12\-day EMA \- 26\-day EMA\)
\- Signal Line = EMA of MACD Line \(typically 9\-day EMA\)
\- MACD Histogram = MACD Line \- Signal Line

Trading signals:
\- Bullish: MACD line crosses above signal line
\- Bearish: MACD line crosses below signal line
\- Divergence: Price makes new high/low but MACD doesn't confirm
\- Zero line crossovers also provide trend change signals