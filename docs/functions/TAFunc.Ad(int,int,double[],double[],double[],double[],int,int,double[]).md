#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Ad\(int, int, double\[\], double\[\], double\[\], double\[\], int, int, double\[\]\) Method

Calculates the Chaikin Accumulation/Distribution Line \(A/D Line\) \- a volume\-based indicator that measures cumulative money flow\.

```csharp
public static TechnicalAnalysis.Common.RetCode Ad(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double[] inClose, in double[] inVolume, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Ad(int,int,double[],double[],double[],double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ad(int,int,double[],double[],double[],double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ad(int,int,double[],double[],double[],double[],int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ad(int,int,double[],double[],double[],double[],int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ad(int,int,double[],double[],double[],double[],int,int,double[]).inClose'></a>

`inClose` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ad(int,int,double[],double[],double[],double[],int,int,double[]).inVolume'></a>

`inVolume` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of volume data\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ad(int,int,double[],double[],double[],double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ad(int,int,double[],double[],double[],double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Ad(int,int,double[],double[],double[],double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the A/D Line values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The A/D Line combines price and volume to show how money is flowing into or out of a security\.

Calculation:
1\. Money Flow Multiplier = \[\(Close \- Low\) \- \(High \- Close\)\] / \(High \- Low\)
2\. Money Flow Volume = Money Flow Multiplier × Volume
3\. A/D Line = Previous A/D Line \+ Money Flow Volume

Interpretation:
\- Rising A/D Line: Buying pressure \(accumulation\)
\- Falling A/D Line: Selling pressure \(distribution\)
\- Divergence with price: Potential trend reversal
\- Confirms price trends when moving in same direction

The A/D Line is cumulative, so absolute values are less important than the direction and divergences\.