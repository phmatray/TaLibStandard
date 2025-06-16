#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## KamaResult Class

Represents the result of calculating the Kaufman Adaptive Moving Average \(KAMA\) indicator\.

```csharp
public record KamaResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.KamaResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; KamaResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[KamaResult](KamaResult.md 'TechnicalAnalysis\.Functions\.KamaResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
KAMA is an adaptive moving average designed to account for market noise and volatility\.
It automatically adjusts its sensitivity based on the efficiency ratio of price movement,
moving quickly in trending markets and slowly in ranging markets to reduce whipsaws\.

| Constructors | |
| :--- | :--- |
| [KamaResult\(RetCode, int, int, double\[\]\)](KamaResult.KamaResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.KamaResult\.KamaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [KamaResult](KamaResult.md 'TechnicalAnalysis\.Functions\.KamaResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](KamaResult.Real.md 'TechnicalAnalysis\.Functions\.KamaResult\.Real') | Gets the array of Kaufman Adaptive Moving Average values\. |
