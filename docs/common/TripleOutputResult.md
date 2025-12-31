#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common')

## TripleOutputResult Class

Base class for indicator results that produce three output arrays\.

```csharp
public abstract record TripleOutputResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Common.TripleOutputResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [IndicatorResult](IndicatorResult.md 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; TripleOutputResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[TripleOutputResult](TripleOutputResult.md 'TechnicalAnalysis\.Common\.TripleOutputResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
This abstract class provides common functionality for technical indicators
that calculate three output series\. It encapsulates all three result arrays
and inherits the metadata properties \(RetCode, BegIdx, NbElement\) from IndicatorResult\.

| Constructors | |
| :--- | :--- |
| [TripleOutputResult\(RetCode, int, int, double\[\], double\[\], double\[\]\)](TripleOutputResult.TripleOutputResult(RetCode,int,int,double[],double[],double[]).md 'TechnicalAnalysis\.Common\.TripleOutputResult\.TripleOutputResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\], double\[\]\)') | Initializes a new instance of the [TripleOutputResult](TripleOutputResult.md 'TechnicalAnalysis\.Common\.TripleOutputResult') class\. |

| Properties | |
| :--- | :--- |
| [Real0](TripleOutputResult.Real0.md 'TechnicalAnalysis\.Common\.TripleOutputResult\.Real0') | Gets the first array of calculated indicator values\. |
| [Real1](TripleOutputResult.Real1.md 'TechnicalAnalysis\.Common\.TripleOutputResult\.Real1') | Gets the second array of calculated indicator values\. |
| [Real2](TripleOutputResult.Real2.md 'TechnicalAnalysis\.Common\.TripleOutputResult\.Real2') | Gets the third array of calculated indicator values\. |
