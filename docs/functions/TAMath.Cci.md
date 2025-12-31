#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Cci Method

| Overloads | |
| :--- | :--- |
| [Cci\(int, int, double\[\], double\[\], double\[\], int\)](TAMath.Cci.md#TechnicalAnalysis.Functions.TAMath.Cci(int,int,double[],double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Cci\(int, int, double\[\], double\[\], double\[\], int\)') | Calculates the Commodity Channel Index \(CCI\) indicator\. |
| [Cci\(int, int, float\[\], float\[\], float\[\], int\)](TAMath.Cci.md#TechnicalAnalysis.Functions.TAMath.Cci(int,int,float[],float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Cci\(int, int, float\[\], float\[\], float\[\], int\)') | Calculates the Commodity Channel Index \(CCI\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,double[],double[],double[],int)'></a>

## TAMath\.Cci\(int, int, double\[\], double\[\], double\[\], int\) Method

Calculates the Commodity Channel Index \(CCI\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.CciResult Cci(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,double[],double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,double[],double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,double[],double[],double[],int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,double[],double[],double[],int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,double[],double[],double[],int).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,double[],double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[CciResult](CciResult.md 'TechnicalAnalysis\.Functions\.CciResult')  
A CciResult object containing the calculated CCI values\.

### Remarks
The Commodity Channel Index \(CCI\) is a momentum\-based oscillator used to help determine when an investment 
vehicle is reaching a condition of being overbought or oversold\. Developed by Donald Lambert, this technical 
indicator assesses price trend direction and strength, allowing traders to determine if they want to enter 
or exit a trade, refrain from taking a trade, or add to an existing position\.

The CCI is calculated as:
CCI = \(Typical Price \- SMA of Typical Price\) / \(0\.015 × Mean Deviation\)
Where Typical Price = \(High \+ Low \+ Close\) / 3

CCI values above \+100 indicate an overbought condition, while values below \-100 indicate an oversold condition\.
The indicator can also be used to identify divergences and trend reversals\.

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,float[],float[],float[],int)'></a>

## TAMath\.Cci\(int, int, float\[\], float\[\], float\[\], int\) Method

Calculates the Commodity Channel Index \(CCI\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.CciResult Cci(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,float[],float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,float[],float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,float[],float[],float[],int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,float[],float[],float[],int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,float[],float[],float[],int).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Cci(int,int,float[],float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[CciResult](CciResult.md 'TechnicalAnalysis\.Functions\.CciResult')  
A CciResult object containing the calculated CCI values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
See the double array overload for a detailed description of the CCI indicator\.