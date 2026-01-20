#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TrixResult Class

Represents the result of calculating the TRIX indicator\.

```csharp
public record TrixResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; TrixResult

### Remarks
TRIX is a momentum oscillator that displays the rate of change of a triple exponentially smoothed moving average\.
It filters out insignificant price movements and helps identify oversold and overbought markets\.
The indicator oscillates around a zero line and is excellent for identifying divergences\.

| Constructors | |
| :--- | :--- |
| [TrixResult\(RetCode, int, int, double\[\]\)](TrixResult.TrixResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.TrixResult\.TrixResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [TrixResult](TrixResult.md 'TechnicalAnalysis\.Functions\.TrixResult') class\. |
