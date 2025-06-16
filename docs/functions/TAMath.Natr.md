#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Natr Method

| Overloads | |
| :--- | :--- |
| [Natr\(int, int, double\[\], double\[\], double\[\], int\)](TAMath.Natr.md#TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Natr\(int, int, double\[\], double\[\], double\[\], int\)') | Calculates the Normalized Average True Range \(NATR\) indicator\. |
| [Natr\(int, int, double\[\], double\[\], double\[\]\)](TAMath.Natr.md#TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Natr\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the Normalized Average True Range \(NATR\) indicator using the default time period\. |
| [Natr\(int, int, float\[\], float\[\], float\[\], int\)](TAMath.Natr.md#TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Natr\(int, int, float\[\], float\[\], float\[\], int\)') | Calculates the Normalized Average True Range \(NATR\) indicator using float arrays\. |
| [Natr\(int, int, float\[\], float\[\], float\[\]\)](TAMath.Natr.md#TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Natr\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the Normalized Average True Range \(NATR\) indicator using float arrays and the default time period\. |

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int)'></a>

## TAMath\.Natr\(int, int, double\[\], double\[\], double\[\], int\) Method

Calculates the Normalized Average True Range \(NATR\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.NatrResult Natr(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for the average \(default: 14\)\.

#### Returns
[NatrResult](NatrResult.md 'TechnicalAnalysis\.Functions\.NatrResult')  
A NatrResult object containing the calculated values\.

### Remarks
NATR is the Average True Range \(ATR\) normalized as a percentage of the closing price\.
This normalization allows for better comparison of volatility across different price levels and instruments\.
The formula is: NATR = \(ATR / Close\) \* 100
This indicator is useful for position sizing and comparing volatility between different securities
regardless of their price levels\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[])'></a>

## TAMath\.Natr\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Normalized Average True Range \(NATR\) indicator using the default time period\.

```csharp
public static TechnicalAnalysis.Functions.NatrResult Natr(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of closing prices\.

#### Returns
[NatrResult](NatrResult.md 'TechnicalAnalysis\.Functions\.NatrResult')  
A NatrResult object containing the calculated values\.

### Remarks
Uses the default time period of 14\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int)'></a>

## TAMath\.Natr\(int, int, float\[\], float\[\], float\[\], int\) Method

Calculates the Normalized Average True Range \(NATR\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.NatrResult Natr(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for the average\.

#### Returns
[NatrResult](NatrResult.md 'TechnicalAnalysis\.Functions\.NatrResult')  
A NatrResult object containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
This may result in a minor performance overhead due to the conversion process\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[])'></a>

## TAMath\.Natr\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the Normalized Average True Range \(NATR\) indicator using float arrays and the default time period\.

```csharp
public static TechnicalAnalysis.Functions.NatrResult Natr(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of closing prices\.

#### Returns
[NatrResult](NatrResult.md 'TechnicalAnalysis\.Functions\.NatrResult')  
A NatrResult object containing the calculated values\.

### Remarks
Uses the default time period of 14\. This overload accepts float arrays and converts them to double arrays\.