#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Mfi Method

| Overloads | |
| :--- | :--- |
| [Mfi\(int, int, double\[\], double\[\], double\[\], double\[\]\)](TAMath.Mfi.md#TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Mfi\(int, int, double\[\], double\[\], double\[\], double\[\]\)') | Calculates the Money Flow Index \(MFI\) indicator with default period\. |
| [Mfi\(int, int, double\[\], double\[\], double\[\], double\[\], int\)](TAMath.Mfi.md#TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Mfi\(int, int, double\[\], double\[\], double\[\], double\[\], int\)') | Calculates the Money Flow Index \(MFI\) indicator\. |
| [Mfi\(int, int, float\[\], float\[\], float\[\], float\[\]\)](TAMath.Mfi.md#TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Mfi\(int, int, float\[\], float\[\], float\[\], float\[\]\)') | Calculates the Money Flow Index \(MFI\) indicator using float arrays with default period\. |
| [Mfi\(int, int, float\[\], float\[\], float\[\], float\[\], int\)](TAMath.Mfi.md#TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Mfi\(int, int, float\[\], float\[\], float\[\], float\[\], int\)') | Calculates the Money Flow Index \(MFI\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[])'></a>

## TAMath\.Mfi\(int, int, double\[\], double\[\], double\[\], double\[\]\) Method

Calculates the Money Flow Index \(MFI\) indicator with default period\.

```csharp
public static TechnicalAnalysis.Functions.MfiResult Mfi(int startIdx, int endIdx, double[] high, double[] low, double[] close, double[] volume);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[]).volume'></a>

`volume` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of trading volumes\.

#### Returns
[MfiResult](MfiResult.md 'TechnicalAnalysis\.Functions\.MfiResult')  
An MfiResult object containing the calculated MFI values\.

### Remarks
This overload uses a default time period of 14\.
See the main overload for a detailed description of the MFI indicator\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[],int)'></a>

## TAMath\.Mfi\(int, int, double\[\], double\[\], double\[\], double\[\], int\) Method

Calculates the Money Flow Index \(MFI\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.MfiResult Mfi(int startIdx, int endIdx, double[] high, double[] low, double[] close, double[] volume, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[],int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[],int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[],int).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[],int).volume'></a>

`volume` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of trading volumes\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,double[],double[],double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[MfiResult](MfiResult.md 'TechnicalAnalysis\.Functions\.MfiResult')  
An MfiResult object containing the calculated MFI values\.

### Remarks
The Money Flow Index \(MFI\) is a momentum indicator that uses both price and volume data to measure 
buying and selling pressure\. It is also known as volume\-weighted RSI\. The MFI starts with the typical 
price for each period\. Money flow is positive when the typical price rises \(buying pressure\) and negative 
when the typical price declines \(selling pressure\)\. A ratio of positive and negative money flow is then 
plugged into an RSI formula to create an oscillator that moves between zero and one hundred\.

The MFI is interpreted similarly to the RSI: readings below 20 indicate oversold conditions, while 
readings above 80 indicate overbought conditions\. Divergences between the indicator and price action 
are also significant and can signal potential reversals\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[])'></a>

## TAMath\.Mfi\(int, int, float\[\], float\[\], float\[\], float\[\]\) Method

Calculates the Money Flow Index \(MFI\) indicator using float arrays with default period\.

```csharp
public static TechnicalAnalysis.Functions.MfiResult Mfi(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[]).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[]).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[]).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[]).volume'></a>

`volume` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of trading volumes\.

#### Returns
[MfiResult](MfiResult.md 'TechnicalAnalysis\.Functions\.MfiResult')  
An MfiResult object containing the calculated MFI values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
Uses a default time period of 14\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[],int)'></a>

## TAMath\.Mfi\(int, int, float\[\], float\[\], float\[\], float\[\], int\) Method

Calculates the Money Flow Index \(MFI\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MfiResult Mfi(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[],int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[],int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[],int).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[],int).volume'></a>

`volume` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of trading volumes\.

<a name='TechnicalAnalysis.Functions.TAMath.Mfi(int,int,float[],float[],float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation\.

#### Returns
[MfiResult](MfiResult.md 'TechnicalAnalysis\.Functions\.MfiResult')  
An MfiResult object containing the calculated MFI values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
See the double array overload for a detailed description of the MFI indicator\.