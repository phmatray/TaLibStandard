#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MinusDI Method

| Overloads | |
| :--- | :--- |
| [MinusDI\(int, int, double\[\], double\[\], double\[\], int\)](TAMath.MinusDI.md#TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinusDI\(int, int, double\[\], double\[\], double\[\], int\)') | Calculates the Minus Directional Indicator \(\-DI\) which measures the strength of negative price movement\. |
| [MinusDI\(int, int, double\[\], double\[\], double\[\]\)](TAMath.MinusDI.md#TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.MinusDI\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the Minus Directional Indicator \(\-DI\) using a default time period of 14\. |
| [MinusDI\(int, int, float\[\], float\[\], float\[\], int\)](TAMath.MinusDI.md#TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MinusDI\(int, int, float\[\], float\[\], float\[\], int\)') | Calculates the Minus Directional Indicator \(\-DI\) for float arrays\. |
| [MinusDI\(int, int, float\[\], float\[\], float\[\]\)](TAMath.MinusDI.md#TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.MinusDI\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the Minus Directional Indicator \(\-DI\) for float arrays using a default time period of 14\. |

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[],int)'></a>

## TAMath\.MinusDI\(int, int, double\[\], double\[\], double\[\], int\) Method

Calculates the Minus Directional Indicator \(\-DI\) which measures the strength of negative price movement\.

```csharp
public static TechnicalAnalysis.Functions.MinusDIResult MinusDI(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[],int).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[],int).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[],int).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[MinusDIResult](MinusDIResult.md 'TechnicalAnalysis\.Functions\.MinusDIResult')  
A MinusDIResult object containing the calculated values and metadata\.

### Remarks
The Minus Directional Indicator is part of the Directional Movement System developed by Welles Wilder\.
It measures the strength of negative price movement and is typically used in conjunction with the
Plus Directional Indicator \(\+DI\) to identify trend direction and strength\. When \-DI is above \+DI,
it suggests a downward trend\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[])'></a>

## TAMath\.MinusDI\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Minus Directional Indicator \(\-DI\) using a default time period of 14\.

```csharp
public static TechnicalAnalysis.Functions.MinusDIResult MinusDI(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[MinusDIResult](MinusDIResult.md 'TechnicalAnalysis\.Functions\.MinusDIResult')  
A MinusDIResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[],int)'></a>

## TAMath\.MinusDI\(int, int, float\[\], float\[\], float\[\], int\) Method

Calculates the Minus Directional Indicator \(\-DI\) for float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MinusDIResult MinusDI(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[],int).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[],int).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[],int).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[MinusDIResult](MinusDIResult.md 'TechnicalAnalysis\.Functions\.MinusDIResult')  
A MinusDIResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
This ensures compatibility with data sources that provide float precision while maintaining accuracy
in the calculations\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[])'></a>

## TAMath\.MinusDI\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the Minus Directional Indicator \(\-DI\) for float arrays using a default time period of 14\.

```csharp
public static TechnicalAnalysis.Functions.MinusDIResult MinusDI(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MinusDI(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[MinusDIResult](MinusDIResult.md 'TechnicalAnalysis\.Functions\.MinusDIResult')  
A MinusDIResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.