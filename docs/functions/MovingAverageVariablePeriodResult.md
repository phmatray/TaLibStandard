#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MovingAverageVariablePeriodResult Class

Represents the result of calculating a Moving Average with Variable Period \(MAVP\) indicator\.

```csharp
public record MovingAverageVariablePeriodResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; MovingAverageVariablePeriodResult

### Remarks
The Moving Average Variable Period indicator is an adaptive moving average that dynamically
adjusts its lookback period based on an external input array\. This allows the moving average
to become more or less responsive to price changes based on market conditions or other indicators,
providing a more flexible smoothing mechanism than fixed\-period moving averages\.

| Constructors | |
| :--- | :--- |
| [MovingAverageVariablePeriodResult\(RetCode, int, int, double\[\]\)](MovingAverageVariablePeriodResult.MovingAverageVariablePeriodResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MovingAverageVariablePeriodResult\.MovingAverageVariablePeriodResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MovingAverageVariablePeriodResult](MovingAverageVariablePeriodResult.md 'TechnicalAnalysis\.Functions\.MovingAverageVariablePeriodResult') class\. |
