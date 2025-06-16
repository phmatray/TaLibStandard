#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TrueRangeResult Class

Represents the result of the True Range \(TR\) indicator calculation\.
True Range is a volatility measure that captures the greatest of: current high minus low, absolute value of current high minus previous close, or absolute value of current low minus previous close\.

```csharp
public record TrueRangeResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.TrueRangeResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; TrueRangeResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[TrueRangeResult](TrueRangeResult.md 'TechnicalAnalysis\.Functions\.TrueRangeResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [TrueRangeResult\(RetCode, int, int, double\[\]\)](TrueRangeResult.TrueRangeResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.TrueRangeResult\.TrueRangeResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [TrueRangeResult](TrueRangeResult.md 'TechnicalAnalysis\.Functions\.TrueRangeResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](TrueRangeResult.Real.md 'TechnicalAnalysis\.Functions\.TrueRangeResult\.Real') | Gets the array of True Range values\. Each value represents the greatest of: \(High \- Low\), \|High \- Previous Close\|, or \|Low \- Previous Close\|\. This captures volatility including gaps between trading sessions\. |
