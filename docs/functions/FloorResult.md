#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## FloorResult Class

Represents the result of the vector floor operation \(FLOOR function\)\.

```csharp
public record FloorResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.FloorResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; FloorResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[FloorResult](FloorResult.md 'TechnicalAnalysis\.Functions\.FloorResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The FLOOR function calculates the floor of each element in the input array\.
The floor of a number is the largest integer that is less than or equal to that number\.
For example, floor\(2\.3\) = 2, floor\(\-2\.3\) = \-3, floor\(5\.0\) = 5\.

| Constructors | |
| :--- | :--- |
| [FloorResult\(RetCode, int, int, double\[\]\)](FloorResult.FloorResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.FloorResult\.FloorResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [FloorResult](FloorResult.md 'TechnicalAnalysis\.Functions\.FloorResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](FloorResult.Real.md 'TechnicalAnalysis\.Functions\.FloorResult\.Real') | Gets the array of floor values resulting from the FLOOR operation\. |
