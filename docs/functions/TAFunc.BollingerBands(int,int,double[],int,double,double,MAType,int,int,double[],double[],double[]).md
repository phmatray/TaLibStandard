#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.BollingerBands\(int, int, double\[\], int, double, double, MAType, int, int, double\[\], double\[\], double\[\]\) Method

Calculates Bollinger Bands \- a volatility indicator that creates upper and lower bands around a moving average\.

```csharp
public static TechnicalAnalysis.Common.RetCode BollingerBands(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, in double optInNbDevUp, in double optInNbDevDn, in TechnicalAnalysis.Common.MAType optInMAType, ref int outBegIdx, ref int outNBElement, ref double[] outRealUpperBand, ref double[] outRealMiddleBand, ref double[] outRealLowerBand);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the moving average calculation\. Typical value: 20\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).optInNbDevUp'></a>

`optInNbDevUp` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

Number of standard deviations for the upper band\. Typical value: 2\.0\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).optInNbDevDn'></a>

`optInNbDevDn` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

Number of standard deviations for the lower band\. Typical value: 2\.0\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).optInMAType'></a>

`optInMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use \(SMA, EMA, etc\.\)\. Default: SMA\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).outRealUpperBand'></a>

`outRealUpperBand` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the upper band values\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).outRealMiddleBand'></a>

`outRealMiddleBand` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the middle band \(moving average\) values\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBands(int,int,double[],int,double,double,TechnicalAnalysis.Common.MAType,int,int,double[],double[],double[]).outRealLowerBand'></a>

`outRealLowerBand` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the lower band values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Bollinger Bands consist of three lines:
\- Upper Band = Moving Average \+ \(Standard Deviation × Number of Deviations\)
\- Middle Band = Moving Average \(typically 20\-period SMA\)
\- Lower Band = Moving Average \- \(Standard Deviation × Number of Deviations\)

The bands expand during volatile periods and contract during consolidation\.
Price touching the upper band may indicate overbought conditions, while touching
the lower band may indicate oversold conditions\. However, prices can remain at
band extremes during strong trends\.