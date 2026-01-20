#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common')

## SingleOutputResult Class

Base class for indicator results that produce a single output array\.

```csharp
public abstract record SingleOutputResult : TechnicalAnalysis.Common.IndicatorResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [IndicatorResult](IndicatorResult.md 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; SingleOutputResult

### Remarks
This abstract class provides common functionality for technical indicators
that calculate a single output series\. It encapsulates the result array
and inherits the metadata properties \(RetCode, BegIdx, NbElement\) from IndicatorResult\.

| Constructors | |
| :--- | :--- |
| [SingleOutputResult\(RetCode, int, int, double\[\]\)](SingleOutputResult.SingleOutputResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Common\.SingleOutputResult\.SingleOutputResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [SingleOutputResult](SingleOutputResult.md 'TechnicalAnalysis\.Common\.SingleOutputResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](SingleOutputResult.Real.md 'TechnicalAnalysis\.Common\.SingleOutputResult\.Real') | Gets the array of calculated indicator values\. |
