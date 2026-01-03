#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MacdExt\(int, int, double\[\], int, MAType, int, MAType, int, MAType, int, int, double\[\], double\[\], double\[\]\) Method

Calculates the MACD Extended \- a flexible version of MACD allowing different moving average types\.

```csharp
public static TechnicalAnalysis.Common.RetCode MacdExt(int startIdx, int endIdx, in double[] inReal, int optInFastPeriod, TechnicalAnalysis.Common.MAType optInFastMAType, int optInSlowPeriod, TechnicalAnalysis.Common.MAType optInSlowMAType, in int optInSignalPeriod, in TechnicalAnalysis.Common.MAType optInSignalMAType, ref int outBegIdx, ref int outNBElement, ref double[] outMACD, ref double[] outMACDSignal, ref double[] outMACDHist);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).optInFastPeriod'></a>

`optInFastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the fast moving average\. Typical value: 12\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).optInFastMAType'></a>

`optInFastMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use for the fast MA \(SMA, EMA, WMA, etc\.\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).optInSlowPeriod'></a>

`optInSlowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the slow moving average\. Typical value: 26\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).optInSlowMAType'></a>

`optInSlowMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use for the slow MA \(SMA, EMA, WMA, etc\.\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).optInSignalPeriod'></a>

`optInSignalPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the signal line moving average\. Typical value: 9\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).optInSignalMAType'></a>

`optInSignalMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use for the signal line \(SMA, EMA, WMA, etc\.\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).outMACD'></a>

`outMACD` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the MACD line values \(fast MA \- slow MA\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).outMACDSignal'></a>

`outMACDSignal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the signal line values \(MA of MACD line\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).outMACDHist'></a>

`outMACDHist` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the MACD histogram values \(MACD line \- signal line\)\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
MACD Extended provides the same three components as standard MACD but with customizable moving average types:
\- MACD Line = Fast MA \- Slow MA
\- Signal Line = MA of MACD Line
\- MACD Histogram = MACD Line \- Signal Line

This extended version allows experimentation with different MA types \(SMA, WMA, DEMA, TEMA, etc\.\)
for potentially better responsiveness or smoothing characteristics\.

Common configurations:
\- Standard MACD: All MAs use EMA
\- Responsive MACD: Fast/Slow use DEMA, Signal uses EMA
\- Smooth MACD: Fast/Slow use EMA, Signal uses SMA

The function automatically swaps fast and slow periods if slow period is less than fast period\.