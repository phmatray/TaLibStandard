#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MinMaxIndex\(int, int, double\[\], int, int, int, int\[\], int\[\]\) Method

Calculates the indices of the lowest and highest values over a specified period\.

```csharp
public static TechnicalAnalysis.Common.RetCode MinMaxIndex(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref int[] outMinIdx, ref int[] outMaxIdx);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MinMaxIndex(int,int,double[],int,int,int,int[],int[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The start index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMaxIndex(int,int,double[],int,int,int,int[],int[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The end index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMaxIndex(int,int,double[],int,int,int,int[],int[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input array of real values\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMaxIndex(int,int,double[],int,int,int,int[],int[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The time period for the calculation\. Valid range is 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMaxIndex(int,int,double[],int,int,int,int[],int[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The beginning index of the output values\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMaxIndex(int,int,double[],int,int,int,int[],int[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of elements in the output arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMaxIndex(int,int,double[],int,int,int,int[],int[]).outMinIdx'></a>

`outMinIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The output array containing the indices of the minimum values for each period\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinMaxIndex(int,int,double[],int,int,int,int[],int[]).outMaxIdx'></a>

`outMaxIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The output array containing the indices of the maximum values for each period\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode') indicating the success or failure of the calculation\.

### Remarks
The MinMaxIndex function identifies the array indices where the lowest and highest values occur 
over a specified rolling period\. Unlike MinMax which returns the actual values, this function 
returns the positions \(indices\) where these extremes are found\. This is particularly useful for:
\- Identifying when price extremes occurred
\- Analyzing the timing of peaks and troughs
\- Building more complex indicators that need position information
\- Backtesting strategies based on extreme value timing