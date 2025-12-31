#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MidPointResult Class

Represents the result of calculating the MidPoint indicator\.

```csharp
public record MidPointResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MidPointResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MidPointResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[MidPointResult](MidPointResult.md 'TechnicalAnalysis\.Functions\.MidPointResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The MidPoint indicator calculates the midpoint between the highest and lowest values
over a specified period\. It represents the center of the price range and can be used
as a simple trend indicator or as a component in other technical analysis calculations\.

| Constructors | |
| :--- | :--- |
| [MidPointResult\(RetCode, int, int, double\[\]\)](MidPointResult.MidPointResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MidPointResult\.MidPointResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MidPointResult](MidPointResult.md 'TechnicalAnalysis\.Functions\.MidPointResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](MidPointResult.Real.md 'TechnicalAnalysis\.Functions\.MidPointResult\.Real') | Gets the array of midpoint values\. |
