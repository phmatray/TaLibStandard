#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## CmoResult Class

Represents the result of the Chande Momentum Oscillator \(CMO\) calculation\.
This indicator measures momentum by calculating the difference between the sum of gains and losses
over a specified period, normalized to oscillate between \-100 and \+100\.

```csharp
public record CmoResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.CmoResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; CmoResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[CmoResult](CmoResult.md 'TechnicalAnalysis\.Functions\.CmoResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [CmoResult\(RetCode, int, int, double\[\]\)](CmoResult.CmoResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.CmoResult\.CmoResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [CmoResult](CmoResult.md 'TechnicalAnalysis\.Functions\.CmoResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](CmoResult.Real.md 'TechnicalAnalysis\.Functions\.CmoResult\.Real') | Gets the array of Chande Momentum Oscillator values\. Values range from \-100 to \+100, where positive values indicate upward momentum and negative values indicate downward momentum\. Readings above \+50 or below \-50 suggest strong momentum\. |
