#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AdxrResult Class

Represents the result of calculating the Average Directional Movement Index Rating \(ADXR\)\.
The ADXR is a smoothed version of the ADX indicator, providing a more stable measure
of trend strength by averaging the current ADX value with a previous ADX value\.

```csharp
public record AdxrResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.AdxrResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; AdxrResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[AdxrResult](AdxrResult.md 'TechnicalAnalysis\.Functions\.AdxrResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [AdxrResult\(RetCode, int, int, double\[\]\)](AdxrResult.AdxrResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.AdxrResult\.AdxrResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [AdxrResult](AdxrResult.md 'TechnicalAnalysis\.Functions\.AdxrResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](AdxrResult.Real.md 'TechnicalAnalysis\.Functions\.AdxrResult\.Real') | Gets the array of calculated ADXR values\. Each value represents the Average Directional Movement Index Rating, providing a smoothed measure of trend strength\. |
