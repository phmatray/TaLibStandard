#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MfiResult Class

Represents the result of the Money Flow Index \(MFI\) indicator calculation\.

```csharp
public record MfiResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MfiResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MfiResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[MfiResult](MfiResult.md 'TechnicalAnalysis\.Functions\.MfiResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The Money Flow Index is a momentum indicator that incorporates both price and volume 
data to measure buying and selling pressure\. Often referred to as a volume\-weighted RSI, 
MFI oscillates between 0 and 100\. Values above 80 typically indicate overbought conditions, 
while values below 20 indicate oversold conditions\. The indicator is particularly useful 
for identifying potential reversals and divergences between price and volume flow\.

| Constructors | |
| :--- | :--- |
| [MfiResult\(RetCode, int, int, double\[\]\)](MfiResult.MfiResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.MfiResult\.MfiResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [MfiResult](MfiResult.md 'TechnicalAnalysis\.Functions\.MfiResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](MfiResult.Real.md 'TechnicalAnalysis\.Functions\.MfiResult\.Real') | Gets the array of Money Flow Index values\. |
