#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## StochRsiResult Class

Represents the result of the Stochastic Relative Strength Index \(STOCHRSI\) calculation\.
This indicator applies the Stochastic oscillator formula to RSI values, creating a more sensitive
momentum oscillator that combines the benefits of both indicators\.

```csharp
public record StochRsiResult : TechnicalAnalysis.Common.Abstractions.DualOutputResult, System.IEquatable<TechnicalAnalysis.Functions.StochRsiResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.Abstractions\.DualOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.abstractions.dualoutputresult 'TechnicalAnalysis\.Common\.Abstractions\.DualOutputResult') &#129106; StochRsiResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[StochRsiResult](StochRsiResult.md 'TechnicalAnalysis\.Functions\.StochRsiResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [StochRsiResult\(RetCode, int, int, double\[\], double\[\]\)](StochRsiResult.StochRsiResult(RetCode,int,int,double[],double[]).md 'TechnicalAnalysis\.Functions\.StochRsiResult\.StochRsiResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\]\)') | Initializes a new instance of the [StochRsiResult](StochRsiResult.md 'TechnicalAnalysis\.Functions\.StochRsiResult') class\. |

| Properties | |
| :--- | :--- |
| [FastD](StochRsiResult.FastD.md 'TechnicalAnalysis\.Functions\.StochRsiResult\.FastD') | Gets the array of %D values \(smoothed %K\)\. This is typically a 3\-period moving average of %K, providing a smoother signal line\. Values range from 0 to 100, with readings above 80 indicating overbought and below 20 indicating oversold\. |
| [FastK](StochRsiResult.FastK.md 'TechnicalAnalysis\.Functions\.StochRsiResult\.FastK') | Gets the array of %K values \(raw StochRSI\)\. This represents the position of the current RSI relative to its range over the lookback period\. Values range from 0 to 100, with extreme readings suggesting potential reversal points\. |
