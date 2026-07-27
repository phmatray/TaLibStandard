#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

## PriceSeries\.FromClose\(ReadOnlySpan\<double\>\) Method

Creates a price series from closing prices alone\.

```csharp
public static TechnicalAnalysis.Functions.PriceSeries FromClose(System.ReadOnlySpan<double> close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.PriceSeries.FromClose(System.ReadOnlySpan_double_).close'></a>

`close` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The closing prices, copied into the new series\. May be empty\.

#### Returns
[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')  
A series with [BarCount](PriceSeries.BarCount.md 'TechnicalAnalysis\.Functions\.PriceSeries\.BarCount') equal to the length of [close](PriceSeries.FromClose(ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromClose(System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromClose\(System\.ReadOnlySpan\<double\>\)\.close')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[close](PriceSeries.FromClose(ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromClose(System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromClose\(System\.ReadOnlySpan\<double\>\)\.close') holds a value that is not finite\.

### Remarks
The resulting series carries no open, high, low or volume, and does not fabricate them\.
Indicators that need a bar's range throw rather than silently computing something else\.