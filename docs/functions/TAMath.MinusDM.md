#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MinusDM Method

| Overloads | |
| :--- | :--- |
| [MinusDM\(int, int, double\[\], double\[\], int\)](TAMath.MinusDM.md#TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinusDM\(int, int, double\[\], double\[\], int\)') | Calculates the Minus Directional Movement \(\-DM\) which measures negative price movement between periods\. |
| [MinusDM\(int, int, float\[\], float\[\], int\)](TAMath.MinusDM.md#TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinusDM\(int, int, float\[\], float\[\], int\)') | Calculates the Minus Directional Movement \(\-DM\) for float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int)'></a>

## TAMath\.MinusDM\(int, int, double\[\], double\[\], int\) Method

Calculates the Minus Directional Movement \(\-DM\) which measures negative price movement between periods\.

```csharp
public static TechnicalAnalysis.Functions.MinusDMResult MinusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[MinusDMResult](MinusDMResult.md 'TechnicalAnalysis\.Functions\.MinusDMResult')  
A MinusDMResult object containing the calculated values and metadata\.

### Remarks
The Minus Directional Movement is a component of the Directional Movement System developed by Welles Wilder\.
It measures the negative \(downward\) movement in price from one period to the next\. \-DM occurs when the
previous low minus the current low is greater than the current high minus the previous high, and is
positive\. The \-DM values are typically smoothed using Wilder's smoothing method\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int)'></a>

## TAMath\.MinusDM\(int, int, float\[\], float\[\], int\) Method

Calculates the Minus Directional Movement \(\-DM\) for float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MinusDMResult MinusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[MinusDMResult](MinusDMResult.md 'TechnicalAnalysis\.Functions\.MinusDMResult')  
A MinusDMResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
This ensures compatibility with data sources that provide float precision while maintaining accuracy
in the calculations\.