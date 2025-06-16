#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.PlusDM\(int, int, double\[\], double\[\], int, int, int, double\[\]\) Method

Calculates the Plus Directional Movement \(\+DM\) \- measures upward price movement\.

```csharp
public static TechnicalAnalysis.Common.RetCode PlusDM(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.PlusDM(int,int,double[],double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.PlusDM(int,int,double[],double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.PlusDM(int,int,double[],double[],int,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.PlusDM(int,int,double[],double[],int,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.PlusDM(int,int,double[],double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the \+DM calculation\. Valid range: 1 to 100000\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.PlusDM(int,int,double[],double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.PlusDM(int,int,double[],double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.PlusDM(int,int,double[],double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the \+DM values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
\+DM is part of the Directional Movement System developed by Welles Wilder\.
It quantifies the magnitude of upward price movements\.

Calculation:
1\. Raw \+DM = Current High \- Previous High \(only if positive and greater than \-DM\)
2\. If optInTimePeriod = 1: Returns raw \+DM values
3\. If optInTimePeriod \> 1: Applies Wilder's smoothing:
   \- Initial: Sum of first 'period' \+DM values
   \- Subsequent: Smoothed \+DM = Previous Smoothed \+DM \- \(Previous Smoothed \+DM / period\) \+ Current \+DM

Key characteristics:
\- \+DM is 0 when there's no upward movement or when downward movement is stronger
\- Used to calculate \+DI \(Plus Directional Indicator\) when divided by Average True Range
\- Part of ADX calculation for trend strength measurement

The smoothed \+DM values help filter out noise and provide a clearer view of 
the upward directional movement trend\.