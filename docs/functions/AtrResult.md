#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AtrResult Class

Represents the result of the Average True Range \(ATR\) indicator calculation\.
This volatility indicator measures the average of true ranges over a specified period, providing insight into market volatility\.

```csharp
public record AtrResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.AtrResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; AtrResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[AtrResult](AtrResult.md 'TechnicalAnalysis\.Functions\.AtrResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [AtrResult\(RetCode, int, int, double\[\]\)](AtrResult.AtrResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.AtrResult\.AtrResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [AtrResult](AtrResult.md 'TechnicalAnalysis\.Functions\.AtrResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](AtrResult.Real.md 'TechnicalAnalysis\.Functions\.AtrResult\.Real') | Gets the array of Average True Range values\. Each value represents the moving average of the True Range, indicating the degree of price volatility\. Higher ATR values indicate higher volatility, while lower values suggest lower volatility\. |
