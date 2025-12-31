#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AroonOscResult Class

Represents the result of the Aroon Oscillator calculation\.

```csharp
public record AroonOscResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.AroonOscResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; AroonOscResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[AroonOscResult](AroonOscResult.md 'TechnicalAnalysis\.Functions\.AroonOscResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The Aroon Oscillator is derived from the Aroon indicator and is calculated as the 
difference between Aroon Up and Aroon Down \(Aroon Up \- Aroon Down\)\. It oscillates 
between \-100 and \+100, with zero as the centerline\. Positive values indicate an 
upward trend \(Aroon Up is greater than Aroon Down\), while negative values indicate 
a downward trend\. The farther the oscillator is from the zero line, the stronger 
the trend\. Crossovers through zero can signal trend changes, making this a valuable 
tool for trend identification and timing entry/exit points\.

| Constructors | |
| :--- | :--- |
| [AroonOscResult\(RetCode, int, int, double\[\]\)](AroonOscResult.AroonOscResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.AroonOscResult\.AroonOscResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [AroonOscResult](AroonOscResult.md 'TechnicalAnalysis\.Functions\.AroonOscResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](AroonOscResult.Real.md 'TechnicalAnalysis\.Functions\.AroonOscResult\.Real') | Gets the array of Aroon Oscillator values\. |
