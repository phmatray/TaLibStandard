#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.TrueRange\(int, int, double\[\], double\[\], double\[\], int, int, double\[\]\) Method

Calculates the True Range \(TR\) \- a volatility measure that captures the full range of price movement\.

```csharp
public static TechnicalAnalysis.Common.RetCode TrueRange(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double[] inClose, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.TrueRange(int,int,double[],double[],double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.TrueRange(int,int,double[],double[],double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.TrueRange(int,int,double[],double[],double[],int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.TrueRange(int,int,double[],double[],double[],int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.TrueRange(int,int,double[],double[],double[],int,int,double[]).inClose'></a>

`inClose` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.TrueRange(int,int,double[],double[],double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.TrueRange(int,int,double[],double[],double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.TrueRange(int,int,double[],double[],double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the True Range values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
True Range is the greatest of:
\- Current High \- Current Low
\- \|Current High \- Previous Close\|
\- \|Current Low \- Previous Close\|

TR is used:
\- As the foundation for ATR \(Average True Range\)
\- To measure volatility including gaps
\- For position sizing and stop\-loss placement
\- As a component in other indicators like ADX

Unlike simple range \(High \- Low\), True Range accounts for gaps between periods,
providing a more complete picture of price volatility\.