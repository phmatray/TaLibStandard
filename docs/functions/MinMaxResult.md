#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MinMaxResult Class

Represents the result of calculating the minimum and maximum values over a specified period\.

```csharp
public record MinMaxResult : TechnicalAnalysis.Common.DualOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.DualOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.dualoutputresult 'TechnicalAnalysis\.Common\.DualOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; MinMaxResult

### Remarks
The MinMax function calculates the lowest and highest values within a rolling window period\.
This is useful for identifying price ranges, calculating channels, and determining
support and resistance levels based on recent price extremes\.

| Constructors | |
| :--- | :--- |
| [MinMaxResult\(RetCode, int, int, double\[\], double\[\]\)](MinMaxResult.MinMaxResult(RetCode,int,int,double[],double[]).md 'TechnicalAnalysis\.Functions\.MinMaxResult\.MinMaxResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\]\)') | Initializes a new instance of the [MinMaxResult](MinMaxResult.md 'TechnicalAnalysis\.Functions\.MinMaxResult') class\. |

| Properties | |
| :--- | :--- |
| [Max](MinMaxResult.Max.md 'TechnicalAnalysis\.Functions\.MinMaxResult\.Max') | Gets the array of maximum values\. |
| [Min](MinMaxResult.Min.md 'TechnicalAnalysis\.Functions\.MinMaxResult\.Min') | Gets the array of minimum values\. |
