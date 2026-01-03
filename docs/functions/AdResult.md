#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AdResult Class

Represents the result of the Accumulation/Distribution Line \(A/D\) indicator calculation\.

```csharp
public record AdResult : TechnicalAnalysis.Common.SingleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.AdResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; AdResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[AdResult](AdResult.md 'TechnicalAnalysis\.Functions\.AdResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The A/D Line is a volume\-based indicator that measures the cumulative flow of money into 
and out of a security\. It combines price and volume to show how money may be flowing 
into or out of a stock\. Rising A/D values indicate accumulation \(buying pressure\), 
while falling values indicate distribution \(selling pressure\)\.

| Constructors | |
| :--- | :--- |
| [AdResult\(RetCode, int, int, double\[\]\)](AdResult.AdResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.AdResult\.AdResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [AdResult](AdResult.md 'TechnicalAnalysis\.Functions\.AdResult') class\. |
