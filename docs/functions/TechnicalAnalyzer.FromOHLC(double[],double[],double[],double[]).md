#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TechnicalAnalyzer](TechnicalAnalyzer.md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer')

## TechnicalAnalyzer\.FromOHLC\(double\[\], double\[\], double\[\], double\[\]\) Method

Creates a new TechnicalAnalyzer instance from OHLC price data\.

```csharp
public static TechnicalAnalysis.Functions.TechnicalAnalyzer FromOHLC(double[] open, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TechnicalAnalyzer.FromOHLC(double[],double[],double[],double[]).open'></a>

`open` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of opening prices\.

<a name='TechnicalAnalysis.Functions.TechnicalAnalyzer.FromOHLC(double[],double[],double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TechnicalAnalyzer.FromOHLC(double[],double[],double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TechnicalAnalyzer.FromOHLC(double[],double[],double[],double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

#### Returns
[TechnicalAnalyzer](TechnicalAnalyzer.md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer')  
A TechnicalAnalyzer instance ready for analysis\.

### Remarks
This is the recommended method for creating a TechnicalAnalyzer when you have
complete OHLC data\. All indicators will have access to the full price range,
ensuring accurate calculations\.