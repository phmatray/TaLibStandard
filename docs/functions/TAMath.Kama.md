#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Kama Method

| Overloads | |
| :--- | :--- |
| [Kama\(int, int, double\[\]\)](TAMath.Kama.md#TechnicalAnalysis.Functions.TAMath.Kama(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Kama\(int, int, double\[\]\)') | Calculates the Kaufman Adaptive Moving Average \(KAMA\) using a default period of 30\. |
| [Kama\(int, int, double\[\], int\)](TAMath.Kama.md#TechnicalAnalysis.Functions.TAMath.Kama(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Kama\(int, int, double\[\], int\)') | Calculates the Kaufman Adaptive Moving Average \(KAMA\) for the specified range of data\. |
| [Kama\(int, int, float\[\]\)](TAMath.Kama.md#TechnicalAnalysis.Functions.TAMath.Kama(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Kama\(int, int, float\[\]\)') | Calculates the Kaufman Adaptive Moving Average \(KAMA\) for float input data using a default period of 30\. |
| [Kama\(int, int, float\[\], int\)](TAMath.Kama.md#TechnicalAnalysis.Functions.TAMath.Kama(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Kama\(int, int, float\[\], int\)') | Calculates the Kaufman Adaptive Moving Average \(KAMA\) for float input data\. |

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,double[])'></a>

## TAMath\.Kama\(int, int, double\[\]\) Method

Calculates the Kaufman Adaptive Moving Average \(KAMA\) using a default period of 30\.

```csharp
public static TechnicalAnalysis.Functions.KamaResult Kama(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values\.

#### Returns
[KamaResult](KamaResult.md 'TechnicalAnalysis\.Functions\.KamaResult')  
A KamaResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,double[],int)'></a>

## TAMath\.Kama\(int, int, double\[\], int\) Method

Calculates the Kaufman Adaptive Moving Average \(KAMA\) for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.KamaResult Kama(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the KAMA calculation\. Default is 30\.

#### Returns
[KamaResult](KamaResult.md 'TechnicalAnalysis\.Functions\.KamaResult')  
A KamaResult object containing the calculated values and metadata\.

### Remarks
The Kaufman Adaptive Moving Average \(KAMA\) was developed by Perry Kaufman\. It is designed to
account for market noise or volatility\. KAMA will closely follow prices when the price swings
are relatively small and the noise is low\. KAMA will adjust when the price swings widen and
follow prices from a greater distance\. This trend\-following indicator can be used to identify
the overall trend, time turning points and filter price movements\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,float[])'></a>

## TAMath\.Kama\(int, int, float\[\]\) Method

Calculates the Kaufman Adaptive Moving Average \(KAMA\) for float input data using a default period of 30\.

```csharp
public static TechnicalAnalysis.Functions.KamaResult Kama(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values as floats\.

#### Returns
[KamaResult](KamaResult.md 'TechnicalAnalysis\.Functions\.KamaResult')  
A KamaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,float[],int)'></a>

## TAMath\.Kama\(int, int, float\[\], int\) Method

Calculates the Kaufman Adaptive Moving Average \(KAMA\) for float input data\.

```csharp
public static TechnicalAnalysis.Functions.KamaResult Kama(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.Kama(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the KAMA calculation\.

#### Returns
[KamaResult](KamaResult.md 'TechnicalAnalysis\.Functions\.KamaResult')  
A KamaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.