#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## RocR100Result Class

Represents the result of calculating the Rate of Change Ratio 100 scale \(ROCR100\) indicator\.

```csharp
public record RocR100Result : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; RocR100Result

### Remarks
The Rate of Change Ratio 100 scale is a momentum indicator that measures the percentage change
between the current price and the price n periods ago, scaled to oscillate around 100\.
This scaling makes it easier to identify overbought and oversold conditions\.

| Constructors | |
| :--- | :--- |
| [RocR100Result\(RetCode, int, int, double\[\]\)](RocR100Result.RocR100Result(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.RocR100Result\.RocR100Result\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [RocR100Result](RocR100Result.md 'TechnicalAnalysis\.Functions\.RocR100Result') class\. |
