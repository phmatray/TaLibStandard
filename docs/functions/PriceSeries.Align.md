#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

## PriceSeries\.Align Method

| Overloads | |
| :--- | :--- |
| [Align\(SingleOutputResult\)](PriceSeries.Align.md#TechnicalAnalysis.Functions.PriceSeries.Align(TechnicalAnalysis.Common.SingleOutputResult) 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\(TechnicalAnalysis\.Common\.SingleOutputResult\)') | Bar\-aligns the result of any single\-output `TAMath` call made over this price series\. |
| [Align&lt;TResult&gt;\(TResult, Func&lt;TResult,double\[\]&gt;\)](PriceSeries.Align.md#TechnicalAnalysis.Functions.PriceSeries.Align_TResult_(TResult,System.Func_TResult,double[]_) 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\<TResult\>\(TResult, System\.Func\<TResult,double\[\]\>\)') | Bar\-aligns one output of any multi\-output `TAMath` call made over this price series\. |

<a name='TechnicalAnalysis.Functions.PriceSeries.Align(TechnicalAnalysis.Common.SingleOutputResult)'></a>

## PriceSeries\.Align\(SingleOutputResult\) Method

Bar\-aligns the result of any single\-output `TAMath` call made over this price series\.

```csharp
public TechnicalAnalysis.Functions.IndicatorSeries Align(TechnicalAnalysis.Common.SingleOutputResult result);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.PriceSeries.Align(TechnicalAnalysis.Common.SingleOutputResult).result'></a>

`result` [TechnicalAnalysis\.Common\.SingleOutputResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.singleoutputresult 'TechnicalAnalysis\.Common\.SingleOutputResult')

The raw result\. It must have been computed over this series with a start index of `0`
and an end index of `BarCount - 1`, otherwise its alignment metadata does not describe
these bars\.

#### Returns
[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')  
An [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries') addressed by BAR index\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[result](PriceSeries.md#TechnicalAnalysis.Functions.PriceSeries.Align(TechnicalAnalysis.Common.SingleOutputResult).result 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\(TechnicalAnalysis\.Common\.SingleOutputResult\)\.result') is `null`\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The result's alignment metadata is inconsistent with this series — its
`BegIdx + NBElement` does not fit inside [BarCount](PriceSeries.BarCount.md 'TechnicalAnalysis\.Functions\.PriceSeries\.BarCount'), or its
`NBElement` exceeds its own output array\. That is a defect in the indicator rather than
in this call, and it is surfaced rather than clamped because clamping would hand back a
silently shifted series\. The parameter named by the exception is
[result](PriceSeries.md#TechnicalAnalysis.Functions.PriceSeries.Align(TechnicalAnalysis.Common.SingleOutputResult).result 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\(TechnicalAnalysis\.Common\.SingleOutputResult\)\.result')\.

### Remarks

This is the escape hatch to the roughly eighty single-output indicators that have no fluent
wrapper yet, and it is the same primitive the shipped wrappers use, so an indicator reached
this way is aligned exactly as carefully as one that ships. The bar count is supplied by this
series, so it can never be mismatched.

<b>The values are copied.</b>`result.Real` stays the caller's array and may be
            post-processed in place afterwards without disturbing the series handed back, which is what
            makes [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries') unconditionally immutable rather than immutable by
            convention. The copy is O(`NBElement`) against an O(n) indicator computation.

<b>Naming your own extension methods.</b> The fluent indicators are extension methods on
            this type declared in this namespace, and the set of them will grow towards the full TA-Lib
            surface. A user-authored `public static IndicatorSeries Cci(this PriceSeries, int)`
            therefore becomes ambiguous (CS0121) the day the library ships its own `Cci`. Give your
            own extensions names the library will never take — a prefix such as `MyCci`, or a
            receiver type of your own — and treat the arrival of new indicators as potentially
            source-breaking for code that does otherwise.

<a name='TechnicalAnalysis.Functions.PriceSeries.Align_TResult_(TResult,System.Func_TResult,double[]_)'></a>

## PriceSeries\.Align\<TResult\>\(TResult, Func\<TResult,double\[\]\>\) Method

Bar\-aligns one output of any multi\-output `TAMath` call made over this price series\.

```csharp
public TechnicalAnalysis.Functions.IndicatorSeries Align<TResult>(TResult result, System.Func<TResult,double[]> output)
    where TResult : TechnicalAnalysis.Common.IndicatorResult;
```
#### Type parameters

<a name='TechnicalAnalysis.Functions.PriceSeries.Align_TResult_(TResult,System.Func_TResult,double[]_).TResult'></a>

`TResult`

The concrete result type\.
#### Parameters

<a name='TechnicalAnalysis.Functions.PriceSeries.Align_TResult_(TResult,System.Func_TResult,double[]_).result'></a>

`result` [TResult](PriceSeries.md#TechnicalAnalysis.Functions.PriceSeries.Align_TResult_(TResult,System.Func_TResult,double[]_).TResult 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\<TResult\>\(TResult, System\.Func\<TResult,double\[\]\>\)\.TResult')

The raw result\. It must have been computed over this series with a start index of `0`
and an end index of `BarCount - 1`\.

<a name='TechnicalAnalysis.Functions.PriceSeries.Align_TResult_(TResult,System.Func_TResult,double[]_).output'></a>

`output` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TResult](PriceSeries.md#TechnicalAnalysis.Functions.PriceSeries.Align_TResult_(TResult,System.Func_TResult,double[]_).TResult 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\<TResult\>\(TResult, System\.Func\<TResult,double\[\]\>\)\.TResult')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Selects the output array to align, from the same result whose metadata is used\. Taking a
selector rather than a separate array is what prevents one result's metadata being paired
with another result's values, which would be a brand new way to misalign a series\.

#### Returns
[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')  
An [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries') addressed by BAR index\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[result](PriceSeries.md#TechnicalAnalysis.Functions.PriceSeries.Align_TResult_(TResult,System.Func_TResult,double[]_).result 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\<TResult\>\(TResult, System\.Func\<TResult,double\[\]\>\)\.result') or [output](PriceSeries.md#TechnicalAnalysis.Functions.PriceSeries.Align_TResult_(TResult,System.Func_TResult,double[]_).output 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\<TResult\>\(TResult, System\.Func\<TResult,double\[\]\>\)\.output') is `null`\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The result's alignment metadata is inconsistent with this series; see
[Align\(SingleOutputResult\)](PriceSeries.Align.md#TechnicalAnalysis.Functions.PriceSeries.Align(TechnicalAnalysis.Common.SingleOutputResult) 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\(TechnicalAnalysis\.Common\.SingleOutputResult\)')\. The parameter named by the exception is
[result](PriceSeries.md#TechnicalAnalysis.Functions.PriceSeries.Align_TResult_(TResult,System.Func_TResult,double[]_).result 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\<TResult\>\(TResult, System\.Func\<TResult,double\[\]\>\)\.result')\.

### Remarks
The selected values are copied, so the result's own array remains the caller's to mutate\.
The naming guidance on [Align\(SingleOutputResult\)](PriceSeries.Align.md#TechnicalAnalysis.Functions.PriceSeries.Align(TechnicalAnalysis.Common.SingleOutputResult) 'TechnicalAnalysis\.Functions\.PriceSeries\.Align\(TechnicalAnalysis\.Common\.SingleOutputResult\)') applies here too\.