#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Dema Method

| Overloads | |
| :--- | :--- |
| [Dema\(int, int, double\[\], int\)](TAMath.Dema.md#TechnicalAnalysis.Functions.TAMath.Dema(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Dema\(int, int, double\[\], int\)') | Calculates the Double Exponential Moving Average \(DEMA\) for the specified range of data\. |
| [Dema\(int, int, double\[\]\)](TAMath.Dema.md#TechnicalAnalysis.Functions.TAMath.Dema(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Dema\(int, int, double\[\]\)') | Calculates the Double Exponential Moving Average \(DEMA\) using a default period of 30\. |
| [Dema\(int, int, float\[\], int\)](TAMath.Dema.md#TechnicalAnalysis.Functions.TAMath.Dema(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Dema\(int, int, float\[\], int\)') | Calculates the Double Exponential Moving Average \(DEMA\) for float input data\. |
| [Dema\(int, int, float\[\]\)](TAMath.Dema.md#TechnicalAnalysis.Functions.TAMath.Dema(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Dema\(int, int, float\[\]\)') | Calculates the Double Exponential Moving Average \(DEMA\) for float input data using a default period of 30\. |

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,double[],int)'></a>

## TAMath\.Dema\(int, int, double\[\], int\) Method

Calculates the Double Exponential Moving Average \(DEMA\) for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.DemaResult Dema(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the DEMA calculation\. Default is 30\.

#### Returns
[DemaResult](DemaResult.md 'TechnicalAnalysis\.Functions\.DemaResult')  
A DemaResult object containing the calculated values and metadata\.

### Remarks
The Double Exponential Moving Average \(DEMA\) is a technical indicator developed by Patrick Mulloy\.
It uses two exponential moving averages to eliminate lag\. The formula is: DEMA = 2 \* EMA \- EMA\(EMA\)\.
This makes DEMA more responsive to price changes than a traditional EMA or SMA\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,double[])'></a>

## TAMath\.Dema\(int, int, double\[\]\) Method

Calculates the Double Exponential Moving Average \(DEMA\) using a default period of 30\.

```csharp
public static TechnicalAnalysis.Functions.DemaResult Dema(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

#### Returns
[DemaResult](DemaResult.md 'TechnicalAnalysis\.Functions\.DemaResult')  
A DemaResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,float[],int)'></a>

## TAMath\.Dema\(int, int, float\[\], int\) Method

Calculates the Double Exponential Moving Average \(DEMA\) for float input data\.

```csharp
public static TechnicalAnalysis.Functions.DemaResult Dema(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the DEMA calculation\.

#### Returns
[DemaResult](DemaResult.md 'TechnicalAnalysis\.Functions\.DemaResult')  
A DemaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,float[])'></a>

## TAMath\.Dema\(int, int, float\[\]\) Method

Calculates the Double Exponential Moving Average \(DEMA\) for float input data using a default period of 30\.

```csharp
public static TechnicalAnalysis.Functions.DemaResult Dema(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Dema(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

#### Returns
[DemaResult](DemaResult.md 'TechnicalAnalysis\.Functions\.DemaResult')  
A DemaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.