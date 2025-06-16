#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MedPriceResult Class

Represents the result of the Median Price calculation\.

```csharp
public record MedPriceResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MedPriceResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MedPriceResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[MedPriceResult](MedPriceResult.md 'TechnicalAnalysis\.Functions\.MedPriceResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The Median Price is a simple price transformation that calculates the midpoint between 
the high and low prices for each period\. Also known as the High\-Low Average, it represents 
the middle of the day's trading range and is often used as a simplified representation 
of price action\. It is calculated as: \(High \+ Low\) / 2\. This indicator is useful for 
identifying the central tendency of price movement within each period\.

| Constructors | |
| :--- | :--- |
| [MedPriceResult\(RetCode, int, int, double\[\]\)](MedPriceResult.MedPriceResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MedPriceResult\.MedPriceResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MedPriceResult](MedPriceResult.md 'TechnicalAnalysis\.Functions\.MedPriceResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](MedPriceResult.Real.md 'TechnicalAnalysis\.Functions\.MedPriceResult\.Real') | Gets the array of median price values\. |
