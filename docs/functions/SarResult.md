#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## SarResult Class

Represents the result of the Parabolic Stop and Reverse \(SAR\) calculation\.
This indicator provides trailing stop\-loss points that follow the price trend, helping traders
identify potential reversal points and manage risk in trending markets\.

```csharp
public record SarResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.SarResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; SarResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[SarResult](SarResult.md 'TechnicalAnalysis\.Functions\.SarResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [SarResult\(RetCode, int, int, double\[\]\)](SarResult.SarResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.SarResult\.SarResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [SarResult](SarResult.md 'TechnicalAnalysis\.Functions\.SarResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](SarResult.Real.md 'TechnicalAnalysis\.Functions\.SarResult\.Real') | Gets the array of Parabolic SAR values\. Each value represents a stop\-loss level that trails the price\. When price is above SAR, the trend is bullish; when below, it's bearish\. SAR flips sides when price crosses it\. |
