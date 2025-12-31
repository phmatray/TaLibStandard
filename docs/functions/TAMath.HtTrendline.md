#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.HtTrendline Method

| Overloads | |
| :--- | :--- |
| [HtTrendline\(int, int, double\[\]\)](TAMath.HtTrendline.md#TechnicalAnalysis.Functions.TAMath.HtTrendline(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtTrendline\(int, int, double\[\]\)') | Calculates the Hilbert Transform \- Instantaneous Trendline for the input price data\. |
| [HtTrendline\(int, int, float\[\]\)](TAMath.HtTrendline.md#TechnicalAnalysis.Functions.TAMath.HtTrendline(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtTrendline\(int, int, float\[\]\)') | Calculates the Hilbert Transform \- Instantaneous Trendline for the input price data\. |

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendline(int,int,double[])'></a>

## TAMath\.HtTrendline\(int, int, double\[\]\) Method

Calculates the Hilbert Transform \- Instantaneous Trendline for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtTrendlineResult HtTrendline(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendline(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendline(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendline(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

#### Returns
[HtTrendlineResult](HtTrendlineResult.md 'TechnicalAnalysis\.Functions\.HtTrendlineResult')  
An HtTrendlineResult containing the calculated trendline values\.

### Remarks
The Hilbert Transform \- Instantaneous Trendline removes the dominant cycle 
component from the price data, leaving only the trend component\. This creates 
a smooth trendline that adapts to market conditions with minimal lag\. It's 
particularly useful for identifying the underlying trend direction while 
filtering out cyclic price movements\.

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendline(int,int,float[])'></a>

## TAMath\.HtTrendline\(int, int, float\[\]\) Method

Calculates the Hilbert Transform \- Instantaneous Trendline for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtTrendlineResult HtTrendline(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendline(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendline(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtTrendline(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

#### Returns
[HtTrendlineResult](HtTrendlineResult.md 'TechnicalAnalysis\.Functions\.HtTrendlineResult')  
An HtTrendlineResult containing the calculated trendline values\.

### Remarks
This overload accepts float input and converts it to double for calculation\.