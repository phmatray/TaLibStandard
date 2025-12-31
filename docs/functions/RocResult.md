#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## RocResult Class

Represents the result of the Rate of Change \(ROC\) indicator calculation\.
This momentum indicator measures the percentage change in price between the current price and the price n periods ago\.

```csharp
public record RocResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.RocResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; RocResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[RocResult](RocResult.md 'TechnicalAnalysis\.Functions\.RocResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [RocResult\(RetCode, int, int, double\[\]\)](RocResult.RocResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.RocResult\.RocResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [RocResult](RocResult.md 'TechnicalAnalysis\.Functions\.RocResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](RocResult.Real.md 'TechnicalAnalysis\.Functions\.RocResult\.Real') | Gets the array of Rate of Change values\. Each value represents the percentage change from n periods ago, calculated as: \(\(price \- price\[n periods ago\]\) / price\[n periods ago\]\) \* 100\. Positive values indicate upward momentum, while negative values indicate downward momentum\. |
