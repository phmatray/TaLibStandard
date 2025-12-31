#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.ZigZag Method

| Overloads | |
| :--- | :--- |
| [ZigZag\(int, int, double\[\], double\[\], double\)](TAMath.ZigZag.md#TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double) 'TechnicalAnalysis\.Functions\.TAMath\.ZigZag\(int, int, double\[\], double\[\], double\)') | Calculates the ZigZag indicator which filters out minor price movements to identify significant trends\. |
| [ZigZag\(int, int, float\[\], float\[\], double\)](TAMath.ZigZag.md#TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double) 'TechnicalAnalysis\.Functions\.TAMath\.ZigZag\(int, int, float\[\], float\[\], double\)') | Calculates the ZigZag indicator using a default deviation of 5\.0%\. |

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double)'></a>

## TAMath\.ZigZag\(int, int, double\[\], double\[\], double\) Method

Calculates the ZigZag indicator which filters out minor price movements to identify significant trends\.

```csharp
public static TechnicalAnalysis.Functions.ZigZagResult ZigZag(int startIdx, int endIdx, double[] high, double[] low, double deviation=5.0);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double).deviation'></a>

`deviation` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The minimum percentage deviation required to form a new ZigZag line \(default: 5\.0\)\.

#### Returns
[ZigZagResult](ZigZagResult.md 'TechnicalAnalysis\.Functions\.ZigZagResult')  
A ZigZagResult object containing the calculated values and metadata\.

### Remarks
The ZigZag indicator is used to filter out market noise and identify significant price movements\.
It connects significant tops and bottoms in the price data, ignoring smaller movements that don't
meet the specified deviation threshold\. The indicator is primarily used to identify chart patterns
and for Elliott Wave analysis\. Note that ZigZag repaints \- the last leg may change as new data
comes in, making it unsuitable for real\-time trading signals\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double)'></a>

## TAMath\.ZigZag\(int, int, float\[\], float\[\], double\) Method

Calculates the ZigZag indicator using a default deviation of 5\.0%\.

```csharp
public static TechnicalAnalysis.Functions.ZigZagResult ZigZag(int startIdx, int endIdx, float[] high, float[] low, double deviation=5.0);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double).deviation'></a>

`deviation` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

#### Returns
[ZigZagResult](ZigZagResult.md 'TechnicalAnalysis\.Functions\.ZigZagResult')  
A ZigZagResult object containing the calculated values and metadata\.