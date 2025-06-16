#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MinusDM Method

| Overloads | |
| :--- | :--- |
| [MinusDM\(int, int, double\[\], double\[\], int\)](TAMath.MinusDM.md#TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinusDM\(int, int, double\[\], double\[\], int\)') | Calculates the Minus Directional Movement \(\-DM\) which measures negative price movement between periods\. |
| [MinusDM\(int, int, double\[\], double\[\]\)](TAMath.MinusDM.md#TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.MinusDM\(int, int, double\[\], double\[\]\)') | Calculates the Minus Directional Movement \(\-DM\) using a default time period of 14\. |
| [MinusDM\(int, int, float\[\], float\[\], int\)](TAMath.MinusDM.md#TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinusDM\(int, int, float\[\], float\[\], int\)') | Calculates the Minus Directional Movement \(\-DM\) for float arrays\. |
| [MinusDM\(int, int, float\[\], float\[\]\)](TAMath.MinusDM.md#TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.MinusDM\(int, int, float\[\], float\[\]\)') | Calculates the Minus Directional Movement \(\-DM\) for float arrays using a default time period of 14\. |

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int)'></a>

## TAMath\.MinusDM\(int, int, double\[\], double\[\], int\) Method

Calculates the Minus Directional Movement \(\-DM\) which measures negative price movement between periods\.

```csharp
public static TechnicalAnalysis.Functions.MinusDMResult MinusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[MinusDMResult](MinusDMResult.md 'TechnicalAnalysis\.Functions\.MinusDMResult')  
A MinusDMResult object containing the calculated values and metadata\.

### Remarks
The Minus Directional Movement is a component of the Directional Movement System developed by Welles Wilder\.
It measures the negative \(downward\) movement in price from one period to the next\. \-DM occurs when the
previous low minus the current low is greater than the current high minus the previous high, and is
positive\. The \-DM values are typically smoothed using Wilder's smoothing method\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[])'></a>

## TAMath\.MinusDM\(int, int, double\[\], double\[\]\) Method

Calculates the Minus Directional Movement \(\-DM\) using a default time period of 14\.

```csharp
public static TechnicalAnalysis.Functions.MinusDMResult MinusDM(int startIdx, int endIdx, double[] high, double[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

#### Returns
[MinusDMResult](MinusDMResult.md 'TechnicalAnalysis\.Functions\.MinusDMResult')  
A MinusDMResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int)'></a>

## TAMath\.MinusDM\(int, int, float\[\], float\[\], int\) Method

Calculates the Minus Directional Movement \(\-DM\) for float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MinusDMResult MinusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[MinusDMResult](MinusDMResult.md 'TechnicalAnalysis\.Functions\.MinusDMResult')  
A MinusDMResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
This ensures compatibility with data sources that provide float precision while maintaining accuracy
in the calculations\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[])'></a>

## TAMath\.MinusDM\(int, int, float\[\], float\[\]\) Method

Calculates the Minus Directional Movement \(\-DM\) for float arrays using a default time period of 14\.

```csharp
public static TechnicalAnalysis.Functions.MinusDMResult MinusDM(int startIdx, int endIdx, float[] high, float[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDM(int,int,float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

#### Returns
[MinusDMResult](MinusDMResult.md 'TechnicalAnalysis\.Functions\.MinusDMResult')  
A MinusDMResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.