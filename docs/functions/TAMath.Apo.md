#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Apo Method

| Overloads | |
| :--- | :--- |
| [Apo\(int, int, double\[\]\)](TAMath.Apo.md#TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Apo\(int, int, double\[\]\)') | Calculates the Absolute Price Oscillator \(APO\) using default parameters\. |
| [Apo\(int, int, double\[\], int, int, MAType\)](TAMath.Apo.md#TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.Apo\(int, int, double\[\], int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Absolute Price Oscillator \(APO\) which shows the difference between two moving averages\. |
| [Apo\(int, int, float\[\]\)](TAMath.Apo.md#TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Apo\(int, int, float\[\]\)') | Calculates the Absolute Price Oscillator \(APO\) using default parameters\. |
| [Apo\(int, int, float\[\], int, int, MAType\)](TAMath.Apo.md#TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.Apo\(int, int, float\[\], int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Absolute Price Oscillator \(APO\) which shows the difference between two moving averages\. |

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[])'></a>

## TAMath\.Apo\(int, int, double\[\]\) Method

Calculates the Absolute Price Oscillator \(APO\) using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.ApoResult Apo(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(usually closing prices\)\.

#### Returns
[ApoResult](ApoResult.md 'TechnicalAnalysis\.Functions\.ApoResult')  
An ApoResult containing the calculated values and metadata\.

### Remarks
Uses default values: fastPeriod=12, slowPeriod=26, maType=Simple Moving Average\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.Apo\(int, int, double\[\], int, int, MAType\) Method

Calculates the Absolute Price Oscillator \(APO\) which shows the difference between two moving averages\.

```csharp
public static TechnicalAnalysis.Functions.ApoResult Apo(int startIdx, int endIdx, double[] real, int fastPeriod, int slowPeriod, TechnicalAnalysis.Common.MAType maType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).fastPeriod'></a>

`fastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the fast moving average \(default: 12\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).slowPeriod'></a>

`slowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the slow moving average \(default: 26\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use \(default: Simple Moving Average\)\.

#### Returns
[ApoResult](ApoResult.md 'TechnicalAnalysis\.Functions\.ApoResult')  
An ApoResult containing the calculated values and metadata\.

### Remarks
The APO is calculated as: Fast MA \- Slow MA\.
Unlike the PPO \(Percentage Price Oscillator\), the APO provides the absolute difference,
making it useful for comparing momentum across different time periods of the same security\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[])'></a>

## TAMath\.Apo\(int, int, float\[\]\) Method

Calculates the Absolute Price Oscillator \(APO\) using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.ApoResult Apo(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(usually closing prices\)\.

#### Returns
[ApoResult](ApoResult.md 'TechnicalAnalysis\.Functions\.ApoResult')  
An ApoResult containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.
Uses default values: fastPeriod=12, slowPeriod=26, maType=Simple Moving Average\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.Apo\(int, int, float\[\], int, int, MAType\) Method

Calculates the Absolute Price Oscillator \(APO\) which shows the difference between two moving averages\.

```csharp
public static TechnicalAnalysis.Functions.ApoResult Apo(int startIdx, int endIdx, float[] real, int fastPeriod, int slowPeriod, TechnicalAnalysis.Common.MAType maType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).fastPeriod'></a>

`fastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the fast moving average\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).slowPeriod'></a>

`slowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the slow moving average\.

<a name='TechnicalAnalysis.Functions.TAMath.Apo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use\.

#### Returns
[ApoResult](ApoResult.md 'TechnicalAnalysis\.Functions\.ApoResult')  
An ApoResult containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.