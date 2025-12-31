#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.MamaLookback\(double, double\) Method

Calculates the lookback period for the MAMA indicator\.

```csharp
public static int MamaLookback(double optInFastLimit, double optInSlowLimit);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.MamaLookback(double,double).optInFastLimit'></a>

`optInFastLimit` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Controls the maximum alpha for the fast\-moving average\. Range: 0\.01 to 0\.99\.

<a name='TechnicalAnalysis.Functions.TAFunc.MamaLookback(double,double).optInSlowLimit'></a>

`optInSlowLimit` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Controls the maximum alpha for the slow\-moving average\. Range: 0\.01 to 0\.99\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of historical data points needed before the first MAMA/FAMA values can be calculated, or \-1 if parameters are invalid\.

### Remarks
The MAMA indicator requires a significant lookback period due to its use of the Hilbert Transform
for cycle measurement\. The base lookback period is 32 bars plus any additional unstable period
configured for the MAMA function\.