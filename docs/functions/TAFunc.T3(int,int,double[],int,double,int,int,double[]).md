#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.T3\(int, int, double\[\], int, double, int, int, double\[\]\) Method

Calculates the T3 Moving Average \(Triple Exponential Moving Average\) \- a smoother and less lagging moving average\.

```csharp
public static TechnicalAnalysis.Common.RetCode T3(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, in double optInVFactor, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.T3(int,int,double[],int,double,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.T3(int,int,double[],int,double,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.T3(int,int,double[],int,double,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.T3(int,int,double[],int,double,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the T3 calculation\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.T3(int,int,double[],int,double,int,int,double[]).optInVFactor'></a>

`optInVFactor` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Volume Factor controls the smoothing\. Valid range: 0\.0 to 1\.0\. Default: 0\.7\.

<a name='TechnicalAnalysis.Functions.TAFunc.T3(int,int,double[],int,double,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.T3(int,int,double[],int,double,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.T3(int,int,double[],int,double,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the T3 values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The T3 Moving Average is a sophisticated smoothing indicator developed by Tim Tillson\.
It uses multiple exponential moving averages and a volume factor to create a smooth line
that is responsive to market movements while filtering out market noise\.

Key characteristics:
\- Less lag than traditional moving averages
\- Smoother than EMA or DEMA
\- The volume factor \(V\-Factor\) controls the amount of smoothing:
  \- V\-Factor = 0: Equivalent to an EMA
  \- V\-Factor = 1: Maximum smoothing
  \- V\-Factor = 0\.7: Common default value

Common uses:
\- Trend identification with reduced false signals
\- Dynamic support and resistance levels
\- Entry/exit signals when price crosses the T3
\- Smoothing other indicators to reduce noise