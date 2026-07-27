#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## PriceSeries Struct

An immutable price series — the entry point to the fluent indicator API\.

```csharp
public readonly struct PriceSeries : System.IEquatable<TechnicalAnalysis.Functions.PriceSeries>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Example

```csharp
PriceSeries prices = PriceSeries.FromHlc(highs, lows, closes);
double? rsi = prices.Rsi(14).Latest;
double? atr = prices.Atr(14).Latest;
```

### Remarks

Build one with the factory that matches the data you actually have, then call an indicator on
it. Every position on this type is a BAR index with domain `[0, BarCount)`.

<b>The factories copy.</b> Immutability is unconditional rather than dependent on caller
            discipline, so a [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries') and every [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries') derived from
            it are safe for unrestricted concurrent use with no caveat. Because the factories take
            [System\.ReadOnlySpan&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1'), a caller with an oversized scratch buffer pays only for the valid
            region: `PriceSeries.FromHlc(high.AsSpan(0, count), low.AsSpan(0, count), close.AsSpan(0, count))`.

<b>The factories reject non-finite prices.</b> A [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') close — a gapped tick,
            a provider sentinel, a bad CSV parse — is refused at the boundary with an
            [System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException') naming the component and the first offending bar. It has to be:
            the running sums inside TA-Lib's simple moving average, and the recursions inside the
            exponential moving average, the average true range and the relative strength index, all
            propagate a single [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') to every later bar. One bad tick would otherwise
            poison the whole series while every status flag still read success, and
            `if (sma[bar] is { } value)` would keep succeeding with a value that compares
            `false` against every threshold. The factories already walk the data to copy it, so the
            check costs nothing.

<b>There is no <c>startIdx</c> or <c>endIdx</c> anywhere on this surface.</b> Indicators always
            analyse the full series, so the first bar of a result is always the indicator's true lookback,
            and a caller can never trigger the unguarded end-index buffer overrun that a raw
            `TAMath` call permits. Windowing is expressed by [AsOf\(int\)](PriceSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.PriceSeries\.AsOf\(int\)'), which keeps bar
            indices absolute instead of rebasing them.

<b>Missing components are never fabricated.</b> A close-only series does not pretend that open,
            high and low equal the close; asking for them throws. Otherwise an ATR would silently compute
            the absolute change in close and call it a true range.

<b>There is no caching.</b> Calling `prices.Sma(20)` twice computes twice. Because this is
            a value type with no lazy state, caching is one field at the composition root when it is wanted,
            and there is no shared mutable state and no locking when it is not.

| Properties | |
| :--- | :--- |
| [BarCount](PriceSeries.BarCount.md 'TechnicalAnalysis\.Functions\.PriceSeries\.BarCount') | Gets the number of bars in the series\. |
| [Close](PriceSeries.Close.md 'TechnicalAnalysis\.Functions\.PriceSeries\.Close') | Gets the closing prices\. |
| [Empty](PriceSeries.Empty.md 'TechnicalAnalysis\.Functions\.PriceSeries\.Empty') | Gets the empty price series\. |
| [HasHighLow](PriceSeries.HasHighLow.md 'TechnicalAnalysis\.Functions\.PriceSeries\.HasHighLow') | Gets a value indicating whether the series carries high and low prices\. |
| [HasOpen](PriceSeries.HasOpen.md 'TechnicalAnalysis\.Functions\.PriceSeries\.HasOpen') | Gets a value indicating whether the series carries opening prices\. |
| [HasVolume](PriceSeries.HasVolume.md 'TechnicalAnalysis\.Functions\.PriceSeries\.HasVolume') | Gets a value indicating whether the series carries volumes\. |
| [High](PriceSeries.High.md 'TechnicalAnalysis\.Functions\.PriceSeries\.High') | Gets the high prices\. |
| [IsEmpty](PriceSeries.IsEmpty.md 'TechnicalAnalysis\.Functions\.PriceSeries\.IsEmpty') | Gets a value indicating whether the series holds no bars\. |
| [Low](PriceSeries.Low.md 'TechnicalAnalysis\.Functions\.PriceSeries\.Low') | Gets the low prices\. |
| [Open](PriceSeries.Open.md 'TechnicalAnalysis\.Functions\.PriceSeries\.Open') | Gets the opening prices\. |
| [Volume](PriceSeries.Volume.md 'TechnicalAnalysis\.Functions\.PriceSeries\.Volume') | Gets the volumes\. |

| Methods | |
| :--- | :--- |
| [Align\(SingleOutputResult\)](PriceSeries.Align.md#TechnicalAnalysis.Functions.PriceSeries.Align(TechnicalAnalysis.Common.SingleOutputResult) 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\(TechnicalAnalysis\.Common\.SingleOutputResult\)') | Bar\-aligns the result of any single\-output `TAMath` call made over this price series\. |
| [Align&lt;TResult&gt;\(TResult, Func&lt;TResult,double\[\]&gt;\)](PriceSeries.Align.md#TechnicalAnalysis.Functions.PriceSeries.Align_TResult_(TResult,System.Func_TResult,double[]_) 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\<TResult\>\(TResult, System\.Func\<TResult,double\[\]\>\)') | Bar\-aligns one output of any multi\-output `TAMath` call made over this price series\. |
| [AsOf\(int\)](PriceSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.PriceSeries\.AsOf\(int\)') | Returns the same price series truncated so that it ends at the given BAR index\. |
| [Equals\(object\)](PriceSeries.Equals.md#TechnicalAnalysis.Functions.PriceSeries.Equals(object) 'TechnicalAnalysis\.Functions\.PriceSeries\.Equals\(object\)') | Determines whether this price series equals the given object\. |
| [Equals\(PriceSeries\)](PriceSeries.Equals.md#TechnicalAnalysis.Functions.PriceSeries.Equals(TechnicalAnalysis.Functions.PriceSeries) 'TechnicalAnalysis\.Functions\.PriceSeries\.Equals\(TechnicalAnalysis\.Functions\.PriceSeries\)') | Determines whether this price series equals another\. |
| [FromClose\(ReadOnlySpan&lt;double&gt;\)](PriceSeries.FromClose(ReadOnlySpan_double_).md 'TechnicalAnalysis\.Functions\.PriceSeries\.FromClose\(System\.ReadOnlySpan\<double\>\)') | Creates a price series from closing prices alone\. |
| [FromHlc\(ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;\)](PriceSeries.FromHlc(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md 'TechnicalAnalysis\.Functions\.PriceSeries\.FromHlc\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)') | Creates a price series from high, low and closing prices\. |
| [FromOhlc\(ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;\)](PriceSeries.FromOhlc(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlc\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)') | Creates a price series from open, high, low and closing prices\. |
| [FromOhlcv\(ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;, ReadOnlySpan&lt;double&gt;\)](PriceSeries.FromOhlcv(ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_,ReadOnlySpan_double_).md 'TechnicalAnalysis\.Functions\.PriceSeries\.FromOhlcv\(System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>, System\.ReadOnlySpan\<double\>\)') | Creates a price series from open, high, low and closing prices together with volumes\. |
| [GetHashCode\(\)](PriceSeries.GetHashCode().md 'TechnicalAnalysis\.Functions\.PriceSeries\.GetHashCode\(\)') | Returns a hash code consistent with [Equals\(PriceSeries\)](PriceSeries.Equals.md#TechnicalAnalysis.Functions.PriceSeries.Equals(TechnicalAnalysis.Functions.PriceSeries) 'TechnicalAnalysis\.Functions\.PriceSeries\.Equals\(TechnicalAnalysis\.Functions\.PriceSeries\)')\. |

| Operators | |
| :--- | :--- |
| [operator ==\(PriceSeries, PriceSeries\)](PriceSeries.operator(PriceSeries,PriceSeries).md 'TechnicalAnalysis\.Functions\.PriceSeries\.op\_Equality\(TechnicalAnalysis\.Functions\.PriceSeries, TechnicalAnalysis\.Functions\.PriceSeries\)') | Determines whether two price series are equal\. |
| [operator \!=\(PriceSeries, PriceSeries\)](PriceSeries.operator!(PriceSeries,PriceSeries).md 'TechnicalAnalysis\.Functions\.PriceSeries\.op\_Inequality\(TechnicalAnalysis\.Functions\.PriceSeries, TechnicalAnalysis\.Functions\.PriceSeries\)') | Determines whether two price series are not equal\. |
