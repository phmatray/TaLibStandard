#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Macd Method

| Overloads | |
| :--- | :--- |
| [Macd\(int, int, double\[\]\)](TAMath.Macd.md#TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Macd\(int, int, double\[\]\)') | Calculates the Moving Average Convergence Divergence \(MACD\) indicator using default parameters\. |
| [Macd\(int, int, double\[\], int, int, int\)](TAMath.Macd.md#TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[],int,int,int) 'TechnicalAnalysis\.Functions\.TAMath\.Macd\(int, int, double\[\], int, int, int\)') | Calculates the Moving Average Convergence Divergence \(MACD\) indicator\. |
| [Macd\(int, int, float\[\]\)](TAMath.Macd.md#TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Macd\(int, int, float\[\]\)') | Calculates the Moving Average Convergence Divergence \(MACD\) indicator using default parameters\. |
| [Macd\(int, int, float\[\], int, int, int\)](TAMath.Macd.md#TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[],int,int,int) 'TechnicalAnalysis\.Functions\.TAMath\.Macd\(int, int, float\[\], int, int, int\)') | Calculates the Moving Average Convergence Divergence \(MACD\) indicator\. |

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[])'></a>

## TAMath\.Macd\(int, int, double\[\]\) Method

Calculates the Moving Average Convergence Divergence \(MACD\) indicator using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.MacdResult Macd(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(usually closing prices\)\.

#### Returns
[MacdResult](MacdResult.md 'TechnicalAnalysis\.Functions\.MacdResult')  
A MacdResult containing the MACD line, signal line, and histogram values\.

### Remarks
Uses default values: fastPeriod=12, slowPeriod=26, signalPeriod=9\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[],int,int,int)'></a>

## TAMath\.Macd\(int, int, double\[\], int, int, int\) Method

Calculates the Moving Average Convergence Divergence \(MACD\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.MacdResult Macd(int startIdx, int endIdx, double[] real, int optInFastPeriod, int optInSlowPeriod, int optInSignalPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[],int,int,int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[],int,int,int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[],int,int,int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[],int,int,int).optInFastPeriod'></a>

`optInFastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the fast EMA \(default: 12\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[],int,int,int).optInSlowPeriod'></a>

`optInSlowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the slow EMA \(default: 26\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,double[],int,int,int).optInSignalPeriod'></a>

`optInSignalPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the signal line EMA \(default: 9\)\.

#### Returns
[MacdResult](MacdResult.md 'TechnicalAnalysis\.Functions\.MacdResult')  
A MacdResult containing the MACD line, signal line, and histogram values\.

### Remarks
The MACD is a trend\-following momentum indicator that shows the relationship between two moving averages\.
\- MACD Line: 12\-period EMA \- 26\-period EMA
\- Signal Line: 9\-period EMA of MACD Line
\- MACD Histogram: MACD Line \- Signal Line

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[])'></a>

## TAMath\.Macd\(int, int, float\[\]\) Method

Calculates the Moving Average Convergence Divergence \(MACD\) indicator using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.MacdResult Macd(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(usually closing prices\)\.

#### Returns
[MacdResult](MacdResult.md 'TechnicalAnalysis\.Functions\.MacdResult')  
A MacdResult containing the MACD line, signal line, and histogram values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.
Uses default values: fastPeriod=12, slowPeriod=26, signalPeriod=9\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[],int,int,int)'></a>

## TAMath\.Macd\(int, int, float\[\], int, int, int\) Method

Calculates the Moving Average Convergence Divergence \(MACD\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.MacdResult Macd(int startIdx, int endIdx, float[] real, int optInFastPeriod, int optInSlowPeriod, int optInSignalPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[],int,int,int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[],int,int,int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[],int,int,int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[],int,int,int).optInFastPeriod'></a>

`optInFastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the fast EMA\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[],int,int,int).optInSlowPeriod'></a>

`optInSlowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the slow EMA\.

<a name='TechnicalAnalysis.Functions.TAMath.Macd(int,int,float[],int,int,int).optInSignalPeriod'></a>

`optInSignalPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the signal line EMA\.

#### Returns
[MacdResult](MacdResult.md 'TechnicalAnalysis\.Functions\.MacdResult')  
A MacdResult containing the MACD line, signal line, and histogram values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.