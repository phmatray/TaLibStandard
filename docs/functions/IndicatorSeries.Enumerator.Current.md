#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries').[Enumerator](IndicatorSeries.Enumerator.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Enumerator')

## IndicatorSeries\.Enumerator\.Current Property

Gets the current bar and its value\.

```csharp
public readonly (int Bar,double Value) Current { get; }
```

#### Property Value
[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')  
A pair whose `Bar` is a BAR index in `[FirstBar, LastBar]` and whose
`Value` is the value at that bar\. Valid only after [MoveNext\(\)](IndicatorSeries.Enumerator.MoveNext().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Enumerator\.MoveNext\(\)') has
returned `true`\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
[MoveNext\(\)](IndicatorSeries.Enumerator.MoveNext().md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Enumerator\.MoveNext\(\)') has not yet been called, or it has already returned
            `false`\. `foreach` never reaches this state; hand\-driving the enumerator can,
            and a [System\.NullReferenceException](https://learn.microsoft.com/en-us/dotnet/api/system.nullreferenceexception 'System\.NullReferenceException') out of a public API would read as a library
            defect rather than as caller misuse\.