#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## LinearRegSlopeResult Class

Represents the result of the Linear Regression Slope \(LINEARREG\_SLOPE\) calculation\.
This indicator calculates the slope of the linear regression line, indicating the rate of change
in price over the specified period\.

```csharp
public record LinearRegSlopeResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.LinearRegSlopeResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; LinearRegSlopeResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[LinearRegSlopeResult](LinearRegSlopeResult.md 'TechnicalAnalysis\.Functions\.LinearRegSlopeResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [LinearRegSlopeResult\(RetCode, int, int, double\[\]\)](LinearRegSlopeResult.LinearRegSlopeResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.LinearRegSlopeResult\.LinearRegSlopeResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [LinearRegSlopeResult](LinearRegSlopeResult.md 'TechnicalAnalysis\.Functions\.LinearRegSlopeResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](LinearRegSlopeResult.Real.md 'TechnicalAnalysis\.Functions\.LinearRegSlopeResult\.Real') | Gets the array of linear regression slope values\. Each value represents the slope \(rate of change per bar\) of the regression line\. Positive values indicate rising prices, negative values indicate falling prices\. |
