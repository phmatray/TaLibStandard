#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## EmaResult Class

Represents the result of calculating the Exponential Moving Average \(EMA\) indicator\.

```csharp
public record EmaResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; EmaResult

### Remarks
The EMA is a type of moving average that gives more weight to recent prices,
making it more responsive to new information compared to the Simple Moving Average \(SMA\)\.
It is commonly used to identify trends and generate trading signals\.

| Constructors | |
| :--- | :--- |
| [EmaResult\(RetCode, int, int, double\[\]\)](EmaResult.EmaResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.EmaResult\.EmaResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [EmaResult](EmaResult.md 'TechnicalAnalysis\.Functions\.EmaResult') class\. |
