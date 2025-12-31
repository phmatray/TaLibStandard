#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.RocRLookback\(int\) Method

Calculates the lookback period required for the RocR calculation\.

```csharp
public static int RocRLookback(int optInTimePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.RocRLookback(int).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods used in the RocR calculation \(valid range: 1\-100000\)\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of data points required before the first valid RocR value can be calculated\.
Returns \-1 if the time period is outside the valid range\.

### Remarks
The lookback period represents the number of data points that must be available
before the first RocR value can be calculated\. For RocR, this is equal to the
specified time period, as we need at least that many historical values to compare
against the current value\.