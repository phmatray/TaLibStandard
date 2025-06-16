#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Beta\(int, int, double\[\], double\[\], int, int, int, double\[\]\) Method

Calculates the Beta coefficient \- a measure of a security's volatility relative to a benchmark\.

```csharp
public static TechnicalAnalysis.Common.RetCode Beta(int startIdx, int endIdx, in double[] inReal0, in double[] inReal1, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Beta(int,int,double[],double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Beta(int,int,double[],double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Beta(int,int,double[],double[],int,int,int,double[]).inReal0'></a>

`inReal0` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of security prices \(the asset being analyzed\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Beta(int,int,double[],double[],int,int,int,double[]).inReal1'></a>

`inReal1` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of benchmark prices \(typically market index\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Beta(int,int,double[],double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the Beta calculation\. Typical value: 20\.

<a name='TechnicalAnalysis.Functions.TAFunc.Beta(int,int,double[],double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Beta(int,int,double[],double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Beta(int,int,double[],double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the Beta values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Beta measures the systematic risk of a security relative to the overall market\.
It's calculated using linear regression of security returns against market returns\.

Calculation:
Beta = Covariance\(Security Returns, Market Returns\) / Variance\(Market Returns\)

Interpretation:
\- Beta = 1\.0: Security moves with the market
\- Beta \> 1\.0: Security is more volatile than the market
\- Beta \< 1\.0: Security is less volatile than the market
\- Beta \< 0: Security moves opposite to the market

Uses:
\- Portfolio risk assessment
\- CAPM \(Capital Asset Pricing Model\) calculations
\- Hedging strategies
\- Performance attribution

Note: This implementation uses percentage returns for calculations\.