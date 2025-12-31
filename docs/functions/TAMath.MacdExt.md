#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MacdExt Method

| Overloads | |
| :--- | :--- |
| [MacdExt\(int, int, double\[\], int, MAType, int, MAType, int, MAType\)](TAMath.MacdExt.md#TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.MacdExt\(int, int, double\[\], int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Extended MACD \(MACD with controllable MA type\) indicator\. |
| [MacdExt\(int, int, float\[\], int, MAType, int, MAType, int, MAType\)](TAMath.MacdExt.md#TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,float[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.MacdExt\(int, int, float\[\], int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates the Extended MACD \(MACD with controllable MA type\) indicator\. |

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.MacdExt\(int, int, double\[\], int, MAType, int, MAType, int, MAType\) Method

Calculates the Extended MACD \(MACD with controllable MA type\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.MacdExtResult MacdExt(int startIdx, int endIdx, double[] real, int fastPeriod=12, TechnicalAnalysis.Common.MAType fastMAType=TechnicalAnalysis.Common.MAType.Sma, int slowPeriod=26, TechnicalAnalysis.Common.MAType slowMAType=TechnicalAnalysis.Common.MAType.Sma, int signalPeriod=9, TechnicalAnalysis.Common.MAType signalMAType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).fastPeriod'></a>

`fastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the fast moving average \(default: 12\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).fastMAType'></a>

`fastMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use for the fast MA \(default: Simple MA\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowPeriod'></a>

`slowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the slow moving average \(default: 26\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowMAType'></a>

`slowMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use for the slow MA \(default: Simple MA\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).signalPeriod'></a>

`signalPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the signal line \(default: 9\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).signalMAType'></a>

`signalMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use for the signal line \(default: Simple MA\)\.

#### Returns
[MacdExtResult](MacdExtResult.md 'TechnicalAnalysis\.Functions\.MacdExtResult')  
A MacdExtResult containing the MACD line, signal line, and histogram values\.

### Remarks
MACD Extended allows you to specify the type of moving average for each component,
providing more flexibility than the standard MACD which uses only exponential moving averages\.
This can be useful for fine\-tuning the indicator's responsiveness to price changes\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,float[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.MacdExt\(int, int, float\[\], int, MAType, int, MAType, int, MAType\) Method

Calculates the Extended MACD \(MACD with controllable MA type\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.MacdExtResult MacdExt(int startIdx, int endIdx, float[] real, int fastPeriod=12, TechnicalAnalysis.Common.MAType fastMAType=TechnicalAnalysis.Common.MAType.Sma, int slowPeriod=26, TechnicalAnalysis.Common.MAType slowMAType=TechnicalAnalysis.Common.MAType.Sma, int signalPeriod=9, TechnicalAnalysis.Common.MAType signalMAType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,float[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,float[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,float[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(usually closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,float[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).fastPeriod'></a>

`fastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the fast moving average \(default: 12\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,float[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).fastMAType'></a>

`fastMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use for the fast MA \(default: Simple MA\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,float[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowPeriod'></a>

`slowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the slow moving average \(default: 26\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,float[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).slowMAType'></a>

`slowMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use for the slow MA \(default: Simple MA\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,float[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).signalPeriod'></a>

`signalPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the signal line \(default: 9\)\.

<a name='TechnicalAnalysis.Functions.TAMath.MacdExt(int,int,float[],int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType,int,TechnicalAnalysis.Common.MAType).signalMAType'></a>

`signalMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to use for the signal line \(default: Simple MA\)\.

#### Returns
[MacdExtResult](MacdExtResult.md 'TechnicalAnalysis\.Functions\.MacdExtResult')  
A MacdExtResult containing the MACD line, signal line, and histogram values\.

### Remarks
This overload accepts float arrays and converts them to double arrays for calculation\.