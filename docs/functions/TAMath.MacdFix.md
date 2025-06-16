#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MacdFix Method

| Overloads | |
| :--- | :--- |
| [MacdFix\(int, int, double\[\], int\)](TAMath.MacdFix.md#TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MacdFix\(int, int, double\[\], int\)') | Calculates the Fixed MACD indicator using the standard 12/26 period configuration\. |
| [MacdFix\(int, int, double\[\]\)](TAMath.MacdFix.md#TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.MacdFix\(int, int, double\[\]\)') | Calculates the Fixed MACD indicator using default signal period\. |
| [MacdFix\(int, int, float\[\], int\)](TAMath.MacdFix.md#TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MacdFix\(int, int, float\[\], int\)') | Calculates the Fixed MACD indicator using the standard 12/26 period configuration\. |
| [MacdFix\(int, int, float\[\]\)](TAMath.MacdFix.md#TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.MacdFix\(int, int, float\[\]\)') | Calculates the Fixed MACD indicator using default signal period\. |

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,double[],int)'></a>

## TAMath\.MacdFix\(int, int, double\[\], int\) Method

Calculates the Fixed MACD indicator using the standard 12/26 period configuration\.

```csharp
public static TechnicalAnalysis.Functions.MacdFixResult MacdFix(int startIdx, int endIdx, double[] real, int signalPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,double[],int).signalPeriod'></a>

`signalPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for the signal line EMA \(default: 9\)\.

#### Returns
[MacdFixResult](MacdFixResult.md 'TechnicalAnalysis\.Functions\.MacdFixResult')  
A MacdFixResult containing the MACD line, signal line, and histogram values\.

### Remarks
MACD Fix uses fixed fast period \(12\) and slow period \(26\) for the MACD calculation,
only allowing customization of the signal line period\. This maintains the traditional
MACD configuration while providing some flexibility for the signal line smoothing\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,double[])'></a>

## TAMath\.MacdFix\(int, int, double\[\]\) Method

Calculates the Fixed MACD indicator using default signal period\.

```csharp
public static TechnicalAnalysis.Functions.MacdFixResult MacdFix(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

#### Returns
[MacdFixResult](MacdFixResult.md 'TechnicalAnalysis\.Functions\.MacdFixResult')  
A MacdFixResult containing the MACD line, signal line, and histogram values\.

### Remarks
Uses fixed values: fastPeriod=12, slowPeriod=26, signalPeriod=9\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,float[],int)'></a>

## TAMath\.MacdFix\(int, int, float\[\], int\) Method

Calculates the Fixed MACD indicator using the standard 12/26 period configuration\.

```csharp
public static TechnicalAnalysis.Functions.MacdFixResult MacdFix(int startIdx, int endIdx, float[] real, int signalPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,float[],int).signalPeriod'></a>

`signalPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for the signal line EMA\.

#### Returns
[MacdFixResult](MacdFixResult.md 'TechnicalAnalysis\.Functions\.MacdFixResult')  
A MacdFixResult containing the MACD line, signal line, and histogram values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,float[])'></a>

## TAMath\.MacdFix\(int, int, float\[\]\) Method

Calculates the Fixed MACD indicator using default signal period\.

```csharp
public static TechnicalAnalysis.Functions.MacdFixResult MacdFix(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdFix(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

#### Returns
[MacdFixResult](MacdFixResult.md 'TechnicalAnalysis\.Functions\.MacdFixResult')  
A MacdFixResult containing the MACD line, signal line, and histogram values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.
Uses fixed values: fastPeriod=12, slowPeriod=26, signalPeriod=9\.