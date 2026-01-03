#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Natr Method

| Overloads | |
| :--- | :--- |
| [Natr\(int, int, double\[\], double\[\], double\[\], int\)](TAMath.Natr.md#TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Natr\(int, int, double\[\], double\[\], double\[\], int\)') | Calculates the Normalized Average True Range \(NATR\) indicator\. |
| [Natr\(int, int, float\[\], float\[\], float\[\], int\)](TAMath.Natr.md#TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Natr\(int, int, float\[\], float\[\], float\[\], int\)') | Calculates the Normalized Average True Range \(NATR\) indicator using the default time period\. |

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int)'></a>

## TAMath\.Natr\(int, int, double\[\], double\[\], double\[\], int\) Method

Calculates the Normalized Average True Range \(NATR\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.NatrResult Natr(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,double[],double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

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

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int)'></a>

## TAMath\.Natr\(int, int, float\[\], float\[\], float\[\], int\) Method

Calculates the Normalized Average True Range \(NATR\) indicator using the default time period\.

```csharp
public static TechnicalAnalysis.Functions.NatrResult Natr(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Natr(int,int,float[],float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

#### Returns
[NatrResult](NatrResult.md 'TechnicalAnalysis\.Functions\.NatrResult')  
A NatrResult object containing the calculated values\.

### Remarks
Uses the default time period of 14\.