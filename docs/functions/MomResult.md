#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MomResult Class

Represents the result of calculating the Momentum \(MOM\) indicator\.

```csharp
public record MomResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MomResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MomResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[MomResult](MomResult.md 'TechnicalAnalysis\.Functions\.MomResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The Momentum indicator measures the rate of change in price over a specified period\.
It is calculated by subtracting the price n periods ago from the current price\.
Positive values indicate upward momentum, while negative values indicate downward momentum\.

| Constructors | |
| :--- | :--- |
| [MomResult\(RetCode, int, int, double\[\]\)](MomResult.MomResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MomResult\.MomResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MomResult](MomResult.md 'TechnicalAnalysis\.Functions\.MomResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](MomResult.Real.md 'TechnicalAnalysis\.Functions\.MomResult\.Real') | Gets the array of momentum values\. |
