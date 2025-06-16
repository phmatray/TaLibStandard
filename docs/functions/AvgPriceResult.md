#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AvgPriceResult Class

Represents the result of the Average Price calculation\.

```csharp
public record AvgPriceResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.AvgPriceResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; AvgPriceResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[AvgPriceResult](AvgPriceResult.md 'TechnicalAnalysis\.Functions\.AvgPriceResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The Average Price is a simple price transformation that calculates the arithmetic mean 
of the high, low, close, and open prices for each period\. This provides a single value 
that represents the average trading price for the period, smoothing out price fluctuations 
and potentially providing a clearer view of the overall price trend\. It is calculated as: 
\(High \+ Low \+ Close \+ Open\) / 4\.

| Constructors | |
| :--- | :--- |
| [AvgPriceResult\(RetCode, int, int, double\[\]\)](AvgPriceResult.AvgPriceResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.AvgPriceResult\.AvgPriceResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [AvgPriceResult](AvgPriceResult.md 'TechnicalAnalysis\.Functions\.AvgPriceResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](AvgPriceResult.Real.md 'TechnicalAnalysis\.Functions\.AvgPriceResult\.Real') | Gets the array of average price values\. |
