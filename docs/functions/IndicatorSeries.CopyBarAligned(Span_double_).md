#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.CopyBarAligned\(Span\<double\>\) Method

Writes the series into the given span in which the index is the BAR index\.

```csharp
public void CopyBarAligned(System.Span<double> destination);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.CopyBarAligned(System.Span_double_).destination'></a>

`destination` [System\.Span&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.span-1 'System\.Span\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.span-1 'System\.Span\`1')

The span to write into\. Its first [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount') elements are overwritten, so that
element `i` describes bar `i`; bars that have no value are written as
[System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN')\. Any elements beyond [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount') are left untouched\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[destination](IndicatorSeries.CopyBarAligned(Span_double_).md#TechnicalAnalysis.Functions.IndicatorSeries.CopyBarAligned(System.Span_double_).destination 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CopyBarAligned\(System\.Span\<double\>\)\.destination') is shorter than [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount')\.

### Remarks
The [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') padding carries the same caveat as
[ToBarAlignedArray\(\)](IndicatorSeries.ToBarAlignedArray().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.ToBarAlignedArray\(\)'): it is a sentinel, and it cannot be told apart from a
computed non\-finite value by inspecting the destination alone\.