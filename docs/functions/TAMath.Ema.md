#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Ema Method

| Overloads | |
| :--- | :--- |
| [Ema\(int, int, double\[\], int\)](TAMath.Ema.md#TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Ema\(int, int, double\[\], int\)') | Calculates the Exponential Moving Average \(EMA\) for the specified range of data\. |
| [Ema\(int, int, double\[\]\)](TAMath.Ema.md#TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Ema\(int, int, double\[\]\)') | Calculates the Exponential Moving Average \(EMA\) using a default period of 30\. |
| [Ema\(int, int, float\[\], int\)](TAMath.Ema.md#TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Ema\(int, int, float\[\], int\)') | Calculates the Exponential Moving Average \(EMA\) for float input data\. |
| [Ema\(int, int, float\[\]\)](TAMath.Ema.md#TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Ema\(int, int, float\[\]\)') | Calculates the Exponential Moving Average \(EMA\) for float input data using a default period of 30\. |

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int)'></a>

## TAMath\.Ema\(int, int, double\[\], int\) Method

Calculates the Exponential Moving Average \(EMA\) for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.EmaResult Ema(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the EMA calculation\. Default is 30\.

#### Returns
[EmaResult](EmaResult.md 'TechnicalAnalysis\.Functions\.EmaResult')  
An EmaResult object containing the calculated values and metadata\.

### Remarks
The Exponential Moving Average gives more weight to recent prices, making it more responsive
to new information compared to the Simple Moving Average\. The EMA is calculated using a
smoothing factor of 2/\(timePeriod \+ 1\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[])'></a>

## TAMath\.Ema\(int, int, double\[\]\) Method

Calculates the Exponential Moving Average \(EMA\) using a default period of 30\.

```csharp
public static TechnicalAnalysis.Functions.EmaResult Ema(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

#### Returns
[EmaResult](EmaResult.md 'TechnicalAnalysis\.Functions\.EmaResult')  
An EmaResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int)'></a>

## TAMath\.Ema\(int, int, float\[\], int\) Method

Calculates the Exponential Moving Average \(EMA\) for float input data\.

```csharp
public static TechnicalAnalysis.Functions.EmaResult Ema(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the EMA calculation\.

#### Returns
[EmaResult](EmaResult.md 'TechnicalAnalysis\.Functions\.EmaResult')  
An EmaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[])'></a>

## TAMath\.Ema\(int, int, float\[\]\) Method

Calculates the Exponential Moving Average \(EMA\) for float input data using a default period of 30\.

```csharp
public static TechnicalAnalysis.Functions.EmaResult Ema(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ema(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

#### Returns
[EmaResult](EmaResult.md 'TechnicalAnalysis\.Functions\.EmaResult')  
An EmaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.