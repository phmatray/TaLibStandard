#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MacdFixLookback\(int\) Method

Returns the lookback period required for MACDFIX calculation\.

```csharp
public static int MacdFixLookback(int optInSignalPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MacdFixLookback(int).optInSignalPeriod'></a>

`optInSignalPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the signal line EMA\. Valid range: 1 to 100000\.

#### Returns
[System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')  
The number of historical data points required before the first valid MACDFIX value can be calculated, or \-1 if the signal period parameter is invalid\.

### Remarks
The lookback period for MACDFIX is calculated based on:
\- The fixed 26\-period slow EMA \(since it's the longer of the two fixed EMAs\)
\- The signal line EMA period

The total lookback is the sum of the lookback periods for the 26\-period EMA
and the signal line EMA\. This ensures sufficient historical data is available
for accurate calculation of all MACDFIX components\.