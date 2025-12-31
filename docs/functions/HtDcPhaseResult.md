#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## HtDcPhaseResult Class

Represents the result of the Hilbert Transform \- Dominant Cycle Phase \(HT\_DCPHASE\) calculation\.
This indicator measures the phase angle of the dominant market cycle using Hilbert Transform techniques,
helping to identify the current position within a price cycle\.

```csharp
public record HtDcPhaseResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.HtDcPhaseResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; HtDcPhaseResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[HtDcPhaseResult](HtDcPhaseResult.md 'TechnicalAnalysis\.Functions\.HtDcPhaseResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [HtDcPhaseResult\(RetCode, int, int, double\[\]\)](HtDcPhaseResult.HtDcPhaseResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.HtDcPhaseResult\.HtDcPhaseResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [HtDcPhaseResult](HtDcPhaseResult.md 'TechnicalAnalysis\.Functions\.HtDcPhaseResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](HtDcPhaseResult.Real.md 'TechnicalAnalysis\.Functions\.HtDcPhaseResult\.Real') | Gets the array of dominant cycle phase values\. Each value represents the phase angle in degrees \(\-180 to \+180\) of the dominant cycle\. Positive values indicate the cycle is in an upward phase, while negative values indicate a downward phase\. |
