#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MacdFixResult Class

Represents the result of calculating the MACD Fix indicator with fixed 12/26 periods\.

```csharp
public record MacdFixResult : TechnicalAnalysis.Common.TripleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.MacdFixResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.TripleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.tripleoutputresult 'TechnicalAnalysis\.Common\.TripleOutputResult') &#129106; MacdFixResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[MacdFixResult](MacdFixResult.md 'TechnicalAnalysis\.Functions\.MacdFixResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
MACD Fix uses the standard fixed periods of 12 and 26 for the fast and slow EMAs,
with a customizable signal period\. This is a variation of the MACD indicator that
maintains the traditional period settings while allowing signal line customization\.

| Constructors | |
| :--- | :--- |
| [MacdFixResult\(RetCode, int, int, double\[\], double\[\], double\[\]\)](MacdFixResult.MacdFixResult(RetCode,int,int,double[],double[],double[]).md 'TechnicalAnalysis\.Functions\.MacdFixResult\.MacdFixResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\], double\[\]\)') | Initializes a new instance of the [MacdFixResult](MacdFixResult.md 'TechnicalAnalysis\.Functions\.MacdFixResult') class\. |

| Properties | |
| :--- | :--- |
| [MACD](MacdFixResult.MACD.md 'TechnicalAnalysis\.Functions\.MacdFixResult\.MACD') | Gets the array of MACD line values\. |
| [MACDHist](MacdFixResult.MACDHist.md 'TechnicalAnalysis\.Functions\.MacdFixResult\.MACDHist') | Gets the array of MACD histogram values\. |
| [MACDSignal](MacdFixResult.MACDSignal.md 'TechnicalAnalysis\.Functions\.MacdFixResult\.MACDSignal') | Gets the array of signal line values\. |
