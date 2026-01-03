#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.ZigZag\(int, int, double\[\], double\[\], double, int, int, double\[\]\) Method

Calculates the ZigZag indicator \- filters out price movements smaller than a specified threshold\.

```csharp
public static TechnicalAnalysis.Common.RetCode ZigZag(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double optInDeviation, ref int outBegIdx, ref int outNBElement, ref double[] outZigZag);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.ZigZag(int,int,double[],double[],double,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.ZigZag(int,int,double[],double[],double,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.ZigZag(int,int,double[],double[],double,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.ZigZag(int,int,double[],double[],double,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.ZigZag(int,int,double[],double[],double,int,int,double[]).optInDeviation'></a>

`optInDeviation` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Minimum percentage price movement required for a reversal \(0\.0 to 100\.0\)\. Typical value: 5\.0\.

<a name='TechnicalAnalysis.Functions.TAFunc.ZigZag(int,int,double[],double[],double,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.ZigZag(int,int,double[],double[],double,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.ZigZag(int,int,double[],double[],double,int,int,double[]).outZigZag'></a>

`outZigZag` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array containing the ZigZag values \(0\.0 for non\-pivot points\)\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The ZigZag indicator:
\- Identifies significant price reversals by filtering out minor price movements
\- Connects swing highs and swing lows with straight lines
\- A reversal is confirmed when price moves by at least the specified deviation percentage
\- Non\-pivot points in the output array are set to 0\.0
\- Only pivot points \(peaks and troughs\) contain actual price values

Interpretation:
\- Useful for identifying support/resistance levels and chart patterns
\- Helps visualize the overall price trend by removing noise
\- The deviation parameter controls sensitivity \(higher values = fewer reversals\)
\- Note: This is a lagging indicator that repaints past values
\- Should not be used alone for trading signals due to its retrospective nature