#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Adxr\(int, int, double\[\], double\[\], double\[\], int, int, int, double\[\]\) Method

Calculates the Average Directional Movement Index Rating \(ADXR\) \- a smoothed version of ADX\.

```csharp
public static TechnicalAnalysis.Common.RetCode Adxr(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double[] inClose, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Adxr(int,int,double[],double[],double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Adxr(int,int,double[],double[],double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Adxr(int,int,double[],double[],double[],int,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Adxr(int,int,double[],double[],double[],int,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Adxr(int,int,double[],double[],double[],int,int,int,double[]).inClose'></a>

`inClose` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Adxr(int,int,double[],double[],double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the ADX calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.Adxr(int,int,double[],double[],double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Adxr(int,int,double[],double[],double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Adxr(int,int,double[],double[],double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the ADXR values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
ADXR is a smoothed version of the ADX indicator, providing a more stable trend strength reading\.

Calculation:
ADXR = \(ADX today \+ ADX n periods ago\) / 2

Where n is the same period used for ADX calculation \(typically 14\)\.

Interpretation \(same as ADX but smoother\):
\- Values above 25: Strong trend
\- Values below 20: Weak trend or ranging market
\- Rising ADXR: Trend strengthening
\- Falling ADXR: Trend weakening

ADXR lags more than ADX but provides fewer false signals due to its smoothing\.
It's particularly useful for confirming trend strength in longer\-term trading strategies\.