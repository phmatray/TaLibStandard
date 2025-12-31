#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## ZigZagResult Class

Represents the result of calculating the Zig Zag indicator\.

```csharp
public record ZigZagResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.ZigZagResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; ZigZagResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[ZigZagResult](ZigZagResult.md 'TechnicalAnalysis\.Functions\.ZigZagResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The Zig Zag indicator filters out price movements smaller than a specified percentage,
connecting significant peaks and troughs with straight lines\. It helps identify trend
reversals and eliminates random price fluctuations, making it easier to see the underlying
price structure and major support/resistance levels\.

| Constructors | |
| :--- | :--- |
| [ZigZagResult\(RetCode, int, int, double\[\]\)](ZigZagResult.ZigZagResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.ZigZagResult\.ZigZagResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [ZigZagResult](ZigZagResult.md 'TechnicalAnalysis\.Functions\.ZigZagResult') class\. |
