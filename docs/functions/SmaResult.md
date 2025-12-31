#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## SmaResult Class

Represents the result of calculating the Simple Moving Average \(SMA\) indicator\.

```csharp
public record SmaResult : TechnicalAnalysis.Common.Abstractions.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.SmaResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.abstractions.singleoutputresult 'TechnicalAnalysis\.Common\.Abstractions\.SingleOutputResult') &#129106; SmaResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[SmaResult](SmaResult.md 'TechnicalAnalysis\.Functions\.SmaResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The SMA is a widely used trend\-following indicator that calculates the average price
over a specified number of periods\. It smooths out price data to help identify trends
by filtering out short\-term price fluctuations\.

| Constructors | |
| :--- | :--- |
| [SmaResult\(RetCode, int, int, double\[\]\)](SmaResult.SmaResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.SmaResult\.SmaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [SmaResult](SmaResult.md 'TechnicalAnalysis\.Functions\.SmaResult') class\. |
