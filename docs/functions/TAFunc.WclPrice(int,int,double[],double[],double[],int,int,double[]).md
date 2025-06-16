#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.WclPrice\(int, int, double\[\], double\[\], double\[\], int, int, double\[\]\) Method

Calculates the Weighted Close Price \- a price that emphasizes the closing price\.

```csharp
public static TechnicalAnalysis.Common.RetCode WclPrice(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double[] inClose, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.WclPrice(int,int,double[],double[],double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.WclPrice(int,int,double[],double[],double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.WclPrice(int,int,double[],double[],double[],int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.WclPrice(int,int,double[],double[],double[],int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.WclPrice(int,int,double[],double[],double[],int,int,double[]).inClose'></a>

`inClose` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.WclPrice(int,int,double[],double[],double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.WclPrice(int,int,double[],double[],double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.WclPrice(int,int,double[],double[],double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the weighted close price values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Weighted Close Price is calculated as:
WCL = \(High \+ Low \+ Close \+ Close\) / 4

This gives double weight to the closing price, making it more influential
than the high and low prices of the period\.

Common uses:
\- Alternative price input for technical indicators
\- Emphasizing closing price importance in analysis
\- Smoothing price action while maintaining close price significance
\- Trend identification with closing price emphasis

The weighted close is particularly useful when:
\- Closing price is considered most important \(e\.g\., daily charts\)
\- You want to reduce the impact of intraday volatility
\- Creating custom indicators that need close\-weighted input

Compare with:
\- Typical Price: \(H\+L\+C\)/3 \- equal weight
\- Average Price: \(O\+H\+L\+C\)/4 \- includes open
\- Median Price: \(H\+L\)/2 \- ignores close