#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Mama\(int, int, double\[\], double, double, int, int, double\[\], double\[\]\) Method

Calculates the MESA Adaptive Moving Average \(MAMA\) and Following Adaptive Moving Average \(FAMA\)\.

```csharp
public static TechnicalAnalysis.Common.RetCode Mama(int startIdx, int endIdx, in double[] inReal, in double optInFastLimit, in double optInSlowLimit, ref int outBegIdx, ref int outNBElement, ref double[] outMAMA, ref double[] outFAMA);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Mama(int,int,double[],double,double,int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mama(int,int,double[],double,double,int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mama(int,int,double[],double,double,int,int,double[],double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mama(int,int,double[],double,double,int,int,double[],double[]).optInFastLimit'></a>

`optInFastLimit` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Controls the maximum alpha for the fast\-moving average\. Range: 0\.01 to 0\.99\. Typical value: 0\.5\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mama(int,int,double[],double,double,int,int,double[],double[]).optInSlowLimit'></a>

`optInSlowLimit` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Controls the maximum alpha for the slow\-moving average\. Range: 0\.01 to 0\.99\. Typical value: 0\.05\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mama(int,int,double[],double,double,int,int,double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mama(int,int,double[],double,double,int,int,double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mama(int,int,double[],double,double,int,int,double[],double[]).outMAMA'></a>

`outMAMA` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the MESA Adaptive Moving Average values\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mama(int,int,double[],double,double,int,int,double[],double[]).outFAMA'></a>

`outFAMA` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the Following Adaptive Moving Average values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
MAMA is an adaptive moving average developed by John Ehlers that uses Hilbert Transform
techniques to measure the dominant cycle period in the price data\. The moving average
adapts its smoothing factor based on the measured phase rate of change\.

Key characteristics:
\- MAMA adapts quickly to price changes when the market is trending
\- It becomes more stable during cycling markets
\- FAMA is a smoothed version of MAMA that follows behind it
\- The difference between MAMA and FAMA can indicate trend strength

Trading signals:
\- Buy when MAMA crosses above FAMA
\- Sell when MAMA crosses below FAMA
\- The vertical distance between lines indicates trend strength
\- Convergence suggests potential trend change

The fast and slow limits control the adaptation range:
\- Fast limit: Maximum adaptation speed \(typical: 0\.5\)
\- Slow limit: Minimum adaptation speed \(typical: 0\.05\)