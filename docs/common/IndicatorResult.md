#### [TechnicalAnalysis.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical.TechnicalAnalysis.Common')
### [TechnicalAnalysis.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis.Common')

## IndicatorResult Class

Represents an abstract base class for technical indicators.

```csharp
public abstract class IndicatorResult :
System.IEquatable<TechnicalAnalysis.Common.IndicatorResult>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; IndicatorResult

Derived  
&#8627; [CandleIndicatorResult](CandleIndicatorResult.md 'TechnicalAnalysis.Common.CandleIndicatorResult')

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[IndicatorResult](IndicatorResult.md 'TechnicalAnalysis.Common.IndicatorResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [IndicatorResult(RetCode, int, int)](IndicatorResult.IndicatorResult(RetCode,int,int).md 'TechnicalAnalysis.Common.IndicatorResult.IndicatorResult(TechnicalAnalysis.Common.RetCode, int, int)') | Initializes a new instance of the IndicatorBase class. |

| Properties | |
| :--- | :--- |
| [BegIdx](IndicatorResult.BegIdx.md 'TechnicalAnalysis.Common.IndicatorResult.BegIdx') | Gets the beginning index of the calculated output series. |
| [NBElement](IndicatorResult.NBElement.md 'TechnicalAnalysis.Common.IndicatorResult.NBElement') | Gets the number of elements in the calculated output series. |
| [RetCode](IndicatorResult.RetCode.md 'TechnicalAnalysis.Common.IndicatorResult.RetCode') | Gets the return code indicating the status of the indicator calculation. |
