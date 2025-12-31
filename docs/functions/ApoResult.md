#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## ApoResult Class

Represents the result of calculating the Absolute Price Oscillator \(APO\) indicator\.

```csharp
public record ApoResult : TechnicalAnalysis.Common.Abstractions.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.ApoResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.abstractions.singleoutputresult 'TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult') &#129106; ApoResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[ApoResult](ApoResult.md 'TechnicalAnalysis\.Functions\.ApoResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
APO displays the difference between two moving averages of different periods in absolute terms\.
Unlike the Percentage Price Oscillator \(PPO\), APO shows the actual price difference,
making it useful for comparing price momentum across different time periods\.

| Constructors | |
| :--- | :--- |
| [ApoResult\(RetCode, int, int, double\[\]\)](ApoResult.ApoResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.ApoResult\.ApoResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [ApoResult](ApoResult.md 'TechnicalAnalysis\.Functions\.ApoResult') class\. |
