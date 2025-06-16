#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Apo\(int, int, double\[\], int, int, MAType, int, int, double\[\]\) Method

Calculates the Absolute Price Oscillator \(APO\) \- a momentum indicator that displays the difference between two moving averages\.

```csharp
public static TechnicalAnalysis.Common.RetCode Apo(int startIdx, int endIdx, in double[] inReal, in int optInFastPeriod, in int optInSlowPeriod, in TechnicalAnalysis.Common.MAType optInMAType, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).optInFastPeriod'></a>

`optInFastPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the fast moving average\. Typical value: 12\.

<a name='TechnicalAnalysis.Functions.TAFunc.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).optInSlowPeriod'></a>

`optInSlowPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the slow moving average\. Typical value: 26\.

<a name='TechnicalAnalysis.Functions.TAFunc.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).optInMAType'></a>

`optInMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use \(SMA, EMA, etc\.\)\. Default: EMA\.

<a name='TechnicalAnalysis.Functions.TAFunc.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the APO values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
APO measures the difference between two moving averages of different periods\.

Calculation:
APO = Fast Moving Average \- Slow Moving Average

Interpretation:
\- Positive APO: Fast MA is above Slow MA \(bullish momentum\)
\- Negative APO: Fast MA is below Slow MA \(bearish momentum\)
\- Zero line crossovers signal potential trend changes
\- Increasing APO indicates strengthening momentum
\- Decreasing APO indicates weakening momentum

Unlike the Percentage Price Oscillator \(PPO\), APO shows absolute price differences,
making it more suitable for comparing momentum in the same security over time\.