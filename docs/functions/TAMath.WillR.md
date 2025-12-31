#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.WillR Method

| Overloads | |
| :--- | :--- |
| [WillR\(int, int, double\[\], double\[\], double\[\]\)](TAMath.WillR.md#TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.WillR\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the Williams' %R \(WILLR\) indicator using the default time period\. |
| [WillR\(int, int, double\[\], double\[\], double\[\], int\)](TAMath.WillR.md#TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.WillR\(int, int, double\[\], double\[\], double\[\], int\)') | Calculates the Williams' %R \(WILLR\) indicator\. |
| [WillR\(int, int, float\[\], float\[\], float\[\]\)](TAMath.WillR.md#TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.WillR\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the Williams' %R \(WILLR\) indicator using float arrays and the default time period\. |
| [WillR\(int, int, float\[\], float\[\], float\[\], int\)](TAMath.WillR.md#TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.WillR\(int, int, float\[\], float\[\], float\[\], int\)') | Calculates the Williams' %R \(WILLR\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[])'></a>

## TAMath\.WillR\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Williams' %R \(WILLR\) indicator using the default time period\.

```csharp
public static TechnicalAnalysis.Functions.WillRResult WillR(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of closing prices\.

#### Returns
[WillRResult](WillRResult.md 'TechnicalAnalysis\.Functions\.WillRResult')  
A WillRResult object containing the calculated values\.

### Remarks
Uses the default time period of 14\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[],int)'></a>

## TAMath\.WillR\(int, int, double\[\], double\[\], double\[\], int\) Method

Calculates the Williams' %R \(WILLR\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.WillRResult WillR(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[],int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[],int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[],int).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,double[],double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the calculation \(default: 14\)\.

#### Returns
[WillRResult](WillRResult.md 'TechnicalAnalysis\.Functions\.WillRResult')  
A WillRResult object containing the calculated values\.

### Remarks
Williams' %R is a momentum indicator that measures overbought and oversold levels\.
It reflects the level of the close relative to the highest high for the look\-back period\.
The oscillator ranges from \-100 to 0, with readings from 0 to \-20 considered overbought,
and readings from \-80 to \-100 considered oversold\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[])'></a>

## TAMath\.WillR\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the Williams' %R \(WILLR\) indicator using float arrays and the default time period\.

```csharp
public static TechnicalAnalysis.Functions.WillRResult WillR(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of closing prices\.

#### Returns
[WillRResult](WillRResult.md 'TechnicalAnalysis\.Functions\.WillRResult')  
A WillRResult object containing the calculated values\.

### Remarks
Uses the default time period of 14\. This overload accepts float arrays and converts them to double arrays\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[],int)'></a>

## TAMath\.WillR\(int, int, float\[\], float\[\], float\[\], int\) Method

Calculates the Williams' %R \(WILLR\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.WillRResult WillR(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[],int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[],int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[],int).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WillR(int,int,float[],float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the calculation\.

#### Returns
[WillRResult](WillRResult.md 'TechnicalAnalysis\.Functions\.WillRResult')  
A WillRResult object containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
This may result in a minor performance overhead due to the conversion process\.