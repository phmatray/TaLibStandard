#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MinusDMResult Class

Represents the result of the Minus Directional Movement \(\-DM\) indicator calculation\.
\-DM measures downward price movement and is used as a component in calculating the Directional Movement System indicators\.

```csharp
public record MinusDMResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MinusDMResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MinusDMResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[MinusDMResult](MinusDMResult.md 'TechnicalAnalysis\.Functions\.MinusDMResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [MinusDMResult\(RetCode, int, int, double\[\]\)](MinusDMResult.MinusDMResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MinusDMResult\.MinusDMResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MinusDMResult](MinusDMResult.md 'TechnicalAnalysis\.Functions\.MinusDMResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](MinusDMResult.Real.md 'TechnicalAnalysis\.Functions\.MinusDMResult\.Real') | Gets the array of Minus Directional Movement values\. Each value represents the negative \(downward\) directional movement for the period\. Calculated as the difference between previous low and current low when it's positive and greater than the upward movement\. |
