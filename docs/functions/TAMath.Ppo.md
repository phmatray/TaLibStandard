#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Ppo Method

| Overloads | |
| :--- | :--- |
| [Ppo\(int, int, double\[\], int, int, MAType\)](TAMath.Ppo.md#TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.Ppo\(int, int, double\[\], int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Percentage Price Oscillator \(PPO\) which shows the percentage difference between two moving averages\. |
| [Ppo\(int, int, double\[\]\)](TAMath.Ppo.md#TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Ppo\(int, int, double\[\]\)') | Calculates the Percentage Price Oscillator \(PPO\) using default parameters\. |
| [Ppo\(int, int, float\[\], int, int, MAType\)](TAMath.Ppo.md#TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.Ppo\(int, int, float\[\], int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Percentage Price Oscillator \(PPO\) which shows the percentage difference between two moving averages\. |
| [Ppo\(int, int, float\[\]\)](TAMath.Ppo.md#TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Ppo\(int, int, float\[\]\)') | Calculates the Percentage Price Oscillator \(PPO\) using default parameters\. |

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.Ppo\(int, int, double\[\], int, int, MAType\) Method

Calculates the Percentage Price Oscillator \(PPO\) which shows the percentage difference between two moving averages\.

```csharp
public static TechnicalAnalysis.Functions.PpoResult Ppo(int startIdx, int endIdx, double[] real, int fastPeriod, int slowPeriod, TechnicalAnalysis.Common.MAType maType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).fastPeriod'></a>

`fastPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for the fast moving average \(default: 12\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).slowPeriod'></a>

`slowPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for the slow moving average \(default: 26\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[],int,int,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use \(default: Simple Moving Average\)\.

#### Returns
[PpoResult](PpoResult.md 'TechnicalAnalysis\.Functions\.PpoResult')  
A PpoResult containing the calculated values and metadata\.

### Remarks
The PPO is calculated as: \(\(Fast MA \- Slow MA\) / Slow MA\) \* 100\.
Unlike the APO \(Absolute Price Oscillator\), the PPO provides a percentage\-based measure,
making it useful for comparing momentum across different securities regardless of their price levels\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[])'></a>

## TAMath\.Ppo\(int, int, double\[\]\) Method

Calculates the Percentage Price Oscillator \(PPO\) using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.PpoResult Ppo(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

#### Returns
[PpoResult](PpoResult.md 'TechnicalAnalysis\.Functions\.PpoResult')  
A PpoResult containing the calculated values and metadata\.

### Remarks
Uses default values: fastPeriod=12, slowPeriod=26, maType=Simple Moving Average\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.Ppo\(int, int, float\[\], int, int, MAType\) Method

Calculates the Percentage Price Oscillator \(PPO\) which shows the percentage difference between two moving averages\.

```csharp
public static TechnicalAnalysis.Functions.PpoResult Ppo(int startIdx, int endIdx, float[] real, int fastPeriod, int slowPeriod, TechnicalAnalysis.Common.MAType maType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).fastPeriod'></a>

`fastPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for the fast moving average\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).slowPeriod'></a>

`slowPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods for the slow moving average\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[],int,int,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use\.

#### Returns
[PpoResult](PpoResult.md 'TechnicalAnalysis\.Functions\.PpoResult')  
A PpoResult containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[])'></a>

## TAMath\.Ppo\(int, int, float\[\]\) Method

Calculates the Percentage Price Oscillator \(PPO\) using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.PpoResult Ppo(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Ppo(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(usually closing prices\)\.

#### Returns
[PpoResult](PpoResult.md 'TechnicalAnalysis\.Functions\.PpoResult')  
A PpoResult containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.
Uses default values: fastPeriod=12, slowPeriod=26, maType=Simple Moving Average\.