#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.T3Lookback\(int, double\) Method

Returns the lookback period required for T3 calculation\.

```csharp
public static int T3Lookback(int optInTimePeriod, double optInVFactor);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.T3Lookback(int,double).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the T3 calculation\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.T3Lookback(int,double).optInVFactor'></a>

`optInVFactor` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Volume Factor controls the smoothing\. Valid range: 0\.0 to 1\.0\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of historical data points required before the first valid T3 value can be calculated, or \-1 if parameters are invalid\.