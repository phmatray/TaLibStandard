#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Obv\(int, int, double\[\], double\[\], int, int, double\[\]\) Method

Calculates the On Balance Volume \(OBV\) \- a momentum indicator that uses volume flow to predict price changes\.

```csharp
public static TechnicalAnalysis.Common.RetCode Obv(int startIdx, int endIdx, in double[] inReal, in double[] inVolume, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Obv(int,int,double[],double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Obv(int,int,double[],double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Obv(int,int,double[],double[],int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Obv(int,int,double[],double[],int,int,double[]).inVolume'></a>

`inVolume` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of volume data\.

<a name='TechnicalAnalysis.Functions.TAFunc.Obv(int,int,double[],double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Obv(int,int,double[],double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Obv(int,int,double[],double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the OBV values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
OBV is a cumulative indicator that adds volume on up days and subtracts volume on down days\.

Calculation:
\- If Close \> Previous Close: OBV = Previous OBV \+ Volume
\- If Close \< Previous Close: OBV = Previous OBV \- Volume
\- If Close = Previous Close: OBV = Previous OBV

Interpretation:
\- Rising OBV confirms an uptrend \(buying pressure\)
\- Falling OBV confirms a downtrend \(selling pressure\)
\- Divergence between OBV and price suggests potential reversal
\- OBV breakouts often precede price breakouts

The absolute value of OBV is not important; focus on the direction and divergences\.