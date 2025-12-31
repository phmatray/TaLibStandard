#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.UltOsc\(int, int, double\[\], double\[\], double\[\], int, int, int, int, int, double\[\]\) Method

Calculates the Ultimate Oscillator \- a momentum oscillator that combines short, intermediate, and long\-term price movements\.

```csharp
public static TechnicalAnalysis.Common.RetCode UltOsc(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double[] inClose, int optInTimePeriod1, int optInTimePeriod2, int optInTimePeriod3, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.UltOsc(int,int,double[],double[],double[],int,int,int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOsc(int,int,double[],double[],double[],int,int,int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOsc(int,int,double[],double[],double[],int,int,int,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOsc(int,int,double[],double[],double[],int,int,int,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOsc(int,int,double[],double[],double[],int,int,int,int,int,double[]).inClose'></a>

`inClose` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOsc(int,int,double[],double[],double[],int,int,int,int,int,double[]).optInTimePeriod1'></a>

`optInTimePeriod1` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

First \(shortest\) time period\. Typical value: 7\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOsc(int,int,double[],double[],double[],int,int,int,int,int,double[]).optInTimePeriod2'></a>

`optInTimePeriod2` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Second \(intermediate\) time period\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOsc(int,int,double[],double[],double[],int,int,int,int,int,double[]).optInTimePeriod3'></a>

`optInTimePeriod3` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Third \(longest\) time period\. Typical value: 28\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOsc(int,int,double[],double[],double[],int,int,int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOsc(int,int,double[],double[],double[],int,int,int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.UltOsc(int,int,double[],double[],double[],int,int,int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the Ultimate Oscillator values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The Ultimate Oscillator was developed by Larry Williams to avoid the pitfalls
of single\-period oscillators by incorporating multiple timeframes\.

Calculation:
1\. Calculate Buying Pressure \(BP\) = Close \- True Low
2\. Calculate True Range \(TR\)
3\. Calculate averages for each period:
   \- Average7 = Sum\(BP,7\) / Sum\(TR,7\)
   \- Average14 = Sum\(BP,14\) / Sum\(TR,14\)
   \- Average28 = Sum\(BP,28\) / Sum\(TR,28\)
4\. UO = 100 \* \[\(4 \* Average7\) \+ \(2 \* Average14\) \+ Average28\] / 7

Values range from 0 to 100:
\- Above 70: Overbought condition
\- Below 30: Oversold condition
\- 50: Neutral level

Trading signals:
\- Bullish divergence \+ break above divergence high
\- Bearish divergence \+ break below divergence low
\- Overbought/oversold reversals with confirmation

Advantages:
\- Reduces false signals by using multiple timeframes
\- Less prone to whipsaws than single\-period oscillators
\- Weighted calculation emphasizes short\-term movements

Best used in conjunction with price action and trend analysis\.