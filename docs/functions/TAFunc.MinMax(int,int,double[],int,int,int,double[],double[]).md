#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MinMax\(int, int, double\[\], int, int, int, double\[\], double\[\]\) Method

Calculates the lowest and highest values over a specified period\.

```csharp
public static TechnicalAnalysis.Common.RetCode MinMax(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outMin, ref double[] outMax);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MinMax(int,int,double[],int,int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The start index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMax(int,int,double[],int,int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The end index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMax(int,int,double[],int,int,int,double[],double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input array of real values\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMax(int,int,double[],int,int,int,double[],double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The time period for the calculation\. Valid range is 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMax(int,int,double[],int,int,int,double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The beginning index of the output values\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMax(int,int,double[],int,int,int,double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of elements in the output arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMax(int,int,double[],int,int,int,double[],double[]).outMin'></a>

`outMin` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The output array containing the minimum values for each period\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMax(int,int,double[],int,int,int,double[],double[]).outMax'></a>

`outMax` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The output array containing the maximum values for each period\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode') indicating the success or failure of the calculation\.

### Remarks
The MinMax function identifies the lowest and highest values over a specified rolling period\.
This function efficiently tracks both extremes simultaneously, making it useful for:
\- Identifying support and resistance levels
\- Calculating price channels
\- Determining volatility ranges
\- Building other indicators that require min/max values