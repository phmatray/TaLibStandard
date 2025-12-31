#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Tema Method

| Overloads | |
| :--- | :--- |
| [Tema\(int, int, double\[\], int\)](TAMath.Tema.md#TechnicalAnalysis.Functions.TAMath.Tema(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Tema\(int, int, double\[\], int\)') | Calculates the Triple Exponential Moving Average \(TEMA\) for the specified range of data\. |
| [Tema\(int, int, float\[\], int\)](TAMath.Tema.md#TechnicalAnalysis.Functions.TAMath.Tema(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Tema\(int, int, float\[\], int\)') | Calculates the Triple Exponential Moving Average \(TEMA\) for float input data\. |

<a name='TechnicalAnalysis.Functions.TAMath.Tema(int,int,double[],int)'></a>

## TAMath\.Tema\(int, int, double\[\], int\) Method

Calculates the Triple Exponential Moving Average \(TEMA\) for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.TemaResult Tema(int startIdx, int endIdx, double[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Tema(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Tema(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Tema(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Tema(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the TEMA calculation\. Default is 30\.

#### Returns
[TemaResult](TemaResult.md 'TechnicalAnalysis\.Functions\.TemaResult')  
A TemaResult object containing the calculated values and metadata\.

### Remarks
The Triple Exponential Moving Average \(TEMA\) was developed by Patrick Mulloy to reduce the lag
inherent in moving averages\. It uses a combination of a single, double, and triple exponential
moving average\. The formula is: TEMA = 3\*EMA \- 3\*EMA\(EMA\) \+ EMA\(EMA\(EMA\)\)\.
TEMA is more responsive to price changes than DEMA or traditional moving averages\.

<a name='TechnicalAnalysis.Functions.TAMath.Tema(int,int,float[],int)'></a>

## TAMath\.Tema\(int, int, float\[\], int\) Method

Calculates the Triple Exponential Moving Average \(TEMA\) for float input data\.

```csharp
public static TechnicalAnalysis.Functions.TemaResult Tema(int startIdx, int endIdx, float[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Tema(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Tema(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Tema(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.Tema(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the TEMA calculation\. Default is 30\.

#### Returns
[TemaResult](TemaResult.md 'TechnicalAnalysis\.Functions\.TemaResult')  
A TemaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.