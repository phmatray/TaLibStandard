#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## WillRResult Class

Represents the result of calculating the Williams' %R \(WillR\) indicator\.

```csharp
public record WillRResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; WillRResult

### Remarks
Williams' %R is a momentum indicator that measures overbought and oversold levels\.
It compares the closing price to the high\-low range over a specific period, typically 14 days\.
The indicator is similar to the Stochastic Oscillator but uses a different scale\.

| Constructors | |
| :--- | :--- |
| [WillRResult\(RetCode, int, int, double\[\]\)](WillRResult.WillRResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.WillRResult\.WillRResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [WillRResult](WillRResult.md 'TechnicalAnalysis\.Functions\.WillRResult') class\. |
