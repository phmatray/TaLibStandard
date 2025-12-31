#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.BollingerBandsLookback\(int, MAType\) Method

Returns the lookback period required for Bollinger Bands calculation\.

```csharp
public static int BollingerBandsLookback(int optInTimePeriod, TechnicalAnalysis.Common.MAType optInMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBandsLookback(int,TechnicalAnalysis.Common.MAType).optInTimePeriod'></a>

`optInTimePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the moving average calculation\. Valid range: 2 to 100000\.

<a name='TechnicalAnalysis.Functions.TAFunc.BollingerBandsLookback(int,TechnicalAnalysis.Common.MAType).optInMAType'></a>

`optInMAType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use \(SMA, EMA, etc\.\)\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of historical data points required before the first valid Bollinger Bands value can be calculated, or \-1 if parameters are invalid\.