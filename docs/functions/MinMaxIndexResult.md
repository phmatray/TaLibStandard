#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MinMaxIndexResult Class

Represents the result of calculating the indices of minimum and maximum values over a specified period\.

```csharp
public record MinMaxIndexResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MinMaxIndexResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MinMaxIndexResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[MinMaxIndexResult](MinMaxIndexResult.md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The MinMaxIndex function identifies the array indices where the minimum and maximum values
occur within a rolling window\. This is useful for locating exact positions of peaks and troughs
in price data, which can be used for support/resistance analysis or pattern recognition\.

| Constructors | |
| :--- | :--- |
| [MinMaxIndexResult\(RetCode, int, int, int\[\], int\[\]\)](MinMaxIndexResult.MinMaxIndexResult(RetCode,int,int,int[],int[]).md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult\.MinMaxIndexResult\(TechnicalAnalysis\.Common\.RetCode, int, int, int\[\], int\[\]\)') | Initializes a new instance of the [MinMaxIndexResult](MinMaxIndexResult.md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult') class\. |

| Properties | |
| :--- | :--- |
| [MaxIdx](MinMaxIndexResult.MaxIdx.md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult\.MaxIdx') | Gets the array of indices where maximum values occur\. |
| [MinIdx](MinMaxIndexResult.MinIdx.md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult\.MinIdx') | Gets the array of indices where minimum values occur\. |
