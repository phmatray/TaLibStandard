#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MinMaxResult Class

Represents the result of calculating the minimum and maximum values over a specified period\.

```csharp
public record MinMaxResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MinMaxResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MinMaxResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[MinMaxResult](MinMaxResult.md 'TechnicalAnalysis\.Functions\.MinMaxResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

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
