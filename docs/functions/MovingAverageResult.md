#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MovingAverageResult Class

Represents the result of calculating a Moving Average indicator\.

```csharp
public record MovingAverageResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; MovingAverageResult

### Remarks
Moving averages are fundamental technical indicators that smooth price data by creating
a constantly updated average price over a specific period\. Various types of moving averages
\(Simple, Exponential, Weighted, etc\.\) can be calculated, each with different characteristics
for trend identification and signal generation\.

| Constructors | |
| :--- | :--- |
| [MovingAverageResult\(RetCode, int, int, double\[\]\)](MovingAverageResult.MovingAverageResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MovingAverageResult\.MovingAverageResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MovingAverageResult](MovingAverageResult.md 'TechnicalAnalysis\.Functions\.MovingAverageResult') class\. |
