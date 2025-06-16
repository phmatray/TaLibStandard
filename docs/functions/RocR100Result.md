#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## RocR100Result Class

Represents the result of calculating the Rate of Change Ratio 100 scale \(ROCR100\) indicator\.

```csharp
public record RocR100Result : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.RocR100Result>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; RocR100Result

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[RocR100Result](RocR100Result.md 'TechnicalAnalysis\.Functions\.RocR100Result')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The Rate of Change Ratio 100 scale is a momentum indicator that measures the percentage change
between the current price and the price n periods ago, scaled to oscillate around 100\.
This scaling makes it easier to identify overbought and oversold conditions\.

| Constructors | |
| :--- | :--- |
| [RocR100Result\(RetCode, int, int, double\[\]\)](RocR100Result.RocR100Result(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.RocR100Result\.RocR100Result\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [RocR100Result](RocR100Result.md 'TechnicalAnalysis\.Functions\.RocR100Result') class\. |

| Properties | |
| :--- | :--- |
| [Real](RocR100Result.Real.md 'TechnicalAnalysis\.Functions\.RocR100Result\.Real') | Gets the array of Rate of Change Ratio 100 scale values\. |
