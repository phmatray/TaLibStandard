#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## DxResult Class

Represents the result of the Directional Movement Index \(DX\) indicator calculation\.
DX measures the strength of a trend regardless of its direction, derived from comparing directional movements\.

```csharp
public record DxResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.DxResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; DxResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[DxResult](DxResult.md 'TechnicalAnalysis\.Functions\.DxResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [DxResult\(RetCode, int, int, double\[\]\)](DxResult.DxResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.DxResult\.DxResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [DxResult](DxResult.md 'TechnicalAnalysis\.Functions\.DxResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](DxResult.Real.md 'TechnicalAnalysis\.Functions\.DxResult\.Real') | Gets the array of Directional Movement Index values\. Values range from 0 to 100, where higher values indicate stronger trends \(either up or down\)\. Values below 20 typically indicate weak trends, while values above 40 suggest strong trends\. |
