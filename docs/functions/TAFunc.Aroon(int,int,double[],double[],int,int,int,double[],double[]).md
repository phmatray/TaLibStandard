#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Aroon\(int, int, double\[\], double\[\], int, int, int, double\[\], double\[\]\) Method

Calculates the Aroon indicator \- identifies trend changes and measures trend strength\.

```csharp
public static TechnicalAnalysis.Common.RetCode Aroon(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outAroonDown, ref double[] outAroonUp);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Aroon(int,int,double[],double[],int,int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Aroon(int,int,double[],double[],int,int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Aroon(int,int,double[],double[],int,int,int,double[],double[]).inHigh'></a>

`inHigh` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Aroon(int,int,double[],double[],int,int,int,double[],double[]).inLow'></a>

`inLow` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Aroon(int,int,double[],double[],int,int,int,double[],double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the calculation\. Typical value: 25\.

<a name='TechnicalAnalysis.Functions.TAFunc.Aroon(int,int,double[],double[],int,int,int,double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Aroon(int,int,double[],double[],int,int,int,double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Aroon(int,int,double[],double[],int,int,int,double[],double[]).outAroonDown'></a>

`outAroonDown` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for Aroon Down values\.

<a name='TechnicalAnalysis.Functions.TAFunc.Aroon(int,int,double[],double[],int,int,int,double[],double[]).outAroonUp'></a>

`outAroonUp` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for Aroon Up values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Aroon measures the time since the most recent high/low within the lookback period\.

Calculation:
\- Aroon Up = \(\(Period \- Days Since Period High\) / Period\) \* 100
\- Aroon Down = \(\(Period \- Days Since Period Low\) / Period\) \* 100

Values range from 0 to 100:
\- Aroon Up near 100: Strong uptrend \(recent new highs\)
\- Aroon Down near 100: Strong downtrend \(recent new lows\)
\- Both near 50: No clear trend

Trading signals:
\- Aroon Up crosses above Aroon Down: Bullish signal
\- Aroon Down crosses above Aroon Up: Bearish signal
\- Either line above 70: Strong trend in that direction
\- Either line below 30: Weak trend in that direction