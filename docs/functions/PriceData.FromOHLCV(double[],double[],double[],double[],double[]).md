#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PriceData](PriceData.md 'TechnicalAnalysis\.Functions\.PriceData')

## PriceData\.FromOHLCV\(double\[\], double\[\], double\[\], double\[\], double\[\]\) Method

Creates a PriceData instance with volume data\.

```csharp
public static TechnicalAnalysis.Functions.PriceData FromOHLCV(double[] open, double[] high, double[] low, double[] close, double[] volume);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.PriceData.FromOHLCV(double[],double[],double[],double[],double[]).open'></a>

`open` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of opening prices\.

<a name='TechnicalAnalysis.Functions.PriceData.FromOHLCV(double[],double[],double[],double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.PriceData.FromOHLCV(double[],double[],double[],double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.PriceData.FromOHLCV(double[],double[],double[],double[],double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.PriceData.FromOHLCV(double[],double[],double[],double[],double[]).volume'></a>

`volume` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of volume data\.

#### Returns
[PriceData](PriceData.md 'TechnicalAnalysis\.Functions\.PriceData')  
A PriceData instance with OHLCV data\.