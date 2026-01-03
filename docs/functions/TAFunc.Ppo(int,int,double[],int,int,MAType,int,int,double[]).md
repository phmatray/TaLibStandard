#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Ppo\(int, int, double\[\], int, int, MAType, int, int, double\[\]\) Method

Calculates the Percentage Price Oscillator \(PPO\) \- a momentum indicator showing the percentage difference between two moving averages\.

```csharp
public static TechnicalAnalysis.Common.RetCode Ppo(int startIdx, int endIdx, in double[] inReal, in int optInFastPeriod, in int optInSlowPeriod, in TechnicalAnalysis.Common.MAType optInMAType, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).optInFastPeriod'></a>

`optInFastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the fast moving average\. Typical value: 12\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).optInSlowPeriod'></a>

`optInSlowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the slow moving average\. Typical value: 26\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).optInMAType'></a>

`optInMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use \(SMA, EMA, etc\.\)\. Typical: EMA\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the PPO values \(as percentages\)\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
PPO is calculated as:
PPO = \(\(Fast MA \- Slow MA\) / Slow MA\) × 100

PPO is similar to MACD but expresses the difference as a percentage,
making it easier to compare values across different securities or time periods\.

Interpretation:
\- Positive values: Fast MA is above Slow MA \(bullish\)
\- Negative values: Fast MA is below Slow MA \(bearish\)
\- Zero line crossovers signal trend changes
\- Divergences with price can indicate potential reversals

PPO is preferred over MACD when comparing securities with different prices
or analyzing the same security over long time periods with significant price changes\.