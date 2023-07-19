#### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md 'TechnicalAnalysis.Common')
### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis.Common')

## IndicatorBase Class

Represents an abstract base class for technical indicators.

```csharp
public abstract class IndicatorBase :
System.IEquatable<TechnicalAnalysis.Common.IndicatorBase>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; IndicatorBase

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[IndicatorBase](IndicatorBase.md 'TechnicalAnalysis.Common.IndicatorBase')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [IndicatorBase(RetCode, int, int)](IndicatorBase.IndicatorBase(RetCode,int,int).md 'TechnicalAnalysis.Common.IndicatorBase.IndicatorBase(TechnicalAnalysis.Common.RetCode, int, int)') | Initializes a new instance of the IndicatorBase class. |

| Properties | |
| :--- | :--- |
| [BegIdx](IndicatorBase.BegIdx.md 'TechnicalAnalysis.Common.IndicatorBase.BegIdx') | Gets the beginning index of the calculated output series. |
| [NBElement](IndicatorBase.NBElement.md 'TechnicalAnalysis.Common.IndicatorBase.NBElement') | Gets the number of elements in the calculated output series. |
| [RetCode](IndicatorBase.RetCode.md 'TechnicalAnalysis.Common.IndicatorBase.RetCode') | Gets the return code indicating the status of the indicator calculation. |
