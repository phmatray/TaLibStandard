#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.RocR\(int, int, double\[\], int, int, int, double\[\]\) Method

Calculates the Rate of Change Ratio \(RocR\) for a given period\.

```csharp
public static TechnicalAnalysis.Common.RetCode RocR(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.RocR(int,int,double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAFunc.RocR(int,int,double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAFunc.RocR(int,int,double[],int,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.RocR(int,int,double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to look back for comparison \(valid range: 1\-100000\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.RocR(int,int,double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Output parameter that will contain the index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.RocR(int,int,double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Output parameter that will contain the number of elements in the output array\.

<a name='TechnicalAnalysis.Functions.TAFunc.RocR(int,int,double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array that will contain the calculated RocR values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode') indicating the success or failure of the calculation\.
Returns [TechnicalAnalysis\.Common\.RetCode\.Success](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode.Success 'TechnicalAnalysis\.Common\.RetCode\.Success') on successful calculation\.
Returns [TechnicalAnalysis\.Common\.RetCode\.OutOfRangeStartIndex](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode.OutOfRangeStartIndex 'TechnicalAnalysis\.Common\.RetCode\.OutOfRangeStartIndex') if startIdx is less than 0\.
Returns [TechnicalAnalysis\.Common\.RetCode\.OutOfRangeEndIndex](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode.OutOfRangeEndIndex 'TechnicalAnalysis\.Common\.RetCode\.OutOfRangeEndIndex') if endIdx is less than 0 or less than startIdx\.
Returns [TechnicalAnalysis\.Common\.RetCode\.BadParam](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode.BadParam 'TechnicalAnalysis\.Common\.RetCode\.BadParam') if any input parameters are invalid\.

### Remarks
The Rate of Change Ratio \(RocR\) is a momentum oscillator that measures the ratio
between the current price and the price n periods ago\. It is calculated as:
RocR = Current Price / Price n periods ago

A RocR value of 1\.0 indicates no change, values above 1\.0 indicate an increase,
and values below 1\.0 indicate a decrease\. For example, a RocR of 1\.1 represents
a 10% increase, while a RocR of 0\.9 represents a 10% decrease\.

This indicator is useful for identifying momentum and potential trend changes\.
When RocR crosses above 1\.0, it may signal upward momentum, and when it crosses
below 1\.0, it may signal downward momentum\.