#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.HtTrendMode Method

| Overloads | |
| :--- | :--- |
| [HtTrendMode\(int, int, double\[\]\)](TAMath.HtTrendMode.md#TechnicalAnalysis.Functions.TAMath.HtTrendMode(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtTrendMode\(int, int, double\[\]\)') | Calculates the Hilbert Transform \- Trend vs Cycle Mode for the input price data\. |
| [HtTrendMode\(int, int, float\[\]\)](TAMath.HtTrendMode.md#TechnicalAnalysis.Functions.TAMath.HtTrendMode(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtTrendMode\(int, int, float\[\]\)') | Calculates the Hilbert Transform \- Trend vs Cycle Mode for the input price data\. |

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendMode(int,int,double[])'></a>

## TAMath\.HtTrendMode\(int, int, double\[\]\) Method

Calculates the Hilbert Transform \- Trend vs Cycle Mode for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtTrendModeResult HtTrendMode(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendMode(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendMode(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendMode(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

#### Returns
[HtTrendModeResult](HtTrendModeResult.md 'TechnicalAnalysis\.Functions\.HtTrendModeResult')  
An HtTrendModeResult containing integer values indicating market mode\.

### Remarks
The Hilbert Transform \- Trend vs Cycle Mode indicator determines whether the 
market is in a trending or cycling mode\. It returns integer values where:
0 indicates a cycling \(ranging\) market, and 1 indicates a trending market\.
This helps traders choose appropriate strategies \- trend\-following strategies 
work better in trending markets, while oscillators work better in cycling markets\.

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendMode(int,int,float[])'></a>

## TAMath\.HtTrendMode\(int, int, float\[\]\) Method

Calculates the Hilbert Transform \- Trend vs Cycle Mode for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtTrendModeResult HtTrendMode(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendMode(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendMode(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendMode(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

#### Returns
[HtTrendModeResult](HtTrendModeResult.md 'TechnicalAnalysis\.Functions\.HtTrendModeResult')  
An HtTrendModeResult containing integer values indicating market mode\.

### Remarks
This overload accepts float input and converts it to double for calculation\.