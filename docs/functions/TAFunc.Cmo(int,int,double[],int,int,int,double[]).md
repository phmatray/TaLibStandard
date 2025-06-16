#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Cmo\(int, int, double\[\], int, int, int, double\[\]\) Method

Calculates the Chande Momentum Oscillator \(CMO\) \- a momentum oscillator that measures the difference between gains and losses\.

```csharp
public static TechnicalAnalysis.Common.RetCode Cmo(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Cmo(int,int,double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Cmo(int,int,double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Cmo(int,int,double[],int,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of prices \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Cmo(int,int,double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the CMO calculation\. Typical value: 14\.

<a name='TechnicalAnalysis.Functions.TAFunc.Cmo(int,int,double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Cmo(int,int,double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Cmo(int,int,double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the CMO values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
CMO is a variation of RSI that provides a more responsive momentum reading\.

Calculation:
CMO = 100 \* \(Sum of Gains \- Sum of Losses\) / \(Sum of Gains \+ Sum of Losses\)

Values range from \-100 to \+100:
\- Values above \+50: Strong upward momentum
\- Values below \-50: Strong downward momentum
\- Values near 0: No clear momentum

Interpretation:
\- Overbought: CMO above \+50
\- Oversold: CMO below \-50
\- Trend confirmation: CMO moving in direction of price
\- Divergence: CMO moving opposite to price \(potential reversal\)

Advantages over RSI:
\- Symmetric scale \(\-100 to \+100\) vs RSI \(0 to 100\)
\- More responsive to price changes
\- Clearer identification of momentum extremes