#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## MacdExtResult Class

Represents the result of calculating the Extended MACD indicator with configurable moving average types\.

```csharp
public record MacdExtResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.MacdExtResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; MacdExtResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[MacdExtResult](MacdExtResult.md 'TechnicalAnalysis\.Functions\.MacdExtResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
MACD Extended allows customization of the moving average types used for calculating
the fast MA, slow MA, and signal line\. This provides more flexibility than the
standard MACD which uses only exponential moving averages\.

| Constructors | |
| :--- | :--- |
| [MacdExtResult\(RetCode, int, int, double\[\], double\[\], double\[\]\)](MacdExtResult.MacdExtResult(RetCode,int,int,double[],double[],double[]).md 'TechnicalAnalysis\.Functions\.MacdExtResult\.MacdExtResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\], double\[\]\)') | Initializes a new instance of the [MacdExtResult](MacdExtResult.md 'TechnicalAnalysis\.Functions\.MacdExtResult') class\. |

| Properties | |
| :--- | :--- |
| [MACD](MacdExtResult.MACD.md 'TechnicalAnalysis\.Functions\.MacdExtResult\.MACD') | Gets the array of MACD line values\. |
| [MACDHist](MacdExtResult.MACDHist.md 'TechnicalAnalysis\.Functions\.MacdExtResult\.MACDHist') | Gets the array of MACD histogram values\. |
| [MACDSignal](MacdExtResult.MACDSignal.md 'TechnicalAnalysis\.Functions\.MacdExtResult\.MACDSignal') | Gets the array of signal line values\. |
