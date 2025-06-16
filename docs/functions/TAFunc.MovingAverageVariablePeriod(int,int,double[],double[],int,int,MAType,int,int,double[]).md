#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MovingAverageVariablePeriod\(int, int, double\[\], double\[\], int, int, MAType, int, int, double\[\]\) Method

Calculates a moving average where the period can vary for each data point\.

```csharp
public static TechnicalAnalysis.Common.RetCode MovingAverageVariablePeriod(int startIdx, int endIdx, in double[] inReal, in double[] inPeriods, in int optInMinPeriod, in int optInMaxPeriod, in TechnicalAnalysis.Common.MAType optInMAType, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the input data\. Must be non\-negative\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the input data\. Must be greater than or equal to startIdx\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values to calculate the variable period moving average from\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).inPeriods'></a>

`inPeriods` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of period values, one for each potential output point\. Values outside the min/max range
will be clamped to the nearest boundary\. The array should be at least as long as the input data\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).optInMinPeriod'></a>

`optInMinPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The minimum allowed period value\. Must be between 2 and 100000\.
Period values below this will be adjusted up to this minimum\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).optInMaxPeriod'></a>

`optInMaxPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The maximum allowed period value\. Must be between 2 and 100000\.
Period values above this will be adjusted down to this maximum\.
This also determines the overall lookback requirement\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).optInMAType'></a>

`optInMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to calculate\. The same MA type is used for all periods,
only the period length varies\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Output parameter that indicates the index in the input array corresponding to the first output value\.
This is based on the maximum period's lookback requirement\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Output parameter that indicates the number of elements written to the output array\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array containing the calculated variable period moving average values\.
Each value is calculated using the period specified in the corresponding inPeriods element\.
The array must be pre\-allocated with sufficient size\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode') indicating the success or failure of the operation:
\- Success: Calculation completed successfully
\- OutOfRangeStartIndex: startIdx is less than 0
\- OutOfRangeEndIndex: endIdx is less than 0 or less than startIdx
\- BadParam: Invalid parameters \(null arrays, invalid period ranges\)

### Example

```csharp
double[] prices = { 10.0, 12.0, 11.0, 13.0, 14.0, 15.0, 14.0, 13.0, 12.0, 11.0 };
double[] periods = { 3.0, 3.0, 4.0, 4.0, 5.0, 5.0, 3.0, 3.0, 4.0, 4.0 };
double[] output = new double[prices.Length];
int outBegIdx = 0;
int outNBElement = 0;

// Calculate variable period SMA with periods ranging from 3 to 5
RetCode result = TAFunc.MovingAverageVariablePeriod(
    0, prices.Length - 1, prices, periods, 
    2, 10, MAType.Sma,
    ref outBegIdx, ref outNBElement, ref output);

// Each output[i] is calculated using periods[i] as the moving average period
```

### Remarks

The MovingAverageVariablePeriod function provides a unique capability to calculate moving averages
where the period (window size) can change dynamically for each data point. This allows for adaptive
behavior based on market conditions or other criteria encoded in the periods array.

Key features:
- Each element in the output can have a different period for its moving average calculation
- Periods are constrained between optInMinPeriod and optInMaxPeriod for stability
- The function optimizes calculations by grouping identical periods together
- Supports all the same moving average types as the standard MovingAverage function

Common use cases:
- Adaptive moving averages that respond to volatility
- Custom trading systems that adjust period based on market conditions
- Multi-timeframe analysis within a single calculation

The function uses the maximum period (optInMaxPeriod) to determine the overall lookback requirement,
ensuring sufficient data is available for all possible period values.