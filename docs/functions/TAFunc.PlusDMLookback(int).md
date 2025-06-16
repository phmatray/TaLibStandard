#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.PlusDMLookback\(int\) Method

Calculates the lookback period for the Plus Directional Movement \(\+DM\) function\.

```csharp
public static int PlusDMLookback(int optInTimePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.PlusDMLookback(int).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The time period for the calculation\. Valid range: 1 to 100000\.

#### Returns
[System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')  
The number of historical data points required before the first valid \+DM value, or \-1 if parameters are invalid\.

### Remarks
The lookback period determines how many historical data points are needed before 
the function can produce its first valid output value\.

For optInTimePeriod = 1: Only 1 data point is needed \(raw \+DM\)\.
For optInTimePeriod \> 1: The lookback includes the smoothing period plus any unstable period\.