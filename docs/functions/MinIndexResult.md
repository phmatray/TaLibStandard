#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MinIndexResult Class

Represents the result of calculating the index locations of the lowest values over a specified period\.
The MININDEX function identifies the position \(index\) of the minimum value within a rolling window\.

```csharp
public record MinIndexResult : TechnicalAnalysis.Common.IndicatorResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; MinIndexResult

| Constructors | |
| :--- | :--- |
| [MinIndexResult\(RetCode, int, int, int\[\]\)](MinIndexResult.MinIndexResult(RetCode,int,int,int[]).md 'TechnicalAnalysis\.Functions\.MinIndexResult\.MinIndexResult\(TechnicalAnalysis\.Common\.RetCode, int, int, int\[\]\)') | Initializes a new instance of the [MinIndexResult](MinIndexResult.md 'TechnicalAnalysis\.Functions\.MinIndexResult') class\. |

| Properties | |
| :--- | :--- |
| [Integers](MinIndexResult.Integers.md 'TechnicalAnalysis\.Functions\.MinIndexResult\.Integers') | Gets the array of indices where minimum values were found\. Each value represents the relative position within the rolling period where the lowest data point occurred\. |
