#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Trix Method

| Overloads | |
| :--- | :--- |
| [Trix\(int, int, double\[\]\)](TAMath.Trix.md#TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Trix\(int, int, double\[\]\)') | Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator using the default time period\. |
| [Trix\(int, int, double\[\], int\)](TAMath.Trix.md#TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Trix\(int, int, double\[\], int\)') | Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator\. |
| [Trix\(int, int, float\[\]\)](TAMath.Trix.md#TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Trix\(int, int, float\[\]\)') | Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator using float arrays and the default time period\. |
| [Trix\(int, int, float\[\], int\)](TAMath.Trix.md#TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Trix\(int, int, float\[\], int\)') | Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[])'></a>

## TAMath\.Trix\(int, int, double\[\]\) Method

Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator using the default time period\.

```csharp
public static TechnicalAnalysis.Functions.TrixResult Trix(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\)\.

#### Returns
[TrixResult](TrixResult.md 'TechnicalAnalysis\.Functions\.TrixResult')  
A TrixResult object containing the calculated values\.

### Remarks
Uses the default time period of 30\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[],int)'></a>

## TAMath\.Trix\(int, int, double\[\], int\) Method

Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.TrixResult Trix(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the exponential moving average \(default: 30\)\.

#### Returns
[TrixResult](TrixResult.md 'TechnicalAnalysis\.Functions\.TrixResult')  
A TrixResult object containing the calculated values\.

### Remarks
TRIX is a momentum oscillator that displays the percent rate of change of a triple exponentially smoothed moving average\.
It filters out insignificant price movements and is designed to keep you in trends equal to or shorter than the number of periods specified\.
TRIX oscillates around a zero line and can be used to identify oversold and overbought markets, and as a momentum indicator\.
Positive values indicate an uptrend, while negative values indicate a downtrend\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[])'></a>

## TAMath\.Trix\(int, int, float\[\]\) Method

Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator using float arrays and the default time period\.

```csharp
public static TechnicalAnalysis.Functions.TrixResult Trix(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\)\.

#### Returns
[TrixResult](TrixResult.md 'TechnicalAnalysis\.Functions\.TrixResult')  
A TrixResult object containing the calculated values\.

### Remarks
Uses the default time period of 30\. This overload accepts float arrays and converts them to double arrays\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[],int)'></a>

## TAMath\.Trix\(int, int, float\[\], int\) Method

Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.TrixResult Trix(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the exponential moving average\.

#### Returns
[TrixResult](TrixResult.md 'TechnicalAnalysis\.Functions\.TrixResult')  
A TrixResult object containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
This may result in a minor performance overhead due to the conversion process\.