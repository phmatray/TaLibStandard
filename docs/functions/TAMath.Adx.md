#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Adx Method

| Overloads | |
| :--- | :--- |
| [Adx\(int, int, double\[\], double\[\], double\[\], int\)](TAMath.Adx.md#TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Adx\(int, int, double\[\], double\[\], double\[\], int\)') | Calculates the Average Directional Index \(ADX\) indicator\. |
| [Adx\(int, int, double\[\], double\[\], double\[\]\)](TAMath.Adx.md#TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Adx\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the Average Directional Index \(ADX\) using the default period of 14\. |
| [Adx\(int, int, float\[\], float\[\], float\[\], int\)](TAMath.Adx.md#TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Adx\(int, int, float\[\], float\[\], float\[\], int\)') | Calculates the Average Directional Index \(ADX\) for the specified period using float arrays\. |
| [Adx\(int, int, float\[\], float\[\], float\[\]\)](TAMath.Adx.md#TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Adx\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the Average Directional Index \(ADX\) using the default period of 14 with float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[],int)'></a>

## TAMath\.Adx\(int, int, double\[\], double\[\], double\[\], int\) Method

Calculates the Average Directional Index \(ADX\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.AdxResult Adx(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[],int).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[],int).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[],int).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the ADX calculation \(default: 14\)\.

#### Returns
[AdxResult](AdxResult.md 'TechnicalAnalysis\.Functions\.AdxResult')  
An AdxResult containing the calculated values and metadata\.

### Remarks
The Average Directional Index \(ADX\) is a trend strength indicator developed by J\. Welles Wilder\.
It is a smoothed average of the Directional Movement Index \(DX\) and is used to determine whether 
a market is trending or ranging, regardless of trend direction\.

The ADX is derived from two other indicators:
\- \+DI \(Positive Directional Indicator\): measures upward trend strength
\- \-DI \(Negative Directional Indicator\): measures downward trend strength

ADX values help identify trend strength:
\- 0\-25: Absent or weak trend
\- 25\-50: Strong trend
\- 50\-75: Very strong trend
\- 75\-100: Extremely strong trend

The ADX does not indicate trend direction, only trend strength\. Traders often use it in combination 
with the \+DI and \-DI lines to determine both trend direction and strength\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[])'></a>

## TAMath\.Adx\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Average Directional Index \(ADX\) using the default period of 14\.

```csharp
public static TechnicalAnalysis.Functions.AdxResult Adx(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[AdxResult](AdxResult.md 'TechnicalAnalysis\.Functions\.AdxResult')  
An AdxResult containing the calculated values and metadata\.

### Remarks
This overload uses a default time period of 14\.
See the main overload for a detailed description of the ADX indicator\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[],int)'></a>

## TAMath\.Adx\(int, int, float\[\], float\[\], float\[\], int\) Method

Calculates the Average Directional Index \(ADX\) for the specified period using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.AdxResult Adx(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[],int).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[],int).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[],int).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the ADX calculation\.

#### Returns
[AdxResult](AdxResult.md 'TechnicalAnalysis\.Functions\.AdxResult')  
An AdxResult containing the calculated values and metadata\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
See the double array overload for a detailed description of the ADX indicator\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[])'></a>

## TAMath\.Adx\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the Average Directional Index \(ADX\) using the default period of 14 with float arrays\.

```csharp
public static TechnicalAnalysis.Functions.AdxResult Adx(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adx(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[AdxResult](AdxResult.md 'TechnicalAnalysis\.Functions\.AdxResult')  
An AdxResult containing the calculated values and metadata\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
Uses a default time period of 14\.