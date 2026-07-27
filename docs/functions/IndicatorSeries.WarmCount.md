#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.WarmCount Property

Gets the number of bars that carry a value — TA\-Lib's `NBElement`\.

```csharp
public int WarmCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A count in the range `[0, BarCount]`, expressed in ARRAY space: it is the length of
[WarmValues](IndicatorSeries.WarmValues.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.WarmValues')\. It is deliberately \<b\>not\</b\> called `Count`, because on a
type with an indexer `Count` reads as "the number of valid indices" and this is not
that: the indexer's domain is `[0, BarCount)`\. Looping `for (int i = 0; i <
            s.WarmCount; i++) s[i]` would read the wrong bars and silently drop the most recent
ones\. The last bar that carries a value is [LastBar](IndicatorSeries.LastBar.md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.LastBar'), which is
`FirstBar + WarmCount - 1`\.