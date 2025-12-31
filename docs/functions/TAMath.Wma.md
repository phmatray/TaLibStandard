#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Wma Method

| Overloads | |
| :--- | :--- |
| [Wma\(int, int, double\[\]\)](TAMath.Wma.md#TechnicalAnalysis.Functions.TAMath.Wma(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Wma\(int, int, double\[\]\)') | Calculates the Weighted Moving Average \(WMA\) using a default period of 30\. |
| [Wma\(int, int, double\[\], int\)](TAMath.Wma.md#TechnicalAnalysis.Functions.TAMath.Wma(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Wma\(int, int, double\[\], int\)') | Calculates the Weighted Moving Average \(WMA\) for the specified range of data\. |
| [Wma\(int, int, float\[\]\)](TAMath.Wma.md#TechnicalAnalysis.Functions.TAMath.Wma(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Wma\(int, int, float\[\]\)') | Calculates the Weighted Moving Average \(WMA\) for float input data using a default period of 30\. |
| [Wma\(int, int, float\[\], int\)](TAMath.Wma.md#TechnicalAnalysis.Functions.TAMath.Wma(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Wma\(int, int, float\[\], int\)') | Calculates the Weighted Moving Average \(WMA\) for float input data\. |

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,double[])'></a>

## TAMath\.Wma\(int, int, double\[\]\) Method

Calculates the Weighted Moving Average \(WMA\) using a default period of 30\.

```csharp
public static TechnicalAnalysis.Functions.WmaResult Wma(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values\.

#### Returns
[WmaResult](WmaResult.md 'TechnicalAnalysis\.Functions\.WmaResult')  
A WmaResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,double[],int)'></a>

## TAMath\.Wma\(int, int, double\[\], int\) Method

Calculates the Weighted Moving Average \(WMA\) for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.WmaResult Wma(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the WMA calculation\. Default is 30\.

#### Returns
[WmaResult](WmaResult.md 'TechnicalAnalysis\.Functions\.WmaResult')  
A WmaResult object containing the calculated values and metadata\.

### Remarks
The Weighted Moving Average assigns linearly increasing weights to more recent data points\.
The most recent value has a weight of n, the second most recent n\-1, and so on, where n is the time period\.
This makes the WMA more responsive to recent price changes than the Simple Moving Average\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,float[])'></a>

## TAMath\.Wma\(int, int, float\[\]\) Method

Calculates the Weighted Moving Average \(WMA\) for float input data using a default period of 30\.

```csharp
public static TechnicalAnalysis.Functions.WmaResult Wma(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values as floats\.

#### Returns
[WmaResult](WmaResult.md 'TechnicalAnalysis\.Functions\.WmaResult')  
A WmaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,float[],int)'></a>

## TAMath\.Wma\(int, int, float\[\], int\) Method

Calculates the Weighted Moving Average \(WMA\) for float input data\.

```csharp
public static TechnicalAnalysis.Functions.WmaResult Wma(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.Wma(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the WMA calculation\.

#### Returns
[WmaResult](WmaResult.md 'TechnicalAnalysis\.Functions\.WmaResult')  
A WmaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.