#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Variance\(int, int, double\[\], int, double, int, int, double\[\]\) Method

Calculates the Variance \- a measure of the dispersion of values around their mean\.

```csharp
public static TechnicalAnalysis.Common.RetCode Variance(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, in double optInNbDev, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Variance(int,int,double[],int,double,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Variance(int,int,double[],int,double,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Variance(int,int,double[],int,double,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Variance(int,int,double[],int,double,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the calculation\. Typical values: 20, 50\.

<a name='TechnicalAnalysis.Functions.TAFunc.Variance(int,int,double[],int,double,int,int,double[]).optInNbDev'></a>

`optInNbDev` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

Deviation multiplier \(must be greater than 0\)\. Typical value: 1\.0\.

<a name='TechnicalAnalysis.Functions.TAFunc.Variance(int,int,double[],int,double,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Variance(int,int,double[],int,double,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Variance(int,int,double[],int,double,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the variance values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Variance measures the average squared deviation from the mean\.
It's the square of the standard deviation\.

Formula: Variance = Σ\(x \- mean\)² / n

Uses in technical analysis:
\- Foundation for calculating standard deviation
\- Risk measurement \(higher variance = higher risk\)
\- Volatility analysis
\- Input for other statistical indicators

Variance is always non\-negative, with larger values indicating
greater dispersion of data points from the mean\.