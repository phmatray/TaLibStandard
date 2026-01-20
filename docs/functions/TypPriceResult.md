#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## TypPriceResult Class

Represents the result of the Typical Price calculation\.

```csharp
public record TypPriceResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; TypPriceResult

### Remarks
The Typical Price is a price transformation that represents the average price of a
trading period, calculated as the arithmetic mean of the high, low, and close prices\.
It is widely used as a more representative single price point than just the closing
price, as it incorporates the entire trading range\. The formula is: \(High \+ Low \+ Close\) / 3\.
This price is often used as the basis for other indicators like Money Flow Index and
Commodity Channel Index\.

| Constructors | |
| :--- | :--- |
| [TypPriceResult\(RetCode, int, int, double\[\]\)](TypPriceResult.TypPriceResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.TypPriceResult\.TypPriceResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [TypPriceResult](TypPriceResult.md 'TechnicalAnalysis\.Functions\.TypPriceResult') class\. |
