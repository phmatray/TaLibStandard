#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.PlusDI Method

| Overloads | |
| :--- | :--- |
| [PlusDI\(int, int, double\[\], double\[\], double\[\]\)](TAMath.PlusDI.md#TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.PlusDI\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the Plus Directional Indicator \(\+DI\) using a default time period of 14\. |
| [PlusDI\(int, int, double\[\], double\[\], double\[\], int\)](TAMath.PlusDI.md#TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.PlusDI\(int, int, double\[\], double\[\], double\[\], int\)') | Calculates the Plus Directional Indicator \(\+DI\) which measures the strength of positive price movement\. |
| [PlusDI\(int, int, float\[\], float\[\], float\[\]\)](TAMath.PlusDI.md#TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.PlusDI\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the Plus Directional Indicator \(\+DI\) for float arrays using a default time period of 14\. |
| [PlusDI\(int, int, float\[\], float\[\], float\[\], int\)](TAMath.PlusDI.md#TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.PlusDI\(int, int, float\[\], float\[\], float\[\], int\)') | Calculates the Plus Directional Indicator \(\+DI\) for float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[])'></a>

## TAMath\.PlusDI\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Plus Directional Indicator \(\+DI\) using a default time period of 14\.

```csharp
public static TechnicalAnalysis.Functions.PlusDIResult PlusDI(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

#### Returns
[PlusDIResult](PlusDIResult.md 'TechnicalAnalysis\.Functions\.PlusDIResult')  
A PlusDIResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[],int)'></a>

## TAMath\.PlusDI\(int, int, double\[\], double\[\], double\[\], int\) Method

Calculates the Plus Directional Indicator \(\+DI\) which measures the strength of positive price movement\.

```csharp
public static TechnicalAnalysis.Functions.PlusDIResult PlusDI(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[],int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[],int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[],int).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,double[],double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[PlusDIResult](PlusDIResult.md 'TechnicalAnalysis\.Functions\.PlusDIResult')  
A PlusDIResult object containing the calculated values and metadata\.

### Remarks
The Plus Directional Indicator is part of the Directional Movement System developed by Welles Wilder\.
It measures the strength of positive price movement and is typically used in conjunction with the
Minus Directional Indicator \(\-DI\) to identify trend direction and strength\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[])'></a>

## TAMath\.PlusDI\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the Plus Directional Indicator \(\+DI\) for float arrays using a default time period of 14\.

```csharp
public static TechnicalAnalysis.Functions.PlusDIResult PlusDI(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

#### Returns
[PlusDIResult](PlusDIResult.md 'TechnicalAnalysis\.Functions\.PlusDIResult')  
A PlusDIResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[],int)'></a>

## TAMath\.PlusDI\(int, int, float\[\], float\[\], float\[\], int\) Method

Calculates the Plus Directional Indicator \(\+DI\) for float arrays\.

```csharp
public static TechnicalAnalysis.Functions.PlusDIResult PlusDI(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[],int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[],int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[],int).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDI(int,int,float[],float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[PlusDIResult](PlusDIResult.md 'TechnicalAnalysis\.Functions\.PlusDIResult')  
A PlusDIResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
This ensures compatibility with data sources that provide float precision while maintaining accuracy
in the calculations\.