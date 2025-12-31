#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.HtDcPhaseLookback\(\) Method

Returns the lookback period required for the Hilbert Transform \- Dominant Cycle Phase calculation\.

```csharp
public static int HtDcPhaseLookback();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of historical data points required before the first valid HtDcPhase value can be calculated\.

### Remarks
The lookback period for HtDcPhase consists of:
\- A fixed component of 63 bars for the Hilbert Transform calculations
\- An additional unstable period that can be configured via TACore\.Globals\.UnstablePeriod\[FuncUnstId\.HtDcPhase\]

The default lookback is 63 bars, but this can be increased if you require more stable results
by setting a larger unstable period for the HtDcPhase function\.