#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.AvgPrice\(int, int, double\[\], double\[\], double\[\], double\[\], int, int, double\[\]\) Method

Calculates the Average Price \- the mean of open, high, low, and close prices\.

```csharp
public static TechnicalAnalysis.Common.RetCode AvgPrice(int startIdx, int endIdx, in double[] inOpen, in double[] inHigh, in double[] inLow, in double[] inClose, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.AvgPrice(int,int,double[],double[],double[],double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.AvgPrice(int,int,double[],double[],double[],double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.AvgPrice(int,int,double[],double[],double[],double[],int,int,double[]).inOpen'></a>

`inOpen` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of opening prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.AvgPrice(int,int,double[],double[],double[],double[],int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.AvgPrice(int,int,double[],double[],double[],double[],int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.AvgPrice(int,int,double[],double[],double[],double[],int,int,double[]).inClose'></a>

`inClose` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.AvgPrice(int,int,double[],double[],double[],double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.AvgPrice(int,int,double[],double[],double[],double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.AvgPrice(int,int,double[],double[],double[],double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the Average Price values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The Average Price provides a single value representation of price action for each period\.

Calculation:
Average Price = \(Open \+ High \+ Low \+ Close\) / 4

Uses:
\- Price smoothing: Reduces noise compared to using close price alone
\- Support/Resistance: Can act as dynamic support/resistance levels
\- Trend confirmation: Price above/below average price confirms trend direction
\- Input for other indicators: Used as input for moving averages or oscillators

The Average Price is also known as the "Typical Price" when calculated as \(High \+ Low \+ Close\) / 3,
but this implementation uses all four price points for a more comprehensive average\.