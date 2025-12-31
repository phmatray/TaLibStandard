#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Trix Method

| Overloads | |
| :--- | :--- |
| [Trix\(int, int, double\[\], int\)](TAMath.Trix.md#TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Trix\(int, int, double\[\], int\)') | Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator\. |
| [Trix\(int, int, float\[\], int\)](TAMath.Trix.md#TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Trix\(int, int, float\[\], int\)') | Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,double[],int)'></a>

## TAMath\.Trix\(int, int, double\[\], int\) Method

Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.TrixResult Trix(int startIdx, int endIdx, double[] real, int timePeriod=30);
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

<a name='TechnicalAnalysis.Functions.TAMath.Trix(int,int,float[],int)'></a>

## TAMath\.Trix\(int, int, float\[\], int\) Method

Calculates the 1\-day Rate\-Of\-Change \(TRIX\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.TrixResult Trix(int startIdx, int endIdx, float[] real, int timePeriod=30);
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

The number of periods for the exponential moving average \(default: 30\)\.

#### Returns
[TrixResult](TrixResult.md 'TechnicalAnalysis\.Functions\.TrixResult')  
A TrixResult object containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
This may result in a minor performance overhead due to the conversion process\.