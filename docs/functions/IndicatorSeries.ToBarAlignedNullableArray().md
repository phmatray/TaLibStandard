#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.ToBarAlignedNullableArray\(\) Method

Projects the series onto a new array indexed by BAR index, with `null` for bars that
have no value\.

```csharp
public System.Nullable<double>[] ToBarAlignedNullableArray();
```

#### Returns
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
A new array of exactly [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount') elements in which element `i` describes
bar `i`, and a bar with no value is `null` rather than a sentinel\.

### Remarks
This is the projection that keeps the type's central promise — absence is `null` — at
the cost of a boxed\-free but larger [System\.Nullable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1') array\. Prefer
[ToBarAlignedArray\(\)](IndicatorSeries.ToBarAlignedArray().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.ToBarAlignedArray\(\)') only when the consumer needs a contiguous
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')`[]` and already understands the
[System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') convention\.