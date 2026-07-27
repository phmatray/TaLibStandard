#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.ToBarAlignedArray\(\) Method

Projects the series onto a new array indexed by BAR index, padding bars that have no value
with [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN')\.

```csharp
public double[] ToBarAlignedArray();
```

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
A new array of exactly [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount') elements in which element `i` describes
bar `i`\. The padding value is [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') and is deliberately not
configurable, because padding with `0.0` reinstates exactly the silent corruption this
type exists to prevent\.

### Remarks

<b>
  <see cref="F:System.Double.NaN"/> is a sentinel here, and it is the one place on this type where
            absence is not <c>null</c>.</b> A [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')`[]` cannot hold `null`, so
            this projection collapses "this bar has no value" and "this bar has a value and the value is
            not finite" onto the same bit pattern. The fluent factories reject non-finite prices, so a
            series produced through this API cannot contain a computed [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN'); a
            series built through [Create\(RetCode, int, int, double\[\], int\)](IndicatorSeries.Create(RetCode,int,int,double[],int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)') from a hand-rolled call can. When the two states
            must be told apart, use [IsWarmAt\(int\)](IndicatorSeries.IsWarmAt(int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.IsWarmAt\(int\)'), [this\[int\]](IndicatorSeries.this[int].md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.this\[int\]') or
            [ToBarAlignedNullableArray\(\)](IndicatorSeries.ToBarAlignedNullableArray().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.ToBarAlignedNullableArray\(\)'), none of which have a sentinel.

Because every indicator has a warm-up, the result of this method almost always contains
[System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN'): `ToBarAlignedArray().Max()` and `.Average()` are
[System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') for a typical series, and a chart fed the raw array must be told
how to skip them.