#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AdxResult Class

Represents the result of an ADX \(Average Directional Index\) calculation\.

```csharp
public record AdxResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.AdxResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; AdxResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[AdxResult](AdxResult.md 'TechnicalAnalysis\.Functions\.AdxResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [AdxResult\(RetCode, int, int, double\[\]\)](AdxResult.AdxResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.AdxResult\.AdxResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the AdxResult record\. |

| Properties | |
| :--- | :--- |
| [Real](AdxResult.Real.md 'TechnicalAnalysis\.Functions\.AdxResult\.Real') | Gets the array of calculated ADX values\. |
