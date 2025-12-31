#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MacdResult Class

Represents the result of calculating the Moving Average Convergence Divergence \(MACD\) indicator\.

```csharp
public record MacdResult : TechnicalAnalysis.Common.Abstractions.TripleOutputResult, System.IEquatable<TechnicalAnalysis.Functions.MacdResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; [TechnicalAnalysis\.Common\.Abstractions\.TripleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.abstractions.tripleoutputresult 'TechnicalAnalysis\.Common\.Abstractions\.TripleOutputResult') &#129106; MacdResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[MacdResult](MacdResult.md 'TechnicalAnalysis\.Functions\.MacdResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
MACD is a trend\-following momentum indicator that shows the relationship between
two moving averages of prices\. It consists of three components: the MACD line
\(difference between 12 and 26 period EMAs\), the signal line \(9 period EMA of MACD\),
and the histogram \(difference between MACD and signal line\)\.

| Constructors | |
| :--- | :--- |
| [MacdResult\(RetCode, int, int, double\[\], double\[\], double\[\]\)](MacdResult.MacdResult(RetCode,int,int,double[],double[],double[]).md 'TechnicalAnalysis\.Functions\.MacdResult\.MacdResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\], double\[\]\)') | Initializes a new instance of the [MacdResult](MacdResult.md 'TechnicalAnalysis\.Functions\.MacdResult') class\. |

| Properties | |
| :--- | :--- |
| [MacdHist](MacdResult.MacdHist.md 'TechnicalAnalysis\.Functions\.MacdResult\.MacdHist') | Gets the array of MACD histogram values\. |
| [MacdSignal](MacdResult.MacdSignal.md 'TechnicalAnalysis\.Functions\.MacdResult\.MacdSignal') | Gets the array of signal line values\. |
| [MacdValue](MacdResult.MacdValue.md 'TechnicalAnalysis\.Functions\.MacdResult\.MacdValue') | Gets the array of MACD line values\. |
