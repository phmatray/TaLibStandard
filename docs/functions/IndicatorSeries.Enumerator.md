#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.Enumerator Struct

Enumerates the warm bars of an [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries') in ascending BAR order\.

```csharp
public struct IndicatorSeries.Enumerator
```

### Remarks

Each iteration yields a `(Bar, Value)` pair in which `Bar` is a BAR index into the
source price series — an absolute position, never an index into the raw TA-Lib output array.
Bars that have no value are skipped rather than yielded as `null`, so enumerating an
empty series performs zero iterations.

[System\.Collections\.Generic\.IEnumerable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') is deliberately not implemented:
            `foreach` binds to this pattern directly and allocates nothing, whereas implementing the
            interface would box the enumerator on every loop. Adding the interface later is a
            non-breaking change; removing an allocating enumerator would not be.

| Properties | |
| :--- | :--- |
| [Current](IndicatorSeries.Enumerator.Current.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Enumerator\.Current') | Gets the current bar and its value\. |

| Methods | |
| :--- | :--- |
| [MoveNext\(\)](IndicatorSeries.Enumerator.MoveNext().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Enumerator\.MoveNext\(\)') | Advances to the next warm bar\. |
