#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Mfi\(int, int, double\[\], double\[\], double\[\], double\[\], int, int, int, double\[\]\) Method

Calculates the Money Flow Index \(MFI\) \- a momentum indicator that uses price and volume to identify overbought/oversold conditions\.

```csharp
public static TechnicalAnalysis.Common.RetCode Mfi(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double[] inClose, in double[] inVolume, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Mfi(int,int,double[],double[],double[],double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mfi(int,int,double[],double[],double[],double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mfi(int,int,double[],double[],double[],double[],int,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mfi(int,int,double[],double[],double[],double[],int,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mfi(int,int,double[],double[],double[],double[],int,int,int,double[]).inClose'></a>

`inClose` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mfi(int,int,double[],double[],double[],double[],int,int,int,double[]).inVolume'></a>

`inVolume` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of volume data\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mfi(int,int,double[],double[],double[],double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the MFI calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mfi(int,int,double[],double[],double[],double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mfi(int,int,double[],double[],double[],double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Mfi(int,int,double[],double[],double[],double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the MFI values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
MFI is often called the volume\-weighted RSI\. It incorporates volume to show money flow in/out of a security\.

Calculation:
1\. Typical Price = \(High \+ Low \+ Close\) / 3
2\. Money Flow = Typical Price × Volume
3\. Positive Money Flow = Sum of Money Flow on up days
4\. Negative Money Flow = Sum of Money Flow on down days
5\. MFI = 100 \- \(100 / \(1 \+ Positive Money Flow / Negative Money Flow\)\)

Interpretation:
\- Range: 0 to 100
\- Above 80: Potentially overbought
\- Below 20: Potentially oversold
\- Divergences with price suggest potential reversals
\- Volume confirmation makes MFI more reliable than price\-only indicators