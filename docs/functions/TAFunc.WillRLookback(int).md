#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.WillRLookback\(int\) Method

Returns the lookback period required for Williams' %R calculation\.

```csharp
public static int WillRLookback(int optInTimePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.WillRLookback(int).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the calculation\. Valid range: 2 to 100000\.

#### Returns
[System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')  
The number of historical data points required before the first valid Williams' %R value can be calculated, or \-1 if parameters are invalid\.