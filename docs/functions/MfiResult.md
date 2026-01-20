#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MfiResult Class

Represents the result of the Money Flow Index \(MFI\) indicator calculation\.

```csharp
public record MfiResult : TechnicalAnalysis.Common.SingleOutputResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; MfiResult

### Remarks
The Money Flow Index is a momentum indicator that incorporates both price and volume 
data to measure buying and selling pressure\. Often referred to as a volume\-weighted RSI, 
MFI oscillates between 0 and 100\. Values above 80 typically indicate overbought conditions, 
while values below 20 indicate oversold conditions\. The indicator is particularly useful 
for identifying potential reversals and divergences between price and volume flow\.

| Constructors | |
| :--- | :--- |
| [MfiResult\(RetCode, int, int, double\[\]\)](MfiResult.MfiResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MfiResult\.MfiResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MfiResult](MfiResult.md 'TechnicalAnalysis\.Functions\.MfiResult') class\. |
