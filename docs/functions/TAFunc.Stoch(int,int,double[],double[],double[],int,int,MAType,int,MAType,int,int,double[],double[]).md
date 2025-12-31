#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Stoch\(int, int, double\[\], double\[\], double\[\], int, int, MAType, int, MAType, int, int, double\[\], double\[\]\) Method

Calculates the Stochastic Oscillator \- a momentum indicator comparing closing price to price range\.

```csharp
public static TechnicalAnalysis.Common.RetCode Stoch(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double[] inClose, in int optInFastKPeriod, in int optInSlowKPeriod, in TechnicalAnalysis.Common.MAType optInSlowKMAType, in int optInSlowDPeriod, in TechnicalAnalysis.Common.MAType optInSlowDMAType, ref int outBegIdx, ref int outNBElement, ref double[] outSlowK, ref double[] outSlowD);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).inHigh'></a>

`inHigh` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).inLow'></a>

`inLow` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).inClose'></a>

`inClose` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInFastKPeriod'></a>

`optInFastKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for %K calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInSlowKPeriod'></a>

`optInSlowKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Smoothing periods for %K \(to create Slow %K\)\. Typical value: 3\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInSlowKMAType'></a>

`optInSlowKMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Moving average type for Slow %K smoothing\. Typical: SMA\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInSlowDPeriod'></a>

`optInSlowDPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for %D calculation\. Typical value: 3\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInSlowDMAType'></a>

`optInSlowDMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Moving average type for %D calculation\. Typical: SMA\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outSlowK'></a>

`outSlowK` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for Slow %K values \(smoothed %K\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Stoch(int,int,double[],double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outSlowD'></a>

`outSlowD` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for Slow %D values \(moving average of Slow %K\)\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The Stochastic Oscillator calculation:
\- Fast %K = 100 × \(Close \- Lowest Low\) / \(Highest High \- Lowest Low\)
\- Slow %K = Moving Average of Fast %K
\- Slow %D = Moving Average of Slow %K

Interpretation:
\- Values range from 0 to 100
\- Above 80: Potentially overbought
\- Below 20: Potentially oversold
\- %K crossing above %D: Bullish signal
\- %K crossing below %D: Bearish signal
\- Divergences between price and oscillator indicate potential reversals