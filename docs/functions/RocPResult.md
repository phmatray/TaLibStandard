#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## RocPResult Class

Represents the result of the Rate of Change Percentage \(ROCP\) indicator calculation\.
This momentum indicator measures the rate of change in price expressed as a decimal percentage \(0\.1 = 10%\)\.

```csharp
public record RocPResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.RocPResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; RocPResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[RocPResult](RocPResult.md 'TechnicalAnalysis\.Functions\.RocPResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [RocPResult\(RetCode, int, int, double\[\]\)](RocPResult.RocPResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.RocPResult\.RocPResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [RocPResult](RocPResult.md 'TechnicalAnalysis\.Functions\.RocPResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](RocPResult.Real.md 'TechnicalAnalysis\.Functions\.RocPResult\.Real') | Gets the array of Rate of Change Percentage values\. Each value represents the rate of change as a decimal \(e\.g\., 0\.05 = 5% increase, \-0\.03 = 3% decrease\)\. This is calculated as: \(price \- price\[n periods ago\]\) / price\[n periods ago\]\. |
