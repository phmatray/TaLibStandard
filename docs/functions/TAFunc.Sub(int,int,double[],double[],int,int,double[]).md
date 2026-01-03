#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Sub\(int, int, double\[\], double\[\], int, int, double\[\]\) Method

Performs vector subtraction of two input arrays\.

```csharp
public static TechnicalAnalysis.Common.RetCode Sub(int startIdx, int endIdx, in double[] inReal0, in double[] inReal1, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Sub(int,int,double[],double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sub(int,int,double[],double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sub(int,int,double[],double[],int,int,double[]).inReal0'></a>

`inReal0` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

First input array \(minuend\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sub(int,int,double[],double[],int,int,double[]).inReal1'></a>

`inReal1` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Second input array \(subtrahend\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sub(int,int,double[],double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sub(int,int,double[],double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Sub(int,int,double[],double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array containing the difference of corresponding elements \(inReal0 \- inReal1\)\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
This function performs element\-wise subtraction:
outReal\[i\] = inReal0\[i\] \- inReal1\[i\]

Common uses:
\- Calculating price differences or spreads between instruments
\- Computing indicator divergences
\- Removing trend components from price series
\- Creating oscillators by subtracting moving averages
\- Calculating profit/loss series