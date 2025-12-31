#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## SarExtResult Class

Represents the result of the Parabolic SAR Extended \(SAREXT\) calculation\.
This is an enhanced version of the standard SAR indicator with additional customization options
for acceleration factors and other parameters, providing more flexibility in trend following\.

```csharp
public record SarExtResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.SarExtResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; SarExtResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[SarExtResult](SarExtResult.md 'TechnicalAnalysis\.Functions\.SarExtResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [SarExtResult\(RetCode, int, int, double\[\]\)](SarExtResult.SarExtResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.SarExtResult\.SarExtResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [SarExtResult](SarExtResult.md 'TechnicalAnalysis\.Functions\.SarExtResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](SarExtResult.Real.md 'TechnicalAnalysis\.Functions\.SarExtResult\.Real') | Gets the array of Parabolic SAR Extended values\. Similar to standard SAR but with additional control over acceleration behavior, allowing for more aggressive or conservative trailing stop strategies\. |
