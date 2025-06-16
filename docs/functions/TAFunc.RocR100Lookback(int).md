#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.RocR100Lookback\(int\) Method

Calculates the lookback period required for the RocR100 calculation\.

```csharp
public static int RocR100Lookback(int optInTimePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.RocR100Lookback(int).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods used in the RocR100 calculation \(valid range: 1\-100000\)\.

#### Returns
[System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')  
The number of data points required before the first valid RocR100 value can be calculated\.
Returns \-1 if the time period is outside the valid range\.

### Remarks
The lookback period represents the number of data points that must be available
before the first RocR100 value can be calculated\. For RocR100, this is equal to the
specified time period, as we need at least that many historical values to compare
against the current value\.