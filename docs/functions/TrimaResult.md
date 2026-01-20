#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TrimaResult Class

Represents the result of calculating the Triangular Moving Average \(TRIMA\) indicator\.

```csharp
public record TrimaResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; TrimaResult

### Remarks
TRIMA is a double\-smoothed moving average that places greater weight on values in the
middle of the period\. It creates a smoother line than a simple moving average,
making it useful for identifying longer\-term trends while filtering out short\-term noise\.

| Constructors | |
| :--- | :--- |
| [TrimaResult\(RetCode, int, int, double\[\]\)](TrimaResult.TrimaResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.TrimaResult\.TrimaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [TrimaResult](TrimaResult.md 'TechnicalAnalysis\.Functions\.TrimaResult') class\. |
