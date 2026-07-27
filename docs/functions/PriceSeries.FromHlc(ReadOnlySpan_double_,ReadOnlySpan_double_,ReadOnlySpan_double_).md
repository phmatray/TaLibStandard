#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

## PriceSeries\.FromHlc\(ReadOnlySpan\<double\>, ReadOnlySpan\<double\>, ReadOnlySpan\<double\>\) Method

Creates a price series from high, low and closing prices\.

```csharp
public static TechnicalAnalysis.Functions.PriceSeries FromHlc(System.ReadOnlySpan<double> high, System.ReadOnlySpan<double> low, System.ReadOnlySpan<double> close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.PriceSeries.FromHlc(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).high'></a>

`high` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The high prices\. Must be the same length as [close](PriceSeries.FromHlc(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromHlc(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromHlc\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.close')\.

<a name='TechnicalAnalysis.Functions.PriceSeries.FromHlc(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).low'></a>

`low` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The low prices\. Must be the same length as [close](PriceSeries.FromHlc(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromHlc(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromHlc\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.close')\.

<a name='TechnicalAnalysis.Functions.PriceSeries.FromHlc(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close'></a>

`close` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The closing prices, which define the number of bars\. May be empty\.

#### Returns
[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')  
A series with [BarCount](PriceSeries.BarCount.md 'TechnicalAnalysis\.Functions\.PriceSeries\.BarCount') equal to the length of [close](PriceSeries.FromHlc(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromHlc(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromHlc\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.close')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[high](PriceSeries.FromHlc(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromHlc(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).high 'TechnicalAnalysis\.Functions\.PriceSeries\.FromHlc\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.high') or [low](PriceSeries.FromHlc(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromHlc(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).low 'TechnicalAnalysis\.Functions\.PriceSeries\.FromHlc\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.low') has a different length from
            [close](PriceSeries.FromHlc(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md#TechnicalAnalysis.Functions.PriceSeries.FromHlc(System.ReadOnlySpan_double_,System.ReadOnlySpan_double_,System.ReadOnlySpan_double_).close 'TechnicalAnalysis\.Functions\.PriceSeries\.FromHlc\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)\.close'), or any component holds a value that is not finite\.