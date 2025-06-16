#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.AdOsc\(int, int, double\[\], double\[\], double\[\], double\[\], int, int, int, int, double\[\]\) Method

Calculates the Chaikin Accumulation/Distribution Oscillator \- a momentum indicator of the A/D Line\.

```csharp
public static TechnicalAnalysis.Common.RetCode AdOsc(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double[] inClose, in double[] inVolume, in int optInFastPeriod, in int optInSlowPeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.AdOsc(int,int,double[],double[],double[],double[],int,int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.AdOsc(int,int,double[],double[],double[],double[],int,int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.AdOsc(int,int,double[],double[],double[],double[],int,int,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.AdOsc(int,int,double[],double[],double[],double[],int,int,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.AdOsc(int,int,double[],double[],double[],double[],int,int,int,int,double[]).inClose'></a>

`inClose` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.AdOsc(int,int,double[],double[],double[],double[],int,int,int,int,double[]).inVolume'></a>

`inVolume` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of volume data\.

<a name='TechnicalAnalysis.Functions.TAFunc.AdOsc(int,int,double[],double[],double[],double[],int,int,int,int,double[]).optInFastPeriod'></a>

`optInFastPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the fast EMA\. Typical value: 3\.

<a name='TechnicalAnalysis.Functions.TAFunc.AdOsc(int,int,double[],double[],double[],double[],int,int,int,int,double[]).optInSlowPeriod'></a>

`optInSlowPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the slow EMA\. Typical value: 10\.

<a name='TechnicalAnalysis.Functions.TAFunc.AdOsc(int,int,double[],double[],double[],double[],int,int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.AdOsc(int,int,double[],double[],double[],double[],int,int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.AdOsc(int,int,double[],double[],double[],double[],int,int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the A/D Oscillator values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The A/D Oscillator is the difference between fast and slow EMAs of the A/D Line\.

Calculation:
1\. Calculate A/D Line \(cumulative\)
2\. Fast EMA of A/D Line \(typically 3\-period\)
3\. Slow EMA of A/D Line \(typically 10\-period\)
4\. A/D Oscillator = Fast EMA \- Slow EMA

Interpretation:
\- Positive values: Buying pressure \(bullish\)
\- Negative values: Selling pressure \(bearish\)
\- Zero line crossovers signal momentum changes
\- Divergences with price indicate potential reversals

The oscillator helps identify when money flow momentum is accelerating
or decelerating, often leading price movements\.