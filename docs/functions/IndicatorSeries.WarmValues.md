#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.WarmValues Property

Gets the values as a span whose element `k` describes bar `FirstBar + k`\.

```csharp
public System.ReadOnlySpan<double> WarmValues { get; }
```

#### Property Value
[System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')  
A read\-only span of exactly [WarmCount](IndicatorSeries.WarmCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmCount') elements — the single ARRAY\-indexed view
on this type, which is why it is named `WarmValues` rather than `Values`\. It
starts at array index `0` and is sliced to [WarmCount](IndicatorSeries.WarmCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmCount'), so TA\-Lib's
untouched zero padding is unreachable and the historical expression
`Values[BegIdx + NBElement - 1]` throws [System\.IndexOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception 'System\.IndexOutOfRangeException') instead
of silently returning a padding zero\. A bar index is \<b\>not\</b\> a valid subscript here: use
[this\[int\]](IndicatorSeries.this[int].md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.this\[int\]') for that\. A series with no values yields an empty span\.