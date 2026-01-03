#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Ema Method

| Overloads | |
| :--- | :--- |
| [Ema\(int, int, double\[\], int\)](TAMath.Ema.md#TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Ema\(int, int, double\[\], int\)') | Calculates the Exponential Moving Average \(EMA\) for the specified range of data\. |
| [Ema\(int, int, float\[\], int\)](TAMath.Ema.md#TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Ema\(int, int, float\[\], int\)') | Calculates the Exponential Moving Average \(EMA\) for float input data\. |

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int)'></a>

## TAMath\.Ema\(int, int, double\[\], int\) Method

Calculates the Exponential Moving Average \(EMA\) for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.EmaResult Ema(int startIdx, int endIdx, double[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the EMA calculation\. Default is 30\.

#### Returns
[EmaResult](EmaResult.md 'TechnicalAnalysis\.Functions\.EmaResult')  
An EmaResult object containing the calculated values and metadata\.

### Remarks
The Exponential Moving Average gives more weight to recent prices, making it more responsive
to new information compared to the Simple Moving Average\. The EMA is calculated using a
smoothing factor of 2/\(timePeriod \+ 1\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int)'></a>

## TAMath\.Ema\(int, int, float\[\], int\) Method

Calculates the Exponential Moving Average \(EMA\) for float input data\.

```csharp
public static TechnicalAnalysis.Functions.EmaResult Ema(int startIdx, int endIdx, float[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the EMA calculation\. Default is 30\.

#### Returns
[EmaResult](EmaResult.md 'TechnicalAnalysis\.Functions\.EmaResult')  
An EmaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.