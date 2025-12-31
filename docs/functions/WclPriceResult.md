#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## WclPriceResult Class

Represents the result of the Weighted Close Price calculation\.

```csharp
public record WclPriceResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.WclPriceResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; WclPriceResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[WclPriceResult](WclPriceResult.md 'TechnicalAnalysis\.Functions\.WclPriceResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The Weighted Close Price emphasizes the closing price by giving it more weight in the 
calculation compared to the high and low prices\. It is calculated as: \(High \+ Low \+ Close \+ Close\) / 4\. 
This price transformation assumes that the closing price is the most important price of 
the trading period, as it represents the final consensus of value for that period\. 
The weighted close is often used in trend\-following strategies and as input for other indicators\.

| Constructors | |
| :--- | :--- |
| [WclPriceResult\(RetCode, int, int, double\[\]\)](WclPriceResult.WclPriceResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.WclPriceResult\.WclPriceResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [WclPriceResult](WclPriceResult.md 'TechnicalAnalysis\.Functions\.WclPriceResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](WclPriceResult.Real.md 'TechnicalAnalysis\.Functions\.WclPriceResult\.Real') | Gets the array of weighted close price values\. |
