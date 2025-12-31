#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.ZigZagLookback\(double\) Method

Calculates the lookback period for the ZigZag indicator\.

```csharp
public static int ZigZagLookback(double optInDeviation);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.ZigZagLookback(double).optInDeviation'></a>

`optInDeviation` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Minimum percentage price movement required for a reversal \(0\.0 to 100\.0\)\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of historical data points needed before the first ZigZag value can be calculated, or \-1 if the deviation is invalid\.

### Remarks
The ZigZag indicator requires at least 1 prior bar to establish an initial reference point
for determining subsequent peaks and troughs\.