#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## KamaResult Class

Represents the result of calculating the Kaufman Adaptive Moving Average \(KAMA\) indicator\.

```csharp
public record KamaResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; KamaResult

### Remarks
KAMA is an adaptive moving average designed to account for market noise and volatility\.
It automatically adjusts its sensitivity based on the efficiency ratio of price movement,
moving quickly in trending markets and slowly in ranging markets to reduce whipsaws\.

| Constructors | |
| :--- | :--- |
| [KamaResult\(RetCode, int, int, double\[\]\)](KamaResult.KamaResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.KamaResult\.KamaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [KamaResult](KamaResult.md 'TechnicalAnalysis\.Functions\.KamaResult') class\. |
