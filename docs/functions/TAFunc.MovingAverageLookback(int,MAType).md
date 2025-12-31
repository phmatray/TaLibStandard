#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MovingAverageLookback\(int, MAType\) Method

Calculates the lookback period required for a moving average calculation\.

```csharp
public static int MovingAverageLookback(int optInTimePeriod, TechnicalAnalysis.Common.MAType optInMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageLookback(int,TechnicalAnalysis.Common.MAType).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the moving average calculation\.
Valid range: 1 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.MovingAverageLookback(int,TechnicalAnalysis.Common.MAType).optInMAType'></a>

`optInMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to calculate the lookback for\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of data points required before the first moving average value can be calculated\.
Returns \-1 if the time period is outside the valid range\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when an unsupported MAType is specified\.

### Example

```csharp
// Get lookback for a 20-period EMA
int lookback = TAFunc.MovingAverageLookback(20, MAType.Ema);
// lookback will be 19 (20 - 1)

// Get lookback for a 10-period DEMA
int lookbackDema = TAFunc.MovingAverageLookback(10, MAType.Dema);
// lookbackDema will be larger due to the double exponential smoothing
```

### Remarks

The lookback period represents the number of data points needed before the first valid
moving average value can be calculated. This varies depending on the type of moving average
and the specified time period.

Different moving average types require different amounts of historical data:
- Simple averages (SMA, WMA) need exactly the time period amount
- Exponential averages (EMA, DEMA, TEMA) may need more data for stability
- Adaptive averages (KAMA, MAMA) have their own specific requirements

For time period of 1, the lookback is always 0 as no historical data is needed.