#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Sar\(int, int, double\[\], double\[\], double, double, int, int, double\[\]\) Method

Calculates the Parabolic SAR \(Stop and Reverse\) \- a trend\-following indicator that provides entry/exit points\.

```csharp
public static TechnicalAnalysis.Common.RetCode Sar(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, double optInAcceleration, in double optInMaximum, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Sar(int,int,double[],double[],double,double,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sar(int,int,double[],double[],double,double,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sar(int,int,double[],double[],double,double,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sar(int,int,double[],double[],double,double,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sar(int,int,double[],double[],double,double,int,int,double[]).optInAcceleration'></a>

`optInAcceleration` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Acceleration factor increment\. Typical value: 0\.02\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sar(int,int,double[],double[],double,double,int,int,double[]).optInMaximum'></a>

`optInMaximum` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Maximum acceleration factor\. Typical value: 0\.20\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sar(int,int,double[],double[],double,double,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sar(int,int,double[],double[],double,double,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sar(int,int,double[],double[],double,double,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the SAR values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Parabolic SAR follows price movements and acts as a trailing stop\-loss system\.
The indicator appears as dots above or below the price chart\.

Key concepts:
\- SAR dots below price: Uptrend \(long position\)
\- SAR dots above price: Downtrend \(short position\)
\- Acceleration Factor \(AF\): Increases by acceleration increment when new highs/lows are made
\- Maximum AF: Caps the acceleration to prevent SAR from getting too close to price

Trading signals:
\- Price crosses above SAR: Buy signal \(SAR flips to below price\)
\- Price crosses below SAR: Sell signal \(SAR flips to above price\)
\- SAR acts as dynamic stop\-loss level

Strengths:
\- Excellent for trending markets
\- Clear entry/exit signals
\- Built\-in risk management

Weaknesses:
\- Generates whipsaws in ranging markets
\- Always in the market \(no neutral position\)
\- Late signals in fast\-moving markets

Best used in conjunction with trend indicators to filter trades\.