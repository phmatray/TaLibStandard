#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MidPrice\(int, int, double\[\], double\[\], int, int, int, double\[\]\) Method

Calculates the midpoint price over a specified period\.

```csharp
public static TechnicalAnalysis.Common.RetCode MidPrice(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, int optInTimePeriod, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MidPrice(int,int,double[],double[],int,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The start index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAFunc.MidPrice(int,int,double[],double[],int,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The end index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAFunc.MidPrice(int,int,double[],double[],int,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.MidPrice(int,int,double[],double[],int,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.MidPrice(int,int,double[],double[],int,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The time period for the calculation\. Valid range is 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.MidPrice(int,int,double[],double[],int,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The beginning index of the output values\.

<a name='TechnicalAnalysis.Functions.TAFunc.MidPrice(int,int,double[],double[],int,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of elements in the output array\.

<a name='TechnicalAnalysis.Functions.TAFunc.MidPrice(int,int,double[],double[],int,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The output array containing the midpoint price values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode') indicating the success or failure of the calculation\.

### Remarks
The MidPrice function calculates the midpoint of the highest high and lowest low over the specified period\.
It is calculated as: \(Highest High \+ Lowest Low\) / 2 over the given time period\.
This indicator is particularly useful in identifying the median price level in a given timeframe,
and can be used to determine support and resistance levels\.