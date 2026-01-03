#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Tsf Method

| Overloads | |
| :--- | :--- |
| [Tsf\(int, int, double\[\], int\)](TAMath.Tsf.md#TechnicalAnalysis.Functions.TAMath.Tsf(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Tsf\(int, int, double\[\], int\)') | Calculates the Time Series Forecast \(TSF\) indicator\. |
| [Tsf\(int, int, float\[\], int\)](TAMath.Tsf.md#TechnicalAnalysis.Functions.TAMath.Tsf(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Tsf\(int, int, float\[\], int\)') | Calculates the Time Series Forecast \(TSF\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Tsf(int,int,double[],int)'></a>

## TAMath\.Tsf\(int, int, double\[\], int\) Method

Calculates the Time Series Forecast \(TSF\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.TsfResult Tsf(int startIdx, int endIdx, double[] real, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Tsf(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Tsf(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Tsf(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Tsf(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the linear regression \(default: 14\)\.

#### Returns
[TsfResult](TsfResult.md 'TechnicalAnalysis\.Functions\.TsfResult')  
A TsfResult object containing the calculated values\.

### Remarks
The Time Series Forecast indicator is a linear regression calculation that plots the statistical trend of a security's price over time\.
It uses the least squares method to fit a straight line to the data for the selected period and then projects that line forward\.
TSF can be used to identify the underlying trend and potential support/resistance levels\.
The indicator attempts to predict future values based on historical linear regression analysis\.

<a name='TechnicalAnalysis.Functions.TAMath.Tsf(int,int,float[],int)'></a>

## TAMath\.Tsf\(int, int, float\[\], int\) Method

Calculates the Time Series Forecast \(TSF\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.TsfResult Tsf(int startIdx, int endIdx, float[] real, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Tsf(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Tsf(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Tsf(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Tsf(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the linear regression \(default: 14\)\.

#### Returns
[TsfResult](TsfResult.md 'TechnicalAnalysis\.Functions\.TsfResult')  
A TsfResult object containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
This may result in a minor performance overhead due to the conversion process\.