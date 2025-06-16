#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Atr Method

| Overloads | |
| :--- | :--- |
| [Atr\(int, int, double\[\], double\[\], double\[\], int\)](TAMath.Atr.md#TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Atr\(int, int, double\[\], double\[\], double\[\], int\)') | Calculates the Average True Range \(ATR\) indicator\. |
| [Atr\(int, int, double\[\], double\[\], double\[\]\)](TAMath.Atr.md#TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Atr\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the Average True Range \(ATR\) indicator with default period\. |
| [Atr\(int, int, float\[\], float\[\], float\[\], int\)](TAMath.Atr.md#TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Atr\(int, int, float\[\], float\[\], float\[\], int\)') | Calculates the Average True Range \(ATR\) indicator using float arrays\. |
| [Atr\(int, int, float\[\], float\[\], float\[\]\)](TAMath.Atr.md#TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Atr\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the Average True Range \(ATR\) indicator using float arrays with default period\. |

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[],int)'></a>

## TAMath\.Atr\(int, int, double\[\], double\[\], double\[\], int\) Method

Calculates the Average True Range \(ATR\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.AtrResult Atr(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[],int).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[],int).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[],int).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to average \(default: 14\)\.

#### Returns
[AtrResult](AtrResult.md 'TechnicalAnalysis\.Functions\.AtrResult')  
An AtrResult object containing the calculated ATR values\.

### Remarks
The Average True Range \(ATR\) is a technical analysis indicator that measures market volatility by decomposing 
the entire range of an asset price for that period\. Developed by J\. Welles Wilder, the ATR indicator measures 
volatility, taking into account any gaps in the price movement\.

The true range is the greatest of:
\- Current high minus current low
\- Absolute value of current high minus previous close
\- Absolute value of current low minus previous close

The ATR is then calculated as a moving average \(typically 14\-period\) of the true range values\. Higher ATR 
values indicate higher volatility, while lower values indicate lower volatility\. ATR does not indicate 
price direction, only volatility\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[])'></a>

## TAMath\.Atr\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Average True Range \(ATR\) indicator with default period\.

```csharp
public static TechnicalAnalysis.Functions.AtrResult Atr(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[AtrResult](AtrResult.md 'TechnicalAnalysis\.Functions\.AtrResult')  
An AtrResult object containing the calculated ATR values\.

### Remarks
This overload uses a default time period of 14\.
See the main overload for a detailed description of the ATR indicator\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[],int)'></a>

## TAMath\.Atr\(int, int, float\[\], float\[\], float\[\], int\) Method

Calculates the Average True Range \(ATR\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.AtrResult Atr(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[],int).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[],int).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[],int).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to average\.

#### Returns
[AtrResult](AtrResult.md 'TechnicalAnalysis\.Functions\.AtrResult')  
An AtrResult object containing the calculated ATR values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
See the double array overload for a detailed description of the ATR indicator\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[])'></a>

## TAMath\.Atr\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the Average True Range \(ATR\) indicator using float arrays with default period\.

```csharp
public static TechnicalAnalysis.Functions.AtrResult Atr(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Atr(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[AtrResult](AtrResult.md 'TechnicalAnalysis\.Functions\.AtrResult')  
An AtrResult object containing the calculated ATR values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
Uses a default time period of 14\.