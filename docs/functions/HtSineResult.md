#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## HtSineResult Class

Represents the result of the Hilbert Transform \- SineWave \(HT\_SINE\) calculation\.
This indicator generates sine and leading sine wave indicators from price data using Hilbert Transform,
useful for identifying cycle turns and generating trading signals in trending markets\.

```csharp
public record HtSineResult : TechnicalAnalysis.Common.DualOutputResult, System.IEquatable<TechnicalAnalysis.Functions.HtSineResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.DualOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.dualoutputresult 'TechnicalAnalysis\.Common\.DualOutputResult') &#129106; HtSineResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[HtSineResult](HtSineResult.md 'TechnicalAnalysis\.Functions\.HtSineResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [HtSineResult\(RetCode, int, int, double\[\], double\[\]\)](HtSineResult.HtSineResult(RetCode,int,int,double[],double[]).md 'TechnicalAnalysis\.Functions\.HtSineResult\.HtSineResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\]\)') | Initializes a new instance of the [HtSineResult](HtSineResult.md 'TechnicalAnalysis\.Functions\.HtSineResult') class\. |

| Properties | |
| :--- | :--- |
| [LeadSine](HtSineResult.LeadSine.md 'TechnicalAnalysis\.Functions\.HtSineResult\.LeadSine') | Gets the array of leading sine wave values\. The lead sine is phase\-advanced by 45 degrees from the sine wave, providing early signals for potential cycle turns\. |
| [Sine](HtSineResult.Sine.md 'TechnicalAnalysis\.Functions\.HtSineResult\.Sine') | Gets the array of sine wave values\. Values oscillate between \-1 and \+1, representing the smoothed cyclic component of price movement\. Crossovers between sine and lead sine can indicate cycle turning points\. |
