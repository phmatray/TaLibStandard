#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MovingAverageVariablePeriodLookback\(int, int, MAType\) Method

Calculates the lookback period required for a variable period moving average calculation\.

```csharp
public static int MovingAverageVariablePeriodLookback(int optInMinPeriod, int optInMaxPeriod, TechnicalAnalysis.Common.MAType optInMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriodLookback(int,int,TechnicalAnalysis.Common.MAType).optInMinPeriod'></a>

`optInMinPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The minimum allowed period value\. Must be between 2 and 100000\.
This parameter is validated but does not affect the lookback calculation\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriodLookback(int,int,TechnicalAnalysis.Common.MAType).optInMaxPeriod'></a>

`optInMaxPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The maximum allowed period value\. Must be between 2 and 100000\.
This value determines the actual lookback period returned\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageVariablePeriodLookback(int,int,TechnicalAnalysis.Common.MAType).optInMAType'></a>

`optInMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average for which to calculate the lookback\.
Different MA types have different lookback requirements for the same period\.

#### Returns
[System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')  
The number of data points required before the first variable period moving average
value can be calculated\. This is based on the maximum period's requirements\.
Returns \-1 if either period parameter is outside the valid range\.

### Example

```csharp
// Get lookback for variable period EMA with periods ranging from 5 to 20
int lookback = TAFunc.MovingAverageVariablePeriodLookback(5, 20, MAType.Ema);
// lookback will be based on a 20-period EMA requirement

// For SMA with the same range
int lookbackSma = TAFunc.MovingAverageVariablePeriodLookback(5, 20, MAType.Sma);
// lookbackSma will be 19 (20 - 1)
```

### Remarks

The lookback period for a variable period moving average is determined by the maximum
possible period value (optInMaxPeriod). This ensures that sufficient historical data
is available regardless of which period values are actually used in the calculation.

The lookback calculation follows these rules:
- Uses the optInMaxPeriod to determine the worst-case lookback requirement
- The actual lookback depends on the specified moving average type
- Returns -1 if the period parameters are outside valid ranges

This conservative approach guarantees that the function will have enough data
to calculate any valid moving average within the specified period range.