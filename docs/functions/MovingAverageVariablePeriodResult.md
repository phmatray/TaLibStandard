#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MovingAverageVariablePeriodResult Class

Represents the result of calculating a Moving Average with Variable Period \(MAVP\) indicator\.

```csharp
public record MovingAverageVariablePeriodResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MovingAverageVariablePeriodResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MovingAverageVariablePeriodResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[MovingAverageVariablePeriodResult](MovingAverageVariablePeriodResult.md 'TechnicalAnalysis\.Functions\.MovingAverageVariablePeriodResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The Moving Average Variable Period indicator is an adaptive moving average that dynamically
adjusts its lookback period based on an external input array\. This allows the moving average
to become more or less responsive to price changes based on market conditions or other indicators,
providing a more flexible smoothing mechanism than fixed\-period moving averages\.

| Constructors | |
| :--- | :--- |
| [MovingAverageVariablePeriodResult\(RetCode, int, int, double\[\]\)](MovingAverageVariablePeriodResult.MovingAverageVariablePeriodResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MovingAverageVariablePeriodResult\.MovingAverageVariablePeriodResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MovingAverageVariablePeriodResult](MovingAverageVariablePeriodResult.md 'TechnicalAnalysis\.Functions\.MovingAverageVariablePeriodResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](MovingAverageVariablePeriodResult.Real.md 'TechnicalAnalysis\.Functions\.MovingAverageVariablePeriodResult\.Real') | Gets the array of variable period moving average values\. |
