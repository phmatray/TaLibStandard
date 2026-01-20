#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PriceData](PriceData.md 'TechnicalAnalysis\.Functions\.PriceData')

## PriceData\.FromClose\(double\[\]\) Method

Creates a PriceData instance from closing prices only\.

```csharp
public static TechnicalAnalysis.Functions.PriceData FromClose(double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.PriceData.FromClose(double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

#### Returns
[PriceData](PriceData.md 'TechnicalAnalysis\.Functions\.PriceData')  
A PriceData instance with all OHLC values set to the closing prices\.

### Remarks
This is useful for indicators that only require closing prices \(e\.g\., SMA, EMA\)\.
The Open, High, and Low arrays will be set to the same values as Close\.