#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

## PriceSeries\.HasHighLow Property

Gets a value indicating whether the series carries high and low prices\.

```csharp
public bool HasHighLow { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when the series was built by [FromHlc\(ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;\)](PriceSeries.FromHlc(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md 'TechnicalAnalysis\.Functions\.PriceSeries\.FromHlc\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)'), [FromOhlc\(ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;\)](PriceSeries.FromOhlc(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlc\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)') or
            [FromOhlcv\(ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;\)](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)')\. Indicators that need a bar's range, such as ATR and the stochastic
            oscillator, require this\.