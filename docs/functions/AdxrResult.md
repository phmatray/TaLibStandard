#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AdxrResult Class

Represents the result of calculating the Average Directional Movement Index Rating \(ADXR\)\.
The ADXR is a smoothed version of the ADX indicator, providing a more stable measure
of trend strength by averaging the current ADX value with a previous ADX value\.

```csharp
public record AdxrResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.AdxrResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; AdxrResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[AdxrResult](AdxrResult.md 'TechnicalAnalysis\.Functions\.AdxrResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [AdxrResult\(RetCode, int, int, double\[\]\)](AdxrResult.AdxrResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.AdxrResult\.AdxrResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [AdxrResult](AdxrResult.md 'TechnicalAnalysis\.Functions\.AdxrResult') class\. |
