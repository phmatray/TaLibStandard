#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TsfResult Class

Represents the result of the Time Series Forecast \(TSF\) calculation\.
This indicator projects the linear regression line forward in time, providing a statistical
forecast of where prices might be based on the current trend\.

```csharp
public record TsfResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.TsfResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; TsfResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[TsfResult](TsfResult.md 'TechnicalAnalysis\.Functions\.TsfResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [TsfResult\(RetCode, int, int, double\[\]\)](TsfResult.TsfResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.TsfResult\.TsfResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [TsfResult](TsfResult.md 'TechnicalAnalysis\.Functions\.TsfResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](TsfResult.Real.md 'TechnicalAnalysis\.Functions\.TsfResult\.Real') | Gets the array of time series forecast values\. Each value represents the projected price based on extending the linear regression line one period into the future, useful for identifying potential support/resistance levels\. |
