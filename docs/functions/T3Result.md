#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## T3Result Class

Represents the result of calculating the T3 Moving Average indicator\.

```csharp
public record T3Result : TechnicalAnalysis.Common.Abstractions.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.T3Result>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.abstractions.singleoutputresult 'TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult') &#129106; T3Result

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[T3Result](T3Result.md 'TechnicalAnalysis\.Functions\.T3Result')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
T3 is a smoothed moving average developed by Tim Tillson\. It incorporates multiple
exponential smoothing techniques to produce a moving average that is both smooth
and responsive, with minimal lag compared to traditional moving averages\.

| Constructors | |
| :--- | :--- |
| [T3Result\(RetCode, int, int, double\[\]\)](T3Result.T3Result(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.T3Result\.T3Result\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [T3Result](T3Result.md 'TechnicalAnalysis\.Functions\.T3Result') class\. |
