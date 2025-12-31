#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.AroonOsc Method

| Overloads | |
| :--- | :--- |
| [AroonOsc\(int, int, double\[\], double\[\]\)](TAMath.AroonOsc.md#TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.AroonOsc\(int, int, double\[\], double\[\]\)') | Calculates the Aroon Oscillator \(AROONOSC\) using the default time period of 14\. |
| [AroonOsc\(int, int, double\[\], double\[\], int\)](TAMath.AroonOsc.md#TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.AroonOsc\(int, int, double\[\], double\[\], int\)') | Calculates the Aroon Oscillator \(AROONOSC\) which measures the strength of a trend and likelihood of continuation\. |
| [AroonOsc\(int, int, float\[\], float\[\]\)](TAMath.AroonOsc.md#TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.AroonOsc\(int, int, float\[\], float\[\]\)') | Calculates the Aroon Oscillator \(AROONOSC\) using the default time period of 14\. |
| [AroonOsc\(int, int, float\[\], float\[\], int\)](TAMath.AroonOsc.md#TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.AroonOsc\(int, int, float\[\], float\[\], int\)') | Calculates the Aroon Oscillator \(AROONOSC\) which measures the strength of a trend and likelihood of continuation\. |

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[])'></a>

## TAMath\.AroonOsc\(int, int, double\[\], double\[\]\) Method

Calculates the Aroon Oscillator \(AROONOSC\) using the default time period of 14\.

```csharp
public static TechnicalAnalysis.Functions.AroonOscResult AroonOsc(int startIdx, int endIdx, double[] high, double[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

#### Returns
[AroonOscResult](AroonOscResult.md 'TechnicalAnalysis\.Functions\.AroonOscResult')  
An AroonOscResult containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[],int)'></a>

## TAMath\.AroonOsc\(int, int, double\[\], double\[\], int\) Method

Calculates the Aroon Oscillator \(AROONOSC\) which measures the strength of a trend and likelihood of continuation\.

```csharp
public static TechnicalAnalysis.Functions.AroonOscResult AroonOsc(int startIdx, int endIdx, double[] high, double[] low, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[],int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[],int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[AroonOscResult](AroonOscResult.md 'TechnicalAnalysis\.Functions\.AroonOscResult')  
An AroonOscResult containing the calculated values and metadata\.

### Remarks
The Aroon Oscillator is calculated as the difference between Aroon Up and Aroon Down\.
It oscillates between \-100 and \+100 with zero as the center line\.
Positive values indicate an upward trend, while negative values indicate a downward trend\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[])'></a>

## TAMath\.AroonOsc\(int, int, float\[\], float\[\]\) Method

Calculates the Aroon Oscillator \(AROONOSC\) using the default time period of 14\.

```csharp
public static TechnicalAnalysis.Functions.AroonOscResult AroonOsc(int startIdx, int endIdx, float[] high, float[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[]).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[]).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

#### Returns
[AroonOscResult](AroonOscResult.md 'TechnicalAnalysis\.Functions\.AroonOscResult')  
An AroonOscResult containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[],int)'></a>

## TAMath\.AroonOsc\(int, int, float\[\], float\[\], int\) Method

Calculates the Aroon Oscillator \(AROONOSC\) which measures the strength of a trend and likelihood of continuation\.

```csharp
public static TechnicalAnalysis.Functions.AroonOscResult AroonOsc(int startIdx, int endIdx, float[] high, float[] low, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[],int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[],int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AroonOsc(int,int,float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 14\)\.

#### Returns
[AroonOscResult](AroonOscResult.md 'TechnicalAnalysis\.Functions\.AroonOscResult')  
An AroonOscResult containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.