#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## LinearRegResult Class

Represents the result of the Linear Regression \(LINEARREG\) calculation\.
This indicator calculates the linear regression line value at each point, providing a statistical
best\-fit line through the price data over a specified period\.

```csharp
public record LinearRegResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.LinearRegResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; LinearRegResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[LinearRegResult](LinearRegResult.md 'TechnicalAnalysis\.Functions\.LinearRegResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [LinearRegResult\(RetCode, int, int, double\[\]\)](LinearRegResult.LinearRegResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.LinearRegResult\.LinearRegResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [LinearRegResult](LinearRegResult.md 'TechnicalAnalysis\.Functions\.LinearRegResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](LinearRegResult.Real.md 'TechnicalAnalysis\.Functions\.LinearRegResult\.Real') | Gets the array of linear regression line values\. Each value represents the y\-coordinate of the regression line at that point in time, calculated using least squares method over the specified lookback period\. |
