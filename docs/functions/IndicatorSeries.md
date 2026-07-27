#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## IndicatorSeries Struct

A bar\-aligned view over a single output series produced by a TA\-Lib indicator\.
This is the one place in the library where TA\-Lib's raw alignment metadata is interpreted\.

```csharp
public readonly struct IndicatorSeries : System.IEquatable<TechnicalAnalysis.Functions.IndicatorSeries>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Example

```csharp
PriceSeries prices = PriceSeries.FromClose(closes);
IndicatorSeries sma = prices.Sma(30);

double? latest = sma.Latest;          // null until the indicator has warmed up
double? atBar50 = sma[50];            // 50 is a BAR index, not an array index
if (sma[50] is { } value)
{
    Console.WriteLine(value);
}
```

### Remarks

<b>There are two index spaces, and confusing them is the classic TA-Lib bug.</b>

An <i>array index</i> is a subscript into the raw [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')`[]` that a
`TAMath` call returned. TA-Lib fills that array starting at array index `0`, and it
writes exactly `NBElement` elements, so the last valid array index is
`NBElement - 1`. Everything from `NBElement` to the end of the allocated array is
untouched zero padding and means nothing.

A <i>bar index</i> is a position in the source price series, with domain
`[0, BarCount)`. TA-Lib reports `BegIdx`, which is a <b>bar</b> index: output array
element `k` describes bar `BegIdx + k`. The last valid bar index is therefore
`BegIdx + NBElement - 1`.

`NBElement - 1` and `BegIdx + NBElement - 1` are two different numbers; they coincide
             only when `BegIdx == 0`. Subscripting the output array with the bar index
             `BegIdx + NBElement - 1` lands in the zero padding and silently yields `0.0`. That is
             the mistake this type exists to make unsayable.

<b>The rule.</b> Every [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32') on this type that names a position is a BAR index.
             That covers the `bar` parameter of [this\[int\]](IndicatorSeries.this[int].md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.this\[int\]'), [IsWarmAt\(int\)](IndicatorSeries.IsWarmAt(int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.IsWarmAt\(int\)'),
             [AsOf\(int\)](IndicatorSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.AsOf\(int\)') and all four crossing overloads; the values returned by
             [FirstBar](IndicatorSeries.FirstBar.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.FirstBar') and [LastBar](IndicatorSeries.LastBar.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.LastBar'); the `Bar` component yielded by
             [GetEnumerator\(\)](IndicatorSeries.GetEnumerator().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.GetEnumerator\(\)'); and the index space of [ToBarAlignedArray\(\)](IndicatorSeries.ToBarAlignedArray().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.ToBarAlignedArray\(\)'),
             [ToBarAlignedNullableArray\(\)](IndicatorSeries.ToBarAlignedNullableArray().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.ToBarAlignedNullableArray\(\)') and [CopyBarAligned\(Span&lt;double&gt;\)](IndicatorSeries.CopyBarAligned(Span_double_).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CopyBarAligned\(System\.Span\<double\>\)').
             [WarmCount](IndicatorSeries.WarmCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmCount') and [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount') are counts, not indices, and neither is a
             valid loop bound for the indexer — the indexer's domain is `[0, BarCount)`, so a loop over
             it must be bounded by [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount'). No member of this type accepts or returns a raw
             TA-Lib output-array index, with the single deliberate exception of [WarmValues](IndicatorSeries.WarmValues.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmValues'),
             whose name and documentation state its index space explicitly. [Create\(RetCode, int, int, double\[\], int\)](IndicatorSeries.Create(RetCode,int,int,double[],int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)') is the sole
             point at which raw TA-Lib metadata enters the type system.

<b>Absence is <c>null</c>, uniformly.</b> A bar that is inside the series but before the
             indicator has warmed up has no value, and that is reported as `null` — never `0.0`,
             never [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN'), and never an exception. There is no sentinel value anywhere on
             this type: [this\[int\]](IndicatorSeries.this[int].md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.this\[int\]') and [Latest](IndicatorSeries.Latest.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Latest') are [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')`?`,
             and [FirstBar](IndicatorSeries.FirstBar.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.FirstBar') and [LastBar](IndicatorSeries.LastBar.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.LastBar') are [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')`?`. The single
             exception is [ToBarAlignedArray\(\)](IndicatorSeries.ToBarAlignedArray().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.ToBarAlignedArray\(\)') and [CopyBarAligned\(Span&lt;double&gt;\)](IndicatorSeries.CopyBarAligned(Span_double_).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CopyBarAligned\(System\.Span\<double\>\)'), which pad with
             [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') because a [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')`[]` cannot hold `null`;
             [ToBarAlignedNullableArray\(\)](IndicatorSeries.ToBarAlignedNullableArray().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.ToBarAlignedNullableArray\(\)') is the projection that keeps the promise.

<b>A bar outside <c>[0, BarCount)</c> is a caller bug</b> and throws
             [System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException'). "Bar 5 of a 30-period SMA" is a legitimate question
             whose answer is "no value"; "bar 5000 of a 100-bar series" is not a question at all. That split
             is what turns [AsOf\(int\)](IndicatorSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.AsOf\(int\)') into a causality guarantee rather than a convention.

<b>
  <see cref="P:TechnicalAnalysis.Functions.IndicatorSeries.RetCode"/> is not warmth.</b> A successful call over too little data reports
             [TechnicalAnalysis\.Common\.RetCode\.Success](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode.success 'TechnicalAnalysis\.Common\.RetCode\.Success') with `BegIdx == 0` and `NBElement == 0`, and in
             that state `BegIdx` is a lie. [HasValues](IndicatorSeries.HasValues.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.HasValues') (equivalently
             `WarmCount > 0`) is the only warmth test. `default(IndicatorSeries)` is a valid
             series with no values that reports [TechnicalAnalysis\.Common\.RetCode\.Success](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode.success 'TechnicalAnalysis\.Common\.RetCode\.Success'), because
             `Success == 0`.

This is an immutable value type, and its immutability is unconditional: [Create\(RetCode, int, int, double\[\], int\)](IndicatorSeries.Create(RetCode,int,int,double[],int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)')
copies the warm values out of the array it is handed, so no caller can reach inside a series
after handing it over. Every instance is therefore safe for unrestricted concurrent use.

| Properties | |
| :--- | :--- |
| [BarCount](IndicatorSeries.BarCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.BarCount') | Gets the number of bars in the source price series\. |
| [FirstBar](IndicatorSeries.FirstBar.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.FirstBar') | Gets the BAR index of the first bar that has a value, or `null` when no bar has one\. |
| [HasValues](IndicatorSeries.HasValues.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.HasValues') | Gets a value indicating whether any bar of this series carries a value\. |
| [LastBar](IndicatorSeries.LastBar.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.LastBar') | Gets the BAR index of the last bar that has a value, or `null` when no bar has one\. |
| [Latest](IndicatorSeries.Latest.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Latest') | Gets the most recent value in the series, or `null` when no bar has a value\. |
| [RetCode](IndicatorSeries.RetCode.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.RetCode') | Gets the return code reported by the underlying TA\-Lib call\. |
| [this\[int\]](IndicatorSeries.this[int].md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.this\[int\]') | Gets the value at the given BAR index, or `null` when that bar has no value\. |
| [WarmCount](IndicatorSeries.WarmCount.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmCount') | Gets the number of bars that carry a value — TA\-Lib's `NBElement`\. |
| [WarmValues](IndicatorSeries.WarmValues.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmValues') | Gets the values as a span whose element `k` describes bar `FirstBar + k`\. |

| Methods | |
| :--- | :--- |
| [AsOf\(int\)](IndicatorSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.AsOf\(int\)') | Returns the same series truncated so that it ends at the given BAR index, making look\-ahead unrepresentable rather than merely detectable\. |
| [CopyBarAligned\(Span&lt;double&gt;\)](IndicatorSeries.CopyBarAligned(Span_double_).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CopyBarAligned\(System\.Span\<double\>\)') | Writes the series into the given span in which the index is the BAR index\. |
| [Create\(RetCode, int, int, double\[\], int\)](IndicatorSeries.Create(RetCode,int,int,double[],int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)') | Creates a bar\-aligned series from the raw metadata of a TA\-Lib call\. This is the only point in the library at which raw TA\-Lib alignment metadata enters the type system\. |
| [CrossedAbove\(double, int\)](IndicatorSeries.CrossedAbove.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(double,int) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(double, int\)') | Determines whether this series crossed above a fixed level at the given BAR index\. |
| [CrossedAbove\(IndicatorSeries, int\)](IndicatorSeries.CrossedAbove.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedAbove(TechnicalAnalysis.Functions.IndicatorSeries,int) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedAbove\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)') | Determines whether this series crossed above another series at the given BAR index\. |
| [CrossedBelow\(double, int\)](IndicatorSeries.CrossedBelow.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(double,int) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(double, int\)') | Determines whether this series crossed below a fixed level at the given BAR index\. |
| [CrossedBelow\(IndicatorSeries, int\)](IndicatorSeries.CrossedBelow.md#TechnicalAnalysis.Functions.IndicatorSeries.CrossedBelow(TechnicalAnalysis.Functions.IndicatorSeries,int) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.CrossedBelow\(TechnicalAnalysis\.Functions\.IndicatorSeries, int\)') | Determines whether this series crossed below another series at the given BAR index\. |
| [Empty\(int\)](IndicatorSeries.Empty(int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Empty\(int\)') | Creates a series covering the given number of bars in which no bar has a value\. |
| [Equals\(object\)](IndicatorSeries.Equals.md#TechnicalAnalysis.Functions.IndicatorSeries.Equals(object) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Equals\(object\)') | Determines whether this series equals the given object\. |
| [Equals\(IndicatorSeries\)](IndicatorSeries.Equals.md#TechnicalAnalysis.Functions.IndicatorSeries.Equals(TechnicalAnalysis.Functions.IndicatorSeries) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Equals\(TechnicalAnalysis\.Functions\.IndicatorSeries\)') | Determines whether this series equals another\. |
| [GetEnumerator\(\)](IndicatorSeries.GetEnumerator().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.GetEnumerator\(\)') | Returns an allocation\-free enumerator over the bars of this series that carry a value\. |
| [GetHashCode\(\)](IndicatorSeries.GetHashCode().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.GetHashCode\(\)') | Returns a hash code consistent with [Equals\(IndicatorSeries\)](IndicatorSeries.Equals.md#TechnicalAnalysis.Functions.IndicatorSeries.Equals(TechnicalAnalysis.Functions.IndicatorSeries) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Equals\(TechnicalAnalysis\.Functions\.IndicatorSeries\)')\. |
| [IsWarmAt\(int\)](IndicatorSeries.IsWarmAt(int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.IsWarmAt\(int\)') | Determines whether the given BAR index has a value\. |
| [ToBarAlignedArray\(\)](IndicatorSeries.ToBarAlignedArray().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.ToBarAlignedArray\(\)') | Projects the series onto a new array indexed by BAR index, padding bars that have no value with [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN')\. |
| [ToBarAlignedNullableArray\(\)](IndicatorSeries.ToBarAlignedNullableArray().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.ToBarAlignedNullableArray\(\)') | Projects the series onto a new array indexed by BAR index, with `null` for bars that have no value\. |
| [WarmValuesToArray\(\)](IndicatorSeries.WarmValuesToArray().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmValuesToArray\(\)') | Copies the values into a new array whose element `k` describes bar `FirstBar + k`\. |

| Operators | |
| :--- | :--- |
| [operator ==\(IndicatorSeries, IndicatorSeries\)](IndicatorSeries.operator(IndicatorSeries,IndicatorSeries).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.op\_Equality\(TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries\)') | Determines whether two series are equal\. |
| [operator \!=\(IndicatorSeries, IndicatorSeries\)](IndicatorSeries.operator!(IndicatorSeries,IndicatorSeries).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.op\_Inequality\(TechnicalAnalysis\.Functions\.IndicatorSeries, TechnicalAnalysis\.Functions\.IndicatorSeries\)') | Determines whether two series are not equal\. |
