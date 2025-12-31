#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TemaResult Class

Represents the result of calculating the Triple Exponential Moving Average \(TEMA\) indicator\.

```csharp
public record TemaResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.TemaResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; TemaResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[TemaResult](TemaResult.md 'TechnicalAnalysis\.Functions\.TemaResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
TEMA is an advanced moving average that uses three exponential moving averages to
further reduce lag compared to DEMA\. It is highly responsive to price changes,
making it excellent for identifying short\-term price movements and trend reversals\.

| Constructors | |
| :--- | :--- |
| [TemaResult\(RetCode, int, int, double\[\]\)](TemaResult.TemaResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.TemaResult\.TemaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [TemaResult](TemaResult.md 'TechnicalAnalysis\.Functions\.TemaResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](TemaResult.Real.md 'TechnicalAnalysis\.Functions\.TemaResult\.Real') | Gets the array of triple exponential moving average values\. |
