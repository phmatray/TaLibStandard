#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MamaResult Class

Represents the result of calculating the MESA Adaptive Moving Average \(MAMA\) indicator\.

```csharp
public record MamaResult : TechnicalAnalysis.Common.DualOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.DualOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.dualoutputresult 'TechnicalAnalysis\.Common\.DualOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; MamaResult

### Remarks
MAMA is an adaptive moving average developed by John Ehlers that automatically adjusts
to price movement based on the rate of change of phase\. It consists of two lines:
MAMA \(the adaptive moving average\) and FAMA \(Following Adaptive Moving Average\),
which work together to identify trends with minimal lag\.

| Constructors | |
| :--- | :--- |
| [MamaResult\(RetCode, int, int, double\[\], double\[\]\)](MamaResult.MamaResult(RetCode,int,int,double[],double[]).md 'TechnicalAnalysis\.Functions\.MamaResult\.MamaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\]\)') | Initializes a new instance of the [MamaResult](MamaResult.md 'TechnicalAnalysis\.Functions\.MamaResult') class\. |

| Properties | |
| :--- | :--- |
| [FAMA](MamaResult.FAMA.md 'TechnicalAnalysis\.Functions\.MamaResult\.FAMA') | Gets the array of Following Adaptive Moving Average \(FAMA\) values\. |
| [MAMA](MamaResult.MAMA.md 'TechnicalAnalysis\.Functions\.MamaResult\.MAMA') | Gets the array of MESA Adaptive Moving Average \(MAMA\) values\. |
