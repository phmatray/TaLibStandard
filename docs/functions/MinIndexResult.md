#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MinIndexResult Class

Represents the result of calculating the index locations of the lowest values over a specified period\.
The MININDEX function identifies the position \(index\) of the minimum value within a rolling window\.

```csharp
public record MinIndexResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MinIndexResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MinIndexResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[MinIndexResult](MinIndexResult.md 'TechnicalAnalysis\.Functions\.MinIndexResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [MinIndexResult\(RetCode, int, int, int\[\]\)](MinIndexResult.MinIndexResult(RetCode,int,int,int[]).md 'TechnicalAnalysis\.Functions\.MinIndexResult\.MinIndexResult\(TechnicalAnalysis\.Common\.RetCode, int, int, int\[\]\)') | Initializes a new instance of the [MinIndexResult](MinIndexResult.md 'TechnicalAnalysis\.Functions\.MinIndexResult') class\. |

| Properties | |
| :--- | :--- |
| [Integers](MinIndexResult.Integers.md 'TechnicalAnalysis\.Functions\.MinIndexResult\.Integers') | Gets the array of indices where minimum values were found\. Each value represents the relative position within the rolling period where the lowest data point occurred\. |
