#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MinusDI\(int, int, double\[\], double\[\], double\[\], int, int, int, double\[\]\) Method

Calculates the Minus Directional Indicator \(\-DI\) \- measures the strength of downward price movement\.

```csharp
public static TechnicalAnalysis.Common.RetCode MinusDI(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double[] inClose, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MinusDI(int,int,double[],double[],double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinusDI(int,int,double[],double[],double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinusDI(int,int,double[],double[],double[],int,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinusDI(int,int,double[],double[],double[],int,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinusDI(int,int,double[],double[],double[],int,int,int,double[]).inClose'></a>

`inClose` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinusDI(int,int,double[],double[],double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the \-DI calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinusDI(int,int,double[],double[],double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinusDI(int,int,double[],double[],double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinusDI(int,int,double[],double[],double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the \-DI values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
\-DI is part of the Directional Movement System developed by Welles Wilder\.
It quantifies the strength of downward price movements\.

Calculation:
1\. Minus Directional Movement \(\-DM\) = Previous Low \- Current Low \(if positive and greater than \+DM\)
2\. True Range \(TR\) = Max\(High\-Low, \|High\-Previous Close\|, \|Low\-Previous Close\|\)
3\. Smoothed \-DM and TR over the period
4\. \-DI = 100 \* Smoothed \-DM / Smoothed TR

Values range from 0 to 100:
\- Higher values indicate stronger downward movement
\- Values above 25 suggest a strong downtrend

Trading signals \(used with \+DI\):
\- \-DI crossing above \+DI: Bearish signal
\- \-DI above \+DI: Downtrend in progress
\- \+DI and \-DI diverging: Trend strengthening
\- \+DI and \-DI converging: Trend weakening

\-DI is commonly used with \+DI and ADX to form a complete trend analysis system\.