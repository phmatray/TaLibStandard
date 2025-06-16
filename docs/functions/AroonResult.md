#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AroonResult Class

Represents the result of the Aroon indicator calculation\.

```csharp
public record AroonResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.AroonResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; AroonResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[AroonResult](AroonResult.md 'TechnicalAnalysis\.Functions\.AroonResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
The Aroon indicator is a technical analysis tool used to identify trend changes and 
the strength of a trend\. It consists of two lines: Aroon Up and Aroon Down, both 
ranging from 0 to 100\. Aroon Up measures the time since the highest high within the 
lookback period, while Aroon Down measures the time since the lowest low\. High values 
\(70\-100\) indicate a strong trend, while low values \(0\-30\) suggest a weak trend or 
consolidation\. Crossovers between the lines can signal potential trend reversals\.

| Constructors | |
| :--- | :--- |
| [AroonResult\(RetCode, int, int, double\[\], double\[\]\)](AroonResult.AroonResult(RetCode,int,int,double[],double[]).md 'TechnicalAnalysis\.Functions\.AroonResult\.AroonResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\]\)') | Initializes a new instance of the [AroonResult](AroonResult.md 'TechnicalAnalysis\.Functions\.AroonResult') class\. |

| Properties | |
| :--- | :--- |
| [AroonDown](AroonResult.AroonDown.md 'TechnicalAnalysis\.Functions\.AroonResult\.AroonDown') | Gets the array of Aroon Down values\. |
| [AroonUp](AroonResult.AroonUp.md 'TechnicalAnalysis\.Functions\.AroonResult\.AroonUp') | Gets the array of Aroon Up values\. |
