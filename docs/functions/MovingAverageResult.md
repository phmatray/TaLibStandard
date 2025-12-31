#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MovingAverageResult Class

Represents the result of calculating a Moving Average indicator\.

```csharp
public record MovingAverageResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MovingAverageResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MovingAverageResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[MovingAverageResult](MovingAverageResult.md 'TechnicalAnalysis\.Functions\.MovingAverageResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
Moving averages are fundamental technical indicators that smooth price data by creating
a constantly updated average price over a specific period\. Various types of moving averages
\(Simple, Exponential, Weighted, etc\.\) can be calculated, each with different characteristics
for trend identification and signal generation\.

| Constructors | |
| :--- | :--- |
| [MovingAverageResult\(RetCode, int, int, double\[\]\)](MovingAverageResult.MovingAverageResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MovingAverageResult\.MovingAverageResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MovingAverageResult](MovingAverageResult.md 'TechnicalAnalysis\.Functions\.MovingAverageResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](MovingAverageResult.Real.md 'TechnicalAnalysis\.Functions\.MovingAverageResult\.Real') | Gets the array of moving average values\. |
