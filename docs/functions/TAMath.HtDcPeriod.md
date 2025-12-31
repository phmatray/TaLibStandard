#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.HtDcPeriod Method

| Overloads | |
| :--- | :--- |
| [HtDcPeriod\(int, int, double\[\]\)](TAMath.HtDcPeriod.md#TechnicalAnalysis.Functions.TAMath.HtDcPeriod(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtDcPeriod\(int, int, double\[\]\)') | Calculates the Hilbert Transform \- Dominant Cycle Period for the input price data\. |
| [HtDcPeriod\(int, int, float\[\]\)](TAMath.HtDcPeriod.md#TechnicalAnalysis.Functions.TAMath.HtDcPeriod(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtDcPeriod\(int, int, float\[\]\)') | Calculates the Hilbert Transform \- Dominant Cycle Period for the input price data\. |

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPeriod(int,int,double[])'></a>

## TAMath\.HtDcPeriod\(int, int, double\[\]\) Method

Calculates the Hilbert Transform \- Dominant Cycle Period for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtDcPeriodResult HtDcPeriod(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPeriod(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPeriod(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPeriod(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

#### Returns
[HtDcPeriodResult](HtDcPeriodResult.md 'TechnicalAnalysis\.Functions\.HtDcPeriodResult')  
An HtDcPeriodResult containing the calculated dominant cycle period values\.

### Remarks
The Hilbert Transform \- Dominant Cycle Period is used to identify the dominant 
market cycle period\. It uses digital signal processing techniques to measure 
cycle periods in the price data\. This indicator helps traders identify the 
current market rhythm and can be used to optimize other indicators' parameters\.

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPeriod(int,int,float[])'></a>

## TAMath\.HtDcPeriod\(int, int, float\[\]\) Method

Calculates the Hilbert Transform \- Dominant Cycle Period for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtDcPeriodResult HtDcPeriod(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPeriod(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPeriod(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPeriod(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

#### Returns
[HtDcPeriodResult](HtDcPeriodResult.md 'TechnicalAnalysis\.Functions\.HtDcPeriodResult')  
An HtDcPeriodResult containing the calculated dominant cycle period values\.

### Remarks
This overload accepts float input and converts it to double for calculation\.