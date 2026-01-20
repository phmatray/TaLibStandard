#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common')

## IndicatorResult Class

Represents an abstract base class for technical indicators\.

```csharp
public abstract record IndicatorResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; IndicatorResult

Derived  
&#8627; [CandleIndicatorResult](CandleIndicatorResult.md 'TechnicalAnalysis\.Common\.CandleIndicatorResult')  
&#8627; [DualOutputResult](DualOutputResult.md 'TechnicalAnalysis\.Common\.DualOutputResult')  
&#8627; [SingleOutputResult](SingleOutputResult.md 'TechnicalAnalysis\.Common\.SingleOutputResult')  
&#8627; [TripleOutputResult](TripleOutputResult.md 'TechnicalAnalysis\.Common\.TripleOutputResult')

| Constructors | |
| :--- | :--- |
| [IndicatorResult\(RetCode, int, int\)](IndicatorResult.IndicatorResult(RetCode,int,int).md 'TechnicalAnalysis\.Common\.IndicatorResult\.IndicatorResult\(TechnicalAnalysis\.Common\.RetCode, int, int\)') | Initializes a new instance of the IndicatorBase class\. |

| Properties | |
| :--- | :--- |
| [BegIdx](IndicatorResult.BegIdx.md 'TechnicalAnalysis\.Common\.IndicatorResult\.BegIdx') | Gets the beginning index of the calculated output series\. |
| [NBElement](IndicatorResult.NBElement.md 'TechnicalAnalysis\.Common\.IndicatorResult\.NBElement') | Gets the number of elements in the calculated output series\. |
| [RetCode](IndicatorResult.RetCode.md 'TechnicalAnalysis\.Common\.IndicatorResult\.RetCode') | Gets the return code indicating the status of the indicator calculation\. |
