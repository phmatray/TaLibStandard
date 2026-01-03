#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.UltOsc Method

| Overloads | |
| :--- | :--- |
| [UltOsc\(int, int, double\[\], double\[\], double\[\], int, int, int\)](TAMath.UltOsc.md#TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int) 'TechnicalAnalysis\.Functions\.TAMath\.UltOsc\(int, int, double\[\], double\[\], double\[\], int, int, int\)') | Calculates the Ultimate Oscillator \(ULTOSC\) indicator\. |
| [UltOsc\(int, int, float\[\], float\[\], float\[\], int, int, int\)](TAMath.UltOsc.md#TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int) 'TechnicalAnalysis\.Functions\.TAMath\.UltOsc\(int, int, float\[\], float\[\], float\[\], int, int, int\)') | Calculates the Ultimate Oscillator \(ULTOSC\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int)'></a>

## TAMath\.UltOsc\(int, int, double\[\], double\[\], double\[\], int, int, int\) Method

Calculates the Ultimate Oscillator \(ULTOSC\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.UltOscResult UltOsc(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod1=7, int timePeriod2=14, int timePeriod3=28);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).timePeriod1'></a>

`timePeriod1` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The first time period \(short\-term, default: 7\)\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).timePeriod2'></a>

`timePeriod2` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The second time period \(intermediate\-term, default: 14\)\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,double[],double[],double[],int,int,int).timePeriod3'></a>

`timePeriod3` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The third time period \(long\-term, default: 28\)\.

#### Returns
[UltOscResult](UltOscResult.md 'TechnicalAnalysis\.Functions\.UltOscResult')  
A UltOscResult object containing the calculated values\.

### Remarks
The Ultimate Oscillator is a momentum oscillator designed to capture momentum across three different timeframes\.
It uses weighted sums of three oscillators, each of which uses a different time period\.
The indicator ranges between 0 and 100, with overbought levels typically above 70 and oversold levels below 30\.
This multi\-timeframe approach reduces false signals and provides more reliable divergence signals\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int)'></a>

## TAMath\.UltOsc\(int, int, float\[\], float\[\], float\[\], int, int, int\) Method

Calculates the Ultimate Oscillator \(ULTOSC\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.UltOscResult UltOsc(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod1=7, int timePeriod2=14, int timePeriod3=28);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).timePeriod1'></a>

`timePeriod1` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The first time period \(short\-term, default: 7\)\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).timePeriod2'></a>

`timePeriod2` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The second time period \(intermediate\-term, default: 14\)\.

<a name='TechnicalAnalysis.Functions.TAMath.UltOsc(int,int,float[],float[],float[],int,int,int).timePeriod3'></a>

`timePeriod3` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The third time period \(long\-term, default: 28\)\.

#### Returns
[UltOscResult](UltOscResult.md 'TechnicalAnalysis\.Functions\.UltOscResult')  
A UltOscResult object containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
This may result in a minor performance overhead due to the conversion process\.