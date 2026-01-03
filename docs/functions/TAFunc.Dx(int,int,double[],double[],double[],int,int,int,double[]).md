#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Dx\(int, int, double\[\], double\[\], double\[\], int, int, int, double\[\]\) Method

Calculates the Directional Movement Index \(DX\) \- measures the strength of directional movement without regard to direction\.

```csharp
public static TechnicalAnalysis.Common.RetCode Dx(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double[] inClose, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Dx(int,int,double[],double[],double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Dx(int,int,double[],double[],double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Dx(int,int,double[],double[],double[],int,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Dx(int,int,double[],double[],double[],int,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Dx(int,int,double[],double[],double[],int,int,int,double[]).inClose'></a>

`inClose` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Dx(int,int,double[],double[],double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the DX calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.Dx(int,int,double[],double[],double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Dx(int,int,double[],double[],double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Dx(int,int,double[],double[],double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the DX values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
DX is the foundation of the ADX \(Average Directional Index\) indicator\.
It measures the strength of directional movement, regardless of whether it's up or down\.

Calculation:
DX = 100 \* \|\+DI \- \-DI\| / \(\+DI \+ \-DI\)

Where:
\- \+DI = Positive Directional Indicator \(upward movement\)
\- \-DI = Negative Directional Indicator \(downward movement\)

Values range from 0 to 100:
\- 0\-25: Weak directional movement
\- 25\-50: Moderate directional movement
\- 50\-75: Strong directional movement
\- 75\-100: Very strong directional movement

Key differences from ADX:
\- DX is more volatile \(not smoothed\)
\- DX reacts faster to changes
\- ADX is the smoothed average of DX

Uses:
\- Identifying trending vs ranging markets
\- Timing entries when combined with \+DI/\-DI
\- Risk management \(avoid trades in low DX environments\)