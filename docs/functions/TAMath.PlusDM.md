#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.PlusDM Method

| Overloads | |
| :--- | :--- |
| [PlusDM\(int, int, double\[\], double\[\], int\)](TAMath.PlusDM.md#TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.PlusDM\(int, int, double\[\], double\[\], int\)') | Calculates the Plus Directional Movement \(\+DM\) which measures positive price movement between periods\. |
| [PlusDM\(int, int, double\[\], double\[\]\)](TAMath.PlusDM.md#TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.PlusDM\(int, int, double\[\], double\[\]\)') | Calculates the Plus Directional Movement \(\+DM\) using a default time period of 14\. |
| [PlusDM\(int, int, float\[\], float\[\], int\)](TAMath.PlusDM.md#TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.PlusDM\(int, int, float\[\], float\[\], int\)') | Calculates the Plus Directional Movement \(\+DM\) for float arrays\. |
| [PlusDM\(int, int, float\[\], float\[\]\)](TAMath.PlusDM.md#TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.PlusDM\(int, int, float\[\], float\[\]\)') | Calculates the Plus Directional Movement \(\+DM\) for float arrays using a default time period of 14\. |

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[],int)'></a>

## TAMath\.PlusDM\(int, int, double\[\], double\[\], int\) Method

Calculates the Plus Directional Movement \(\+DM\) which measures positive price movement between periods\.

```csharp
public static TechnicalAnalysis.Functions.PlusDMResult PlusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[],int).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[],int).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[PlusDMResult](PlusDMResult.md 'TechnicalAnalysis\.Functions\.PlusDMResult')  
A PlusDMResult object containing the calculated values and metadata\.

### Remarks
The Plus Directional Movement is a component of the Directional Movement System developed by Welles Wilder\.
It measures the positive \(upward\) movement in price from one period to the next\. \+DM occurs when the
current high minus the previous high is greater than the previous low minus the current low, and is
positive\. The \+DM values are typically smoothed using Wilder's smoothing method\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[])'></a>

## TAMath\.PlusDM\(int, int, double\[\], double\[\]\) Method

Calculates the Plus Directional Movement \(\+DM\) using a default time period of 14\.

```csharp
public static TechnicalAnalysis.Functions.PlusDMResult PlusDM(int startIdx, int endIdx, double[] high, double[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

#### Returns
[PlusDMResult](PlusDMResult.md 'TechnicalAnalysis\.Functions\.PlusDMResult')  
A PlusDMResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[],int)'></a>

## TAMath\.PlusDM\(int, int, float\[\], float\[\], int\) Method

Calculates the Plus Directional Movement \(\+DM\) for float arrays\.

```csharp
public static TechnicalAnalysis.Functions.PlusDMResult PlusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[],int).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[],int).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[PlusDMResult](PlusDMResult.md 'TechnicalAnalysis\.Functions\.PlusDMResult')  
A PlusDMResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
This ensures compatibility with data sources that provide float precision while maintaining accuracy
in the calculations\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[])'></a>

## TAMath\.PlusDM\(int, int, float\[\], float\[\]\) Method

Calculates the Plus Directional Movement \(\+DM\) for float arrays using a default time period of 14\.

```csharp
public static TechnicalAnalysis.Functions.PlusDMResult PlusDM(int startIdx, int endIdx, float[] high, float[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.PlusDM(int,int,float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

#### Returns
[PlusDMResult](PlusDMResult.md 'TechnicalAnalysis\.Functions\.PlusDMResult')  
A PlusDMResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.