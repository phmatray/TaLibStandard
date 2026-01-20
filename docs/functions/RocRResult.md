#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## RocRResult Class

Represents the result of calculating the Rate of Change Ratio \(ROCR\) indicator\.

```csharp
public record RocRResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; RocRResult

### Remarks
The Rate of Change Ratio measures the ratio between the current price and the price n periods ago\.
Unlike the standard ROC which shows percentage change, ROCR shows the price ratio, making it useful
for comparing relative strength and identifying momentum changes in price movements\.

| Constructors | |
| :--- | :--- |
| [RocRResult\(RetCode, int, int, double\[\]\)](RocRResult.RocRResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.RocRResult\.RocRResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [RocRResult](RocRResult.md 'TechnicalAnalysis\.Functions\.RocRResult') class\. |
