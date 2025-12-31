#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## NatrResult Class

Represents the result of calculating the Normalized Average True Range \(NATR\) indicator\.

```csharp
public record NatrResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.NatrResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; NatrResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[NatrResult](NatrResult.md 'TechnicalAnalysis\.Functions\.NatrResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The Normalized Average True Range is a volatility indicator that expresses the Average True Range \(ATR\)
as a percentage of the closing price\. This normalization allows for better comparison of volatility
across different price levels and between different securities\.

| Constructors | |
| :--- | :--- |
| [NatrResult\(RetCode, int, int, double\[\]\)](NatrResult.NatrResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.NatrResult\.NatrResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [NatrResult](NatrResult.md 'TechnicalAnalysis\.Functions\.NatrResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](NatrResult.Real.md 'TechnicalAnalysis\.Functions\.NatrResult\.Real') | Gets the array of Normalized Average True Range values\. |
