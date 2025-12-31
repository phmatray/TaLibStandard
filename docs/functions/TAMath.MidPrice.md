#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MidPrice Method

| Overloads | |
| :--- | :--- |
| [MidPrice\(int, int, double\[\], double\[\], int\)](TAMath.MidPrice.md#TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MidPrice\(int, int, double\[\], double\[\], int\)') | Calculates the midpoint price over a specified time period \(MIDPRICE\)\. |
| [MidPrice\(int, int, float\[\], float\[\], int\)](TAMath.MidPrice.md#TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MidPrice\(int, int, float\[\], float\[\], int\)') | Calculates the midpoint price over a specified time period \(MIDPRICE\) using default period\. |

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,double[],double[],int)'></a>

## TAMath\.MidPrice\(int, int, double\[\], double\[\], int\) Method

Calculates the midpoint price over a specified time period \(MIDPRICE\)\.

```csharp
public static TechnicalAnalysis.Functions.MidPriceResult MidPrice(int startIdx, int endIdx, double[] high, double[] low, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,double[],double[],int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,double[],double[],int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to look back for calculating the midprice\.

#### Returns
[MidPriceResult](MidPriceResult.md 'TechnicalAnalysis\.Functions\.MidPriceResult')  
A MidPriceResult containing the midprice values over each rolling window\.

### Remarks
The MIDPRICE function calculates the midpoint between the highest high and lowest low within a moving window:
\(Highest High \+ Lowest Low\) / 2\. This indicator is commonly used in trading systems to identify the center
of the price range and can help determine trend direction and support/resistance levels\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,float[],float[],int)'></a>

## TAMath\.MidPrice\(int, int, float\[\], float\[\], int\) Method

Calculates the midpoint price over a specified time period \(MIDPRICE\) using default period\.

```csharp
public static TechnicalAnalysis.Functions.MidPriceResult MidPrice(int startIdx, int endIdx, float[] high, float[] low, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,float[],float[],int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,float[],float[],int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPrice(int,int,float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

#### Returns
[MidPriceResult](MidPriceResult.md 'TechnicalAnalysis\.Functions\.MidPriceResult')  
A MidPriceResult containing the midprice values over each rolling window\.

### Remarks
This overload uses a default time period of 14\.