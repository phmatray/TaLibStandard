#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## BetaResult Class

Represents the result of the Beta coefficient calculation\.

```csharp
public record BetaResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; BetaResult

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
