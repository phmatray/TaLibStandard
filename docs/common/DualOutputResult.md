#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common')

## DualOutputResult Class

Base class for indicator results that produce two output arrays\.

```csharp
public abstract record DualOutputResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Common.DualOutputResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [IndicatorResult](IndicatorResult.md 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; DualOutputResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[DualOutputResult](DualOutputResult.md 'TechnicalAnalysis\.Common\.DualOutputResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
This abstract class provides common functionality for technical indicators
that calculate two output series\. It encapsulates both result arrays
and inherits the metadata properties \(RetCode, BegIdx, NbElement\) from IndicatorResult\.

| Constructors | |
| :--- | :--- |
| [DualOutputResult\(RetCode, int, int, double\[\], double\[\]\)](DualOutputResult.DualOutputResult(RetCode,int,int,double[],double[]).md 'TechnicalAnalysis\.Common\.DualOutputResult\.DualOutputResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\]\)') | Initializes a new instance of the [DualOutputResult](DualOutputResult.md 'TechnicalAnalysis\.Common\.DualOutputResult') class\. |

| Properties | |
| :--- | :--- |
| [Real0](DualOutputResult.Real0.md 'TechnicalAnalysis\.Common\.DualOutputResult\.Real0') | Gets the first array of calculated indicator values\. |
| [Real1](DualOutputResult.Real1.md 'TechnicalAnalysis\.Common\.DualOutputResult\.Real1') | Gets the second array of calculated indicator values\. |
