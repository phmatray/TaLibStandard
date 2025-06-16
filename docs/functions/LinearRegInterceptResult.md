#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## LinearRegInterceptResult Class

Represents the result of the Linear Regression Intercept \(LINEARREG\_INTERCEPT\) calculation\.
This indicator calculates the y\-intercept of the linear regression line, representing where
the regression line would cross the y\-axis if extended backward\.

```csharp
public record LinearRegInterceptResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.LinearRegInterceptResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; LinearRegInterceptResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[LinearRegInterceptResult](LinearRegInterceptResult.md 'TechnicalAnalysis\.Functions\.LinearRegInterceptResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [LinearRegInterceptResult\(RetCode, int, int, double\[\]\)](LinearRegInterceptResult.LinearRegInterceptResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.LinearRegInterceptResult\.LinearRegInterceptResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [LinearRegInterceptResult](LinearRegInterceptResult.md 'TechnicalAnalysis\.Functions\.LinearRegInterceptResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](LinearRegInterceptResult.Real.md 'TechnicalAnalysis\.Functions\.LinearRegInterceptResult\.Real') | Gets the array of linear regression intercept values\. Each value represents the y\-intercept of the regression line calculated over the lookback period, useful for projecting the regression line and understanding price levels\. |
