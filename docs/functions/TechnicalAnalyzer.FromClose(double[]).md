#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TechnicalAnalyzer](TechnicalAnalyzer.md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer')

## TechnicalAnalyzer\.FromClose\(double\[\]\) Method

Creates a new TechnicalAnalyzer instance from closing prices only\.

```csharp
public static TechnicalAnalysis.Functions.TechnicalAnalyzer FromClose(double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TechnicalAnalyzer.FromClose(double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

#### Returns
[TechnicalAnalyzer](TechnicalAnalyzer.md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer')  
A TechnicalAnalyzer instance ready for analysis\.

### Remarks
This convenience method is useful when you only have closing price data\.
Note that some indicators \(like ADX, Stochastic, ATR\) require High, Low, and Close
prices for accurate calculation\. When using this method, all OHLC values will be
set to the closing prices, which may affect indicator accuracy\.