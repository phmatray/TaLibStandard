#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.LinearRegSlopeLookback\(int\) Method

Returns the lookback period required for Linear Regression Slope calculation\.

```csharp
public static int LinearRegSlopeLookback(int optInTimePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.LinearRegSlopeLookback(int).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for the linear regression slope calculation\. Valid range: 2 to 100000\.

#### Returns
[System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')  
The number of historical data points required before the first valid Linear Regression Slope value can be calculated, or \-1 if parameters are invalid\.