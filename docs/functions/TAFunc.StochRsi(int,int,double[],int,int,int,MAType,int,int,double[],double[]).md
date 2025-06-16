#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.StochRsi\(int, int, double\[\], int, int, int, MAType, int, int, double\[\], double\[\]\) Method

Calculates the Stochastic RSI \- applies stochastic oscillator formula to RSI values\.

```csharp
public static TechnicalAnalysis.Common.RetCode StochRsi(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, in int optInFastKPeriod, in int optInFastDPeriod, in TechnicalAnalysis.Common.MAType optInFastDMAType, ref int outBegIdx, ref int outNBElement, ref double[] outFastK, ref double[] outFastD);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of prices \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for RSI calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInFastKPeriod'></a>

`optInFastKPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for Stochastic %K\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInFastDPeriod'></a>

`optInFastDPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for Stochastic %D smoothing\. Typical value: 3\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).optInFastDMAType'></a>

`optInFastDMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

Moving average type for %D line smoothing\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outFastK'></a>

`outFastK` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the Stochastic RSI %K values\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochRsi(int,int,double[],int,int,int,TechnicalAnalysis.Common.MAType,int,int,double[],double[]).outFastD'></a>

`outFastD` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the Stochastic RSI %D values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Stochastic RSI combines two popular indicators to create a more sensitive momentum oscillator\.
It measures where RSI is relative to its high/low range over a set period\.

Calculation:
1\. Calculate RSI for the specified period
2\. Apply Stochastic formula to RSI values:
   StochRSI = \(RSI \- Lowest RSI\) / \(Highest RSI \- Lowest RSI\) \* 100
3\. Smooth the result to get %K and %D lines

Values range from 0 to 100:
\- Above 80: Overbought condition
\- Below 20: Oversold condition
\- 50: Neutral level

Trading signals:
\- %K crossing above %D in oversold zone: Buy signal
\- %K crossing below %D in overbought zone: Sell signal
\- Divergences with price: Potential reversals
\- Centerline \(50\) crossovers: Trend changes

Advantages over standard RSI:
\- More sensitive to price changes
\- Generates more trading signals
\- Better for identifying short\-term turning points

Best used in conjunction with trend analysis to filter signals\.