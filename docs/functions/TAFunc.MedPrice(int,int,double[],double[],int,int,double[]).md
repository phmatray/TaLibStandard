#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MedPrice\(int, int, double\[\], double\[\], int, int, double\[\]\) Method

Calculates the Median Price \(HL/2\) \- the midpoint between the high and low prices\.

```csharp
public static TechnicalAnalysis.Common.RetCode MedPrice(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MedPrice(int,int,double[],double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.MedPrice(int,int,double[],double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.MedPrice(int,int,double[],double[],int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.MedPrice(int,int,double[],double[],int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.MedPrice(int,int,double[],double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.MedPrice(int,int,double[],double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.MedPrice(int,int,double[],double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the Median Price values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The Median Price is the simplest price transformation, representing the midpoint of the daily trading range\.

Calculation:
Median Price = \(High \+ Low\) / 2

Uses and characteristics:
\- Smooths out price action by focusing on the range midpoint
\- Less affected by opening and closing volatility
\- Often used as input for other indicators instead of close price
\- Represents the "fair value" within the day's range

Trading applications:
\- Alternative price input for moving averages and oscillators
\- Identifying the daily equilibrium price
\- Reducing noise in trend analysis
\- Support/resistance level identification

The Median Price is part of a family of price transformations including
Typical Price \(HLC/3\), Weighted Close \(HLCC/4\), and Average Price \(OHLC/4\)\.