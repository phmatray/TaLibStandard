#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## RsiResult Class

Represents the result of calculating the Relative Strength Index \(RSI\) indicator\.

```csharp
public record RsiResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.RsiResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; RsiResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The RSI is a momentum oscillator that measures the speed and magnitude of price changes\.
It oscillates between 0 and 100, helping identify overbought and oversold conditions\.
Values above 70 typically indicate overbought conditions, while values below 30 indicate oversold conditions\.

| Constructors | |
| :--- | :--- |
| [RsiResult\(RetCode, int, int, double\[\]\)](RsiResult.RsiResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.RsiResult\.RsiResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](RsiResult.Real.md 'TechnicalAnalysis\.Functions\.RsiResult\.Real') | Gets the array of RSI values\. |
