#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MaxIndexResult Class

Represents the result of calculating the index locations of the highest values over a specified period\.
The MAXINDEX function identifies the position \(index\) of the maximum value within a rolling window\.

```csharp
public record MaxIndexResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MaxIndexResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MaxIndexResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[MaxIndexResult](MaxIndexResult.md 'TechnicalAnalysis\.Functions\.MaxIndexResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [MaxIndexResult\(RetCode, int, int, int\[\]\)](MaxIndexResult.MaxIndexResult(RetCode,int,int,int[]).md 'TechnicalAnalysis\.Functions\.MaxIndexResult\.MaxIndexResult\(TechnicalAnalysis\.Common\.RetCode, int, int, int\[\]\)') | Initializes a new instance of the [MaxIndexResult](MaxIndexResult.md 'TechnicalAnalysis\.Functions\.MaxIndexResult') class\. |

| Properties | |
| :--- | :--- |
| [Integers](MaxIndexResult.Integers.md 'TechnicalAnalysis\.Functions\.MaxIndexResult\.Integers') | Gets the array of indices where maximum values were found\. Each value represents the relative position within the rolling period where the highest data point occurred\. |
