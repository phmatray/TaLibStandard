#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MinIndex\(int, int, double\[\], int, int, int, int\[\]\) Method

Calculates the index of the lowest value over a specified period \(MININDEX\)\.

```csharp
public static TechnicalAnalysis.Common.RetCode MinIndex(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref int[] outInteger);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MinIndex(int,int,double[],int,int,int,int[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The start index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinIndex(int,int,double[],int,int,int,int[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The end index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinIndex(int,int,double[],int,int,int,int[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input array of real values\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinIndex(int,int,double[],int,int,int,int[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The time period over which to find the minimum value index\. Valid range is 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinIndex(int,int,double[],int,int,int,int[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The beginning index of the output values within the output array\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinIndex(int,int,double[],int,int,int,int[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of elements to be set in the output array\.

<a name='TechnicalAnalysis.Functions.TAFunc.MinIndex(int,int,double[],int,int,int,int[]).outInteger'></a>

`outInteger` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The output array that will contain the indices of the minimum values for each period\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode') indicating the success or failure of the calculation\.

### Remarks
The MININDEX function returns the array index location of the lowest value within a rolling window\.
This is useful for identifying when troughs occurred in the data series\.