#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

## PriceSeries\.FromOhlcv\(ReadOnlySpan\<double\>, ReadOnlySpan\<double\>, ReadOnlySpan\<double\>, ReadOnlySpan\<double\>, ReadOnlySpan\<double\>\) Method

Creates a price series from open, high, low and closing prices together with volumes\.

```csharp
public static TechnicalAnalysis.Functions.PriceSeries FromOhlcv(System.ReadOnlySpan<double> open, System.ReadOnlySpan<double> high, System.ReadOnlySpan<double> low, System.ReadOnlySpan<double> close, System.ReadOnlySpan<double> volume);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).open'></a>

`open` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The opening prices\. Must be the same length as [close](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.close')\.

<a name='TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).high'></a>

`high` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The high prices\. Must be the same length as [close](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.close')\.

<a name='TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).low'></a>

`low` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The low prices\. Must be the same length as [close](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.close')\.

<a name='TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close'></a>

`close` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The closing prices, which define the number of bars\. May be empty\.

<a name='TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).volume'></a>

`volume` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The volumes\. Must be the same length as [close](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.close')\.

#### Returns
[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')  
A series with [BarCount](PriceSeries.BarCount.md 'TechnicalAnalysis\.Functions\.PriceSeries\.BarCount') equal to the length of [close](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.close')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[open](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).open 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.open'), [high](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).high 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.high'), [low](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).low 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.low') or
            [volume](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).volume 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.volume') has a different length from [close](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromOhlcv(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.close'), or any
            component holds a value that is not finite\. Components are checked in the order open, high,
            low, volume\.