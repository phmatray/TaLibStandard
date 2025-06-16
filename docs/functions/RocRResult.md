#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## RocRResult Class

Represents the result of calculating the Rate of Change Ratio \(ROCR\) indicator\.

```csharp
public record RocRResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.RocRResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; RocRResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[RocRResult](RocRResult.md 'TechnicalAnalysis\.Functions\.RocRResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The Rate of Change Ratio measures the ratio between the current price and the price n periods ago\.
Unlike the standard ROC which shows percentage change, ROCR shows the price ratio, making it useful
for comparing relative strength and identifying momentum changes in price movements\.

| Constructors | |
| :--- | :--- |
| [RocRResult\(RetCode, int, int, double\[\]\)](RocRResult.RocRResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.RocRResult\.RocRResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [RocRResult](RocRResult.md 'TechnicalAnalysis\.Functions\.RocRResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](RocRResult.Real.md 'TechnicalAnalysis\.Functions\.RocRResult\.Real') | Gets the array of Rate of Change Ratio values\. |
