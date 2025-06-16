#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.AroonOsc\(int, int, double\[\], double\[\], int, int, int, double\[\]\) Method

Calculates the Aroon Oscillator \- a single line indicator that combines Aroon Up and Down\.

```csharp
public static TechnicalAnalysis.Common.RetCode AroonOsc(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.AroonOsc(int,int,double[],double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.AroonOsc(int,int,double[],double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.AroonOsc(int,int,double[],double[],int,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.AroonOsc(int,int,double[],double[],int,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.AroonOsc(int,int,double[],double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the calculation\. Typical value: 25\.

<a name='TechnicalAnalysis.Functions.TAFunc.AroonOsc(int,int,double[],double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.AroonOsc(int,int,double[],double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.AroonOsc(int,int,double[],double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the Aroon Oscillator values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The Aroon Oscillator simplifies the Aroon indicator into a single line\.

Calculation:
Aroon Oscillator = Aroon Up \- Aroon Down

Values range from \-100 to \+100:
\- Near \+100: Strong uptrend
\- Near \-100: Strong downtrend
\- Near 0: No clear trend or consolidation

Trading signals:
\- Cross above zero: Bullish signal \(uptrend beginning\)
\- Cross below zero: Bearish signal \(downtrend beginning\)
\- Above \+50: Strong bullish momentum
\- Below \-50: Strong bearish momentum

The oscillator format makes it easier to identify trend changes
and gauge trend strength with a single line\.