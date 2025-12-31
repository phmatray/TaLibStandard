#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## PlusDIResult Class

Represents the result of the Plus Directional Indicator \(\+DI\) calculation\.
\+DI is part of the Directional Movement System and measures the strength of upward price movements\.

```csharp
public record PlusDIResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.PlusDIResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; PlusDIResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[PlusDIResult](PlusDIResult.md 'TechnicalAnalysis\.Functions\.PlusDIResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [PlusDIResult\(RetCode, int, int, double\[\]\)](PlusDIResult.PlusDIResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.PlusDIResult\.PlusDIResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [PlusDIResult](PlusDIResult.md 'TechnicalAnalysis\.Functions\.PlusDIResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](PlusDIResult.Real.md 'TechnicalAnalysis\.Functions\.PlusDIResult\.Real') | Gets the array of Plus Directional Indicator values\. Values range from 0 to 100, representing the strength of upward price movement\. When \+DI is above \-DI, it suggests an uptrend; the wider the gap, the stronger the trend\. |
