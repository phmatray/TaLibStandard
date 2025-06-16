#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## BetaResult Class

Represents the result of the Beta coefficient calculation\.

```csharp
public record BetaResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.BetaResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; BetaResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[BetaResult](BetaResult.md 'TechnicalAnalysis\.Functions\.BetaResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
Beta is a statistical measure that compares the volatility of a security or portfolio 
to the volatility of a benchmark \(typically a market index\)\. It measures the systematic 
risk of an investment\. A beta of 1\.0 indicates the security moves in line with the market, 
greater than 1\.0 indicates higher volatility than the market, and less than 1\.0 indicates 
lower volatility\. Negative beta indicates inverse correlation with the market\. Beta is 
fundamental in the Capital Asset Pricing Model \(CAPM\) for calculating expected returns\.

| Constructors | |
| :--- | :--- |
| [BetaResult\(RetCode, int, int, double\[\]\)](BetaResult.BetaResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.BetaResult\.BetaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [BetaResult](BetaResult.md 'TechnicalAnalysis\.Functions\.BetaResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](BetaResult.Real.md 'TechnicalAnalysis\.Functions\.BetaResult\.Real') | Gets the array of beta coefficient values\. |
