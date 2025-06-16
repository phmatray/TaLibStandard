#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.UltOsc Method

| Overloads | |
| :--- | :--- |
| [UltOsc\(int, int, double\[\], double\[\], double\[\], int, int, int\)](TAMath.UltOsc.md#TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int) 'TechnicalAnalysis\.Functions\.TAMath\.UltOsc\(int, int, double\[\], double\[\], double\[\], int, int, int\)') | Calculates the Ultimate Oscillator \(ULTOSC\) indicator\. |
| [UltOsc\(int, int, double\[\], double\[\], double\[\]\)](TAMath.UltOsc.md#TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.UltOsc\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the Ultimate Oscillator \(ULTOSC\) indicator using default time periods\. |
| [UltOsc\(int, int, float\[\], float\[\], float\[\], int, int, int\)](TAMath.UltOsc.md#TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int) 'TechnicalAnalysis\.Functions\.TAMath\.UltOsc\(int, int, float\[\], float\[\], float\[\], int, int, int\)') | Calculates the Ultimate Oscillator \(ULTOSC\) indicator using float arrays\. |
| [UltOsc\(int, int, float\[\], float\[\], float\[\]\)](TAMath.UltOsc.md#TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.UltOsc\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the Ultimate Oscillator \(ULTOSC\) indicator using float arrays and default time periods\. |

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int)'></a>

## TAMath\.UltOsc\(int, int, double\[\], double\[\], double\[\], int, int, int\) Method

Calculates the Ultimate Oscillator \(ULTOSC\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.UltOscResult UltOsc(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod1, int timePeriod2, int timePeriod3);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).timePeriod1'></a>

`timePeriod1` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The first time period \(short\-term, default: 7\)\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).timePeriod2'></a>

`timePeriod2` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The second time period \(intermediate\-term, default: 14\)\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).timePeriod3'></a>

`timePeriod3` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The third time period \(long\-term, default: 28\)\.

#### Returns
[UltOscResult](UltOscResult.md 'TechnicalAnalysis\.Functions\.UltOscResult')  
A UltOscResult object containing the calculated values\.

### Remarks
The Ultimate Oscillator is a momentum oscillator designed to capture momentum across three different timeframes\.
It uses weighted sums of three oscillators, each of which uses a different time period\.
The indicator ranges between 0 and 100, with overbought levels typically above 70 and oversold levels below 30\.
This multi\-timeframe approach reduces false signals and provides more reliable divergence signals\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[])'></a>

## TAMath\.UltOsc\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the Ultimate Oscillator \(ULTOSC\) indicator using default time periods\.

```csharp
public static TechnicalAnalysis.Functions.UltOscResult UltOsc(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of closing prices\.

#### Returns
[UltOscResult](UltOscResult.md 'TechnicalAnalysis\.Functions\.UltOscResult')  
A UltOscResult object containing the calculated values\.

### Remarks
Uses the default time periods of 7, 14, and 28\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int)'></a>

## TAMath\.UltOsc\(int, int, float\[\], float\[\], float\[\], int, int, int\) Method

Calculates the Ultimate Oscillator \(ULTOSC\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.UltOscResult UltOsc(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod1, int timePeriod2, int timePeriod3);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).timePeriod1'></a>

`timePeriod1` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The first time period \(short\-term\)\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).timePeriod2'></a>

`timePeriod2` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The second time period \(intermediate\-term\)\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).timePeriod3'></a>

`timePeriod3` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The third time period \(long\-term\)\.

#### Returns
[UltOscResult](UltOscResult.md 'TechnicalAnalysis\.Functions\.UltOscResult')  
A UltOscResult object containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
This may result in a minor performance overhead due to the conversion process\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[])'></a>

## TAMath\.UltOsc\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the Ultimate Oscillator \(ULTOSC\) indicator using float arrays and default time periods\.

```csharp
public static TechnicalAnalysis.Functions.UltOscResult UltOsc(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of closing prices\.

#### Returns
[UltOscResult](UltOscResult.md 'TechnicalAnalysis\.Functions\.UltOscResult')  
A UltOscResult object containing the calculated values\.

### Remarks
Uses the default time periods of 7, 14, and 28\. This overload accepts float arrays and converts them to double arrays\.