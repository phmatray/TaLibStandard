#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## SumResult Class

Represents the result of calculating the summation of values over a specified period\.
The SUM function calculates the total of all values within a rolling window\.

```csharp
public record SumResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.SumResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; SumResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[SumResult](SumResult.md 'TechnicalAnalysis\.Functions\.SumResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [SumResult\(RetCode, int, int, double\[\]\)](SumResult.SumResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.SumResult\.SumResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [SumResult](SumResult.md 'TechnicalAnalysis\.Functions\.SumResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](SumResult.Real.md 'TechnicalAnalysis\.Functions\.SumResult\.Real') | Gets the array of calculated sum values\. Each value represents the total of all data points within the specified rolling period\. |
