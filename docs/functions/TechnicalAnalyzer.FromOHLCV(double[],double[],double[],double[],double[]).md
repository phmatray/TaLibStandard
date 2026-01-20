#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TechnicalAnalyzer](TechnicalAnalyzer.md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer')

## TechnicalAnalyzer\.FromOHLCV\(double\[\], double\[\], double\[\], double\[\], double\[\]\) Method

Creates a new TechnicalAnalyzer instance from OHLCV price data\.

```csharp
public static TechnicalAnalysis.Functions.TechnicalAnalyzer FromOHLCV(double[] open, double[] high, double[] low, double[] close, double[] volume);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TechnicalAnalyzer.FromOHLCV(double[],double[],double[],double[],double[]).open'></a>

`open` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of opening prices\.

<a name='TechnicalAnalysis.Functions.TechnicalAnalyzer.FromOHLCV(double[],double[],double[],double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TechnicalAnalyzer.FromOHLCV(double[],double[],double[],double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TechnicalAnalyzer.FromOHLCV(double[],double[],double[],double[],double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TechnicalAnalyzer.FromOHLCV(double[],double[],double[],double[],double[]).volume'></a>

`volume` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of volume data\.

#### Returns
[TechnicalAnalyzer](TechnicalAnalyzer.md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer')  
A TechnicalAnalyzer instance ready for analysis\.

### Remarks
Use this method when you have volume data available\. While the current high\-level
indicators don't use volume, having it available enables future volume\-based
analysis operations\.