#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TrueRangeResult Class

Represents the result of the True Range \(TR\) indicator calculation\.
True Range is a volatility measure that captures the greatest of: current high minus low, absolute value of current high minus previous close, or absolute value of current low minus previous close\.

```csharp
public record TrueRangeResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.TrueRangeResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; TrueRangeResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[TrueRangeResult](TrueRangeResult.md 'TechnicalAnalysis\.Functions\.TrueRangeResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [TrueRangeResult\(RetCode, int, int, double\[\]\)](TrueRangeResult.TrueRangeResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.TrueRangeResult\.TrueRangeResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [TrueRangeResult](TrueRangeResult.md 'TechnicalAnalysis\.Functions\.TrueRangeResult') class\. |
