#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## CciResult Class

Represents the result of the Commodity Channel Index \(CCI\) indicator calculation\.
CCI is a momentum oscillator that measures the difference between a security's price and its statistical mean, used to identify overbought and oversold conditions\.

```csharp
public record CciResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.CciResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; CciResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[CciResult](CciResult.md 'TechnicalAnalysis\.Functions\.CciResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [CciResult\(RetCode, int, int, double\[\]\)](CciResult.CciResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.CciResult\.CciResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [CciResult](CciResult.md 'TechnicalAnalysis\.Functions\.CciResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](CciResult.Real.md 'TechnicalAnalysis\.Functions\.CciResult\.Real') | Gets the array of Commodity Channel Index values\. Values above \+100 indicate overbought conditions, while values below \-100 indicate oversold conditions\. Values between \-100 and \+100 indicate normal trading conditions\. |
