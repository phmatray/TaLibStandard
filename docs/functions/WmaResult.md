#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## WmaResult Class

Represents the result of calculating the Weighted Moving Average \(WMA\) indicator\.

```csharp
public record WmaResult : TechnicalAnalysis.Common.Abstractions.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.WmaResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.abstractions.singleoutputresult 'TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult') &#129106; WmaResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[WmaResult](WmaResult.md 'TechnicalAnalysis\.Functions\.WmaResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The WMA assigns linearly decreasing weights to older data points, giving more importance
to recent prices\. Unlike the SMA which treats all periods equally, the WMA provides
a middle ground between the responsiveness of the EMA and the smoothness of the SMA\.

| Constructors | |
| :--- | :--- |
| [WmaResult\(RetCode, int, int, double\[\]\)](WmaResult.WmaResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.WmaResult\.WmaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [WmaResult](WmaResult.md 'TechnicalAnalysis\.Functions\.WmaResult') class\. |
