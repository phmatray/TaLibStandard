#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.HtPhasorLookback\(\) Method

Calculates the lookback period for the Hilbert Transform \- Phasor Components\.

```csharp
public static int HtPhasorLookback();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of data points required before the first valid output value\.

### Remarks
The lookback period consists of:
\- A fixed period of 32 bars for the Hilbert Transform calculation
\- Plus any additional unstable period configured for this function

The unstable period can be configured by modifying TACore\.Globals\.UnstablePeriod\[FuncUnstId\.HtPhasor\] to adjust
how many additional bars are needed for the algorithm to stabilize\. By default,
the unstable period is 0, making the total lookback period 32 bars\.

This lookback period ensures that the Hilbert Transform has sufficient data to
accurately decompose the price series into its phase components\.