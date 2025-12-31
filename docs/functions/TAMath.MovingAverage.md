#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MovingAverage Method

| Overloads | |
| :--- | :--- |
| [MovingAverage\(int, int, double\[\], int, MAType\)](TAMath.MovingAverage.md#TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.MovingAverage\(int, int, double\[\], int, TechnicalAnalysis\.Common\.MAType\)') | Calculates a Moving Average of the specified type for the input price data\. |
| [MovingAverage\(int, int, float\[\], int, MAType\)](TAMath.MovingAverage.md#TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,float[],int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.MovingAverage\(int, int, float\[\], int, TechnicalAnalysis\.Common\.MAType\)') | Calculates a Moving Average of the specified type for the input price data\. |

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.MovingAverage\(int, int, double\[\], int, MAType\) Method

Calculates a Moving Average of the specified type for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.MovingAverageResult MovingAverage(int startIdx, int endIdx, double[] real, int timePeriod=30, TechnicalAnalysis.Common.MAType maType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 30\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to calculate \(default: SMA\)\.

#### Returns
[MovingAverageResult](MovingAverageResult.md 'TechnicalAnalysis\.Functions\.MovingAverageResult')  
A MovingAverageResult containing the calculated moving average values\.

### Remarks
This function supports multiple moving average types including:
\- Simple Moving Average \(SMA\)
\- Exponential Moving Average \(EMA\)
\- Weighted Moving Average \(WMA\)
\- Double Exponential Moving Average \(DEMA\)
\- Triple Exponential Moving Average \(TEMA\)
\- Triangular Moving Average \(TRIMA\)
\- Kaufman Adaptive Moving Average \(KAMA\)
\- MESA Adaptive Moving Average \(MAMA\)
\- T3 Moving Average

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,float[],int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.MovingAverage\(int, int, float\[\], int, MAType\) Method

Calculates a Moving Average of the specified type for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.MovingAverageResult MovingAverage(int startIdx, int endIdx, float[] real, int timePeriod=30, TechnicalAnalysis.Common.MAType maType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,float[],int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,float[],int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,float[],int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,float[],int,TechnicalAnalysis.Common.MAType).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 30\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverage(int,int,float[],int,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to calculate \(default: SMA\)\.

#### Returns
[MovingAverageResult](MovingAverageResult.md 'TechnicalAnalysis\.Functions\.MovingAverageResult')  
A MovingAverageResult containing the calculated moving average values\.

### Remarks
This overload accepts float input and converts it to double for calculation\.