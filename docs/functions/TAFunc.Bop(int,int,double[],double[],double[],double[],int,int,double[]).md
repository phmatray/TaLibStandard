#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Bop\(int, int, double\[\], double\[\], double\[\], double\[\], int, int, double\[\]\) Method

Calculates the Balance of Power \(BOP\) \- an indicator measuring the strength of buyers vs sellers\.

```csharp
public static TechnicalAnalysis.Common.RetCode Bop(int startIdx, int endIdx, in double[] inOpen, in double[] inHigh, in double[] inLow, in double[] inClose, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Bop(int,int,double[],double[],double[],double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Bop(int,int,double[],double[],double[],double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Bop(int,int,double[],double[],double[],double[],int,int,double[]).inOpen'></a>

`inOpen` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of opening prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Bop(int,int,double[],double[],double[],double[],int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Bop(int,int,double[],double[],double[],double[],int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Bop(int,int,double[],double[],double[],double[],int,int,double[]).inClose'></a>

`inClose` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.Bop(int,int,double[],double[],double[],double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Bop(int,int,double[],double[],double[],double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Bop(int,int,double[],double[],double[],double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the BOP values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Balance of Power measures the ability of buyers and sellers to push prices to extreme levels\.

Calculation:
BOP = \(Close \- Open\) / \(High \- Low\)

Values range from \-1 to \+1:
\- Values near \+1: Strong buying pressure \(bulls in control\)
\- Values near \-1: Strong selling pressure \(bears in control\)
\- Values near 0: Balance between buyers and sellers

Trading signals:
\- Positive BOP: Buyers are winning the battle
\- Negative BOP: Sellers are winning the battle
\- BOP crossing zero: Potential trend change
\- Divergence with price: Potential reversal signal

Note: When High equals Low \(no range\), BOP is set to 0 to avoid division by zero\.