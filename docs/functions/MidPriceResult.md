#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MidPriceResult Class

Represents the result of calculating the MidPrice indicator\.

```csharp
public record MidPriceResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.MidPriceResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; MidPriceResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[MidPriceResult](MidPriceResult.md 'TechnicalAnalysis\.Functions\.MidPriceResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The MidPrice indicator calculates the midpoint between the high and low prices
over a specified period\. Unlike MidPoint which can work with any data series,
MidPrice specifically uses high and low price data to find the center of the trading range\.

| Constructors | |
| :--- | :--- |
| [MidPriceResult\(RetCode, int, int, double\[\]\)](MidPriceResult.MidPriceResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MidPriceResult\.MidPriceResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MidPriceResult](MidPriceResult.md 'TechnicalAnalysis\.Functions\.MidPriceResult') class\. |
