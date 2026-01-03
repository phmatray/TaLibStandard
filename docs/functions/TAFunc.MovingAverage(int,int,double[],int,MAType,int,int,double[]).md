#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MovingAverage\(int, int, double\[\], int, MAType, int, int, double\[\]\) Method

Calculates a moving average with the flexibility to choose from multiple moving average types\.

```csharp
public static TechnicalAnalysis.Common.RetCode MovingAverage(int startIdx, int endIdx, in double[] inReal, in int optInTimePeriod, in TechnicalAnalysis.Common.MAType optInMAType, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the input data\. Must be non\-negative\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the input data\. Must be greater than or equal to startIdx\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values to calculate the moving average from\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,int,double[]).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the moving average calculation\. 
Valid range: 1 to 100000\. When set to 1, input values are copied directly to output\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,int,double[]).optInMAType'></a>

`optInMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to calculate\. Each type has different characteristics
regarding smoothing, lag, and responsiveness to price changes\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Output parameter that indicates the index in the input array corresponding to the first output value\.
This accounts for any lookback period required by the chosen moving average type\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Output parameter that indicates the number of elements written to the output array\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverage(int,int,double[],int,TechnicalAnalysis.Common.MAType,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array containing the calculated moving average values\. The array must be pre\-allocated
with sufficient size to hold the results\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode') indicating the success or failure of the operation:
\- Success: Calculation completed successfully
\- OutOfRangeStartIndex: startIdx is less than 0
\- OutOfRangeEndIndex: endIdx is less than 0 or less than startIdx
\- BadParam: Invalid parameters \(null arrays, invalid time period, or unsupported MA type\)

### Example

```csharp
double[] prices = { 10.0, 12.0, 11.0, 13.0, 14.0, 15.0, 14.0, 13.0 };
double[] smaOutput = new double[prices.Length];
int outBegIdx = 0;
int outNBElement = 0;

// Calculate a 3-period Simple Moving Average
RetCode result = TAFunc.MovingAverage(
    0, prices.Length - 1, prices, 3, MAType.Sma,
    ref outBegIdx, ref outNBElement, ref smaOutput);
```

### Remarks

The MovingAverage function provides a unified interface to calculate various types of moving averages
based on the specified MAType. This function acts as a dispatcher that routes to the appropriate
moving average implementation.

Supported moving average types include:
- SMA (Simple Moving Average): Equal weight to all values in the period
- EMA (Exponential Moving Average): More weight to recent values
- WMA (Weighted Moving Average): Linear weights favoring recent values
- DEMA (Double Exponential Moving Average): Reduced lag version of EMA
- TEMA (Triple Exponential Moving Average): Further reduced lag
- TRIMA (Triangular Moving Average): Double smoothed SMA
- KAMA (Kaufman Adaptive Moving Average): Adapts to market volatility
- MAMA (MESA Adaptive Moving Average): Uses phase and amplitude adjustments
- T3 (Tillson T3): Smooth moving average with reduced lag

Special behavior: When optInTimePeriod is 1, the function simply copies the input values
to the output array, as no averaging is needed.