#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MidPriceLookback\(int\) Method

Returns the lookback period for the MidPrice function\.

```csharp
public static int MidPriceLookback(int optInTimePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MidPriceLookback(int).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The time period for the calculation\. Valid range is 2 to 100000\.

#### Returns
[System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')  
The number of elements needed before the first valid value, or \-1 if the period is invalid\.