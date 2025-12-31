#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.ApoLookback\(int, int, MAType\) Method

Returns the lookback period required for APO calculation\.

```csharp
public static int ApoLookback(int optInFastPeriod, int optInSlowPeriod, TechnicalAnalysis.Common.MAType optInMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.ApoLookback(int,int,TechnicalAnalysis.Common.MAType).optInFastPeriod'></a>

`optInFastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the fast moving average\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.ApoLookback(int,int,TechnicalAnalysis.Common.MAType).optInSlowPeriod'></a>

`optInSlowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the slow moving average\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.ApoLookback(int,int,TechnicalAnalysis.Common.MAType).optInMAType'></a>

`optInMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of historical data points required before the first valid APO value can be calculated, or \-1 if parameters are invalid\.