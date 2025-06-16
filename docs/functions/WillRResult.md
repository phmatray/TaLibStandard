#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## WillRResult Class

Represents the result of calculating the Williams' %R \(WillR\) indicator\.

```csharp
public record WillRResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.WillRResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; WillRResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[WillRResult](WillRResult.md 'TechnicalAnalysis\.Functions\.WillRResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
Williams' %R is a momentum indicator that measures overbought and oversold levels\.
It compares the closing price to the high\-low range over a specific period, typically 14 days\.
The indicator is similar to the Stochastic Oscillator but uses a different scale\.

| Constructors | |
| :--- | :--- |
| [WillRResult\(RetCode, int, int, double\[\]\)](WillRResult.WillRResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.WillRResult\.WillRResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [WillRResult](WillRResult.md 'TechnicalAnalysis\.Functions\.WillRResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](WillRResult.Real.md 'TechnicalAnalysis\.Functions\.WillRResult\.Real') | Gets the array of Williams' %R values\. |
