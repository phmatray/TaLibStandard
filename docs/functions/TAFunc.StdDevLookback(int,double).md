#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.StdDevLookback\(int, double\) Method

Returns the lookback period required for Standard Deviation calculation\.

```csharp
public static int StdDevLookback(int optInTimePeriod, double optInNbDev);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.StdDevLookback(int,double).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the calculation\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.StdDevLookback(int,double).optInNbDev'></a>

`optInNbDev` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Number of standard deviations \(not used in lookback calculation\)\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of historical data points required before the first valid standard deviation value can be calculated, or \-1 if parameters are invalid\.