#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## PlusDMResult Class

Represents the result of the Plus Directional Movement \(\+DM\) indicator calculation\.
\+DM measures upward price movement and is used as a component in calculating the Directional Movement System indicators\.

```csharp
public record PlusDMResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.PlusDMResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; PlusDMResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[PlusDMResult](PlusDMResult.md 'TechnicalAnalysis\.Functions\.PlusDMResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [PlusDMResult\(RetCode, int, int, double\[\]\)](PlusDMResult.PlusDMResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.PlusDMResult\.PlusDMResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [PlusDMResult](PlusDMResult.md 'TechnicalAnalysis\.Functions\.PlusDMResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](PlusDMResult.Real.md 'TechnicalAnalysis\.Functions\.PlusDMResult\.Real') | Gets the array of Plus Directional Movement values\. Each value represents the positive \(upward\) directional movement for the period\. Calculated as the difference between current high and previous high when it's positive and greater than the downward movement\. |
